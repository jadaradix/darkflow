Imports System.Media
Imports System.IO

Module DFunctions
    Public StackWorkForbidden As Boolean = False
    Public SwitchingScene = False

    Public IfCommands As New List(Of String)
    Public TimePassed As Integer = 0
    Public Settings As New List(Of String)
    Public SettingValues As New List(Of String)

    Sub ExpandArray(ByRef TheArray() As Byte, ByVal ElementCount As UInt64)
        Array.Resize(TheArray, TheArray.Length + ElementCount)
    End Sub

    Function DF_Ignore(ByVal InstanceID As UInt16) As Boolean
        Try
            Return Not CusA.Instances(InstanceID).InUse
        Catch
            Return True
        End Try
        'If Not CusA.Instances(InstanceID).InUse Then Return True
        'Return False
    End Function

    Function DF_Instance_In_Range(ByVal InstanceID As UInt16) As Boolean
        If DF_Ignore(InstanceID) Then Return False
        Dim X As Double = CusA.Instances(InstanceID).X
        Dim Y As Double = CusA.Instances(InstanceID).Y
        Dim W As UInt16 = CusA.Instances(InstanceID).Width
        Dim H As UInt16 = CusA.Instances(InstanceID).Height
        Return (Pointer_In And X < Pointer_X And (X + W) > Pointer_X And Y < Pointer_Y And (Y + H) > Pointer_Y)
    End Function

    Function NextInstance() As UInt16
        Dim Count As UInt16 = 0
        For I As UInt16 = 0 To CusA.Instances.Count - 1
            If Not CusA.Instances(I).InUse Then Return I
            Count += 1
        Next
        Return Count + 1
    End Function

    Function Get_Single_ID(ByVal DObject As String) As Int32
        For I As UInt16 = 0 To CusA.Instances.Count - 1
            If DF_Ignore(I) Then Continue For
            If CusA.Instances(I).ObjectName = DObject Then Return I
        Next
        Return -1
    End Function

    Function Collision(ByVal AppliesTo1 As UInt16, ByVal AppliesTo2 As UInt16) As Boolean

        Dim FrameHeight As UInt16 = 32
        Dim FrameHeight2 As UInt16 = 32
        For Each o As DImage In Images
            If o.Name = CusA.Instances(AppliesTo1).ImageName Then FrameHeight = o.FrameHeight
            If o.Name = CusA.Instances(AppliesTo2).ImageName Then FrameHeight2 = o.FrameHeight
        Next

        Dim Rect1 As New Rectangle(CusA.Instances(AppliesTo1).X, CusA.Instances(AppliesTo1).Y, CusA.Instances(AppliesTo1).Width, FrameHeight)
        Dim Rect2 As New Rectangle(CusA.Instances(AppliesTo2).X, CusA.Instances(AppliesTo2).Y, CusA.Instances(AppliesTo2).Width, FrameHeight2)

        Dim theta1 As Double = CusA.Instances(AppliesTo1).T
        Dim theta2 As Double = CusA.Instances(AppliesTo2).T
        While theta1 >= 360
            theta1 -= 360
        End While
        While theta1 < 0
            theta1 += 360
        End While
        While theta2 >= 360
            theta2 -= 360
        End While
        While theta2 < 0
            theta2 += 360
        End While

        Dim h As UInt16 = Rect1.Height
        Dim w As UInt16 = Rect1.Width
        Dim X As Int16 = Rect1.Location.X
        Dim Y As Int16 = Rect1.Location.Y
        Dim a As Double = Math.PI * theta1 / 180

        Dim P As New Point(Math.Round(X + 0.5 * (w - w * Math.Cos(a) + h * Math.Sin(a))), Math.Round(Y + 0.5 * (h - w * Math.Sin(a) - h * Math.Cos(a))))
        Dim Q As New Point(Math.Round(X + 0.5 * (w + w * Math.Cos(a) + h * Math.Sin(a))), Math.Round(Y + 0.5 * (h + w * Math.Sin(a) - h * Math.Cos(a))))
        Dim R As New Point(Math.Round(X + 0.5 * (w + w * Math.Cos(a) - h * Math.Sin(a))), Math.Round(Y + 0.5 * (h + w * Math.Sin(a) + h * Math.Cos(a))))
        Dim S As New Point(Math.Round(X + 0.5 * (w - w * Math.Cos(a) - h * Math.Sin(a))), Math.Round(Y + 0.5 * (h - w * Math.Sin(a) + h * Math.Cos(a))))

        If PointInRotatedRect(P, Rect2, theta2) Then Return True
        If PointInRotatedRect(Q, Rect2, theta2) Then Return True
        If PointInRotatedRect(R, Rect2, theta2) Then Return True
        If PointInRotatedRect(S, Rect2, theta2) Then Return True

        h = Rect2.Height
        w = Rect2.Width
        X = Rect2.Location.X
        Y = Rect2.Location.Y
        a = Math.PI * theta2 / 180

        P = New Point(Math.Round(X + 0.5 * (w - w * Math.Cos(a) + h * Math.Sin(a))), Math.Round(Y + 0.5 * (h - w * Math.Sin(a) - h * Math.Cos(a))))
        Q = New Point(Math.Round(X + 0.5 * (w + w * Math.Cos(a) + h * Math.Sin(a))), Math.Round(Y + 0.5 * (h + w * Math.Sin(a) - h * Math.Cos(a))))
        R = New Point(Math.Round(X + 0.5 * (w + w * Math.Cos(a) - h * Math.Sin(a))), Math.Round(Y + 0.5 * (h + w * Math.Sin(a) + h * Math.Cos(a))))
        S = New Point(Math.Round(X + 0.5 * (w - w * Math.Cos(a) - h * Math.Sin(a))), Math.Round(Y + 0.5 * (h - w * Math.Sin(a) + h * Math.Cos(a))))

        If PointInRotatedRect(P, Rect1, theta1) Then Return True
        If PointInRotatedRect(Q, Rect1, theta1) Then Return True
        If PointInRotatedRect(R, Rect1, theta1) Then Return True
        If PointInRotatedRect(S, Rect1, theta1) Then Return True
        Return False
    End Function

    Class StackElement
        Public EventType As String
        Public EventData As String
        Public IgnoreDataFilter As Boolean
        Public InstanceID As UInt16
        Public OtherInstanceID As UInt16
        Public UtiliseOther As Boolean
        Function Clone() As StackElement 'Circular Reference, Boys
            Dim Returnable As New StackElement
            With Returnable
                .EventType = EventType
                .EventData = EventData
                .IgnoreDataFilter = IgnoreDataFilter
                .InstanceID = InstanceID
                .OtherInstanceID = OtherInstanceID
                .UtiliseOther = UtiliseOther
            End With
            Return Returnable
        End Function
    End Class

    Public Stack As New List(Of StackElement)
    Public NewSceneStack As New List(Of StackElement)

    Sub PutOnStack(ByVal PEventType As String, ByVal PEventData As String, ByVal PIgnoreDataFilter As Boolean, ByVal PInstanceID As UInt16, ByVal POtherInstanceID As UInt16, ByVal PUtiliseOther As Boolean, Optional ByVal PutOnNewSceneStack As Boolean = False)
        If DEvents.Count = 0 Then Exit Sub
        Dim FoundOne As Boolean = False
        For D As UInt16 = 0 To DEvents.Count - 1
            If Not DEvents(D).EventType = PEventType Then Continue For
            If Not PIgnoreDataFilter Then
                If Not DEvents(D).EventData = PEventData Then Continue For
            End If
            If Not DEvents(D).ObjectName = CusA.Instances(PInstanceID).ObjectName Then Continue For
            FoundOne = True
        Next
        If Not FoundOne Then Exit Sub
        Dim S As New StackElement
        With S
            .EventType = PEventType
            .EventData = PEventData
            .IgnoreDataFilter = PIgnoreDataFilter
            .InstanceID = PInstanceID
            .OtherInstanceID = POtherInstanceID
            .UtiliseOther = PUtiliseOther
        End With
        If PutOnNewSceneStack Then
            NewSceneStack.Add(S)
        Else
            Stack.Add(S)
        End If
    End Sub

    Sub VBL(ByVal sender As System.Object, ByVal e As System.EventArgs)

        If Not StackWorkForbidden Then
            'Populate the Stack
            If CusA.Instances.Count > 0 Then
                For I As UInt16 = 0 To CusA.Instances.Count - 1
                    If CusA.Instances(I).IsMade Then PutOnStack("Step", String.Empty, True, I, 0, False)

                    Dim bigside As UInt16 = CusA.Instances(I).Width
                    If CusA.Instances(I).Height > bigside Then bigside = CusA.Instances(I).Height
                    If DF_Ignore(I) Then Continue For
                    If CusA.Instances(I).X > CusA.Width + bigside + 500 Or CusA.Instances(I).X < -bigside - 500 Then
                        CusA.Instances(I).InUse = False
                    End If
                    If CusA.Instances(I).Y > CusA.Height + bigside + 500 Or CusA.Instances(I).Y < -bigside - 500 Then
                        CusA.Instances(I).InUse = False
                    End If

                    If CusA.Instances(I).X <= CusA.ViewX + CusA.ViewWidth + bigside And CusA.Instances(I).X >= CusA.ViewX - bigside _
                        And CusA.Instances(I).Y <= CusA.ViewY + CusA.ViewHeight + bigside And CusA.Instances(I).Y >= CusA.ViewY - bigside Then

                        If CusA.Instances(I).HasChanged Then
                            For I2 As UInt16 = 0 To CusA.Instances.Count - 1
                                If I2 = I Then Continue For

                                If DF_Ignore(I2) Then Continue For

                                Dim bigside2 As UInt16 = CusA.Instances(I2).Width
                                If CusA.Instances(I2).Height > bigside Then bigside = CusA.Instances(I).Height


                                If CusA.Instances(I).X - (CusA.Instances(I2).X + bigside2) > bigside Then Continue For
                                If CusA.Instances(I2).X - (CusA.Instances(I).X + bigside) > bigside2 Then Continue For
                                If CusA.Instances(I).Y - (CusA.Instances(I2).Y + bigside2) > bigside Then Continue For
                                If CusA.Instances(I2).Y - (CusA.Instances(I).Y + bigside) > bigside2 Then Continue For
                                If Collision(I, I2) Then
                                    PutOnStack("Collision", CusA.Instances(I2).ObjectName, False, I, I2, True)
                                    PutOnStack("Collision", CusA.Instances(I2).ObjectName, False, I2, I, True)
                                End If
                            Next
                        End If

                    End If
                Next
                If Pointer_Held Then
                    PointerLogic("Held")
                End If
            End If
            If Stack.Count > 0 Then
                For I As UInt16 = 0 To Stack.Count - 1
                    If SwitchingScene Then
                        SwitchingScene = False
                        Exit For
                    Else
                        If Stack.Count = 0 Then Exit For
                        EventWorks(Stack(I))
                    End If
                Next
            End If
            Stack.Clear()
            For Each P In NewSceneStack
                Stack.Add(P.Clone())
            Next
            NewSceneStack.Clear()
        End If

        If StackWorkForbidden Then Exit Sub

        'Views
        If View_VX >= 0 Then
            If (CusA.Width - (CusA.ViewX + CusA.ViewWidth)) >= View_VX Then
                CusA.ViewX += View_VX
            End If
        Else
            If (View_VX * -1) > CusA.ViewX Then
                CusA.ViewX = 0
            Else
                CusA.ViewX += View_VX
            End If
        End If
        If View_VY >= 0 Then
            If (CusA.Height - (CusA.ViewY + CusA.ViewHeight)) >= CusA.ViewY Then
                CusA.ViewY += View_VY
            End If
        Else
            If (View_VY * -1) > CusA.ViewY Then
                CusA.ViewY = 0
            Else
                CusA.ViewY += View_VY
            End If
        End If
        If (CusA.ViewX < 0) Then CusA.ViewX = 0
        If (CusA.ViewY < 0) Then CusA.ViewY = 0
        If (CusA.ViewX + CusA.ViewWidth > CusA.Width) Then CusA.ViewX = CusA.Width - CusA.ViewWidth
        If (CusA.ViewY + CusA.ViewHeight > CusA.Height) Then CusA.ViewY = CusA.Height - CusA.ViewHeight

        'Variables
        If CusA.Instances.Count > 0 Then
            For I As UInt16 = 0 To CusA.Instances.Count - 1
                If DF_Ignore(I) Then Continue For
                If Not CusA.Instances(I).VX = 0 Then CusA.Instances(I).HasChanged = True
                If Not CusA.Instances(I).VY = 0 Then CusA.Instances(I).HasChanged = True
                If Not CusA.Instances(I).TV = 0 Then CusA.Instances(I).HasChanged = True

                CusA.Instances(I).X += CusA.Instances(I).VX
                CusA.Instances(I).T += CusA.Instances(I).TV
                CusA.Instances(I).VX += CusA.Instances(I).AX
                CusA.Instances(I).Y += CusA.Instances(I).VY
                CusA.Instances(I).VY += CusA.Instances(I).AY
                Dim FrameCount As Int32 = GetFrameCount(CusA.Instances(I).ImageName)
                If CusA.Instances(I).FrameSpeed > 0 Then
                    If TimePassed Mod Math.Floor(30 / CusA.Instances(I).FrameSpeed) = 0 Then
                        CusA.Instances(I).Frame += 1
                        While CusA.Instances(I).Frame >= FrameCount
                            CusA.Instances(I).Frame -= FrameCount
                        End While
                        While CusA.Instances(I).Frame < 0
                            CusA.Instances(I).Frame += FrameCount
                        End While
                    End If
                End If
            Next
        End If

        AlarmsSync()
        MakeBMP()
        MainForm.BackgroundImage = Use
        TimePassed += 1
        If TimePassed = 600 Then TimePassed = 0

    End Sub

    Function GetFrameCount(ByVal ImageName As String) As Int32
        Dim FrameCount As Int32 = 1
        For Each X As DImage In Images
            If X.Name = ImageName Then
                Return Math.Floor(X.Height / X.FrameHeight)
            End If
        Next
        Return 1
    End Function

    Function HasAnEvent(ByVal ObjectName As String, ByVal TypeFilter As String, ByVal DataFilter As String, ByVal UtiliseDataFilter As Boolean)
        Dim TryIt As Boolean = False
        For Each D As DEvent In DEvents
            If UtiliseDataFilter Then
                If D.EventType = TypeFilter And D.ObjectName = ObjectName And D.EventData = DataFilter Then TryIt = True : Exit For
            Else
                If D.EventType = TypeFilter And D.ObjectName = ObjectName Then TryIt = True : Exit For
            End If
        Next
        Return TryIt
    End Function

    Function DepthFromObjName(ByVal ObjectName As String) As UInt16
        For Each P As DObject In Objects
            If P.Name = ObjectName Then Return P.Depth
        Next
        Return 0
    End Function

    Sub CreateInstance(ByVal ObjectName As String, ByVal X As Double, ByVal Y As Double, ByVal RunEvent As Boolean)
        Dim I As New Instance(ObjectName, String.Empty, X, Y, X, Y, 64, 64, 0, 0, 0, 0, 0, 0, New List(Of Variable), DepthFromObjName(ObjectName), 0, 0)
        For Each P As DObject In Objects
            If P.Name = ObjectName Then I.ImageName = P.ImageName : Exit For
        Next
        Dim TempRefImg As New Bitmap(24, 24)
        For Each P As DImage In Images
            If P.Name = I.ImageName Then TempRefImg = P.Data.Clone()
        Next
        With I
            .InUse = True
            .Width = TempRefImg.Width
            .Height = TempRefImg.Height
        End With
        TempRefImg.Dispose()
        CusA.Instances.Add(I)
        If RunEvent Then PutOnStack("Create", String.Empty, True, CusA.Instances.Count - 1, 0, False, True)
    End Sub

    Sub BootScene(ByVal NewSceneID As UInt16)

        StackWorkForbidden = True
        SwitchingScene = True
        Stack.Clear()
        NewSceneStack.Clear()

        View_VX = 0
        View_VY = 0
        CuS = NewSceneID
        CusA = Scenes(CuS).CloneMe()
        CusA.Instances.Clear()
        MainForm.Size = New Size(CusA.ViewWidth + HorizAdd, CusA.ViewHeight + VertiAdd)

        DF_Logo_Height = CusA.ViewHeight / 8
        DF_Logo_Width = 320 * (DF_Logo_Height / 85)
        DF_Logo_Rect = New Rectangle(DF_Logo_X, DF_Logo_Y, DF_Logo_Width, DF_Logo_Height)

        Dim ScreenWidth As UInt16 = My.Computer.Screen.Bounds.Width
        Dim ScreenHeight As UInt16 = My.Computer.Screen.Bounds.Height
        MainForm.Location = New Point((ScreenWidth / 2) - (MainForm.Width / 2), (ScreenHeight / 2) - (MainForm.Height / 2))

        'MsgError("stack work forbidden: " + StackWorkForbidden.ToString)
        'MsgError("stack stop processing: " + StopProcessingStack.ToString)

        Dim iCount As UInt16 = Scenes(NewSceneID).Instances.Count

        If iCount > 0 Then
            For P As UInt16 = 0 To iCount - 1
                CreateInstance(Scenes(NewSceneID).Instances(P).ObjectName, Scenes(NewSceneID).Instances(P).X, Scenes(NewSceneID).Instances(P).Y, False)
            Next
            For P As UInt16 = 0 To iCount - 1
                PutOnStack("Create", String.Empty, True, P, 0, False, True)
            Next
        End If

        SwitchingScene = False
        StackWorkForbidden = False

    End Sub

    Sub PointerLogic(ByVal RegisterAs As String)
        Dim New_Pointer_X As UInt16 = Math.Floor(Pointer_X + CusA.ViewX)
        Dim New_Pointer_Y As UInt16 = Math.Floor(Pointer_Y + CusA.ViewY)
        If CusA.Instances.Count = 0 Then Exit Sub
        For I As UInt16 = 0 To CusA.Instances.Count - 1

            Dim bigside As UInt16 = CusA.Instances(I).Width
            If CusA.Instances(I).Height > bigside Then bigside = CusA.Instances(I).Height

            If CusA.Instances(I).X >= CusA.ViewX - bigside And CusA.Instances(I).X <= CusA.ViewX + CusA.ViewWidth + bigside _
                And CusA.Instances(I).Y >= CusA.ViewY - bigside And CusA.Instances(I).Y <= CusA.ViewY + CusA.ViewHeight + bigside Then
                Dim FH As Integer
                For Each img As DImage In Images
                    If img.Name = CusA.Instances(I).ImageName Then
                        FH = img.FrameHeight
                    End If
                Next

                'If CusA.Instances(I).X < New_Pointer_X And (CusA.Instances(I).X + CusA.Instances(I).Width) > New_Pointer_X And CusA.Instances(I).Y < New_Pointer_Y And (CusA.Instances(I).Y + FH) > New_Pointer_Y Then
                If PointInRotatedRect(New Point(New_Pointer_X, New_Pointer_Y), New Rectangle(CusA.Instances(I).X, CusA.Instances(I).Y, CusA.Instances(I).Width, FH), CusA.Instances(I).T) Then
                    PutOnStack("Pointer", RegisterAs, False, I, 0, False)
                End If
            End If
        Next
    End Sub

    Sub EventWorks(ByVal S As StackElement)

        If S.EventType = "Create" Then CusA.Instances(S.InstanceID).IsMade = True
        If CusA.Instances(S.InstanceID).IsMade = False Then Exit Sub


        If DEvents.Count = 0 Then Exit Sub
        Dim SE As StackElement = S.Clone()
        If DF_Ignore(SE.InstanceID) Then Exit Sub

        Dim CurrentApplies As String = String.Empty

        Dim Skipping As Boolean = False
        Dim CurrentIndent As Byte = 0
        Dim ActivateElse As Boolean = False
        Dim NeededIndent As Byte = 0

        'Is there an Event?
        Dim EventID As UInt16 = 0
        Dim FoundOne As Boolean = False
        For D As UInt16 = 0 To DEvents.Count - 1
            If Not DEvents(D).EventType = SE.EventType Then Continue For
            If Not SE.IgnoreDataFilter Then
                If Not DEvents(D).EventData = SE.EventData Then Continue For
            End If
            If Not DEvents(D).ObjectName = CusA.Instances(SE.InstanceID).ObjectName Then Continue For
            FoundOne = True
            EventID = D
        Next
        If Not FoundOne Then Exit Sub

        Dim MyCode As String = DEvents(EventID).Code
        Dim CodeLines As New List(Of String)
        If MyCode.Contains(CC) Then
            For Each L As String In MyCode.Split(CC)
                CodeLines.Add(L)
            Next
        Else
            CodeLines.Add(MyCode)
        End If

        For Each P As String In CodeLines
            Dim pid As Integer = 0
            For Each H As String In P.Split(CommandSep)
                pid += 1
                Dim CommandName As String = String.Empty
                Dim ArgumentsString As String = String.Empty
                If H.Contains(" ") Then
                    CommandName = H.Substring(0, H.IndexOf(" "))
                    ArgumentsString = H.Substring(CommandName.Length + 1)
                Else
                    CommandName = H
                End If
                Dim Arguments As New List(Of String)
                If ArgumentsString.Contains(ArgSep) Then
                    For Each K As String In ArgumentsString.Split(ArgSep)
                        Arguments.Add(K)
                    Next
                Else
                    Arguments.Add(ArgumentsString)
                End If
                If CommandName = "SET_APPLICATION" Then CurrentApplies = Arguments(0) : Continue For
                Dim NewArguments As List(Of String) = Arguments
                For A As UInt16 = 0 To NewArguments.Count - 1
                    If NewArguments(A) = "!Applies!" Then
                        If SE.UtiliseOther Then
                            NewArguments(A) = SE.OtherInstanceID.ToString
                        Else
                            NewArguments(A) = SE.InstanceID.ToString
                        End If
                    End If
                Next
                If DF_Ignore(SE.InstanceID) Then Exit Sub

                If CurrentApplies = "this" Then
                    'Console.WriteLine("this with " + InstanceID.ToString)
                    DoCommand(CusA.Instances(SE.InstanceID).Variables, CurrentIndent, NeededIndent, CommandName, NewArguments, SE.InstanceID, ActivateElse)
                ElseIf CurrentApplies = "other" Then
                    'Console.WriteLine("other")
                    DoCommand(CusA.Instances(SE.InstanceID).Variables, CurrentIndent, NeededIndent, CommandName, NewArguments, SE.OtherInstanceID, ActivateElse)
                Else
                    'Is it an Object?
                    Dim DieOut As Boolean = True
                    For Each D As DObject In Objects
                        If D.Name = CurrentApplies Then
                            DieOut = False
                        End If
                    Next
                    If DieOut Then Exit Sub
                    For I As UInt16 = 0 To CusA.Instances.Count - 1
                        If DF_Ignore(I) Then Continue For
                        If CusA.Instances(I).ObjectName = CurrentApplies Then
                            DoCommand(CusA.Instances(SE.InstanceID).Variables, CurrentIndent, NeededIndent, CommandName, NewArguments, I, ActivateElse)
                        End If
                    Next
                End If
            Next
        Next
    End Sub

    Sub SetInstanceProperty(ByVal InstanceID As UInt16, ByVal TheProperty As String, ByVal TheValue As Double)
        Select Case TheProperty
            Case "T"
                CusA.Instances(InstanceID).T = TheValue
                CusA.Instances(InstanceID).HasChanged = True
            Case "TV"
                CusA.Instances(InstanceID).TV = TheValue
            Case "X"
                CusA.Instances(InstanceID).X = TheValue
                CusA.Instances(InstanceID).HasChanged = True
            Case "Y"
                CusA.Instances(InstanceID).Y = TheValue
                CusA.Instances(InstanceID).HasChanged = True
            Case "VX"
                CusA.Instances(InstanceID).VX = TheValue
            Case "VY"
                CusA.Instances(InstanceID).VY = TheValue
            Case "AX"
                CusA.Instances(InstanceID).AX = TheValue
            Case "AY"
                CusA.Instances(InstanceID).AY = TheValue
            Case "DEPTH"
                CusA.Instances(InstanceID).Depth = Math.Floor(TheValue)
            Case "FRAMESPEED"
                CusA.Instances(InstanceID).FrameSpeed = TheValue
            Case "FRAME"
                Dim FrameCount As Int32 = GetFrameCount(CusA.Instances(InstanceID).ImageName)
                CusA.Instances(InstanceID).Frame = Math.Floor(TheValue)
                While CusA.Instances(InstanceID).Frame >= FrameCount
                    CusA.Instances(InstanceID).Frame -= FrameCount
                End While
                While CusA.Instances(InstanceID).Frame < 0
                    CusA.Instances(InstanceID).Frame += FrameCount
                End While
        End Select
    End Sub

    Sub DoCommand(ByRef Variables As List(Of Variable), ByRef CurrentIndent As Byte, ByRef NeededIndent As Byte, ByVal CommandName As String, ByVal Arguments As List(Of String), ByVal InstanceID As UInt16, ByRef ActivateElse As Boolean)

        If Not InstanceID < CusA.Instances.Count Then Exit Sub

        'Console.WriteLine("rec'v " + InstanceID.ToString)

        Dim IffyResult As Boolean = False

        'MsgError("giving " + (CurrentIndent = NeededIndent).ToString)
        'MsgError("Coming in: " + CommandName + ", current indent: " + Convert.ToString(CurrentIndent) + ", needed indent: " + Convert.ToString(NeededIndent))

        Dim AllowExecution As Boolean = True

        If CommandName = "START_BLOCK" Then
            CurrentIndent += 1
        ElseIf CommandName = "END_BLOCK" Then
            If CurrentIndent > 0 Then CurrentIndent -= 1
        End If

        If Not CurrentIndent = NeededIndent Then
            'Dim Difference As Byte = CurrentIndent - NeededIndent
            'If CommandName = "END_BLOCK" Then
            '    If Difference = 1 Then
            '        If CurrentIndent > 0 Then
            '            CurrentIndent -= 1
            '        End If
            '        NeededIndent = CurrentIndent
            '    End If
            'End If
            AllowExecution = False
        End If
        Select Case CommandName

            '''''''''''''
            '' Generic ''
            '''''''''''''

            Case "REM"
                'Dim Comment As String = Arguments(0)
            Case "CLICK_AT"
                If AllowExecution Then
                    Dim XTar As Double = ParseSomething(Variables, Arguments(0), InstanceID, True)
                    Dim YTar As Double = ParseSomething(Variables, Arguments(1), InstanceID, True)
                    If CusA.Instances.Count = 0 Then Exit Sub
                    For I As UInt16 = 0 To CusA.Instances.Count - 1
                        Dim FH As Integer
                        For Each img As DImage In Images
                            If img.Name = CusA.Instances(I).ImageName Then
                                FH = img.FrameHeight
                            End If
                        Next

                        If CusA.Instances(I).X < XTar And (CusA.Instances(I).X + CusA.Instances(I).Width) > XTar And CusA.Instances(I).Y < YTar And (CusA.Instances(I).Y + FH) > YTar Then
                            PutOnStack("Pointer", "Click", False, I, 0, False, True)
                        End If
                    Next
                End If
            Case "SET_VARIABLE"
                If AllowExecution Then
                    Dim VariableName As String = Arguments(0)
                    If VariableName.StartsWith("[") And VariableName.EndsWith("]") Then
                        Dim TheProperty As String = VariableName.Substring(1)
                        TheProperty = TheProperty.Substring(0, TheProperty.Length - 1)
                        SetInstanceProperty(InstanceID, TheProperty, ParseSomething(Variables, Arguments(1), InstanceID, True))
                    Else
                        Dim NewValue As Object
                        If Arguments(1).StartsWith("""") And Arguments(1).EndsWith("""") Then
                            NewValue = Arguments(1).Substring(1, Arguments(1).Length - 2)
                        Else
                            NewValue = ParseSomething(Variables, Arguments(1), InstanceID, False)
                        End If
                        Dim IsGlobal As Boolean = VariableName.ToLower.StartsWith("global.")
                        If IsGlobal Then VariableName = VariableName.Substring(7)
                        Dim DidSet As Boolean = False
                        While VariableName.Contains("{")
                            Dim start As String = VariableName.Substring(0, VariableName.IndexOf("{"))
                            Dim arg As String = ParseSomething(Variables, VariableName.Substring(VariableName.IndexOf("{") + 1, VariableName.IndexOf("}") - VariableName.IndexOf("{") - 1), InstanceID, False)
                            Dim ender As String = VariableName.Substring(VariableName.IndexOf("}") + 1)
                            VariableName = start + "<" + arg + ">" + ender
                        End While
                        VariableName = VariableName.Replace("<", "{")
                        VariableName = VariableName.Replace(">", "}")
                        If IsGlobal Then
                            'Global
                            If GlobalVariables.Count > 0 Then
                                For P As UInt16 = 0 To GlobalVariables.Count - 1
                                    If GlobalVariables(P).Name = VariableName Then
                                        GlobalVariables(P).Value = NewValue
                                        DidSet = True
                                    End If
                                Next
                            End If
                        Else
                            Dim SexyValue As Double = ParseSomething(Variables, Arguments(1), InstanceID, True)
                            'It might be an internal Variable. Bodge follows.
                            Dim DidSomeShit As Boolean = False
                            'FIX 2
                            If VariableName.ToUpper = "VIEW_X" Then
                                If SexyValue < 0 Then SexyValue = 0
                                CusA.ViewX = Convert.ToDouble(SexyValue)
                                DidSomeShit = True
                                DidSet = True
                            ElseIf VariableName.ToUpper = "VIEW_Y" Then
                                If SexyValue < 0 Then SexyValue = 0
                                CusA.ViewY = Convert.ToDouble(SexyValue)
                                DidSomeShit = True
                                DidSet = True
                            ElseIf VariableName.ToUpper = "VIEW_VX" Then
                                View_VX = SexyValue
                                DidSomeShit = True
                                DidSet = True
                            ElseIf VariableName.ToUpper = "VIEW_VY" Then
                                View_VY = SexyValue
                                DidSomeShit = True
                                DidSet = True
                            End If
                            If Not DidSomeShit Then
                                'Local
                                If Variables.Count > 0 Then
                                    For P As UInt16 = 0 To Variables.Count - 1
                                        If Variables(P).Name = VariableName Then
                                            Variables(P).Value = NewValue
                                            DidSet = True
                                        End If
                                    Next
                                End If
                            End If
                        End If
                        If Not DidSet Then
                            Dim P As New Variable
                            With P
                                .Name = VariableName
                                .Value = NewValue
                            End With
                            If IsGlobal Then
                                GlobalVariables.Add(P)
                            Else
                                Variables.Add(P)
                            End If
                        End If
                    End If
                End If

            Case "SET_SPEED"
                If AllowExecution Then
                    Dim OVX As Double = CusA.Instances(InstanceID).VX
                    Dim OVY As Double = CusA.Instances(InstanceID).VY
                    Dim Mag As Double = ParseSomething(Variables, Arguments(0), InstanceID, True)
                    Dim theta As Double = 0

                    If Not (OVX = 0 And OVY = 0) Then
                        theta = Math.Atan(OVY / OVX)
                    End If
                    If OVX < 0 Then
                        theta += Math.PI
                    End If
                    SetInstanceProperty(InstanceID, "VX", Mag * Math.Cos(theta))
                    SetInstanceProperty(InstanceID, "VY", Mag * Math.Sin(theta))
                End If

            Case "SET_DIRECTION"
                If AllowExecution Then
                    Dim OVX As Double = CusA.Instances(InstanceID).VX
                    Dim OVY As Double = CusA.Instances(InstanceID).VY
                    Dim Mag As Double = Math.Sqrt(OVX ^ 2 + OVY ^ 2)
                    Dim theta As Double = 0
                    If Not Mag = 0 Then
                        theta = ParseSomething(Variables, Arguments(0), InstanceID, True) * Math.PI / 180
                    End If
                    SetInstanceProperty(InstanceID, "VX", Mag * Math.Cos(theta))
                    SetInstanceProperty(InstanceID, "VY", Mag * Math.Sin(theta))
                End If

            Case "SET_ACCELERATION"
                If AllowExecution Then
                    Dim OAX As Double = CusA.Instances(InstanceID).AX
                    Dim OAY As Double = CusA.Instances(InstanceID).AY
                    Dim Mag As Double = ParseSomething(Variables, Arguments(0), InstanceID, True)
                    Dim theta As Double = 0
                    If Not (OAX = 0 And OAY = 0) Then
                        theta = Math.Atan(OAY / OAX)
                    End If
                    If OAX < 0 Then
                        theta += 180
                    End If
                    SetInstanceProperty(InstanceID, "AX", Mag * Math.Cos(theta))
                    SetInstanceProperty(InstanceID, "AY", Mag * Math.Sin(theta))
                End If

            Case "SET_ACCELERATION_DIRECTION"
                If AllowExecution Then
                    Dim OAX As Double = CusA.Instances(InstanceID).AX
                    Dim OAY As Double = CusA.Instances(InstanceID).AY
                    Dim Mag As Double = Math.Sqrt(OAX ^ 2 + OAY ^ 2)
                    Dim theta As Double = 0
                    If Not Mag = 0 Then
                        theta = ParseSomething(Variables, Arguments(0), InstanceID, True) * Math.PI / 180
                    End If
                    SetInstanceProperty(InstanceID, "AX", Mag * Math.Cos(theta))
                    SetInstanceProperty(InstanceID, "AY", Mag * Math.Sin(theta))
                End If

            Case "IF"
                Dim Condition As String = Arguments(0)
                Dim Value As String = Arguments(1)
                IffyResult = (ParseSomething(Variables, Condition, InstanceID, False).ToString = ParseSomething(Variables, Value, InstanceID, False).ToString)
            Case "IF_MORE"
                Dim Value1 As String = Arguments(0)
                Dim Value2 As String = Arguments(1)
                Dim Value1Parsed As Double = ParseSomething(Variables, Value1, InstanceID, True)
                Dim Value2Parsed As Double = ParseSomething(Variables, Value2, InstanceID, True)
                'MsgError(Value1Parsed.ToString + " and " + Value2Parsed.ToString)
                IffyResult = (Value1Parsed > Value2Parsed)

            Case "IF_LESS"
                Dim Value1 As String = Arguments(0)
                Dim Value2 As String = Arguments(1)
                Dim Value1Parsed As Double = ParseSomething(Variables, Value1, InstanceID, True)
                Dim Value2Parsed As Double = ParseSomething(Variables, Value2, InstanceID, True)
                'MsgError(Value1Parsed.ToString + " and " + Value2Parsed.ToString)
                IffyResult = (Value1Parsed < Value2Parsed)

            Case "IF_PLATFORM"
                Dim ChosenPlatform As String = Arguments(0)
                IffyResult = (ChosenPlatform = "Windows")

            Case "IF_CHECK_POSITION"
                IffyResult = False
                Dim tX As Double = ParseSomething(Variables, Arguments(1), InstanceID, True)
                Dim tY As Double = ParseSomething(Variables, Arguments(2), InstanceID, True)
                For Each inst As Instance In CusA.Instances
                    If inst.InUse Then
                        If inst.ObjectName = Arguments(0) Then
                            If PointInRotatedRect(New Point(tX, tY), New Rectangle(inst.X, inst.Y, inst.Width, inst.Height), inst.T) Then
                                IffyResult = True
                            End If
                        End If
                    End If
                Next

            Case "ELSE"
                IffyResult = ActivateElse

            Case "SHOW_MESSAGE"
                If AllowExecution Then
                    Dim MessageText As String = ParseSomething(Variables, Arguments(0), InstanceID, False)
                    'If MessageText.StartsWith("""") Then MessageText = MessageText.Substring(1)
                    'If MessageText.EndsWith("""") Then MessageText = MessageText.Substring(0, MessageText.Length - 1)
                    MainForm.VBLTicker.Enabled = False
                    MsgInfo(MessageText)
                    MainForm.VBLTicker.Enabled = True
                End If

            Case "PLAY_SOUND"
                If AllowExecution Then
                    Dim SoundName As String = Arguments(0)
                    Dim MyTempData() As Byte = {0}
                    Dim GoAhead As Boolean = False
                    For Each F As Sound In Sounds
                        If F.Name = SoundName Then MyTempData = F.Data : GoAhead = True : Exit For
                    Next
                    If GoAhead Then
                        Dim S = New MemoryStream(MyTempData)
                        Dim P = New SoundPlayer(S)
                        P.Play()
                    End If
                End If

            Case "QUIT"
                If AllowExecution Then
                    End
                End If

                ''''''''''''
                '' Scenes ''
                ''''''''''''

            Case "SWITCH_SCENE"
                If AllowExecution Then
                    Dim SceneName As String = Arguments(0)
                    Dim FoundID As UInt16 = 0
                    Dim DoIt As Boolean = False
                    Dim I As UInt16 = 0
                    For Each D As Scene In Scenes
                        If D.Name = SceneName Then FoundID = I : DoIt = True : Exit For
                        I += 1
                    Next
                    If DoIt Then
                        BootScene(FoundID)
                    End If
                End If

            Case "IF_CURRENT_SCENE"
                Dim SceneName As String = Arguments(0)
                IffyResult = (SceneName = CusA.Name)

            Case "IF_NEXT_SCENE"
                IffyResult = (CuS < Scenes.Count - 1)

            Case "IF_PREVIOUS_SCENE"
                IffyResult = (CuS > 0)

            Case "SWITCH_NEXT_SCENE"
                If AllowExecution Then
                    If CuS < Scenes.Count - 1 Then
                        BootScene(CuS + 1)
                    End If
                End If

            Case "SWITCH_PREVIOUS_SCENE"
                If AllowExecution Then
                    If CuS > 0 Then
                        BootScene(CuS - 1)
                    End If
                End If

            Case "RESTART_SCENE"
                If AllowExecution Then
                    BootScene(CuS)
                End If

                '''''''''''''''
                '' Instances ''
                '''''''''''''''

            Case "CREATE"
                If AllowExecution Then
                    Dim ObjectName As String = Arguments(0)
                    Dim TheX As Double = ParseSomething(Variables, Arguments(1), InstanceID, True)
                    Dim TheY As Double = ParseSomething(Variables, Arguments(2), InstanceID, True)
                    CreateInstance(ObjectName, TheX, TheY, True)
                End If

            Case "DELETE"
                If AllowExecution Then
                    CusA.Instances(InstanceID).InUse = False
                End If

            Case "INSTANCE_PROPERTY"
                If AllowExecution Then
                    Dim TheProperty As String = Arguments(0)
                    Dim TheValue As Double = ParseSomething(Variables, Arguments(1), InstanceID, True)
                    SetInstanceProperty(InstanceID, TheProperty, TheValue)
                End If

            Case "SET_IMAGE"
                If AllowExecution Then
                    Dim NewImage As String = Arguments(0)
                    CusA.Instances(InstanceID).ImageName = NewImage
                    CusA.Instances(InstanceID).HasChanged = True
                End If

            Case "JUMP_TO_START_POSITION"
                If AllowExecution Then
                    CusA.Instances(InstanceID).X = CusA.Instances(InstanceID).StartX
                    CusA.Instances(InstanceID).Y = CusA.Instances(InstanceID).StartY
                    CusA.Instances(InstanceID).HasChanged = True
                End If

            Case "IF_OBJECT_AT_POSITION"
                Dim ObjectName As String = Arguments(0)
                Dim X As Double = ParseSomething(Variables, Arguments(1), InstanceID, True)
                Dim Y As Double = ParseSomething(Variables, Arguments(2), InstanceID, True)
                IffyResult = Object_At_Position(ObjectName, X, Y)

            Case "DELETE_AT_POSITION"
                If AllowExecution Then
                    If CusA.Instances.Count > 0 Then
                        Dim TheX As Double = ParseSomething(Variables, Arguments(0), InstanceID, True)
                        Dim TheY As Double = ParseSomething(Variables, Arguments(1), InstanceID, True)
                        For U As UInt16 = 0 To CusA.Instances.Count - 1
                            If DF_Ignore(U) Then Continue For
                            If CusA.Instances(U).X = TheX And CusA.Instances(U).Y = TheY Then CusA.Instances(U).InUse = False
                        Next
                    End If
                End If

            Case "IF_INSTANCES"
                Dim ObjectName As String = Arguments(0)
                Dim RequestedCount As UInt16 = Convert.ToUInt16(ParseSomething(Variables, Arguments(1), InstanceID, True))
                Dim TempCount As UInt16 = 0
                If CusA.Instances.Count > 0 Then
                    For K As UInt16 = 0 To CusA.Instances.Count - 1
                        If DF_Ignore(K) Then Continue For
                        If CusA.Instances(K).ObjectName = ObjectName Then TempCount += 1
                    Next
                End If
                'MsgBox("there are " + TempCount.ToString + " instances of " + ObjectName + ". Checking for " + RequestedCount.ToString)
                IffyResult = (RequestedCount = TempCount)

            Case "SNAP_TO_GRID"
                If AllowExecution Then
                    Dim SnapX As Double = ParseSomething(Variables, Arguments(0), InstanceID, True)
                    Dim SnapY As Double = ParseSomething(Variables, Arguments(1), InstanceID, True)
                    Dim OldX As Double = CusA.Instances(InstanceID).X
                    Dim OldY As Double = CusA.Instances(InstanceID).Y
                    Dim ModX As Double = OldX Mod SnapX
                    Dim ModY As Double = OldY Mod SnapY
                    OldX -= ModX

                    OldY -= ModY

                    CusA.Instances(InstanceID).X = OldX
                    CusA.Instances(InstanceID).Y = OldY
                    CusA.Instances(InstanceID).HasChanged = True
                End If

                '''''''''''''
                '' DISPLAY ''
                '''''''''''''

            Case "SET_BACKGROUND"
                If AllowExecution Then
                    Dim NewBG As String = Arguments(0)
                    Dim DoIt As Boolean = False
                    For Each D As DImage In Images
                        If D.Name = NewBG Then DoIt = True
                    Next
                    CusA.Background = NewBG
                End If

            Case "SET_FOREGROUND"
                If AllowExecution Then
                    Dim NewBG As String = Arguments(0)
                    Dim DoIt As Boolean = False
                    For Each D As DImage In Images
                        If D.Name = NewBG Then DoIt = True
                    Next
                    CusA.Foreground = NewBG
                End If

            Case "DRAW_TEXT"
                If AllowExecution Then
                    Dim DFont As String = String.Empty
                    Dim DData As String = String.Empty
                    Dim DX As Double = 0
                    Dim DY As Double = 0
                    If Arguments.Count = 4 Then
                        DFont = Arguments(0)
                        DData = ParseSomething(Variables, Arguments(1), InstanceID, False).ToString
                        DX = ParseSomething(Variables, Arguments(2), InstanceID, True)
                        DY = ParseSomething(Variables, Arguments(3), InstanceID, True)
                    Else
                        'Compatibility Layer
                        DFont = String.Empty
                        DData = ParseSomething(Variables, Arguments(0), InstanceID, False).ToString
                        DX = ParseSomething(Variables, Arguments(1), InstanceID, True)
                        DY = ParseSomething(Variables, Arguments(2), InstanceID, True)
                    End If

                    Dim IDToBin As Int16 = -1
                    If DTexts.Count > 0 Then
                        For P As Int16 = 0 To DTexts.Count - 1
                            If DTexts(P).X = DX And DTexts(P).Y = DY Then
                                IDToBin = P
                            End If
                        Next
                        If Not IDToBin = -1 Then DTexts.RemoveAt(IDToBin)
                    End If
                    Dim D As New DText
                    With D
                        .Data = DData
                        .X = DX
                        .Y = DY
                        .FontImg = DFont
                    End With
                    DTexts.Add(D)
                End If

            Case "CLEAR_TEXT"
                If AllowExecution Then
                    DTexts.Clear()
                End If

                ''''''''''''
                '' ALARMS ''
                ''''''''''''

            Case "SET_ALARM"
                If AllowExecution Then
                    Dim AlarmID As UInt16 = Math.Floor(ParseSomething(Variables, Arguments(0), InstanceID, True))
                    Dim PTime As UInt16 = Math.Floor(ParseSomething(Variables, Arguments(1), InstanceID, True))
                    SetAlarm(AlarmID, PTime, True)
                End If

            Case "IF_ALARM_RINGS"
                Dim AlarmID As UInt16 = ParseSomething(Variables, Arguments(0), InstanceID, True)
                IffyResult = (Alarms(AlarmID).Enabled And Alarms(AlarmID).Time = 0)
                'If IffyResult Then
                '    Alarms(AlarmID).Rang = False
                'End If
                'Console.WriteLine("Check Alarm Ring: return " + IffyResult.ToString)

                '''''''''''
                '' DEBUG ''
                '''''''''''

            Case "SMALL_DUMP"
                If AllowExecution Then
                    Dumpery.DataList.Items.Clear()
                    Dumpery.ObjectNameLabel.Text = CusA.Instances(InstanceID).ObjectName
                    For Each Glob As Variable In Variables
                        Dim itm As New ListViewItem
                        itm.Text = Glob.Name
                        itm.SubItems.Add(Glob.Value)
                        Dumpery.DataList.Items.Add(itm)
                    Next
                    Dumpery.Show()
                End If

            Case "BIG_DUMP"
                If AllowExecution Then
                    Dumpery.DataList.Items.Clear()
                    Dumpery.ObjectNameLabel.Text = "Global Dump"
                    For Each Glob As Variable In GlobalVariables
                        Dim itm As New ListViewItem
                        itm.Text = "global." + Glob.Name
                        itm.SubItems.Add(Glob.Value)
                        Dumpery.DataList.Items.Add(itm)
                    Next
                    Dumpery.Show()
                End If

                ''''''''''''
                '' HTML 5 ''
                ''''''''''''

            Case "GO_TO_ADDRESS"
                Dim WebAddress As String = ParseSomething(Variables, Arguments(0), InstanceID, False)
                If WebAddress.StartsWith("www.") Then WebAddress = "http://" + WebAddress
                Dim AllowedPrefixes As New List(Of String)
                With AllowedPrefixes
                    .Add("http://")
                    .Add("https://")
                    .Add("ftp://")
                End With
                Dim IsAllowed As Boolean = False
                For Each P In AllowedPrefixes
                    If WebAddress.StartsWith(P) Then IsAllowed = True
                Next
                If Not IsAllowed Then
                    'Last Attempt
                    If WebAddress.EndsWith(".html") Or WebAddress.EndsWith(".htm") And Not WebAddress.Contains(" ") Then
                        'Space is in case of fake parameter passing, like: cmd pause fake.html
                        IsAllowed = True
                    End If
                End If
                If IsAllowed Then
                    Try
                        System.Diagnostics.Process.Start(WebAddress)
                    Catch 'Firefox is a Turd
                    End Try
                Else
                    MainForm.VBLTicker.Enabled = False
                    MsgError("The command 'GO_TO_ADDRESS' was blocked because it did not specify a generic external resource identifier.")
                    MainForm.VBLTicker.Enabled = True
                End If

        End Select

        If IfCommands.Contains(CommandName) Then
            'MsgError("Apparently, " + CommandName + " is an IF like action?")
            If IffyResult Then
                If CurrentIndent = NeededIndent Then
                    NeededIndent += 1
                    ActivateElse = False
                End If
                'MsgError("If was TRUE. Needed Indent increased; set to " + NeededIndent.ToString)
            Else
                ActivateElse = True
                'MsgError("If was FALSE. To continue execution, I MUST have indentation of " + Convert.ToString(NeededIndent))
            End If
        End If

        If CommandName = "END_BLOCK" And (NeededIndent - 1) = CurrentIndent Then
            NeededIndent -= 1
        End If

    End Sub

End Module
