Public Class FScene

    Public DName As String
    Public DWidth As UInt16
    Public DHeight As UInt16
    Public ViewWidth As UInt16
    Public ViewHeight As UInt16
    Public ViewX As UInt16
    Public ViewY As UInt16
    Public BGRed As Byte
    Public BGGreen As Byte
    Public BGBlue As Byte
    Public Foreground As String
    Public Background As String

    Dim ShowGrid As Boolean = False
    Dim SnapToGrid As Boolean = False
    Dim SnapX As Byte = 32
    Dim SnapY As Byte = 32
    Dim TX As Int16 = 0
    Dim TY As Int16 = 0
    Dim TObj As String = String.Empty

    Dim FireEvents As Boolean = False

    Class SceneInstance
        Public ObjectName As String
        Public X As Int16
        Public Y As Int16
        Public Sub New(ByVal PObjectName As String, ByVal PX As Int16, ByVal PY As Int16)
            ObjectName = PObjectName
            X = PX
            Y = PY
        End Sub
    End Class

    Public Instances As New List(Of SceneInstance)
    Public ObjectToPlot As String = String.Empty

#Region "Object Functions"

    Public Sub AddObject(ByVal DName As String)
        ObjectDropper.BackCombo.Items.Add(DName)
    End Sub

    Public Sub RenameObject(ByVal OldName As String, ByVal NewName As String)

        If ObjectDropper.BackCombo.Items.Count > 0 Then
            For X As UInt16 = 0 To ObjectDropper.BackCombo.Items.Count - 1
                If ObjectDropper.BackCombo.Items(X) = OldName Then ObjectDropper.BackCombo.Items(X) = NewName : Exit For
            Next
        End If

        If Instances.Count > 0 Then
            For X As UInt16 = 0 To Instances.Count - 1
                If Instances(X).ObjectName = OldName Then Instances(X).ObjectName = NewName
            Next
        End If

    End Sub

    Public Sub RemoveObject(ByVal ObjectName As String)
        Dim TheIndex As Int16 = 0
        Dim DOn As Int16 = 0
        For Each X As String In ObjectDropper.BackCombo.Items
            If X = ObjectName Then TheIndex = DOn : Exit For
            DOn += 1
        Next
        ObjectDropper.BackCombo.Items.RemoveAt(TheIndex)
        If ObjectToPlot = ObjectName Then ObjectToPlot = String.Empty
    End Sub

    Sub PlotInstance(ByVal ObjectName As String, ByVal Screen As Boolean, ByVal X As Int16, ByVal Y As Int16)
        Dim ToAdd As New SceneInstance(ObjectName, X, Y)
        Instances.Add(ToAdd)
        DesignPanel.Invalidate()
    End Sub

    'Dim DelX As UInt16 = 0
    'Dim DelY As UInt16 = 0

    'Function InstanceFits(ByVal B As SceneInstance) As Boolean
    '    Dim DidFind As Boolean = False
    '    For Each P As DObject In Objects
    '        If P.Name = B.ObjectName Then
    '            DidFind = True
    '        End If
    '    Next
    '    If DidFind Then
    '        If DelX >= B.X And DelY >= B.Y And DelX < (B.X + B.Width) And DelY < (B.Y + B.Height) Then
    '            Return True
    '        End If
    '    Else
    '        Return False
    '    End If
    'End Function

    Sub DeleteInstance(ByVal X As Int16, ByVal Y As Int16)

        Dim ToBin As UInt16
        Dim CurrentDepth As UInt16 = 200
        If Instances.Count > 0 Then
            Dim FoundOne As Boolean = False
            For I As UInt16 = 0 To Instances.Count - 1
                Dim B As SceneInstance = Instances(I)
                If X >= B.X And Y >= B.Y And X < (B.X + GetObjectSize(B.ObjectName).Width) And Y < (B.Y + GetObjectSize(B.ObjectName).Height) Then
                    Dim LocalDepth As Byte = 0
                    For Each P As DObject In Objects
                        If P.Name = Instances(I).ObjectName Then
                            LocalDepth = P.Depth
                        End If
                    Next
                    If LocalDepth <= CurrentDepth Then
                        ToBin = I
                        CurrentDepth = LocalDepth
                    End If
                    FoundOne = True
                End If
            Next
            If FoundOne Then
                Instances.RemoveAt(ToBin)
                DesignPanel.Invalidate()
            End If
        End If
    End Sub

#End Region

#Region "Image Functions"

    Public Sub AddImage(ByVal DName As String)
        ForegroundDropper.BackCombo.Items.Add(DName)
        BackgroundDropper.BackCombo.Items.Add(DName)
    End Sub

    Public Sub RenameImage(ByVal OldName As String, ByVal NewName As String)
        Dim TheIndex As Int16 = 0
        Dim DOn As Int16 = 0
        For Each X As String In ForegroundDropper.BackCombo.Items
            If X = OldName Then TheIndex = DOn : Exit For
            DOn += 1
        Next
        ForegroundDropper.BackCombo.Items(TheIndex) = NewName
        BackgroundDropper.BackCombo.Items(TheIndex) = NewName
        If Foreground = OldName Then
            Foreground = NewName
            ForegroundDropper.Text = NewName
        End If
        If Background = OldName Then
            Background = NewName
            BackgroundDropper.Text = NewName
        End If
    End Sub

    Public Sub RemoveImage(ByVal ImageName As String)
        Dim TheIndex As Int16 = 0
        Dim DOn As Int16 = 0
        For Each X As String In ForegroundDropper.BackCombo.Items
            If X = ImageName Then TheIndex = DOn : Exit For
            DOn += 1
        Next
        ForegroundDropper.BackCombo.Items.RemoveAt(TheIndex)
        BackgroundDropper.BackCombo.Items.RemoveAt(TheIndex)
        Dim DoRefresh As Boolean = False
        If Foreground = ImageName Then
            Foreground = String.Empty
            ForegroundDropper.Text = "No Foreground"
            DoRefresh = True
        End If
        If Background = ImageName Then
            Background = String.Empty
            BackgroundDropper.Text = "No Background"
            DoRefresh = True
        End If
        If DoRefresh Then DesignPanel.Invalidate()
    End Sub

#End Region


    Private Sub Scene_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        BackgroundDropper.BackCombo.Items.Add("No Background")
        ForegroundDropper.BackCombo.Items.Add("No Foreground")
        MouseSnapLabel.Location = New Point(MouseSnapDescLabel.Location.X + MouseSnapDescLabel.Width + 4, MouseSnapLabel.Location.Y)
        MouseLabel.Location = New Point(MouseSnapDescLabel.Location.X + MouseSnapDescLabel.Width + 4, MouseLabel.Location.Y)
        Icon = ImageToIcon(My.Resources.SceneIcon)
        Text = DName
        SexUpToolStrip(MainToolStrip, False, True)
        RightClickMenu.Renderer = New metroMenuRenderer
        SnapToGrid = (GetOption("SNAP_OBJECTS") = "1")
        SnapToGridChecker.Checked = SnapToGrid
        ShowGrid = (GetOption("SHOW_GRID") = "1")
        ShowGridChecker.Checked = ShowGrid
        UseRightClickMenuChecker.Checked = (GetOption("RIGHT_CLICK") = "1")
        SnapX = Convert.ToByte(GetOption("SNAP_X"))
        SnapXTextBox.Text = SnapX
        SnapY = Convert.ToByte(GetOption("SNAP_Y"))
        SnapYTextBox.Text = SnapY
        NameTextBox.Text = DName
        SceneWidthSelector.Value = DWidth
        SceneWidthSelector.Maximum = 16383
        SceneHeightSelector.Value = DHeight
        SceneHeightSelector.Maximum = 16383
        ViewWidthSelector.Value = ViewWidth
        ViewWidthSelector.Maximum = DWidth
        ViewHeightSelector.Value = ViewHeight
        ViewHeightSelector.Maximum = DHeight
        ViewXSelector.Value = ViewX
        ViewXSelector.Maximum = DWidth
        ViewYSelector.Value = ViewY
        ViewYSelector.Maximum = DHeight
        BGColorDisplayer.BackColor = Color.FromArgb(BGRed, BGGreen, BGBlue)

        For Each P As DImage In Images
            ForegroundDropper.BackCombo.Items.Add(P.Name)
            BackgroundDropper.BackCombo.Items.Add(P.Name)
        Next
        For Each P As DObject In Objects
            ObjectDropper.BackCombo.Items.Add(P.Name)
        Next
        ForegroundDropper.Text = Foreground
        BackgroundDropper.Text = Background
        If Foreground.Length = 0 Then ForegroundDropper.Text = "No Foreground"
        If Background.Length = 0 Then BackgroundDropper.Text = "No Background"
        DesignPanel.AutoScrollMinSize = New Size(DWidth, DHeight)

        ObjectDropper.Text = DefaultObjectToPlot

        FireEvents = True

    End Sub

    Private Sub DesignPanel_MouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles DesignPanel.MouseClick
        Dim X As Int16 = e.Location.X
        Dim Y As Int16 = e.Location.Y
        X += (0 - DesignPanel.AutoScrollPosition.X)
        Y += (0 - DesignPanel.AutoScrollPosition.Y)
        If e.Button = Windows.Forms.MouseButtons.Right Then
            Dim FoundOne As Boolean = False
            If UseRightClickMenuChecker.Checked Then
                For Each P As SceneInstance In Instances
                    If P.X < X And (P.X + GetObjectSize(P.ObjectName).Width) > X And P.Y < Y And (P.Y + GetObjectSize(P.ObjectName).Height) > Y Then TObj = P.ObjectName : FoundOne = True
                Next
                TX = X
                TY = Y
                If FoundOne Then RightClickMenu.Show(DesignPanel, e.Location)
            Else
                DeleteInstance(X, Y)
            End If
            Exit Sub
        End If
        If ObjectToPlot.Length = 0 Then Exit Sub
        If SnapToGridChecker.Checked Then
            Dim NewX, NewY As Int16
            For i As Int16 = 1 To DWidth
                If Not CanDivide(i, SnapX) Then Continue For
                If X >= i Then NewX = i
            Next
            For i As Int16 = 1 To DHeight
                If Not CanDivide(i, SnapY) Then Continue For
                If Y >= i Then NewY = i
            Next
            PlotInstance(ObjectToPlot, True, NewX, NewY)
        Else
            PlotInstance(ObjectToPlot, True, X, Y)
        End If
        DesignPanel.Invalidate()
    End Sub

    Private Sub ObjectDropper_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ObjectDropper.SelectedIndexChanged
        ObjectToPlot = DirectCast(sender, ComboBox).Text
        OpenObjectButton.Enabled = IsAlreadyResource(ObjectToPlot)
        If Not FireEvents Then Exit Sub
        ObjectPreviewPanel.BackgroundImage = FObject.ObjectPreview(ObjectToPlot, ObjectPreviewPanel.Width - 2, String.Empty, False)
        DefaultObjectToPlot = ObjectToPlot
    End Sub

    Private Sub Snappers_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SnapXTextBox.DTextChanged, SnapYTextBox.DTextChanged
        Dim C = DirectCast(sender, TextBox)
        Dim TheValue As String = C.Text
        If Not IsNumeric(TheValue, Globalization.NumberStyles.Integer) Then Exit Sub
        If Convert.ToInt16(TheValue) = 0 Or Convert.ToInt16(TheValue) > 255 Then Exit Sub
        If C.Parent.Name = "SnapXTextBox" Then
            SnapX = Convert.ToByte(TheValue)
            SetOption("SNAP_X", TheValue)
        ElseIf C.Parent.Name = "SnapYTextBox" Then
            SnapY = Convert.ToByte(TheValue)
            SetOption("SNAP_Y", TheValue)
        End If
        If ShowGrid Then DesignPanel.Refresh()
    End Sub

    Private Sub DAcceptButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DAcceptButton.Click
        Dim NewName As String = NameTextBox.Text
        If Not DName = NewName Then
            If GUIResNameChecker(NewName) Then
                NameTextBox.Focus()
                Exit Sub
            End If
        End If
        If GetSetting("BootScene") = DName Then SetSetting("BootScene", NewName)
        For i = 0 To Scenes.Count - 1
            If Not Scenes(i).Name = DName Then Continue For
            Dim NS As New Scene(NewName, DWidth, DHeight, ViewWidth, ViewHeight, ViewX, ViewY, BGRed, BGGreen, BGBlue, Foreground, Background)
            For Each T As SceneInstance In Instances
                Dim NF As New Instance(T.ObjectName, T.X, T.Y)
                NS.GInstances.Add(NF)
            Next
            Scenes(i) = NS
        Next
        For Each X As TreeNode In MainForm.ResourcesList.Nodes(ResourceType.Scene).Nodes
            If X.Text = DName Then X.Text = NewName
        Next
        Close()
    End Sub

    Private Sub SizeSelectors_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ViewWidthSelector.ValueChanged, ViewHeightSelector.ValueChanged, SceneWidthSelector.ValueChanged, SceneHeightSelector.ValueChanged, ViewXSelector.ValueChanged, ViewYSelector.ValueChanged
        If Not FireEvents Then Exit Sub
        If ViewXSelector.Value > ViewWidthSelector.Value Then ViewXSelector.Value = ViewWidthSelector.Value
        If ViewYSelector.Value > ViewHeightSelector.Value Then ViewYSelector.Value = ViewHeightSelector.Value
        If ViewWidthSelector.Value > SceneWidthSelector.Value Then ViewWidthSelector.Value = SceneWidthSelector.Value
        If ViewHeightSelector.Value > SceneHeightSelector.Value Then ViewHeightSelector.Value = SceneHeightSelector.Value
        ViewXSelector.Maximum = ViewWidth
        ViewYSelector.Maximum = ViewHeight
        ViewWidthSelector.Maximum = DWidth
        ViewHeightSelector.Maximum = DHeight
        DWidth = SceneWidthSelector.Value
        DHeight = SceneHeightSelector.Value
        ViewWidth = ViewWidthSelector.Value
        ViewHeight = ViewHeightSelector.Value
        ViewX = ViewXSelector.Value
        ViewY = ViewYSelector.Value
        If DirectCast(sender, DarkFlow.SexyNumeric).Name.StartsWith("Scene") Then
            DesignPanel.AutoScrollMinSize = New Size(DWidth, DHeight)
            DesignPanel.Invalidate()
        End If
        If DirectCast(sender, DarkFlow.SexyNumeric).Name.StartsWith("View") Then
            DesignPanel.Invalidate()
        End If
    End Sub

    Private Sub DesignPanel_MouseMove(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles DesignPanel.MouseMove
        Dim X As Int16 = e.Location.X
        Dim Y As Int16 = e.Location.Y
        X += (0 - DirectCast(sender, Panel).AutoScrollPosition.X)
        Y += (0 - DirectCast(sender, Panel).AutoScrollPosition.Y)
        Dim NewX, NewY As Int16
        For i As Int16 = 1 To DWidth
            If Not CanDivide(i, SnapX) Then Continue For
            If X >= i Then NewX = i
        Next
        For i As Int16 = 1 To DHeight
            If Not CanDivide(i, SnapY) Then Continue For
            If Y >= i Then NewY = i
        Next
        MouseLabel.Text = X.ToString + ", " + Y.ToString
        MouseSnapLabel.Text = NewX.ToString + ", " + NewY.ToString
    End Sub

    Private Sub BGColorDisplayer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BGColorDisplayer.Click
        BGColorDisplayer.BackColor = SelectColor(BGColorDisplayer.BackColor)
        BGRed = BGColorDisplayer.BackColor.R
        BGGreen = BGColorDisplayer.BackColor.G
        BGBlue = BGColorDisplayer.BackColor.B
        DesignPanel.Invalidate()
    End Sub

    Private Sub BackgroundDropper_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ForegroundDropper.SelectedIndexChanged, BackgroundDropper.SelectedIndexChanged
        If Not FireEvents Then Exit Sub
        If Not ForegroundDropper.Text = "No Foreground" Then
            Foreground = ForegroundDropper.Text
        Else
            Foreground = String.Empty
        End If
        If Not BackgroundDropper.Text = "No Background" Then
            Background = BackgroundDropper.Text
        Else
            Background = String.Empty
        End If
        DesignPanel.Invalidate()
    End Sub

    Private Sub DCancelButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DCancelButton.Click
        Close()
    End Sub

    Structure DrawableInstance
        Public X As Int16
        Public Y As Int16
        Public ProcessedID As UInt16
        Public Depth As Byte
        Sub New(ByVal PX As Int16, ByVal PY As Int16, ByVal PProcessedID As UInt16, ByVal PDepth As Byte)
            X = PX
            Y = PY
            ProcessedID = PProcessedID
            Depth = PDepth
        End Sub
    End Structure

    Private Sub DesignPanel_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles DesignPanel.Paint

        Dim Buffer As New Bitmap(DWidth, DHeight)
        Dim BufferGFX As Graphics = Graphics.FromImage(Buffer)
        BufferGFX.Clear(Color.FromArgb(BGRed, BGGreen, BGBlue))

        'Background and Foreground discovery
        Dim BGI As New Bitmap(32, 32)
        For Each P As DImage In Images
            If P.Name = Background Then BGI = P.Data.Clone()
        Next
        Dim FGI As New Bitmap(32, 32)
        For Each P As DImage In Images
            If P.Name = Foreground Then FGI = P.Data.Clone()
        Next

        'Background
        Dim HR As UInt32 = Math.Ceiling(DWidth / BGI.Width)
        Dim HV As UInt32 = Math.Ceiling(DHeight / BGI.Height)
        For DX As UInt32 = 0 To HR - 1
            For DY As UInt32 = 0 To HV - 1
                BufferGFX.DrawImageUnscaled(BGI, (DX * BGI.Width), (DY * BGI.Height))
            Next
        Next

        'Instances
        If Instances.Count > 0 Then
            Dim ProcessedImages As New List(Of Bitmap)
            ProcessedImages.Add(My.Resources.NoImage.Clone()) 'No Image
            Dim OldDrawables As New List(Of DrawableInstance)
            Dim NewDrawables As New List(Of DrawableInstance)
            For Each T As SceneInstance In Instances
                Dim ObjectName As String = T.ObjectName
                Dim FoundImageName As String = String.Empty
                Dim FoundData As New Bitmap(32, 32)
                Dim FoundFrameHeight As UInt16 = 32
                Dim FoundDepth As UInt16 = 0
                Dim IsObject As Boolean = False
                For Each P As DObject In Objects
                    If P.Name = ObjectName Then
                        FoundImageName = P.ImageName
                        FoundDepth = P.Depth
                        IsObject = True
                    End If
                Next
                If Not IsObject Then Continue For
                For Each P As DImage In Images
                    If P.Name = FoundImageName Then
                        FoundData = P.Data.Clone()
                        FoundFrameHeight = P.FrameHeight
                    End If
                Next
                Dim DI As DrawableInstance
                If FoundImageName.Length > 0 Then
                    Dim TheBMP As New Bitmap(FoundData.Width, FoundFrameHeight)
                    Dim LGFX As Graphics = Graphics.FromImage(TheBMP)
                    LGFX.DrawImageUnscaled(FoundData, New Point(0, 0))
                    LGFX.Dispose()
                    ProcessedImages.Add(TheBMP.Clone())
                    DI = New DrawableInstance(T.X, T.Y, ProcessedImages.Count - 1, FoundDepth)
                Else
                    DI = New DrawableInstance(T.X, T.Y, 0, FoundDepth)
                End If
                OldDrawables.Add(DI)
            Next
            For I As Int16 = 200 To 0 Step -1
                For F As UInt16 = 0 To OldDrawables.Count - 1
                    If OldDrawables(F).Depth = I Then
                        NewDrawables.Add(New DrawableInstance(OldDrawables(F).X, OldDrawables(F).Y, OldDrawables(F).ProcessedID, I))
                    End If
                Next
            Next
            For Each F As DrawableInstance In NewDrawables
                BufferGFX.DrawImageUnscaled(ProcessedImages(F.ProcessedID), F.X, F.Y)
            Next
        End If

        'Foreground
        BufferGFX.DrawImageUnscaled(FGI, New Point(0, 0))
        If ShowGrid Then
            For i As Int16 = 0 To DWidth
                If Not i Mod SnapX = 0 Then Continue For
                BufferGFX.DrawLine(New Pen(Color.FromArgb(127, 255 - BGGreen, 255 - BGGreen, 255 - BGBlue)), i - 1, 0, i - 1, DHeight)
            Next
            For i As Int16 = 0 To DHeight
                If Not i Mod SnapY = 0 Then Continue For
                BufferGFX.DrawLine(New Pen(Color.FromArgb(127, 255 - BGRed, 255 - BGGreen, 255 - BGBlue)), 0, i - 1, DWidth, i - 1)
            Next
        End If

        'View Display
        BufferGFX.DrawRectangle(New Pen(Color.FromArgb(127, 255, 0, 0), 1), New Rectangle(ViewX - 1, ViewY - 1, ViewWidth, ViewHeight))
        BufferGFX.Dispose()

        'Buffer
        e.Graphics.DrawImageUnscaled(Buffer, New Point(DesignPanel.AutoScrollPosition.X, DesignPanel.AutoScrollPosition.Y))

    End Sub

    Private Sub UseRightClickMenuChecker_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UseRightClickMenuChecker.CheckedChanged
        If Not FireEvents Then Exit Sub
        SetOption("RIGHT_CLICK", If(DirectCast(sender, CheckBox).Checked, "1", "0"))
    End Sub

    Private Sub SnapToGridChecker_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SnapToGridChecker.CheckedChanged
        If Not FireEvents Then Exit Sub
        Dim Result As Boolean = DirectCast(sender, CheckBox).Checked
        SetOption("SNAP_OBJECTS", If(Result, "1", "0"))
        SnapToGrid = Result
    End Sub

    Private Sub ShowGridChecker_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ShowGridChecker.CheckedChanged
        If Not FireEvents Then Exit Sub
        Dim Result As Boolean = DirectCast(sender, CheckBox).Checked
        SetOption("SHOW_GRID", If(Result, "1", "0"))
        ShowGrid = Result
        DesignPanel.Invalidate()
    End Sub

    Private Sub FScene_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        SaveOptions()
    End Sub

    Private Sub DesignPanel_Scroll(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ScrollEventArgs) Handles DesignPanel.Scroll
        DirectCast(sender, Panel).Invalidate()
    End Sub

    Private Sub RDeleteButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RDeleteButton.Click
        DeleteInstance(TX, TY)
    End Sub

    Private Sub FScene_Resize(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Resize
        DesignPanel.Invalidate()
    End Sub

    Private Sub ObjectPreviewPanel_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles ObjectPreviewPanel.Paint
        e.Graphics.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias
        e.Graphics.DrawPath(New Pen(Color.FromArgb(255, 132, 132, 132), 1), CreateAllRoundedRect(New Rectangle(1, 1, ObjectPreviewPanel.Width - 2, ObjectPreviewPanel.Width - 2), 6))
    End Sub

    Private Sub DesignPanel_SizeChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DesignPanel.SizeChanged
        DesignPanel.Invalidate()
    End Sub

    Private Sub DeleteButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteButton.Click
        If Scenes.Count = 1 Then
            MsgError("You must have at least one scene.")
            Exit Sub
        End If
        If Not WarnYesNo("Are you sure that you want to delete '" + DName + "'?") Then Exit Sub
        DeleteScene(DName)
    End Sub

    Private Sub OpenObjectButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpenObjectButton.Click
        Dim CurObj As String = ObjectDropper.Text
        For Each X As TreeNode In MainForm.ResourcesList.Nodes(ResourceType.DObject).Nodes
            If X.Text = CurObj Then MainForm.OpenResource(X) : Exit For
        Next
    End Sub

    Private Sub ROpenObjectButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ROpenObjectButton.Click
        For Each X As TreeNode In MainForm.ResourcesList.Nodes(ResourceType.DObject).Nodes
            If X.Text = TObj Then MainForm.OpenResource(X) : Exit For
        Next
    End Sub

    Private Sub RightClickMenu_Opening(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles RightClickMenu.Opening
        ROpenObjectButton.Text = "Open '" + TObj + "'"
    End Sub
    '  Private Sub tFormClosed(sender As System.Object, e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
    '      Moi.WinLoc = Me.Location
    '      Moi.WinSize = Me.Size
    '      Moi.WinState = Me.WindowState
    '  End Sub
End Class