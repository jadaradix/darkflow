<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FSelectPlatform
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
        Me.HeaderPanel = New System.Windows.Forms.Panel()
        Me.DCancelButton = New Dark_Flow.SexyButton()
        Me.TitleLabel = New System.Windows.Forms.Label()
        Me.BrowserHeaderLabel = New System.Windows.Forms.Label()
        Me.RunnerHeaderLabel = New System.Windows.Forms.Label()
        Me.HeaderPanel.SuspendLayout()
        Me.SuspendLayout()
        '
        'HeaderPanel
        '
        Me.HeaderPanel.BackColor = System.Drawing.Color.White
        Me.HeaderPanel.Controls.Add(Me.DCancelButton)
        Me.HeaderPanel.Controls.Add(Me.TitleLabel)
        Me.HeaderPanel.Dock = System.Windows.Forms.DockStyle.Top
        Me.HeaderPanel.Location = New System.Drawing.Point(0, 0)
        Me.HeaderPanel.Name = "HeaderPanel"
        Me.HeaderPanel.Size = New System.Drawing.Size(354, 38)
        Me.HeaderPanel.TabIndex = 1
        '
        'DCancelButton
        '
        Me.DCancelButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DCancelButton.BackColor = System.Drawing.Color.Transparent
        Me.DCancelButton.DText = "Cancel"
        Me.DCancelButton.ForeColor = System.Drawing.Color.Black
        Me.DCancelButton.ImageOnTop = False
        Me.DCancelButton.LeftAligned = False
        Me.DCancelButton.Location = New System.Drawing.Point(284, 6)
        Me.DCancelButton.Name = "DCancelButton"
        Me.DCancelButton.ShrinkMyIcon = False
        Me.DCancelButton.Size = New System.Drawing.Size(64, 26)
        Me.DCancelButton.TabIndex = 3
        Me.DCancelButton.TabStop = True
        Me.DCancelButton.Text = "Cancel"
        Me.DCancelButton.TextImageSpacing = CType(0, Byte)
        Me.DCancelButton.XIMage = Nothing
        '
        'TitleLabel
        '
        Me.TitleLabel.AutoSize = True
        Me.TitleLabel.Font = New System.Drawing.Font("Segoe UI Light", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TitleLabel.Location = New System.Drawing.Point(8, 8)
        Me.TitleLabel.Name = "TitleLabel"
        Me.TitleLabel.Size = New System.Drawing.Size(109, 21)
        Me.TitleLabel.TabIndex = 2
        Me.TitleLabel.Text = "Select Platform"
        '
        'BrowserHeaderLabel
        '
        Me.BrowserHeaderLabel.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BrowserHeaderLabel.BackColor = System.Drawing.Color.Gray
        Me.BrowserHeaderLabel.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BrowserHeaderLabel.ForeColor = System.Drawing.Color.White
        Me.BrowserHeaderLabel.Location = New System.Drawing.Point(0, 175)
        Me.BrowserHeaderLabel.Name = "BrowserHeaderLabel"
        Me.BrowserHeaderLabel.Padding = New System.Windows.Forms.Padding(5)
        Me.BrowserHeaderLabel.Size = New System.Drawing.Size(354, 26)
        Me.BrowserHeaderLabel.TabIndex = 9
        Me.BrowserHeaderLabel.Text = ":: Browser ::"
        Me.BrowserHeaderLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'RunnerHeaderLabel
        '
        Me.RunnerHeaderLabel.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RunnerHeaderLabel.BackColor = System.Drawing.Color.Gray
        Me.RunnerHeaderLabel.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RunnerHeaderLabel.ForeColor = System.Drawing.Color.White
        Me.RunnerHeaderLabel.Location = New System.Drawing.Point(0, 40)
        Me.RunnerHeaderLabel.Name = "RunnerHeaderLabel"
        Me.RunnerHeaderLabel.Padding = New System.Windows.Forms.Padding(5)
        Me.RunnerHeaderLabel.Size = New System.Drawing.Size(354, 26)
        Me.RunnerHeaderLabel.TabIndex = 12
        Me.RunnerHeaderLabel.Text = ":: Console ::"
        Me.RunnerHeaderLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'FSelectPlatform
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(354, 317)
        Me.ControlBox = False
        Me.Controls.Add(Me.RunnerHeaderLabel)
        Me.Controls.Add(Me.BrowserHeaderLabel)
        Me.Controls.Add(Me.HeaderPanel)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FSelectPlatform"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = " "
        Me.HeaderPanel.ResumeLayout(False)
        Me.HeaderPanel.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents HeaderPanel As System.Windows.Forms.Panel
    Friend WithEvents TitleLabel As System.Windows.Forms.Label
    Friend WithEvents BrowserHeaderLabel As System.Windows.Forms.Label
    Friend WithEvents RunnerHeaderLabel As System.Windows.Forms.Label
    Friend WithEvents DCancelButton As Dark_Flow.SexyButton
End Class
