Imports System.Drawing.Drawing2D
Imports System.IO

Public Class FImage

    Dim Moi As DImage

    Sub SetMoi(ByVal Thing As Object)
        Moi = DirectCast(Thing, DImage).CloneMe
    End Sub
    Public Sub UpdateImage(ByVal TI As Image)
        Moi.Data = TI
        Moi.FrameHeight = Moi.Data.Height
        FormaliseControls(True)
    End Sub
    Function GetName() As String
        Return Moi.Name
    End Function

    Function GenerateDisplay() As Bitmap
        Dim W As UInt16 = Moi.Data.Width
        Dim H As UInt16 = Moi.Data.Height
        Dim XLoop As Int16 = Math.Ceiling(W / 16)
        Dim YLoop As Int16 = Math.Ceiling(H / 16)
        Dim Returnable As New Bitmap(W, H)
        Dim GFX As Graphics = Graphics.FromImage(Returnable)
        For X = 0 To XLoop - 1
            For Y = 0 To YLoop - 1
                GFX.DrawImage(My.Resources.TranspBack, New Point(X * 16, Y * 16))
            Next
        Next
        GFX.DrawImage(Moi.Data, 0, 0)
        GFX.DrawRectangle(New Pen(Color.FromArgb(128, 0, 0, 0), 1), New Rectangle(0, 0, W - 1, DirectCast(Moi, DImage).FrameHeight - 1))
        GFX.Dispose()
        Return Returnable
    End Function

    Sub SortOutFrameHeight(ByRef TI As Bitmap)
        Dim NewVal As UInt16 = 0
        If CanDivide(TI.Height, Moi.FrameHeight) Then
            NewVal = Moi.FrameHeight
        Else
            If TI.Width <= TI.Height Then
                If CanDivide(TI.Height, TI.Width) Then
                    NewVal = TI.Width
                Else
                    NewVal = TI.Height
                End If
            Else
                NewVal = TI.Height
            End If
        End If
        Moi.FrameHeight = NewVal
    End Sub

    Public Sub EditMyImage()
        Dim ImageEditor As String = GetOption("IMAGE_EDITOR")
        If Not File.Exists(ImageEditor) Then
            MsgWarn("There is no Image Editor defined. See 'Options'.")
            Exit Sub
        End If
        Dim NF As String = TempDir + Moi.Name + ".png"
        Dim DW As UInt16 = Moi.Data.Width
        Dim DH As UInt16 = Moi.Data.Height
        Dim FH As UInt16 = Moi.FrameHeight
        If Convert.ToByte(GetOption("ALPHA_CAPABLE")) = 0 Then
            'Fill transparent pixels with pseudo-black
            Dim BlackBacker As New Bitmap(DW, DH)
            Dim BlackBackerGFX As Graphics = Graphics.FromImage(BlackBacker)
            BlackBackerGFX.Clear(Color.FromArgb(0, 1, 0))
            BlackBackerGFX.DrawImageUnscaled(DirectCast(Moi, DImage).Data, 0, 0)
            BlackBackerGFX.Dispose()
            BlackBacker = MakeBMPTransparent(BlackBacker, Color.FromArgb(0, 1, 0))
            Dim Backer As New Bitmap(DW, DH)
            Dim BackerGFX As Graphics = Graphics.FromImage(Backer)
            BackerGFX.Clear(Color.Magenta)
            BackerGFX.DrawImageUnscaled(BlackBacker, 0, 0)
            BackerGFX.Dispose()
            Backer.Save(NF, Imaging.ImageFormat.Png)
        Else
            Moi.Data.Clone().Save(NF, Imaging.ImageFormat.Png)
        End If
        System.Diagnostics.Process.Start(ImageEditor, """" + NF + """")
        If Not ShowResourceEditMessage(Moi.Name) = MsgBoxResult.Ok Then Exit Sub
        Dim TI As Image = PathToImage(NF)
        If Convert.ToByte(GetOption("ALPHA_CAPABLE")) = 0 Then TI = MakeBMPTransparent(TI, Color.Magenta)
        SortOutFrameHeight(TI)
        Moi.Data = TI
        FormaliseControls(True)
        IO.File.Delete(NF)
    End Sub

    Sub FormaliseControls(ByVal DoRefresh As Boolean)
        FrameHeightSelector.Value = Moi.FrameHeight
        FrameHeightSelector.Maximum = Moi.Data.Height
        FrameHeightSelector.Invalidate()
        If DoRefresh Then ImagePanel.BackgroundImage = GenerateDisplay()
    End Sub

    Private Sub FImage_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SexUpToolStrip(MainToolStrip, False, False)
        Icon = ImageToIcon(My.Resources.ImageIcon)
        BackColor = NiceBG
        For Each F As String In Directory.GetFiles(AppPath + "Resources/Images")
            Dim P As String = F
            P = P.Substring(P.LastIndexOf("\") + 1)
            P = P.Substring(0, P.LastIndexOf("."))
            SampleDropper.BackCombo.Items.Add(P)
        Next
        NameTextBox.Text = Moi.Name
        FormaliseControls(True)
        Text = NameTextBox.Text
    End Sub

    Public Sub DAcceptButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DAcceptButton.Click

        Dim CurName As String = DirectCast(Moi, DImage).Name
        Dim NewName As String = NameTextBox.Text

        If Not CurName = NewName Then
            If GUIResNameChecker(NewName) Then
                NameTextBox.Focus()
                Exit Sub
            End If
        End If

        If Not CanDivide(Moi.Data.Height, FrameHeightSelector.Value) Then
            MsgError("Frame Height must be a factor of the Image Height.")
            Exit Sub
        End If

        Dim R As UInt16 = 0
        For I As UInt16 = 0 To Images.Count - 1
            If Images(I).Name = CurName Then
                R = I
            End If
        Next

        If Objects.Count > 0 Then
            For F As UInt16 = 0 To Objects.Count - 1
                If Objects(F).ImageName = CurName Then Objects(F).ImageName = NewName
            Next
        End If

        If Scenes.Count > 0 Then
            For F As UInt16 = 0 To Scenes.Count - 1
                If Scenes(F).Background = CurName Then Scenes(F).Background = NewName
                If Scenes(F).Foreground = CurName Then Scenes(F).Foreground = NewName
            Next
        End If

        For Each T As Form In MainForm.MdiChildren
            If T.Name = "FScene" Then
                DirectCast(T, FScene).RenameImage(CurName, NewName)
                Dim DoRefresh As Boolean = False
                For Each D As FScene.SceneInstance In DirectCast(T, FScene).Instances
                    For Each G As DObject In Objects
                        If G.ImageName = CurName And G.Name = D.ObjectName Then DoRefresh = True
                    Next
                Next
                If DoRefresh Then DirectCast(T, FScene).DesignPanel.Invalidate()
            ElseIf T.Name = "FObject" Then
                DirectCast(T, FObject).RenameImage(CurName, NewName)
            End If
        Next

        For Each X As TreeNode In MainForm.ResourcesList.Nodes(ResourceType.Image).Nodes
            If X.Text = CurName Then X.Text = NewName
        Next

        Moi.Name = NewName
        Images(R) = Moi.CloneMe()

        For Each T As Form In MainForm.MdiChildren
            If T.Name = "FObject" Then
                DirectCast(T, FObject).SlackLoadPreview(NewName)
            End If
        Next

        Close()

    End Sub

    Private Sub DCancelButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DCancelButton.Click
        Close()
    End Sub

    Private Sub DeleteButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteButton.Click
        If Not WarnYesNo("Are you sure that you want to delete '" + DirectCast(Moi, DImage).Name + "'?") Then Exit Sub
        DeleteImage(Moi.Name)
    End Sub

    Private Sub LoadFromFileButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LoadFromFileButton.Click
        Dim Result As String = OpenFile(String.Empty, ImageFilter)
        If Result.Length = 0 Then Exit Sub
        Dim TI As Image = PathToImage(Result)
        If Convert.ToByte(GetOption("ALPHA_CAPABLE")) = 0 Then TI = MakeBMPTransparent(TI, Color.Magenta)
        SortOutFrameHeight(TI)
        Moi.Data = TI
        FormaliseControls(True)
    End Sub

    Private Sub EditButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditButton.Click
        EditMyImage()
    End Sub

    Private Sub SaveToFileButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveToFileButton.Click
        Dim Result As String = SaveFile(String.Empty, ImageFilter, If(NameTextBox.Text.Length > 1, NameTextBox.Text, Moi.Name) + ".png")
        If Result.Length = 0 Then Exit Sub
        Moi.Data.Save(Result)
    End Sub

    Private Sub SampleDropper_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SampleDropper.SelectedIndexChanged
        Dim I As String = SampleDropper.Text
        If I.Length = 0 Then Exit Sub
        SampleDropper.BackCombo.SelectedIndex = -1
        Dim IP As String = AppPath + "Resources\Images\" + I + ".png"
        Dim TI As Image = PathToImage(IP)
        Moi.Data = TI
        If I.ToLower.Contains("strip") Then
            SortOutFrameHeight(TI)
        Else
            Moi.FrameHeight = TI.Height
        End If
        FormaliseControls(True)
    End Sub

    Private Sub FrameHeightSelector_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FrameHeightSelector.ValueChanged
        Moi.FrameHeight = DirectCast(sender, SexyNumeric).Value
        ImagePanel.BackgroundImage = GenerateDisplay()
    End Sub

    Private Sub GenerateFontImageButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GenerateFontImageButton.Click
        FFont.User = Me
        ShowInternalForm(FFont)
        FFont.Show()
    End Sub

End Class