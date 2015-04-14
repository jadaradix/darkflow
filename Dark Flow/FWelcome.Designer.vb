<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FWelcome
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
        Me.ExamplesGrouper = New Dark_Flow.SexyGroupBox()
        Me.SuperPanel1 = New Dark_Flow.SuperPanel()
        Me.ExamplesList = New System.Windows.Forms.ListBox()
        Me.OpenExampleButton = New Dark_Flow.SexyButton()
        Me.OpenLastProjectButton = New Dark_Flow.SexyButton()
        Me.ExamplesGrouper.SuspendLayout()
        Me.SuperPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ExamplesGrouper
        '
        Me.ExamplesGrouper.BorderColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.ExamplesGrouper.Controls.Add(Me.SuperPanel1)
        Me.ExamplesGrouper.Controls.Add(Me.OpenExampleButton)
        Me.ExamplesGrouper.Location = New System.Drawing.Point(0, 44)
        Me.ExamplesGrouper.Name = "ExamplesGrouper"
        Me.ExamplesGrouper.Size = New System.Drawing.Size(260, 248)
        Me.ExamplesGrouper.TabIndex = 2
        Me.ExamplesGrouper.TabStop = False
        Me.ExamplesGrouper.Text = "Examples"
        '
        'SuperPanel1
        '
        Me.SuperPanel1.BackColor = System.Drawing.Color.Transparent
        Me.SuperPanel1.BorderColor = System.Drawing.Color.Gray
        Me.SuperPanel1.BorderRadius = CType(6, Byte)
        Me.SuperPanel1.Controls.Add(Me.ExamplesList)
        Me.SuperPanel1.GradBottomColor = System.Drawing.Color.White
        Me.SuperPanel1.GradTopColor = System.Drawing.Color.White
        Me.SuperPanel1.Location = New System.Drawing.Point(9, 25)
        Me.SuperPanel1.Name = "SuperPanel1"
        Me.SuperPanel1.Size = New System.Drawing.Size(243, 178)
        Me.SuperPanel1.TabIndex = 4
        '
        'ExamplesList
        '
        Me.ExamplesList.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ExamplesList.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ExamplesList.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable
        Me.ExamplesList.FormattingEnabled = True
        Me.ExamplesList.ItemHeight = 24
        Me.ExamplesList.Location = New System.Drawing.Point(4, 4)
        Me.ExamplesList.Name = "ExamplesList"
        Me.ExamplesList.Size = New System.Drawing.Size(235, 170)
        Me.ExamplesList.TabIndex = 6
        '
        'OpenExampleButton
        '
        Me.OpenExampleButton.BackColor = System.Drawing.Color.Transparent
        Me.OpenExampleButton.DText = "Open"
        Me.OpenExampleButton.ForeColor = System.Drawing.Color.Black
        Me.OpenExampleButton.ImageOnTop = False
        Me.OpenExampleButton.LeftAligned = False
        Me.OpenExampleButton.Location = New System.Drawing.Point(160, 207)
        Me.OpenExampleButton.Name = "OpenExampleButton"
        Me.OpenExampleButton.ShrinkMyIcon = False
        Me.OpenExampleButton.Size = New System.Drawing.Size(92, 30)
        Me.OpenExampleButton.TabIndex = 1
        Me.OpenExampleButton.TabStop = True
        Me.OpenExampleButton.Text = "Open"
        Me.OpenExampleButton.TextImageSpacing = CType(0, Byte)
        Me.OpenExampleButton.XIMage = Nothing
        '
        'OpenLastProjectButton
        '
        Me.OpenLastProjectButton.BackColor = System.Drawing.Color.Transparent
        Me.OpenLastProjectButton.DText = "  Open Last Project"
        Me.OpenLastProjectButton.ForeColor = System.Drawing.Color.Black
        Me.OpenLastProjectButton.ImageOnTop = False
        Me.OpenLastProjectButton.LeftAligned = True
        Me.OpenLastProjectButton.Location = New System.Drawing.Point(0, 0)
        Me.OpenLastProjectButton.Name = "OpenLastProjectButton"
        Me.OpenLastProjectButton.ShrinkMyIcon = False
        Me.OpenLastProjectButton.Size = New System.Drawing.Size(260, 36)
        Me.OpenLastProjectButton.TabIndex = 1
        Me.OpenLastProjectButton.TabStop = True
        Me.OpenLastProjectButton.Text = "  Open Last Project"
        Me.OpenLastProjectButton.TextImageSpacing = CType(0, Byte)
        Me.OpenLastProjectButton.XIMage = Global.Dark_Flow.My.Resources.Resources.OpenFileIcon
        '
        'FWelcome
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(260, 292)
        Me.Controls.Add(Me.ExamplesGrouper)
        Me.Controls.Add(Me.OpenLastProjectButton)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(276, 330)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(276, 330)
        Me.Name = "FWelcome"
        Me.Text = "Welcome"
        Me.ExamplesGrouper.ResumeLayout(False)
        Me.SuperPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents OpenExampleButton As Dark_Flow.SexyButton
    Friend WithEvents OpenLastProjectButton As Dark_Flow.SexyButton
    Friend WithEvents ExamplesGrouper As Dark_Flow.SexyGroupBox
    Friend WithEvents SuperPanel1 As Dark_Flow.SuperPanel
    Friend WithEvents ExamplesList As System.Windows.Forms.ListBox
End Class
