<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FActionEditor
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FActionEditor))
        Dim TreeNode1 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Actions", 0, 0)
        Me.ImageLabel = New System.Windows.Forms.Label()
        Me.IconPanel = New System.Windows.Forms.Panel()
        Me.ImageDropper = New Dark_Flow.SexyComboBox()
        Me.ArgumentsListBacker = New Dark_Flow.SuperPanel()
        Me.ArgumentsList = New System.Windows.Forms.ListBox()
        Me.NoAppliesChecker = New Dark_Flow.SexyCheckBox()
        Me.DedentChecker = New Dark_Flow.SexyCheckBox()
        Me.ConditionalChecker = New Dark_Flow.SexyCheckBox()
        Me.IndentChecker = New Dark_Flow.SexyCheckBox()
        Me.CodeBox = New Dark_Flow.SexyTextBox()
        Me.ActionHeader = New Dark_Flow.SuperPanel()
        Me.AddButton = New Dark_Flow.SexyButton()
        Me.DeleteButton = New Dark_Flow.SexyButton()
        Me.SaveButton = New Dark_Flow.SexyButton()
        Me.MainNameLabel = New System.Windows.Forms.Label()
        Me.MainSplitter = New Dark_Flow.SexySplitter()
        Me.ActionsList = New Dark_Flow.SexyTree()
        Me.DisplayBox = New Dark_Flow.SexyTextBox()
        Me.DisplayLabel = New System.Windows.Forms.Label()
        Me.NameBox = New Dark_Flow.SexyTextBox()
        Me.NameLabel = New System.Windows.Forms.Label()
        Me.ArgumentPanel = New Dark_Flow.SuperPanel()
        Me.ArgumentAcceptButton = New Dark_Flow.SexyButton()
        Me.ArgumentTypeDropper = New Dark_Flow.SexyComboBox()
        Me.ArgumentNameBox = New Dark_Flow.SexyTextBox()
        Me.EditArgButton = New Dark_Flow.SexyButton()
        Me.DeleteArgButton = New Dark_Flow.SexyButton()
        Me.AddArgButton = New Dark_Flow.SexyButton()
        Me.BGChecker = New Dark_Flow.SexyCheckBox()
        Me.CategoryLabel = New System.Windows.Forms.Label()
        Me.CategoryDropper = New Dark_Flow.SexyComboBox()
        Me.ArgumentsListBacker.SuspendLayout()
        Me.ActionHeader.SuspendLayout()
        Me.ArgumentPanel.SuspendLayout()
        Me.SuspendLayout()
        '
        'ImageLabel
        '
        Me.ImageLabel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ImageLabel.AutoSize = True
        Me.ImageLabel.ForeColor = System.Drawing.Color.Gray
        Me.ImageLabel.Location = New System.Drawing.Point(422, 346)
        Me.ImageLabel.Name = "ImageLabel"
        Me.ImageLabel.Size = New System.Drawing.Size(43, 15)
        Me.ImageLabel.TabIndex = 11
        Me.ImageLabel.Text = "Image:"
        '
        'IconPanel
        '
        Me.IconPanel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.IconPanel.Location = New System.Drawing.Point(563, 355)
        Me.IconPanel.Name = "IconPanel"
        Me.IconPanel.Size = New System.Drawing.Size(32, 32)
        Me.IconPanel.TabIndex = 12
        '
        'ImageDropper
        '
        Me.ImageDropper.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ImageDropper.BackColor = System.Drawing.Color.Transparent
        Me.ImageDropper.BorderColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.ImageDropper.Image = CType(resources.GetObject("ImageDropper.Image"), System.Drawing.Image)
        Me.ImageDropper.Location = New System.Drawing.Point(424, 362)
        Me.ImageDropper.Name = "ImageDropper"
        Me.ImageDropper.ShadowColor = System.Drawing.Color.FromArgb(CType(CType(72, Byte), Integer), CType(CType(72, Byte), Integer), CType(CType(72, Byte), Integer))
        Me.ImageDropper.Size = New System.Drawing.Size(136, 25)
        Me.ImageDropper.TabIndex = 10
        '
        'ArgumentsListBacker
        '
        Me.ArgumentsListBacker.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ArgumentsListBacker.BackColor = System.Drawing.Color.Transparent
        Me.ArgumentsListBacker.BorderColor = System.Drawing.Color.Gray
        Me.ArgumentsListBacker.BorderRadius = CType(6, Byte)
        Me.ArgumentsListBacker.Controls.Add(Me.ArgumentsList)
        Me.ArgumentsListBacker.GradBottomColor = System.Drawing.Color.White
        Me.ArgumentsListBacker.GradTopColor = System.Drawing.Color.White
        Me.ArgumentsListBacker.Location = New System.Drawing.Point(598, 81)
        Me.ArgumentsListBacker.Name = "ArgumentsListBacker"
        Me.ArgumentsListBacker.Size = New System.Drawing.Size(182, 181)
        Me.ArgumentsListBacker.TabIndex = 9
        '
        'ArgumentsList
        '
        Me.ArgumentsList.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ArgumentsList.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ArgumentsList.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable
        Me.ArgumentsList.FormattingEnabled = True
        Me.ArgumentsList.ItemHeight = 24
        Me.ArgumentsList.Location = New System.Drawing.Point(4, 4)
        Me.ArgumentsList.Name = "ArgumentsList"
        Me.ArgumentsList.Size = New System.Drawing.Size(174, 168)
        Me.ArgumentsList.TabIndex = 8
        '
        'NoAppliesChecker
        '
        Me.NoAppliesChecker.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.NoAppliesChecker.BackColor = System.Drawing.Color.Transparent
        Me.NoAppliesChecker.Checked = False
        Me.NoAppliesChecker.DText = "No Applies"
        Me.NoAppliesChecker.Location = New System.Drawing.Point(324, 369)
        Me.NoAppliesChecker.Name = "NoAppliesChecker"
        Me.NoAppliesChecker.Size = New System.Drawing.Size(92, 18)
        Me.NoAppliesChecker.TabIndex = 7
        Me.NoAppliesChecker.Text = "No Applies"
        '
        'DedentChecker
        '
        Me.DedentChecker.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.DedentChecker.BackColor = System.Drawing.Color.Transparent
        Me.DedentChecker.Checked = False
        Me.DedentChecker.DText = "Dedent"
        Me.DedentChecker.Location = New System.Drawing.Point(292, 349)
        Me.DedentChecker.Name = "DedentChecker"
        Me.DedentChecker.Size = New System.Drawing.Size(62, 18)
        Me.DedentChecker.TabIndex = 5
        Me.DedentChecker.Text = "Dedent"
        '
        'ConditionalChecker
        '
        Me.ConditionalChecker.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ConditionalChecker.BackColor = System.Drawing.Color.Transparent
        Me.ConditionalChecker.Checked = False
        Me.ConditionalChecker.DText = "Conditional"
        Me.ConditionalChecker.Location = New System.Drawing.Point(232, 369)
        Me.ConditionalChecker.Name = "ConditionalChecker"
        Me.ConditionalChecker.Size = New System.Drawing.Size(92, 18)
        Me.ConditionalChecker.TabIndex = 6
        Me.ConditionalChecker.Text = "Conditional"
        '
        'IndentChecker
        '
        Me.IndentChecker.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.IndentChecker.BackColor = System.Drawing.Color.Transparent
        Me.IndentChecker.Checked = False
        Me.IndentChecker.DText = "Indent"
        Me.IndentChecker.Location = New System.Drawing.Point(232, 349)
        Me.IndentChecker.Name = "IndentChecker"
        Me.IndentChecker.Size = New System.Drawing.Size(60, 18)
        Me.IndentChecker.TabIndex = 4
        Me.IndentChecker.Text = "Indent"
        '
        'CodeBox
        '
        Me.CodeBox.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CodeBox.BackColor = System.Drawing.Color.Transparent
        Me.CodeBox.BorderColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.CodeBox.Location = New System.Drawing.Point(232, 81)
        Me.CodeBox.MultiLine = True
        Me.CodeBox.Name = "CodeBox"
        Me.CodeBox.ShadowColor = System.Drawing.Color.FromArgb(CType(CType(72, Byte), Integer), CType(CType(72, Byte), Integer), CType(CType(72, Byte), Integer))
        Me.CodeBox.Size = New System.Drawing.Size(363, 262)
        Me.CodeBox.TabIndex = 3
        Me.CodeBox.UseSystemPasswordChar = False
        '
        'ActionHeader
        '
        Me.ActionHeader.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ActionHeader.BackColor = System.Drawing.Color.Transparent
        Me.ActionHeader.BorderColor = System.Drawing.Color.FromArgb(CType(CType(48, Byte), Integer), CType(CType(48, Byte), Integer), CType(CType(48, Byte), Integer))
        Me.ActionHeader.BorderRadius = CType(6, Byte)
        Me.ActionHeader.Controls.Add(Me.AddButton)
        Me.ActionHeader.Controls.Add(Me.DeleteButton)
        Me.ActionHeader.Controls.Add(Me.SaveButton)
        Me.ActionHeader.Controls.Add(Me.MainNameLabel)
        Me.ActionHeader.GradBottomColor = System.Drawing.Color.FromArgb(CType(CType(184, Byte), Integer), CType(CType(184, Byte), Integer), CType(CType(184, Byte), Integer))
        Me.ActionHeader.GradTopColor = System.Drawing.Color.FromArgb(CType(CType(210, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(210, Byte), Integer))
        Me.ActionHeader.Location = New System.Drawing.Point(232, 3)
        Me.ActionHeader.Name = "ActionHeader"
        Me.ActionHeader.Size = New System.Drawing.Size(548, 34)
        Me.ActionHeader.TabIndex = 2
        '
        'AddButton
        '
        Me.AddButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.AddButton.BackColor = System.Drawing.Color.Transparent
        Me.AddButton.DText = "Add"
        Me.AddButton.ForeColor = System.Drawing.Color.Black
        Me.AddButton.ImageOnTop = False
        Me.AddButton.LeftAligned = False
        Me.AddButton.Location = New System.Drawing.Point(323, 4)
        Me.AddButton.Name = "AddButton"
        Me.AddButton.ShrinkMyIcon = True
        Me.AddButton.Size = New System.Drawing.Size(70, 26)
        Me.AddButton.TabIndex = 5
        Me.AddButton.TabStop = True
        Me.AddButton.Text = "Add"
        Me.AddButton.TextImageSpacing = CType(0, Byte)
        Me.AddButton.XIMage = Global.Dark_Flow.My.Resources.Resources.AddIcon
        '
        'DeleteButton
        '
        Me.DeleteButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DeleteButton.BackColor = System.Drawing.Color.Transparent
        Me.DeleteButton.DText = "Delete"
        Me.DeleteButton.ForeColor = System.Drawing.Color.Black
        Me.DeleteButton.ImageOnTop = False
        Me.DeleteButton.LeftAligned = False
        Me.DeleteButton.Location = New System.Drawing.Point(397, 4)
        Me.DeleteButton.Name = "DeleteButton"
        Me.DeleteButton.ShrinkMyIcon = True
        Me.DeleteButton.Size = New System.Drawing.Size(80, 26)
        Me.DeleteButton.TabIndex = 4
        Me.DeleteButton.TabStop = True
        Me.DeleteButton.Text = "Delete"
        Me.DeleteButton.TextImageSpacing = CType(0, Byte)
        Me.DeleteButton.XIMage = Global.Dark_Flow.My.Resources.Resources.DeleteIcon
        '
        'SaveButton
        '
        Me.SaveButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SaveButton.BackColor = System.Drawing.Color.Transparent
        Me.SaveButton.DText = "Save"
        Me.SaveButton.ForeColor = System.Drawing.Color.Black
        Me.SaveButton.ImageOnTop = False
        Me.SaveButton.LeftAligned = False
        Me.SaveButton.Location = New System.Drawing.Point(481, 4)
        Me.SaveButton.Name = "SaveButton"
        Me.SaveButton.ShrinkMyIcon = True
        Me.SaveButton.Size = New System.Drawing.Size(64, 26)
        Me.SaveButton.TabIndex = 3
        Me.SaveButton.TabStop = True
        Me.SaveButton.Text = "Save"
        Me.SaveButton.TextImageSpacing = CType(0, Byte)
        Me.SaveButton.XIMage = Global.Dark_Flow.My.Resources.Resources.SaveFileIcon
        '
        'MainNameLabel
        '
        Me.MainNameLabel.AutoSize = True
        Me.MainNameLabel.BackColor = System.Drawing.Color.Transparent
        Me.MainNameLabel.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MainNameLabel.Location = New System.Drawing.Point(3, 3)
        Me.MainNameLabel.Name = "MainNameLabel"
        Me.MainNameLabel.Size = New System.Drawing.Size(36, 25)
        Me.MainNameLabel.TabIndex = 3
        Me.MainNameLabel.Text = "[...]"
        '
        'MainSplitter
        '
        Me.MainSplitter.Location = New System.Drawing.Point(224, 0)
        Me.MainSplitter.MaximumSize = New System.Drawing.Size(224, 0)
        Me.MainSplitter.MinExtra = 224
        Me.MainSplitter.MinSize = 224
        Me.MainSplitter.Name = "MainSplitter"
        Me.MainSplitter.Size = New System.Drawing.Size(5, 397)
        Me.MainSplitter.TabIndex = 1
        Me.MainSplitter.TabStop = False
        '
        'ActionsList
        '
        Me.ActionsList.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ActionsList.Dock = System.Windows.Forms.DockStyle.Left
        Me.ActionsList.DrawMode = System.Windows.Forms.TreeViewDrawMode.OwnerDrawText
        Me.ActionsList.ItemHeight = 22
        Me.ActionsList.Location = New System.Drawing.Point(0, 0)
        Me.ActionsList.Name = "ActionsList"
        TreeNode1.ImageIndex = 0
        TreeNode1.Name = "MasterActionsNode"
        TreeNode1.SelectedImageIndex = 0
        TreeNode1.Text = "Actions"
        Me.ActionsList.Nodes.AddRange(New System.Windows.Forms.TreeNode() {TreeNode1})
        Me.ActionsList.Size = New System.Drawing.Size(224, 397)
        Me.ActionsList.TabIndex = 0
        '
        'DisplayBox
        '
        Me.DisplayBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DisplayBox.BackColor = System.Drawing.Color.Transparent
        Me.DisplayBox.BorderColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.DisplayBox.Location = New System.Drawing.Point(363, 55)
        Me.DisplayBox.MultiLine = False
        Me.DisplayBox.Name = "DisplayBox"
        Me.DisplayBox.ShadowColor = System.Drawing.Color.FromArgb(CType(CType(72, Byte), Integer), CType(CType(72, Byte), Integer), CType(CType(72, Byte), Integer))
        Me.DisplayBox.Size = New System.Drawing.Size(232, 24)
        Me.DisplayBox.TabIndex = 13
        Me.DisplayBox.UseSystemPasswordChar = False
        '
        'DisplayLabel
        '
        Me.DisplayLabel.AutoSize = True
        Me.DisplayLabel.ForeColor = System.Drawing.Color.Gray
        Me.DisplayLabel.Location = New System.Drawing.Point(360, 38)
        Me.DisplayLabel.Name = "DisplayLabel"
        Me.DisplayLabel.Size = New System.Drawing.Size(48, 15)
        Me.DisplayLabel.TabIndex = 14
        Me.DisplayLabel.Text = "Display:"
        '
        'NameBox
        '
        Me.NameBox.BackColor = System.Drawing.Color.Transparent
        Me.NameBox.BorderColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.NameBox.Location = New System.Drawing.Point(232, 55)
        Me.NameBox.MultiLine = False
        Me.NameBox.Name = "NameBox"
        Me.NameBox.ShadowColor = System.Drawing.Color.FromArgb(CType(CType(72, Byte), Integer), CType(CType(72, Byte), Integer), CType(CType(72, Byte), Integer))
        Me.NameBox.Size = New System.Drawing.Size(128, 24)
        Me.NameBox.TabIndex = 15
        Me.NameBox.UseSystemPasswordChar = False
        '
        'NameLabel
        '
        Me.NameLabel.AutoSize = True
        Me.NameLabel.ForeColor = System.Drawing.Color.Gray
        Me.NameLabel.Location = New System.Drawing.Point(229, 38)
        Me.NameLabel.Name = "NameLabel"
        Me.NameLabel.Size = New System.Drawing.Size(42, 15)
        Me.NameLabel.TabIndex = 16
        Me.NameLabel.Text = "Name:"
        '
        'ArgumentPanel
        '
        Me.ArgumentPanel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ArgumentPanel.BackColor = System.Drawing.Color.Transparent
        Me.ArgumentPanel.BorderColor = System.Drawing.Color.FromArgb(CType(CType(48, Byte), Integer), CType(CType(48, Byte), Integer), CType(CType(48, Byte), Integer))
        Me.ArgumentPanel.BorderRadius = CType(6, Byte)
        Me.ArgumentPanel.Controls.Add(Me.ArgumentAcceptButton)
        Me.ArgumentPanel.Controls.Add(Me.ArgumentTypeDropper)
        Me.ArgumentPanel.Controls.Add(Me.ArgumentNameBox)
        Me.ArgumentPanel.GradBottomColor = System.Drawing.Color.FromArgb(CType(CType(184, Byte), Integer), CType(CType(184, Byte), Integer), CType(CType(184, Byte), Integer))
        Me.ArgumentPanel.GradTopColor = System.Drawing.Color.FromArgb(CType(CType(210, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(210, Byte), Integer))
        Me.ArgumentPanel.Location = New System.Drawing.Point(598, 295)
        Me.ArgumentPanel.Name = "ArgumentPanel"
        Me.ArgumentPanel.Size = New System.Drawing.Size(182, 92)
        Me.ArgumentPanel.TabIndex = 17
        Me.ArgumentPanel.Visible = False
        '
        'ArgumentAcceptButton
        '
        Me.ArgumentAcceptButton.BackColor = System.Drawing.Color.Transparent
        Me.ArgumentAcceptButton.DText = "Accept"
        Me.ArgumentAcceptButton.ForeColor = System.Drawing.Color.Black
        Me.ArgumentAcceptButton.ImageOnTop = False
        Me.ArgumentAcceptButton.LeftAligned = False
        Me.ArgumentAcceptButton.Location = New System.Drawing.Point(84, 57)
        Me.ArgumentAcceptButton.Name = "ArgumentAcceptButton"
        Me.ArgumentAcceptButton.ShrinkMyIcon = False
        Me.ArgumentAcceptButton.Size = New System.Drawing.Size(86, 30)
        Me.ArgumentAcceptButton.TabIndex = 5
        Me.ArgumentAcceptButton.TabStop = True
        Me.ArgumentAcceptButton.Text = "Accept"
        Me.ArgumentAcceptButton.TextImageSpacing = CType(0, Byte)
        Me.ArgumentAcceptButton.XIMage = Global.Dark_Flow.My.Resources.Resources.AcceptIcon
        '
        'ArgumentTypeDropper
        '
        Me.ArgumentTypeDropper.BackColor = System.Drawing.Color.Transparent
        Me.ArgumentTypeDropper.BorderColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.ArgumentTypeDropper.Image = CType(resources.GetObject("ArgumentTypeDropper.Image"), System.Drawing.Image)
        Me.ArgumentTypeDropper.Location = New System.Drawing.Point(4, 30)
        Me.ArgumentTypeDropper.Name = "ArgumentTypeDropper"
        Me.ArgumentTypeDropper.ShadowColor = System.Drawing.Color.FromArgb(CType(CType(72, Byte), Integer), CType(CType(72, Byte), Integer), CType(CType(72, Byte), Integer))
        Me.ArgumentTypeDropper.Size = New System.Drawing.Size(166, 24)
        Me.ArgumentTypeDropper.TabIndex = 5
        '
        'ArgumentNameBox
        '
        Me.ArgumentNameBox.BackColor = System.Drawing.Color.Transparent
        Me.ArgumentNameBox.BorderColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.ArgumentNameBox.Location = New System.Drawing.Point(4, 4)
        Me.ArgumentNameBox.MultiLine = False
        Me.ArgumentNameBox.Name = "ArgumentNameBox"
        Me.ArgumentNameBox.ShadowColor = System.Drawing.Color.Black
        Me.ArgumentNameBox.Size = New System.Drawing.Size(166, 24)
        Me.ArgumentNameBox.TabIndex = 21
        Me.ArgumentNameBox.UseSystemPasswordChar = False
        '
        'EditArgButton
        '
        Me.EditArgButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.EditArgButton.BackColor = System.Drawing.Color.Transparent
        Me.EditArgButton.DText = ""
        Me.EditArgButton.ForeColor = System.Drawing.Color.Black
        Me.EditArgButton.ImageOnTop = False
        Me.EditArgButton.LeftAligned = True
        Me.EditArgButton.Location = New System.Drawing.Point(715, 264)
        Me.EditArgButton.Name = "EditArgButton"
        Me.EditArgButton.ShrinkMyIcon = True
        Me.EditArgButton.Size = New System.Drawing.Size(32, 23)
        Me.EditArgButton.TabIndex = 26
        Me.EditArgButton.TabStop = True
        Me.EditArgButton.TextImageSpacing = CType(0, Byte)
        Me.EditArgButton.XIMage = Global.Dark_Flow.My.Resources.Resources.EditIcon
        '
        'DeleteArgButton
        '
        Me.DeleteArgButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DeleteArgButton.BackColor = System.Drawing.Color.Transparent
        Me.DeleteArgButton.DText = ""
        Me.DeleteArgButton.ForeColor = System.Drawing.Color.Black
        Me.DeleteArgButton.ImageOnTop = False
        Me.DeleteArgButton.LeftAligned = True
        Me.DeleteArgButton.Location = New System.Drawing.Point(748, 264)
        Me.DeleteArgButton.Name = "DeleteArgButton"
        Me.DeleteArgButton.ShrinkMyIcon = True
        Me.DeleteArgButton.Size = New System.Drawing.Size(32, 23)
        Me.DeleteArgButton.TabIndex = 25
        Me.DeleteArgButton.TabStop = True
        Me.DeleteArgButton.TextImageSpacing = CType(0, Byte)
        Me.DeleteArgButton.XIMage = Global.Dark_Flow.My.Resources.Resources.DeleteIcon
        '
        'AddArgButton
        '
        Me.AddArgButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.AddArgButton.BackColor = System.Drawing.Color.Transparent
        Me.AddArgButton.DText = ""
        Me.AddArgButton.ForeColor = System.Drawing.Color.Black
        Me.AddArgButton.ImageOnTop = False
        Me.AddArgButton.LeftAligned = True
        Me.AddArgButton.Location = New System.Drawing.Point(682, 264)
        Me.AddArgButton.Name = "AddArgButton"
        Me.AddArgButton.ShrinkMyIcon = True
        Me.AddArgButton.Size = New System.Drawing.Size(32, 23)
        Me.AddArgButton.TabIndex = 24
        Me.AddArgButton.TabStop = True
        Me.AddArgButton.TextImageSpacing = CType(0, Byte)
        Me.AddArgButton.XIMage = Global.Dark_Flow.My.Resources.Resources.AddIcon
        '
        'BGChecker
        '
        Me.BGChecker.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.BGChecker.BackColor = System.Drawing.Color.Transparent
        Me.BGChecker.Checked = False
        Me.BGChecker.DText = "BG"
        Me.BGChecker.Location = New System.Drawing.Point(354, 349)
        Me.BGChecker.Name = "BGChecker"
        Me.BGChecker.Size = New System.Drawing.Size(62, 18)
        Me.BGChecker.TabIndex = 6
        Me.BGChecker.Text = "BG"
        '
        'CategoryLabel
        '
        Me.CategoryLabel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CategoryLabel.AutoSize = True
        Me.CategoryLabel.ForeColor = System.Drawing.Color.Gray
        Me.CategoryLabel.Location = New System.Drawing.Point(595, 38)
        Me.CategoryLabel.Name = "CategoryLabel"
        Me.CategoryLabel.Size = New System.Drawing.Size(58, 15)
        Me.CategoryLabel.TabIndex = 28
        Me.CategoryLabel.Text = "Category:"
        '
        'CategoryDropper
        '
        Me.CategoryDropper.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CategoryDropper.BackColor = System.Drawing.Color.Transparent
        Me.CategoryDropper.BorderColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.CategoryDropper.Image = CType(resources.GetObject("CategoryDropper.Image"), System.Drawing.Image)
        Me.CategoryDropper.Location = New System.Drawing.Point(598, 55)
        Me.CategoryDropper.Name = "CategoryDropper"
        Me.CategoryDropper.ShadowColor = System.Drawing.Color.FromArgb(CType(CType(72, Byte), Integer), CType(CType(72, Byte), Integer), CType(CType(72, Byte), Integer))
        Me.CategoryDropper.Size = New System.Drawing.Size(182, 24)
        Me.CategoryDropper.TabIndex = 29
        '
        'FActionEditor
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(784, 397)
        Me.Controls.Add(Me.CategoryDropper)
        Me.Controls.Add(Me.CategoryLabel)
        Me.Controls.Add(Me.BGChecker)
        Me.Controls.Add(Me.EditArgButton)
        Me.Controls.Add(Me.DeleteArgButton)
        Me.Controls.Add(Me.AddArgButton)
        Me.Controls.Add(Me.ArgumentPanel)
        Me.Controls.Add(Me.NameLabel)
        Me.Controls.Add(Me.NameBox)
        Me.Controls.Add(Me.DisplayLabel)
        Me.Controls.Add(Me.DisplayBox)
        Me.Controls.Add(Me.IconPanel)
        Me.Controls.Add(Me.ImageLabel)
        Me.Controls.Add(Me.ImageDropper)
        Me.Controls.Add(Me.ArgumentsListBacker)
        Me.Controls.Add(Me.NoAppliesChecker)
        Me.Controls.Add(Me.DedentChecker)
        Me.Controls.Add(Me.ConditionalChecker)
        Me.Controls.Add(Me.IndentChecker)
        Me.Controls.Add(Me.CodeBox)
        Me.Controls.Add(Me.ActionHeader)
        Me.Controls.Add(Me.MainSplitter)
        Me.Controls.Add(Me.ActionsList)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MinimumSize = New System.Drawing.Size(792, 424)
        Me.Name = "FActionEditor"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Action Editor"
        Me.ArgumentsListBacker.ResumeLayout(False)
        Me.ActionHeader.ResumeLayout(False)
        Me.ActionHeader.PerformLayout()
        Me.ArgumentPanel.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ActionsList As Dark_Flow.SexyTree
    Friend WithEvents MainSplitter As Dark_Flow.SexySplitter
    Friend WithEvents ActionHeader As Dark_Flow.SuperPanel
    Friend WithEvents MainNameLabel As System.Windows.Forms.Label
    Friend WithEvents SaveButton As Dark_Flow.SexyButton
    Friend WithEvents CodeBox As Dark_Flow.SexyTextBox
    Friend WithEvents IndentChecker As Dark_Flow.SexyCheckBox
    Friend WithEvents DedentChecker As Dark_Flow.SexyCheckBox
    Friend WithEvents NoAppliesChecker As Dark_Flow.SexyCheckBox
    Friend WithEvents ConditionalChecker As Dark_Flow.SexyCheckBox
    Friend WithEvents ArgumentsList As System.Windows.Forms.ListBox
    Friend WithEvents ArgumentsListBacker As Dark_Flow.SuperPanel
    Friend WithEvents ImageDropper As Dark_Flow.SexyComboBox
    Friend WithEvents ImageLabel As System.Windows.Forms.Label
    Friend WithEvents IconPanel As System.Windows.Forms.Panel
    Friend WithEvents DisplayBox As Dark_Flow.SexyTextBox
    Friend WithEvents DisplayLabel As System.Windows.Forms.Label
    Friend WithEvents NameBox As Dark_Flow.SexyTextBox
    Friend WithEvents NameLabel As System.Windows.Forms.Label
    Friend WithEvents ArgumentPanel As Dark_Flow.SuperPanel
    Friend WithEvents ArgumentAcceptButton As Dark_Flow.SexyButton
    Friend WithEvents ArgumentTypeDropper As Dark_Flow.SexyComboBox
    Friend WithEvents ArgumentNameBox As Dark_Flow.SexyTextBox
    Friend WithEvents EditArgButton As Dark_Flow.SexyButton
    Friend WithEvents DeleteArgButton As Dark_Flow.SexyButton
    Friend WithEvents AddArgButton As Dark_Flow.SexyButton
    Friend WithEvents BGChecker As Dark_Flow.SexyCheckBox
    Friend WithEvents CategoryLabel As System.Windows.Forms.Label
    Friend WithEvents CategoryDropper As Dark_Flow.SexyComboBox
    Friend WithEvents DeleteButton As Dark_Flow.SexyButton
    Friend WithEvents AddButton As Dark_Flow.SexyButton
End Class
