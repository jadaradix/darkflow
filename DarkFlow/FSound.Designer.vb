<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FSound
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
        Me.MainToolStrip = New System.Windows.Forms.ToolStrip()
        Me.DAcceptButton = New System.Windows.Forms.ToolStripButton()
        Me.TSS1 = New System.Windows.Forms.ToolStripSeparator()
        Me.DCancelButton = New System.Windows.Forms.ToolStripButton()
        Me.TSS2 = New System.Windows.Forms.ToolStripSeparator()
        Me.DeleteButton = New System.Windows.Forms.ToolStripButton()
        Me.NameLabel = New System.Windows.Forms.Label()
        Me.TopPanel = New System.Windows.Forms.Panel()
        Me.NameTextBox = New DarkFlow.SexyTextBox()
        Me.SideBarSuperPanel = New DarkFlow.SuperPanel()
        Me.MusicIconPanel = New System.Windows.Forms.Panel()
        Me.PlayButton = New DarkFlow.SexyButton()
        Me.SaveToFileButton = New DarkFlow.SexyButton()
        Me.LoadFromFileButton = New DarkFlow.SexyButton()
        Me.EditButton = New DarkFlow.SexyButton()
        Me.SampleDropper = New DarkFlow.SexyComboBox()
        Me.UseSampleLabel = New System.Windows.Forms.Label()
        Me.MainToolStrip.SuspendLayout()
        Me.TopPanel.SuspendLayout()
        Me.SideBarSuperPanel.SuspendLayout()
        Me.SuspendLayout()
        '
        'MainToolStrip
        '
        Me.MainToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DAcceptButton, Me.TSS1, Me.DCancelButton, Me.TSS2, Me.DeleteButton})
        Me.MainToolStrip.Location = New System.Drawing.Point(0, 0)
        Me.MainToolStrip.Name = "MainToolStrip"
        Me.MainToolStrip.Size = New System.Drawing.Size(284, 25)
        Me.MainToolStrip.TabIndex = 0
        '
        'DAcceptButton
        '
        Me.DAcceptButton.Image = Global.DarkFlow.My.Resources.Resources.AcceptIcon
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
        Me.DCancelButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
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
        Me.DeleteButton.Image = Global.DarkFlow.My.Resources.Resources.DeleteIcon
        Me.DeleteButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.DeleteButton.Name = "DeleteButton"
        Me.DeleteButton.Size = New System.Drawing.Size(60, 22)
        Me.DeleteButton.Text = "Delete"
        '
        'NameLabel
        '
        Me.NameLabel.AutoSize = True
        Me.NameLabel.BackColor = System.Drawing.Color.Transparent
        Me.NameLabel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.NameLabel.Location = New System.Drawing.Point(82, 34)
        Me.NameLabel.Name = "NameLabel"
        Me.NameLabel.Size = New System.Drawing.Size(42, 15)
        Me.NameLabel.TabIndex = 2
        Me.NameLabel.Text = "Name:"
        '
        'TopPanel
        '
        Me.TopPanel.Controls.Add(Me.NameTextBox)
        Me.TopPanel.Controls.Add(Me.NameLabel)
        Me.TopPanel.Controls.Add(Me.MainToolStrip)
        Me.TopPanel.Dock = System.Windows.Forms.DockStyle.Top
        Me.TopPanel.Location = New System.Drawing.Point(0, 0)
        Me.TopPanel.Name = "TopPanel"
        Me.TopPanel.Size = New System.Drawing.Size(284, 58)
        Me.TopPanel.TabIndex = 6
        '
        'NameTextBox
        '
        Me.NameTextBox.BackColor = System.Drawing.Color.Transparent
        Me.NameTextBox.BorderColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.NameTextBox.Location = New System.Drawing.Point(135, 30)
        Me.NameTextBox.MultiLine = False
        Me.NameTextBox.Name = "NameTextBox"
        Me.NameTextBox.ShadowColor = System.Drawing.Color.FromArgb(CType(CType(72, Byte), Integer), CType(CType(72, Byte), Integer), CType(CType(72, Byte), Integer))
        Me.NameTextBox.Size = New System.Drawing.Size(147, 26)
        Me.NameTextBox.TabIndex = 2
        Me.NameTextBox.UseSystemPasswordChar = False
        '
        'SideBarSuperPanel
        '
        Me.SideBarSuperPanel.BackColor = System.Drawing.Color.Transparent
        Me.SideBarSuperPanel.BorderColor = System.Drawing.Color.White
        Me.SideBarSuperPanel.BorderRadius = CType(6, Byte)
        Me.SideBarSuperPanel.Controls.Add(Me.MusicIconPanel)
        Me.SideBarSuperPanel.Controls.Add(Me.PlayButton)
        Me.SideBarSuperPanel.GradBottomColor = System.Drawing.Color.Silver
        Me.SideBarSuperPanel.GradTopColor = System.Drawing.Color.White
        Me.SideBarSuperPanel.Location = New System.Drawing.Point(2, 60)
        Me.SideBarSuperPanel.Name = "SideBarSuperPanel"
        Me.SideBarSuperPanel.Size = New System.Drawing.Size(116, 161)
        Me.SideBarSuperPanel.TabIndex = 5
        '
        'MusicIconPanel
        '
        Me.MusicIconPanel.BackColor = System.Drawing.Color.Transparent
        Me.MusicIconPanel.BackgroundImage = Global.DarkFlow.My.Resources.Resources.BigMusicIcon
        Me.MusicIconPanel.Location = New System.Drawing.Point(13, 13)
        Me.MusicIconPanel.Name = "MusicIconPanel"
        Me.MusicIconPanel.Size = New System.Drawing.Size(90, 90)
        Me.MusicIconPanel.TabIndex = 6
        '
        'PlayButton
        '
        Me.PlayButton.BackColor = System.Drawing.Color.Transparent
        Me.PlayButton.DText = "Play"
        Me.PlayButton.ForeColor = System.Drawing.Color.Black
        Me.PlayButton.ImageOnTop = False
        Me.PlayButton.LeftAligned = True
        Me.PlayButton.Location = New System.Drawing.Point(24, 116)
        Me.PlayButton.Name = "PlayButton"
        Me.PlayButton.Size = New System.Drawing.Size(68, 30)
        Me.PlayButton.TabIndex = 6
        Me.PlayButton.TabStop = True
        Me.PlayButton.Text = "Play"
        Me.PlayButton.TextImageSpacing = CType(0, Byte)
        Me.PlayButton.XIMage = Global.DarkFlow.My.Resources.Resources.PlayIcon
        '
        'SaveToFileButton
        '
        Me.SaveToFileButton.BackColor = System.Drawing.Color.Transparent
        Me.SaveToFileButton.DText = "Save"
        Me.SaveToFileButton.ForeColor = System.Drawing.Color.Black
        Me.SaveToFileButton.ImageOnTop = True
        Me.SaveToFileButton.LeftAligned = True
        Me.SaveToFileButton.Location = New System.Drawing.Point(242, 118)
        Me.SaveToFileButton.Name = "SaveToFileButton"
        Me.SaveToFileButton.Size = New System.Drawing.Size(40, 56)
        Me.SaveToFileButton.TabIndex = 10
        Me.SaveToFileButton.TabStop = True
        Me.SaveToFileButton.Text = "Save"
        Me.SaveToFileButton.TextImageSpacing = CType(0, Byte)
        Me.SaveToFileButton.XIMage = Global.DarkFlow.My.Resources.Resources.SaveFileIcon
        '
        'LoadFromFileButton
        '
        Me.LoadFromFileButton.BackColor = System.Drawing.Color.Transparent
        Me.LoadFromFileButton.DText = "Load from File"
        Me.LoadFromFileButton.ForeColor = System.Drawing.Color.Black
        Me.LoadFromFileButton.ImageOnTop = True
        Me.LoadFromFileButton.LeftAligned = True
        Me.LoadFromFileButton.Location = New System.Drawing.Point(120, 60)
        Me.LoadFromFileButton.Name = "LoadFromFileButton"
        Me.LoadFromFileButton.Size = New System.Drawing.Size(162, 56)
        Me.LoadFromFileButton.TabIndex = 8
        Me.LoadFromFileButton.TabStop = True
        Me.LoadFromFileButton.Text = "Load from File"
        Me.LoadFromFileButton.TextImageSpacing = CType(0, Byte)
        Me.LoadFromFileButton.XIMage = Global.DarkFlow.My.Resources.Resources.OpenFileIcon
        '
        'EditButton
        '
        Me.EditButton.BackColor = System.Drawing.Color.Transparent
        Me.EditButton.DText = "Edit"
        Me.EditButton.ForeColor = System.Drawing.Color.Black
        Me.EditButton.ImageOnTop = True
        Me.EditButton.LeftAligned = True
        Me.EditButton.Location = New System.Drawing.Point(120, 118)
        Me.EditButton.Name = "EditButton"
        Me.EditButton.Size = New System.Drawing.Size(120, 56)
        Me.EditButton.TabIndex = 9
        Me.EditButton.TabStop = True
        Me.EditButton.Text = "Edit"
        Me.EditButton.TextImageSpacing = CType(0, Byte)
        Me.EditButton.XIMage = Global.DarkFlow.My.Resources.Resources.EditIcon
        '
        'SampleDropper
        '
        Me.SampleDropper.BackColor = System.Drawing.Color.Transparent
        Me.SampleDropper.BorderColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.SampleDropper.Image = Global.DarkFlow.My.Resources.Resources.NewFileIcon
        Me.SampleDropper.Location = New System.Drawing.Point(120, 196)
        Me.SampleDropper.Name = "SampleDropper"
        Me.SampleDropper.ShadowColor = System.Drawing.Color.FromArgb(CType(CType(72, Byte), Integer), CType(CType(72, Byte), Integer), CType(CType(72, Byte), Integer))
        Me.SampleDropper.Size = New System.Drawing.Size(162, 24)
        Me.SampleDropper.TabIndex = 23
        '
        'UseSampleLabel
        '
        Me.UseSampleLabel.AutoSize = True
        Me.UseSampleLabel.BackColor = System.Drawing.Color.Transparent
        Me.UseSampleLabel.ForeColor = System.Drawing.Color.Silver
        Me.UseSampleLabel.Location = New System.Drawing.Point(118, 178)
        Me.UseSampleLabel.Name = "UseSampleLabel"
        Me.UseSampleLabel.Size = New System.Drawing.Size(71, 15)
        Me.UseSampleLabel.TabIndex = 22
        Me.UseSampleLabel.Text = "Use Sample:"
        '
        'FSound
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackgroundImage = Global.DarkFlow.My.Resources.Resources.InverseGradient
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(284, 222)
        Me.Controls.Add(Me.SampleDropper)
        Me.Controls.Add(Me.UseSampleLabel)
        Me.Controls.Add(Me.SaveToFileButton)
        Me.Controls.Add(Me.LoadFromFileButton)
        Me.Controls.Add(Me.EditButton)
        Me.Controls.Add(Me.TopPanel)
        Me.Controls.Add(Me.SideBarSuperPanel)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(300, 260)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(300, 250)
        Me.Name = "FSound"
        Me.Text = "[Sound]"
        Me.MainToolStrip.ResumeLayout(False)
        Me.MainToolStrip.PerformLayout()
        Me.TopPanel.ResumeLayout(False)
        Me.TopPanel.PerformLayout()
        Me.SideBarSuperPanel.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MainToolStrip As System.Windows.Forms.ToolStrip
    Friend WithEvents DAcceptButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents TSS1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents DCancelButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents NameTextBox As DarkFlow.SexyTextBox
    Friend WithEvents NameLabel As System.Windows.Forms.Label
    Friend WithEvents SideBarSuperPanel As DarkFlow.SuperPanel
    Friend WithEvents PlayButton As DarkFlow.SexyButton
    Friend WithEvents MusicIconPanel As System.Windows.Forms.Panel
    Friend WithEvents TopPanel As System.Windows.Forms.Panel
    Friend WithEvents DeleteButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents TSS2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents SaveToFileButton As DarkFlow.SexyButton
    Friend WithEvents LoadFromFileButton As DarkFlow.SexyButton
    Friend WithEvents EditButton As DarkFlow.SexyButton
    Friend WithEvents SampleDropper As DarkFlow.SexyComboBox
    Friend WithEvents UseSampleLabel As System.Windows.Forms.Label
End Class
