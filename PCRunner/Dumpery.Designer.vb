<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Dumpery
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Dumpery))
        Me.MainToolStrip = New System.Windows.Forms.ToolStrip()
        Me.SaveButton = New System.Windows.Forms.ToolStripButton()
        Me.ObjectNameLabel = New System.Windows.Forms.ToolStripLabel()
        Me.DataList = New System.Windows.Forms.ListView()
        Me.NameColumn = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ValueColumn = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.MainToolStrip.SuspendLayout()
        Me.SuspendLayout()
        '
        'MainToolStrip
        '
        Me.MainToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SaveButton, Me.ObjectNameLabel})
        Me.MainToolStrip.Location = New System.Drawing.Point(0, 0)
        Me.MainToolStrip.Name = "MainToolStrip"
        Me.MainToolStrip.Size = New System.Drawing.Size(324, 25)
        Me.MainToolStrip.TabIndex = 1
        Me.MainToolStrip.Text = "ToolStrip1"
        '
        'SaveButton
        '
        Me.SaveButton.Image = Global.PCRunner.My.Resources.Resources.SaveFileIcon
        Me.SaveButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.SaveButton.Name = "SaveButton"
        Me.SaveButton.Size = New System.Drawing.Size(51, 22)
        Me.SaveButton.Text = "Save"
        '
        'ObjectNameLabel
        '
        Me.ObjectNameLabel.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ObjectNameLabel.Name = "ObjectNameLabel"
        Me.ObjectNameLabel.Size = New System.Drawing.Size(85, 22)
        Me.ObjectNameLabel.Text = "[Object Name]"
        '
        'DataList
        '
        Me.DataList.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.NameColumn, Me.ValueColumn})
        Me.DataList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataList.GridLines = True
        Me.DataList.Location = New System.Drawing.Point(0, 25)
        Me.DataList.Name = "DataList"
        Me.DataList.Size = New System.Drawing.Size(324, 261)
        Me.DataList.TabIndex = 2
        Me.DataList.UseCompatibleStateImageBehavior = False
        Me.DataList.View = System.Windows.Forms.View.Details
        '
        'NameColumn
        '
        Me.NameColumn.Text = "Variable"
        Me.NameColumn.Width = 128
        '
        'ValueColumn
        '
        Me.ValueColumn.Text = "Value"
        Me.ValueColumn.Width = 192
        '
        'Dumpery
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(324, 286)
        Me.Controls.Add(Me.DataList)
        Me.Controls.Add(Me.MainToolStrip)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Dumpery"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Dump"
        Me.MainToolStrip.ResumeLayout(False)
        Me.MainToolStrip.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MainToolStrip As System.Windows.Forms.ToolStrip
    Friend WithEvents SaveButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents ObjectNameLabel As System.Windows.Forms.ToolStripLabel
    Friend WithEvents DataList As System.Windows.Forms.ListView
    Friend WithEvents NameColumn As System.Windows.Forms.ColumnHeader
    Friend WithEvents ValueColumn As System.Windows.Forms.ColumnHeader
End Class
