<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FEditCode
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
        Me.MainTextBox = New FastColoredTextBoxNS.FastColoredTextBox()
        Me.MainToolStrip = New System.Windows.Forms.ToolStrip()
        Me.DAcceptButton = New System.Windows.Forms.ToolStripButton()
        Me.MTSSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.LoadInButton = New System.Windows.Forms.ToolStripButton()
        Me.SaveOutButton = New System.Windows.Forms.ToolStripButton()
        Me.MainToolStrip.SuspendLayout()
        Me.SuspendLayout()
        '
        'MainTextBox
        '
        Me.MainTextBox.AutoScrollMinSize = New System.Drawing.Size(25, 15)
        Me.MainTextBox.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.MainTextBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MainTextBox.Location = New System.Drawing.Point(0, 25)
        Me.MainTextBox.Name = "MainTextBox"
        Me.MainTextBox.Size = New System.Drawing.Size(624, 417)
        Me.MainTextBox.TabIndex = 0
        '
        'MainToolStrip
        '
        Me.MainToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DAcceptButton, Me.MTSSeparator1, Me.LoadInButton, Me.SaveOutButton})
        Me.MainToolStrip.Location = New System.Drawing.Point(0, 0)
        Me.MainToolStrip.Name = "MainToolStrip"
        Me.MainToolStrip.Size = New System.Drawing.Size(624, 25)
        Me.MainToolStrip.TabIndex = 1
        Me.MainToolStrip.Text = "ToolStrip1"
        '
        'DAcceptButton
        '
        Me.DAcceptButton.Image = Global.DarkFlow.My.Resources.Resources.AcceptIcon
        Me.DAcceptButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.DAcceptButton.Name = "DAcceptButton"
        Me.DAcceptButton.Size = New System.Drawing.Size(64, 22)
        Me.DAcceptButton.Text = "Accept"
        '
        'MTSSeparator1
        '
        Me.MTSSeparator1.Name = "MTSSeparator1"
        Me.MTSSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'LoadInButton
        '
        Me.LoadInButton.Image = Global.DarkFlow.My.Resources.Resources.OpenFileIcon
        Me.LoadInButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.LoadInButton.Name = "LoadInButton"
        Me.LoadInButton.Size = New System.Drawing.Size(75, 22)
        Me.LoadInButton.Text = "Load In..."
        '
        'SaveOutButton
        '
        Me.SaveOutButton.Image = Global.DarkFlow.My.Resources.Resources.SaveFileIcon
        Me.SaveOutButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.SaveOutButton.Name = "SaveOutButton"
        Me.SaveOutButton.Size = New System.Drawing.Size(83, 22)
        Me.SaveOutButton.Text = "Save Out..."
        '
        'FEditCode
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(624, 442)
        Me.Controls.Add(Me.MainTextBox)
        Me.Controls.Add(Me.MainToolStrip)
        Me.Name = "FEditCode"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Code Editor"
        Me.MainToolStrip.ResumeLayout(False)
        Me.MainToolStrip.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MainTextBox As FastColoredTextBoxNS.FastColoredTextBox
    Friend WithEvents MainToolStrip As System.Windows.Forms.ToolStrip
    Friend WithEvents DAcceptButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents MTSSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents LoadInButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents SaveOutButton As System.Windows.Forms.ToolStripButton
End Class
