<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FInputBox
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
        Me.DCancelButton = New Dark_Flow.SexyButton()
        Me.DOkayButton = New Dark_Flow.SexyButton()
        Me.MainTextBox = New Dark_Flow.SexyTextBox()
        Me.DescriptionLabel = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'DCancelButton
        '
        Me.DCancelButton.BackColor = System.Drawing.Color.Transparent
        Me.DCancelButton.DText = "Cancel"
        Me.DCancelButton.ForeColor = System.Drawing.Color.Black
        Me.DCancelButton.ImageOnTop = False
        Me.DCancelButton.LeftAligned = False
        Me.DCancelButton.Location = New System.Drawing.Point(248, 42)
        Me.DCancelButton.Name = "DCancelButton"
        Me.DCancelButton.Size = New System.Drawing.Size(84, 26)
        Me.DCancelButton.TabIndex = 7
        Me.DCancelButton.TabStop = True
        Me.DCancelButton.Text = "Cancel"
        Me.DCancelButton.TextImageSpacing = CType(0, Byte)
        Me.DCancelButton.XIMage = Nothing
        '
        'DOkayButton
        '
        Me.DOkayButton.BackColor = System.Drawing.Color.Transparent
        Me.DOkayButton.DText = "OK"
        Me.DOkayButton.ForeColor = System.Drawing.Color.Black
        Me.DOkayButton.ImageOnTop = False
        Me.DOkayButton.LeftAligned = False
        Me.DOkayButton.Location = New System.Drawing.Point(248, 14)
        Me.DOkayButton.Name = "DOkayButton"
        Me.DOkayButton.Size = New System.Drawing.Size(84, 26)
        Me.DOkayButton.TabIndex = 6
        Me.DOkayButton.TabStop = True
        Me.DOkayButton.Text = "OK"
        Me.DOkayButton.TextImageSpacing = CType(0, Byte)
        Me.DOkayButton.XIMage = Nothing
        '
        'MainTextBox
        '
        Me.MainTextBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.MainTextBox.BackColor = System.Drawing.Color.Transparent
        Me.MainTextBox.BorderColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.MainTextBox.Location = New System.Drawing.Point(12, 83)
        Me.MainTextBox.MultiLine = False
        Me.MainTextBox.Name = "MainTextBox"
        Me.MainTextBox.ShadowColor = System.Drawing.Color.FromArgb(CType(CType(72, Byte), Integer), CType(CType(72, Byte), Integer), CType(CType(72, Byte), Integer))
        Me.MainTextBox.Size = New System.Drawing.Size(320, 23)
        Me.MainTextBox.TabIndex = 5
        Me.MainTextBox.UseSystemPasswordChar = False
        '
        'DescriptionLabel
        '
        Me.DescriptionLabel.AutoSize = True
        Me.DescriptionLabel.Location = New System.Drawing.Point(12, 11)
        Me.DescriptionLabel.Name = "DescriptionLabel"
        Me.DescriptionLabel.Size = New System.Drawing.Size(95, 15)
        Me.DescriptionLabel.TabIndex = 4
        Me.DescriptionLabel.Text = "DescriptionLabel"
        '
        'FInputBox
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(344, 114)
        Me.Controls.Add(Me.DCancelButton)
        Me.Controls.Add(Me.DOkayButton)
        Me.Controls.Add(Me.MainTextBox)
        Me.Controls.Add(Me.DescriptionLabel)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FInputBox"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "FInputBox"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DCancelButton As SexyButton
    Friend WithEvents DOkayButton As SexyButton
    Friend WithEvents MainTextBox As SexyTextBox
    Friend WithEvents DescriptionLabel As System.Windows.Forms.Label
End Class
