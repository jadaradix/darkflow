
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FObject
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FObject))
        Me.MainToolStrip = New System.Windows.Forms.ToolStrip()
        Me.DAcceptButton = New System.Windows.Forms.ToolStripButton()
        Me.TSS1 = New System.Windows.Forms.ToolStripSeparator()
        Me.DCancelButton = New System.Windows.Forms.ToolStripButton()
        Me.TSS2 = New System.Windows.Forms.ToolStripSeparator()
        Me.DeleteButton = New System.Windows.Forms.ToolStripButton()
        Me.SelectAllButton = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.SelectManyButton = New System.Windows.Forms.ToolStripButton()
        Me.SelectOneButton = New System.Windows.Forms.ToolStripButton()
        Me.SelectionSeperator = New System.Windows.Forms.ToolStripSeparator()
        Me.CheckErrorsButton = New System.Windows.Forms.ToolStripButton()
        Me.ActionRightClickMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.EditValuesRightClickButton = New System.Windows.Forms.ToolStripMenuItem()
        Me.RightClickSep1 = New System.Windows.Forms.ToolStripSeparator()
        Me.SelectOneRightClickButton = New System.Windows.Forms.ToolStripMenuItem()
        Me.SelectManyRightClickButton = New System.Windows.Forms.ToolStripMenuItem()
        Me.RightClickSep3 = New System.Windows.Forms.ToolStripSeparator()
        Me.SelectAllToolBtn = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.CutActionRightClickButton = New System.Windows.Forms.ToolStripMenuItem()
        Me.CopyActionRightClickButton = New System.Windows.Forms.ToolStripMenuItem()
        Me.PasteActionBelowRightClickButton = New System.Windows.Forms.ToolStripMenuItem()
        Me.RightClickSep2 = New System.Windows.Forms.ToolStripSeparator()
        Me.DeleteActionRightClickButton = New System.Windows.Forms.ToolStripMenuItem()
        Me.ClearActionsRightClickButton = New System.Windows.Forms.ToolStripMenuItem()
        Me.BottomPanel = New System.Windows.Forms.Panel()
        Me.ActionsToAddTabControl = New DarkFlow.SexyTabControl()
        Me.ActionInfoPanel = New System.Windows.Forms.Panel()
        Me.ArgumentsListLabel = New System.Windows.Forms.Label()
        Me.ArgumentsHeaderLabel = New System.Windows.Forms.Label()
        Me.ActionNameLabel = New System.Windows.Forms.Label()
        Me.ActionsList = New System.Windows.Forms.ListBox()
        Me.ErrorPanel = New DarkFlow.DoubleBufferPanel()
        Me.CloseErrors = New DarkFlow.SexyButton()
        Me.ErrorLabel = New System.Windows.Forms.TextBox()
        Me.SidePanel = New DarkFlow.DoubleBufferPanel()
        Me.DepthBox = New DarkFlow.SexyNumeric()
        Me.DepthLabel = New System.Windows.Forms.Label()
        Me.EventsListBacker = New DarkFlow.SuperPanel()
        Me.EventsList = New System.Windows.Forms.ListBox()
        Me.ImageDropper = New DarkFlow.SexyComboBox()
        Me.NameTextBox = New DarkFlow.SexyTextBox()
        Me.NameLabel = New System.Windows.Forms.Label()
        Me.EditImageButton = New DarkFlow.SexyButton()
        Me.ImageLabel = New System.Windows.Forms.Label()
        Me.AddEventButton = New DarkFlow.SexyButton()
        Me.DeleteEventButton = New DarkFlow.SexyButton()
        Me.ImagePreviewPanel = New System.Windows.Forms.Panel()
        Me.ChangeEventButton = New DarkFlow.SexyButton()
        Me.OpenImageButton = New DarkFlow.SexyButton()
        Me.EventsLabel = New System.Windows.Forms.Label()
        Me.MainToolStrip.SuspendLayout()
        Me.ActionRightClickMenu.SuspendLayout()
        Me.BottomPanel.SuspendLayout()
        Me.ActionInfoPanel.SuspendLayout()
        Me.ErrorPanel.SuspendLayout()
        Me.SidePanel.SuspendLayout()
        Me.EventsListBacker.SuspendLayout()
        Me.SuspendLayout()
        '
        'MainToolStrip
        '
        Me.MainToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DAcceptButton, Me.TSS1, Me.DCancelButton, Me.TSS2, Me.DeleteButton, Me.SelectAllButton, Me.ToolStripSeparator1, Me.SelectManyButton, Me.SelectOneButton, Me.SelectionSeperator, Me.CheckErrorsButton})
        Me.MainToolStrip.Location = New System.Drawing.Point(0, 0)
        Me.MainToolStrip.Name = "MainToolStrip"
        Me.MainToolStrip.Padding = New System.Windows.Forms.Padding(0, 2, 0, 2)
        Me.MainToolStrip.Size = New System.Drawing.Size(734, 27)
        Me.MainToolStrip.TabIndex = 0
        Me.MainToolStrip.Text = "ToolStrip1"
        '
        'DAcceptButton
        '
        Me.DAcceptButton.Image = Global.DarkFlow.My.Resources.Resources.AcceptIcon
        Me.DAcceptButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.DAcceptButton.Name = "DAcceptButton"
        Me.DAcceptButton.Size = New System.Drawing.Size(64, 20)
        Me.DAcceptButton.Text = "Accept"
        '
        'TSS1
        '
        Me.TSS1.Name = "TSS1"
        Me.TSS1.Size = New System.Drawing.Size(6, 23)
        '
        'DCancelButton
        '
        Me.DCancelButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.DCancelButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.DCancelButton.Name = "DCancelButton"
        Me.DCancelButton.Size = New System.Drawing.Size(47, 20)
        Me.DCancelButton.Text = "Cancel"
        '
        'TSS2
        '
        Me.TSS2.Name = "TSS2"
        Me.TSS2.Size = New System.Drawing.Size(6, 23)
        '
        'DeleteButton
        '
        Me.DeleteButton.Image = Global.DarkFlow.My.Resources.Resources.DeleteIcon
        Me.DeleteButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.DeleteButton.Name = "DeleteButton"
        Me.DeleteButton.Size = New System.Drawing.Size(60, 20)
        Me.DeleteButton.Text = "Delete"
        '
        'SelectAllButton
        '
        Me.SelectAllButton.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.SelectAllButton.Image = Global.DarkFlow.My.Resources.Resources.CopyIcon
        Me.SelectAllButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.SelectAllButton.Name = "SelectAllButton"
        Me.SelectAllButton.Size = New System.Drawing.Size(75, 20)
        Me.SelectAllButton.Text = "Select All"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 23)
        '
        'SelectManyButton
        '
        Me.SelectManyButton.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.SelectManyButton.Image = Global.DarkFlow.My.Resources.Resources.ArrayIcon
        Me.SelectManyButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.SelectManyButton.Name = "SelectManyButton"
        Me.SelectManyButton.Size = New System.Drawing.Size(91, 20)
        Me.SelectManyButton.Text = "Select Many"
        '
        'SelectOneButton
        '
        Me.SelectOneButton.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.SelectOneButton.Image = Global.DarkFlow.My.Resources.Resources.ArrayIcon
        Me.SelectOneButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.SelectOneButton.Name = "SelectOneButton"
        Me.SelectOneButton.Size = New System.Drawing.Size(83, 20)
        Me.SelectOneButton.Text = "Select One"
        '
        'SelectionSeperator
        '
        Me.SelectionSeperator.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.SelectionSeperator.Name = "SelectionSeperator"
        Me.SelectionSeperator.Size = New System.Drawing.Size(6, 23)
        '
        'CheckErrorsButton
        '
        Me.CheckErrorsButton.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.CheckErrorsButton.Image = Global.DarkFlow.My.Resources.Resources.checkerrs
        Me.CheckErrorsButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.CheckErrorsButton.Name = "CheckErrorsButton"
        Me.CheckErrorsButton.Size = New System.Drawing.Size(133, 20)
        Me.CheckErrorsButton.Text = "Check For Problems"
        '
        'ActionRightClickMenu
        '
        Me.ActionRightClickMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EditValuesRightClickButton, Me.RightClickSep1, Me.SelectOneRightClickButton, Me.SelectManyRightClickButton, Me.RightClickSep3, Me.SelectAllToolBtn, Me.ToolStripSeparator2, Me.CutActionRightClickButton, Me.CopyActionRightClickButton, Me.PasteActionBelowRightClickButton, Me.RightClickSep2, Me.DeleteActionRightClickButton, Me.ClearActionsRightClickButton})
        Me.ActionRightClickMenu.Name = "ActionRightClickMenu"
        Me.ActionRightClickMenu.Size = New System.Drawing.Size(179, 226)
        '
        'EditValuesRightClickButton
        '
        Me.EditValuesRightClickButton.Image = Global.DarkFlow.My.Resources.Resources.EditIcon
        Me.EditValuesRightClickButton.Name = "EditValuesRightClickButton"
        Me.EditValuesRightClickButton.Size = New System.Drawing.Size(178, 22)
        Me.EditValuesRightClickButton.Text = "Edit Values"
        '
        'RightClickSep1
        '
        Me.RightClickSep1.Name = "RightClickSep1"
        Me.RightClickSep1.Size = New System.Drawing.Size(175, 6)
        '
        'SelectOneRightClickButton
        '
        Me.SelectOneRightClickButton.Image = Global.DarkFlow.My.Resources.Resources.ArrayIcon
        Me.SelectOneRightClickButton.Name = "SelectOneRightClickButton"
        Me.SelectOneRightClickButton.Size = New System.Drawing.Size(178, 22)
        Me.SelectOneRightClickButton.Text = "Select One"
        '
        'SelectManyRightClickButton
        '
        Me.SelectManyRightClickButton.Image = Global.DarkFlow.My.Resources.Resources.ArrayIcon
        Me.SelectManyRightClickButton.Name = "SelectManyRightClickButton"
        Me.SelectManyRightClickButton.Size = New System.Drawing.Size(178, 22)
        Me.SelectManyRightClickButton.Text = "Select Many"
        '
        'RightClickSep3
        '
        Me.RightClickSep3.Name = "RightClickSep3"
        Me.RightClickSep3.Size = New System.Drawing.Size(175, 6)
        '
        'SelectAllToolBtn
        '
        Me.SelectAllToolBtn.Name = "SelectAllToolBtn"
        Me.SelectAllToolBtn.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.A), System.Windows.Forms.Keys)
        Me.SelectAllToolBtn.Size = New System.Drawing.Size(178, 22)
        Me.SelectAllToolBtn.Text = "Select All"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(175, 6)
        '
        'CutActionRightClickButton
        '
        Me.CutActionRightClickButton.Name = "CutActionRightClickButton"
        Me.CutActionRightClickButton.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.X), System.Windows.Forms.Keys)
        Me.CutActionRightClickButton.Size = New System.Drawing.Size(178, 22)
        Me.CutActionRightClickButton.Text = "Cut"
        '
        'CopyActionRightClickButton
        '
        Me.CopyActionRightClickButton.Image = Global.DarkFlow.My.Resources.Resources.CopyIcon
        Me.CopyActionRightClickButton.Name = "CopyActionRightClickButton"
        Me.CopyActionRightClickButton.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.C), System.Windows.Forms.Keys)
        Me.CopyActionRightClickButton.Size = New System.Drawing.Size(178, 22)
        Me.CopyActionRightClickButton.Text = "Copy"
        '
        'PasteActionBelowRightClickButton
        '
        Me.PasteActionBelowRightClickButton.Image = Global.DarkFlow.My.Resources.Resources.PasteIcon
        Me.PasteActionBelowRightClickButton.Name = "PasteActionBelowRightClickButton"
        Me.PasteActionBelowRightClickButton.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.V), System.Windows.Forms.Keys)
        Me.PasteActionBelowRightClickButton.Size = New System.Drawing.Size(178, 22)
        Me.PasteActionBelowRightClickButton.Text = "Paste below"
        '
        'RightClickSep2
        '
        Me.RightClickSep2.Name = "RightClickSep2"
        Me.RightClickSep2.Size = New System.Drawing.Size(175, 6)
        '
        'DeleteActionRightClickButton
        '
        Me.DeleteActionRightClickButton.Image = Global.DarkFlow.My.Resources.Resources.DeleteIcon
        Me.DeleteActionRightClickButton.Name = "DeleteActionRightClickButton"
        Me.DeleteActionRightClickButton.ShortcutKeys = System.Windows.Forms.Keys.Delete
        Me.DeleteActionRightClickButton.Size = New System.Drawing.Size(178, 22)
        Me.DeleteActionRightClickButton.Text = "Delete"
        '
        'ClearActionsRightClickButton
        '
        Me.ClearActionsRightClickButton.Name = "ClearActionsRightClickButton"
        Me.ClearActionsRightClickButton.Size = New System.Drawing.Size(178, 22)
        Me.ClearActionsRightClickButton.Text = "Clear"
        '
        'BottomPanel
        '
        Me.BottomPanel.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.BottomPanel.Controls.Add(Me.ActionsToAddTabControl)
        Me.BottomPanel.Controls.Add(Me.ActionInfoPanel)
        Me.BottomPanel.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.BottomPanel.Location = New System.Drawing.Point(180, 287)
        Me.BottomPanel.Name = "BottomPanel"
        Me.BottomPanel.Size = New System.Drawing.Size(554, 176)
        Me.BottomPanel.TabIndex = 8
        '
        'ActionsToAddTabControl
        '
        Me.ActionsToAddTabControl.BorderColor = System.Drawing.Color.FromArgb(CType(CType(80, Byte), Integer), CType(CType(80, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.ActionsToAddTabControl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ActionsToAddTabControl.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed
        Me.ActionsToAddTabControl.GradFrom = System.Drawing.Color.FromArgb(CType(CType(133, Byte), Integer), CType(CType(133, Byte), Integer), CType(CType(133, Byte), Integer))
        Me.ActionsToAddTabControl.Location = New System.Drawing.Point(0, 0)
        Me.ActionsToAddTabControl.Name = "ActionsToAddTabControl"
        Me.ActionsToAddTabControl.SelectedIndex = 0
        Me.ActionsToAddTabControl.Size = New System.Drawing.Size(330, 176)
        Me.ActionsToAddTabControl.TabIndex = 5
        '
        'ActionInfoPanel
        '
        Me.ActionInfoPanel.BackColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.ActionInfoPanel.Controls.Add(Me.ArgumentsListLabel)
        Me.ActionInfoPanel.Controls.Add(Me.ArgumentsHeaderLabel)
        Me.ActionInfoPanel.Controls.Add(Me.ActionNameLabel)
        Me.ActionInfoPanel.Dock = System.Windows.Forms.DockStyle.Right
        Me.ActionInfoPanel.Location = New System.Drawing.Point(330, 0)
        Me.ActionInfoPanel.Name = "ActionInfoPanel"
        Me.ActionInfoPanel.Size = New System.Drawing.Size(224, 176)
        Me.ActionInfoPanel.TabIndex = 6
        '
        'ArgumentsListLabel
        '
        Me.ArgumentsListLabel.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ArgumentsListLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.ArgumentsListLabel.Location = New System.Drawing.Point(7, 58)
        Me.ArgumentsListLabel.Name = "ArgumentsListLabel"
        Me.ArgumentsListLabel.Padding = New System.Windows.Forms.Padding(0, 2, 4, 4)
        Me.ArgumentsListLabel.Size = New System.Drawing.Size(208, 112)
        Me.ArgumentsListLabel.TabIndex = 2
        '
        'ArgumentsHeaderLabel
        '
        Me.ArgumentsHeaderLabel.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ArgumentsHeaderLabel.BackColor = System.Drawing.Color.Gray
        Me.ArgumentsHeaderLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ArgumentsHeaderLabel.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ArgumentsHeaderLabel.ForeColor = System.Drawing.Color.White
        Me.ArgumentsHeaderLabel.Location = New System.Drawing.Point(4, 36)
        Me.ArgumentsHeaderLabel.Name = "ArgumentsHeaderLabel"
        Me.ArgumentsHeaderLabel.Padding = New System.Windows.Forms.Padding(2)
        Me.ArgumentsHeaderLabel.Size = New System.Drawing.Size(215, 138)
        Me.ArgumentsHeaderLabel.TabIndex = 1
        Me.ArgumentsHeaderLabel.Text = "Arguments:"
        '
        'ActionNameLabel
        '
        Me.ActionNameLabel.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ActionNameLabel.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ActionNameLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ActionNameLabel.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ActionNameLabel.ForeColor = System.Drawing.Color.White
        Me.ActionNameLabel.Location = New System.Drawing.Point(4, 5)
        Me.ActionNameLabel.Name = "ActionNameLabel"
        Me.ActionNameLabel.Padding = New System.Windows.Forms.Padding(2, 4, 4, 4)
        Me.ActionNameLabel.Size = New System.Drawing.Size(215, 27)
        Me.ActionNameLabel.TabIndex = 0
        '
        'ActionsList
        '
        Me.ActionsList.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ActionsList.BackColor = System.Drawing.Color.White
        Me.ActionsList.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ActionsList.ContextMenuStrip = Me.ActionRightClickMenu
        Me.ActionsList.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable
        Me.ActionsList.FormattingEnabled = True
        Me.ActionsList.ItemHeight = 36
        Me.ActionsList.Location = New System.Drawing.Point(182, 29)
        Me.ActionsList.Name = "ActionsList"
        Me.ActionsList.Size = New System.Drawing.Size(550, 258)
        Me.ActionsList.TabIndex = 6
        '
        'ErrorPanel
        '
        Me.ErrorPanel.BackgroundImage = Global.DarkFlow.My.Resources.Resources.InverseGradient
        Me.ErrorPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ErrorPanel.Controls.Add(Me.CloseErrors)
        Me.ErrorPanel.Controls.Add(Me.ErrorLabel)
        Me.ErrorPanel.Dock = System.Windows.Forms.DockStyle.Right
        Me.ErrorPanel.Location = New System.Drawing.Point(554, 27)
        Me.ErrorPanel.Name = "ErrorPanel"
        Me.ErrorPanel.Size = New System.Drawing.Size(180, 260)
        Me.ErrorPanel.TabIndex = 9
        Me.ErrorPanel.Visible = False
        '
        'CloseErrors
        '
        Me.CloseErrors.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CloseErrors.BackColor = System.Drawing.Color.Transparent
        Me.CloseErrors.DText = "Close Error Panel"
        Me.CloseErrors.ForeColor = System.Drawing.Color.Black
        Me.CloseErrors.ImageOnTop = False
        Me.CloseErrors.LeftAligned = False
        Me.CloseErrors.Location = New System.Drawing.Point(3, 233)
        Me.CloseErrors.Name = "CloseErrors"
        Me.CloseErrors.Size = New System.Drawing.Size(174, 24)
        Me.CloseErrors.TabIndex = 6
        Me.CloseErrors.TabStop = True
        Me.CloseErrors.Text = "Close Error Panel"
        Me.CloseErrors.TextImageSpacing = CType(0, Byte)
        Me.CloseErrors.XIMage = Nothing
        '
        'ErrorLabel
        '
        Me.ErrorLabel.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ErrorLabel.BackColor = System.Drawing.Color.DarkGray
        Me.ErrorLabel.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ErrorLabel.Location = New System.Drawing.Point(3, 3)
        Me.ErrorLabel.Multiline = True
        Me.ErrorLabel.Name = "ErrorLabel"
        Me.ErrorLabel.ReadOnly = True
        Me.ErrorLabel.Size = New System.Drawing.Size(174, 228)
        Me.ErrorLabel.TabIndex = 0
        Me.ErrorLabel.WordWrap = False
        '
        'SidePanel
        '
        Me.SidePanel.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.SidePanel.BackgroundImage = Global.DarkFlow.My.Resources.Resources.InverseGradient
        Me.SidePanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.SidePanel.Controls.Add(Me.DepthBox)
        Me.SidePanel.Controls.Add(Me.DepthLabel)
        Me.SidePanel.Controls.Add(Me.EventsListBacker)
        Me.SidePanel.Controls.Add(Me.ImageDropper)
        Me.SidePanel.Controls.Add(Me.NameTextBox)
        Me.SidePanel.Controls.Add(Me.NameLabel)
        Me.SidePanel.Controls.Add(Me.EditImageButton)
        Me.SidePanel.Controls.Add(Me.ImageLabel)
        Me.SidePanel.Controls.Add(Me.AddEventButton)
        Me.SidePanel.Controls.Add(Me.DeleteEventButton)
        Me.SidePanel.Controls.Add(Me.ImagePreviewPanel)
        Me.SidePanel.Controls.Add(Me.ChangeEventButton)
        Me.SidePanel.Controls.Add(Me.OpenImageButton)
        Me.SidePanel.Controls.Add(Me.EventsLabel)
        Me.SidePanel.Dock = System.Windows.Forms.DockStyle.Left
        Me.SidePanel.Location = New System.Drawing.Point(0, 27)
        Me.SidePanel.Name = "SidePanel"
        Me.SidePanel.Size = New System.Drawing.Size(180, 436)
        Me.SidePanel.TabIndex = 7
        '
        'DepthBox
        '
        Me.DepthBox.BackColor = System.Drawing.Color.Transparent
        Me.DepthBox.BorderColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.DepthBox.InputColor = System.Drawing.Color.FromArgb(CType(CType(41, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.DepthBox.Location = New System.Drawing.Point(111, 136)
        Me.DepthBox.Maximum = CType(200US, UShort)
        Me.DepthBox.Minimum = CType(0US, UShort)
        Me.DepthBox.Name = "DepthBox"
        Me.DepthBox.ShadowColor = System.Drawing.Color.FromArgb(CType(CType(72, Byte), Integer), CType(CType(72, Byte), Integer), CType(CType(72, Byte), Integer))
        Me.DepthBox.Size = New System.Drawing.Size(67, 24)
        Me.DepthBox.TabIndex = 20
        Me.DepthBox.Value = CType(0US, UShort)
        '
        'DepthLabel
        '
        Me.DepthLabel.AutoSize = True
        Me.DepthLabel.BackColor = System.Drawing.Color.Transparent
        Me.DepthLabel.ForeColor = System.Drawing.Color.Silver
        Me.DepthLabel.Location = New System.Drawing.Point(66, 140)
        Me.DepthLabel.Name = "DepthLabel"
        Me.DepthLabel.Size = New System.Drawing.Size(42, 15)
        Me.DepthLabel.TabIndex = 19
        Me.DepthLabel.Text = "Depth:"
        '
        'EventsListBacker
        '
        Me.EventsListBacker.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.EventsListBacker.BorderColor = System.Drawing.Color.Gray
        Me.EventsListBacker.BorderRadius = CType(6, Byte)
        Me.EventsListBacker.Controls.Add(Me.EventsList)
        Me.EventsListBacker.GradBottomColor = System.Drawing.Color.White
        Me.EventsListBacker.GradTopColor = System.Drawing.Color.White
        Me.EventsListBacker.Location = New System.Drawing.Point(3, 193)
        Me.EventsListBacker.Name = "EventsListBacker"
        Me.EventsListBacker.Size = New System.Drawing.Size(174, 173)
        Me.EventsListBacker.TabIndex = 8
        '
        'EventsList
        '
        Me.EventsList.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.EventsList.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.EventsList.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable
        Me.EventsList.FormattingEnabled = True
        Me.EventsList.ItemHeight = 24
        Me.EventsList.Location = New System.Drawing.Point(3, 3)
        Me.EventsList.Name = "EventsList"
        Me.EventsList.Size = New System.Drawing.Size(168, 167)
        Me.EventsList.TabIndex = 5
        '
        'ImageDropper
        '
        Me.ImageDropper.BackColor = System.Drawing.Color.Transparent
        Me.ImageDropper.BorderColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.ImageDropper.Image = CType(resources.GetObject("ImageDropper.Image"), System.Drawing.Image)
        Me.ImageDropper.Location = New System.Drawing.Point(67, 85)
        Me.ImageDropper.Name = "ImageDropper"
        Me.ImageDropper.ShadowColor = System.Drawing.Color.FromArgb(CType(CType(72, Byte), Integer), CType(CType(72, Byte), Integer), CType(CType(72, Byte), Integer))
        Me.ImageDropper.Size = New System.Drawing.Size(111, 24)
        Me.ImageDropper.TabIndex = 8
        '
        'NameTextBox
        '
        Me.NameTextBox.BackColor = System.Drawing.Color.Transparent
        Me.NameTextBox.BorderColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.NameTextBox.Location = New System.Drawing.Point(10, 24)
        Me.NameTextBox.MultiLine = False
        Me.NameTextBox.Name = "NameTextBox"
        Me.NameTextBox.ShadowColor = System.Drawing.Color.Black
        Me.NameTextBox.Size = New System.Drawing.Size(158, 24)
        Me.NameTextBox.TabIndex = 18
        Me.NameTextBox.UseSystemPasswordChar = False
        '
        'NameLabel
        '
        Me.NameLabel.AutoSize = True
        Me.NameLabel.BackColor = System.Drawing.Color.Transparent
        Me.NameLabel.ForeColor = System.Drawing.Color.White
        Me.NameLabel.Location = New System.Drawing.Point(8, 8)
        Me.NameLabel.Name = "NameLabel"
        Me.NameLabel.Size = New System.Drawing.Size(42, 15)
        Me.NameLabel.TabIndex = 4
        Me.NameLabel.Text = "Name:"
        '
        'EditImageButton
        '
        Me.EditImageButton.BackColor = System.Drawing.Color.Transparent
        Me.EditImageButton.DText = "Edit"
        Me.EditImageButton.ForeColor = System.Drawing.Color.Black
        Me.EditImageButton.ImageOnTop = False
        Me.EditImageButton.LeftAligned = False
        Me.EditImageButton.Location = New System.Drawing.Point(124, 110)
        Me.EditImageButton.Name = "EditImageButton"
        Me.EditImageButton.Size = New System.Drawing.Size(54, 24)
        Me.EditImageButton.TabIndex = 17
        Me.EditImageButton.TabStop = True
        Me.EditImageButton.Text = "Edit"
        Me.EditImageButton.TextImageSpacing = CType(0, Byte)
        Me.EditImageButton.XIMage = Nothing
        '
        'ImageLabel
        '
        Me.ImageLabel.BackColor = System.Drawing.Color.Silver
        Me.ImageLabel.ForeColor = System.Drawing.Color.Black
        Me.ImageLabel.Location = New System.Drawing.Point(0, 60)
        Me.ImageLabel.Name = "ImageLabel"
        Me.ImageLabel.Padding = New System.Windows.Forms.Padding(3)
        Me.ImageLabel.Size = New System.Drawing.Size(180, 22)
        Me.ImageLabel.TabIndex = 13
        Me.ImageLabel.Text = "Image"
        Me.ImageLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'AddEventButton
        '
        Me.AddEventButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.AddEventButton.BackColor = System.Drawing.Color.Transparent
        Me.AddEventButton.DText = "Add"
        Me.AddEventButton.ForeColor = System.Drawing.Color.Black
        Me.AddEventButton.ImageOnTop = False
        Me.AddEventButton.LeftAligned = False
        Me.AddEventButton.Location = New System.Drawing.Point(3, 368)
        Me.AddEventButton.Name = "AddEventButton"
        Me.AddEventButton.Size = New System.Drawing.Size(174, 32)
        Me.AddEventButton.TabIndex = 16
        Me.AddEventButton.TabStop = True
        Me.AddEventButton.Text = "Add"
        Me.AddEventButton.TextImageSpacing = CType(0, Byte)
        Me.AddEventButton.XIMage = Nothing
        '
        'DeleteEventButton
        '
        Me.DeleteEventButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.DeleteEventButton.BackColor = System.Drawing.Color.Transparent
        Me.DeleteEventButton.DText = "Delete"
        Me.DeleteEventButton.ForeColor = System.Drawing.Color.Black
        Me.DeleteEventButton.ImageOnTop = False
        Me.DeleteEventButton.LeftAligned = False
        Me.DeleteEventButton.Location = New System.Drawing.Point(91, 402)
        Me.DeleteEventButton.Name = "DeleteEventButton"
        Me.DeleteEventButton.Size = New System.Drawing.Size(86, 32)
        Me.DeleteEventButton.TabIndex = 15
        Me.DeleteEventButton.TabStop = True
        Me.DeleteEventButton.Text = "Delete"
        Me.DeleteEventButton.TextImageSpacing = CType(0, Byte)
        Me.DeleteEventButton.XIMage = Nothing
        '
        'ImagePreviewPanel
        '
        Me.ImagePreviewPanel.BackColor = System.Drawing.Color.Transparent
        Me.ImagePreviewPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.ImagePreviewPanel.Location = New System.Drawing.Point(2, 83)
        Me.ImagePreviewPanel.Name = "ImagePreviewPanel"
        Me.ImagePreviewPanel.Size = New System.Drawing.Size(63, 63)
        Me.ImagePreviewPanel.TabIndex = 5
        '
        'ChangeEventButton
        '
        Me.ChangeEventButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ChangeEventButton.BackColor = System.Drawing.Color.Transparent
        Me.ChangeEventButton.DText = "Change"
        Me.ChangeEventButton.ForeColor = System.Drawing.Color.Black
        Me.ChangeEventButton.ImageOnTop = False
        Me.ChangeEventButton.LeftAligned = False
        Me.ChangeEventButton.Location = New System.Drawing.Point(3, 402)
        Me.ChangeEventButton.Name = "ChangeEventButton"
        Me.ChangeEventButton.Size = New System.Drawing.Size(86, 32)
        Me.ChangeEventButton.TabIndex = 5
        Me.ChangeEventButton.TabStop = True
        Me.ChangeEventButton.Text = "Change"
        Me.ChangeEventButton.TextImageSpacing = CType(0, Byte)
        Me.ChangeEventButton.XIMage = Nothing
        '
        'OpenImageButton
        '
        Me.OpenImageButton.BackColor = System.Drawing.Color.Transparent
        Me.OpenImageButton.DText = "Open"
        Me.OpenImageButton.ForeColor = System.Drawing.Color.Black
        Me.OpenImageButton.ImageOnTop = False
        Me.OpenImageButton.LeftAligned = False
        Me.OpenImageButton.Location = New System.Drawing.Point(67, 110)
        Me.OpenImageButton.Name = "OpenImageButton"
        Me.OpenImageButton.Size = New System.Drawing.Size(55, 24)
        Me.OpenImageButton.TabIndex = 5
        Me.OpenImageButton.TabStop = True
        Me.OpenImageButton.Text = "Open"
        Me.OpenImageButton.TextImageSpacing = CType(0, Byte)
        Me.OpenImageButton.XIMage = Nothing
        '
        'EventsLabel
        '
        Me.EventsLabel.BackColor = System.Drawing.Color.Silver
        Me.EventsLabel.ForeColor = System.Drawing.Color.Black
        Me.EventsLabel.Location = New System.Drawing.Point(0, 168)
        Me.EventsLabel.Name = "EventsLabel"
        Me.EventsLabel.Padding = New System.Windows.Forms.Padding(3)
        Me.EventsLabel.Size = New System.Drawing.Size(180, 22)
        Me.EventsLabel.TabIndex = 14
        Me.EventsLabel.Text = "Events"
        Me.EventsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'FObject
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(734, 463)
        Me.Controls.Add(Me.ErrorPanel)
        Me.Controls.Add(Me.BottomPanel)
        Me.Controls.Add(Me.ActionsList)
        Me.Controls.Add(Me.SidePanel)
        Me.Controls.Add(Me.MainToolStrip)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MinimumSize = New System.Drawing.Size(742, 492)
        Me.Name = "FObject"
        Me.Text = "[Object]"
        Me.MainToolStrip.ResumeLayout(False)
        Me.MainToolStrip.PerformLayout()
        Me.ActionRightClickMenu.ResumeLayout(False)
        Me.BottomPanel.ResumeLayout(False)
        Me.ActionInfoPanel.ResumeLayout(False)
        Me.ErrorPanel.ResumeLayout(False)
        Me.ErrorPanel.PerformLayout()
        Me.SidePanel.ResumeLayout(False)
        Me.SidePanel.PerformLayout()
        Me.EventsListBacker.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MainToolStrip As System.Windows.Forms.ToolStrip
    Friend WithEvents DAcceptButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents TSS1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents DCancelButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents NameLabel As System.Windows.Forms.Label
    Friend WithEvents ImageLabel As System.Windows.Forms.Label
    Friend WithEvents ImagePreviewPanel As System.Windows.Forms.Panel
    Friend WithEvents OpenImageButton As DarkFlow.SexyButton
    Friend WithEvents EventsLabel As System.Windows.Forms.Label
    Friend WithEvents EventsList As System.Windows.Forms.ListBox
    Friend WithEvents AddEventButton As DarkFlow.SexyButton
    Friend WithEvents DeleteEventButton As DarkFlow.SexyButton
    Friend WithEvents ChangeEventButton As DarkFlow.SexyButton
    Friend WithEvents ActionsToAddTabControl As DarkFlow.SexyTabControl
    Friend WithEvents ActionsList As System.Windows.Forms.ListBox
    Friend WithEvents EditImageButton As DarkFlow.SexyButton
    Friend WithEvents NameTextBox As DarkFlow.SexyTextBox
    Friend WithEvents SidePanel As DarkFlow.DoubleBufferPanel
    Friend WithEvents ImageDropper As DarkFlow.SexyComboBox
    Friend WithEvents DeleteButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents TSS2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents EventsListBacker As DarkFlow.SuperPanel
    Friend WithEvents BottomPanel As System.Windows.Forms.Panel
    Friend WithEvents ActionInfoPanel As System.Windows.Forms.Panel
    Friend WithEvents ArgumentsListLabel As System.Windows.Forms.Label
    Friend WithEvents ArgumentsHeaderLabel As System.Windows.Forms.Label
    Friend WithEvents ActionNameLabel As System.Windows.Forms.Label
    Friend WithEvents SelectOneButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents SelectManyButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents SelectionSeperator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents SelectAllButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents ActionRightClickMenu As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents EditValuesRightClickButton As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RightClickSep1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents SelectOneRightClickButton As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SelectManyRightClickButton As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RightClickSep3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents CutActionRightClickButton As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CopyActionRightClickButton As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PasteActionBelowRightClickButton As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RightClickSep2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents DeleteActionRightClickButton As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ClearActionsRightClickButton As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DepthBox As DarkFlow.SexyNumeric
    Friend WithEvents DepthLabel As System.Windows.Forms.Label
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents CheckErrorsButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents ErrorPanel As DarkFlow.DoubleBufferPanel
    Friend WithEvents ErrorLabel As System.Windows.Forms.TextBox
    Friend WithEvents CloseErrors As DarkFlow.SexyButton
    Friend WithEvents SelectAllToolBtn As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
End Class
