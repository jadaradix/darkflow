Imports System.IO
Imports System.Drawing.Drawing2D

Module DarkLib

    'Split string constants - use asc(int)

    Public ParentSplitter As Byte = 30
    Public ChildSplitter As Byte = 31

    Public CP As Char = Chr(ParentSplitter)
    Public CC As Char = Chr(ChildSplitter)
    Public CS As Char = Chr(11)

    Public Domain As String = "http://darkflow.net/"
    Public CommsBase As String = "http://darkflow.net/app/"

    'PROJECT DATA

    Public GameLogo As Bitmap

    Public CurrentFile As String = String.Empty
    Public SCurrentFile As String = String.Empty
    Public ChangeMade As Boolean = False
    Public NiceBG As Color = Color.FromArgb(226, 229, 238)

    Public System32Path As String = Environment.GetFolderPath(Environment.SpecialFolder.System)

    'Remove this after bodge complete
    Public Function IsObject(ByVal ThingyName As String) As Boolean
        For Each P As DObject In Objects
            If P.Name = ThingyName Then Return True
        Next
        Return False
    End Function

    'Actions List
    Public ThinList As Boolean = False

    Public DirectoriesToDeleteOnExit As New List(Of String)

    Public EnResourceTypes As New List(Of String)
    Public ResourceTypes As New List(Of String)
    Public ResourceTypePlurals As New List(Of String)

    Public GlobalImages As New ImageList

    Class DImage
        Function CloneMe() As DImage
            Return New DImage(Name, FrameHeight, Data)
        End Function
        Public Name As String
        Public Data As Image
        Public FrameHeight As UInt16
        Sub New(ByVal DName As String, ByVal DFrameHeight As UInt16, Optional ByVal DData As Bitmap = Nothing)
            Name = DName
            FrameHeight = DFrameHeight
            Data = DData
        End Sub
    End Class
    Public Images As New List(Of DImage)

    Class DEvent
        Public EventType As String
        Public EventData As String
        Public Actions As List(Of String)
        Public Sub New(ByVal DEventType As String, ByVal DEventData As String, ByVal DActions As List(Of String))
            EventType = DEventType
            EventData = DEventData
            Actions = DActions
        End Sub
        Function CloneMe() As DEvent
            Dim nList As New List(Of String)
            For Each A As String In Actions
                nList.Add(A.Clone)
            Next
            Return New DEvent(EventType.Clone, EventData.Clone, nList)
        End Function
    End Class

    Public Class DObject
        Public Sub New(ByVal PName As String, ByVal PImageName As String, ByVal PFrame As Int16, ByVal PEvents As List(Of DEvent), ByVal PDepth As UInt16)
            Name = PName
            ImageName = PImageName
            Frame = PFrame
            Events = PEvents
            Depth = PDepth
        End Sub
        Function CloneMe() As DObject
            Dim iList As New List(Of DEvent)
            Dim t As UInt16 = 0
            For Each P As DEvent In Events
                iList.Add(P.CloneMe())
            Next
            Return New DObject(Name.Clone, ImageName.Clone, Frame, iList, Depth)
        End Function
        Public Name As String
        Public ImageName As String
        Public Events As List(Of DEvent)
        Public Frame As UInt16
        Public Depth As UInt16
    End Class
    Public Objects As New List(Of DObject)

    Public Class Instance
        Public ObjectName As String
        Public X As Int16
        Public Y As Int16
        Public Sub New(ByVal DObjectName As String, ByVal DX As Int16, ByVal DY As Int16)
            ObjectName = DObjectName
            X = DX
            Y = DY
        End Sub
    End Class

    Public Class Scene
        Public Sub New(ByVal DName As String, ByVal DWidth As UInt16, ByVal DHeight As UInt16, ByVal DViewWidth As UInt16, ByVal DViewHeight As UInt16, ByVal DViewX As UInt16, ByVal DViewY As UInt16, ByVal DBGRed As Byte, ByVal DBGGreen As Byte, ByVal DBGBlue As Byte, ByVal DForeground As String, ByVal DBackground As String)
            Name = DName
            Width = DWidth
            Height = DHeight
            ViewWidth = DViewWidth
            ViewHeight = DViewHeight
            ViewX = DViewX
            ViewY = DViewY
            BGRed = DBGRed
            BGGreen = DBGGreen
            BGBlue = DBGBlue
            Foreground = DForeground
            Background = DBackground
            GInstances = New List(Of Instance)
            GInstances.Clear()
        End Sub
        Public WinSize As Size = FScene.Size
        Public WinLoc As Point
        Public WinState As FormWindowState = FormWindowState.Normal
        Public Name As String
        Public Width As UInt16
        Public Height As UInt16
        Public ViewWidth As UInt16
        Public ViewHeight As UInt16
        Public ViewX As UInt16
        Public ViewY As UInt16
        Public BGRed As Byte
        Public BGGreen As Byte
        Public BGBlue As Byte
        Public Foreground As String
        Public Background As String
        Public GInstances As List(Of Instance)
    End Class
    Public Scenes As New List(Of Scene)

    Public Class Sound
        Function CloneMe() As Sound
            Return New Sound(Name, Data)
        End Function
        Public Name As String
        Public Data() As Byte
        Sub New(ByVal DName As String, Optional ByVal FData() As Byte = Nothing)
            Name = DName
            Data = FData
        End Sub
    End Class
    Public Sounds As New List(Of Sound)

    Enum PlatformCategory
        Runner = 0
        Browser = 1
    End Enum

    Class Platform
        Public Name As String
        Public Icon As Image
        Public Category As Byte
        Public EXEPath As String
        Public Arguments As String
        Public Inputs As New List(Of String)
    End Class
    Public Platforms As New List(Of Platform)

    Class Browser
        Public Name As String
        Public Icon As Bitmap
        Public EXEPath As String
    End Class
    Public Browsers As New List(Of Browser)

    Public DefaultRegex = Application.ProductName + " Projects|*.dfk"

    Sub InitPlatforms()

        For Each F As String In Directory.GetFiles(AppPath + "PlatformProfiles")

            If Not F.EndsWith(".dat") Then Continue For
            F = F.Substring(F.LastIndexOf("\") + 1)
            F = F.Substring(0, F.IndexOf("."))

            Dim P As New Platform

            Dim MyName As String = F
            Dim MyIconPath As String = AppPath + "PlatformProfiles\" + MyName + ".png"
            Dim MyCategory As Byte = PlatformCategory.Browser
            Dim MyEXEPath As String = MyName + ".exe"
            Dim MyArguments As String = String.Empty

            For Each X As String In IO.File.ReadAllLines(AppPath + "PlatformProfiles\" + MyName + ".dat")
                If X = "RUNNER" Then
                    MyCategory = PlatformCategory.Runner
                ElseIf X.StartsWith("INPUT ") Then
                    X = X.Substring(6)
                    P.Inputs.Add(X)
                ElseIf X.StartsWith("EXE ") Then
                    MyEXEPath = X.Substring(4)
                ElseIf X.StartsWith("ARGUMENTS ") Then
                    MyArguments = X.Substring(10)
                End If
            Next

            With P
                .Name = MyName
                If File.Exists(MyIconPath) Then
                    .Icon = PathToImage(MyIconPath)
                Else
                    .Icon = New Bitmap(48, 48).Clone()
                End If
                .Category = MyCategory
                .EXEPath = If(File.Exists(AppPath + "PlatformProfiles\" + MyEXEPath), MyEXEPath, String.Empty)
                .Arguments = MyArguments
            End With

            Platforms.Add(P)

        Next

    End Sub

    Sub InitArraysLang()
        ResourceTypes.Clear()
        ResourceTypePlurals.Clear()
        With EnResourceTypes
            .Add("Image")
            .Add("Object")
            .Add("Scene")
            .Add("Sound")
        End With
        For i = 0 To EnResourceTypes.Count - 1
            ResourceTypes.Add(EnResourceTypes(i))
            ResourceTypePlurals.Add(EnResourceTypes(i) + "s")
        Next
    End Sub

    Sub InitArrays()
        InitArraysLang()
        Dim PF As String = My.Computer.FileSystem.SpecialDirectories.ProgramFiles + "\"
        Dim PotentialBrowserNames As New List(Of String)
        Dim PotentialBrowserPaths As New List(Of String)

        'Internet Explorer
        PotentialBrowserNames.Add("Internet Explorer")
        PotentialBrowserPaths.Add(PF + "Internet Explorer\iexplore.exe")
        'Safari
        PotentialBrowserNames.Add("Safari")
        PotentialBrowserPaths.Add(PF + "Safari\Safari.exe")
        'Opera
        PotentialBrowserNames.Add("Opera")
        PotentialBrowserPaths.Add(PF + "Opera\opera.exe")
        'Firefox
        PotentialBrowserNames.Add("Mozilla Firefox")
        PotentialBrowserPaths.Add(PF + "Mozilla Firefox\firefox.exe")
        'Chrome
        PotentialBrowserNames.Add("Google Chrome")
        PotentialBrowserPaths.Add(CDrive + "Users\" + Environment.UserName + "\AppData\Local\Google\Chrome\Application\chrome.exe")

        For I As Byte = 0 To PotentialBrowserNames.Count - 1
            If IO.File.Exists(PotentialBrowserPaths(I)) Then
                Dim P As New Browser
                With P
                    .Name = PotentialBrowserNames(I)
                    .EXEPath = PotentialBrowserPaths(I)
                    .Icon = New Bitmap(32, 32)
                End With
                Select Case PotentialBrowserNames(I)
                    Case "Internet Explorer"
                        P.Icon = My.Resources.IE9Icon.Clone()
                    Case "Safari"
                        P.Icon = My.Resources.SafariIcon
                    Case "Opera"
                        P.Icon = My.Resources.OperaIcon
                    Case "Mozilla Firefox"
                        P.Icon = My.Resources.FirefoxIcon
                    Case "Google Chrome"
                        P.Icon = My.Resources.ChromeIcon
                End Select
                Browsers.Add(P)
            End If
        Next
    End Sub

    Sub InitGlobalImages()
        With GlobalImages
            .ColorDepth = ColorDepth.Depth32Bit
            .ImageSize = New Size(16, 16)
        End With
        With GlobalImages.Images
            .Add(My.Resources.OpenFileIcon)
            .Add(My.Resources.ImageIcon)
            .Add(My.Resources.ObjectIcon)
            .Add(My.Resources.SceneIcon)
            .Add(My.Resources.SoundIcon)
        End With
    End Sub

    Public TempDir As String

    Sub InitFileSystem()
        AppPath = Application.StartupPath + "\"
        CDrive = AppPath.Substring(0, 3)
        'Options
        OptionsPath = AppPath + "Options.dat"
        If Not File.Exists(OptionsPath) Then
            IO.File.WriteAllBytes(OptionsPath, My.Resources.RestoreData)
        End If
        TempDir = AppPath + "DFTemp\"
        If Not Directory.Exists(TempDir) Then Directory.CreateDirectory(TempDir)
        'Clear Temp folder from installation - delete to enable upgrade
        Try
            If Directory.Exists(TempDir + "DarkFlowInstall") Then Directory.Delete(TempDir + "DarkFlowInstall", True)
        Catch : End Try
    End Sub

    Sub AssociateFileTypes()

        Try

            'DFK Files for the IDE
            SetFileType(".dfk", "DarkFlowFile")
            SetFileDescription("DarkFlowFile", Application.ProductName + " Project")
            AddAction("DarkFlowFile", "open", "Open")
            SetExtensionCommandLine("open", "DarkFlowFile", """" + AppPath + Application.ProductName + ".exe"" ""%1""")
            SetDefaultIcon("DarkFlowFile", """" + AppPath + "Icon.ico""")

            'ODFX Files for Games
            SetFileType(".odfx", "DarkFlowODFXFile")
            SetFileDescription("DarkFlowODFXFile", Application.ProductName + " Game")
            AddAction("DarkFlowODFXFile", "open", "Open")
            SetExtensionCommandLine("open", "DarkFlowODFXFile", """" + AppPath + "PlatformProfiles\Windows.exe"" ""%1""")
            SetDefaultIcon("DarkFlowODFXFile", """" + AppPath + "Icon.ico""")

        Catch ex As Exception
            MsgWarn("You should run " + Application.ProductName + " as an Administrator." + vbCrLf + vbCrLf + "(" + ex.Message + ")")
        End Try

    End Sub

    Sub NewWork()

        CurrentFile = String.Empty
        SCurrentFile = String.Empty
        For Each X As Form In MainForm.MdiChildren
            X.Close()
        Next

        Images.Clear()
        Objects.Clear()
        Scenes.Clear()
        Sounds.Clear()
        FPlatformInputs.Inputs.Clear()

        GameLogo = My.Resources.DefaultGameLogo.Clone()

        Dim E As New List(Of FPlatformInputs.InputExecutor)
        Dim Q As New FPlatformInputs.Input(String.Empty, E)


        E.Clear()
        E.Add(New FPlatformInputs.InputExecutor("Windows", "Up Arrow"))
        E.Add(New FPlatformInputs.InputExecutor("Browser", "Up Arrow"))
        Q = New FPlatformInputs.Input("Up", E)
        FPlatformInputs.Inputs.Add(Q.CloneMe())

        E.Clear()
        E.Add(New FPlatformInputs.InputExecutor("Windows", "Down Arrow"))
        E.Add(New FPlatformInputs.InputExecutor("Browser", "Down Arrow"))
        Q = New FPlatformInputs.Input("Down", E)
        FPlatformInputs.Inputs.Add(Q.CloneMe())

        E.Clear()
        E.Add(New FPlatformInputs.InputExecutor("Windows", "Left Arrow"))
        E.Add(New FPlatformInputs.InputExecutor("Browser", "Left Arrow"))
        Q = New FPlatformInputs.Input("Left", E)
        FPlatformInputs.Inputs.Add(Q.CloneMe())

        E.Clear()
        E.Add(New FPlatformInputs.InputExecutor("Windows", "Right Arrow"))
        E.Add(New FPlatformInputs.InputExecutor("Browser", "Right Arrow"))
        Q = New FPlatformInputs.Input("Right", E)
        FPlatformInputs.Inputs.Add(Q.CloneMe())

        E.Clear()
        E.Add(New FPlatformInputs.InputExecutor("Windows", "Up Arrow Released"))
        E.Add(New FPlatformInputs.InputExecutor("Windows", "Down Arrow Released"))
        E.Add(New FPlatformInputs.InputExecutor("Windows", "Left Arrow Released"))
        E.Add(New FPlatformInputs.InputExecutor("Windows", "Right Arrow Released"))
        E.Add(New FPlatformInputs.InputExecutor("Browser", "Up Arrow Released"))
        E.Add(New FPlatformInputs.InputExecutor("Browser", "Down Arrow Released"))
        E.Add(New FPlatformInputs.InputExecutor("Browser", "Left Arrow Released"))
        E.Add(New FPlatformInputs.InputExecutor("Browser", "Right Arrow Released"))
        Q = New FPlatformInputs.Input("Released", E)
        FPlatformInputs.Inputs.Add(Q.CloneMe())

        For Each P As TreeNode In MainForm.ResourcesList.Nodes
            P.Nodes.Clear()
        Next

        AddResource(ResourceType.Scene, False, True)
        SetSetting("Product", "New " + Application.ProductName + " Project")
        SetSetting("BootScene", "Scene_1")
        Dim RS As String = String.Empty
        For i = 0 To 7
            RS += Random(0, 9).ToString
        Next
        SetSetting("GameID", RS)
        ChangeMade = False
        SetProgramTitle()

    End Sub

    Function GenerateProgramTitle() As String
        Return "<" + If(SCurrentFile.Length > 0, SCurrentFile, "New Project") + ">"
    End Function

    Sub SetProgramTitle()
        MainForm.Text = GenerateProgramTitle()
    End Sub

    Function ParseDFKContentReturnsSceneToOpen(ByVal TheFolder As String, ByVal TheContent As String)
        'FIND ME HERE
        Dim DoAdd As Boolean = False
        Dim NewNode As New TreeNode
        Dim TType As Byte = 0
        Dim NewName As String = String.Empty
        Dim SceneToOpen As Boolean = False

        For Each Line As String In Split(TheContent, CP)
            If Line.Length = 0 Then Continue For
            NewNode = New TreeNode
            Dim LLineType As Byte = Asc(Line.Substring(0, 1))
            Line = Line.Substring(1)
            DoAdd = False
            Select Case LLineType
                Case LineType.Image
                    DoAdd = True
                    TType = ResourceType.Image
                    NewName = iGet(Line, 0, CC)
                    Dim Grabbed As Image = PathToImage(TheFolder + "Images/" + NewName + ".png")
                    Dim NewImage As New DarkLib.DImage(NewName, Convert.ToUInt16(iGet(Line, 1, CC)), Grabbed)
                    Images.Add(NewImage)
                Case LineType.DObject
                    DoAdd = True
                    TType = ResourceType.DObject
                    NewName = iGet(Line, 0, CC)
                    Dim ImageName As String = iGet(Line, 1, CC)
                    Dim Frame As UInt16 = Convert.ToUInt16(iGet(Line, 2, CC))
                    Dim Events As New List(Of DEvent)
                    Dim Depth As Int16 = 0
                    Dim DepthRead As String = iGet(Line, 3, CC)
                    If DepthRead.Length > 0 Then
                        Depth = Convert.ToUInt16(DepthRead)
                    End If
                    Dim NewObject As New DObject(NewName, ImageName, Frame, Events, Depth)
                    Objects.Add(NewObject)
                Case LineType.Scene
                    DoAdd = True
                    TType = ResourceType.Scene
                    NewName = iGet(Line, 0, CC)
                    Dim Data() As String = Line.Split(CC)
                    Dim NewScene As New Scene(NewName, 0, 0, 0, 0, 0, 0, 0, 0, 0, Data(10), Data(11))
                    With NewScene
                        .Width = Convert.ToUInt16(Data(1))
                        .Height = Convert.ToUInt16(Data(2))
                        .ViewWidth = Convert.ToUInt16(Data(3))
                        .ViewHeight = Convert.ToUInt16(Data(4))
                        .ViewX = Convert.ToUInt16(Data(5))
                        .ViewY = Convert.ToUInt16(Data(6))
                        .BGRed = Convert.ToByte(Data(7))
                        .BGGreen = Convert.ToByte(Data(8))
                        .BGBlue = Convert.ToByte(Data(9))
                    End With
                    Scenes.Add(NewScene)
                    SceneToOpen = True
                Case LineType.Sound
                    DoAdd = True
                    TType = ResourceType.Sound
                    NewName = Line
                    Dim NewSound As New DarkLib.Sound(NewName, File.ReadAllBytes(TheFolder + "Sounds/" + NewName + ".wav"))
                    Sounds.Add(NewSound)
                Case LineType.Setting
                    Dim SettingName As String = Line.Substring(0, Line.IndexOf(CC))
                    Dim SettingValue As String = Line.Substring(Line.IndexOf(CC) + 1)
                    SetSetting(SettingName, SettingValue)
                Case LineType.Input
                    FPlatformInputs.Inputs.Add(New FPlatformInputs.Input(Line, New List(Of FPlatformInputs.InputExecutor)))
            End Select

            If DoAdd Then
                With NewNode
                    .ImageIndex = TType + 1
                    .SelectedImageIndex = TType + 1
                    .Text = NewName
                    .Name = NewName
                End With
                MainForm.ResourcesList.Nodes(TType).Nodes.Add(NewNode)
            End If

        Next

        For Each Line As String In Split(TheContent, CP)
            If Line.Length = 0 Then Continue For
            Dim LLineType As Byte = Convert.ToByte(Asc(Line.Substring(0, 1)))
            Line = Line.Substring(1)
            Select Case LLineType
                Case LineType.DEvent
                    Dim ObjectName As String = iGet(Line, 0, CC)
                    Dim EventType As String = iGet(Line, 1, CC)
                    Dim EventData As String = iGet(Line, 2, CC)
                    For Each D As DObject In Objects
                        If Not D.Name = ObjectName Then Continue For
                        D.Events.Add(New DEvent(EventType, EventData, New List(Of String)))
                    Next
                Case LineType.Instance
                    Dim SName As String = iGet(Line, 0, CC)
                    Dim OName As String = iGet(Line, 1, CC)
                    Dim X As Int16 = Convert.ToInt16(iGet(Line, 2, CC))
                    Dim Y As Int16 = Convert.ToInt16(iGet(Line, 3, CC))
                    For Each P As Scene In Scenes
                        If Not P.Name = SName Then Continue For
                        P.GInstances.Add(New Instance(OName, X, Y))
                    Next
                Case LineType.InputExecutor
                    Dim InputName As String = Line.Substring(0, Line.IndexOf(CC))
                    Line = Line.Substring(InputName.Length + 1)
                    For Each P As FPlatformInputs.Input In FPlatformInputs.Inputs
                        If Not P.Name = InputName Then Continue For
                        Dim PlatformName As String = Line.Substring(0, Line.IndexOf(CC))
                        Line = Line.Substring(PlatformName.Length + 1)
                        Dim PlatformII As String = Line
                        P.Executors.Add(New FPlatformInputs.InputExecutor(PlatformName, PlatformII))
                    Next
            End Select
        Next

        For Each Line As String In Split(TheContent, CP)
            If Line.Length = 0 Then Continue For
            Dim LLineType As Byte = Convert.ToByte(Asc(Line.Substring(0, 1)))
            Line = Line.Substring(1)
            Select Case LLineType
                Case LineType.Action
                    Dim ObjectName As String = iGet(Line, 0, CC)
                    Dim EventType As String = iGet(Line, 1, CC)
                    Dim EventData As String = iGet(Line, 2, CC)
                    Dim ActionData As String = iGet(Line, 3, CC)
                    For Each D As DObject In Objects
                        If Not D.Name = ObjectName Then Continue For
                        For Each T As DEvent In D.Events
                            If T.EventType = EventType And T.EventData = EventData Then
                                T.Actions.Add(ActionData)
                            End If
                        Next
                    Next
            End Select
        Next

        ChangeMade = True

        Return SceneToOpen

    End Function

    Sub OpenProject(ByVal FullPath As String)
        Dim Temp As String = FullPath.Substring(FullPath.LastIndexOf("\") + 1)
        Dim NameToUse As String = Temp.Substring(0, Temp.LastIndexOf("."))
        Dim TheFolder As String = AppPath + "LoadProject\" + NameToUse + "\"
        If Directory.Exists(TheFolder) Then
            Try
                For Each S As String In Directory.GetDirectories(TheFolder)
                    Directory.Delete(S, True)
                Next
                For Each F As String In Directory.GetFiles(TheFolder)
                    File.Delete(F)
                Next
            Catch : End Try
        Else
            Directory.CreateDirectory(TheFolder)
        End If
        IO.File.WriteAllBytes(TheFolder + NameToUse + ".zip", IO.File.ReadAllBytes(FullPath))
        Dim MyBAT As String = "zip.exe x """ + NameToUse + ".zip"" -y" + vbCrLf + "exit"
        RunBatchString(MyBAT, TheFolder, True)
        File.Delete(TheFolder + NameToUse + ".zip")

        If Not File.Exists(TheFolder + "DFK.dfk") Then
            MsgError("Invalid Project:" + vbNewLine + vbNewLine + "DFK did not contain a text-based DFK.")
            Exit Sub
        End If

        If File.Exists(TheFolder + "Logo.png") Then
            GameLogo = PathToImage(TheFolder + "Logo.png")
        Else
            GameLogo = My.Resources.DefaultGameLogo.Clone()
        End If

        CurrentFile = FullPath

        SCurrentFile = Temp

        For Each X As TreeNode In MainForm.ResourcesList.Nodes
            X.Nodes.Clear()
        Next

        Images.Clear()
        Objects.Clear()
        Scenes.Clear()
        Sounds.Clear()
        FPlatformInputs.Inputs.Clear()

        For Each P As Form In MainForm.MdiChildren
            P.Close()
        Next

        SetOption("LAST_PROJECT", FullPath)
        SaveOptions()

        Dim SceneToOpen As Boolean = ParseDFKContentReturnsSceneToOpen(TheFolder, File.ReadAllText(TheFolder + "DFK.dfk"))

        MainForm.ResourcesList.ExpandAll()

        If SceneToOpen Then MainForm.OpenResource(MainForm.ResourcesList.Nodes(ResourceType.Scene).Nodes(0))

        SetProgramTitle()

        Try
            IO.Directory.Delete(TheFolder, True)
        Catch
            DirectoriesToDeleteOnExit.Add(TheFolder)
        End Try

    End Sub

    Sub SaveProjectWork(ByVal NP As String)
        'FIND ME HERE
        If Not NP.EndsWith("\") Then NP += "\"
        If Not Directory.Exists(NP) Then Directory.CreateDirectory(NP)
        Directory.CreateDirectory(NP + "Images")
        Directory.CreateDirectory(NP + "Sounds")
        Directory.CreateDirectory(NP + "Files")
        Dim ToWrite As String = String.Empty
        For Each XI As DImage In Images
            ToWrite += Chr(LineType.Image) + XI.Name + CC + XI.FrameHeight.ToString + CP
            XI.Data.Save(NP + "Images\" + XI.Name + ".png", Imaging.ImageFormat.Png)
        Next
        For Each XI As DObject In Objects
            ToWrite += Chr(LineType.DObject) + XI.Name + CC + XI.ImageName + CC + XI.Frame.ToString + CC + XI.Depth.ToString + CP
            For Each O As DEvent In XI.Events
                ToWrite += Chr(LineType.DEvent) + XI.Name + CC + O.EventType + CC + O.EventData + CP
                For Each P As String In O.Actions
                    ToWrite += Chr(LineType.Action) + XI.Name + CC + O.EventType + CC + O.EventData + CC + P + CP
                Next
            Next
        Next
        For Each XI As Scene In Scenes
            ToWrite += Chr(LineType.Scene)
            ToWrite += XI.Name + CC
            ToWrite += XI.Width.ToString + CC
            ToWrite += XI.Height.ToString + CC
            ToWrite += XI.ViewWidth.ToString + CC
            ToWrite += XI.ViewHeight.ToString + CC
            ToWrite += XI.ViewX.ToString + CC
            ToWrite += XI.ViewY.ToString + CC
            ToWrite += XI.BGRed.ToString + CC
            ToWrite += XI.BGGreen.ToString + CC
            ToWrite += XI.BGBlue.ToString + CC
            ToWrite += XI.Foreground.ToString + CC
            ToWrite += XI.Background.ToString + CC
            ToWrite += CP
            For Each Ins As Instance In XI.GInstances
                ToWrite += Chr(LineType.Instance) + XI.Name + CC + Ins.ObjectName + CC + Ins.X.ToString + CC + Ins.Y.ToString + CP
            Next
        Next
        For Each XI As Sound In Sounds
            ToWrite += Chr(LineType.Sound) + XI.Name + CP
            File.WriteAllBytes(NP + "Sounds\" + XI.Name + ".wav", XI.Data)
        Next
        For X As Byte = 0 To SettingNames.Count - 1
            ToWrite += Chr(LineType.Setting) + SettingNames(X) + CC + SettingValues(X) + CP
        Next
        If FPlatformInputs.Inputs.Count > 0 Then
            For X As UInt16 = 0 To FPlatformInputs.Inputs.Count - 1
                ToWrite += Chr(LineType.Input) + FPlatformInputs.Inputs(X).Name + CP
                If FPlatformInputs.Inputs(X).Executors.Count > 0 Then
                    For Y As UInt16 = 0 To FPlatformInputs.Inputs(X).Executors.Count - 1
                        Dim PlatformName As String = FPlatformInputs.Inputs(X).Executors(Y).PlatformName
                        Dim PlatformII As String = FPlatformInputs.Inputs(X).Executors(Y).PlatformInputIdentifier
                        ToWrite += Chr(LineType.InputExecutor) + FPlatformInputs.Inputs(X).Name + CC + PlatformName + CC + PlatformII + CP
                    Next
                End If
            Next
        End If

        File.WriteAllText(NP + "DFK.dfk", ToWrite)
        GameLogo.Save(NP + "Logo.png", Imaging.ImageFormat.Png)

    End Sub

    Sub SaveProject(ByVal FullPath As String)
        Dim NP As String = AppPath + "SaveProject\"
        SaveProjectWork(NP)
        Dim MyBAT As String = "zip.exe a SaveProject.zip Images Sounds Files DFK.dfk Logo.png" + vbCrLf + "exit"
        RunBatchString(MyBAT, NP, True)
        File.Copy(NP + "SaveProject.zip", FullPath, True)
        'Lagging write protection from the fucking file system
        Try
            Directory.Delete(NP, True)
        Catch : End Try
        ChangeMade = False
    End Sub

    Sub SaveGUI()
        If SCurrentFile.Length = 0 Then SaveProjectAs() : Exit Sub
        SaveProject(CurrentFile)
    End Sub

    Sub SaveProjectAs()
        Dim NewPath As String = SaveFile(String.Empty, DefaultRegex, SCurrentFile)
        If NewPath.Length = 0 Then Exit Sub
        CurrentFile = NewPath
        SCurrentFile = CurrentFile.Substring(CurrentFile.LastIndexOf("\") + 1)
        SetProgramTitle()
        ChangeMade = False
        SaveProject(CurrentFile)
    End Sub

    Public Function FileDeathOperationGUI()
        If ChangeMade Then
            Dim Message As String = "Do you want to save changes to " + If(SCurrentFile.Length > 0, "'" + SCurrentFile + "'", "this new project") + "?"
            Dim Response As Byte = MessageBox.Show(Message, Application.ProductName, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning)
            If Response = MsgBoxResult.Cancel Then Return True
            If Response = MsgBoxResult.Yes Then SaveGUI()
        End If
        Return False
    End Function

    Public Sub ExportDialog(ByVal MyIcon As Image)
        If GetOption("AUTO_SAVE") = "1" Then
            If Not SCurrentFile.Length = 0 Then SaveProject(CurrentFile)
        End If
        'If Not IsLoggedIn() Then
        '    FPleaseLogin.ShowDialog()
        'End If

        Dim GameID As UInt32 = Convert.ToUInt32(GetSetting("GameID"))
        Dim ExportPath As String = AppPath + "ExportProject" + GameID.ToString + "\"

        SaveProjectWork(ExportPath)

        DirectoriesToDeleteOnExit.Add(ExportPath)

        With FSelectPlatform
            .Icon = ImageToIcon(MyIcon)
            .ShowDialog()
            If .SelectedPlatform.Length = 0 Then Exit Sub
        End With

        'Dim FoundAt As String = DoIt(GameID)

        Dim SR As String = FSelectPlatform.SelectedPlatform

        Dim T As New Platform
        For Each Q In Platforms
            If Q.Name = SR Then T = Q
        Next

        Dim IsGenerator As Boolean = (T.Category = PlatformCategory.Browser)
        Dim IsWindows As Boolean = (T.Name = "Windows")

        Dim TempData As String = "1"

        Dim OptimiserPath As String = AppPath + "PlatformProfiles\" + SR + "Optimiser.exe"

        Dim PI As New ProcessStartInfo
        Dim P As New Process

        With PI
            .WorkingDirectory = ExportPath
            .WindowStyle = ProcessWindowStyle.Hidden
        End With

        With P
            .StartInfo = PI
        End With

        If File.Exists(OptimiserPath) Then
            Dim OptimiserToPath As String = ExportPath + "Optimiser.exe"
            IO.File.Copy(OptimiserPath, OptimiserToPath, True)
            With PI
                .FileName = OptimiserToPath
            End With
            With P
                .Start()
                .WaitForExit()
            End With
        End If

        With FExportDone
            .WhichPlatform = T
        End With

        If IsGenerator Then
            With PI
                .FileName = AppPath + "PlatformProfiles\" + T.EXEPath
                .Arguments = """" + ExportPath.Substring(0, ExportPath.Length - 1) + """ " + GameID.ToString + " """ + AppPath + "Actions" + """ " + TempData + If(T.Arguments.Length > 0, " ", String.Empty) + T.Arguments
            End With
            'MsgError(PI.Arguments)
            With P
                .StartInfo = PI
                .Start()
                .WaitForExit()
            End With

            If SR = "Browser" Then
                Dim CurrentBrowser As String = GetOption("BROWSER")
                Dim MyEXEPath As String = String.Empty
                For Each E In Browsers
                    If E.Name = CurrentBrowser Then
                        If File.Exists(E.EXEPath) Then MyEXEPath = E.EXEPath : Exit For
                    End If
                Next
                If MyEXEPath.Length = 0 Then
                    MsgError("Your Selected Browser does not exist. Go to Options.")
                Else
                    System.Diagnostics.Process.Start(MyEXEPath, """" + ExportPath + SR + "Files\index.html" + """")
                End If
            End If

            P.Dispose()

            With FExportDone
                .ImportantData = ExportPath + SR + "Files\"
                .ShowDialog()
            End With

        Else

            Dim ODFXMakerToPath As String = AppPath + "ODFXMaker.exe"
            With PI
                .FileName = ODFXMakerToPath
                .Arguments = """" + ExportPath.Substring(0, ExportPath.Length - 1) + """ " + GameID.ToString + " """ + AppPath + "Actions" + """ " + TempData
                'MsgError(.Arguments)
            End With
            With P
                .StartInfo = PI
                .Start()
                .WaitForExit()
            End With
            If IsWindows Then
                System.Diagnostics.Process.Start(AppPath + "PlatformProfiles\" + T.EXEPath, """" + ExportPath + "Data.odfx" + """")

                P.Dispose()
            End If

            With FExportDone
                .ImportantData = ExportPath + "Data.odfx"
                .ShowDialog()
            End With

            End If

    End Sub

    Sub BinResNodeAfterDeletion(ByVal DName As String, ByVal ResNodeID As Byte)
        If MainForm.ResourcesList.Nodes(ResNodeID).Nodes.Count > 0 Then
            For B = 0 To MainForm.ResourcesList.Nodes(ResNodeID).Nodes.Count - 1
                Try
                    If MainForm.ResourcesList.Nodes(ResNodeID).Nodes(B).Text = DName Then
                        MainForm.ResourcesList.Nodes(ResNodeID).Nodes.RemoveAt(B)
                    End If
                Catch : End Try
            Next
        End If
    End Sub

    Public Sub DeleteImage(ByVal DName As String)

        Dim DidDoIt As Boolean = False
        Dim U As UInt16 = 0
        For I As UInt16 = 0 To Images.Count - 1
            If Images(I).Name = DName Then U = I : DidDoIt = True
        Next I

        If Not DidDoIt Then
            ResourceError("delete", ResourceType.Image)
            Exit Sub
        End If

        Images.RemoveAt(U)

        If Objects.Count > 0 Then
            For P As UInt16 = 0 To Objects.Count - 1
                If Objects(P).ImageName = DName Then Objects(P).ImageName = String.Empty
            Next
        End If

        For Each P As Form In MainForm.MdiChildren
            If P.Name = "FObject" Then
                DirectCast(P, FObject).RemoveImage(DName)
            ElseIf P.Name = "FScene" Then
                DirectCast(P, FScene).RemoveImage(DName)
            End If
            If P.Name = "FImage" And P.Text = DName Then
                P.Close()
            End If
        Next

        BinResNodeAfterDeletion(DName, ResourceType.Image)

    End Sub

    Dim ObjFitFilter As String = String.Empty
    Function ObjFits(ByVal Passable As Instance) As Boolean
        If Passable.ObjectName = ObjFitFilter Then Return True
        Return False
    End Function

    Function SceneObjFits(ByVal Passable As FScene.SceneInstance) As Boolean
        If Passable.ObjectName = ObjFitFilter Then Return True
        Return False
    End Function

    Public Sub DeleteObject(ByVal DName As String)

        ObjFitFilter = DName
        Dim U As Int16 = 0
        For Each D As DObject In Objects
            If D.Name = DName Then Exit For
            U += 1
        Next
        Objects.RemoveAt(U)
        For Each P As Scene In Scenes
            Dim FoundMatched As UInt16 = 0
            For Each D As Instance In P.GInstances
                If D.ObjectName = DName Then FoundMatched += 1
            Next
            If FoundMatched > 0 Then
                Dim GInstancesList(P.GInstances.Count - 1) As Instance
                P.GInstances.CopyTo(GInstancesList, 0)
                For Each F As Instance In Array.FindAll(GInstancesList, AddressOf ObjFits)
                    P.GInstances.Remove(F)
                Next
            End If
        Next
        For Each P As DObject In Objects
            For Each T As DEvent In P.Events
                If T.EventType = "Collision" And T.EventData = DName Then T.EventData = "<Unknown>"
            Next
        Next
        For Each P As Form In MainForm.MdiChildren
            If P.Name = "FScene" Then
                Dim FoundMatched As UInt16 = 0
                For Each D As FScene.SceneInstance In DirectCast(P, FScene).Instances
                    If D.ObjectName = DName Then FoundMatched += 1
                Next
                If FoundMatched > 0 Then
                    Dim GInstancesList(DirectCast(P, FScene).Instances.Count - 1) As FScene.SceneInstance
                    DirectCast(P, FScene).Instances.CopyTo(GInstancesList, 0)
                    For Each F As FScene.SceneInstance In Array.FindAll(GInstancesList, AddressOf SceneObjFits)
                        DirectCast(P, FScene).Instances.Remove(F)
                    Next
                    DirectCast(P, FScene).DesignPanel.Invalidate()
                End If
            ElseIf P.Name = "FObject" Then
                DirectCast(P, FObject).LDeleteObject(DName)
            End If
            If P.Text = DName Then
                P.Close()
            End If
        Next
        If DefaultObjectToPlot = DName Then DefaultObjectToPlot = String.Empty

        BinResNodeAfterDeletion(DName, ResourceType.DObject)

    End Sub

    Public Sub DeleteScene(ByVal DName As String)
        Dim U As Int16 = 0
        For Each D As Scene In Scenes
            If D.Name = DName Then Exit For
            U += 1
        Next
        Scenes.RemoveAt(U)
        For Each P As Form In MainForm.MdiChildren
            If P.Text = DName Then
                P.Close()
            End If
        Next
        If GetSetting("BootScene") = DName Then SetSetting("BootScene", Scenes(0).Name)

        BinResNodeAfterDeletion(DName, ResourceType.Scene)

    End Sub

    Public Sub DeleteSound(ByVal DName As String)
        For Each P As Form In MainForm.MdiChildren
            If P.Text = DName Then
                P.Close()
            End If
        Next
        Dim U As Int16 = 0
        For Each D As Sound In Sounds
            If D.Name = DName Then Exit For
            U += 1
        Next
        Sounds.RemoveAt(U)

        BinResNodeAfterDeletion(DName, ResourceType.Sound)

    End Sub

    Sub ResourceError(ByVal Verb As String, ByVal ResID As Byte)
        MsgError("Bad news. I couldn't " + Verb + " your " + ResourceTypes(ResID) + ".")
    End Sub

End Module
