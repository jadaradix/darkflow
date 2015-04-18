<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FExportDone
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
        Me.MainPanel = New DarkFlow.SuperPanel()
        Me.Function2 = New DarkFlow.SexyButton()
        Me.SuperPanel1 = New DarkFlow.SuperPanel()
        Me.PathLabel = New DarkFlow.SexyGDILabel()
        Me.SubInfoLabel = New DarkFlow.SexyGDILabel()
        Me.Function1 = New DarkFlow.SexyButton()
        Me.FolderIconPanel = New System.Windows.Forms.Panel()
        Me.MainInfoLabel = New DarkFlow.SexyGDILabel()
        Me.DOKButton = New DarkFlow.SexyButton()
        Me.MainPanel.SuspendLayout()
        Me.SuperPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MainPanel
        '
        Me.MainPanel.BackColor = System.Drawing.Color.Transparent
        Me.MainPanel.BorderColor = System.Drawing.Color.FromArgb(CType(CType(48, Byte), Integer), CType(CType(48, Byte), Integer), CType(CType(48, Byte), Integer))
        Me.MainPanel.BorderRadius = CType(6, Byte)
        Me.MainPanel.Controls.Add(Me.Function2)
        Me.MainPanel.Controls.Add(Me.SuperPanel1)
        Me.MainPanel.Controls.Add(Me.SubInfoLabel)
        Me.MainPanel.Controls.Add(Me.Function1)
        Me.MainPanel.Controls.Add(Me.FolderIconPanel)
        Me.MainPanel.Controls.Add(Me.MainInfoLabel)
        Me.MainPanel.GradBottomColor = System.Drawing.Color.FromArgb(CType(CType(184, Byte), Integer), CType(CType(184, Byte), Integer), CType(CType(184, Byte), Integer))
        Me.MainPanel.GradTopColor = System.Drawing.Color.FromArgb(CType(CType(210, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(210, Byte), Integer))
        Me.MainPanel.Location = New System.Drawing.Point(0, 0)
        Me.MainPanel.Name = "MainPanel"
        Me.MainPanel.Size = New System.Drawing.Size(494, 134)
        Me.MainPanel.TabIndex = 6
        '
        'Function2
        '
        Me.Function2.BackColor = System.Drawing.Color.Transparent
        Me.Function2.DText = ""
        Me.Function2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(1, Byte), Integer))
        Me.Function2.ImageOnTop = False
        Me.Function2.LeftAligned = False
        Me.Function2.Location = New System.Drawing.Point(138, 101)
        Me.Function2.Name = "Function2"
        Me.Function2.Size = New System.Drawing.Size(172, 26)
        Me.Function2.TabIndex = 9
        Me.Function2.TabStop = True
        Me.Function2.TextImageSpacing = CType(0, Byte)
        Me.Function2.XIMage = Nothing
        '
        'SuperPanel1
        '
        Me.SuperPanel1.BorderColor = System.Drawing.Color.FromArgb(CType(CType(48, Byte), Integer), CType(CType(48, Byte), Integer), CType(CType(48, Byte), Integer))
        Me.SuperPanel1.BorderRadius = CType(6, Byte)
        Me.SuperPanel1.Controls.Add(Me.PathLabel)
        Me.SuperPanel1.GradBottomColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.SuperPanel1.GradTopColor = System.Drawing.Color.White
        Me.SuperPanel1.Location = New System.Drawing.Point(42, 74)
        Me.SuperPanel1.Name = "SuperPanel1"
        Me.SuperPanel1.Size = New System.Drawing.Size(443, 24)
        Me.SuperPanel1.TabIndex = 7
        '
        'PathLabel
        '
        Me.PathLabel.DText = Nothing
        Me.PathLabel.Location = New System.Drawing.Point(5, 3)
        Me.PathLabel.Name = "PathLabel"
        Me.PathLabel.Size = New System.Drawing.Size(434, 18)
        Me.PathLabel.TabIndex = 7
        '
        'SubInfoLabel
        '
        Me.SubInfoLabel.DText = Nothing
        Me.SubInfoLabel.Location = New System.Drawing.Point(12, 42)
        Me.SubInfoLabel.Name = "SubInfoLabel"
        Me.SubInfoLabel.Size = New System.Drawing.Size(472, 28)
        Me.SubInfoLabel.TabIndex = 1
        '
        'Function1
        '
        Me.Function1.BackColor = System.Drawing.Color.Transparent
        Me.Function1.DText = ""
        Me.Function1.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Function1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(1, Byte), Integer))
        Me.Function1.ImageOnTop = False
        Me.Function1.LeftAligned = False
        Me.Function1.Location = New System.Drawing.Point(312, 101)
        Me.Function1.Name = "Function1"
        Me.Function1.Size = New System.Drawing.Size(172, 26)
        Me.Function1.TabIndex = 8
        Me.Function1.TabStop = True
        Me.Function1.TextImageSpacing = CType(0, Byte)
        Me.Function1.XIMage = Nothing
        '
        'FolderIconPanel
        '
        Me.FolderIconPanel.BackgroundImage = Global.DarkFlow.My.Resources.Resources.OpenFileIcon
        Me.FolderIconPanel.Location = New System.Drawing.Point(12, 74)
        Me.FolderIconPanel.Name = "FolderIconPanel"
        Me.FolderIconPanel.Size = New System.Drawing.Size(24, 24)
        Me.FolderIconPanel.TabIndex = 2
        '
        'MainInfoLabel
        '
        Me.MainInfoLabel.DText = Nothing
        Me.MainInfoLabel.Location = New System.Drawing.Point(12, 12)
        Me.MainInfoLabel.Name = "MainInfoLabel"
        Me.MainInfoLabel.Size = New System.Drawing.Size(472, 28)
        Me.MainInfoLabel.TabIndex = 0
        '
        'DOKButton
        '
        Me.DOKButton.BackColor = System.Drawing.Color.Transparent
        Me.DOKButton.DText = "OK"
        Me.DOKButton.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(1, Byte), Integer))
        Me.DOKButton.ImageOnTop = False
        Me.DOKButton.LeftAligned = False
        Me.DOKButton.Location = New System.Drawing.Point(383, 138)
        Me.DOKButton.Name = "DOKButton"
        Me.DOKButton.Size = New System.Drawing.Size(111, 30)
        Me.DOKButton.TabIndex = 2
        Me.DOKButton.TabStop = True
        Me.DOKButton.Text = "OK"
        Me.DOKButton.TextImageSpacing = CType(0, Byte)
        Me.DOKButton.XIMage = Nothing
        '
        'FExportDone
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(494, 168)
        Me.Controls.Add(Me.MainPanel)
        Me.Controls.Add(Me.DOKButton)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FExportDone"
        Me.Padding = New System.Windows.Forms.Padding(6, 6, 6, 44)
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Export Complete"
        Me.MainPanel.ResumeLayout(False)
        Me.SuperPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents DOKButton As DarkFlow.SexyButton
    Friend WithEvents MainPanel As DarkFlow.SuperPanel
    Friend WithEvents MainInfoLabel As DarkFlow.SexyGDILabel
    Friend WithEvents SubInfoLabel As DarkFlow.SexyGDILabel
    Friend WithEvents FolderIconPanel As System.Windows.Forms.Panel
    Friend WithEvents Function1 As DarkFlow.SexyButton
    Friend WithEvents SuperPanel1 As DarkFlow.SuperPanel
    Friend WithEvents PathLabel As DarkFlow.SexyGDILabel
    Friend WithEvents Function2 As DarkFlow.SexyButton
End Class
