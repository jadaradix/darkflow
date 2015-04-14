<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FFont
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
        Me.PreviewPlace = New Dark_Flow.DoubleBufferPanel()
        Me.PreviewHolder = New Dark_Flow.DoubleBufferPanel()
        Me.Controlbar = New Dark_Flow.DoubleBufferPanel()
        Me.AntialiasCheck = New Dark_Flow.SexyCheckBox()
        Me.ItalicCheck = New Dark_Flow.SexyCheckBox()
        Me.BoldCheck = New Dark_Flow.SexyCheckBox()
        Me.FontDropper = New Dark_Flow.SexyComboBox()
        Me.FontSize = New Dark_Flow.SexyNumeric()
        Me.FontSizeLabel = New System.Windows.Forms.Label()
        Me.BaseFontLabel = New System.Windows.Forms.Label()
        Me.TileHeight = New Dark_Flow.SexyNumeric()
        Me.TileHeightLabel = New System.Windows.Forms.Label()
        Me.TileWidth = New Dark_Flow.SexyNumeric()
        Me.TileWidthLabel = New System.Windows.Forms.Label()
        Me.MainToolStrip.SuspendLayout()
        Me.PreviewPlace.SuspendLayout()
        Me.Controlbar.SuspendLayout()
        Me.SuspendLayout()
        '
        'MainToolStrip
        '
        Me.MainToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DAcceptButton, Me.TSS1, Me.DCancelButton})
        Me.MainToolStrip.Location = New System.Drawing.Point(0, 0)
        Me.MainToolStrip.Name = "MainToolStrip"
        Me.MainToolStrip.Padding = New System.Windows.Forms.Padding(0)
        Me.MainToolStrip.Size = New System.Drawing.Size(530, 25)
        Me.MainToolStrip.TabIndex = 1
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
        Me.DCancelButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.DCancelButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.DCancelButton.Name = "DCancelButton"
        Me.DCancelButton.Size = New System.Drawing.Size(47, 22)
        Me.DCancelButton.Text = "Cancel"
        '
        'PreviewPlace
        '
        Me.PreviewPlace.AutoScroll = True
        Me.PreviewPlace.BackColor = System.Drawing.Color.Transparent
        Me.PreviewPlace.BackgroundImage = Global.Dark_Flow.My.Resources.Resources.TranspBack
        Me.PreviewPlace.Controls.Add(Me.PreviewHolder)
        Me.PreviewPlace.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PreviewPlace.Location = New System.Drawing.Point(0, 115)
        Me.PreviewPlace.Name = "PreviewPlace"
        Me.PreviewPlace.Size = New System.Drawing.Size(530, 512)
        Me.PreviewPlace.TabIndex = 3
        '
        'PreviewHolder
        '
        Me.PreviewHolder.BackColor = System.Drawing.Color.Transparent
        Me.PreviewHolder.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PreviewHolder.Location = New System.Drawing.Point(0, 0)
        Me.PreviewHolder.Name = "PreviewHolder"
        Me.PreviewHolder.Size = New System.Drawing.Size(512, 512)
        Me.PreviewHolder.TabIndex = 0
        '
        'Controlbar
        '
        Me.Controlbar.BackgroundImage = Global.Dark_Flow.My.Resources.Resources.InverseGradient
        Me.Controlbar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Controlbar.Controls.Add(Me.AntialiasCheck)
        Me.Controlbar.Controls.Add(Me.ItalicCheck)
        Me.Controlbar.Controls.Add(Me.BoldCheck)
        Me.Controlbar.Controls.Add(Me.FontDropper)
        Me.Controlbar.Controls.Add(Me.FontSize)
        Me.Controlbar.Controls.Add(Me.FontSizeLabel)
        Me.Controlbar.Controls.Add(Me.BaseFontLabel)
        Me.Controlbar.Controls.Add(Me.TileHeight)
        Me.Controlbar.Controls.Add(Me.TileHeightLabel)
        Me.Controlbar.Controls.Add(Me.TileWidth)
        Me.Controlbar.Controls.Add(Me.TileWidthLabel)
        Me.Controlbar.Dock = System.Windows.Forms.DockStyle.Top
        Me.Controlbar.Location = New System.Drawing.Point(0, 25)
        Me.Controlbar.Name = "Controlbar"
        Me.Controlbar.Size = New System.Drawing.Size(530, 90)
        Me.Controlbar.TabIndex = 2
        '
        'AntialiasCheck
        '
        Me.AntialiasCheck.BackColor = System.Drawing.Color.Transparent
        Me.AntialiasCheck.Checked = False
        Me.AntialiasCheck.DText = "Antialias"
        Me.AntialiasCheck.ForeColor = System.Drawing.Color.Silver
        Me.AntialiasCheck.Location = New System.Drawing.Point(439, 50)
        Me.AntialiasCheck.Name = "AntialiasCheck"
        Me.AntialiasCheck.Size = New System.Drawing.Size(73, 18)
        Me.AntialiasCheck.TabIndex = 33
        Me.AntialiasCheck.Text = "Antialias"
        '
        'ItalicCheck
        '
        Me.ItalicCheck.BackColor = System.Drawing.Color.Transparent
        Me.ItalicCheck.Checked = False
        Me.ItalicCheck.DText = "Italic"
        Me.ItalicCheck.ForeColor = System.Drawing.Color.Silver
        Me.ItalicCheck.Location = New System.Drawing.Point(380, 50)
        Me.ItalicCheck.Name = "ItalicCheck"
        Me.ItalicCheck.Size = New System.Drawing.Size(53, 18)
        Me.ItalicCheck.TabIndex = 31
        Me.ItalicCheck.Text = "Italic"
        '
        'BoldCheck
        '
        Me.BoldCheck.BackColor = System.Drawing.Color.Transparent
        Me.BoldCheck.Checked = False
        Me.BoldCheck.DText = "Bold"
        Me.BoldCheck.ForeColor = System.Drawing.Color.Silver
        Me.BoldCheck.Location = New System.Drawing.Point(321, 50)
        Me.BoldCheck.Name = "BoldCheck"
        Me.BoldCheck.Size = New System.Drawing.Size(53, 18)
        Me.BoldCheck.TabIndex = 30
        Me.BoldCheck.Text = "Bold"
        '
        'FontDropper
        '
        Me.FontDropper.BackColor = System.Drawing.Color.Transparent
        Me.FontDropper.BorderColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.FontDropper.Image = Global.Dark_Flow.My.Resources.Resources.font
        Me.FontDropper.Location = New System.Drawing.Point(240, 14)
        Me.FontDropper.Name = "FontDropper"
        Me.FontDropper.ShadowColor = System.Drawing.Color.FromArgb(CType(CType(72, Byte), Integer), CType(CType(72, Byte), Integer), CType(CType(72, Byte), Integer))
        Me.FontDropper.Size = New System.Drawing.Size(272, 24)
        Me.FontDropper.TabIndex = 32
        '
        'FontSize
        '
        Me.FontSize.BackColor = System.Drawing.Color.Transparent
        Me.FontSize.BorderColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.FontSize.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FontSize.InputColor = System.Drawing.Color.FromArgb(CType(CType(41, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.FontSize.Location = New System.Drawing.Point(240, 45)
        Me.FontSize.Maximum = CType(100US, UShort)
        Me.FontSize.Minimum = CType(0US, UShort)
        Me.FontSize.Name = "FontSize"
        Me.FontSize.ShadowColor = System.Drawing.Color.FromArgb(CType(CType(72, Byte), Integer), CType(CType(72, Byte), Integer), CType(CType(72, Byte), Integer))
        Me.FontSize.Size = New System.Drawing.Size(75, 25)
        Me.FontSize.TabIndex = 29
        Me.FontSize.Value = CType(12US, UShort)
        '
        'FontSizeLabel
        '
        Me.FontSizeLabel.AutoSize = True
        Me.FontSizeLabel.BackColor = System.Drawing.Color.Transparent
        Me.FontSizeLabel.ForeColor = System.Drawing.Color.Silver
        Me.FontSizeLabel.Location = New System.Drawing.Point(176, 50)
        Me.FontSizeLabel.Name = "FontSizeLabel"
        Me.FontSizeLabel.Size = New System.Drawing.Size(57, 15)
        Me.FontSizeLabel.TabIndex = 28
        Me.FontSizeLabel.Text = "Font Size:"
        '
        'BaseFontLabel
        '
        Me.BaseFontLabel.AutoSize = True
        Me.BaseFontLabel.BackColor = System.Drawing.Color.Transparent
        Me.BaseFontLabel.ForeColor = System.Drawing.Color.Silver
        Me.BaseFontLabel.Location = New System.Drawing.Point(176, 19)
        Me.BaseFontLabel.Name = "BaseFontLabel"
        Me.BaseFontLabel.Size = New System.Drawing.Size(61, 15)
        Me.BaseFontLabel.TabIndex = 25
        Me.BaseFontLabel.Text = "Base Font:"
        '
        'TileHeight
        '
        Me.TileHeight.BackColor = System.Drawing.Color.Transparent
        Me.TileHeight.BorderColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.TileHeight.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TileHeight.InputColor = System.Drawing.Color.FromArgb(CType(CType(41, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TileHeight.Location = New System.Drawing.Point(85, 45)
        Me.TileHeight.Maximum = CType(64US, UShort)
        Me.TileHeight.Minimum = CType(8US, UShort)
        Me.TileHeight.Name = "TileHeight"
        Me.TileHeight.ShadowColor = System.Drawing.Color.FromArgb(CType(CType(72, Byte), Integer), CType(CType(72, Byte), Integer), CType(CType(72, Byte), Integer))
        Me.TileHeight.Size = New System.Drawing.Size(75, 25)
        Me.TileHeight.TabIndex = 27
        Me.TileHeight.Value = CType(16US, UShort)
        '
        'TileHeightLabel
        '
        Me.TileHeightLabel.AutoSize = True
        Me.TileHeightLabel.BackColor = System.Drawing.Color.Transparent
        Me.TileHeightLabel.ForeColor = System.Drawing.Color.Silver
        Me.TileHeightLabel.Location = New System.Drawing.Point(15, 50)
        Me.TileHeightLabel.Name = "TileHeightLabel"
        Me.TileHeightLabel.Size = New System.Drawing.Size(68, 15)
        Me.TileHeightLabel.TabIndex = 26
        Me.TileHeightLabel.Text = "Tile Height:"
        '
        'TileWidth
        '
        Me.TileWidth.BackColor = System.Drawing.Color.Transparent
        Me.TileWidth.BorderColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.TileWidth.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TileWidth.InputColor = System.Drawing.Color.FromArgb(CType(CType(41, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TileWidth.Location = New System.Drawing.Point(85, 14)
        Me.TileWidth.Maximum = CType(64US, UShort)
        Me.TileWidth.Minimum = CType(8US, UShort)
        Me.TileWidth.Name = "TileWidth"
        Me.TileWidth.ShadowColor = System.Drawing.Color.FromArgb(CType(CType(72, Byte), Integer), CType(CType(72, Byte), Integer), CType(CType(72, Byte), Integer))
        Me.TileWidth.Size = New System.Drawing.Size(75, 25)
        Me.TileWidth.TabIndex = 24
        Me.TileWidth.Value = CType(16US, UShort)
        '
        'TileWidthLabel
        '
        Me.TileWidthLabel.AutoSize = True
        Me.TileWidthLabel.BackColor = System.Drawing.Color.Transparent
        Me.TileWidthLabel.ForeColor = System.Drawing.Color.Silver
        Me.TileWidthLabel.Location = New System.Drawing.Point(19, 19)
        Me.TileWidthLabel.Name = "TileWidthLabel"
        Me.TileWidthLabel.Size = New System.Drawing.Size(64, 15)
        Me.TileWidthLabel.TabIndex = 23
        Me.TileWidthLabel.Text = "Tile Width:"
        '
        'FFont
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(530, 627)
        Me.Controls.Add(Me.PreviewPlace)
        Me.Controls.Add(Me.Controlbar)
        Me.Controls.Add(Me.MainToolStrip)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "FFont"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Generate Font Image"
        Me.MainToolStrip.ResumeLayout(False)
        Me.MainToolStrip.PerformLayout()
        Me.PreviewPlace.ResumeLayout(False)
        Me.Controlbar.ResumeLayout(False)
        Me.Controlbar.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MainToolStrip As System.Windows.Forms.ToolStrip
    Friend WithEvents DAcceptButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents TSS1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents DCancelButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents Controlbar As Dark_Flow.DoubleBufferPanel
    Friend WithEvents ItalicCheck As Dark_Flow.SexyCheckBox
    Friend WithEvents BoldCheck As Dark_Flow.SexyCheckBox
    Friend WithEvents FontDropper As Dark_Flow.SexyComboBox
    Friend WithEvents FontSize As Dark_Flow.SexyNumeric
    Friend WithEvents FontSizeLabel As System.Windows.Forms.Label
    Friend WithEvents BaseFontLabel As System.Windows.Forms.Label
    Friend WithEvents TileHeight As Dark_Flow.SexyNumeric
    Friend WithEvents TileHeightLabel As System.Windows.Forms.Label
    Friend WithEvents TileWidth As Dark_Flow.SexyNumeric
    Friend WithEvents TileWidthLabel As System.Windows.Forms.Label
    Friend WithEvents PreviewPlace As Dark_Flow.DoubleBufferPanel
    Friend WithEvents PreviewHolder As Dark_Flow.DoubleBufferPanel
    Friend WithEvents AntialiasCheck As Dark_Flow.SexyCheckBox
End Class
