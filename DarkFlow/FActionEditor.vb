Imports System.IO

Public Class FActionEditor

    Dim DoIt As Boolean = False

    Dim Forkable As DAction

    Dim AddingArgument As Boolean
    Dim EI As Byte = 0

    Private Sub Actions_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        BackColor = CrucialColor
        Icon = ImageToIcon(My.Resources.ActionIcon)

        Dim SpontanList As New ImageList
        With SpontanList
            .ColorDepth = ColorDepth.Depth32Bit
            .ImageSize = New Size(16, 16)
            .Images.Add(My.Resources.OpenFileIcon)
            .Images.Add(My.Resources.ActionIcon)
        End With
        ActionsList.ImageList = SpontanList

        ImageDropper.BackCombo.Items.Clear()
        For Each F As String In Directory.GetFiles(AppPath + "ActionIcons")
            F = F.Substring(F.LastIndexOf("\") + 1)
            F = F.Substring(0, F.LastIndexOf("."))
            ImageDropper.BackCombo.Items.Add(F)
        Next

        CategoryDropper.BackCombo.Items.Clear()
        For Each F As String In ActionCategories
            CategoryDropper.BackCombo.Items.Add(F)
        Next

        ActionsList.Nodes(0).Nodes.Clear()
        For Each X As DAction In DActions
            Dim D As New TreeNode(X.Name, 1, 1)
            ActionsList.Nodes(0).Nodes.Add(D)
        Next

        ArgumentTypeDropper.BackCombo.Items.Clear()
        For Each P As String In PossibleArgumentTypes
            ArgumentTypeDropper.BackCombo.Items.Add(P)
        Next

        ActionsList.Nodes(0).Expand()
        ActionsList.SelectedNode = ActionsList.Nodes(0).Nodes(0)

        SelectZerothNode()

        ArgumentPanel.Visible = False

    End Sub

    Sub SelectZerothNode()
        ActionsList_NodeMouseDoubleClick(ActionsList, New TreeNodeMouseClickEventArgs(ActionsList.Nodes(0).Nodes(0), Windows.Forms.MouseButtons.Left, 1, 100, 100))
    End Sub

    Private Sub ActionsList_NodeMouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeNodeMouseClickEventArgs) Handles ActionsList.NodeMouseDoubleClick

        If e.Node.Level = 0 Then Exit Sub

        DoIt = False

        Dim ActionName As String = e.Node.Text
        MatchFindName = ActionName
        Forkable = DActions.Find(AddressOf MatchAction).CloneMe()
        MainNameLabel.Text = Forkable.Name
        NameBox.Text = Forkable.Name

        NoAppliesChecker.Checked = Forkable.NoApplies
        ConditionalChecker.Checked = Forkable.IsConditional
        IndentChecker.Checked = Forkable.Indent
        DedentChecker.Checked = Forkable.Dedent
        BGChecker.Checked = Forkable.BG

        CodeBox.Text = String.Empty
        For Each P As String In Forkable.CodeLines
            CodeBox.Text += P + vbNewLine
        Next
        If CodeBox.Text.Length > 0 Then CodeBox.Text = CodeBox.Text.Substring(0, CodeBox.Text.Length - 1)

        ArgumentsList.Items.Clear()
        For Each P As DArgument In Forkable.Arguments
            ArgumentsList.Items.Add(P.Name)
        Next

        DisplayBox.Text = Forkable.Display
        ImageDropper.Text = Forkable.DImageName
        CategoryDropper.Text = Forkable.Category

        DoIt = True

        DoPreview()

        CodeBox.Focus()
        If CodeBox.Text.Length > 0 Then
            CodeBox.TextContainer.SelectionStart = CodeBox.Text.Length - 1
            CodeBox.TextContainer.SelectionLength = 0
        End If

        If AddingArgument Then
            'poo
        Else
            ArgumentPanel.Visible = False
        End If

    End Sub

    Private Sub Checkers_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NoAppliesChecker.CheckedChanged, IndentChecker.CheckedChanged, DedentChecker.CheckedChanged, ConditionalChecker.CheckedChanged, BGChecker.CheckedChanged
        If DoIt Then
            Forkable.NoApplies = NoAppliesChecker.Checked
            Forkable.IsConditional = ConditionalChecker.Checked
            Forkable.Indent = IndentChecker.Checked
            Forkable.Dedent = DedentChecker.Checked
            Forkable.BG = BGChecker.Checked
            RemakeMyImage()
            DoPreview()
        End If
    End Sub

    Private Sub SaveButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveButton.Click

        Dim NewName As String = If(NameBox.Text.Length > 0, NameBox.Text, Forkable.Name)

        Forkable.CodeLines.Clear()
        For Each P As String In CodeBox.TextContainer.Lines
            If P.Length = 0 Then Continue For
            Forkable.CodeLines.Add(P)
        Next
        Forkable.Display = DisplayBox.Text

        Dim R As UInt16 = 0
        Dim DidDoIt As Boolean = False
        For I As UInt16 = 0 To DActions.Count - 1
            If DActions(I).Name = Forkable.Name Then R = I : DidDoIt = True : Exit For
        Next
        If Not DidDoIt Then Exit Sub

        If Not NewName = Forkable.Name Then
            File.Move(AppPath + "Actions\" + Forkable.Name + ".action", AppPath + "Actions\" + NewName + ".action")
            For Y As UInt16 = 0 To ActionsList.Nodes(0).Nodes.Count - 1
                If ActionsList.Nodes(0).Nodes(Y).Text = Forkable.Name Then
                    ActionsList.Nodes(0).Nodes.RemoveAt(Y)
                    ActionsList.Nodes(0).Nodes.Insert(Y, New TreeNode(NewName, 1, 1))
                End If
            Next
        End If

        MainNameLabel.Text = NewName

        Forkable.Name = NewName
        DActions(R) = Forkable.CloneMe()

        Dim F As String = String.Empty
        F += "TYPE " + Forkable.Category + vbNewLine
        F += "ICON " + Forkable.DImageName + vbNewLine
        F += "DISPLAY " + Forkable.Display + vbNewLine
        If IndentChecker.Checked Then F += "INDENT" + vbNewLine
        If DedentChecker.Checked Then F += "DEDENT" + vbNewLine
        If ConditionalChecker.Checked Then F += "CONDITIONAL" + vbNewLine
        If NoAppliesChecker.Checked Then F += "NOAPPLIES" + vbNewLine
        If BGChecker.Checked Then F += "BG" + vbNewLine
        For Each D As DArgument In Forkable.Arguments
            F += "ARG " + D.Name + CC + D.Type.ToString + vbNewLine
        Next
        For Each P As String In Forkable.CodeLines
            F += P + vbNewLine
        Next

        IO.File.WriteAllText(AppPath + "Actions\" + NewName + ".action", F)

    End Sub

    Private Sub DeleteButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteButton.Click
        'TRANSLATE
        If DActions.Count = 1 Then
            MsgError("There is only one Action. Continuation is not safe.")
            Exit Sub
        End If
        If Not WarnYesNo("Do you want to delete the Action '" + Forkable.Name + "'?") Then Exit Sub
        Dim DelID As UInt16 = 0
        Dim DidFind As Boolean = False
        For I As UInt16 = 0 To DActions.Count - 1
            If DActions(I).Name = Forkable.Name Then DelID = I : DidFind = True : Exit For
        Next
        If Not DidFind Then Exit Sub
        ActionsList.Nodes(0).Nodes.RemoveAt(DelID)
        DActions.RemoveAt(DelID)
        IO.File.Delete(AppPath + "Actions\" + Forkable.Name + ".action")
        SelectZerothNode()
    End Sub

    Sub DoPreview()
        IconPanel.BackgroundImage = Forkable.DImage
    End Sub

    Sub RemakeMyImage()
        Forkable.DImage = ActionMakeIcon(ImageDropper.Text, ConditionalChecker.Checked, Forkable.BG)
    End Sub

    Private Sub ImageDropper_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImageDropper.SelectedIndexChanged
        If Not DoIt Then Exit Sub
        Forkable.DImageName = ImageDropper.Text
        RemakeMyImage()
        DoPreview()
    End Sub

    Private Sub ArgumentsList_DrawItem(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DrawItemEventArgs) Handles ArgumentsList.DrawItem
        If e.Index < 0 Then Exit Sub
        GDIRenderItem(Color.White, False, e, 9, New Point(22, e.Bounds.Y + 2), Forkable.Arguments(e.Index).Name, My.Resources.SettingsIcon)
    End Sub

    Private Sub Actions_ResizeEnd(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.ResizeEnd
        MainSplitter.Invalidate()
    End Sub

    Private Function IsArgumentAcceptable(ByVal NewName As String) As Boolean
        For Each P As DArgument In Forkable.Arguments
            If P.Name = NewName Then Return False
        Next
        Return True
    End Function

    Private Sub ArgumentsList_MouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ArgumentsList.MouseDoubleClick
        If ArgumentsList.SelectedIndices.Count = 0 Then Exit Sub
        'The most Hideous bodge in the World
        CodeBox.Focus()
        SendKeys.Send("!" + (ArgumentsList.SelectedIndex + 1).ToString + "!")
    End Sub

    Private Sub AddArgButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddArgButton.Click
        AddingArgument = True
        Dim D As UInt16 = 1
        While Not IsArgumentAcceptable("Argument_" + D.ToString)
            D += 1
        End While
        ArgumentNameBox.Text = "Argument_" + D.ToString
        ArgumentTypeDropper.Text = PossibleArgumentTypes(0)
        ArgumentPanel.Visible = True
        ArgumentNameBox.Focus()
    End Sub

    Private Sub EditArgButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditArgButton.Click
        If ArgumentsList.SelectedItems.Count = 0 Then Exit Sub
        AddingArgument = False
        EI = ArgumentsList.SelectedIndex
        ArgumentNameBox.Text = Forkable.Arguments(EI).Name
        If Forkable.Arguments(EI).Type.Length = 1 Then ArgumentTypeDropper.Text = "Generic" Else ArgumentTypeDropper.Text = Forkable.Arguments(EI).Type
        ArgumentPanel.Visible = True
        ArgumentNameBox.Focus()
    End Sub

    Private Sub DeleteArgButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteArgButton.Click
        If ArgumentsList.SelectedItems.Count = 0 Then Exit Sub
        Forkable.Arguments.RemoveAt(ArgumentsList.SelectedIndex)
        ArgumentsList.Items.RemoveAt(ArgumentsList.SelectedIndex)
    End Sub

    Private Sub ArgumentAcceptButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ArgumentAcceptButton.Click
        If AddingArgument Then
            Forkable.Arguments.Add(New DArgument(ArgumentNameBox.Text, ArgumentTypeDropper.Text))
            ArgumentsList.Items.Add(ArgumentNameBox.Text)
            ArgumentsList.Invalidate()
        Else
            If Not Forkable.Arguments(EI).Name = ArgumentNameBox.Text Then
                If Not IsArgumentAcceptable(ArgumentNameBox.Text) Then ArgumentNameBox.Focus() : Exit Sub
            End If
            Forkable.Arguments(EI) = New DArgument(ArgumentNameBox.Text, ArgumentTypeDropper.Text)
            ArgumentsList.Items.Item(EI) = ArgumentNameBox.Text
            ArgumentsList.Invalidate()
        End If
        ArgumentPanel.Visible = False
    End Sub

    Private Sub ArgumentsList_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ArgumentsList.SelectedIndexChanged
        If Not ArgumentsList.SelectedIndex = EI Then ArgumentPanel.Visible = False
    End Sub

    Private Sub CategoryDropper_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CategoryDropper.SelectedIndexChanged
        If Not DoIt Then Exit Sub
        Forkable.Category = CategoryDropper.Text
    End Sub

    Private Sub AddButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddButton.Click

        Dim NewName As String = GetInput("New Action Name", String.Empty, ValidateLevel.None)
        If NewName.Length = 0 Then Exit Sub

        Dim F As New DAction(NewName, "Control", "Variable", ActionMakeIcon("Variable", False, True), NewName, False, False, New List(Of DArgument), False, False, New List(Of String), True, True)
        DActions.Add(F)
        Dim R As String = String.Empty
        R += "TYPE Control" + vbNewLine
        R += "ICON Variable" + vbNewLine
        R += "DISPLAY " + NewName + vbNewLine
        R += "BG"

        IO.File.WriteAllText(AppPath + "Actions\" + NewName + ".action", R)

        ActionsList.Nodes(0).Nodes.Add(New TreeNode(NewName, 1, 1))

    End Sub
End Class