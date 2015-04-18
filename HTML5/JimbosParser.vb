Module JimbosParser

    Public GlobalStarter As String = "global."

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

    Class DFInternalVariable
        Public InternalName As String
        Public UserName As String
        Sub New(ByVal PInternalName As String, ByVal PUserName As String)
            InternalName = PInternalName
            UserName = PUserName
        End Sub
    End Class
    Dim DFInternalVariables As New List(Of DFInternalVariable)

    Class DFFunction
        Public FName As String
        Public ArgumentCount As Byte
        Sub New(ByVal PFName As String, ByVal PArgumentCount As Byte)
            FName = PFName
            ArgumentCount = PArgumentCount
        End Sub
    End Class
    Dim DFFunctions As New List(Of DFFunction)

    Sub AddOperator(ByVal PDescriptor As String, ByVal PFindable As String, ByVal PIdentifier As Byte)
        Dim F As New DFOperator(PDescriptor, PFindable, PIdentifier)
        DFOperators.Add(F)
    End Sub

    Sub AddDFInternalVariable(ByVal PInternalName As String, ByVal PUserName As String)
        Dim F As New DFInternalVariable(PInternalName, PUserName)
        DFInternalVariables.Add(F)
    End Sub

    Sub AddDFFunction(ByVal PFName As String, ByVal PArgumentCount As Byte)
        Dim F As New DFFunction(PFName, PArgumentCount)
        DFFunctions.Add(F)
    End Sub

    Sub InitOperators()
        AddOperator("Divide", "/", DFOperatorIdentifier.Divide)
        AddOperator("Multiply", "*", DFOperatorIdentifier.Multiply)
        AddOperator("Add", "+", DFOperatorIdentifier.Add)
        AddOperator("Subtract", "-", DFOperatorIdentifier.Subtract)
        AddOperator("Modulus", "%", DFOperatorIdentifier.Modulus)
    End Sub

    Sub InitDFInternalVariables()
        AddDFInternalVariable("CS_Width", "SCENE_WIDTH")
        AddDFInternalVariable("CS_Height", "SCENE_HEIGHT")
        AddDFInternalVariable("CS_View_X", "VIEW_X")
        AddDFInternalVariable("CS_View_Y", "VIEW_Y")
        AddDFInternalVariable("CS_View_Width", "VIEW_WIDTH")
        AddDFInternalVariable("CS_View_Height", "VIEW_HEIGHT")
        AddDFInternalVariable("CS_View_VX", "VIEW_VX")
        AddDFInternalVariable("CS_View_VY", "VIEW_VY")
        AddDFInternalVariable("Pointer_X", "POINTER_X")
        AddDFInternalVariable("Pointer_Y", "POINTER_Y")
        AddDFInternalVariable("Pointer_Held", "POINTER_HELD")
    End Sub

    Public InstanceProperties As New List(Of String)
    Public ROInstanceProperties As New List(Of String)
    Public ROHInstanceProperties As New List(Of String)
    Public ROHSInstanceProperties As New List(Of String)
    Sub InitInstanceProperties()
        With InstanceProperties
            .Add("T")
            .Add("TV")
            .Add("X")
            .Add("Y")
            .Add("VX")
            .Add("VY")
            .Add("AX")
            .Add("AY")
            .Add("DEPTH")
            .Add("FRAME")
            .Add("FRAMEHEIGHT")
        End With
        With ROInstanceProperties
            .Add("AA")
            .Add("VA")
            .Add("A")
            .Add("V")
        End With
        With ROHInstanceProperties
            .Add("Get_Accel_Angle")
            .Add("Get_Direction")
            .Add("Get_Accel")
            .Add("Get_Speed")
        End With

        With ROHSInstanceProperties
            .Add("SetAccel")
            .Add("SetSpeed")
            .Add("SetAccelDir")
            .Add("SetDirection")
        End With
    End Sub

    Sub InitFunctions()
        AddDFFunction("Random", 2)
        AddDFFunction("Is_Divisible", 2)
        AddDFFunction("Round_Up", 2)
        AddDFFunction("Round_Down", 2)
        AddDFFunction("Sin", 1)
        AddDFFunction("Cos", 1)
        AddDFFunction("Get_angle", 2)
    End Sub

    Function ParserSplitter(ByVal MyExpression As String, ByVal MyOperator As Byte) As String
        Dim StringOperator As String = String.Empty
        For Each P As DFOperator In DFOperators
            If P.Identifier = MyOperator Then
                StringOperator = P.Findable
            End If
        Next
        If StringOperator.Length = 0 Then Return "0"
        Dim TLeft As String = MyExpression.Substring(0, MyExpression.IndexOf(StringOperator)).Trim()
        Dim TRight As String = MyExpression.Substring(MyExpression.IndexOf(StringOperator) + 1).Trim()
        Select Case MyOperator
            Case DFOperatorIdentifier.Divide
                Return (Parser(TLeft) + " / " + Parser(TRight))
            Case DFOperatorIdentifier.Multiply
                Return (Parser(TLeft) + " * " + Parser(TRight))
            Case DFOperatorIdentifier.Add
                Return (Parser(TLeft) + " + " + Parser(TRight))
            Case DFOperatorIdentifier.Subtract
                Return (Parser(TLeft) + " - " + Parser(TRight))
            Case DFOperatorIdentifier.Modulus
                Return (Parser(TLeft) + " % " + Parser(TRight))
        End Select
        Return String.Empty
    End Function

    Function HighLevelStringParser(ByVal Input As String) As String

        Dim Returnable As String = Input.Trim()

        'SPEECH MARKS
        Dim SpeechMarkCount As UInt16 = 0
        For Each I As String In Returnable
            If I = """" Then SpeechMarkCount += 1
        Next

        If SpeechMarkCount = 2 And Returnable.StartsWith("""") And Returnable.EndsWith("""") Then
            Return Returnable 'No point in going any Firther
        End If

        Dim Test As String = Parser(Input)

        If Test = Returnable Then Return """" + Returnable + """" Else Return Returnable

    End Function

    Function Parser(ByVal Input As String, Optional ByVal IsSetting As Boolean = False) As String

        Dim Returnable As String = Input.Trim()

        If Not IsSetting Then

            'SPEECH MARKS
            Dim SpeechMarkCount As UInt16 = 0
            For Each I As String In Returnable
                If I = """" Then SpeechMarkCount += 1
            Next

            If SpeechMarkCount = 2 And Returnable.StartsWith("""") And Returnable.EndsWith("""") Then
                Return Returnable 'No point in going any Firther
            End If

            'NUMBER
            Dim Out As Double
            Dim Success As Boolean = Double.TryParse(Returnable, Out)
            If Success Then
                Return Returnable
            End If

            For Each P As DFOperator In DFOperators
                Dim checkStr As String = Returnable
                Dim newstr As String = ""
                If checkStr.Contains("{") Then
                    Dim i As Integer = 0
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
                    Return ParserSplitter(Returnable, P.Identifier)
                End If
            Next

        End If

        Dim DoExit As Boolean = False

        'GLOBAL BREAK
        DoExit = False
        If Returnable.StartsWith(GlobalStarter) Then
            Returnable = Returnable.Substring(GlobalStarter.Length)
            DoExit = True
        End If
        If DoExit Then
            
            Dim i As Byte = 0
            Dim ArrayVal1 As String = 0
            Dim ArrayVal2 As String = 0
            Dim ArrayVal3 As String = 0

            Dim orig As String = Returnable
            If orig.Contains("{") Then
                Returnable = orig.Substring(0, orig.IndexOf("{"))
                While orig.Contains("{")
                    If i = 0 Then ArrayVal1 = Parser(orig.Substring(orig.IndexOf("{") + 1, orig.IndexOf("}") - orig.IndexOf("{") - 1))
                    If i = 1 Then ArrayVal2 = Parser(orig.Substring(orig.IndexOf("{") + 1, orig.IndexOf("}") - orig.IndexOf("{") - 1))
                    If i = 2 Then ArrayVal3 = Parser(orig.Substring(orig.IndexOf("{") + 1, orig.IndexOf("}") - orig.IndexOf("{") - 1))
                    orig = orig.Substring(orig.IndexOf("}") + 1)
                    i += 1
                    If i = 3 Then Exit While
                End While
            End If
            Return "DF_Get_Global_Variable(""" + Returnable + """, " + ArrayVal1 + ", " + ArrayVal2 + ", " + ArrayVal3 + ")"

            Return Returnable
        End If

        'DF INTERNAL VARIABLES
        DoExit = False
        For Each P As DFInternalVariable In DFInternalVariables
            'MsgBox("""" + Returnable.ToUpper + """, """ + P.UserName + """")

            If Returnable.ToUpper = P.UserName Then Returnable = P.InternalName : DoExit = True : Exit For
        Next
        If DoExit Then Return Returnable

        'INSTANCE PROPERTIES
        DoExit = False
        For U As UInt16 = 0 To InstanceProperties.Count - 1
            If Returnable = "[" + InstanceProperties(U) + "]" Then
                Returnable = "Instances[ActualApplies]." + InstanceProperties(U)
                DoExit = True
                Exit For
            End If
        Next
        For U As UInt16 = 0 To ROInstanceProperties.Count - 1
            If Returnable = "[" + ROInstanceProperties(U) + "]" Then
                Returnable = ROHInstanceProperties(U) + "(ActualApplies)"
                DoExit = True
                Exit For
            End If
        Next
        If DoExit Then Return Returnable

        If Not IsSetting Then

            'FUNCTIONS
            DoExit = False
            For Each P As DFFunction In DFFunctions
                If Returnable.ToUpper.StartsWith(P.FName.ToUpper + "(") And Returnable.EndsWith(")") Then
                    Dim ParameterList As String = Returnable
                    ParameterList = ParameterList.Substring(P.FName.Length + 1)
                    ParameterList = ParameterList.Substring(0, ParameterList.Length - 1)
                    Dim Parameters() As String = ParameterList.Split(",")
                    Dim NewParameterList As String = String.Empty
                    If P.FName = "Get_angle" Then NewParameterList += "ActualApplies,"
                    For Each D As String In Parameters
                        'MsgBox(Parser(D))
                        NewParameterList += Parser(D) + ", "
                    Next
                    NewParameterList = NewParameterList.Substring(0, NewParameterList.Length - 2)
                    Returnable = P.FName + "(" + NewParameterList + ")"
                    DoExit = True
                    Exit For
                End If
            Next
            If DoExit Then Return Returnable

            'CONSTANTS

            If Returnable.ToUpper = "TRUE" Then
                Return "true"
            ElseIf Returnable.ToUpper = "FALSE" Then
                Return "false"
            End If

            'DF INSTANCE LEVEL VARIABLES
            Dim i As Byte = 0
            Dim ArrayVal1 As String = 0
            Dim ArrayVal2 As String = 0
            Dim ArrayVal3 As String = 0

            Dim orig As String = Returnable
            If orig.Contains("{") Then
                Returnable = orig.Substring(0, orig.IndexOf("{"))
                While orig.Contains("{")
                    If i = 0 Then ArrayVal1 = Parser(orig.Substring(orig.IndexOf("{") + 1, orig.IndexOf("}") - orig.IndexOf("{") - 1))
                    If i = 1 Then ArrayVal2 = Parser(orig.Substring(orig.IndexOf("{") + 1, orig.IndexOf("}") - orig.IndexOf("{") - 1))
                    If i = 2 Then ArrayVal3 = Parser(orig.Substring(orig.IndexOf("{") + 1, orig.IndexOf("}") - orig.IndexOf("{") - 1))
                    orig = orig.Substring(orig.IndexOf("}") + 1)
                    i += 1
                    If i = 3 Then Exit While
                End While
            End If
            Return "DF_Get_Instance_Variable(ActualApplies, """ + Returnable + """, " + ArrayVal1 + ", " + ArrayVal2 + ", " + ArrayVal3 + ")"

        End If

        Return Returnable

    End Function

End Module

