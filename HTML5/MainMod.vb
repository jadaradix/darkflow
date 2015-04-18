Imports System.IO
Imports System.Drawing
Imports HTML5.DDefines

Module MainModule

    Public MyVersion As Byte = 100

    Public Platform As String = "Browser"

    Public ParentSplitter As Byte = 30
    Public ChildSplitter As Byte = 31

    Dim CP As String = Chr(ParentSplitter)
    Dim CC As String = Chr(ChildSplitter)

    Dim CommandSep As String = Chr(11)
    Dim ArgSep As String = Chr(12)

    Dim Folder As String = String.Empty

    Function PathToImage(ByVal path As String) As Image
        Dim imgData() As Byte = SafeGetFileData(path)
        Return New Bitmap(System.Drawing.Image.FromStream(New MemoryStream(imgData)))
    End Function

    Function SafeGetFileData(ByVal filePath As String) As Byte()
        Dim MyFileStream As FileStream = New FileStream(filePath, FileMode.Open, FileAccess.Read)
        Dim MyBinaryReader As BinaryReader = New BinaryReader(MyFileStream)
        Dim FinalData() As Byte = MyBinaryReader.ReadBytes(CType(MyFileStream.Length, Integer))
        MyBinaryReader.Close()
        MyFileStream.Close()
        Return FinalData
    End Function

    Public Images As New List(Of DImage)
    Public Sounds As New List(Of Sound)
    Public Objects As New List(Of DObject)
    Public Scenes As New List(Of Scene)
    Public DEvents As New List(Of DEvent)
    Public Inputs As New List(Of Input)

    'Function IsStringData(ByVal Input As String) As Boolean
    '    Dim Out As Int32
    '    Dim Success As Boolean = Int32.TryParse(Input, Out)
    '    If Success Then

    '    End If
    'End Function

    Function IsThisAnIf(ByVal CommandName As String) As Boolean

        '''''''''''''
        '' Generic ''
        '''''''''''''
        If CommandName = "IF" Then
            Return True
        End If

        If CommandName = "IF_MORE" Then
            Return True
        End If

        If CommandName = "IF_LESS" Then
            Return True
        End If

        If CommandName = "IF_PLATFORM" Then
            Return True
        End If

        If CommandName = "IF_ALARM_RINGS" Then
            Return True
        End If

        ''''''''''''
        '' Scenes ''
        ''''''''''''
        If CommandName = "IF_CURRENT_SCENE" Then
            Return True
        End If
        If CommandName = "IF_NEXT_SCENE" Then
            Return True
        End If
        If CommandName = "IF_PREVIOUS_SCENE" Then
            Return True
        End If

        '''''''''''''''
        '' Instances ''
        '''''''''''''''
        If CommandName = "IF_INSTANCES" Then
            Return True
        End If
        If CommandName = "IF_OBJECT_AT_POSITION" Then
            Return True
        End If

        If CommandName = "IF_CHECK_POSITION" Then
            Return True
        End If

        Return False

    End Function

    Enum VariableIniter
        DNothing = 0
        DZero = 1
        DString = 2
    End Enum

    '   Dim Globals As New List(Of String)

    Function GenerateJS(ByVal Identifier As String, ByRef ToProcessArguments() As String) As String

        Dim ToAdd As String = String.Empty
        Select Case Identifier

            '''''''''''''
            '' Generic ''
            '''''''''''''

            Case "REM"
                Dim Comment As String = ToProcessArguments(0)
                ToAdd = "//" + Comment

            Case "SET_VARIABLE"

                Dim IVariableName As String = ToProcessArguments(0)
                Dim VariableName As String = Parser(IVariableName, True)
                Dim VariableValue As String = Parser(ToProcessArguments(1))
                Dim IsGlobal As Boolean = IVariableName.StartsWith(GlobalStarter)
                If VariableName.StartsWith("[") And VariableName.EndsWith("]") Then
                    Dim TheProperty As String = VariableName.Substring(1)
                    TheProperty = TheProperty.Substring(0, TheProperty.Length - 1)
                    ToAdd = "Instances[ActualApplies]." + TheProperty.ToUpper() + " = " + VariableValue + ";"

                Else
                    If IsGlobal Then
                        Dim NVariableName As String = IVariableName.Substring(GlobalStarter.Length)
                        Dim NVariableIniter As Byte = VariableIniter.DNothing
                        If VariableValue.StartsWith("""") And VariableValue.EndsWith("""") Then
                            NVariableIniter = VariableIniter.DString
                        Else
                            Dim Tester As Int64 = 0
                            Dim Success As Boolean = Int64.TryParse(VariableValue, Tester)
                            If Success Then NVariableIniter = VariableIniter.DZero
                        End If
                        Dim i As Byte = 0
                        Dim ArrayVal1 As String = 0
                        Dim ArrayVal2 As String = 0
                        Dim ArrayVal3 As String = 0

                        Dim orig As String = IVariableName
                        If orig.Contains("{") Then
                            While orig.Contains("{")
                                If i = 0 Then ArrayVal1 = Parser(orig.Substring(orig.IndexOf("{") + 1, orig.IndexOf("}") - orig.IndexOf("{") - 1))
                                If i = 1 Then ArrayVal2 = Parser(orig.Substring(orig.IndexOf("{") + 1, orig.IndexOf("}") - orig.IndexOf("{") - 1))
                                If i = 2 Then ArrayVal3 = Parser(orig.Substring(orig.IndexOf("{") + 1, orig.IndexOf("}") - orig.IndexOf("{") - 1))
                                orig = orig.Substring(orig.IndexOf("}") + 1)
                                i += 1
                                If i = 3 Then Exit While
                            End While
                        End If
                        ToAdd = "DF_Set_Global_Variable(""" + IVariableName.Substring(7) + """, " + ArrayVal1 + ", " + ArrayVal2 + ", " + ArrayVal3 + ", " + VariableValue + ");"

                    Else
                        If VariableName.StartsWith("CS_") Then
                            ToAdd = VariableName + " = Math.floor(" + VariableValue + ");"
                        Else
                            If VariableName.StartsWith("Instances[ActualApplies].") Then
                                ToAdd = VariableName + " = Math.floor(" + VariableValue + ");"
                            Else
                                Dim i As Byte = 0
                                Dim ArrayVal1 As String = 0
                                Dim ArrayVal2 As String = 0
                                Dim ArrayVal3 As String = 0

                                Dim orig As String = IVariableName
                                If orig.Contains("{") Then
                                    VariableName = orig.Substring(0, orig.IndexOf("{"))
                                    While orig.Contains("{")
                                        If i = 0 Then ArrayVal1 = Parser(orig.Substring(orig.IndexOf("{") + 1, orig.IndexOf("}") - orig.IndexOf("{") - 1))
                                        If i = 1 Then ArrayVal2 = Parser(orig.Substring(orig.IndexOf("{") + 1, orig.IndexOf("}") - orig.IndexOf("{") - 1))
                                        If i = 2 Then ArrayVal3 = Parser(orig.Substring(orig.IndexOf("{") + 1, orig.IndexOf("}") - orig.IndexOf("{") - 1))
                                        orig = orig.Substring(orig.IndexOf("}") + 1)
                                        i += 1
                                        If i = 3 Then Exit While
                                    End While
                                End If
                                ToAdd = "DF_Set_Instance_Variable(ActualApplies, """ + IVariableName + """, " + ArrayVal1 + ", " + ArrayVal2 + ", " + ArrayVal3 + ", " + VariableValue + ");"
                            End If

                        End If
                    End If
                End If


            Case "IF"
                Dim Condition As String = Parser(ToProcessArguments(0))
                Dim Matcher As String = Parser(ToProcessArguments(1))
                ToAdd = "if(" + Condition + " == " + Matcher + ")"

            Case "IF_MORE"
                Dim Value1 As String = Parser(ToProcessArguments(0))
                Dim Value2 As String = Parser(ToProcessArguments(1))
                ToAdd = "if(" + Value1 + " > " + Value2 + ")"

            Case "IF_CHECK_POSITION"

                Dim Value1 As String = ToProcessArguments(0)
                Dim Value2 As String = Parser(ToProcessArguments(1))
                Dim Value3 As String = Parser(ToProcessArguments(2))
                ToAdd = "if(DF_CheckPosition(" + Value1 + ", " + Value2 + ", " + Value3 + "))"

            Case "IF_LESS"
                Dim Value1 As String = Parser(ToProcessArguments(0))
                Dim Value2 As String = Parser(ToProcessArguments(1))
                ToAdd = "if(" + Value1 + " < " + Value2 + ")"

            Case "IF_PLATFORM"
                Dim ChosenPlatform As String = ToProcessArguments(0).Replace(" ", "_")
                ToAdd = "if(DF_Platform == DF_" + ChosenPlatform + ")"

            Case "START_BLOCK"
                ToAdd = "{"

            Case "ELSE"
                ToAdd = " else "

            Case "END_BLOCK"
                ToAdd = "}"

            Case "SHOW_MESSAGE"
                Dim MyMessage As String = Parser(ToProcessArguments(0))
                ToAdd = "alert(" + MyMessage + ");"

            Case "PLAY_SOUND"
                Dim SoundName As String = ToProcessArguments(0)
                ToAdd = "Play_Sound(ActualApplies, " + SoundName + ");"

            Case "SET_SPEED"
                ToAdd = "SetSpeed(ActualApplies, " + Parser(ToProcessArguments(0)) + ");"
            Case "SET_DIRECTION"
                ToAdd = "SetDirection(ActualApplies, " + Parser(ToProcessArguments(0)) + ");"
            Case "SET_ACCELERATION"
                ToAdd = "SetAccel(ActualApplies, " + Parser(ToProcessArguments(0)) + ");"
            Case "SET_ACCELERATION_DIRECTION"
                ToAdd = "SetAccelDir(ActualApplies, " + Parser(ToProcessArguments(0)) + ");"
            Case "QUIT"
                'Not Supported!

                ''''''''''''
                '' Scenes ''
                ''''''''''''

            Case "SWITCH_SCENE"
                Dim SName As String = ToProcessArguments(0)
                ToAdd = "DF_Current_Scene = DF_Current_Scene_From_Scene(""" + SName + """); " + SName + "();"

            Case "IF_CURRENT_SCENE"
                Dim SName As String = ToProcessArguments(0)
                ToAdd = "if (DF_Current_Scene == DF_Current_Scene_From_Scene(""" + SName + """))"

            Case "IF_NEXT_SCENE"
                ToAdd = "if (Is_Next_Scene() == 1)"

            Case "IF_PREVIOUS_SCENE"
                ToAdd = "if (Is_Previous_Scene() == 1)"

            Case "SWITCH_NEXT_SCENE"
                ToAdd = "Goto_Next_Scene();"

            Case "SWITCH_PREVIOUS_SCENE"
                ToAdd = "Goto_Previous_Scene();"

            Case "RESTART_SCENE"
                ToAdd = "Scenes[DF_Current_Scene]();"

            Case "SET_BACKGROUND"
                Dim BGName As String = ToProcessArguments(0)
                ToAdd = "CS_Background = " + BGName + "; DF_Draw_Background = true;"

            Case "SET_FOREGROUND"
                Dim BGName As String = ToProcessArguments(0)
                ToAdd = "CS_Foreground = " + BGName + "; DF_Draw_Foreground = true;"

            Case "DRAW_TEXT"
                Dim DFont As String = ToProcessArguments(0)
                Dim DData As String = Parser(ToProcessArguments(1))
                Dim DX As String = Parser(ToProcessArguments(2))
                Dim DY As String = Parser(ToProcessArguments(3))
                DData = HighLevelStringParser(DData)

                ToAdd = "DF_Draw_Text(" + DFont + ", " + DData + ".toString(), " + DX + ", " + DY + ");"

            Case "CLEAR_TEXT"
                ToAdd = "DF_Clear_Text();"

                '''''''''''''''
                '' Instances ''
                '''''''''''''''

            Case "CREATE"
                Dim ObjectName As String = ToProcessArguments(0)
                Dim LX As String = Parser(ToProcessArguments(1))
                Dim LY As String = Parser(ToProcessArguments(2))
                ToAdd = "Create_Instance(" + ObjectName + ", " + LX + ", " + LY + ", true);"

            Case "DELETE"
                Dim InstanceID As String = ToProcessArguments(0)
                ToAdd = "Delete_Instance(" + InstanceID + ");"

            Case "CLICK_AT"
                Dim X As String = ToProcessArguments(0)
                Dim Y As String = ToProcessArguments(1)
                ToAdd = "DF_Pointer_Click_Logic(" + X + "," + Y + ");"

            Case "INSTANCE_PROPERTY"
                Dim InstanceProperty As String = ToProcessArguments(0)
                Dim ToSetValue As String = Parser(ToProcessArguments(1))
                Dim DoExit As Boolean = False
                For U As UInt16 = 0 To JimbosParser.ROInstanceProperties.Count - 1
                    If InstanceProperty = JimbosParser.ROInstanceProperties(U) Then
                        ToAdd = JimbosParser.ROHSInstanceProperties(U) + "(ActualApplies, " + ToSetValue + ");"
                        DoExit = True
                        Exit For
                    End If
                Next
                If Not DoExit Then ToAdd = "Instances[ActualApplies]." + InstanceProperty.ToUpper() + " = " + ToSetValue + ";"

            Case "SET_IMAGE"
                ToAdd = "Instances[ActualApplies].ImageID = " + ToProcessArguments(0) + "; Instances[ActualApplies].Frame = 0;"

            Case "JUMP_TO_START_POSITION"
                ToAdd = "Instances[ActualApplies].X = Instances[ActualApplies].StartX; Instances[ActualApplies].Y = Instances[ActualApplies].StartY;"

            Case "IF_OBJECT_AT_POSITION"
                Dim OName As String = ToProcessArguments(0)
                Dim OX As String = Parser(ToProcessArguments(1))
                Dim OY As String = Parser(ToProcessArguments(2))
                ToAdd = "if(Object_At_Position(" + OName + ", " + OX + ", " + OY + "))"

            Case "DELETE_AT_POSITION"
                Dim X As String = Parser(ToProcessArguments(0))
                Dim Y As String = Parser(ToProcessArguments(1))
                ToAdd = "Delete_At_Position(" + X + ", " + Y + ");"

            Case "IF_INSTANCES"
                Dim ObjectName As String = ToProcessArguments(0)
                Dim ICount As String = Parser(ToProcessArguments(1))
                ToAdd = "if (Count_Instances(" + ToProcessArguments(0) + ") == " + ICount + ")"

            Case "SNAP_TO_GRID"
                Dim X As String = Parser(ToProcessArguments(0))
                Dim Y As String = Parser(ToProcessArguments(1))
                ToAdd = "Snap_To_Grid(InstanceID, " + X + ", " + Y + ");"

                ''''''''''''
                '' ALARMS ''
                ''''''''''''


            Case "SET_ALARM"

                Dim AlarmID As String = Parser(ToProcessArguments(0))
                Dim Time As String = Parser(ToProcessArguments(1))
                ToAdd = "DF_Set_Alarm(" + AlarmID + ", " + Time + ", true);"

            Case "IF_ALARM_RINGS"
                Dim AlarmID As String = Parser(ToProcessArguments(0)).ToString
                Dim AlarmIDStr As String = AlarmID.ToString
                ToAdd = "if (Alarms[" + AlarmIDStr + "].Enabled && Alarms[" + AlarmIDStr + "].Time == 0)"

                ''''''''''''
                '' HTML 5 ''
                ''''''''''''

            Case "GO_TO_ADDRESS"
                ToAdd = "window.location = """ + ToProcessArguments(0) + """;"

            Case Else

                ToAdd = "//Unimplemented: " + Identifier

        End Select
        Return ToAdd
    End Function

    Function GeneratePointerCode(ByVal Descriptor As String)
        Dim GameJS As String = String.Empty
        GameJS += "function DF_Pointer_" + Descriptor + "_Logic(pX, pY) {" + vbNewLine
        Dim ObjectsConditions As New List(Of String)
        For Each P In DEvents
            If P.EventType = "Pointer" And P.EventData = Descriptor Then
                ObjectsConditions.Add(P.ObjectName)
            End If
        Next
        If ObjectsConditions.Count > 0 Then
            GameJS += " for (InstanceID in Instances) {" + vbNewLine
            GameJS += "  if (DF_Ignore(InstanceID)) continue;" + vbNewLine
            GameJS += "  if (DF_Instance_In_Range(InstanceID, pX, pY)) {" + vbNewLine
            For Each P In ObjectsConditions
                GameJS += "   if (Instances[InstanceID].ObjectID == " + P + ") " + P + "_Pointer_" + Descriptor + "(InstanceID, InstanceID);" + vbNewLine
            Next
            GameJS += "  }" + vbNewLine
            GameJS += " }" + vbNewLine
        End If
        GameJS += "}" + vbNewLine + vbNewLine
        Return GameJS
    End Function

    Function GenerateKeyCode(ByVal Descriptor As String) As String

        Dim GameJS As String = String.Empty
        'Key Preparation
        Dim LEventCount As UInt16 = 0
        For Each D In DEvents
            If D.EventType = "Input" Then LEventCount += 1
        Next

        GameJS += "function DF_Key_" + Descriptor + "_Logic(Which_Key) {" + vbNewLine
        If LEventCount > 0 Then
            GameJS += " for (InstanceID in Instances) {" + vbNewLine
            GameJS += "  if (DF_Ignore(InstanceID)) continue;" + vbNewLine
            If Inputs.Count > 0 Then
                For I As UInt16 = 0 To Inputs.Count - 1
                    Dim PotentialConditions As New List(Of String)
                    For Each P In Inputs(I).Executors
                        If Not P.PlatformName = "Browser" Then Continue For
                        'Bodge for non-key inputs (e.g. rotation?)
                        If P.PlatformInputIdentifier = "Rotate" Then Continue For
                        If Descriptor = "Down" Then
                            For T As UInt16 = 0 To DFKeyIdentifiers.Count - 1
                                If P.PlatformInputIdentifier = DFKeyIdentifiers(T) Then
                                    PotentialConditions.Add("(Which_Key == " + DFKeyVariables(T) + ")")
                                End If
                            Next
                        ElseIf Descriptor = "Up" Then
                            For T As UInt16 = 0 To DFKeyIdentifiers.Count - 1
                                If P.PlatformInputIdentifier = (DFKeyIdentifiers(T) + " Released") Then
                                    PotentialConditions.Add("(Which_Key == " + DFKeyVariables(T) + ")")
                                End If
                            Next
                        End If
                    Next
                    Dim PotentialConditionsString As String = String.Empty
                    If PotentialConditions.Count = 0 Then Continue For
                    For Each F As String In PotentialConditions
                        PotentialConditionsString += F + " || "
                    Next
                    PotentialConditionsString = PotentialConditionsString.Substring(0, PotentialConditionsString.Length - 4)
                    GameJS += "  if (" + PotentialConditionsString + ") {" + vbNewLine
                    'GameJS += "   //Run " + Inputs(I).Name + "!" + vbNewLine
                    For Each P In Objects
                        Dim HasThisInput As Boolean = False
                        For Each J As DEvent In DEvents
                            If J.ObjectName = P.Name And J.EventType = "Input" And J.EventData = Inputs(I).Name Then HasThisInput = True
                        Next
                        If HasThisInput Then
                            GameJS += "   if (Instances[InstanceID].ObjectID == " + P.Name + ") " + P.Name + "_Input_" + Inputs(I).Name.Replace(" ", "_") + "(InstanceID, InstanceID);" + vbNewLine
                        End If
                    Next
                    GameJS += "  }" + vbNewLine
                Next
            End If
            GameJS += " }" + vbNewLine
        End If
        GameJS += "}" + vbNewLine + vbNewLine
        Return GameJS
    End Function

    Sub Main()

        If My.Application.CommandLineArgs.Count < 4 Then
            Console.WriteLine("This executable must be called with at least 5 arguments. Exit.")
            End
        End If

        Dim LFolder As String = My.Application.CommandLineArgs(0)
        If Not Directory.Exists(LFolder) Then
            Console.WriteLine("The passed directory did not exist. Exit.")
            End
        End If

        InitKeys()
        InitOperators()
        InitDFInternalVariables()
        InitInstanceProperties()
        InitFunctions()

        If Not LFolder.EndsWith("\") Then LFolder += "\"
        Folder = LFolder

        Dim SGameID As String = My.Application.CommandLineArgs(1)

        Dim ActionsFolder As String = My.Application.CommandLineArgs(2)

        Pro = (My.Application.CommandLineArgs(3) = "1")

        If My.Application.CommandLineArgs.Count > 4 Then
            Platform = My.Application.CommandLineArgs(4)
        End If

        Dim ExportFolder As String = Folder + Platform + "Files\"

        If Directory.Exists(ExportFolder) Then
            Try
                Directory.Delete(ExportFolder, True)
            Catch : End Try
        End If

        Directory.CreateDirectory(ExportFolder)
        Directory.CreateDirectory(ExportFolder + "DFResources")

        ''''''''''''''''''''''''
        ''''''''''''''''''''''''
        ''   Constant Files   ''
        ''''''''''''''''''''''''
        ''''''''''''''''''''''''

        File.WriteAllBytes(ExportFolder + "DFResources\DF_BarBG.png", My.Resources.BarBG)
        File.WriteAllBytes(ExportFolder + "DFResources\DF_BarOver.png", My.Resources.BarOver)

        If Pro Then
            File.Copy(Folder + "Logo.png", ExportFolder + "DFResources\Game_Logo.png")
        Else
            File.WriteAllBytes(ExportFolder + "DFResources\Game_Logo.png", My.Resources.LoadingLogo)
        End If
        File.WriteAllBytes(ExportFolder + "DFResources\wrongconsole.png", My.Resources.wrongconsole)
        File.WriteAllBytes(ExportFolder + "DFResources\errorbg.png", My.Resources.background)
        IO.File.WriteAllBytes(ExportFolder + "DFStyle.css", My.Resources.CSS)
        IO.File.WriteAllBytes(ExportFolder + "DFLib.js", My.Resources.LibJS)
        IO.File.WriteAllBytes(ExportFolder + "error.html", My.Resources._error)
        IO.File.WriteAllBytes(ExportFolder + "DFActions.js", My.Resources.ActionsJS)

        '''''''''''''''''''''''
        '''''''''''''''''''''''
        ''   Fact Finder 1   ''
        '''''''''''''''''''''''
        '''''''''''''''''''''''
        'Gets Scenes, Images, Objects, Max Width/Height, Settings

        Dim MaxWidth As UInt16 = 0
        Dim MaxHeight As UInt16 = 0
        Dim SettingNames As New List(Of String)
        Dim SettingValues As New List(Of String)

        For Each X As String In Split(IO.File.ReadAllText(Folder + "DFK.dfk"), CP)
            If X.Length = 0 Then Continue For
            Dim LS As Byte = Asc(X.Substring(0, 1))
            X = X.Substring(1)
            Select Case LS
                Case LineType.Scene
                    Dim Data() As String = Split(X, CC)
                    Dim SName As String = Data(0)
                    Dim S As New Scene
                    With S
                        .Name = SName
                        .Width = Data(1)
                        .Height = Data(2)
                        .ViewWidth = Data(3)
                        .ViewHeight = Data(4)
                        .ViewX = Data(5)
                        .ViewY = Data(6)
                        .BGRed = Data(7)
                        .BGGreen = Data(8)
                        .BGBlue = Data(9)
                        .Foreground = Data(10)
                        .Background = Data(11)
                    End With
                    Scenes.Add(S)
                    Dim NewWidth As UInt16 = S.ViewWidth
                    Dim NewHeight As UInt16 = S.ViewHeight
                    If NewWidth > MaxWidth Then MaxWidth = NewWidth
                    If NewHeight > MaxHeight Then MaxHeight = NewHeight
                Case LineType.Image
                    Dim ImageName As String = X.Substring(0, X.IndexOf(CC))
                    X = X.Substring(ImageName.Length + 1)
                    Dim FrameHeight As UInt16 = Convert.ToUInt16(X)
                    Dim TempImage As Bitmap = PathToImage(Folder + "Images\" + ImageName + ".png")
                    File.Copy(Folder + "Images\" + ImageName + ".png", ExportFolder + "DFResources\" + ImageName + ".png", True)
                    Dim P As New DImage(ImageName, TempImage.Width, TempImage.Height, FrameHeight)
                    TempImage.Dispose()
                    Images.Add(P)
                Case LineType.Sound
                    Dim SoundName As String = X
                    File.Copy(Folder + "Sounds\" + SoundName + ".wav", ExportFolder + "DFResources\" + SoundName + ".wav", True)
                    Dim P As New Sound(SoundName)
                    Sounds.Add(P)
                Case LineType.Setting
                    Dim SName As String = X.Substring(0, X.IndexOf(CC))
                    Dim SValue As String = X.Substring(SName.Length + 1)
                    SettingNames.Add(SName)
                    SettingValues.Add(SValue)
                Case LineType.DObject
                    Dim ObjectName As String = X.Substring(0, X.IndexOf(CC))
                    Dim ImageName As String = X.Substring(ObjectName.Length + 1)
                    ImageName = ImageName.Substring(0, ImageName.IndexOf(CC))
                    Dim Depth As Byte = Convert.ToByte(X.Substring(X.LastIndexOf(CC) + 1))
                    Dim P As New DObject(ObjectName, ImageName, Depth)
                    Objects.Add(P)
                Case LineType.Input
                    Inputs.Add(New Input(X, New List(Of InputExecutor)))
            End Select
        Next

        '''''''''''''''''''''''
        '''''''''''''''''''''''
        ''   Fact Finder 2   ''
        '''''''''''''''''''''''
        '''''''''''''''''''''''
        'Gets Instances, Events and Input Executors

        For Each X As String In Split(IO.File.ReadAllText(Folder + "DFK.dfk"), CP)
            If X.Length = 0 Then Continue For
            Dim LS As Byte = Asc(X.Substring(0, 1))
            X = X.Substring(1)
            Select Case LS
                Case LineType.Instance
                    Dim Data() As String = Split(X, CC)
                    Dim SName As String = Data(0)
                    Dim OName As String = Data(1)
                    Dim IName As String = String.Empty
                    Dim IWidth As UInt16 = 0
                    Dim IHeight As UInt16 = 0
                    Dim LX As Int32 = Convert.ToInt32(Data(2))
                    Dim LY As Int32 = Convert.ToInt32(Data(3))
                    For Each P As Scene In Scenes
                        If Not P.Name = SName Then Continue For
                        For Each O As DObject In Objects
                            If Not O.Name = OName Then Continue For
                            IName = O.ImageName
                        Next
                        For Each O As DImage In Images
                            If Not O.Name = IName Then Continue For
                            IWidth = O.Width
                            IHeight = O.Height
                        Next
                        Dim I As New Instance
                        With I
                            .ObjectName = OName
                            .X = LX
                            .Y = LY
                        End With
                        P.Instances.Add(I)
                    Next
                Case LineType.DEvent
                    Dim ObjectName As String = X.Substring(0, X.IndexOf(CC))
                    X = X.Substring(ObjectName.Length + 1)
                    Dim EventType As String = X.Substring(0, X.IndexOf(CC))
                    X = X.Substring(EventType.Length + 1)
                    Dim EventData As String = X
                    Dim D As New DEvent
                    With D
                        .ObjectName = ObjectName
                        .EventType = EventType
                        .EventData = EventData
                    End With
                    DEvents.Add(D)
                Case LineType.InputExecutor
                    Dim InputName As String = X.Substring(0, X.IndexOf(CC))
                    X = X.Substring(InputName.Length + 1)
                    For Each P As Input In Inputs
                        If Not P.Name = InputName Then Continue For
                        Dim PlatformName As String = X.Substring(0, X.IndexOf(CC))
                        X = X.Substring(PlatformName.Length + 1)
                        Dim PlatformII As String = X
                        P.Executors.Add(New InputExecutor(PlatformName, PlatformII))
                    Next
            End Select
        Next

        '''''''''''''''''''''
        '''''''''''''''''''''
        ''   Derivations   ''
        '''''''''''''''''''''
        '''''''''''''''''''''

        'If MaxWidth < (LoadingWidth + (LoadingPadding * 2)) Then
        '    MaxWidth = (LoadingWidth + (LoadingPadding * 2))
        'Else
        '    MaxWidth += (LoadingPadding * 2)
        'End If
        'If MaxHeight < (LoadingHeight + (LoadingPadding * 2)) Then
        '    MaxHeight = (LoadingHeight + (LoadingPadding * 2))
        'Else
        '    MaxHeight += (LoadingPadding * 2)
        'End If

        If MaxWidth < LoadingWidth Then
            MaxWidth = LoadingWidth
        End If
        If MaxHeight < LoadingHeight Then
            MaxHeight = LoadingHeight
        End If

        Dim TheTitle As String = String.Empty
        Dim TheBootScene As String = String.Empty
        For P As UInt16 = 0 To SettingNames.Count - 1
            If SettingNames(P) = "Product" Then
                TheTitle = SettingValues(P)
            ElseIf SettingNames(P) = "BootScene" Then
                TheBootScene = SettingValues(P)
            End If
        Next

        ''''''''''''''
        ''''''''''''''
        ''   HTML   ''
        ''''''''''''''
        ''''''''''''''


        Dim HTML As String = String.Empty
        HTML += "<!DOCTYPE html>" + vbNewLine
        HTML += "<html>" + vbNewLine
        HTML += " <head>" + vbNewLine
        HTML += "  <title>" + TheTitle + "</title>" + vbNewLine
        If Platform = "Mobile" Then
            'Dim Scale As Double = (MaxHeight / 388)
            'If Scale > 1 Then
            '    'Bodge
            '    Scale = (388 / MaxHeight)
            'End If
            Dim Scale As Double = (MaxHeight / 388)
            If Scale > 1 Then
                'Bodge
                Scale = (388 / MaxHeight)
            End If
            HTML += "  <script type=""text/javascript"" > " + vbNewLine

            HTML += "var DFDontLoad = false; " + vbNewLine
            HTML += "var mobile = (/iphone|ipad|ipod|android|blackberry|mini|windows\sce|palm/i.test(navigator.userAgent.toLowerCase()));  " + vbNewLine
            HTML += "    if (!mobile) {  " + vbNewLine
            HTML += "alert(""This game was not designed for this console."");" + vbNewLine
            HTML += "DFDontLoad = true;" + vbNewLine
            HTML += "}" + vbNewLine
            HTML += "</script>" + vbNewLine
            HTML += "  <meta name=""viewport"" content=""width=" + MaxWidth.ToString + ", height=" + MaxHeight.ToString + ", initial-scale=" + Scale.ToString + ", maximum-scale=" + Scale.ToString + ", minimum-scale=" + Scale.ToString + ", user-scalable=no"">" + vbNewLine
            'HTML += "  <meta name=""viewport"" content=""height=" + MaxHeight.ToString + ", initial-scale=1"">" + vbNewLine
        Else
            HTML += "  <script type=""text/javascript"" > "
            HTML += "var DFDontLoad = false; " + vbNewLine
            HTML += "var mobile = (/iphone|ipad|ipod|android|blackberry|mini|windows\sce|palm/i.test(navigator.userAgent.toLowerCase()));  " + vbNewLine
            HTML += "    if (mobile) {  " + vbNewLine
            HTML += "alert(""This game was not designed for this console."");" + vbNewLine
            HTML += "DFDontLoad = true;" + vbNewLine
            HTML += "}" + vbNewLine
            HTML += "</script>" + vbNewLine
        End If
        HTML += "  <link rel=""stylesheet"" type=""text/css"" href=""DFStyle.css"">" + vbNewLine
        HTML += "  <script type=""text/javascript"" src=""DFLib.js""></script>" + vbNewLine
        HTML += "  <script type=""text/javascript"" src=""DFActions.js""></script>" + vbNewLine
        HTML += "  <script type=""text/javascript"" src=""GameGlobals.js""></script>" + vbNewLine
        HTML += "  <script type=""text/javascript"" src=""GameData.js""></script>" + vbNewLine
        HTML += " </head>" + vbNewLine
        HTML += " <body style=""width: " + MaxWidth.ToString + "px;height: " + MaxHeight.ToString + ";"">" + vbNewLine
        'If Platform = "Browser" Then
        '    HTML += "  <h1>" + TheTitle + "</h1>" + vbNewLine
        'End If
        HTML += "  <div id=""GameBox"" class=""GameBox"">" + vbNewLine
        HTML += "   <div id=""VPusher""></div>" + vbNewLine
        HTML += "   <div id=""Loader"">" + vbNewLine
        HTML += "    <img src=""DFResources/Game_Logo.png"" alt=""Loading Game..."" id=""Logo"">" + vbNewLine
        HTML += "    <div id=""ProgressBox"">" + vbNewLine
        HTML += "     <div id=""ProgressBar"">" + vbNewLine
        HTML += "      <div id=""ProgressBlocker"">&nbsp;</div>" + vbNewLine
        HTML += "      <div id=""ProgressOver""></div>" + vbNewLine
        HTML += "     </div>" + vbNewLine
        HTML += "    </div>" + vbNewLine
        HTML += "   </div>" + vbNewLine
        HTML += "   <canvas id=""Canvas"">" + vbNewLine
        HTML += "   </canvas>" + vbNewLine
        HTML += "  </div>" + vbNewLine
        HTML += "  <script type=""text/javascript"">DF_Play_Game();</script>" + vbNewLine
        HTML += " </body>" + vbNewLine
        HTML += "</html>"

        IO.File.WriteAllText(ExportFolder + "index.html", HTML)

        '''''''''''''''''
        '''''''''''''''''
        ''   Game JS   ''
        '''''''''''''''''
        '''''''''''''''''

        Dim GameJS As String = String.Empty

        GameJS += "/////////////////////" + vbNewLine
        GameJS += "// Loading Defines //" + vbNewLine
        GameJS += "/////////////////////" + vbNewLine + vbNewLine

        GameJS += "function DF_Init_Values() {" + vbNewLine
        Dim DOn As UInt16 = 0
        For Each P In Scenes
            If P.Name = TheBootScene Then Exit For
            DOn += 1
        Next
        GameJS += " DF_Scene_Count = " + Scenes.Count.ToString + ";" + vbNewLine
        GameJS += " DF_Current_Scene = " + DOn.ToString + ";" + vbNewLine
        GameJS += " DF_Resources_Count = " + (Images.Count + Sounds.Count).ToString + " + 1; // + 1 for Dark Flow Logo" + vbNewLine
        GameJS += " DF_Max_Width = " + MaxWidth.ToString + ";" + vbNewLine
        GameJS += " DF_Max_Height = " + MaxHeight.ToString + ";" + vbNewLine
        GameJS += "}" + vbNewLine + vbNewLine

        GameJS += "function DF_Init_Resources() {" + vbNewLine
        GameJS += " Resources[Game_Logo] = new Resource(""Game_Logo"", 0, new Image(), 320, 85, 0);" + vbNewLine
        For Each P In Images
            GameJS += " Resources[" + P.Name + "] = new Resource(""" + P.Name + """, 0, new Image(), " + P.Width.ToString + ", " + P.Height.ToString + ", " + P.FrameHeight.ToString + ");" + vbNewLine
        Next
        For Each P In Sounds
            GameJS += " Resources[" + P.Name + "] = new Resource(""" + P.Name + """, 1, new Audio(), 0, 0, 0);" + vbNewLine
        Next
        GameJS += "}" + vbNewLine + vbNewLine

        GameJS += "function DF_Init_Scenes() {" + vbNewLine
        DOn = 0
        For Each P In Scenes
            GameJS += " Scenes[" + DOn.ToString + "] = " + P.Name + ";" + vbNewLine
            DOn += 1
        Next
        GameJS += "}" + vbNewLine + vbNewLine

        GameJS += "//////////////" + vbNewLine
        GameJS += "// Defines //" + vbNewLine
        GameJS += "/////////////" + vbNewLine + vbNewLine

        'Start at 1 because image 0 is Dark Flow Logo
        DOn = 1
        For Each P In Images
            GameJS += "var " + P.Name + " = " + DOn.ToString + ";" + vbNewLine
            DOn += 1
        Next
        For Each P In Sounds
            GameJS += "var " + P.Name + " = " + DOn.ToString + ";" + vbNewLine
            DOn += 1
        Next
        GameJS += vbNewLine

        DOn = 0
        For Each P In Objects
            GameJS += "var " + P.Name + " = " + DOn.ToString + ";" + vbNewLine
            DOn += 1
        Next
        GameJS += vbNewLine

        GameJS += "////////////" + vbNewLine
        GameJS += "// Events //" + vbNewLine
        GameJS += "////////////" + vbNewLine + vbNewLine

        For Each K In DEvents
            Dim CurrentIndent As UInt16 = 0
            Dim LocalsFound As New List(Of String)
            Dim EventData As String = K.EventData.Replace(" ", "_")
            If EventData.Length = 0 Then
                GameJS += "function " + K.ObjectName + "_" + K.EventType + "(InstanceID, OtherInstanceID) {" + vbNewLine
            Else
                GameJS += "function " + K.ObjectName + "_" + K.EventType + "_" + EventData + "(InstanceID, OtherInstanceID) {" + vbNewLine
            End If
            GameJS += " var ActualApplies = InstanceID;" + vbNewLine
            For Each P As String In Split(IO.File.ReadAllText(Folder + "DFK.dfk"), CP)
                If P.Length = 0 Then Continue For
                Dim LS As Byte = Asc(P.Substring(0, 1))
                P = P.Substring(1)
                Select Case LS
                    Case LineType.Action
                        Dim LObjectName As String = P.Substring(0, P.IndexOf(CC))
                        P = P.Substring(LObjectName.Length + 1)
                        Dim LEventType As String = P.Substring(0, P.IndexOf(CC))
                        P = P.Substring(LEventType.Length + 1)
                        Dim LEventData As String = P.Substring(0, P.IndexOf(CC))
                        P = P.Substring(EventData.Length + 1)
                        If LObjectName = K.ObjectName And LEventType = K.EventType And LEventData = K.EventData Then
                            Dim ActionName As String = ActionGetPartition(P, "name")
                            Dim Arguments As String = ActionGetPartition(P, "arguments")
                            Dim ArgumentsList As New List(Of String)
                            Dim Current As String = String.Empty
                            For Each R As String In Arguments
                                If R = CommandSep Then
                                    ArgumentsList.Add(Current)
                                    Current = String.Empty
                                Else
                                    Current += R
                                End If
                            Next
                            If Current.Length > 0 Then ArgumentsList.Add(Current)

                            Dim Applies As String = ActionGetPartition(P, "appliesto")
                            Dim AddApplyLine As Boolean = True
                            For Each X As String In IO.File.ReadAllLines(ActionsFolder + "\" + ActionName + ".action")
                                If X = "NOAPPLIES" Then
                                    AddApplyLine = False
                                    Exit For
                                End If
                            Next

                            Dim FinishTempBlock As Boolean = False
                            If AddApplyLine Then
                                Dim ApplyLine As String = String.Empty
                                If Applies = "this" Then
                                    ApplyLine = "ActualApplies = InstanceID;"
                                ElseIf Applies = "other" Then
                                    ApplyLine = "ActualApplies = OtherInstanceID;"
                                Else
                                    ApplyLine = "for (ActualApplies in Instances) { if (DF_Ignore(ActualApplies) || !(Instances[ActualApplies].ObjectID == " + Applies + ")) continue;"
                                    FinishTempBlock = True
                                End If
                                GameJS += " "
                                If CurrentIndent > 0 Then
                                    For I As UInt16 = 0 To CurrentIndent - 1
                                        GameJS += " "
                                    Next
                                End If
                                GameJS += ApplyLine + vbNewLine
                            End If

                            For Each X As String In IO.File.ReadAllLines(ActionsFolder + "\" + ActionName + ".action")
                                If X.StartsWith("TYPE ") Then Continue For
                                If X.StartsWith("DISPLAY ") Then Continue For
                                If X.StartsWith("ICON ") Then Continue For
                                If X = "BG" Then Continue For
                                If X = "NOAPPLIES" Then Continue For
                                If X = "INDENT" Then Continue For
                                If X = "DEDENT" Then Continue For
                                If X = "CONDITIONAL" Then Continue For
                                If X.StartsWith("ARG ") Then Continue For
                                Dim ArgumentCount As UInt16 = 0
                                For Each F As String In X
                                    If F = ";" Then ArgumentCount += 1
                                Next
                                If ArgumentCount = 0 Then
                                    If X.Contains("!1!") Then ArgumentCount = 1
                                Else
                                    ArgumentCount += 1
                                End If
                                X = X.Replace(";", ArgSep)
                                Dim ToProcess As String = String.Empty
                                If ArgumentCount > 0 Then
                                    Dim Y As String = X
                                    If ArgumentCount = 1 Then
                                        Y = Y.Replace("!1!", Arguments)
                                    Else
                                        For G As UInt16 = 1 To ArgumentsList.Count
                                            Y = Y.Replace("!" + G.ToString + "!", ArgumentsList(G - 1))
                                        Next
                                    End If
                                    ToProcess = Y
                                Else
                                    ToProcess = X
                                End If
                                Dim Identifier As String = String.Empty
                                Dim ToProcessArguments() As String = {}
                                Array.Clear(ToProcessArguments, 0, 0)
                                If ToProcess.Contains(" ") Then
                                    Identifier = ToProcess.Substring(0, ToProcess.IndexOf(" "))
                                    ToProcessArguments = Split(ToProcess.Substring(Identifier.Length + 1), ArgSep)
                                Else
                                    Identifier = ToProcess
                                End If
                                If ToProcessArguments.Length > 0 Then
                                    For A As UInt16 = 0 To ToProcessArguments.Length - 1
                                        If ToProcessArguments(A) = "!Applies!" Then
                                            ToProcessArguments(A) = "ActualApplies"
                                        End If
                                    Next
                                End If

                                Dim IsIf As Boolean = IsThisAnIf(Identifier.ToUpper)
                                Dim IsEnd As Boolean = (Identifier.ToUpper = "END_BLOCK")
                                Dim ToAdd As String = GenerateJS(Identifier.ToUpper, ToProcessArguments)

                                If IsEnd Then
                                    If CurrentIndent > 0 Then CurrentIndent -= 1
                                End If
                                GameJS += " "
                                If CurrentIndent > 0 Then
                                    For I As UInt16 = 0 To CurrentIndent - 1
                                        GameJS += " "
                                    Next
                                End If
                                GameJS += ToAdd + vbNewLine
                                If Identifier = "START_BLOCK" Then CurrentIndent += 1
                                'If IsIf Then CurrentIndent += 1
                            Next
                            If FinishTempBlock Then
                                GameJS += " "
                                If CurrentIndent > 0 Then
                                    For I As UInt16 = 0 To CurrentIndent - 1
                                        GameJS += " "
                                    Next
                                End If
                                GameJS += "}" + vbNewLine
                            End If
                        End If
                End Select
            Next
            GameJS += "}" + vbNewLine + vbNewLine
        Next

        GameJS += "///////////////////////" + vbNewLine
        GameJS += "// Generic Functions //" + vbNewLine
        GameJS += "///////////////////////" + vbNewLine + vbNewLine

        GameJS += "function Create_Instance(ObjectID, X, Y, RunEvents) {" + vbNewLine
        GameJS += " var DImage = -1;" + vbNewLine
        GameJS += " var DDepth = 0;" + vbNewLine
        For Each P In Objects
            If P.ImageName.Length = 0 Then Continue For
            GameJS += " if (ObjectID == " + P.Name + ") { DImage = " + P.ImageName + "; DDepth = " + P.Depth.ToString + "; }" + vbNewLine
        Next
        GameJS += " var NextID = DF_Next_Instance();" + vbNewLine
        GameJS += " Instances[NextID] = new Instance(ObjectID, DImage, X, Y, DDepth);" + vbNewLine
        'GameJS += " if (DImage == -1) {" + vbNewLine
        'GameJS += "  Instances[NextID] = new Instance(ObjectID, -1, X, Y);" + vbNewLine
        'GameJS += " } else {" + vbNewLine
        'GameJS += "  Instances[NextID] = new Instance(ObjectID, DImage, X, Y);" + vbNewLine
        'GameJS += " }" + vbNewLine
        GameJS += " if (RunEvents) {" + vbNewLine
        For Each P In Objects
            Dim HasCreateEvent As Boolean = False
            For Each S In DEvents
                If Not S.ObjectName = P.Name Then Continue For
                If Not S.EventType = "Create" Then Continue For
                HasCreateEvent = True
            Next
            If HasCreateEvent Then
                GameJS += "  if (ObjectID == " + P.Name + ") " + P.Name + "_Create(NextID, NextID);" + vbNewLine
            End If
        Next
        GameJS += " }" + vbNewLine
        GameJS += "}" + vbNewLine + vbNewLine

        Dim LEventCount As UInt16 = 0

        GameJS += "function DF_Events() {" + vbNewLine

        'Step
        LEventCount = 0
        For Each D In DEvents
            If D.EventType = "Step" Then LEventCount += 1
        Next
        If LEventCount > 0 Then
            GameJS += " for (InstanceID in Instances) {" + vbNewLine
            GameJS += "  if (DF_Ignore(InstanceID)) continue;" + vbNewLine
            For Each D In DEvents
                If Not D.EventType = "Step" Then Continue For
                GameJS += "  if (Instances[InstanceID].ObjectID == " + D.ObjectName + ") " + D.ObjectName + "_Step(InstanceID, InstanceID);" + vbNewLine
            Next
            GameJS += " }" + vbNewLine
        End If

        'Collision
        LEventCount = 0
        For Each D In DEvents
            If D.EventType = "Collision" Then LEventCount += 1
        Next
        If LEventCount > 0 Then
            GameJS += " for (InstanceID in Instances) {" + vbNewLine
            GameJS += "  if (DF_Ignore(InstanceID)) continue;" + vbNewLine
            GameJS += "  for (Instance2ID in Instances) {" + vbNewLine
            GameJS += "   if (DF_Ignore(Instance2ID)) continue;" + vbNewLine
            For Each D In DEvents
                If Not D.EventType = "Collision" Then Continue For
                GameJS += "    if (Instances[InstanceID].ObjectID == " + D.ObjectName + " && Instances[Instance2ID].ObjectID == " + D.EventData + " && DF_Collision(InstanceID, Instance2ID)) " + D.ObjectName + "_Collision_" + D.EventData + "(InstanceID, Instance2ID);" + vbNewLine
            Next
            GameJS += "  }" + vbNewLine
            GameJS += " }" + vbNewLine
        End If

        GameJS += "}" + vbNewLine + vbNewLine

        'Keys
        GameJS += GenerateKeyCode("Down")
        GameJS += GenerateKeyCode("Up")

        'Pointer
        GameJS += GeneratePointerCode("Click")
        GameJS += GeneratePointerCode("Over")
        GameJS += GeneratePointerCode("Down")
        GameJS += GeneratePointerCode("Up")
        GameJS += GeneratePointerCode("Held")

        GameJS += "////////////" + vbNewLine
        GameJS += "// Scenes //" + vbNewLine
        GameJS += "////////////" + vbNewLine + vbNewLine

        GameJS += "function DF_Current_Scene_From_Scene(Scene_Name) {" + vbNewLine
        GameJS += " switch(Scene_Name) {" + vbNewLine
        DOn = 0
        For Each P In Scenes
            GameJS += "  case """ + P.Name + """:" + vbNewLine
            GameJS += "    return " + DOn.ToString + "; break;" + vbNewLine
            DOn += 1
        Next
        GameJS += " }" + vbNewLine
        GameJS += " return 0; //Pray that this never happens" + vbNewLine
        GameJS += "}" + vbNewLine + vbNewLine

        For Each P In Scenes
            Dim MoreLines As New List(Of String)
            GameJS += "function " + P.Name + "() {" + vbNewLine
            GameJS += "DF_Scene_Changing = true;" + vbNewLine
            GameJS += " DF_Scene_Reset(" + P.Width.ToString + ", " + P.Height.ToString + ", " + P.ViewWidth.ToString + ", " + P.ViewHeight.ToString + ", " + P.ViewX.ToString + ", " + P.ViewY.ToString + ");" + vbNewLine
            GameJS += " CS_Background_Color = ""rgb(" + P.BGRed.ToString + ", " + P.BGGreen.ToString + ", " + P.BGBlue.ToString + ")"";" + vbNewLine
            If P.Background.Length > 0 Then GameJS += " CS_Background = " + P.Background + "; DF_Draw_Background = true;" + vbNewLine
            If P.Foreground.Length > 0 Then GameJS += " CS_Foreground = " + P.Foreground + "; DF_Draw_Foreground = true;" + vbNewLine
            Dim B As UInt16 = 0
            For Each I In P.Instances
                GameJS += " Create_Instance(" + I.ObjectName + ", " + I.X.ToString + ", " + I.Y.ToString + ", false);" + vbNewLine
                Dim HasCreateEvent As Boolean = False
                For Each S In DEvents
                    If Not S.ObjectName = I.ObjectName Then Continue For
                    If Not S.EventType = "Create" Then Continue For
                    HasCreateEvent = True
                Next
                If HasCreateEvent Then
                    MoreLines.Add(" " + I.ObjectName + "_Create(" + B.ToString + ", " + B.ToString + ");")
                End If
                B += 1
            Next
            For Each Q As String In MoreLines
                GameJS += Q + vbNewLine
            Next
            GameJS += "}" + vbNewLine + vbNewLine
        Next

        IO.File.WriteAllText(ExportFolder + "GameData.js", GameJS)

        '''''''''''''''''
        '''''''''''''''''
        ''   Globals   ''
        '''''''''''''''''
        '''''''''''''''''

        Dim GlobalString As String = String.Empty

        GlobalString += "//////////////////////" + vbNewLine
        GlobalString += "// Global Variables //" + vbNewLine
        GlobalString += "//////////////////////" + vbNewLine + vbNewLine

        GlobalString += "DF_Draw_Logo = " + If(Pro, "false", "true") + ";" + vbNewLine + vbNewLine
        GlobalString += "DF_Must_Wait = " + If(Pro, "false", "true") + ";" + vbNewLine + vbNewLine

        GlobalString += "var score = 0;" + vbNewLine
        GlobalString += "var lives = 3;" + vbNewLine
        GlobalString += "var health = 100;" + vbNewLine + vbNewLine

        DOn = 0

        IO.File.WriteAllText(ExportFolder + "GameGlobals.js", GlobalString)

        Dim DataString As String = String.Empty
        Dim iv As Integer = 0
        For Each sett As String In SettingNames
            If sett = "Product" Then
                DataString += SettingValues(iv) + ";" + DateTime.Now.ToLongDateString + ";"
            End If
            iv += 1
        Next

        IO.File.WriteAllText(ExportFolder + "data.dat", DataString)

    End Sub

    Public Function StringToBytes(ByVal TheInput As String) As Byte()
        Return New System.Text.ASCIIEncoding().GetBytes(TheInput)
    End Function

    Function ActionGetPartition(ByRef TheString As String, ByVal Partition As String) As String
        If Not TheString.Contains("<" + Partition + ">") And TheString.Contains("</" + Partition + ">") Then Return String.Empty
        Dim Tag1 As String = "<" + Partition + ">"
        Dim Returnable As String = TheString.Substring(TheString.IndexOf(Tag1) + Tag1.Length)
        Dim Tag2 As String = "</" + Partition + ">"
        Returnable = Returnable.Substring(0, Returnable.LastIndexOf(Tag2))
        Return Returnable
    End Function

End Module
