<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FEvent
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
        Me.PointerButton = New DarkFlow.SexyButton()
        Me.MainPanel = New DarkFlow.SuperPanel()
        Me.OptionsListBacker = New DarkFlow.SuperPanel()
        Me.OptionsList = New System.Windows.Forms.ListBox()
        Me.DAcceptButton = New DarkFlow.SexyButton()
        Me.InfoHeaderLabel = New System.Windows.Forms.Label()
        Me.StepButton = New DarkFlow.SexyButton()
        Me.InputButton = New DarkFlow.SexyButton()
        Me.CollisionButton = New DarkFlow.SexyButton()
        Me.CreateButton = New DarkFlow.SexyButton()
        Me.MainPanel.SuspendLayout()
        Me.OptionsListBacker.SuspendLayout()
        Me.SuspendLayout()
        '
        'PointerButton
        '
        Me.PointerButton.BackColor = System.Drawing.Color.Transparent
        Me.PointerButton.DText = "Pointer"
        Me.PointerButton.ForeColor = System.Drawing.Color.Black
        Me.PointerButton.ImageOnTop = False
        Me.PointerButton.LeftAligned = True
        Me.PointerButton.Location = New System.Drawing.Point(0, 136)
        Me.PointerButton.Name = "PointerButton"
        Me.PointerButton.ShrinkMyIcon = False
        Me.PointerButton.Size = New System.Drawing.Size(177, 32)
        Me.PointerButton.TabIndex = 6
        Me.PointerButton.TabStop = True
        Me.PointerButton.Text = "Pointer"
        Me.PointerButton.TextImageSpacing = CType(0, Byte)
        Me.PointerButton.XIMage = Global.DarkFlow.My.Resources.Resources.EventMouse
        '
        'MainPanel
        '
        Me.MainPanel.BackColor = System.Drawing.Color.Transparent
        Me.MainPanel.BorderColor = System.Drawing.Color.FromArgb(CType(CType(48, Byte), Integer), CType(CType(48, Byte), Integer), CType(CType(48, Byte), Integer))
        Me.MainPanel.BorderRadius = CType(6, Byte)
        Me.MainPanel.Controls.Add(Me.OptionsListBacker)
        Me.MainPanel.Controls.Add(Me.DAcceptButton)
        Me.MainPanel.Controls.Add(Me.InfoHeaderLabel)
        Me.MainPanel.GradBottomColor = System.Drawing.Color.FromArgb(CType(CType(184, Byte), Integer), CType(CType(184, Byte), Integer), CType(CType(184, Byte), Integer))
        Me.MainPanel.GradTopColor = System.Drawing.Color.FromArgb(CType(CType(210, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(210, Byte), Integer))
        Me.MainPanel.Location = New System.Drawing.Point(182, 0)
        Me.MainPanel.Name = "MainPanel"
        Me.MainPanel.Size = New System.Drawing.Size(295, 187)
        Me.MainPanel.TabIndex = 5
        '
        'OptionsListBacker
        '
        Me.OptionsListBacker.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.OptionsListBacker.BackColor = System.Drawing.Color.Transparent
        Me.OptionsListBacker.BorderColor = System.Drawing.Color.Gray
        Me.OptionsListBacker.BorderRadius = CType(6, Byte)
        Me.OptionsListBacker.Controls.Add(Me.OptionsList)
        Me.OptionsListBacker.GradBottomColor = System.Drawing.Color.White
        Me.OptionsListBacker.GradTopColor = System.Drawing.Color.White
        Me.OptionsListBacker.Location = New System.Drawing.Point(15, 30)
        Me.OptionsListBacker.Name = "OptionsListBacker"
        Me.OptionsListBacker.Size = New System.Drawing.Size(265, 105)
        Me.OptionsListBacker.TabIndex = 7
        '
        'OptionsList
        '
        Me.OptionsList.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.OptionsList.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.OptionsList.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable
        Me.OptionsList.FormattingEnabled = True
        Me.OptionsList.ItemHeight = 24
        Me.OptionsList.Location = New System.Drawing.Point(4, 4)
        Me.OptionsList.Name = "OptionsList"
        Me.OptionsList.Size = New System.Drawing.Size(257, 96)
        Me.OptionsList.TabIndex = 5
        '
        'DAcceptButton
        '
        Me.DAcceptButton.BackColor = System.Drawing.Color.Transparent
        Me.DAcceptButton.DText = "Accept"
        Me.DAcceptButton.ForeColor = System.Drawing.Color.Black
        Me.DAcceptButton.ImageOnTop = False
        Me.DAcceptButton.LeftAligned = False
        Me.DAcceptButton.Location = New System.Drawing.Point(170, 141)
        Me.DAcceptButton.Name = "DAcceptButton"
        Me.DAcceptButton.ShrinkMyIcon = False
        Me.DAcceptButton.Size = New System.Drawing.Size(110, 30)
        Me.DAcceptButton.TabIndex = 2
        Me.DAcceptButton.TabStop = True
        Me.DAcceptButton.Text = "Accept"
        Me.DAcceptButton.TextImageSpacing = CType(0, Byte)
        Me.DAcceptButton.XIMage = Global.DarkFlow.My.Resources.Resources.AcceptIcon
        '
        'InfoHeaderLabel
        '
        Me.InfoHeaderLabel.BackColor = System.Drawing.Color.Transparent
        Me.InfoHeaderLabel.Location = New System.Drawing.Point(15, 12)
        Me.InfoHeaderLabel.Name = "InfoHeaderLabel"
        Me.InfoHeaderLabel.Size = New System.Drawing.Size(265, 15)
        Me.InfoHeaderLabel.TabIndex = 0
        Me.InfoHeaderLabel.Text = "<select an event for further options>"
        '
        'StepButton
        '
        Me.StepButton.BackColor = System.Drawing.Color.Transparent
        Me.StepButton.DText = "Step"
        Me.StepButton.ForeColor = System.Drawing.Color.Black
        Me.StepButton.ImageOnTop = False
        Me.StepButton.LeftAligned = True
        Me.StepButton.Location = New System.Drawing.Point(0, 102)
        Me.StepButton.Name = "StepButton"
        Me.StepButton.ShrinkMyIcon = False
        Me.StepButton.Size = New System.Drawing.Size(177, 32)
        Me.StepButton.TabIndex = 4
        Me.StepButton.TabStop = True
        Me.StepButton.Text = "Step"
        Me.StepButton.TextImageSpacing = CType(0, Byte)
        Me.StepButton.XIMage = Global.DarkFlow.My.Resources.Resources.EventStep
        '
        'InputButton
        '
        Me.InputButton.BackColor = System.Drawing.Color.Transparent
        Me.InputButton.DText = "Input"
        Me.InputButton.ForeColor = System.Drawing.Color.Black
        Me.InputButton.ImageOnTop = False
        Me.InputButton.LeftAligned = True
        Me.InputButton.Location = New System.Drawing.Point(0, 68)
        Me.InputButton.Name = "InputButton"
        Me.InputButton.ShrinkMyIcon = False
        Me.InputButton.Size = New System.Drawing.Size(177, 32)
        Me.InputButton.TabIndex = 2
        Me.InputButton.TabStop = True
        Me.InputButton.Text = "Input"
        Me.InputButton.TextImageSpacing = CType(0, Byte)
        Me.InputButton.XIMage = Global.DarkFlow.My.Resources.Resources.EventKey
        '
        'CollisionButton
        '
        Me.CollisionButton.BackColor = System.Drawing.Color.Transparent
        Me.CollisionButton.DText = "Collision"
        Me.CollisionButton.ForeColor = System.Drawing.Color.Black
        Me.CollisionButton.ImageOnTop = False
        Me.CollisionButton.LeftAligned = True
        Me.CollisionButton.Location = New System.Drawing.Point(0, 34)
        Me.CollisionButton.Name = "CollisionButton"
        Me.CollisionButton.ShrinkMyIcon = False
        Me.CollisionButton.Size = New System.Drawing.Size(177, 32)
        Me.CollisionButton.TabIndex = 1
        Me.CollisionButton.TabStop = True
        Me.CollisionButton.Text = "Collision"
        Me.CollisionButton.TextImageSpacing = CType(0, Byte)
        Me.CollisionButton.XIMage = Global.DarkFlow.My.Resources.Resources.EventCollision
        '
        'CreateButton
        '
        Me.CreateButton.BackColor = System.Drawing.Color.Transparent
        Me.CreateButton.DText = "Create"
        Me.CreateButton.ForeColor = System.Drawing.Color.Black
        Me.CreateButton.ImageOnTop = False
        Me.CreateButton.LeftAligned = True
        Me.CreateButton.Location = New System.Drawing.Point(0, 0)
        Me.CreateButton.Name = "CreateButton"
        Me.CreateButton.ShrinkMyIcon = False
        Me.CreateButton.Size = New System.Drawing.Size(177, 32)
        Me.CreateButton.TabIndex = 0
        Me.CreateButton.TabStop = True
        Me.CreateButton.Text = "Create"
        Me.CreateButton.TextImageSpacing = CType(0, Byte)
        Me.CreateButton.XIMage = Global.DarkFlow.My.Resources.Resources.EventCreate
        '
        'FEvent
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(477, 187)
        Me.Controls.Add(Me.PointerButton)
        Me.Controls.Add(Me.MainPanel)
        Me.Controls.Add(Me.StepButton)
        Me.Controls.Add(Me.InputButton)
        Me.Controls.Add(Me.CollisionButton)
        Me.Controls.Add(Me.CreateButton)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FEvent"
        Me.Padding = New System.Windows.Forms.Padding(188, 8, 8, 8)
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "[Event]"
        Me.MainPanel.ResumeLayout(False)
        Me.OptionsListBacker.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents CreateButton As DarkFlow.SexyButton
    Friend WithEvents CollisionButton As DarkFlow.SexyButton
    Friend WithEvents InputButton As DarkFlow.SexyButton
    Friend WithEvents StepButton As DarkFlow.SexyButton
    Friend WithEvents MainPanel As SuperPanel
    Friend WithEvents InfoHeaderLabel As System.Windows.Forms.Label
    Friend WithEvents DAcceptButton As DarkFlow.SexyButton
    Friend WithEvents PointerButton As DarkFlow.SexyButton
    Friend WithEvents OptionsListBacker As DarkFlow.SuperPanel
    Friend WithEvents OptionsList As System.Windows.Forms.ListBox
End Class
