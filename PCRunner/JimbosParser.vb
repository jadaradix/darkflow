Module JimbosParser

    'Operators

    Enum DFOperatorIdentifier
        Divide = 0
        Multiply = 1
        Add = 2
        Subtract = 3
        Modulus = 4
    End Enum

    Class DFOperator
        Dim Descriptor As String
        Public Findable As String
        Public Identifier As Byte
        Sub New(ByVal PDescriptor As String, ByVal PFindable As String, ByVal PIdentifier As Byte)
            Descriptor = PDescriptor
            Findable = PFindable
            Identifier = PIdentifier
        End Sub
    End Class
    Dim DFOperators As New List(Of DFOperator)

    Sub AddOperator(ByVal PDescriptor As String, ByVal PFindable As String, ByVal PIdentifier As Byte)
        Dim F As New DFOperator(PDescriptor, PFindable, PIdentifier)
        DFOperators.Add(F)
    End Sub

    Sub InitOperators()
        AddOperator("Divide", "/", DFOperatorIdentifier.Divide)
        AddOperator("Multiply", "*", DFOperatorIdentifier.Multiply)
        AddOperator("Add", "+", DFOperatorIdentifier.Add)
        AddOperator("Subtract", "-", DFOperatorIdentifier.Subtract)
        AddOperator("Modulus", "%", DFOperatorIdentifier.Modulus)
    End Sub

    'Variables

    Class DFInternalVariable
        Public ParseSymbol As String
        Public Descriptor As String
        Sub New(ByVal PParseSymbol As String, ByVal PDescriptor As String)
            ParseSymbol = PParseSymbol
            Descriptor = PDescriptor
        End Sub
    End Class
    Dim DFInternalVariables As New List(Of DFInternalVariable)

    Sub AddInternalVariable(ByVal PParseSymbol As String, ByVal PDescriptor As String)
        Dim V As New DFInternalVariable(PParseSymbol, PDescriptor)
        DFInternalVariables.Add(V)
    End Sub

    Sub InitInternalVariables()
        AddInternalVariable("View_VX", "View X Velocity")
        AddInternalVariable("View_VY", "View X Velocity")
        AddInternalVariable("View_VX", "View X Velocity")
    End Sub

    Function ParseSomethingReturn(ByVal Input As Object, ByVal ForceNumeric As Boolean) As Object
        If ForceNumeric Then
            Return Convert.ToDouble(Input)
        End If
        Return Convert.ToString(Input)
    End Function

    Function ParseExpressionTop(ByVal MyExpression As String, ByVal MyOperator As Byte, ByRef Variables As List(Of Variable), ByVal InstanceID As UInt16)
        Dim StringOperator As String = String.Empty
        For Each P As DFOperator In DFOperators
            If P.Identifier = MyOperator Then
                StringOperator = P.Findable
            End If
        Next
        If StringOperator.Length = 0 Then Return ParseSomethingReturn(0, True)
        Dim TLeft As String = MyExpression.Substring(0, MyExpression.IndexOf(StringOperator)).Trim()
        Dim TRight As String = MyExpression.Substring(MyExpression.IndexOf(StringOperator) + 1).Trim()
        Dim Evaluated As New Object
        Select Case MyOperator
            Case DFOperatorIdentifier.Divide
                Evaluated = (ParseSomething(Variables, TLeft, InstanceID, True) / ParseSomething(Variables, TRight, InstanceID, True))
            Case DFOperatorIdentifier.Multiply
                Evaluated = (ParseSomething(Variables, TLeft, InstanceID, True) * ParseSomething(Variables, TRight, InstanceID, True))
            Case DFOperatorIdentifier.Add
                Evaluated = (ParseSomething(Variables, TLeft, InstanceID, True) + ParseSomething(Variables, TRight, InstanceID, True))
            Case DFOperatorIdentifier.Subtract
                Evaluated = (ParseSomething(Variables, TLeft, InstanceID, True) - ParseSomething(Variables, TRight, InstanceID, True))
            Case DFOperatorIdentifier.Modulus
                Evaluated = (ParseSomething(Variables, TLeft, InstanceID, True) Mod ParseSomething(Variables, TRight, InstanceID, True))
        End Select
        Return ParseSomethingReturn(Evaluated, True)
    End Function

    Function ParseSomething(ByRef Variables As List(Of Variable), ByVal Input As Object, ByVal InstanceID As UInt16, ByVal DemandsNum As Boolean) As Object
        If Not InstanceID < CusA.Instances.Count Then Return ParseSomethingReturn(0, True)
        Dim StrRep As String = Convert.ToString(Input).Trim()
        If StrRep.StartsWith("""") And StrRep.EndsWith("""") Then
            StrRep = StrRep.Substring(1)
            StrRep = StrRep.Substring(0, StrRep.Length - 1)
            Return StrRep
        End If
        Dim StrRepU As String = StrRep.ToUpper()
        For Each P As DFOperator In DFOperators
            Dim checkStr As String = StrRep
            Dim newstr As String = ""
            If checkStr.Contains("{") Then
                Dim counting As Boolean = False
                For Each Str As Char In checkStr
                    If counting Then
                        If Str = "}" Then
                            counting = False
                        Else
                            Str = "X"
                        End If
                    End If
                    If Str = "{" Then counting = True
                    newstr = newstr + Str
                Next
                checkStr = newstr

            End If
            If checkStr.Contains(P.Findable) Then
                Return ParseExpressionTop(StrRep, P.Identifier, Variables, InstanceID)
            End If
        Next
        If StrRep.StartsWith("[") And StrRep.EndsWith("]") Then
            Dim DProperty As String = StrRep.Substring(1)
            DProperty = DProperty.Substring(0, DProperty.Length - 1)
            DProperty = DProperty.ToUpper
            Select Case DProperty
                Case "X"
                    Return ParseSomethingReturn(CusA.Instances(InstanceID).X, True)
                Case "Y"
                    Return ParseSomethingReturn(CusA.Instances(InstanceID).Y, True)
                Case "VX"
                    Return ParseSomethingReturn(CusA.Instances(InstanceID).VX, True)
                Case "VY"
                    Return ParseSomethingReturn(CusA.Instances(InstanceID).VY, True)
                Case "AX"
                    Return ParseSomethingReturn(CusA.Instances(InstanceID).AX, True)
                Case "AY"
                    Return ParseSomethingReturn(CusA.Instances(InstanceID).AY, True)
                Case "DEPTH"
                    Return ParseSomethingReturn(CusA.Instances(InstanceID).Depth, True)
                Case "FRAME"
                    Return ParseSomethingReturn(CusA.Instances(InstanceID).Frame, True)
                Case "FRAMESPEED"
                    Return ParseSomethingReturn(CusA.Instances(InstanceID).FrameSpeed, True)
                Case "V"
                    Return ParseSomethingReturn(CusA.Instances(InstanceID).V, True)
                Case "VA"
                    Return ParseSomethingReturn(CusA.Instances(InstanceID).VA, True)
                Case "A"
                    Return ParseSomethingReturn(CusA.Instances(InstanceID).A, True)
                Case "AA"
                    Return ParseSomethingReturn(CusA.Instances(InstanceID).AA, True)
                Case "T"
                    Return ParseSomethingReturn(CusA.Instances(InstanceID).T, True)
                Case "TV"
                    Return ParseSomethingReturn(CusA.Instances(InstanceID).TV, True)
            End Select
        End If
        Dim TempOut As Double = 0
        If Double.TryParse(Input, TempOut) Then
            Return ParseSomethingReturn(TempOut, True)
        Else
            'FIX 1
            If StrRepU = "SCENE_WIDTH" Then
                Return ParseSomethingReturn(CusA.Width, True)
            ElseIf StrRepU = "SCENE_HEIGHT" Then
                Return ParseSomethingReturn(CusA.Height, True)
            ElseIf StrRepU = "VIEW_X" Then
                Return ParseSomethingReturn(CusA.ViewX, True)
            ElseIf StrRepU = "VIEW_Y" Then
                Return ParseSomethingReturn(CusA.ViewY, True)
            ElseIf StrRepU = "VIEW_VX" Then
                Return ParseSomethingReturn(View_VX, True)
            ElseIf StrRepU = "VIEW_VY" Then
                Return ParseSomethingReturn(View_VY, True)
            ElseIf StrRepU = "VIEW_WIDTH" Then
                Return ParseSomethingReturn(CusA.ViewWidth, True)
            ElseIf StrRepU = "VIEW_HEIGHT" Then
                Return ParseSomethingReturn(CusA.ViewHeight, True)
            ElseIf StrRepU = "POINTER_X" Then
                Return ParseSomethingReturn(Pointer_X, True)
            ElseIf StrRepU = "POINTER_Y" Then
                Return ParseSomethingReturn(Pointer_Y, True)
            ElseIf StrRepU = "POINTER_HELD" Then
                Return ParseSomethingReturn(If(Pointer_Held, 1, 0), True)
            End If
            If StrRepU.StartsWith("IS_DIVISIBLE(") And StrRepU.EndsWith(")") Then
                StrRep = StrRep.Substring(("IS_DIVISIBLE").Length + 1)
                StrRep = StrRep.Substring(0, StrRep.Length - 1)
                Dim FInput As String = StrRep.Substring(0, StrRep.IndexOf(","))
                Dim FDivisor As String = StrRep.Substring(StrRep.IndexOf(",") + 1)
                Dim NewFInput As Double = ParseSomething(Variables, FInput, InstanceID, True)
                Dim NewFDivisor As Double = ParseSomething(Variables, FDivisor, InstanceID, True)
                Return ParseSomethingReturn(If(Is_Divisible(NewFInput, NewFDivisor), 1, 0), True)
            End If
            If StrRepU.StartsWith("GET_ANGLE(") And StrRepU.EndsWith(")") Then
                StrRep = StrRep.Substring(("GET_ANGLE").Length + 1)
                StrRep = StrRep.Substring(0, StrRep.Length - 1)
                Dim Xco As String = StrRep.Substring(0, StrRep.IndexOf(","))
                Dim Yco As String = StrRep.Substring(StrRep.IndexOf(",") + 1)
                Dim NewXCo As Double = ParseSomething(Variables, Xco, InstanceID, True)
                Dim NewYCo As Double = ParseSomething(Variables, Yco, InstanceID, True)
                Dim Xpart As Double = NewXCo - CusA.Instances(InstanceID).X
                Dim Ypart As Double = NewYCo - CusA.Instances(InstanceID).Y
                Dim theta As Double = Math.Atan(Ypart / Xpart)
                theta = theta * 180 / Math.PI
                If Xpart < 0 Then theta = theta + 180
                While theta >= 360
                    theta -= 360
                End While
                While theta < 0
                    theta += 360
                End While
                Return theta
            End If
            If StrRepU.StartsWith("SIN(") And StrRepU.EndsWith(")") Then
                StrRep = StrRep.Substring(("SIN").Length + 1)
                StrRep = StrRep.Substring(0, StrRep.Length - 1)
                Return Math.Sin(Math.PI * ParseSomething(Variables, StrRep, InstanceID, True) / 180)
            End If
            If StrRepU.StartsWith("COS(") And StrRepU.EndsWith(")") Then
                StrRep = StrRep.Substring(("COS").Length + 1)
                StrRep = StrRep.Substring(0, StrRep.Length - 1)
                Return Math.Cos(Math.PI * ParseSomething(Variables, StrRep, InstanceID, True) / 180)
            End If
            If StrRepU.StartsWith("MULTIPLE_OF(") And StrRepU.EndsWith(")") Then
                StrRep = StrRep.Substring(("MULTIPLE_OF").Length + 1)
                StrRep = StrRep.Substring(0, StrRep.Length - 1)
                Dim Value As String = StrRep.Substring(0, StrRep.IndexOf(","))
                Dim Multiple As String = StrRep.Substring(StrRep.IndexOf(",") + 1)
                Dim NewValue As Double = ParseSomething(Variables, Value, InstanceID, True)
                Dim NewMultiple As Double = ParseSomething(Variables, Multiple, InstanceID, True)
                Return ParseSomethingReturn(If(NewValue Mod NewMultiple = 0, 1, 0), True)
            End If
            If StrRepU.StartsWith("RANDOM(") And StrRepU.EndsWith(")") Then
                StrRep = StrRep.Substring(("RANDOM").Length + 1)
                StrRep = StrRep.Substring(0, StrRep.Length - 1)
                Dim Minimum As String = StrRep.Substring(0, StrRep.IndexOf(","))
                Dim Maximum As String = StrRep.Substring(StrRep.IndexOf(",") + 1)
                Dim NewMinimum As Double = ParseSomething(Variables, Minimum, InstanceID, True)
                Dim NewMaximum As Double = ParseSomething(Variables, Maximum, InstanceID, True)
                Return ParseSomethingReturn(Random(Math.Floor(NewMinimum), Math.Floor(NewMaximum)), True)
            End If
            While Input.ToString.ToLower.Contains("{")
                Dim start As String = Input.Substring(0, Input.IndexOf("{"))
                Dim arg As String = ParseSomething(Variables, Input.Substring(Input.IndexOf("{") + 1, Input.IndexOf("}") - Input.IndexOf("{") - 1), InstanceID, DemandsNum)
                Dim ender As String = Input.Substring(Input.IndexOf("}") + 1)
                Input = start + "<" + arg + ">" + ender
            End While
            Input = Input.Replace("<", "{")
            Input = Input.Replace(">", "}")
            If Input.ToString.ToLower.StartsWith("global.") Then
                Input = Input.Substring(7)
                If GlobalVariables.Count > 0 Then
                    For P As UInt16 = 0 To GlobalVariables.Count - 1
                        If GlobalVariables(P).Name = Input Then Return ParseSomethingReturn(GlobalVariables(P).Value, DemandsNum)
                    Next
                End If
            Else
                If Variables.Count > 0 Then
                    For P As UInt16 = 0 To Variables.Count - 1
                        If Variables(P).Name = Input.ToString Then Return ParseSomethingReturn(Variables(P).Value, DemandsNum)
                    Next
                End If
            End If
        End If
        Return ParseSomethingReturn(0, True)
    End Function

End Module
