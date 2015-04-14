Imports System.IO
Imports System.Media

Public Class FSound

    Dim DataChanged As Boolean = False

    Dim Moi As Sound

    Sub SetMoi(ByVal Thing)
        Moi = DirectCast(Thing, Sound).CloneMe
    End Sub

    Dim P As SoundPlayer
    Dim S As MemoryStream

    Sub DoPlay()
        S = New MemoryStream(Moi.Data)
        P = New SoundPlayer(S)
        P.Play()
    End Sub

    Sub DoKill()
        P.Stop()
        P.Dispose()
    End Sub

    Private Sub FSound_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Icon = ImageToIcon(My.Resources.SoundIcon)
        BackColor = clsColors.CrucialColor
        For Each F As String In Directory.GetFiles(AppPath + "Resources/Sounds")
            Dim P As String = F
            P = P.Substring(P.LastIndexOf("\") + 1)
            P = P.Substring(0, P.LastIndexOf("."))
            SampleDropper.BackCombo.Items.Add(P)
        Next
        SexUpToolStrip(Me.MainToolStrip, False, True, Me)
        MaximumSize = Me.Size
        MinimumSize = Me.Size
        Text = Moi.Name
        NameTextBox.Text = Moi.Name
        P = New SoundPlayer
        WindowState = FormWindowState.Normal
        Parent.Invalidate()
    End Sub

    Private Sub DAcceptButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DAcceptButton.Click

        Dim NewName As String = NameTextBox.Text
        If Not Moi.Name = NewName Then
            If GUIResNameChecker(NewName) Then
                NameTextBox.Focus()
                Exit Sub
            End If
        End If
        DoKill()
        For Each X As TreeNode In MainForm.ResourcesList.Nodes(ResourceType.Sound).Nodes
            If X.Text = Moi.Name Then X.Text = NewName
        Next
        Dim R As UInt16 = 0
        Dim DidDoit As Boolean = False
        For P As UInt16 = 0 To Sounds.Count - 1
            If Sounds(P).Name = Moi.Name Then
                R = P
                DidDoit = True
                Exit For
            End If
        Next

        CType(Moi, Sound).Name = NewName
        If DidDoit Then
            Sounds(R) = Moi.CloneMe()
        Else
            ResourceError("save", ResourceType.Sound)
        End If

        Close()

    End Sub

    Private Sub DCancelButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DCancelButton.Click
        DoKill()
        Close()
    End Sub

    Private Sub DeleteButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteButton.Click
        If Not WarnYesNo("Are you sure that you want to delete '" + Moi.Name + "'?") Then Exit Sub
        DoKill()
        DeleteSound(Moi.Name)
    End Sub

    Private Sub PlayButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PlayButton.Click
        DoPlay()
    End Sub

    Private Sub LoadFromFileButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LoadFromFileButton.Click
        Dim Result As String = OpenFile(String.Empty, "Waveform Audio Files|*.wav")
        If Result.Length = 0 Then Exit Sub
        Moi.Data = File.ReadAllBytes(Result)
    End Sub

    Private Sub EditButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditButton.Click
        Dim SoundEditor As String = GetOption("SOUND_EDITOR")
        If Not File.Exists(SoundEditor) Then
            MsgWarn("There is no Sound Editor defined. See 'Options'.")
            Exit Sub
        End If
        Dim NF As String = TempDir + Moi.Name + ".wav"
        File.WriteAllBytes(NF, Moi.Data)
        System.Diagnostics.Process.Start(SoundEditor, """" + NF + """")
        If Not ShowResourceEditMessage(Moi.Name) = MsgBoxResult.Ok Then Exit Sub
        Moi.Data = File.ReadAllBytes(NF)
        IO.File.Delete(NF)
    End Sub

    Private Sub SaveToFileButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveToFileButton.Click
        Dim Result As String = SaveFile(String.Empty, "Waveform Audio Files|*.wav", If(NameTextBox.Text.Length > 1, NameTextBox.Text, Moi.Name) + ".wav")
        If Result.Length = 0 Then Exit Sub
        File.WriteAllBytes(Result, Moi.Data)
    End Sub

    Private Sub SampleDropper_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SampleDropper.SelectedIndexChanged
        Dim I As String = SampleDropper.Text
        If I.Length = 0 Then Exit Sub
        SampleDropper.BackCombo.SelectedIndex = -1
        Dim IP As String = AppPath + "Resources\Sounds\" + I + ".wav"
        Moi.Data = File.ReadAllBytes(IP)
        DoPlay()
    End Sub

End Class