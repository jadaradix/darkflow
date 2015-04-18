<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FImage
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
        Me.ImagePanel = New DarkFlow.DoubleBufferPanel()
        Me.SidePanel = New DarkFlow.DoubleBufferPanel()
        Me.GenerateFontImageButton = New DarkFlow.SexyButton()
        Me.SaveToFileButton = New DarkFlow.SexyButton()
        Me.SampleDropper = New DarkFlow.SexyComboBox()
        Me.UseSampleLabel = New System.Windows.Forms.Label()
        Me.NameTextBox = New DarkFlow.SexyTextBox()
        Me.FrameWidthExplainLabel = New System.Windows.Forms.Label()
        Me.LoadFromFileButton = New DarkFlow.SexyButton()
        Me.FrameHeightSelector = New DarkFlow.SexyNumeric()
        Me.NameLabel = New System.Windows.Forms.Label()
        Me.FrameHeightLabel = New System.Windows.Forms.Label()
        Me.EditButton = New DarkFlow.SexyButton()
        Me.MainToolStrip.SuspendLayout()
        Me.SidePanel.SuspendLayout()
        Me.SuspendLayout()
        '
        'MainToolStrip
        '
        Me.MainToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DAcceptButton, Me.TSS1, Me.DCancelButton, Me.TSS2, Me.DeleteButton})
        Me.MainToolStrip.Location = New System.Drawing.Point(0, 0)
        Me.MainToolStrip.Name = "MainToolStrip"
        Me.MainToolStrip.Size = New System.Drawing.Size(464, 25)
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
        'ImagePanel
        '
        Me.ImagePanel.BackColor = System.Drawing.Color.White
        Me.ImagePanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.ImagePanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ImagePanel.Location = New System.Drawing.Point(180, 25)
        Me.ImagePanel.Name = "ImagePanel"
        Me.ImagePanel.Size = New System.Drawing.Size(284, 335)
        Me.ImagePanel.TabIndex = 3
        '
        'SidePanel
        '
        Me.SidePanel.BackgroundImage = Global.DarkFlow.My.Resources.Resources.InverseGradient
        Me.SidePanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.SidePanel.Controls.Add(Me.GenerateFontImageButton)
        Me.SidePanel.Controls.Add(Me.SaveToFileButton)
        Me.SidePanel.Controls.Add(Me.SampleDropper)
        Me.SidePanel.Controls.Add(Me.UseSampleLabel)
        Me.SidePanel.Controls.Add(Me.NameTextBox)
        Me.SidePanel.Controls.Add(Me.FrameWidthExplainLabel)
        Me.SidePanel.Controls.Add(Me.LoadFromFileButton)
        Me.SidePanel.Controls.Add(Me.FrameHeightSelector)
        Me.SidePanel.Controls.Add(Me.NameLabel)
        Me.SidePanel.Controls.Add(Me.FrameHeightLabel)
        Me.SidePanel.Controls.Add(Me.EditButton)
        Me.SidePanel.Dock = System.Windows.Forms.DockStyle.Left
        Me.SidePanel.Location = New System.Drawing.Point(0, 25)
        Me.SidePanel.Name = "SidePanel"
        Me.SidePanel.Size = New System.Drawing.Size(180, 335)
        Me.SidePanel.TabIndex = 0
        '
        'GenerateFontImageButton
        '
        Me.GenerateFontImageButton.BackColor = System.Drawing.Color.Transparent
        Me.GenerateFontImageButton.DText = "Generate Font Image"
        Me.GenerateFontImageButton.ForeColor = System.Drawing.Color.Black
        Me.GenerateFontImageButton.ImageOnTop = False
        Me.GenerateFontImageButton.LeftAligned = False
        Me.GenerateFontImageButton.Location = New System.Drawing.Point(13, 299)
        Me.GenerateFontImageButton.Name = "GenerateFontImageButton"
        Me.GenerateFontImageButton.Size = New System.Drawing.Size(155, 24)
        Me.GenerateFontImageButton.TabIndex = 6
        Me.GenerateFontImageButton.TabStop = True
        Me.GenerateFontImageButton.Text = "Generate Font Image"
        Me.GenerateFontImageButton.TextImageSpacing = CType(0, Byte)
        Me.GenerateFontImageButton.XIMage = Nothing
        '
        'SaveToFileButton
        '
        Me.SaveToFileButton.BackColor = System.Drawing.Color.Transparent
        Me.SaveToFileButton.DText = "Save"
        Me.SaveToFileButton.ForeColor = System.Drawing.Color.Black
        Me.SaveToFileButton.ImageOnTop = True
        Me.SaveToFileButton.LeftAligned = True
        Me.SaveToFileButton.Location = New System.Drawing.Point(128, 110)
        Me.SaveToFileButton.Name = "SaveToFileButton"
        Me.SaveToFileButton.Size = New System.Drawing.Size(40, 56)
        Me.SaveToFileButton.TabIndex = 7
        Me.SaveToFileButton.TabStop = True
        Me.SaveToFileButton.Text = "Save"
        Me.SaveToFileButton.TextImageSpacing = CType(0, Byte)
        Me.SaveToFileButton.XIMage = Global.DarkFlow.My.Resources.Resources.SaveFileIcon
        '
        'SampleDropper
        '
        Me.SampleDropper.BackColor = System.Drawing.Color.Transparent
        Me.SampleDropper.BorderColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.SampleDropper.Image = Global.DarkFlow.My.Resources.Resources.NewFileIcon
        Me.SampleDropper.Location = New System.Drawing.Point(10, 198)
        Me.SampleDropper.Name = "SampleDropper"
        Me.SampleDropper.ShadowColor = System.Drawing.Color.FromArgb(CType(CType(72, Byte), Integer), CType(CType(72, Byte), Integer), CType(CType(72, Byte), Integer))
        Me.SampleDropper.Size = New System.Drawing.Size(158, 24)
        Me.SampleDropper.TabIndex = 21
        '
        'UseSampleLabel
        '
        Me.UseSampleLabel.AutoSize = True
        Me.UseSampleLabel.BackColor = System.Drawing.Color.Transparent
        Me.UseSampleLabel.ForeColor = System.Drawing.Color.Silver
        Me.UseSampleLabel.Location = New System.Drawing.Point(8, 182)
        Me.UseSampleLabel.Name = "UseSampleLabel"
        Me.UseSampleLabel.Size = New System.Drawing.Size(71, 15)
        Me.UseSampleLabel.TabIndex = 20
        Me.UseSampleLabel.Text = "Use Sample:"
        '
        'NameTextBox
        '
        Me.NameTextBox.BackColor = System.Drawing.Color.Transparent
        Me.NameTextBox.BorderColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.NameTextBox.Location = New System.Drawing.Point(10, 26)
        Me.NameTextBox.MultiLine = False
        Me.NameTextBox.Name = "NameTextBox"
        Me.NameTextBox.ShadowColor = System.Drawing.Color.Black
        Me.NameTextBox.Size = New System.Drawing.Size(158, 24)
        Me.NameTextBox.TabIndex = 4
        Me.NameTextBox.UseSystemPasswordChar = False
        '
        'FrameWidthExplainLabel
        '
        Me.FrameWidthExplainLabel.BackColor = System.Drawing.Color.Transparent
        Me.FrameWidthExplainLabel.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FrameWidthExplainLabel.ForeColor = System.Drawing.Color.Gray
        Me.FrameWidthExplainLabel.Location = New System.Drawing.Point(10, 250)
        Me.FrameWidthExplainLabel.Name = "FrameWidthExplainLabel"
        Me.FrameWidthExplainLabel.Size = New System.Drawing.Size(158, 46)
        Me.FrameWidthExplainLabel.TabIndex = 0
        Me.FrameWidthExplainLabel.Text = "Frame Width is equal to the width of the image as frames are arranged vertically." & _
            ""
        Me.FrameWidthExplainLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LoadFromFileButton
        '
        Me.LoadFromFileButton.BackColor = System.Drawing.Color.Transparent
        Me.LoadFromFileButton.DText = "Load from File"
        Me.LoadFromFileButton.ForeColor = System.Drawing.Color.Black
        Me.LoadFromFileButton.ImageOnTop = True
        Me.LoadFromFileButton.LeftAligned = True
        Me.LoadFromFileButton.Location = New System.Drawing.Point(10, 52)
        Me.LoadFromFileButton.Name = "LoadFromFileButton"
        Me.LoadFromFileButton.Size = New System.Drawing.Size(158, 56)
        Me.LoadFromFileButton.TabIndex = 4
        Me.LoadFromFileButton.TabStop = True
        Me.LoadFromFileButton.Text = "Load from File"
        Me.LoadFromFileButton.TextImageSpacing = CType(0, Byte)
        Me.LoadFromFileButton.XIMage = Global.DarkFlow.My.Resources.Resources.OpenFileIcon
        '
        'FrameHeightSelector
        '
        Me.FrameHeightSelector.BackColor = System.Drawing.Color.Transparent
        Me.FrameHeightSelector.BorderColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.FrameHeightSelector.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FrameHeightSelector.InputColor = System.Drawing.Color.FromArgb(CType(CType(41, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.FrameHeightSelector.Location = New System.Drawing.Point(101, 224)
        Me.FrameHeightSelector.Maximum = CType(0US, UShort)
        Me.FrameHeightSelector.Minimum = CType(0US, UShort)
        Me.FrameHeightSelector.Name = "FrameHeightSelector"
        Me.FrameHeightSelector.ShadowColor = System.Drawing.Color.FromArgb(CType(CType(72, Byte), Integer), CType(CType(72, Byte), Integer), CType(CType(72, Byte), Integer))
        Me.FrameHeightSelector.Size = New System.Drawing.Size(67, 25)
        Me.FrameHeightSelector.TabIndex = 0
        Me.FrameHeightSelector.Value = CType(0US, UShort)
        '
        'NameLabel
        '
        Me.NameLabel.AutoSize = True
        Me.NameLabel.BackColor = System.Drawing.Color.Transparent
        Me.NameLabel.ForeColor = System.Drawing.Color.White
        Me.NameLabel.Location = New System.Drawing.Point(8, 10)
        Me.NameLabel.Name = "NameLabel"
        Me.NameLabel.Size = New System.Drawing.Size(42, 15)
        Me.NameLabel.TabIndex = 4
        Me.NameLabel.Text = "Name:"
        '
        'FrameHeightLabel
        '
        Me.FrameHeightLabel.AutoSize = True
        Me.FrameHeightLabel.BackColor = System.Drawing.Color.Transparent
        Me.FrameHeightLabel.ForeColor = System.Drawing.Color.Silver
        Me.FrameHeightLabel.Location = New System.Drawing.Point(17, 229)
        Me.FrameHeightLabel.Name = "FrameHeightLabel"
        Me.FrameHeightLabel.Size = New System.Drawing.Size(82, 15)
        Me.FrameHeightLabel.TabIndex = 0
        Me.FrameHeightLabel.Text = "Frame Height:"
        '
        'EditButton
        '
        Me.EditButton.BackColor = System.Drawing.Color.Transparent
        Me.EditButton.DText = "Edit"
        Me.EditButton.ForeColor = System.Drawing.Color.Black
        Me.EditButton.ImageOnTop = True
        Me.EditButton.LeftAligned = True
        Me.EditButton.Location = New System.Drawing.Point(10, 110)
        Me.EditButton.Name = "EditButton"
        Me.EditButton.Size = New System.Drawing.Size(116, 56)
        Me.EditButton.TabIndex = 6
        Me.EditButton.TabStop = True
        Me.EditButton.Text = "Edit"
        Me.EditButton.TextImageSpacing = CType(0, Byte)
        Me.EditButton.XIMage = Global.DarkFlow.My.Resources.Resources.EditIcon
        '
        'FImage
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(464, 360)
        Me.Controls.Add(Me.ImagePanel)
        Me.Controls.Add(Me.SidePanel)
        Me.Controls.Add(Me.MainToolStrip)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MinimumSize = New System.Drawing.Size(480, 364)
        Me.Name = "FImage"
        Me.Text = "[Image]"
        Me.MainToolStrip.ResumeLayout(False)
        Me.MainToolStrip.PerformLayout()
        Me.SidePanel.ResumeLayout(False)
        Me.SidePanel.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MainToolStrip As System.Windows.Forms.ToolStrip
    Friend WithEvents DAcceptButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents DCancelButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents TSS1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents NameLabel As System.Windows.Forms.Label
    Friend WithEvents LoadFromFileButton As DarkFlow.SexyButton
    Friend WithEvents EditButton As DarkFlow.SexyButton
    Friend WithEvents ImagePanel As DarkFlow.DoubleBufferPanel
    Friend WithEvents FrameHeightSelector As DarkFlow.SexyNumeric
    Friend WithEvents FrameHeightLabel As System.Windows.Forms.Label
    Friend WithEvents FrameWidthExplainLabel As System.Windows.Forms.Label
    Friend WithEvents SidePanel As DarkFlow.DoubleBufferPanel
    Friend WithEvents NameTextBox As DarkFlow.SexyTextBox
    Friend WithEvents DeleteButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents TSS2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents UseSampleLabel As System.Windows.Forms.Label
    Friend WithEvents SampleDropper As DarkFlow.SexyComboBox
    Friend WithEvents SaveToFileButton As DarkFlow.SexyButton
    Friend WithEvents GenerateFontImageButton As DarkFlow.SexyButton
End Class
