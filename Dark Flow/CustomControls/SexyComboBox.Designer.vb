<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SexyComboBox
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SexyComboBox))
        Me.FrontSkin = New Dark_Flow.DoubleBufferPanel()
        Me.BackCombo = New Dark_Flow.SexyDropper()
        Me.SuspendLayout()
        '
        'FrontSkin
        '
        Me.FrontSkin.Location = New System.Drawing.Point(0, 0)
        Me.FrontSkin.Name = "FrontSkin"
        Me.FrontSkin.Size = New System.Drawing.Size(198, 29)
        Me.FrontSkin.TabIndex = 1
        '
        'BackCombo
        '
        Me.BackCombo.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BackCombo.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.BackCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.BackCombo.DropDownWidth = 121
        Me.BackCombo.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BackCombo.FromColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.BackCombo.HighlightSelected = False
        Me.BackCombo.ItemHeight = 18
        Me.BackCombo.Location = New System.Drawing.Point(0, 3)
        Me.BackCombo.Name = "BackCombo"
        Me.BackCombo.RImage = CType(resources.GetObject("BackCombo.RImage"), System.Drawing.Image)
        Me.BackCombo.Size = New System.Drawing.Size(198, 24)
        Me.BackCombo.TabIndex = 0
        Me.BackCombo.ToColor = System.Drawing.Color.Silver
        '
        'SexyComboBox
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.Transparent
        Me.Controls.Add(Me.FrontSkin)
        Me.Controls.Add(Me.BackCombo)
        Me.Name = "SexyComboBox"
        Me.Size = New System.Drawing.Size(198, 29)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents BackCombo As Dark_Flow.SexyDropper
    Friend WithEvents FrontSkin As Dark_Flow.DoubleBufferPanel

End Class
