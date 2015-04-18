<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SexyTextBox
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Me.TextContainer = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'TextContainer
        '
        Me.TextContainer.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextContainer.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextContainer.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextContainer.Location = New System.Drawing.Point(5, 4)
        Me.TextContainer.Name = "TextContainer"
        Me.TextContainer.Size = New System.Drawing.Size(191, 16)
        Me.TextContainer.TabIndex = 0
        '
        'SexyTextBox
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.TextContainer)
        Me.Name = "SexyTextBox"
        Me.Size = New System.Drawing.Size(201, 24)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TextContainer As System.Windows.Forms.TextBox

End Class
