<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FScene
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FScene))
        Me.MainToolStrip = New System.Windows.Forms.ToolStrip()
        Me.DAcceptButton = New System.Windows.Forms.ToolStripButton()
        Me.TSS1 = New System.Windows.Forms.ToolStripSeparator()
        Me.DCancelButton = New System.Windows.Forms.ToolStripButton()
        Me.TSS2 = New System.Windows.Forms.ToolStripSeparator()
        Me.DeleteButton = New System.Windows.Forms.ToolStripButton()
        Me.RightClickMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.RDeleteButton = New System.Windows.Forms.ToolStripMenuItem()
        Me.ROpenObjectButton = New System.Windows.Forms.ToolStripMenuItem()
        Me.RSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.RMoveToPositionButton = New System.Windows.Forms.ToolStripMenuItem()
        Me.DesignPanel = New Dark_Flow.DoubleBufferPanel()
        Me.BottomBanner = New Dark_Flow.DoubleBufferPanel()
        Me.CoOrdinatesBanner = New Dark_Flow.DoubleBufferPanel()
        Me.SnapYTextBox = New Dark_Flow.SexyTextBox()
        Me.SnapXTextBox = New Dark_Flow.SexyTextBox()
        Me.MouseDescLabel = New System.Windows.Forms.Label()
        Me.MouseLabel = New System.Windows.Forms.Label()
        Me.ShowGridChecker = New Dark_Flow.SexyCheckBox()
        Me.SnapYLabel = New System.Windows.Forms.Label()
        Me.SnapXLabel = New System.Windows.Forms.Label()
        Me.MouseSnapDescLabel = New System.Windows.Forms.Label()
        Me.SnapToGridChecker = New Dark_Flow.SexyCheckBox()
        Me.MouseSnapLabel = New System.Windows.Forms.Label()
        Me.Spacer = New Dark_Flow.DoubleBufferPanel()
        Me.UseRightClickMenuChecker = New Dark_Flow.SexyCheckBox()
        Me.ObjectBox = New Dark_Flow.SexyGroupBox()
        Me.ObjectPreviewPanel = New Dark_Flow.DoubleBufferPanel()
        Me.ObjectDropper = New Dark_Flow.SexyComboBox()
        Me.OpenObjectButton = New Dark_Flow.SexyButton()
        Me.SidePanel = New Dark_Flow.DoubleBufferPanel()
        Me.NameTextBox = New Dark_Flow.SexyTextBox()
        Me.ViewSettingsLabel = New System.Windows.Forms.Label()
        Me.ForegroundDropper = New Dark_Flow.SexyComboBox()
        Me.NameLabel = New System.Windows.Forms.Label()
        Me.ForegroundLabel = New System.Windows.Forms.Label()
        Me.ViewWidthLabel = New System.Windows.Forms.Label()
        Me.BackgroundDropper = New Dark_Flow.SexyComboBox()
        Me.ViewWidthSelector = New Dark_Flow.SexyNumeric()
        Me.BackgroundLabel = New System.Windows.Forms.Label()
        Me.ViewHeightLabel = New System.Windows.Forms.Label()
        Me.BGColorLabel = New System.Windows.Forms.Label()
        Me.ViewHeightSelector = New Dark_Flow.SexyNumeric()
        Me.BGColorDisplayer = New System.Windows.Forms.Panel()
        Me.ViewXLabel = New System.Windows.Forms.Label()
        Me.SceneHeightSelector = New Dark_Flow.SexyNumeric()
        Me.ViewXSelector = New Dark_Flow.SexyNumeric()
        Me.SceneHeightLabel = New System.Windows.Forms.Label()
        Me.ViewYLabel = New System.Windows.Forms.Label()
        Me.SceneWidthSelector = New Dark_Flow.SexyNumeric()
        Me.ViewYSelector = New Dark_Flow.SexyNumeric()
        Me.SceneWidthLabel = New System.Windows.Forms.Label()
        Me.SceneSettingsLabel = New System.Windows.Forms.Label()
        Me.MainToolStrip.SuspendLayout()
        Me.RightClickMenu.SuspendLayout()
        Me.BottomBanner.SuspendLayout()
        Me.CoOrdinatesBanner.SuspendLayout()
        Me.Spacer.SuspendLayout()
        Me.ObjectBox.SuspendLayout()
        Me.SidePanel.SuspendLayout()
        Me.SuspendLayout()
        '
        'MainToolStrip
        '
        Me.MainToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DAcceptButton, Me.TSS1, Me.DCancelButton, Me.TSS2, Me.DeleteButton})
        Me.MainToolStrip.Location = New System.Drawing.Point(0, 0)
        Me.MainToolStrip.Name = "MainToolStrip"
        Me.MainToolStrip.Size = New System.Drawing.Size(664, 25)
        Me.MainToolStrip.TabIndex = 0
        '
        'DAcceptButton
        '
        Me.DAcceptButton.Image = Global.Dark_Flow.My.Resources.Resources.AcceptIcon
        Me.DAcceptButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.DAcceptButton.Name = "DAcceptButton"
        Me.DAcceptButton.Size = New System.Drawing.Size(64, 22)
        Me.DAcceptButton.Text = "Accept"
        '
        'TSS1
        '
        Me.TSS1.Name = "TSS1"
        Me.TSS1.Size = New System.Drawing.Size(6, 25)
        '
        'DCancelButton
        '
        Me.DCancelButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.DCancelButton.Name = "DCancelButton"
        Me.DCancelButton.Size = New System.Drawing.Size(47, 22)
        Me.DCancelButton.Text = "Cancel"
        '
        'TSS2
        '
        Me.TSS2.Name = "TSS2"
        Me.TSS2.Size = New System.Drawing.Size(6, 25)
        '
        'DeleteButton
        '
        Me.DeleteButton.Image = Global.Dark_Flow.My.Resources.Resources.DeleteIcon
        Me.DeleteButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.DeleteButton.Name = "DeleteButton"
        Me.DeleteButton.Size = New System.Drawing.Size(60, 22)
        Me.DeleteButton.Text = "Delete"
        '
        'RightClickMenu
        '
        Me.RightClickMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.RDeleteButton, Me.ROpenObjectButton, Me.RSeparator, Me.RMoveToPositionButton})
        Me.RightClickMenu.Name = "RightClickMenu"
        Me.RightClickMenu.Size = New System.Drawing.Size(174, 76)
        '
        'RDeleteButton
        '
        Me.RDeleteButton.Image = Global.Dark_Flow.My.Resources.Resources.DeleteIcon
        Me.RDeleteButton.Name = "RDeleteButton"
        Me.RDeleteButton.Size = New System.Drawing.Size(173, 22)
        Me.RDeleteButton.Text = "Delete"
        '
        'ROpenObjectButton
        '
        Me.ROpenObjectButton.Image = Global.Dark_Flow.My.Resources.Resources.OpenFileIcon
        Me.ROpenObjectButton.Name = "ROpenObjectButton"
        Me.ROpenObjectButton.Size = New System.Drawing.Size(173, 22)
        Me.ROpenObjectButton.Text = "Open Object"
        '
        'RSeparator
        '
        Me.RSeparator.Name = "RSeparator"
        Me.RSeparator.Size = New System.Drawing.Size(170, 6)
        Me.RSeparator.Visible = False
        '
        'RMoveToPositionButton
        '
        Me.RMoveToPositionButton.Name = "RMoveToPositionButton"
        Me.RMoveToPositionButton.Size = New System.Drawing.Size(173, 22)
        Me.RMoveToPositionButton.Text = "Move to Position..."
        Me.RMoveToPositionButton.Visible = False
        '
        'DesignPanel
        '
        Me.DesignPanel.BackColor = System.Drawing.Color.White
        Me.DesignPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DesignPanel.Location = New System.Drawing.Point(180, 25)
        Me.DesignPanel.Name = "DesignPanel"
        Me.DesignPanel.Size = New System.Drawing.Size(484, 289)
        Me.DesignPanel.TabIndex = 4
        '
        'BottomBanner
        '
        Me.BottomBanner.BackgroundImage = Global.Dark_Flow.My.Resources.Resources.GenericGradient
        Me.BottomBanner.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BottomBanner.Controls.Add(Me.CoOrdinatesBanner)
        Me.BottomBanner.Controls.Add(Me.Spacer)
        Me.BottomBanner.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.BottomBanner.Location = New System.Drawing.Point(180, 314)
        Me.BottomBanner.Name = "BottomBanner"
        Me.BottomBanner.Size = New System.Drawing.Size(484, 134)
        Me.BottomBanner.TabIndex = 0
        '
        'CoOrdinatesBanner
        '
        Me.CoOrdinatesBanner.BackgroundImage = Global.Dark_Flow.My.Resources.Resources.InverseGradient
        Me.CoOrdinatesBanner.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.CoOrdinatesBanner.Controls.Add(Me.SnapYTextBox)
        Me.CoOrdinatesBanner.Controls.Add(Me.SnapXTextBox)
        Me.CoOrdinatesBanner.Controls.Add(Me.MouseDescLabel)
        Me.CoOrdinatesBanner.Controls.Add(Me.MouseLabel)
        Me.CoOrdinatesBanner.Controls.Add(Me.ShowGridChecker)
        Me.CoOrdinatesBanner.Controls.Add(Me.SnapYLabel)
        Me.CoOrdinatesBanner.Controls.Add(Me.SnapXLabel)
        Me.CoOrdinatesBanner.Controls.Add(Me.MouseSnapDescLabel)
        Me.CoOrdinatesBanner.Controls.Add(Me.SnapToGridChecker)
        Me.CoOrdinatesBanner.Controls.Add(Me.MouseSnapLabel)
        Me.CoOrdinatesBanner.Dock = System.Windows.Forms.DockStyle.Right
        Me.CoOrdinatesBanner.Location = New System.Drawing.Point(304, 0)
        Me.CoOrdinatesBanner.Name = "CoOrdinatesBanner"
        Me.CoOrdinatesBanner.Size = New System.Drawing.Size(180, 134)
        Me.CoOrdinatesBanner.TabIndex = 0
        '
        'SnapYTextBox
        '
        Me.SnapYTextBox.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SnapYTextBox.BackColor = System.Drawing.Color.Transparent
        Me.SnapYTextBox.BorderColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.SnapYTextBox.Location = New System.Drawing.Point(122, 105)
        Me.SnapYTextBox.MultiLine = False
        Me.SnapYTextBox.Name = "SnapYTextBox"
        Me.SnapYTextBox.ShadowColor = System.Drawing.Color.FromArgb(CType(CType(72, Byte), Integer), CType(CType(72, Byte), Integer), CType(CType(72, Byte), Integer))
        Me.SnapYTextBox.Size = New System.Drawing.Size(52, 23)
        Me.SnapYTextBox.TabIndex = 11
        Me.SnapYTextBox.UseSystemPasswordChar = False
        '
        'SnapXTextBox
        '
        Me.SnapXTextBox.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SnapXTextBox.BackColor = System.Drawing.Color.Transparent
        Me.SnapXTextBox.BorderColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.SnapXTextBox.Location = New System.Drawing.Point(122, 80)
        Me.SnapXTextBox.MultiLine = False
        Me.SnapXTextBox.Name = "SnapXTextBox"
        Me.SnapXTextBox.ShadowColor = System.Drawing.Color.FromArgb(CType(CType(72, Byte), Integer), CType(CType(72, Byte), Integer), CType(CType(72, Byte), Integer))
        Me.SnapXTextBox.Size = New System.Drawing.Size(52, 23)
        Me.SnapXTextBox.TabIndex = 8
        Me.SnapXTextBox.UseSystemPasswordChar = False
        '
        'MouseDescLabel
        '
        Me.MouseDescLabel.AutoSize = True
        Me.MouseDescLabel.BackColor = System.Drawing.Color.Transparent
        Me.MouseDescLabel.ForeColor = System.Drawing.Color.Silver
        Me.MouseDescLabel.Location = New System.Drawing.Point(9, 4)
        Me.MouseDescLabel.Name = "MouseDescLabel"
        Me.MouseDescLabel.Size = New System.Drawing.Size(46, 15)
        Me.MouseDescLabel.TabIndex = 0
        Me.MouseDescLabel.Text = "Mouse:"
        '
        'MouseLabel
        '
        Me.MouseLabel.AutoSize = True
        Me.MouseLabel.BackColor = System.Drawing.Color.Transparent
        Me.MouseLabel.ForeColor = System.Drawing.Color.White
        Me.MouseLabel.Location = New System.Drawing.Point(106, 4)
        Me.MouseLabel.Name = "MouseLabel"
        Me.MouseLabel.Size = New System.Drawing.Size(25, 15)
        Me.MouseLabel.TabIndex = 2
        Me.MouseLabel.Text = "0, 0"
        '
        'ShowGridChecker
        '
        Me.ShowGridChecker.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ShowGridChecker.BackColor = System.Drawing.Color.Transparent
        Me.ShowGridChecker.Checked = False
        Me.ShowGridChecker.DText = "Show Grid"
        Me.ShowGridChecker.ForeColor = System.Drawing.Color.Silver
        Me.ShowGridChecker.Location = New System.Drawing.Point(12, 64)
        Me.ShowGridChecker.Name = "ShowGridChecker"
        Me.ShowGridChecker.Size = New System.Drawing.Size(156, 18)
        Me.ShowGridChecker.TabIndex = 9
        Me.ShowGridChecker.Text = "Show Grid"
        '
        'SnapYLabel
        '
        Me.SnapYLabel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SnapYLabel.AutoSize = True
        Me.SnapYLabel.BackColor = System.Drawing.Color.Transparent
        Me.SnapYLabel.ForeColor = System.Drawing.Color.Silver
        Me.SnapYLabel.Location = New System.Drawing.Point(40, 111)
        Me.SnapYLabel.Name = "SnapYLabel"
        Me.SnapYLabel.Size = New System.Drawing.Size(46, 15)
        Me.SnapYLabel.TabIndex = 10
        Me.SnapYLabel.Text = "Snap Y:"
        '
        'SnapXLabel
        '
        Me.SnapXLabel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SnapXLabel.AutoSize = True
        Me.SnapXLabel.BackColor = System.Drawing.Color.Transparent
        Me.SnapXLabel.ForeColor = System.Drawing.Color.Silver
        Me.SnapXLabel.Location = New System.Drawing.Point(40, 86)
        Me.SnapXLabel.Name = "SnapXLabel"
        Me.SnapXLabel.Size = New System.Drawing.Size(46, 15)
        Me.SnapXLabel.TabIndex = 7
        Me.SnapXLabel.Text = "Snap X:"
        '
        'MouseSnapDescLabel
        '
        Me.MouseSnapDescLabel.AutoSize = True
        Me.MouseSnapDescLabel.BackColor = System.Drawing.Color.Transparent
        Me.MouseSnapDescLabel.ForeColor = System.Drawing.Color.Silver
        Me.MouseSnapDescLabel.Location = New System.Drawing.Point(9, 21)
        Me.MouseSnapDescLabel.Name = "MouseSnapDescLabel"
        Me.MouseSnapDescLabel.Size = New System.Drawing.Size(82, 15)
        Me.MouseSnapDescLabel.TabIndex = 1
        Me.MouseSnapDescLabel.Text = "Mouse (snap):"
        '
        'SnapToGridChecker
        '
        Me.SnapToGridChecker.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SnapToGridChecker.BackColor = System.Drawing.Color.Transparent
        Me.SnapToGridChecker.Checked = False
        Me.SnapToGridChecker.DText = "Snap Objects to Grid"
        Me.SnapToGridChecker.ForeColor = System.Drawing.Color.Silver
        Me.SnapToGridChecker.Location = New System.Drawing.Point(12, 43)
        Me.SnapToGridChecker.Name = "SnapToGridChecker"
        Me.SnapToGridChecker.Size = New System.Drawing.Size(156, 18)
        Me.SnapToGridChecker.TabIndex = 6
        Me.SnapToGridChecker.Text = "Snap Objects to Grid"
        '
        'MouseSnapLabel
        '
        Me.MouseSnapLabel.AutoSize = True
        Me.MouseSnapLabel.BackColor = System.Drawing.Color.Transparent
        Me.MouseSnapLabel.ForeColor = System.Drawing.Color.White
        Me.MouseSnapLabel.Location = New System.Drawing.Point(106, 21)
        Me.MouseSnapLabel.Name = "MouseSnapLabel"
        Me.MouseSnapLabel.Size = New System.Drawing.Size(25, 15)
        Me.MouseSnapLabel.TabIndex = 0
        Me.MouseSnapLabel.Text = "0, 0"
        '
        'Spacer
        '
        Me.Spacer.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Spacer.BackColor = System.Drawing.Color.Transparent
        Me.Spacer.Controls.Add(Me.UseRightClickMenuChecker)
        Me.Spacer.Controls.Add(Me.ObjectBox)
        Me.Spacer.Location = New System.Drawing.Point(0, 0)
        Me.Spacer.Name = "Spacer"
        Me.Spacer.Size = New System.Drawing.Size(304, 134)
        Me.Spacer.TabIndex = 29
        '
        'UseRightClickMenuChecker
        '
        Me.UseRightClickMenuChecker.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.UseRightClickMenuChecker.AutoSize = True
        Me.UseRightClickMenuChecker.BackColor = System.Drawing.Color.Transparent
        Me.UseRightClickMenuChecker.Checked = False
        Me.UseRightClickMenuChecker.DText = "Use Right-Click Menu"
        Me.UseRightClickMenuChecker.Location = New System.Drawing.Point(157, 112)
        Me.UseRightClickMenuChecker.Name = "UseRightClickMenuChecker"
        Me.UseRightClickMenuChecker.Size = New System.Drawing.Size(140, 18)
        Me.UseRightClickMenuChecker.TabIndex = 28
        Me.UseRightClickMenuChecker.Text = "Use Right-Click Menu"
        '
        'ObjectBox
        '
        Me.ObjectBox.BackColor = System.Drawing.Color.Transparent
        Me.ObjectBox.BorderColor = System.Drawing.Color.Gray
        Me.ObjectBox.Controls.Add(Me.ObjectPreviewPanel)
        Me.ObjectBox.Controls.Add(Me.ObjectDropper)
        Me.ObjectBox.Controls.Add(Me.OpenObjectButton)
        Me.ObjectBox.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ObjectBox.Location = New System.Drawing.Point(4, 4)
        Me.ObjectBox.Name = "ObjectBox"
        Me.ObjectBox.Size = New System.Drawing.Size(293, 106)
        Me.ObjectBox.TabIndex = 0
        Me.ObjectBox.TabStop = False
        Me.ObjectBox.Text = "Object to Plot:"
        '
        'ObjectPreviewPanel
        '
        Me.ObjectPreviewPanel.BackColor = System.Drawing.Color.Transparent
        Me.ObjectPreviewPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.ObjectPreviewPanel.Location = New System.Drawing.Point(192, 5)
        Me.ObjectPreviewPanel.Name = "ObjectPreviewPanel"
        Me.ObjectPreviewPanel.Size = New System.Drawing.Size(96, 96)
        Me.ObjectPreviewPanel.TabIndex = 0
        '
        'ObjectDropper
        '
        Me.ObjectDropper.BackColor = System.Drawing.Color.Transparent
        Me.ObjectDropper.BorderColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.ObjectDropper.Image = CType(resources.GetObject("ObjectDropper.Image"), System.Drawing.Image)
        Me.ObjectDropper.Location = New System.Drawing.Point(13, 32)
        Me.ObjectDropper.Name = "ObjectDropper"
        Me.ObjectDropper.ShadowColor = System.Drawing.Color.FromArgb(CType(CType(160, Byte), Integer), CType(CType(160, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.ObjectDropper.Size = New System.Drawing.Size(173, 25)
        Me.ObjectDropper.TabIndex = 0
        '
        'OpenObjectButton
        '
        Me.OpenObjectButton.BackColor = System.Drawing.Color.Transparent
        Me.OpenObjectButton.DText = "Open"
        Me.OpenObjectButton.Enabled = False
        Me.OpenObjectButton.ForeColor = System.Drawing.Color.Black
        Me.OpenObjectButton.ImageOnTop = False
        Me.OpenObjectButton.LeftAligned = False
        Me.OpenObjectButton.Location = New System.Drawing.Point(107, 59)
        Me.OpenObjectButton.Name = "OpenObjectButton"
        Me.OpenObjectButton.Size = New System.Drawing.Size(79, 26)
        Me.OpenObjectButton.TabIndex = 27
        Me.OpenObjectButton.TabStop = True
        Me.OpenObjectButton.Text = "Open"
        Me.OpenObjectButton.TextImageSpacing = CType(0, Byte)
        Me.OpenObjectButton.XIMage = Nothing
        '
        'SidePanel
        '
        Me.SidePanel.BackgroundImage = Global.Dark_Flow.My.Resources.Resources.InverseGradient
        Me.SidePanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.SidePanel.Controls.Add(Me.NameTextBox)
        Me.SidePanel.Controls.Add(Me.ViewSettingsLabel)
        Me.SidePanel.Controls.Add(Me.ForegroundDropper)
        Me.SidePanel.Controls.Add(Me.NameLabel)
        Me.SidePanel.Controls.Add(Me.ForegroundLabel)
        Me.SidePanel.Controls.Add(Me.ViewWidthLabel)
        Me.SidePanel.Controls.Add(Me.BackgroundDropper)
        Me.SidePanel.Controls.Add(Me.ViewWidthSelector)
        Me.SidePanel.Controls.Add(Me.BackgroundLabel)
        Me.SidePanel.Controls.Add(Me.ViewHeightLabel)
        Me.SidePanel.Controls.Add(Me.BGColorLabel)
        Me.SidePanel.Controls.Add(Me.ViewHeightSelector)
        Me.SidePanel.Controls.Add(Me.BGColorDisplayer)
        Me.SidePanel.Controls.Add(Me.ViewXLabel)
        Me.SidePanel.Controls.Add(Me.SceneHeightSelector)
        Me.SidePanel.Controls.Add(Me.ViewXSelector)
        Me.SidePanel.Controls.Add(Me.SceneHeightLabel)
        Me.SidePanel.Controls.Add(Me.ViewYLabel)
        Me.SidePanel.Controls.Add(Me.SceneWidthSelector)
        Me.SidePanel.Controls.Add(Me.ViewYSelector)
        Me.SidePanel.Controls.Add(Me.SceneWidthLabel)
        Me.SidePanel.Controls.Add(Me.SceneSettingsLabel)
        Me.SidePanel.Dock = System.Windows.Forms.DockStyle.Left
        Me.SidePanel.Location = New System.Drawing.Point(0, 25)
        Me.SidePanel.Name = "SidePanel"
        Me.SidePanel.Size = New System.Drawing.Size(180, 423)
        Me.SidePanel.TabIndex = 1
        '
        'NameTextBox
        '
        Me.NameTextBox.BackColor = System.Drawing.Color.Transparent
        Me.NameTextBox.BorderColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.NameTextBox.Location = New System.Drawing.Point(10, 28)
        Me.NameTextBox.MultiLine = False
        Me.NameTextBox.Name = "NameTextBox"
        Me.NameTextBox.ShadowColor = System.Drawing.Color.Black
        Me.NameTextBox.Size = New System.Drawing.Size(158, 24)
        Me.NameTextBox.TabIndex = 23
        Me.NameTextBox.UseSystemPasswordChar = False
        '
        'ViewSettingsLabel
        '
        Me.ViewSettingsLabel.BackColor = System.Drawing.Color.Silver
        Me.ViewSettingsLabel.ForeColor = System.Drawing.Color.Black
        Me.ViewSettingsLabel.Location = New System.Drawing.Point(0, 275)
        Me.ViewSettingsLabel.Name = "ViewSettingsLabel"
        Me.ViewSettingsLabel.Padding = New System.Windows.Forms.Padding(3)
        Me.ViewSettingsLabel.Size = New System.Drawing.Size(180, 22)
        Me.ViewSettingsLabel.TabIndex = 22
        Me.ViewSettingsLabel.Text = "View Settings"
        Me.ViewSettingsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ForegroundDropper
        '
        Me.ForegroundDropper.BackColor = System.Drawing.Color.Transparent
        Me.ForegroundDropper.BorderColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.ForegroundDropper.Image = CType(resources.GetObject("ForegroundDropper.Image"), System.Drawing.Image)
        Me.ForegroundDropper.Location = New System.Drawing.Point(11, 151)
        Me.ForegroundDropper.Name = "ForegroundDropper"
        Me.ForegroundDropper.ShadowColor = System.Drawing.Color.Black
        Me.ForegroundDropper.Size = New System.Drawing.Size(157, 25)
        Me.ForegroundDropper.TabIndex = 20
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
        'ForegroundLabel
        '
        Me.ForegroundLabel.AutoSize = True
        Me.ForegroundLabel.BackColor = System.Drawing.Color.Transparent
        Me.ForegroundLabel.ForeColor = System.Drawing.Color.Silver
        Me.ForegroundLabel.Location = New System.Drawing.Point(8, 133)
        Me.ForegroundLabel.Name = "ForegroundLabel"
        Me.ForegroundLabel.Size = New System.Drawing.Size(72, 15)
        Me.ForegroundLabel.TabIndex = 21
        Me.ForegroundLabel.Text = "Foreground:"
        '
        'ViewWidthLabel
        '
        Me.ViewWidthLabel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ViewWidthLabel.BackColor = System.Drawing.Color.Transparent
        Me.ViewWidthLabel.ForeColor = System.Drawing.Color.Silver
        Me.ViewWidthLabel.Location = New System.Drawing.Point(12, 307)
        Me.ViewWidthLabel.Name = "ViewWidthLabel"
        Me.ViewWidthLabel.Size = New System.Drawing.Size(82, 16)
        Me.ViewWidthLabel.TabIndex = 0
        Me.ViewWidthLabel.Text = "Width:"
        Me.ViewWidthLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'BackgroundDropper
        '
        Me.BackgroundDropper.BackColor = System.Drawing.Color.Transparent
        Me.BackgroundDropper.BorderColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.BackgroundDropper.Image = CType(resources.GetObject("BackgroundDropper.Image"), System.Drawing.Image)
        Me.BackgroundDropper.Location = New System.Drawing.Point(10, 107)
        Me.BackgroundDropper.Name = "BackgroundDropper"
        Me.BackgroundDropper.ShadowColor = System.Drawing.Color.Black
        Me.BackgroundDropper.Size = New System.Drawing.Size(158, 25)
        Me.BackgroundDropper.TabIndex = 4
        '
        'ViewWidthSelector
        '
        Me.ViewWidthSelector.BackColor = System.Drawing.Color.Transparent
        Me.ViewWidthSelector.BorderColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.ViewWidthSelector.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ViewWidthSelector.InputColor = System.Drawing.Color.FromArgb(CType(CType(41, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ViewWidthSelector.Location = New System.Drawing.Point(100, 304)
        Me.ViewWidthSelector.Maximum = CType(0US, UShort)
        Me.ViewWidthSelector.Minimum = CType(0US, UShort)
        Me.ViewWidthSelector.Name = "ViewWidthSelector"
        Me.ViewWidthSelector.ShadowColor = System.Drawing.Color.FromArgb(CType(CType(72, Byte), Integer), CType(CType(72, Byte), Integer), CType(CType(72, Byte), Integer))
        Me.ViewWidthSelector.Size = New System.Drawing.Size(68, 24)
        Me.ViewWidthSelector.TabIndex = 0
        Me.ViewWidthSelector.Value = CType(640US, UShort)
        '
        'BackgroundLabel
        '
        Me.BackgroundLabel.AutoSize = True
        Me.BackgroundLabel.BackColor = System.Drawing.Color.Transparent
        Me.BackgroundLabel.ForeColor = System.Drawing.Color.Silver
        Me.BackgroundLabel.Location = New System.Drawing.Point(8, 89)
        Me.BackgroundLabel.Name = "BackgroundLabel"
        Me.BackgroundLabel.Size = New System.Drawing.Size(74, 15)
        Me.BackgroundLabel.TabIndex = 19
        Me.BackgroundLabel.Text = "Background:"
        '
        'ViewHeightLabel
        '
        Me.ViewHeightLabel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ViewHeightLabel.BackColor = System.Drawing.Color.Transparent
        Me.ViewHeightLabel.ForeColor = System.Drawing.Color.Silver
        Me.ViewHeightLabel.Location = New System.Drawing.Point(12, 334)
        Me.ViewHeightLabel.Name = "ViewHeightLabel"
        Me.ViewHeightLabel.Size = New System.Drawing.Size(82, 15)
        Me.ViewHeightLabel.TabIndex = 7
        Me.ViewHeightLabel.Text = "Height:"
        Me.ViewHeightLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'BGColorLabel
        '
        Me.BGColorLabel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BGColorLabel.BackColor = System.Drawing.Color.Transparent
        Me.BGColorLabel.ForeColor = System.Drawing.Color.Silver
        Me.BGColorLabel.Location = New System.Drawing.Point(12, 183)
        Me.BGColorLabel.Name = "BGColorLabel"
        Me.BGColorLabel.Size = New System.Drawing.Size(82, 15)
        Me.BGColorLabel.TabIndex = 18
        Me.BGColorLabel.Text = "BG Color:"
        Me.BGColorLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ViewHeightSelector
        '
        Me.ViewHeightSelector.BackColor = System.Drawing.Color.Transparent
        Me.ViewHeightSelector.BorderColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.ViewHeightSelector.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ViewHeightSelector.InputColor = System.Drawing.Color.FromArgb(CType(CType(41, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ViewHeightSelector.Location = New System.Drawing.Point(100, 331)
        Me.ViewHeightSelector.Maximum = CType(0US, UShort)
        Me.ViewHeightSelector.Minimum = CType(0US, UShort)
        Me.ViewHeightSelector.Name = "ViewHeightSelector"
        Me.ViewHeightSelector.ShadowColor = System.Drawing.Color.FromArgb(CType(CType(72, Byte), Integer), CType(CType(72, Byte), Integer), CType(CType(72, Byte), Integer))
        Me.ViewHeightSelector.Size = New System.Drawing.Size(68, 24)
        Me.ViewHeightSelector.TabIndex = 8
        Me.ViewHeightSelector.Value = CType(480US, UShort)
        '
        'BGColorDisplayer
        '
        Me.BGColorDisplayer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.BGColorDisplayer.Location = New System.Drawing.Point(100, 180)
        Me.BGColorDisplayer.Name = "BGColorDisplayer"
        Me.BGColorDisplayer.Size = New System.Drawing.Size(68, 24)
        Me.BGColorDisplayer.TabIndex = 4
        '
        'ViewXLabel
        '
        Me.ViewXLabel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ViewXLabel.BackColor = System.Drawing.Color.Transparent
        Me.ViewXLabel.ForeColor = System.Drawing.Color.Silver
        Me.ViewXLabel.Location = New System.Drawing.Point(12, 361)
        Me.ViewXLabel.Name = "ViewXLabel"
        Me.ViewXLabel.Size = New System.Drawing.Size(82, 15)
        Me.ViewXLabel.TabIndex = 10
        Me.ViewXLabel.Text = "X:"
        Me.ViewXLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'SceneHeightSelector
        '
        Me.SceneHeightSelector.BackColor = System.Drawing.Color.Transparent
        Me.SceneHeightSelector.BorderColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.SceneHeightSelector.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SceneHeightSelector.InputColor = System.Drawing.Color.FromArgb(CType(CType(41, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.SceneHeightSelector.Location = New System.Drawing.Point(100, 235)
        Me.SceneHeightSelector.Maximum = CType(0US, UShort)
        Me.SceneHeightSelector.Minimum = CType(0US, UShort)
        Me.SceneHeightSelector.Name = "SceneHeightSelector"
        Me.SceneHeightSelector.ShadowColor = System.Drawing.Color.FromArgb(CType(CType(72, Byte), Integer), CType(CType(72, Byte), Integer), CType(CType(72, Byte), Integer))
        Me.SceneHeightSelector.Size = New System.Drawing.Size(68, 24)
        Me.SceneHeightSelector.TabIndex = 17
        Me.SceneHeightSelector.Value = CType(480US, UShort)
        '
        'ViewXSelector
        '
        Me.ViewXSelector.BackColor = System.Drawing.Color.Transparent
        Me.ViewXSelector.BorderColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.ViewXSelector.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ViewXSelector.InputColor = System.Drawing.Color.FromArgb(CType(CType(41, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ViewXSelector.Location = New System.Drawing.Point(100, 358)
        Me.ViewXSelector.Maximum = CType(0US, UShort)
        Me.ViewXSelector.Minimum = CType(0US, UShort)
        Me.ViewXSelector.Name = "ViewXSelector"
        Me.ViewXSelector.ShadowColor = System.Drawing.Color.FromArgb(CType(CType(72, Byte), Integer), CType(CType(72, Byte), Integer), CType(CType(72, Byte), Integer))
        Me.ViewXSelector.Size = New System.Drawing.Size(68, 24)
        Me.ViewXSelector.TabIndex = 9
        Me.ViewXSelector.Value = CType(0US, UShort)
        '
        'SceneHeightLabel
        '
        Me.SceneHeightLabel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SceneHeightLabel.BackColor = System.Drawing.Color.Transparent
        Me.SceneHeightLabel.ForeColor = System.Drawing.Color.Silver
        Me.SceneHeightLabel.Location = New System.Drawing.Point(12, 238)
        Me.SceneHeightLabel.Name = "SceneHeightLabel"
        Me.SceneHeightLabel.Size = New System.Drawing.Size(82, 15)
        Me.SceneHeightLabel.TabIndex = 16
        Me.SceneHeightLabel.Text = "Height:"
        Me.SceneHeightLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ViewYLabel
        '
        Me.ViewYLabel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ViewYLabel.BackColor = System.Drawing.Color.Transparent
        Me.ViewYLabel.ForeColor = System.Drawing.Color.Silver
        Me.ViewYLabel.Location = New System.Drawing.Point(12, 388)
        Me.ViewYLabel.Name = "ViewYLabel"
        Me.ViewYLabel.Size = New System.Drawing.Size(82, 15)
        Me.ViewYLabel.TabIndex = 11
        Me.ViewYLabel.Text = "Y:"
        Me.ViewYLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'SceneWidthSelector
        '
        Me.SceneWidthSelector.BackColor = System.Drawing.Color.Transparent
        Me.SceneWidthSelector.BorderColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.SceneWidthSelector.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SceneWidthSelector.InputColor = System.Drawing.Color.FromArgb(CType(CType(41, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.SceneWidthSelector.Location = New System.Drawing.Point(100, 208)
        Me.SceneWidthSelector.Maximum = CType(0US, UShort)
        Me.SceneWidthSelector.Minimum = CType(0US, UShort)
        Me.SceneWidthSelector.Name = "SceneWidthSelector"
        Me.SceneWidthSelector.ShadowColor = System.Drawing.Color.FromArgb(CType(CType(72, Byte), Integer), CType(CType(72, Byte), Integer), CType(CType(72, Byte), Integer))
        Me.SceneWidthSelector.Size = New System.Drawing.Size(68, 24)
        Me.SceneWidthSelector.TabIndex = 14
        Me.SceneWidthSelector.Value = CType(640US, UShort)
        '
        'ViewYSelector
        '
        Me.ViewYSelector.BackColor = System.Drawing.Color.Transparent
        Me.ViewYSelector.BorderColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.ViewYSelector.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ViewYSelector.InputColor = System.Drawing.Color.FromArgb(CType(CType(41, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ViewYSelector.Location = New System.Drawing.Point(100, 385)
        Me.ViewYSelector.Maximum = CType(0US, UShort)
        Me.ViewYSelector.Minimum = CType(0US, UShort)
        Me.ViewYSelector.Name = "ViewYSelector"
        Me.ViewYSelector.ShadowColor = System.Drawing.Color.FromArgb(CType(CType(72, Byte), Integer), CType(CType(72, Byte), Integer), CType(CType(72, Byte), Integer))
        Me.ViewYSelector.Size = New System.Drawing.Size(68, 24)
        Me.ViewYSelector.TabIndex = 12
        Me.ViewYSelector.Value = CType(0US, UShort)
        '
        'SceneWidthLabel
        '
        Me.SceneWidthLabel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SceneWidthLabel.BackColor = System.Drawing.Color.Transparent
        Me.SceneWidthLabel.ForeColor = System.Drawing.Color.Silver
        Me.SceneWidthLabel.Location = New System.Drawing.Point(12, 211)
        Me.SceneWidthLabel.Name = "SceneWidthLabel"
        Me.SceneWidthLabel.Size = New System.Drawing.Size(82, 15)
        Me.SceneWidthLabel.TabIndex = 15
        Me.SceneWidthLabel.Text = "Width:"
        Me.SceneWidthLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'SceneSettingsLabel
        '
        Me.SceneSettingsLabel.BackColor = System.Drawing.Color.Silver
        Me.SceneSettingsLabel.ForeColor = System.Drawing.Color.Black
        Me.SceneSettingsLabel.Location = New System.Drawing.Point(0, 60)
        Me.SceneSettingsLabel.Name = "SceneSettingsLabel"
        Me.SceneSettingsLabel.Padding = New System.Windows.Forms.Padding(3)
        Me.SceneSettingsLabel.Size = New System.Drawing.Size(180, 22)
        Me.SceneSettingsLabel.TabIndex = 13
        Me.SceneSettingsLabel.Text = "Scene Settings"
        Me.SceneSettingsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'FScene
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(664, 448)
        Me.Controls.Add(Me.DesignPanel)
        Me.Controls.Add(Me.BottomBanner)
        Me.Controls.Add(Me.SidePanel)
        Me.Controls.Add(Me.MainToolStrip)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MinimumSize = New System.Drawing.Size(680, 486)
        Me.Name = "FScene"
        Me.Text = "[Scene]"
        Me.MainToolStrip.ResumeLayout(False)
        Me.MainToolStrip.PerformLayout()
        Me.RightClickMenu.ResumeLayout(False)
        Me.BottomBanner.ResumeLayout(False)
        Me.CoOrdinatesBanner.ResumeLayout(False)
        Me.CoOrdinatesBanner.PerformLayout()
        Me.Spacer.ResumeLayout(False)
        Me.Spacer.PerformLayout()
        Me.ObjectBox.ResumeLayout(False)
        Me.SidePanel.ResumeLayout(False)
        Me.SidePanel.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MainToolStrip As System.Windows.Forms.ToolStrip
    Friend WithEvents DAcceptButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents TSS1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents DCancelButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents ViewWidthSelector As Dark_Flow.SexyNumeric
    Friend WithEvents ViewWidthLabel As System.Windows.Forms.Label
    Friend WithEvents NameLabel As System.Windows.Forms.Label
    Friend WithEvents ViewYSelector As Dark_Flow.SexyNumeric
    Friend WithEvents ViewYLabel As System.Windows.Forms.Label
    Friend WithEvents ViewXSelector As Dark_Flow.SexyNumeric
    Friend WithEvents ViewXLabel As System.Windows.Forms.Label
    Friend WithEvents ViewHeightSelector As Dark_Flow.SexyNumeric
    Friend WithEvents ViewHeightLabel As System.Windows.Forms.Label
    Friend WithEvents SceneSettingsLabel As System.Windows.Forms.Label
    Friend WithEvents SceneHeightSelector As Dark_Flow.SexyNumeric
    Friend WithEvents SceneHeightLabel As System.Windows.Forms.Label
    Friend WithEvents SceneWidthSelector As Dark_Flow.SexyNumeric
    Friend WithEvents SceneWidthLabel As System.Windows.Forms.Label
    Friend WithEvents BGColorLabel As System.Windows.Forms.Label
    Friend WithEvents BGColorDisplayer As System.Windows.Forms.Panel
    Friend WithEvents BackgroundLabel As System.Windows.Forms.Label
    Friend WithEvents ForegroundDropper As Dark_Flow.SexyComboBox
    Friend WithEvents ForegroundLabel As System.Windows.Forms.Label
    Friend WithEvents BackgroundDropper As Dark_Flow.SexyComboBox
    Friend WithEvents ViewSettingsLabel As System.Windows.Forms.Label
    Friend WithEvents OpenObjectButton As Dark_Flow.SexyButton
    Friend WithEvents UseRightClickMenuChecker As Dark_Flow.SexyCheckBox
    Friend WithEvents RightClickMenu As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents RMoveToPositionButton As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RDeleteButton As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ROpenObjectButton As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BottomBanner As Dark_Flow.DoubleBufferPanel
    Friend WithEvents SnapYTextBox As Dark_Flow.SexyTextBox
    Friend WithEvents MouseLabel As System.Windows.Forms.Label
    Friend WithEvents SnapYLabel As System.Windows.Forms.Label
    Friend WithEvents MouseSnapDescLabel As System.Windows.Forms.Label
    Friend WithEvents SnapXTextBox As Dark_Flow.SexyTextBox
    Friend WithEvents MouseSnapLabel As System.Windows.Forms.Label
    Friend WithEvents SnapToGridChecker As Dark_Flow.SexyCheckBox
    Friend WithEvents SnapXLabel As System.Windows.Forms.Label
    Friend WithEvents MouseDescLabel As System.Windows.Forms.Label
    Friend WithEvents ShowGridChecker As Dark_Flow.SexyCheckBox
    Friend WithEvents CoOrdinatesBanner As Dark_Flow.DoubleBufferPanel
    Friend WithEvents SidePanel As Dark_Flow.DoubleBufferPanel
    Friend WithEvents ObjectBox As Dark_Flow.SexyGroupBox
    Friend WithEvents ObjectPreviewPanel As Dark_Flow.DoubleBufferPanel
    Friend WithEvents ObjectDropper As Dark_Flow.SexyComboBox
    Friend WithEvents NameTextBox As Dark_Flow.SexyTextBox
    Friend WithEvents DesignPanel As Dark_Flow.DoubleBufferPanel
    Friend WithEvents Spacer As Dark_Flow.DoubleBufferPanel
    Friend WithEvents DeleteButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents TSS2 As System.Windows.Forms.ToolStripSeparator
End Class
