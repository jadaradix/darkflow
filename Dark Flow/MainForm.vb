Imports System.Runtime.InteropServices
Imports System.Drawing.Drawing2D
Imports System.Net
Imports System.IO

Public Class MainForm

    'REMOVE NASTY 3D BORDER
    Private WithEvents MyMDIClient As Control
    <DllImport("user32")> _
    Private Shared Function SetWindowLong(ByVal hWnd As IntPtr, ByVal nIndex As Int32, ByVal dwNewLong As IntPtr) As IntPtr
    End Function
    Private Sub MainForm_Layout(ByVal sender As Object, ByVal e As System.Windows.Forms.LayoutEventArgs) Handles MyBase.Layout
        If MyMDIClient Is Nothing AndAlso Me.IsMdiContainer Then
            Dim EIN As IEnumerator = Me.Controls.GetEnumerator
            Do While EIN.MoveNext AndAlso MyMDIClient Is Nothing
                If TypeOf EIN.Current Is MdiClient Then
                    MyMDIClient = DirectCast(EIN.Current, MdiClient)
                    SetWindowLong(MyMDIClient.Handle, -20, 0)
                End If
            Loop
        End If
    End Sub
    'END REMOVE NASTY 3D BORDER

    Private Sub MainForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Icon = My.Resources.Icon
        Glosser.BackColor = CrucialColor

        SexyDoings(Me, False)
        If AeroEnabled() Then
            Glosser.BackColor = Color.Black

            DMainMenuStrip.BackColor = Color.Black
            GlassOn(Me, New Padding(0, 26, 0, 0))
        Else
            DMainMenuStrip.BackColor = CrucialColor
        End If

        IsMdiContainer = True

        ResourceRightClicker.Renderer = New metroMenuRenderer
        DMainMenuStrip.Renderer = New metroMenuRenderer
        DMainMenuStrip.Invalidate()

        InitGlobalImages()
        InitFileSystem()
        LoadOptions()

        InitPlatforms()
        InitArrays()

        InitResourcesList()
        InitActions()

        AssociateFileTypes()

        NewWork()
        SetProgramTitle()
        'SexUpToolStrip(PrimaryToolStrip, False, True)
        SexUpToolStrip_New(PrimaryToolStrip, False, True)
        'SexUpToolStrip(SecondaryToolStrip, False, True)
        StripsContainer.Height = PrimaryToolStrip.Height '+ SecondaryToolStrip.Height

    End Sub

    Private Sub MainForm_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown
        Dim DoOpen As Boolean = (GetOption("WELCOME_ON_BOOT") = "1")
        Dim DidOpen As Boolean = False
        For Each Arg As String In My.Application.CommandLineArgs
            If IO.File.Exists(Arg) And Arg.EndsWith(".dfk") Then
                OpenProject(Arg)
                DoOpen = False
                DidOpen = True
                Exit For
            End If
        Next
        If DoOpen Then ShowInternalForm(FWelcome)
    End Sub

    Private Sub MainForm_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        If FileDeathOperationGUI() Then e.Cancel = True
        For Each X As String In DirectoriesToDeleteOnExit
            Try
                IO.Directory.Delete(X, True)
            Catch : End Try
        Next
    End Sub

    Private Sub MainForm_ResizeEnd(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.ResizeEnd
        MainSplitter.Invalidate()
    End Sub

    Private Sub NewButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NewButton.Click, NewMenuButton.Click
        If FileDeathOperationGUI() Then Exit Sub
        NewWork()
        SetProgramTitle()
    End Sub

    Private Sub OpenButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpenButton.Click, OpenMenuButton.Click
        If FileDeathOperationGUI() Then Exit Sub
        Dim FilePath As String = OpenFile(String.Empty, DefaultRegex)
        If FilePath.Length = 0 Then Exit Sub
        OpenProject(FilePath)
    End Sub

    Private Sub SaveButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveButton.Click, SaveMenuButton.Click
        SaveGUI()
    End Sub

    Private Sub SaveAsMenuButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveAsMenuButton.Click
        SaveProjectAs()
    End Sub

    Private Sub AddImageButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddImageButton.Click, AddImageMenuButton.Click
        Dim Response As String = AddResource(ResourceType.Image, True, False)
        For Each X As Form In MdiChildren
            If X.Name = "FScene" Then
                DirectCast(X, FScene).AddImage(Response)
            ElseIf X.Name = "FObject" Then
                DirectCast(X, FObject).AddImage(Response)
            End If
        Next
    End Sub

    Private Sub AddObjectButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddObjectButton.Click, AddObjectMenuButton.Click
        Dim Response As String = AddResource(ResourceType.DObject, True, False)
        For Each X As Form In MdiChildren
            If Not X.Name = "FScene" Then Continue For
            DirectCast(X, FScene).AddObject(Response)
        Next
    End Sub

    Private Sub AddSceneButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddSceneButton.Click, AddSceneMenuButton.Click
        AddResource(ResourceType.Scene, True, False)
    End Sub

    Private Sub AddSoundButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddSoundButton.Click, AddSoundMenuButton.Click
        AddResource(ResourceType.Sound, True, False)
    End Sub

    Private Sub ImportMenuButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        If FileDeathOperationGUI() Then Exit Sub

        NewWork()
        SetProgramTitle()

    End Sub

    Private Sub TestButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PlayButton.Click, PlayMenuButton.Click
        ExportDialog(My.Resources.PlayIcon)
    End Sub

    Private Sub PublishButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        ExportDialog(My.Resources.ExportIcon)
    End Sub

    Public Sub ResourcesList_NodeMouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeNodeMouseClickEventArgs) Handles ResourcesList.NodeMouseDoubleClick
        OpenResource(e.Node)
    End Sub

    Private Sub OptionsButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OptionsButton.Click, OptionsMenuButton.Click
        FOptions.ShowDialog()
    End Sub

    Private Sub GameSettingsButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GameSettingsButton.Click, GameSettingsMenuButton.Click
        FGameSettings.ShowDialog()
    End Sub

    Private Sub PlatformInputsToolsButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PlatformInputsButton.Click, PlatformInputsMenuButton.Click
        FPlatformInputs.ShowDialog()
    End Sub

    Private Sub ActionEditorButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ActionEditorMenuButton.Click
        If MdiChildren.Count > 0 Then
            'TRANSLATE
            MsgError("Please close all open windows first!")
            Exit Sub
        End If
        FActionEditor.ShowDialog()
    End Sub

    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    '''''       The Ugliest Bodge in the World!        '''''
    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''

    Private Sub DMainMenuStrip_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles DMainMenuStrip.Paint
        If AeroEnabled() Then e.Graphics.Clear(Color.Transparent) Else e.Graphics.Clear(CrucialColor)
        e.Graphics.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias
        'e.Graphics.DrawPath(New Pen(Color.FromArgb(198, 216, 218)), CreateTopRoundedRect(New Rectangle(0, 0, DMainMenuStrip.Width - 2, DMainMenuStrip.Height - 2), 5))
        'e.Graphics.FillPath(New SolidBrush(Color.FromArgb(250, 250, 253)), CreateTopRoundedRect(New Rectangle(1, 1, DMainMenuStrip.Width - 4, DMainMenuStrip.Height), 5))
        'e.Graphics.DrawPath(New Pen(Color.FromArgb(88, 103, 119)), CreateTopRoundedRect(New Rectangle(1, 1, DMainMenuStrip.Width - 4, DMainMenuStrip.Height), 5))
        e.Graphics.DrawLine(New Pen(Color.FromArgb(88, 103, 119)), New Point(0, DMainMenuStrip.Height - 1), New Point(DMainMenuStrip.Width, DMainMenuStrip.Height - 1))
        e.Graphics.DrawLine(New Pen(Color.FromArgb(198, 216, 218)), New Point(0, DMainMenuStrip.Height - 2), New Point(DMainMenuStrip.Width, DMainMenuStrip.Height - 2))

        Dim gBrush As LinearGradientBrush = New LinearGradientBrush(New Point(0, 0) _
                                              , New Point(0, DMainMenuStrip.Height) _
                                              , Color.FromArgb(218, 218, 218) _
                                              , Color.FromArgb(238, 238, 238))
        e.Graphics.DrawRectangle(New Pen(Color.FromArgb(198, 216, 218)), New Rectangle(0, 0, DMainMenuStrip.Width - 2, DMainMenuStrip.Height - 2))
        e.Graphics.FillRectangle(gBrush, New Rectangle(1, 1, DMainMenuStrip.Width - 4, DMainMenuStrip.Height))
        e.Graphics.DrawRectangle(New Pen(Color.FromArgb(88, 103, 119)), New Rectangle(1, 1, DMainMenuStrip.Width - 4, DMainMenuStrip.Height))
    End Sub

    Private Sub Droppers_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles FileDropper.Paint, WindowDropper.Paint, GameDropper.Paint, ToolsDropper.Paint, HelpDropper.Paint
        e.Graphics.TextRenderingHint = Drawing.Text.TextRenderingHint.AntiAlias
        e.Graphics.DrawString(DirectCast(sender, ToolStripMenuItem).Text, DirectCast(sender, ToolStripMenuItem).Font, If(DirectCast(sender, ToolStripMenuItem).Selected Or DirectCast(sender, ToolStripMenuItem).Pressed, Brushes.White, Brushes.Black), (DirectCast(sender, ToolStripMenuItem).Width / 2) - (e.Graphics.MeasureString(DirectCast(sender, ToolStripMenuItem).Text, DirectCast(sender, ToolStripMenuItem).Font, New SizeF).ToSize.Width / 2), 1)
    End Sub

    Private Sub ShowWelcomeWindowMenuButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ShowWelcomeWindowMenuButton.Click
        For Each TheForm As Form In MdiChildren
            If TheForm.Name = "FWelcome" Then TheForm.Focus() : Exit Sub
        Next
        ShowInternalForm(FWelcome)
    End Sub

    Private Sub ResetOptionsMenuButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ResetOptionsMenuButton.Click
        If Not WarnYesNo("Are you sure that you would like to reset your " + Application.ProductName + " Options?") Then Exit Sub
        IO.File.WriteAllBytes(OptionsPath, My.Resources.RestoreData)
        LoadOptions()
    End Sub

    Private Sub AboutMenuButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AboutMenuButton.Click
        FAbout.ShowDialog()
    End Sub

    Private Sub ResourcesList_NodeMouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeNodeMouseClickEventArgs) Handles ResourcesList.NodeMouseClick
        Dim TI As Byte = 0
        Dim ParentText As String = String.Empty
        If e.Node.Level = 0 Then
            ParentText = e.Node.Text
            TI = e.Node.Index
            DeleteResourceContextButton.Text = "Delete"
            EditResourceContextButton.Text = "Edit"
            AddResourceContextButton.Enabled = True
            DeleteResourceContextButton.Enabled = False
            EditResourceContextButton.Enabled = False
        Else
            ParentText = e.Node.Parent.Text
            TI = e.Node.Parent.Index
            DeleteResourceContextButton.Text = "Delete " + e.Node.Text
            EditResourceContextButton.Text = "Edit " + e.Node.Text
            AddResourceContextButton.Enabled = True
            DeleteResourceContextButton.Enabled = True
            EditResourceContextButton.Enabled = True
        End If
        AddResourceContextButton.Text = "Add " + EnResourceTypes(TI)
        AddResourceContextButton.Image = GlobalImages.Images(TI + 1)
    End Sub

    Private Sub AddResourceContextButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddResourceContextButton.Click
        Select Case CType(sender, ToolStripMenuItem).Text
            Case "Add Image"
                AddImageButton_Click(sender, e)
            Case "Add Object"
                AddObjectButton_Click(sender, e)
            Case "Add Scene"
                AddSceneButton_Click(sender, e)
            Case "Add Sound"
                AddSoundButton_Click(sender, e)
        End Select
    End Sub

    Sub OpenResource(ByVal WhichNode As TreeNode)
        For Each TheForm As Form In MdiChildren
            If TheForm.Text = WhichNode.Text Then TheForm.Focus() : Exit Sub
        Next
        If WhichNode.Level = 0 Then Exit Sub
        Dim NewForm As Form = New Form
        Select Case WhichNode.Parent.Index
            Case ResourceType.Image
                NewForm = New FImage
                Dim DidDoIt As Boolean = False
                Dim R As UInt16 = 0
                For P As UInt16 = 0 To Images.Count - 1
                    If Images(P).Name = WhichNode.Text Then
                        R = P
                        DidDoIt = True
                        Exit For
                    End If
                Next
                If DidDoIt Then
                    CType(NewForm, FImage).SetMoi(Images(R).CloneMe())
                Else
                    ResourceError("load", ResourceType.Image)
                    Exit Sub
                End If
            Case ResourceType.DObject
                NewForm = New FObject
                Dim DidDoIt As Boolean = False
                Dim R As UInt16 = 0
                For P As UInt16 = 0 To Objects.Count - 1
                    If Objects(P).Name = WhichNode.Text Then
                        R = P
                        DidDoIt = True
                        Exit For
                    End If
                Next
                If DidDoIt Then
                    CType(NewForm, FObject).SetMoi(Objects(R).CloneMe())
                Else
                    ResourceError("load", ResourceType.DObject)
                    Exit Sub
                End If
            Case ResourceType.Scene
                NewForm = New FScene
                With CType(NewForm, FScene)
                    .DName = WhichNode.Text
                    For Each P As Scene In Scenes
                        If Not P.Name = WhichNode.Text Then Continue For
                        .DWidth = P.Width
                        .DHeight = P.Height
                        .ViewWidth = P.ViewWidth
                        .ViewHeight = P.ViewHeight
                        .ViewX = P.ViewX
                        .ViewY = P.ViewY
                        .BGRed = P.BGRed
                        .BGGreen = P.BGGreen
                        .BGBlue = P.BGBlue
                        .Foreground = P.Foreground
                        .Background = P.Background
                        For Each X As Instance In P.GInstances
                            .Instances.Add(New FScene.SceneInstance(X.ObjectName, X.X, X.Y))
                        Next
                        Exit For
                    Next
                End With
            Case ResourceType.Sound
                NewForm = New FSound
                Dim DidDoIt As Boolean = False
                Dim R As UInt16 = 0
                For P As UInt16 = 0 To Sounds.Count - 1
                    If Sounds(P).Name = WhichNode.Text Then
                        R = P
                        DidDoIt = True
                        Exit For
                    End If
                Next
                If DidDoIt Then
                    CType(NewForm, FSound).SetMoi(Sounds(R).CloneMe())
                Else
                    ResourceError("load", ResourceType.Sound)
                    Exit Sub
                End If
        End Select
        ShowInternalForm(NewForm)
    End Sub

    Private Sub EditResourceContextButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditResourceContextButton.Click
        OpenResource(ResourcesList.SelectedNode)
    End Sub

    Private Sub DeleteResourceContextButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteResourceContextButton.Click
        If ResourcesList.SelectedNode.Parent.Index = ResourceType.Scene And Scenes.Count = 1 Then
            MsgError("You must have at least one scene.")
            Exit Sub
        End If
        If Not WarnYesNo("Are you sure that you want to delete '" + ResourcesList.SelectedNode.Text + "?") Then Exit Sub
        Select Case ResourcesList.SelectedNode.Parent.Index
            Case ResourceType.Image
                DeleteImage(ResourcesList.SelectedNode.Text)
            Case ResourceType.DObject
                DeleteObject(ResourcesList.SelectedNode.Text)
            Case ResourceType.Scene
                DeleteScene(ResourcesList.SelectedNode.Text)
            Case ResourceType.Sound
                DeleteSound(ResourcesList.SelectedNode.Text)
        End Select
    End Sub

    Private Sub Glosser_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Glosser.Paint

        Dim gBrush As LinearGradientBrush = New LinearGradientBrush(New Point(0, 26) _
                                              , New Point(0, Glosser.Height) _
                                              , Color.FromArgb(238, 238, 238) _
                                              , Color.White)
        e.Graphics.FillRectangle(gBrush, New Rectangle(New Point(0, 26), New Point(Glosser.Width, Glosser.Height)))

        e.Graphics.DrawLine(New Pen(Color.FromArgb(88, 103, 119)), New Point(0, 25), New Point(Glosser.Width, 25))
        e.Graphics.DrawLine(New Pen(Color.FromArgb(198, 216, 218)), New Point(0, 24), New Point(Glosser.Width, 24))
        e.Graphics.DrawLine(New Pen(Color.FromArgb(181, 190, 206)), New Point(0, Glosser.Height - 1), New Point(Glosser.Width, Glosser.Height - 1))
        e.Graphics.DrawLine(New Pen(Color.FromArgb(88, 103, 119)), New Point(0, 25), New Point(Glosser.Width, 25))

        'Dim gBrush As LinearGradientBrush = New LinearGradientBrush(New Point(0, 26) _
        '                              , New Point(0, Glosser.Height) _
        '                              , Color.FromArgb(238, 238, 238) _
        '                              , Color.White)
        'e.Graphics.FillRectangle(gBrush, New Rectangle(New Point(5, 26), New Point(Glosser.Width, Glosser.Height)))

        'e.Graphics.DrawLine(New Pen(Color.FromArgb(88, 103, 119)), New Point(5, 25), New Point(Glosser.Width, 25))
        'e.Graphics.DrawLine(New Pen(Color.FromArgb(198, 216, 218)), New Point(4, 24), New Point(Glosser.Width, 24))

        'e.Graphics.DrawLine(New Pen(Color.FromArgb(88, 103, 119)), New Point(5, 25), New Point(5, Glosser.Height - 1))
        'e.Graphics.DrawLine(New Pen(Color.FromArgb(198, 216, 218)), New Point(4, 24), New Point(4, Glosser.Height - 1))

        'e.Graphics.DrawLine(New Pen(Color.FromArgb(88, 103, 119)), New Point(0, Glosser.Height - 1), New Point(5, Glosser.Height - 1))
        'e.Graphics.DrawLine(New Pen(Color.FromArgb(198, 216, 218)), New Point(0, Glosser.Height - 2), New Point(4, Glosser.Height - 2))

        'e.Graphics.DrawLine(New Pen(Color.FromArgb(181, 190, 206)), New Point(6, Glosser.Height - 1), New Point(Glosser.Width, Glosser.Height - 1))
        'e.Graphics.DrawLine(New Pen(Color.FromArgb(88, 103, 119)), New Point(6, 25), New Point(Glosser.Width, 25))
    End Sub
End Class
