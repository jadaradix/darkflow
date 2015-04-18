Imports System.IO
Imports System.Media

Public Class MainForm

    Public AppPath As String

    'Public GamePath As String

    Dim Data(0) As Byte
    Public FilesFound As New List(Of String)

    Dim DeadText As String = "Dark Flow Runner"

    Private Property Up_Arrow_State As Boolean

    Private Sub MainForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Array.Resize(Data, 0)

        AppPath = Application.StartupPath + Path.DirectorySeparatorChar
        Icon = My.Resources.InternalAppIcon
        For Each Arg As String In My.Application.CommandLineArgs
            If File.Exists(Arg) Then FilesFound.Add(Arg) : Exit For
        Next
        If FilesFound.Count > 0 Then
            Data = File.ReadAllBytes(FilesFound(0))
        Else
            For Each X As String In Directory.GetFiles(AppPath)
                If X.EndsWith(".odfx") Then
                    FilesFound.Add(X)
                End If
            Next
        End If
        If FilesFound.Count = 0 Then
            'Try internal Data
            Dim DataLengthData() As Byte = My.Resources.DataLength
            Dim DataLengthString As String = String.Empty
            For I = 0 To DataLengthData.Length - 1
                Dim NumericString As String = Chr(DataLengthData(I))
                DataLengthString += NumericString
            Next
            Dim DataLength As UInt64 = Convert.ToUInt64(DataLengthString)
            If DataLength = 31415926 Then
                MsgError("No input file passed or found.")
                End
            Else
                Array.Resize(Data, DataLength)
                Array.ConstrainedCopy(My.Resources.Data, 0, Data, 0, DataLength)
            End If
        Else
            Data = File.ReadAllBytes(FilesFound(0))
        End If

        'IO.File.WriteAllBytes("C:/Users/James/Desktop/Game.odfx", Data)

        InitAlarms(16)
        InitKeys()
        InitFontCharacters(String.Empty)
        InitOperators()
        CalculateAdds()

        'Dim ScreenWidth As UInt16 = My.Computer.Screen.Bounds.Width
        'Dim ScreenHeight As UInt16 = My.Computer.Screen.Bounds.Height
        'Location = New Point((ScreenWidth / 2) - (Width / 2), (ScreenHeight / 2) - (Height / 2))
        'Dim ImageToDraw As New Bitmap(ClientRectangle.Width, ClientRectangle.Height)
        'Dim ImageToDrawGFX As Graphics = Graphics.FromImage(ImageToDraw)
        'ImageToDrawGFX.Clear(Color.FromArgb(64, 64, 64))
        'ImageToDrawGFX.DrawImageUnscaled(My.Resources.DarkFlowLogo, New Point((ClientRectangle.Width - My.Resources.DarkFlowLogo.Width) / 2, (ClientRectangle.Height - My.Resources.DarkFlowLogo.Height) / 2))
        'ImageToDrawGFX.Dispose()
        'BackgroundImage = ImageToDraw
        'Dim TempTimer As New Timer
        'TempTimer.Interval = 100
        'AddHandler TempTimer.Tick, AddressOf TempTimerTick
        'TempTimer.Enabled = True

        Begin()

    End Sub

    Dim TempTicks As UInt16 = 0
    Sub TempTimerTick()
        If TempTicks = 5 Then
            BackColor = Color.FromArgb(64, 64, 64)
            BackgroundImage = Nothing
            Begin()
        End If
        TempTicks += 1
    End Sub

    Private Sub MainForm_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown
        If FilesFound.Count > 1 Then
            SelectFile.ShowDialog(Me)
            Data = File.ReadAllBytes(FilesFound(SelectFile.FilesListBox.SelectedIndex))
            Begin()
        End If
    End Sub

    Sub Begin()

        With IfCommands
            .Add("IF")
            .Add("IF_CHECK_POSITION")
            .Add("IF_MORE")
            .Add("IF_LESS")
            .Add("IF_PLATFORM")
            .Add("IF_CURRENT_SCENE")
            .Add("IF_NEXT_SCENE")
            .Add("IF_PREVIOUS_SCENE")
            .Add("IF_OBJECT_AT_POSITION")
            .Add("IF_INSTANCES")
            .Add("ELSE")
            .Add("IF_ALARM_RINGS")
        End With

        Text = "Loading..."

        Dim BinStartPos As UInt16 = 0

        Dim TempStartPos As Byte = 0
        Dim TempLength As Byte = 4

        Dim LVersion As Byte = Data(0)

        If LVersion > Version Then
            MsgError("This file is created for a runner newer than this.")
            End
        End If

        Dim LIDEVersion As Byte = Data(1)
        Dim LJunkByte1 As Byte = Data(2)
        Dim LJunkByte2 As Byte = Data(3)

        'Game ID (byte gather loop)
        TempStartPos = 4
        TempLength = 4
        Dim LGameIDArray(TempLength - 1) As Byte
        For i As Byte = 0 To TempLength - 1
            LGameIDArray(i) = Data(TempStartPos + i)
        Next
        Dim LGameID As UInt32 = BitConverter.ToUInt32(LGameIDArray, 0)

        'Pro Hash (byte gather loop)
        TempStartPos = 8
        TempLength = 4
        Dim LProHashArray(TempLength - 1) As Byte
        For i As Byte = 0 To TempLength - 1
            LProHashArray(i) = Data(TempStartPos + i)
        Next
        Dim LProHash As UInt32 = BitConverter.ToUInt32(LProHashArray, 0)
        Dim NProHash As UInt32 = MakeProHash(LGameID)

        Pro = (LProHash = NProHash)

        'Magic (byte gather loop)
        TempStartPos = 12
        TempLength = 4
        Dim LMagicArray(TempLength - 1) As Byte
        For i As Byte = 0 To TempLength - 1
            LMagicArray(i) = Data(TempStartPos + i)
        Next
        Dim LMagic = BitConverter.ToUInt32(LMagicArray, 0)

        'MsgError("version: " + LVersion.ToString)
        'MsgError("df ide version: " + LIDEVersion.ToString)
        'MsgError("junk1: " + LJunkByte1.ToString)
        'MsgError("junk2: " + LJunkByte2.ToString)
        'MsgError("game id: " + LGameID.ToString)
        'MsgError("pro hash: " + LProHash.ToString)
        'MsgError("magic: " + LMagic.ToString)

        Dim ReadPos As UInt64 = 16

        Dim BinaryCount As UInt16 = BitConverter.ToUInt16(Data, ReadPos)
        ReadPos += 2

        Dim DataTypes(BinaryCount - 1) As Byte
        Dim DataLengths(BinaryCount - 1) As UInt32

        If BinaryCount > 0 Then

            For I As UInt32 = 0 To BinaryCount - 1
                DataTypes(I) = Data(ReadPos)
                ReadPos += 1
                Dim DataLength As UInt32 = BitConverter.ToUInt32(Data, ReadPos)
                DataLengths(I) = DataLength
                ReadPos += 4
            Next

            BinStartPos = ReadPos

            'Pump up ReadPos by our present data to allow for proper string subbing
            For I As UInt64 = 0 To BinaryCount - 1
                ReadPos += DataLengths(I)
            Next

        End If

        Dim Items As New List(Of String)
        Dim Current As String = String.Empty

        For I As UInt64 = ReadPos To Data.Length - 1
            Dim Here As Byte = Data(I)
            If Here = ParentSplitter Then
                Items.Add(Current)
                Current = String.Empty
            Else
                Current += Chr(Here).ToString
            End If
        Next
        If Current.Length > 0 Then Items.Add(Current)

        For Each X As String In Items
            If X.Length = 0 Then Continue For
            Dim Pre As Byte = Asc(X.Substring(0, 1))
            X = X.Substring(1)
            Select Case Pre
                Case LineType.Image
                    Dim WorkWith As String = X
                    Dim ImageName As String = WorkWith.Substring(0, WorkWith.IndexOf(CC))
                    WorkWith = WorkWith.Substring(ImageName.Length + 1)
                    Dim FrameHeight As UInt16 = Convert.ToUInt16(WorkWith)
                    'Dim ImageWidth As UInt16 = Convert.ToUInt16(WorkWith.Substring(0, WorkWith.IndexOf(C)))
                    'WorkWith = WorkWith.Substring(ImageWidth.ToString.Length + 1)
                    'Dim ImageHeight As UInt16 = Convert.ToUInt16(WorkWith)
                    Dim P As New DImage(ImageName, 32, 32, FrameHeight)
                    Images.Add(P)
                Case LineType.DObject
                    'Clipboard.SetText(X)
                    Dim ObjectName As String = X.Substring(0, X.IndexOf(CC))
                    Dim ImageName As String = X.Substring(ObjectName.Length + 1)
                    ImageName = ImageName.Substring(0, ImageName.IndexOf(CC))
                    Dim Depth As Byte = Convert.ToByte(X.Substring(X.LastIndexOf(CC) + 1))
                    Dim P As New DObject(ObjectName, ImageName, New List(Of DEvent), Depth)
                    Objects.Add(P)
                Case LineType.Scene
                    Dim Data() As String = Split(X, CC)
                    Dim SName As String = Data(0)
                    Dim S As New Scene(SName, 100, 100, 100, 100, 0, 0, 0, 0, 0, String.Empty, String.Empty, New List(Of Instance))
                    With S
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
                Case LineType.Sound
                    Dim SoundName As String = X
                    Sounds.Add(New Sound(SoundName))
                Case LineType.DEvent
                    Dim ObjectName As String = X.Substring(0, X.IndexOf(CC))
                    X = X.Substring(ObjectName.Length + 1)
                    Dim EventType As String = X.Substring(0, X.IndexOf(CC))
                    X = X.Substring(EventType.Length + 1)
                    Dim EventData As String = X.Substring(0, X.IndexOf(CC))
                    X = X.Substring(EventData.Length + 1)
                    Dim EventCode As String = X
                    Dim D As New DEvent
                    With D
                        .ObjectName = ObjectName
                        .EventType = EventType
                        .EventData = EventData
                        .Code = EventCode
                    End With
                    DEvents.Add(D)
                Case LineType.Setting
                    Dim SettingName As String = X.Substring(0, X.IndexOf(CC))
                    Dim SettingValue As String = X.Substring(SettingName.Length + 1)
                    Settings.Add(SettingName)
                    SettingValues.Add(SettingValue)
                Case LineType.Input
                    Inputs.Add(New Input(X, New List(Of InputExecutor)))
            End Select
        Next
        
        For Each X As String In Items
            If X.Length = 0 Then Continue For
            Dim Pre As Byte = Asc(X.Substring(0, 1))
            X = X.Substring(1)
            Select Case Pre
                Case LineType.Instance
                    Dim Data() As String = Split(X, CC)
                    Dim SName As String = Data(0)
                    Dim OName As String = Data(1)
                    Dim IName As String = String.Empty
                    Dim IWidth As UInt16 = 0
                    Dim IHeight As UInt16 = 0
                    Dim LX As Int16 = Convert.ToInt16(Data(2))
                    Dim LY As Int16 = Convert.ToInt16(Data(3))
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
                        Dim I As New Instance(OName, IName, LX, LY, LX, LY, 64, 64, 0, 0, 0, 0, 0, 0, New List(Of Variable), 0, 0, 0)
                        With I
                            .Width = IWidth
                            .Height = IHeight
                            .VX = 0
                            .VY = 0
                            .AX = 0
                            .AY = 0
                            .Depth = 0
                        End With
                        P.Instances.Add(I)
                    Next
                Case LineType.InputExecutor
                    Dim InputName As String = X.Substring(0, X.IndexOf(CC))
                    X = X.Substring(InputName.Length + 1)
                    For Each P As Input In Inputs
                        If Not P.Name = InputName Then Continue For
                        Dim ConsoleName As String = X.Substring(0, X.IndexOf(CC))
                        X = X.Substring(ConsoleName.Length + 1)
                        Dim ConsoleII As String = X
                        P.Executors.Add(New InputExecutor(ConsoleName, ConsoleII))
                    Next
            End Select
        Next

        Dim ImagesThusFar As UInt16 = 0
        Dim SoundsThusFar As UInt16 = 0
        Dim GenericsThusFar As UInt16 = 0

        If BinaryCount > 0 Then
            ReadPos = BinStartPos
            For I As UInt16 = 0 To BinaryCount - 1
                Dim DataLength As UInt32 = DataLengths(I)
                Dim MyData(DataLength - 1) As Byte
                'BLOODY SLOW - accelerated function anyone?
                For F As UInt32 = 0 To DataLength - 1
                    MyData(F) = Data(Convert.ToUInt32(ReadPos) + F)
                Next
                Select Case DataTypes(I)
                    Case BinaryDataType.Image
                        Dim TMPInf As Bitmap = MemoryToBMP(MyData)
                        Images(ImagesThusFar).Data = TMPInf.Clone()
                        Images(ImagesThusFar).Width = TMPInf.Width
                        Images(ImagesThusFar).Height = TMPInf.Height
                        TMPInf.Dispose()
                        ImagesThusFar += 1
                    Case BinaryDataType.Sound
                        Sounds(SoundsThusFar).Data = MyData
                        SoundsThusFar += 1
                    Case BinaryDataType.Generic
                        GenericsThusFar += 1
                End Select
                ReadPos += DataLength
            Next
        End If

        Dim BootSceneName As String = String.Empty
        If Settings.Count > 0 Then
            For P As UInt16 = 0 To Settings.Count - 1
                If Settings(P) = "BootScene" Then BootSceneName = SettingValues(P)
                If Settings(P) = "Product" Then Text = SettingValues(P)
            Next
        End If
        Dim TempCS As UInt16 = 0
        If BootSceneName.Length > 0 Then
            If Settings.Count > 0 Then
                For P As UInt16 = 0 To Scenes.Count - 1
                    If Scenes(P).Name = BootSceneName Then TempCS = P : Exit For
                Next
            End If
        End If
        BootScene(TempCS)

        'Mouse Handles
        AddHandler Me.MouseMove, AddressOf DFMouseMove
        AddHandler Me.MouseLeave, AddressOf DFMouseLeave
        AddHandler Me.MouseDown, AddressOf DFMouseDown
        AddHandler Me.MouseUp, AddressOf DFMouseUp
        AddHandler Me.MouseClick, AddressOf DFMouseClick

        'Keyboard Handles
        AddHandler Me.KeyUp, AddressOf DFKeyUp
        AddHandler Me.KeyDown, AddressOf DFKeyDown

        'VBL Timer
        AddHandler VBLTicker.Tick, AddressOf VBL
        VBLTicker.Enabled = True

    End Sub

    Sub DFMouseMove(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        If StackWorkForbidden Then Exit Sub
        If e.Location.X < 0 Or e.Location.Y < 0 Then Exit Sub
        Pointer_X = e.Location.X
        Pointer_Y = e.Location.Y
        Pointer_In = True
        PointerLogic("Over")
    End Sub

    Sub DFMouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If StackWorkForbidden Then Exit Sub
        Pointer_In = False
    End Sub

    Sub DFMouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        If StackWorkForbidden Then Exit Sub
        PointerLogic("Down")
        Pointer_Held = True
    End Sub

    Sub DFMouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        If StackWorkForbidden Then Exit Sub
        PointerLogic("Up")
        Pointer_Held = False
    End Sub

    Sub DFMouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        If StackWorkForbidden Then Exit Sub
        PointerLogic("Click")
    End Sub

    Sub DFKeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If StackWorkForbidden Then Exit Sub
        DFKeyCrap(e.KeyCode, True)
    End Sub

    Sub DFKeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If StackWorkForbidden Then Exit Sub
        DFKeyCrap(e.KeyCode, False)
    End Sub

    Sub DFKeyCrap(ByVal KeyCode As UInt16, ByVal IsUp As Boolean)
        If CusA.Instances.Count > 0 And Inputs.Count > 0 Then
            For I As UInt16 = 0 To Inputs.Count - 1
                Dim DoThisInput As Boolean = False
                For Each P As InputExecutor In Inputs(I).Executors
                    If Not P.ConsoleName = "Windows" Then Continue For
                    For Each G As KeyElement In DFKeys
                        If Not G.Firer = KeyCode Then Continue For
                        If IsUp Then
                            If P.ConsoleInputIdentifier = G.Descriptor + " Released" Then DoThisInput = True
                        Else
                            If P.ConsoleInputIdentifier = G.Descriptor Then DoThisInput = True
                        End If
                    Next
                Next
                If DoThisInput Then
                    For D As UInt16 = 0 To CusA.Instances.Count - 1
                        If DF_Ignore(D) Then Continue For
                        PutOnStack("Input", Inputs(I).Name, False, D, 0, False)
                    Next
                End If
            Next
        End If
    End Sub

End Class
