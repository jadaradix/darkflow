<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SelectFile
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
        Me.DOKButton = New Button
        Me.ListContainer = New Panel
        Me.FilesListBox = New System.Windows.Forms.ListBox()
        Me.ListContainer.SuspendLayout()
        Me.SuspendLayout()
        '
        'DOKButton
        '
        Me.DOKButton.BackColor = System.Drawing.Color.Transparent
        Me.DOKButton.Text = "OK"
        Me.DOKButton.ForeColor = System.Drawing.Color.Black
        Me.DOKButton.ImageAlign = ContentAlignment.MiddleCenter
        Me.DOKButton.TextAlign = ContentAlignment.MiddleCenter
        Me.DOKButton.Location = New System.Drawing.Point(181, 226)
        Me.DOKButton.Name = "DOKButton"
        Me.DOKButton.Size = New System.Drawing.Size(111, 30)
        Me.DOKButton.TabIndex = 1
        Me.DOKButton.TabStop = True
        Me.DOKButton.Text = "OK"
        '
        'ListContainer
        '
        Me.ListContainer.BackColor = System.Drawing.Color.Transparent
        Me.ListContainer.Controls.Add(Me.FilesListBox)
        Me.ListContainer.Location = New System.Drawing.Point(0, 0)
        Me.ListContainer.Name = "ListContainer"
        Me.ListContainer.Size = New System.Drawing.Size(292, 220)
        Me.ListContainer.TabIndex = 0
        '
        'FilesListBox
        '
        Me.FilesListBox.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.FilesListBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable
        Me.FilesListBox.FormattingEnabled = True
        Me.FilesListBox.ItemHeight = 36
        Me.FilesListBox.Location = New System.Drawing.Point(4, 4)
        Me.FilesListBox.Name = "FilesListBox"
        Me.FilesListBox.Size = New System.Drawing.Size(284, 212)
        Me.FilesListBox.TabIndex = 1
        '
        'SelectFile
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(292, 256)
        Me.Controls.Add(Me.DOKButton)
        Me.Controls.Add(Me.ListContainer)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "SelectFile"
        Me.Padding = New System.Windows.Forms.Padding(6, 28, 6, 44)
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Select File"
        Me.ListContainer.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ListContainer As Panel
    Friend WithEvents FilesListBox As System.Windows.Forms.ListBox
    Friend WithEvents DOKButton As Button
End Class
