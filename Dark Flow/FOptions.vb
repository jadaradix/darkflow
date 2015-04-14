Imports System.Drawing.Drawing2D

Public Class FOptions

    Dim OldLanguage As String

    Function GetGoodPath(ByVal OptionName As String) As String
        Dim Reply As String = GetOption(OptionName)
        If IO.File.Exists(Reply) Then Return Reply
        Return String.Empty
    End Function

    Private Sub Options_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        GlobalGlass(Me, True, True)
        Icon = ImageToIcon(My.Resources.OptionsIcon)
        ReCenter(Me)
        Dim PF As String = My.Computer.FileSystem.SpecialDirectories.ProgramFiles

        'General
        ShrinkActionsListChecker.Checked = ThinList
        WelcomeOnBootChecker.Checked = (GetOption("WELCOME_ON_BOOT") = "1")
        AutoSave_Checker.Checked = (GetOption("AUTO_SAVE") = "1")
        'Browser
        BrowsersList.Items.Clear()
        For Each X In Browsers
            BrowsersList.Items.Add(X.Name)
        Next
        Dim Browser As String = GetOption("BROWSER")
        Dim DidSelect As Boolean = False
        For P As Byte = 0 To BrowsersList.Items.Count - 1
            If BrowsersList.Items(P) = Browser Then BrowsersList.SelectedIndex = P : DidSelect = True : Exit For
        Next
        If Not DidSelect Then BrowsersList.SelectedIndex = 0

        'Editors
        ImageEditorBox.Text = GetGoodPath("IMAGE_EDITOR")
        AlphaCapableChecker.Checked = (GetOption("ALPHA_CAPABLE") = "1")
        SoundEditorBox.Text = GetGoodPath("SOUND_EDITOR")

    End Sub

    Private Sub BrowsersList_DrawItem(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DrawItemEventArgs) Handles BrowsersList.DrawItem
        GDIRenderItem(Color.White, True, e, 10, New Point(e.Bounds.X + 36, e.Bounds.Y + 7), Browsers(e.Index).Name, Browsers(e.Index).Icon)
    End Sub

    Sub FocusEditorField(ByRef Focuser As Control)
        MainTabber.SelectedTab = EditorsTab
        Focuser.Focus()
    End Sub

    Private Sub DOKButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DOKButton.Click

        'Account

        'General
        Dim DoShrinkList As Boolean = ShrinkActionsListChecker.Checked
        SetOption("SHRINK_ACTIONS_LIST", If(DoShrinkList, "1", "0"))
        ThinList = DoShrinkList
        For Each P As Form In MainForm.MdiChildren
            If P.Name = "FObject" Then
                DirectCast(P, FObject).ReflectThinList(True)
            End If
        Next
        Dim DoWelcomeOnBoot As Boolean = WelcomeOnBootChecker.Checked
        SetOption("WELCOME_ON_BOOT", If(DoWelcomeOnBoot, "1", "0"))
        SetOption("AUTO_SAVE", If(AutoSave_Checker.Checked, "1", "0"))

        'Browser
        SetOption("BROWSER", BrowsersList.Items(BrowsersList.SelectedIndex))

        'Editors
        Dim ImageEditor As String = ImageEditorBox.Text
        Dim SoundEditor As String = SoundEditorBox.Text
        If ImageEditor.Length = 0 Then
            ImageEditor = Environment.GetFolderPath(Environment.SpecialFolder.System) + "\mspaint.exe"
        End If
        If Not IO.File.Exists(ImageEditor) Then
            MsgWarn("The Image Editor path must exist.")
            FocusEditorField(ImageEditorBox)
            Exit Sub
        End If
        If SoundEditor.Length > 0 Then
            If Not IO.File.Exists(SoundEditor) Then
                MsgWarn("The Sound Editor path must exist.")
                FocusEditorField(SoundEditorBox)
                Exit Sub
            End If
        End If
        SetOption("IMAGE_EDITOR", ImageEditor)
        SetOption("SOUND_EDITOR", SoundEditor)
        SetOption("ALPHA_CAPABLE", If(AlphaCapableChecker.Checked, "1", "0"))

        SaveOptions()
        Close()

    End Sub

    Private Sub ImageEditorButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImageEditorButton.Click
        Dim Response As String = OpenFile(String.Empty, "Executables|*.exe")
        If Response.Length = 0 Then Exit Sub
        ImageEditorBox.Text = Response
    End Sub

    Private Sub SoundEditorButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SoundEditorButton.Click
        Dim Response As String = OpenFile(String.Empty, "Executables|*.exe")
        If Response.Length = 0 Then Exit Sub
        SoundEditorBox.Text = Response
    End Sub

End Class