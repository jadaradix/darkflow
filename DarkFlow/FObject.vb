Imports System.Drawing.Drawing2D
Imports System.IO

Public Class FObject

    Dim Moi As DObject

    Sub SetMoi(ByVal Thing)
        Moi = DirectCast(Thing, DObject).CloneMe
    End Sub

#Region "Global Declarations"

    Dim FireEvents As Boolean = True

    Dim DragFromBottom As Boolean
    Dim DragInternal As Boolean
    Dim DraggingInternal As Int16
    Dim DraggingFromBottom As Panel
    Dim MouseInBox As Boolean = False

    Public Actions As New List(Of String)
    Public ActionImages As New List(Of Bitmap)
    Public ActionArguments As New List(Of String)
    Public ActionDisplays As New List(Of String)
    Public ActionAppliesTos As New List(Of String)

    Dim CurrentIndents As New List(Of SByte)

#End Region

#Region "Image Functions"

    Public Sub AddImage(ByVal DName As String)
        ImageDropper.BackCombo.Items.Add(DName)
    End Sub

    Public Sub RenameImage(ByVal OldName As String, ByVal NewName As String)
        Dim TheIndex As Int16 = 0
        Dim DOn As Int16 = 0
        For Each X As String In ImageDropper.BackCombo.Items
            If X = OldName Then TheIndex = DOn : Exit For
            DOn += 1
        Next
        ImageDropper.BackCombo.Items(TheIndex) = NewName
        If Moi.ImageName = OldName Then
            Moi.ImageName = NewName
            ImageDropper.Text = NewName
        End If
    End Sub

    Public Sub RemoveImage(ByVal DImageName As String)
        Dim TheIndex As Int16 = 0
        Dim DOn As Int16 = 0
        For Each X As String In ImageDropper.BackCombo.Items
            If X = DImageName Then TheIndex = DOn : Exit For
            DOn += 1
        Next
        ImageDropper.BackCombo.Items.RemoveAt(TheIndex)
        If Moi.ImageName = DImageName Then
            Moi.ImageName = String.Empty
            ImageDropper.Text = String.Empty
        End If
    End Sub

    Private Sub OpenImageButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpenImageButton.Click
        If ImageDropper.Text.Length = 0 Then Exit Sub
        Dim Exists As Boolean = False
        For Each P As DImage In Images
            If P.Name = ImageDropper.Text Then Exists = True
        Next
        If Not Exists Then Exit Sub
        For Each P As TreeNode In MainForm.ResourcesList.Nodes(ResourceType.Image).Nodes
            If P.Text = ImageDropper.Text Then MainForm.ResourcesList_NodeMouseDoubleClick(P, New TreeNodeMouseClickEventArgs(P, Windows.Forms.MouseButtons.Left, 1, 0, 0))
        Next
    End Sub

    Private Sub EditImageButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditImageButton.Click
        If ImageDropper.Text.Length = 0 Then Exit Sub
        Dim Exists As Boolean = False
        For Each P As DImage In Images
            If P.Name = ImageDropper.Text Then Exists = True
        Next
        If Not Exists Then Exit Sub
        For Each P As TreeNode In MainForm.ResourcesList.Nodes(ResourceType.Image).Nodes
            If P.Text = ImageDropper.Text Then
                MainForm.ResourcesList_NodeMouseDoubleClick(P, New TreeNodeMouseClickEventArgs(P, Windows.Forms.MouseButtons.Left, 1, 0, 0))
            End If
        Next
        For Each T As Form In MainForm.MdiChildren
            If Not T.Name = "FImage" Then Continue For
            If Not DirectCast(T, FImage).GetName() = ImageDropper.Text Then Continue For
            DirectCast(T, FImage).EditMyImage()
            DirectCast(T, FImage).DAcceptButton_Click(DirectCast(T, FImage).DAcceptButton, New EventArgs)
        Next
    End Sub

    Private Sub ImageDropper_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImageDropper.SelectedIndexChanged
        If Not FireEvents Then Exit Sub
        If Not DirectCast(sender, ComboBox).Text = "No Image" Then
            Moi.ImageName = DirectCast(sender, ComboBox).Text
        Else
            Moi.ImageName = String.Empty
        End If
        LoadPreview()
    End Sub

#End Region

#Region "External Functions"

    Function ObjectPreview(ByVal ObjectName As String, ByVal SquareSize As Byte, ByVal OptImageName As String, ByVal UseExtra As Boolean) As Image
        Dim XImage As String = String.Empty
        If Not UseExtra Then
            For Each P As DObject In Objects
                If P.Name = ObjectName Then XImage = P.ImageName
            Next
        Else
            XImage = OptImageName
        End If
        Dim Data As New Bitmap(SquareSize, SquareSize)

        Dim DidDraw As Boolean = False
        Dim XHeight As Integer = 0
        For Each P As DImage In Images
            If P.Name = XImage Then Data = P.Data : DidDraw = True : XHeight = P.FrameHeight
        Next
        If Not DidDraw Then
            Dim GDI As Graphics = Graphics.FromImage(Data)
            GDI.DrawImageUnscaled(My.Resources.NoImage, (SquareSize / 2) - 16, (SquareSize / 2) - 16)
        End If

        Dim Returnable As New Bitmap(SquareSize, SquareSize)
        Dim RGFX As Graphics = Graphics.FromImage(Returnable)

        RGFX.Clear(Color.Transparent)
        If Data.Width > SquareSize Or XHeight > SquareSize Then
            If Data.Width >= XHeight Then
                Dim SF As Double = SquareSize / Data.Width
                Dim NH As Double = XHeight * SF
                RGFX.DrawImage(Data, New Rectangle(0, (SquareSize / 2) - ((XHeight * SF) / 2), SquareSize, NH))
            Else
                Dim SF As Double = SquareSize / XHeight
                Dim NW As Double = Data.Width * SF
                RGFX.DrawImage(Data, New Rectangle((SquareSize / 2) - (NW / 2), 0, NW, SquareSize * (Data.Height / XHeight)))
            End If
        Else
            RGFX.DrawImageUnscaledAndClipped(Data, New Rectangle((SquareSize / 2) - (Data.Width / 2), (SquareSize / 2) - (XHeight / 2), Data.Width, XHeight))
        End If
        RGFX.Dispose()
        Return Returnable
    End Function

    Sub SlackLoadPreview(ByVal NameInQuestion As String)
        If Moi.ImageName = NameInQuestion Then LoadPreview()
    End Sub

    Public Sub LoadPreview()
        ImagePreviewPanel.BackgroundImage = ObjectPreview(Moi.Name, ImagePreviewPanel.Width - 2, Moi.ImageName, True)
    End Sub

    Sub RenameInput(ByVal OldName As String, ByVal NewName As String)
        Dim DoRefresh As Boolean = False
        For Each I As DEvent In Moi.Events
            If I.EventType = "Input" And I.EventData = OldName Then
                I.EventData = NewName
                DoRefresh = True
            End If
        Next
        If DoRefresh Then EventsList.Invalidate()
    End Sub

    Sub LDeleteObject(ByVal DName As String)
        Dim I As UInt16 = 0
        Dim DoRefresh As Boolean = False
        For Each T As DEvent In Moi.Events
            If T.EventData.Length = 0 Then Continue For
            If T.EventType = "Collision" And T.EventData = DName Then
                T.EventData = "<Unknown>"
                EventsList.Items(I) = T.EventType + ", " + T.EventData
                DoRefresh = True
            End If
            I += 1
        Next
        If DoRefresh Then EventsList.Invalidate()
    End Sub

    Sub ReflectThinList(ByVal ReselectEvent As Boolean)
        Dim Olden As Byte = ActionsList.ItemHeight
        If ThinList Then
            ActionsList.ItemHeight = 24
        Else
            ActionsList.ItemHeight = 36
        End If
        If Not Olden = ActionsList.ItemHeight Then ActionsList.Refresh()
        If ReselectEvent And Moi.Events.Count > 0 Then
            EventsList_SelectedIndexChanged(New Object, New System.EventArgs)
        End If
    End Sub

#End Region

#Region "Action Functions"

    Public Sub PopulateActionsTabControl(ByRef RAppliesTo As TabControl)
        Dim BackupIndex As Byte = 100
        Try
            BackupIndex = RAppliesTo.SelectedIndex
        Catch : End Try
        For Each X As TabPage In RAppliesTo.TabPages
            Try
                If X.Controls.Count > 0 Then
                    For Y = 0 To X.Controls.Count - 1
                        RemoveHandler X.Controls(Y).MouseDown, AddressOf ActionMouseDown
                        RemoveHandler X.Controls(Y).MouseEnter, AddressOf ActionMouseEnter
                        RemoveHandler X.Controls(Y).MouseUp, AddressOf ActionMouseUp
                        X.Controls.RemoveAt(Y)
                    Next
                End If
            Catch : End Try
            RAppliesTo.TabPages.Remove(X)
        Next
        RAppliesTo.TabPages.Clear()
        For X As Byte = 0 To ActionCategories.Count - 1
            Dim CatName As String = ActionCategories(X)
            Dim Y As New TabPage
            Y.Text = CatName
            Y.Name = CatName + "TabPage"

            Dim Scroller As New ScrollableControl
            Scroller.Dock = DockStyle.Fill
            Scroller.BackColor = Color.White
            Scroller.AutoScroll = True


            Y.Controls.Add(Scroller)

            Dim LocalActions As New List(Of String)
            For Each Z As DAction In DActions
                If Not Z.ShowMe Then Continue For
                If Not Z.Category = CatName Then Continue For
                LocalActions.Add(Z.Name)
            Next
            Dim DOn As Int16 = 0
            Dim XOn As Int16 = 0
            Dim YOn As Int16 = 0
            Dim MW As UInt16 = 164
            For Each Z As String In LocalActions
                Dim NewPanel As New DoubleBufferPanel
                With NewPanel
                    .Size = New Size(MW, 32)
                    .Tag = Z
                    .Name = Z.Replace(" ", "_") + "ActionPanel"
                    .Location = New Point(10 + (XOn * MW) + (XOn * 10), 10 + (YOn * 32) + (YOn * 10))
                    'MsgError(Z + " at " + NewPanel.Location.ToString)
                    .BackgroundImageLayout = ImageLayout.None
                    .BackgroundImage = ActionGetIcon(Z, True)
                End With
                Scroller.Controls.Add(NewPanel)
                'AddHandler NewPanel.Click, AddressOf ActionPanelClicked
                AddHandler NewPanel.MouseDown, AddressOf ActionMouseDown
                AddHandler NewPanel.MouseEnter, AddressOf ActionMouseEnter
                AddHandler NewPanel.MouseUp, AddressOf ActionMouseUp
                If YOn = 2 Then
                    XOn += 1 : YOn = 0
                Else
                    YOn += 1
                End If
                DOn += 1
            Next
            RAppliesTo.TabPages.Add(Y)
        Next
        If Not BackupIndex = 100 Then RAppliesTo.SelectedIndex = BackupIndex
    End Sub

    Sub GenerateIndentIndices()
        CurrentIndents.Clear()
        If Actions.Count = 0 Then Exit Sub
        Dim RunningIndent As Byte = 0
        For X As Int16 = 0 To Actions.Count - 1
            Dim ActionName As String = Actions(X)
            MatchFindName = ActionName
            Dim TheAct As DAction = DActions.Find(AddressOf MatchAction)
            If TheAct.Indent Then RunningIndent += 1
            CurrentIndents.Add(RunningIndent)
            If RunningIndent > 0 Then
                If TheAct.Dedent Then RunningIndent -= 1
            End If
        Next
    End Sub

    Sub RepopulateLibrary()
        PopulateActionsTabControl(ActionsToAddTabControl)
    End Sub

    Sub EditAction()
        If ActionsList.SelectedIndices.Count = 0 Then Exit Sub
        If ActionsList.SelectedIndices.Count > 1 Then
            MsgWarn("You may only edit one Action at once.")
            Exit Sub
        End If
        Dim EditingIndex As Int16 = ActionsList.SelectedIndices(0)
        With FAction
            .ArgumentString = ActionArguments(EditingIndex)
            .ActionName = Actions(EditingIndex)
            .AppliesTo = ActionAppliesTos(EditingIndex)
            .ShowDialog()
            If Not .UseData Then Exit Sub
            ActionAppliesTos.Item(EditingIndex) = .AppliesTo
            ActionArguments.Item(EditingIndex) = .ArgumentString
            ActionDisplays.Item(EditingIndex) = ActionEquateDisplay(.ActionName, .ArgumentString, .AppliesTo)
        End With
        BrapFix(EditingIndex)
        ActionsList.Invalidate()
    End Sub

    Sub BrapFix(ByVal RowID As UInt16)
        Moi.Events(EventsList.SelectedIndex).Actions(RowID) = GenerateActionLine(Actions(RowID), ActionArguments(RowID), ActionAppliesTos(RowID))
    End Sub

    Sub BrapAllDataBack()
        Moi.Events(EventsList.SelectedIndex).Actions.Clear()
        If Actions.Count > 0 Then
            For I As UInt16 = 0 To Actions.Count - 1
                Moi.Events(EventsList.SelectedIndex).Actions.Add(GenerateActionLine(Actions(I), ActionArguments(I), ActionAppliesTos(I)))
            Next
        End If
    End Sub

    Function ShouldAllowDialog(ByVal ActionName As String) As Boolean
        MatchFindName = ActionName
        Dim TheAct As DAction = DActions.Find(AddressOf MatchAction)
        If TheAct.Arguments.Count = 0 And TheAct.NoApplies Then Return False
        Return True
    End Function

    Sub ActionMouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        DragFromBottom = True
        DraggingFromBottom = sender
        Cursor = Cursors.NoMove2D
    End Sub

    Sub ActionMouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim ActionName As String = DirectCast(sender, Panel).Tag
        ActionNameLabel.Text = ActionName
        ArgumentsListLabel.Text = String.Empty
        Dim ArgumentCount As Byte = 0
        MatchFindName = ActionName
        For Each X As DArgument In DActions.Find(AddressOf MatchAction).Arguments
            ArgumentsListLabel.Text += X.Name + vbCrLf
            ArgumentCount += 1
        Next
        'If ArgumentCount = 0 Then ArgumentsListLabel.Text = "<No Arguments>"
        If ArgumentCount = 0 Then ArgumentsListLabel.Text = String.Empty
    End Sub

    Sub ActionMouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        Cursor = Cursors.Default
        Dim ActionName As String = DirectCast(DraggingFromBottom, Panel).Tag
        If EventsList.SelectedIndices.Count = 0 Then
            MsgWarn("You must add an Event, to which to add Actions.")
            Exit Sub
        End If
        If Not DragFromBottom Then Exit Sub
        'MsgError(Location.X.ToString)
        'MsgError(Location.Y.ToString)
        'Dim MDIID As Byte = 10
        'Dim DOn As Byte = 0
        'MsgError(ObjectName)
        'For Each X As Form In MainForm.MdiChildren
        '    If X.Text = ObjectName Then MDIID = DOn
        '    DOn += 1
        'Next
        'MsgError(MDIID.ToString)
        'If Not ActionsList.PointToClient(Cursor.Position).X > 0 Then Exit Sub
        'MsgError(Cursor.Position.X.ToString)
        'MsgError(Me.PointToScreen(ActionsList.Location).X.ToString)
        Dim TheX As Int16 = ActionsList.PointToClient(Cursor.Position).X ' - Location.X
        Dim TheY As Int16 = ActionsList.PointToClient(Cursor.Position).Y ' - Location.Y
        If TheX < 0 Then Exit Sub
        If TheX > ActionsList.Width Then Exit Sub
        If TheY < 0 Then Exit Sub
        If TheY > ActionsList.Height Then Exit Sub
        MatchFindName = ActionName
        Dim TheAct As DAction = DActions.Find(AddressOf MatchAction)
        Dim JustAdd As Boolean = Not (ActionsList.SelectedIndices.Count = 1)
        Dim Position As Int16 = ActionsList.SelectedIndex + 1
        If TheAct.NoApplies And TheAct.Arguments.Count = 0 Then
            If JustAdd Then
                AddAction(ActionName, String.Empty, "this", True, True, False, 0, True)
                ActionsList.SelectedItems.Clear()
                ActionsList.SelectedIndex = ActionsList.Items.Count - 1
            Else
                AddAction(ActionName, String.Empty, "this", True, True, True, Position, True)
                ActionsList.SelectedItems.Clear()
                ActionsList.SelectedIndex = Position
            End If
            DragFromBottom = False
            Exit Sub
        End If
        FAction.ActionName = ActionName
        FAction.AppliesTo = "this"
        FAction.ArgumentString = String.Empty
        If TheAct.Arguments.Count > 1 Then
            Dim MyShizzle As String = String.Empty
            For X As Byte = 0 To TheAct.Arguments.Count - 2
                MyShizzle += CS
            Next
            FAction.ArgumentString = MyShizzle
        End If
        FAction.AppliesToGroupBox.Enabled = True
        If TheAct.NoApplies Then
            FAction.AppliesToGroupBox.Enabled = False
        End If
        With FAction
            .ParentPoint = ActionsList.PointToScreen(New Point(0, 0))
            .ParentWidth = ActionsList.Width
            .ParentHeight = ActionsList.Height
            .ShowDialog()
            If Not .UseData Then Cursor = Cursors.Default : Exit Sub
        End With
        If JustAdd Then
            AddAction(ActionName, FAction.ArgumentString, FAction.AppliesTo, True, True, False, 0, True)
        Else
            AddAction(ActionName, FAction.ArgumentString, FAction.AppliesTo, True, True, True, Position, True)
        End If
        ActionsList.SelectedItems.Clear()
        ActionsList.SelectedIndex = If(JustAdd, ActionsList.Items.Count - 1, Position)
        DragFromBottom = False
    End Sub

    Dim MustRefresh As Boolean = False

    Private Sub ActionsList_MouseMove(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ActionsList.MouseMove
        MustRefresh = False
        If Not ActionsList.SelectionMode = SelectionMode.One Then Exit Sub
        If Not DragInternal Then Exit Sub
        If DraggingInternal = ActionsList.SelectedIndex Then Exit Sub
        If DraggingInternal > ActionsList.SelectedIndex Then
            Dim TextForCurrent As String = Actions(DraggingInternal - 1)
            Dim TextForAbove As String = Actions(DraggingInternal)
            Actions(DraggingInternal) = TextForCurrent
            Actions(DraggingInternal - 1) = TextForAbove
            Dim ImageForCurrent As Bitmap = ActionImages(DraggingInternal - 1)
            Dim ImageForAbove As Bitmap = ActionImages(DraggingInternal)
            ActionImages(DraggingInternal) = ImageForCurrent
            ActionImages(DraggingInternal - 1) = ImageForAbove
            Dim ArgumentForCurrent As String = ActionArguments(DraggingInternal - 1)
            Dim ArgumentForAbove As String = ActionArguments(DraggingInternal)
            ActionArguments(DraggingInternal) = ArgumentForCurrent
            ActionArguments(DraggingInternal - 1) = ArgumentForAbove
            Dim DisplayForCurrent As String = ActionDisplays(DraggingInternal - 1)
            Dim DisplayForAbove As String = ActionDisplays(DraggingInternal)
            ActionDisplays(DraggingInternal) = DisplayForCurrent
            ActionDisplays(DraggingInternal - 1) = DisplayForAbove
            Dim ApplyForCurrent As String = ActionAppliesTos(DraggingInternal - 1)
            Dim ApplyForAbove As String = ActionAppliesTos(DraggingInternal)
            ActionAppliesTos(DraggingInternal) = ApplyForCurrent
            ActionAppliesTos(DraggingInternal - 1) = ApplyForAbove
            DraggingInternal -= 1
        Else
            Dim TextForCurrent As String = Actions(DraggingInternal + 1)
            Dim TextForAbove As String = Actions(DraggingInternal)
            Actions(DraggingInternal) = TextForCurrent
            Actions(DraggingInternal + 1) = TextForAbove
            Dim ImageForCurrent As Bitmap = ActionImages(DraggingInternal + 1)
            Dim ImageForAbove As Bitmap = ActionImages(DraggingInternal)
            ActionImages(DraggingInternal) = ImageForCurrent
            ActionImages(DraggingInternal + 1) = ImageForAbove
            Dim ArgumentForCurrent As String = ActionArguments(DraggingInternal + 1)
            Dim ArgumentForAbove As String = ActionArguments(DraggingInternal)
            ActionArguments(DraggingInternal) = ArgumentForCurrent
            ActionArguments(DraggingInternal + 1) = ArgumentForAbove
            Dim DisplayForCurrent As String = ActionDisplays(DraggingInternal + 1)
            Dim DisplayForAbove As String = ActionDisplays(DraggingInternal)
            ActionDisplays(DraggingInternal) = DisplayForCurrent
            ActionDisplays(DraggingInternal + 1) = DisplayForAbove
            Dim ApplyForCurrent As String = ActionAppliesTos(DraggingInternal + 1)
            Dim ApplyForAbove As String = ActionAppliesTos(DraggingInternal)
            ActionAppliesTos(DraggingInternal) = ApplyForCurrent
            ActionAppliesTos(DraggingInternal + 1) = ApplyForAbove
            DraggingInternal += 1
        End If
        BrapAllDataBack()
        MustRefresh = True
        ActionsList.Invalidate()
        GenerateIndentIndices()
    End Sub

    Private Sub ActionsList_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ActionsList.MouseUp
        If Not ActionsList.SelectionMode = SelectionMode.One Then Exit Sub
        DragInternal = False
        If MustRefresh Then
            GenerateIndentIndices()
            ActionsList.Invalidate()
        End If
        MustRefresh = False
        Cursor = Cursors.Default
    End Sub

    Private Sub ActionsList_MouseDoubleClick() Handles ActionsList.MouseDoubleClick, EditValuesRightClickButton.Click
        If ActionsList.SelectedIndices.Count = 0 Then Exit Sub
        If ShouldAllowDialog(Actions(ActionsList.SelectedIndices(0))) Then EditAction()
    End Sub

    Private Sub ActionsList_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ActionsList.MouseDown
        If Not ActionsList.SelectionMode = SelectionMode.One Then Exit Sub
        DragInternal = True
        DraggingInternal = ActionsList.SelectedIndex
        Cursor = Cursors.NoMove2D
    End Sub

    Private Sub SelectOneButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SelectOneButton.Click, SelectOneRightClickButton.Click
        ActionsList.SelectionMode = SelectionMode.One
        SelectMultiple = False
    End Sub

    Private Sub SelectManyButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SelectManyButton.Click, SelectManyRightClickButton.Click
        ActionsList.SelectionMode = SelectionMode.MultiExtended
        SelectMultiple = True
    End Sub

    Private Sub SelectAllButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SelectAllButton.Click
        ActionsList.SelectionMode = SelectionMode.MultiSimple
        ActionsList.SelectedIndices.Clear()
        For I As UInt16 = 0 To ActionsList.Items.Count - 1
            ActionsList.SelectedIndices.Add(I)
        Next
    End Sub

#End Region

#Region "GDI and the Likes"

    Private Sub ActionsList_DrawItem(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DrawItemEventArgs) Handles ActionsList.DrawItem

        Dim DForeColor As Color = Color.White
        Dim DBackColor As Color = Color.Black

        e.Graphics.TextRenderingHint = Drawing.Text.TextRenderingHint.ClearTypeGridFit

        If e.Index < 0 Then Exit Sub
        Dim IsSelected As Boolean = False
        If (e.State And DrawItemState.Selected) = DrawItemState.Selected Then IsSelected = True

        Dim MyX As Int16 = (CurrentIndents(e.Index) * If(ThinList, 16, 24))
        Dim MyY As Int16 = e.Bounds.Y
        e.Graphics.FillRectangle(Brushes.White, New Rectangle(0, MyY, e.Bounds.Width, e.Bounds.Height))

        If IsSelected Then e.Graphics.DrawImage(My.Resources.BarBG, New Rectangle(0, MyY, e.Bounds.Width, e.Bounds.Height))
        Dim ThingString As String = ActionAppliesTos(e.Index)
        Dim ArgString As String = String.Empty
        Dim NiceArgs As String = ArgumentsMakeAttractive(ActionArguments(e.Index), True)
        If ThinList Then
            e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic
            e.Graphics.DrawImage(ActionImages(e.Index), New Rectangle(MyX + 2, MyY + 2, 20, 20))
            If IsSelected Then
                e.Graphics.DrawString(ActionDisplays(e.Index), Font, New SolidBrush(DBackColor), MyX + 20 + 3, MyY + 3 + 1)
                e.Graphics.DrawString(ActionDisplays(e.Index), Font, New SolidBrush(DForeColor), MyX + 20 + 3, MyY + 3)
            Else
                e.Graphics.DrawString(ActionDisplays(e.Index), Font, Brushes.Black, MyX + 20 + 3, MyY + 3)
            End If
            Exit Sub
        End If

        e.Graphics.DrawImageUnscaled(ActionImages(e.Index), New Point(MyX + 2, MyY + 2))

        If NiceArgs.Length > 0 Then
            If ThingString = "this" Then
                If Actions(e.Index) = "Execute Code" Then
                    ArgString = NiceArgs
                Else
                    ArgString = "Arguments of " + NiceArgs
                End If
            ElseIf IsObject(ThingString) Then
                If Actions(e.Index) = "Execute Code" Then
                    ArgString = "Applies to instances of " + ThingString + ": " + NiceArgs
                Else
                    ArgString = "Applies to instances of " + ThingString + " with Args. " + NiceArgs
                End If
            Else
                If Actions(e.Index) = "Execute Code" Then
                    ArgString = "Applies to instance IDs " + ThingString + ": " + NiceArgs
                Else
                    ArgString = "Applies to instance IDs " + ThingString + " with Args. " + NiceArgs
                End If
            End If
        End If

        If IsSelected Then

            If NiceArgs.Length > 0 Then
                e.Graphics.DrawString(ActionDisplays(e.Index), Font, New SolidBrush(DBackColor), MyX + 36, MyY + 4 + 1)
                e.Graphics.DrawString(ActionDisplays(e.Index), Font, New SolidBrush(DForeColor), MyX + 36, MyY + 4)

                e.Graphics.DrawString(ArgString, New Font(Font.Name, 7), New SolidBrush(DBackColor), MyX + 36, MyY + 18 + 1)
                e.Graphics.DrawString(ArgString, New Font(Font.Name, 7), Brushes.LightGray, MyX + 36, MyY + 18)
            Else
                e.Graphics.DrawString(ActionDisplays(e.Index), Font, New SolidBrush(DBackColor), MyX + 36, MyY + 8 + 1)
                e.Graphics.DrawString(ActionDisplays(e.Index), Font, New SolidBrush(DForeColor), MyX + 36, MyY + 8)
            End If

            ''Top Left
            'e.Graphics.DrawImageUnscaled(My.Resources.Corners, New Point(-7, e.Bounds.Y - 7))
            ''Bottom Left
            'e.Graphics.DrawImageUnscaled(My.Resources.Corners, New Point(-7, e.Bounds.Y + 36 - 6))
            ''Top Right
            'e.Graphics.DrawImageUnscaled(My.Resources.Corners, New Point(e.Bounds.Width - 7, MyY - 7))
            ''Bottom Right
            'e.Graphics.DrawImageUnscaled(My.Resources.Corners, New Point(e.Bounds.Width - 7, MyY + 36 - 6))

        Else

            If NiceArgs.Length > 0 Then

                e.Graphics.DrawString(ActionDisplays(e.Index), Font, Brushes.Black, MyX + 36, MyY + 4)
                e.Graphics.DrawString(ArgString, New Font(Font.Name, 7), Brushes.Gray, MyX + 36, MyY + 18)

            Else

                e.Graphics.DrawString(ActionDisplays(e.Index), Font, Brushes.Black, MyX + 36, MyY + 8)

            End If

        End If
    End Sub



    Private Sub ActionsList_MeasureItem(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MeasureItemEventArgs) Handles ActionsList.MeasureItem
        e.ItemHeight = If(ThinList, 24, 36)
    End Sub

#End Region

#Region "Events"

    Private Sub EventsList_DrawItem(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DrawItemEventArgs) Handles EventsList.DrawItem
        Dim TI As New Bitmap(16, 16)
        Dim Out As String
        If e.Index = -1 Then Exit Sub
        Select Case Moi.Events(e.Index).EventType
            Case "Create"
                TI = My.Resources.EventCreate
                Out = "Create"
            Case "Collision"
                TI = My.Resources.EventCollision
                Out = "Collision with " + Moi.Events(e.Index).EventData + ""
            Case "Input"
                TI = My.Resources.EventKey
                Out = Moi.Events(e.Index).EventData
            Case "Step"
                TI = My.Resources.EventStep
                Out = "Step"
            Case "Pointer"
                TI = My.Resources.EventMouse
                Out = "Pointer " + Moi.Events(e.Index).EventData
            Case Else
                Out = "<Unknown>"
        End Select
        GDIRenderItem(Color.White, False, e, 9, New Point(22, e.Bounds.Y + 3), Out, TI)
    End Sub

    Private Sub AddEventButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddEventButton.Click
        With FEvent
            .Text = "Add Event"
            .ShowDialog()
            If Not .UseData Then Exit Sub
        End With
        For T As Int16 = 0 To Moi.Events.Count - 1
            If Moi.Events(T).EventType = FEvent.EventType And Moi.Events(T).EventData = FEvent.EventData Then
                EventsList.SelectedIndex = T
                Exit Sub
            End If
        Next
        Moi.Events.Add(New DEvent(FEvent.EventType, FEvent.EventData, New List(Of String)))
        EventsList.Items.Add(FEvent.EventType + ", " + FEvent.EventData)
        EventsList.SelectedIndex = EventsList.Items.Count - 1
    End Sub

    Private Sub DeleteEventButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteEventButton.Click
        If Not EventsList.SelectedItems.Count = 1 Then Exit Sub
        If Not WarnYesNo("Are you sure you want to remove the Event and all of its actions?") Then Exit Sub
        Dim I As Int16 = EventsList.SelectedIndex
        EventsList.Items.RemoveAt(I)
        Moi.Events.RemoveAt(I)
        If EventsList.Items.Count > 0 Then
            EventsList.SelectedIndex = 0
        Else
            ClearActions()
        End If
    End Sub

    Private Sub ChangeEventButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChangeEventButton.Click
        If Not EventsList.SelectedItems.Count = 1 Then Exit Sub
        With FEvent
            .Text = "Change Event"
            .ShowDialog()
            If Not .UseData Then Exit Sub
            Moi.Events(EventsList.SelectedIndex).EventType = .EventType
            Moi.Events(EventsList.SelectedIndex).EventData = .EventData
        End With
        EventsList.Items(EventsList.SelectedIndex) = FEvent.EventType + ", " + FEvent.EventData
    End Sub

#End Region

    Private Sub DObject_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ErrorPanel.Visible = False
        Icon = ImageToIcon(My.Resources.ObjectIcon)
        SexUpToolStrip(MainToolStrip, False, False, Me)
        ActionRightClickMenu.Renderer = New metroMenuRenderer
        Text = Moi.Name
        NameTextBox.Text = Moi.Name
        DepthBox.Value = Moi.Depth
        ImageDropper.BackCombo.Items.Add("No Image")
        For Each P As DImage In Images
            ImageDropper.BackCombo.Items.Add(P.Name)
        Next
        FireEvents = True

        If Moi.ImageName.Length = 0 Then
            ImageDropper.Text = "No Image"
        Else
            ImageDropper.Text = Moi.ImageName
        End If

        EventsList.Items.Clear()
        For P As Int16 = 0 To Moi.Events.Count - 1
            EventsList.Items.Add(Moi.Events(P).EventType + ", " + Moi.Events(P).EventData)
        Next

        PopulateActionsTabControl(ActionsToAddTabControl)

        If Moi.Events.Count > 0 Then
            EventsList.SelectedIndex = 0
        End If

        ReflectThinList(False)
        ActionsList.SelectionMode = If(SelectMultiple, SelectionMode.MultiExtended, SelectionMode.One)

    End Sub

#Region "Action Context Menu"

    Private Sub ActionRightClickMenu_Opening() Handles ActionRightClickMenu.Opening
        Dim HasActions As Boolean = If(ActionsList.Items.Count > 0, True, False)
        DeleteActionRightClickButton.Enabled = HasActions
        CutActionRightClickButton.Enabled = HasActions
        CopyActionRightClickButton.Enabled = HasActions
        ClearActionsRightClickButton.Enabled = HasActions
        If ActionsList.Items.Count > 0 Then
            ActionsList.SelectedIndex = ActionsList.IndexFromPoint(ActionsList.PointToClient(Control.MousePosition))
        End If
        Dim CanPaste As Boolean = Clipboard.ContainsText()
        If CanPaste Then 'Attempt to disprove paste ability
            Dim DOn As UInt16 = 0
            Dim TheItems As New List(Of String)
            For Each X As String In Clipboard.GetText().Split(CP)
                If X.Length > 0 Then
                    If DOn = 0 And Not X = "DFACTS" Then CanPaste = False : Exit For
                    If DOn > 0 Then
                        TheItems.Add(X)
                    End If
                    DOn += 1
                End If
            Next
            If TheItems.Count = 0 Then CanPaste = False
        End If
        EditValuesRightClickButton.Enabled = If(ActionsList.SelectedIndices.Count = 1, True, False)
        PasteActionBelowRightClickButton.Enabled = CanPaste
        If ActionsList.Items.Count > 0 Then
            If Not ShouldAllowDialog(Actions(ActionsList.SelectedIndex)) Then
                EditValuesRightClickButton.Enabled = False
            End If
        End If
    End Sub

    Private Sub ClearRightClickButton_Click() Handles ClearActionsRightClickButton.Click
        Dim Response As Byte = MessageBox.Show("Are you sure you want to clear the list of Actions?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
        If Not Response = MsgBoxResult.Yes Then Exit Sub
        Actions.Clear()
        ActionImages.Clear()
        ActionDisplays.Clear()
        ActionAppliesTos.Clear()
        ActionArguments.Clear()
        ActionsList.Items.Clear()
        GenerateIndentIndices()
        BrapAllDataBack()
    End Sub

    Private Sub CutRightClickButton_Click() Handles CutActionRightClickButton.Click
        CopyActionRightClickButton_Click()
        DeleteRightClickButton_Click()
    End Sub

    Private Sub CopyActionRightClickButton_Click() Handles CopyActionRightClickButton.Click
        Dim FinalString As String = "DFACTS" + CP
        For Each X As Int16 In ActionsList.SelectedIndices
            FinalString += GenerateActionLine(Actions(X), ActionArguments(X), ActionAppliesTos(X)) + CP
        Next
        FinalString = FinalString.Substring(0, FinalString.Length - 1)
        Clipboard.SetText(FinalString)
    End Sub

    Private Sub PasteActionBelowRightClickButton_Click() Handles PasteActionBelowRightClickButton.Click
        If Not Clipboard.ContainsText Then Exit Sub
        Dim MyContent As String = Clipboard.GetText()
        If Not MyContent.Contains(CP) Then Exit Sub
        Dim MyLines As New List(Of String)
        Dim D As UInt16 = 0
        For Each X As String In MyContent.Split(CP)
            If D = 0 Then
                If Not X = "DFACTS" Then Exit Sub
            Else
                MyLines.Add(X)
            End If
            D += 1
        Next
        Dim InsertPos As UInt16 = 0
        If ActionsList.SelectedIndices.Count > 0 Then
            InsertPos = ActionsList.SelectedIndices(ActionsList.SelectedIndices.Count - 1) + 1
        Else
            If ActionsList.Items.Count > 0 Then
                InsertPos = ActionsList.Items.Count
            End If
        End If
        'MsgError("do insert " + DoInsert.ToString)
        'MsgError("insert pos " + InsertPos.ToString)
        For Each Y As String In MyLines
            Dim ActionName As String = ActionGetPartition(Y, "name")
            Dim ActionArguments As String = ActionGetPartition(Y, "arguments")
            Dim ActionAppliesTo As String = ActionGetPartition(Y, "appliesto")
            AddAction(ActionName, ActionArguments, ActionAppliesTo, True, True, True, InsertPos, True)
            InsertPos += 1
        Next
    End Sub

    Private Sub DeleteRightClickButton_Click() Handles DeleteActionRightClickButton.Click
        While ActionsList.SelectedIndices.Count > 0
            Dim TheIndex As Int16 = ActionsList.SelectedIndices(0)
            Actions.RemoveAt(TheIndex)
            ActionDisplays.RemoveAt(TheIndex)
            ActionArguments.RemoveAt(TheIndex)
            ActionAppliesTos.RemoveAt(TheIndex)
            ActionImages.RemoveAt(TheIndex)
            ActionsList.Items.RemoveAt(TheIndex)
        End While
        GenerateIndentIndices()
        BrapAllDataBack()
    End Sub

#End Region

    Private Sub DAcceptButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DAcceptButton.Click

        Dim NewName As String = NameTextBox.Text
        If Not Moi.Name = NewName Then
            If GUIResNameChecker(NewName) Then
                NameTextBox.Focus()
                Exit Sub
            End If
        End If

        If Scenes.Count > 0 Then
            For I As UInt16 = 0 To Scenes.Count - 1
                If Scenes(I).GInstances.Count > 0 Then
                    For P As UInt16 = 0 To Scenes(I).GInstances.Count - 1
                        If Scenes(I).GInstances(P).ObjectName = Moi.Name Then Scenes(I).GInstances(P).ObjectName = NewName
                    Next
                End If
            Next
        End If

        If Objects.Count > 0 Then
            For I As UInt16 = 0 To Objects.Count - 1
                For Each J As DEvent In Objects(I).Events
                    If J.EventType = "Collision" And J.EventData = Moi.Name Then
                        J.EventData = NewName
                    End If
                Next
            Next
        End If

        For Each T As Form In MainForm.MdiChildren
            If T.Name = "FScene" Then
                DirectCast(T, FScene).RenameObject(Moi.Name, NewName)
            ElseIf T.Name = "FObject" Then
                If DirectCast(T, FObject).Moi.Name = Moi.Name Then Continue For
                Dim DoRefresh As Boolean = False
                For Each J As DEvent In DirectCast(T, FObject).Moi.Events
                    If J.EventType = "Collision" And J.EventData = Moi.Name Then
                        J.EventData = NewName
                        DoRefresh = True
                    End If
                Next
                If DoRefresh Then DirectCast(T, FObject).EventsList.Refresh()
            End If
        Next

        Dim R As UInt16 = 0
        Dim DidDoIt As Boolean = False
        For P As UInt16 = 0 To Objects.Count - 1
            If Objects(P).Name = Moi.Name Then
                R = P
                DidDoIt = True
                Exit For
            End If
        Next

        For Each X As TreeNode In MainForm.ResourcesList.Nodes(ResourceType.DObject).Nodes
            If X.Text = Moi.Name Then X.Text = NewName
        Next

        Moi.Name = NewName
        Moi.Depth = DepthBox.Value

        If DidDoIt Then
            Objects(R) = Moi.CloneMe()
        Else
            ResourceError("save", ResourceType.DObject)
        End If

        Close()

    End Sub

    Private Sub DCancelButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DCancelButton.Click
        Close()
    End Sub

    Private Sub DeleteButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteButton.Click
        If Not WarnYesNo("Are you sure that you want to delete '" + Moi.Name + "'?") Then Exit Sub
        DeleteObject(Moi.Name)
    End Sub

    Function ActionGetPartition(ByRef TheString As String, ByVal Partition As String) As String
        If Not TheString.Contains("<" + Partition + ">") And TheString.Contains("</" + Partition + ">") Then Return String.Empty
        Dim Tag1 As String = "<" + Partition + ">"
        Dim Returnable As String = TheString.Substring(TheString.IndexOf(Tag1) + Tag1.Length)
        Dim Tag2 As String = "</" + Partition + ">"
        Returnable = Returnable.Substring(0, Returnable.LastIndexOf(Tag2))
        Return Returnable
    End Function

    Sub ClearActions()
        ActionsList.Items.Clear()
        Actions.Clear()
        ActionArguments.Clear()
        ActionAppliesTos.Clear()
        ActionImages.Clear()
        ActionDisplays.Clear()
    End Sub

    Function GenerateActionLine(ByVal ActionName As String, ByVal ActionArguments As String, ByVal ActionAppliesTo As String) As String
        'Dim ForkableActions As New List(Of String)
        'For I As Int16 = 0 To Actions.Count - 1
        '    Dim Final As String = String.Empty
        '    'Name
        '    Final += "<name>" + ActionName + "</name>"
        '    'Arguments
        '    Final += "<arguments>" + ActionArguments + "</arguments>"
        '    'AppliesTo
        '    Final += "<appliesto>" + ActionAppliesTo + "</appliesto>"
        '    ForkableActions.Add(Final)
        'Next
        Dim Final As String = String.Empty
        'Name
        Final += "<name>" + ActionName + "</name>"
        'Arguments
        Final += "<arguments>" + ActionArguments + "</arguments>"
        'AppliesTo
        Final += "<appliesto>" + ActionAppliesTo + "</appliesto>"
        Return Final
    End Function

    Sub AddAction(ByVal ActionName As String, ByVal DActionArguments As String, ByVal DActionAppliesTo As String, ByVal RegenerateIndices As Boolean, ByVal AddTheItem As Boolean, ByVal DoInsert As Boolean, ByVal InsertPosition As UInt16, ByVal AddToEvent As Boolean)
        If DoInsert Then
            Actions.Insert(InsertPosition, ActionName)
            ActionDisplays.Insert(InsertPosition, ActionEquateDisplay(ActionName, DActionArguments, DActionAppliesTo))
            ActionArguments.Insert(InsertPosition, DActionArguments)
            ActionAppliesTos.Insert(InsertPosition, DActionAppliesTo)
            ActionImages.Insert(InsertPosition, ActionGetIcon(ActionName, False))
        Else
            Actions.Add(ActionName)
            ActionDisplays.Add(ActionEquateDisplay(ActionName, DActionArguments, DActionAppliesTo))
            ActionArguments.Add(DActionArguments)
            ActionAppliesTos.Add(DActionAppliesTo)
            ActionImages.Add(ActionGetIcon(ActionName, False))
        End If
        If RegenerateIndices Then GenerateIndentIndices()
        If DoInsert Then
            If AddTheItem Then ActionsList.Items.Insert(InsertPosition, String.Empty)
        Else
            If AddTheItem Then ActionsList.Items.Add(String.Empty)
        End If
        If AddToEvent And EventsList.SelectedIndices.Count > 0 Then
            If DoInsert Then
                Moi.Events(EventsList.SelectedIndex).Actions.Insert(InsertPosition, GenerateActionLine(ActionName, DActionArguments, DActionAppliesTo))
            Else
                Moi.Events(EventsList.SelectedIndex).Actions.Add(GenerateActionLine(ActionName, DActionArguments, DActionAppliesTo))
            End If
        End If
    End Sub

    Private Sub EventsList_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EventsList.SelectedIndexChanged
        If EventsList.Items.Count = 0 Then Exit Sub
        If EventsList.SelectedIndex < 0 Then Exit Sub
        ErrorPanel.Visible = False
        ClearActions()
        Dim AmountAdded As UInt16 = 0
        'MsgError("fetching from: " + EventsList.SelectedIndex.ToString)
        For Each P As String In Moi.Events(EventsList.SelectedIndex).Actions
            Dim DName As String = ActionGetPartition(P, "name")
            Dim DArguments As String = ActionGetPartition(P, "arguments")
            Dim DAppliesTo As String = ActionGetPartition(P, "appliesto")
            AmountAdded += 1
            AddAction(DName, DArguments, DAppliesTo, False, False, False, 0, False)
        Next
        GenerateIndentIndices()
        If AmountAdded > 0 Then
            For i = 0 To AmountAdded - 1
                ActionsList.Items.Add(String.Empty)
            Next
        End If

    End Sub

    Private Sub CheckErrorsButton_Click(sender As System.Object, e As System.EventArgs) Handles CheckErrorsButton.Click
        Dim ErrorList As List(Of String) = CheckErrors()
        ErrorLabel.wordwrap = True

        ErrorPanel.Visible = True
        If ErrorList.Count = 0 Then
            ErrorLabel.Text = "No errors were Found in this script"
            Exit Sub
        End If
        Dim BigList As String = ""
        For Each err As String In ErrorList
            BigList = BigList + vbNewLine + err
        Next
        BigList = BigList.Substring(1)
        ErrorLabel.Text = BigList
    End Sub

    Function CheckErrors() As List(Of String)
        Dim ErrorList As New List(Of String)
        Dim ThroughCheck As Integer = 0
        For i As Integer = 0 To ActionsList.Items.Count - 1
            If ActionDisplays(i) = "Else" Then
                If i = 0 Then
                    ErrorList.Add("Unexpected Else (Line 1).")
                Else
                    If Not ActionDisplays(i - 1) = "End Block" Then
                        ErrorList.Add("Unexpected Else (Line " + (i + 1).ToString + ").")
                    End If
                End If
            End If
            If ActionDisplays(i) = "Start Block" Then
                If i = 0 Then
                    ErrorList.Add("Unexpected Start Block (Line 1).")
                Else
                    If Not (ActionGetCondition(Actions(i - 1)) Or ActionDisplays(i - 1) = "Else") Then
                        ErrorList.Add("Unexpected Start Block (Line " + (i + 1).ToString + ").")
                    End If
                End If
                ThroughCheck += 1
            End If
            If ActionDisplays(i) = "End Block" Then
                ThroughCheck -= 1
                If ThroughCheck < 0 Then
                    ErrorList.Add("Unexected End Block (Line " + (i + 1).ToString + ").")
                End If
            End If
            If ActionGetCondition(Actions(i)) Or ActionDisplays(i) = "Else" Then
                If i = ActionsList.Items.Count - 1 Then
                    ErrorList.Add("Missing Start Block (Line " + (i + 1).ToString + ").")
                Else
                    If Not ActionDisplays(i + 1) = "Start Block" Then
                        ErrorList.Add("Missing Start Block (Line " + (i + 1).ToString + ").")
                    End If
                End If
            End If
        Next

        If Not ThroughCheck = 0 Then
            ErrorList.Add("Blocks don't line up!")
        End If

        Return ErrorList
    End Function

    Private Sub CloseErrors_Click(sender As System.Object, e As System.EventArgs) Handles CloseErrors.Click
        ErrorPanel.Visible = False
    End Sub

    Private Sub SelectAllToolBtn_Click(sender As System.Object, e As System.EventArgs) Handles SelectAllToolBtn.Click
        ActionsList.SelectedIndices.Clear()
        For i As Integer = 0 To ActionsList.Items.Count - 1
            ActionsList.SelectedIndices.Add(i)
        Next

    End Sub
End Class