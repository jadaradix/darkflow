<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FPlatformInputs
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
        Me.DataPanel = New DarkFlow.SuperPanel()
        Me.DataAcceptButton = New DarkFlow.SexyButton()
        Me.EditExecutorButton = New DarkFlow.SexyButton()
        Me.DeleteExecutorButton = New DarkFlow.SexyButton()
        Me.AddExecutorButton = New DarkFlow.SexyButton()
        Me.EditInputButton = New DarkFlow.SexyButton()
        Me.DeleteInputButton = New DarkFlow.SexyButton()
        Me.AddInputButton = New DarkFlow.SexyButton()
        Me.DOKButton = New DarkFlow.SexyButton()
        Me.MainListBacker = New DarkFlow.SuperPanel()
        Me.MainList = New System.Windows.Forms.ListBox()
        Me.SubListBacker = New DarkFlow.SuperPanel()
        Me.SubList = New System.Windows.Forms.ListBox()
        Me.DataPanel.SuspendLayout()
        Me.MainListBacker.SuspendLayout()
        Me.SubListBacker.SuspendLayout()
        Me.SuspendLayout()
        '
        'DataPanel
        '
        Me.DataPanel.BackColor = System.Drawing.Color.Transparent
        Me.DataPanel.BorderColor = System.Drawing.Color.FromArgb(CType(CType(48, Byte), Integer), CType(CType(48, Byte), Integer), CType(CType(48, Byte), Integer))
        Me.DataPanel.BorderRadius = CType(6, Byte)
        Me.DataPanel.Controls.Add(Me.DataAcceptButton)
        Me.DataPanel.GradBottomColor = System.Drawing.Color.FromArgb(CType(CType(184, Byte), Integer), CType(CType(184, Byte), Integer), CType(CType(184, Byte), Integer))
        Me.DataPanel.GradTopColor = System.Drawing.Color.FromArgb(CType(CType(210, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(210, Byte), Integer))
        Me.DataPanel.Location = New System.Drawing.Point(0, 183)
        Me.DataPanel.Name = "DataPanel"
        Me.DataPanel.Size = New System.Drawing.Size(200, 111)
        Me.DataPanel.TabIndex = 30
        Me.DataPanel.Visible = False
        '
        'DataAcceptButton
        '
        Me.DataAcceptButton.BackColor = System.Drawing.Color.Transparent
        Me.DataAcceptButton.DText = "Accept"
        Me.DataAcceptButton.ForeColor = System.Drawing.Color.Black
        Me.DataAcceptButton.ImageOnTop = False
        Me.DataAcceptButton.LeftAligned = False
        Me.DataAcceptButton.Location = New System.Drawing.Point(111, 77)
        Me.DataAcceptButton.Name = "DataAcceptButton"
        Me.DataAcceptButton.ShrinkMyIcon = False
        Me.DataAcceptButton.Size = New System.Drawing.Size(86, 30)
        Me.DataAcceptButton.TabIndex = 5
        Me.DataAcceptButton.TabStop = True
        Me.DataAcceptButton.Text = "Accept"
        Me.DataAcceptButton.TextImageSpacing = CType(0, Byte)
        Me.DataAcceptButton.XIMage = Global.DarkFlow.My.Resources.Resources.AcceptIcon
        '
        'EditExecutorButton
        '
        Me.EditExecutorButton.BackColor = System.Drawing.Color.Transparent
        Me.EditExecutorButton.DText = ""
        Me.EditExecutorButton.ForeColor = System.Drawing.Color.Black
        Me.EditExecutorButton.ImageOnTop = False
        Me.EditExecutorButton.LeftAligned = True
        Me.EditExecutorButton.Location = New System.Drawing.Point(237, 261)
        Me.EditExecutorButton.Name = "EditExecutorButton"
        Me.EditExecutorButton.ShrinkMyIcon = True
        Me.EditExecutorButton.Size = New System.Drawing.Size(32, 23)
        Me.EditExecutorButton.TabIndex = 29
        Me.EditExecutorButton.TabStop = True
        Me.EditExecutorButton.TextImageSpacing = CType(0, Byte)
        Me.EditExecutorButton.XIMage = Global.DarkFlow.My.Resources.Resources.EditIcon
        '
        'DeleteExecutorButton
        '
        Me.DeleteExecutorButton.BackColor = System.Drawing.Color.Transparent
        Me.DeleteExecutorButton.DText = ""
        Me.DeleteExecutorButton.ForeColor = System.Drawing.Color.Black
        Me.DeleteExecutorButton.ImageOnTop = False
        Me.DeleteExecutorButton.LeftAligned = True
        Me.DeleteExecutorButton.Location = New System.Drawing.Point(271, 261)
        Me.DeleteExecutorButton.Name = "DeleteExecutorButton"
        Me.DeleteExecutorButton.ShrinkMyIcon = True
        Me.DeleteExecutorButton.Size = New System.Drawing.Size(32, 23)
        Me.DeleteExecutorButton.TabIndex = 28
        Me.DeleteExecutorButton.TabStop = True
        Me.DeleteExecutorButton.TextImageSpacing = CType(0, Byte)
        Me.DeleteExecutorButton.XIMage = Global.DarkFlow.My.Resources.Resources.DeleteIcon
        '
        'AddExecutorButton
        '
        Me.AddExecutorButton.BackColor = System.Drawing.Color.Transparent
        Me.AddExecutorButton.DText = ""
        Me.AddExecutorButton.ForeColor = System.Drawing.Color.Black
        Me.AddExecutorButton.ImageOnTop = False
        Me.AddExecutorButton.LeftAligned = True
        Me.AddExecutorButton.Location = New System.Drawing.Point(203, 261)
        Me.AddExecutorButton.Name = "AddExecutorButton"
        Me.AddExecutorButton.ShrinkMyIcon = True
        Me.AddExecutorButton.Size = New System.Drawing.Size(32, 23)
        Me.AddExecutorButton.TabIndex = 27
        Me.AddExecutorButton.TabStop = True
        Me.AddExecutorButton.TextImageSpacing = CType(0, Byte)
        Me.AddExecutorButton.XIMage = Global.DarkFlow.My.Resources.Resources.AddIcon
        '
        'EditInputButton
        '
        Me.EditInputButton.BackColor = System.Drawing.Color.Transparent
        Me.EditInputButton.DText = ""
        Me.EditInputButton.ForeColor = System.Drawing.Color.Black
        Me.EditInputButton.ImageOnTop = False
        Me.EditInputButton.LeftAligned = True
        Me.EditInputButton.Location = New System.Drawing.Point(34, 153)
        Me.EditInputButton.Name = "EditInputButton"
        Me.EditInputButton.ShrinkMyIcon = True
        Me.EditInputButton.Size = New System.Drawing.Size(32, 23)
        Me.EditInputButton.TabIndex = 26
        Me.EditInputButton.TabStop = True
        Me.EditInputButton.TextImageSpacing = CType(0, Byte)
        Me.EditInputButton.XIMage = Global.DarkFlow.My.Resources.Resources.EditIcon
        '
        'DeleteInputButton
        '
        Me.DeleteInputButton.BackColor = System.Drawing.Color.Transparent
        Me.DeleteInputButton.DText = ""
        Me.DeleteInputButton.ForeColor = System.Drawing.Color.Black
        Me.DeleteInputButton.ImageOnTop = False
        Me.DeleteInputButton.LeftAligned = True
        Me.DeleteInputButton.Location = New System.Drawing.Point(68, 153)
        Me.DeleteInputButton.Name = "DeleteInputButton"
        Me.DeleteInputButton.ShrinkMyIcon = True
        Me.DeleteInputButton.Size = New System.Drawing.Size(32, 23)
        Me.DeleteInputButton.TabIndex = 25
        Me.DeleteInputButton.TabStop = True
        Me.DeleteInputButton.TextImageSpacing = CType(0, Byte)
        Me.DeleteInputButton.XIMage = Global.DarkFlow.My.Resources.Resources.DeleteIcon
        '
        'AddInputButton
        '
        Me.AddInputButton.BackColor = System.Drawing.Color.Transparent
        Me.AddInputButton.DText = ""
        Me.AddInputButton.ForeColor = System.Drawing.Color.Black
        Me.AddInputButton.ImageOnTop = False
        Me.AddInputButton.LeftAligned = True
        Me.AddInputButton.Location = New System.Drawing.Point(0, 153)
        Me.AddInputButton.Name = "AddInputButton"
        Me.AddInputButton.ShrinkMyIcon = True
        Me.AddInputButton.Size = New System.Drawing.Size(32, 23)
        Me.AddInputButton.TabIndex = 24
        Me.AddInputButton.TabStop = True
        Me.AddInputButton.TextImageSpacing = CType(0, Byte)
        Me.AddInputButton.XIMage = Global.DarkFlow.My.Resources.Resources.AddIcon
        '
        'DOKButton
        '
        Me.DOKButton.BackColor = System.Drawing.Color.Transparent
        Me.DOKButton.DText = "OK"
        Me.DOKButton.ForeColor = System.Drawing.Color.Black
        Me.DOKButton.ImageOnTop = False
        Me.DOKButton.LeftAligned = False
        Me.DOKButton.Location = New System.Drawing.Point(377, 264)
        Me.DOKButton.Name = "DOKButton"
        Me.DOKButton.ShrinkMyIcon = False
        Me.DOKButton.Size = New System.Drawing.Size(111, 30)
        Me.DOKButton.TabIndex = 3
        Me.DOKButton.TabStop = True
        Me.DOKButton.Text = "OK"
        Me.DOKButton.TextImageSpacing = CType(0, Byte)
        Me.DOKButton.XIMage = Nothing
        '
        'MainListBacker
        '
        Me.MainListBacker.BackColor = System.Drawing.Color.Transparent
        Me.MainListBacker.BorderColor = System.Drawing.Color.FromArgb(CType(CType(48, Byte), Integer), CType(CType(48, Byte), Integer), CType(CType(48, Byte), Integer))
        Me.MainListBacker.BorderRadius = CType(6, Byte)
        Me.MainListBacker.Controls.Add(Me.MainList)
        Me.MainListBacker.GradBottomColor = System.Drawing.Color.White
        Me.MainListBacker.GradTopColor = System.Drawing.Color.White
        Me.MainListBacker.Location = New System.Drawing.Point(0, 0)
        Me.MainListBacker.Name = "MainListBacker"
        Me.MainListBacker.Size = New System.Drawing.Size(200, 152)
        Me.MainListBacker.TabIndex = 1
        '
        'MainList
        '
        Me.MainList.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.MainList.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable
        Me.MainList.FormattingEnabled = True
        Me.MainList.ItemHeight = 36
        Me.MainList.Location = New System.Drawing.Point(3, 3)
        Me.MainList.Name = "MainList"
        Me.MainList.Size = New System.Drawing.Size(194, 145)
        Me.MainList.TabIndex = 2
        '
        'SubListBacker
        '
        Me.SubListBacker.BackColor = System.Drawing.Color.Transparent
        Me.SubListBacker.BorderColor = System.Drawing.Color.FromArgb(CType(CType(48, Byte), Integer), CType(CType(48, Byte), Integer), CType(CType(48, Byte), Integer))
        Me.SubListBacker.BorderRadius = CType(6, Byte)
        Me.SubListBacker.Controls.Add(Me.SubList)
        Me.SubListBacker.GradBottomColor = System.Drawing.Color.Silver
        Me.SubListBacker.GradTopColor = System.Drawing.Color.Silver
        Me.SubListBacker.Location = New System.Drawing.Point(203, 0)
        Me.SubListBacker.Margin = New System.Windows.Forms.Padding(0)
        Me.SubListBacker.Name = "SubListBacker"
        Me.SubListBacker.Size = New System.Drawing.Size(285, 260)
        Me.SubListBacker.TabIndex = 2
        '
        'SubList
        '
        Me.SubList.BackColor = System.Drawing.Color.Silver
        Me.SubList.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.SubList.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable
        Me.SubList.FormattingEnabled = True
        Me.SubList.ItemHeight = 24
        Me.SubList.Items.AddRange(New Object() {"1", "2", "3", "4", "5"})
        Me.SubList.Location = New System.Drawing.Point(3, 3)
        Me.SubList.Name = "SubList"
        Me.SubList.Size = New System.Drawing.Size(279, 253)
        Me.SubList.TabIndex = 0
        '
        'FPlatformInputs
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(488, 294)
        Me.Controls.Add(Me.DataPanel)
        Me.Controls.Add(Me.EditExecutorButton)
        Me.Controls.Add(Me.DeleteExecutorButton)
        Me.Controls.Add(Me.AddExecutorButton)
        Me.Controls.Add(Me.EditInputButton)
        Me.Controls.Add(Me.DeleteInputButton)
        Me.Controls.Add(Me.AddInputButton)
        Me.Controls.Add(Me.DOKButton)
        Me.Controls.Add(Me.MainListBacker)
        Me.Controls.Add(Me.SubListBacker)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FPlatformInputs"
        Me.Padding = New System.Windows.Forms.Padding(206, 2, 2, 38)
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Platform Inputs"
        Me.TopMost = True
        Me.DataPanel.ResumeLayout(False)
        Me.MainListBacker.ResumeLayout(False)
        Me.SubListBacker.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents MainListBacker As DarkFlow.SuperPanel
    Friend WithEvents MainList As System.Windows.Forms.ListBox
    Friend WithEvents SubListBacker As DarkFlow.SuperPanel
    Friend WithEvents SubList As System.Windows.Forms.ListBox
    Friend WithEvents DOKButton As DarkFlow.SexyButton
    Friend WithEvents EditInputButton As DarkFlow.SexyButton
    Friend WithEvents DeleteInputButton As DarkFlow.SexyButton
    Friend WithEvents AddInputButton As DarkFlow.SexyButton
    Friend WithEvents EditExecutorButton As DarkFlow.SexyButton
    Friend WithEvents DeleteExecutorButton As DarkFlow.SexyButton
    Friend WithEvents AddExecutorButton As DarkFlow.SexyButton
    Friend WithEvents DataPanel As DarkFlow.SuperPanel
    Friend WithEvents DataAcceptButton As DarkFlow.SexyButton
End Class
