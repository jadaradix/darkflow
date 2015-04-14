<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FAction
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FAction))
        Me.DOKButton = New Dark_Flow.SexyButton()
        Me.LovelyContainer = New Dark_Flow.SuperPanel()
        Me.AppliesToGroupBox = New Dark_Flow.SexyGroupBox()
        Me.InstancesOfDropper = New Dark_Flow.SexyComboBox()
        Me.ThisRadioButton = New System.Windows.Forms.RadioButton()
        Me.InstancesOfRadioButton = New System.Windows.Forms.RadioButton()
        Me.OtherRadioButton = New System.Windows.Forms.RadioButton()
        Me.LabelsPanel = New System.Windows.Forms.Panel()
        Me.ControlsPanel = New System.Windows.Forms.Panel()
        Me.LovelyContainer.SuspendLayout()
        Me.AppliesToGroupBox.SuspendLayout()
        Me.SuspendLayout()
        '
        'DOKButton
        '
        Me.DOKButton.BackColor = System.Drawing.Color.Transparent
        Me.DOKButton.DText = "OK"
        Me.DOKButton.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(1, Byte), Integer))
        Me.DOKButton.ImageOnTop = False
        Me.DOKButton.LeftAligned = False
        Me.DOKButton.Location = New System.Drawing.Point(133, 156)
        Me.DOKButton.Name = "DOKButton"
        Me.DOKButton.ShrinkMyIcon = False
        Me.DOKButton.Size = New System.Drawing.Size(111, 30)
        Me.DOKButton.TabIndex = 4
        Me.DOKButton.TabStop = True
        Me.DOKButton.Text = "OK"
        Me.DOKButton.TextImageSpacing = CType(0, Byte)
        Me.DOKButton.XIMage = Nothing
        '
        'LovelyContainer
        '
        Me.LovelyContainer.BackColor = System.Drawing.Color.Transparent
        Me.LovelyContainer.BorderColor = System.Drawing.Color.FromArgb(CType(CType(48, Byte), Integer), CType(CType(48, Byte), Integer), CType(CType(48, Byte), Integer))
        Me.LovelyContainer.BorderRadius = CType(6, Byte)
        Me.LovelyContainer.Controls.Add(Me.AppliesToGroupBox)
        Me.LovelyContainer.Controls.Add(Me.LabelsPanel)
        Me.LovelyContainer.Controls.Add(Me.ControlsPanel)
        Me.LovelyContainer.GradBottomColor = System.Drawing.Color.FromArgb(CType(CType(184, Byte), Integer), CType(CType(184, Byte), Integer), CType(CType(184, Byte), Integer))
        Me.LovelyContainer.GradTopColor = System.Drawing.Color.FromArgb(CType(CType(210, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(210, Byte), Integer))
        Me.LovelyContainer.Location = New System.Drawing.Point(0, 0)
        Me.LovelyContainer.Name = "LovelyContainer"
        Me.LovelyContainer.Size = New System.Drawing.Size(244, 150)
        Me.LovelyContainer.TabIndex = 6
        '
        'AppliesToGroupBox
        '
        Me.AppliesToGroupBox.BackColor = System.Drawing.Color.Transparent
        Me.AppliesToGroupBox.BorderColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.AppliesToGroupBox.Controls.Add(Me.InstancesOfDropper)
        Me.AppliesToGroupBox.Controls.Add(Me.ThisRadioButton)
        Me.AppliesToGroupBox.Controls.Add(Me.InstancesOfRadioButton)
        Me.AppliesToGroupBox.Controls.Add(Me.OtherRadioButton)
        Me.AppliesToGroupBox.Location = New System.Drawing.Point(6, 6)
        Me.AppliesToGroupBox.Name = "AppliesToGroupBox"
        Me.AppliesToGroupBox.Size = New System.Drawing.Size(232, 106)
        Me.AppliesToGroupBox.TabIndex = 5
        Me.AppliesToGroupBox.TabStop = False
        Me.AppliesToGroupBox.Text = "Applies To:"
        '
        'InstancesOfDropper
        '
        Me.InstancesOfDropper.BackColor = System.Drawing.Color.Transparent
        Me.InstancesOfDropper.BorderColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.InstancesOfDropper.Image = CType(resources.GetObject("InstancesOfDropper.Image"), System.Drawing.Image)
        Me.InstancesOfDropper.Location = New System.Drawing.Point(121, 47)
        Me.InstancesOfDropper.Name = "InstancesOfDropper"
        Me.InstancesOfDropper.ShadowColor = System.Drawing.Color.FromArgb(CType(CType(72, Byte), Integer), CType(CType(72, Byte), Integer), CType(CType(72, Byte), Integer))
        Me.InstancesOfDropper.Size = New System.Drawing.Size(105, 25)
        Me.InstancesOfDropper.TabIndex = 7
        '
        'ThisRadioButton
        '
        Me.ThisRadioButton.AutoSize = True
        Me.ThisRadioButton.Location = New System.Drawing.Point(11, 23)
        Me.ThisRadioButton.Name = "ThisRadioButton"
        Me.ThisRadioButton.Size = New System.Drawing.Size(47, 19)
        Me.ThisRadioButton.TabIndex = 2
        Me.ThisRadioButton.TabStop = True
        Me.ThisRadioButton.Text = "This"
        Me.ThisRadioButton.UseVisualStyleBackColor = True
        '
        'InstancesOfRadioButton
        '
        Me.InstancesOfRadioButton.AutoSize = True
        Me.InstancesOfRadioButton.Location = New System.Drawing.Point(11, 50)
        Me.InstancesOfRadioButton.Name = "InstancesOfRadioButton"
        Me.InstancesOfRadioButton.Size = New System.Drawing.Size(91, 19)
        Me.InstancesOfRadioButton.TabIndex = 3
        Me.InstancesOfRadioButton.TabStop = True
        Me.InstancesOfRadioButton.Text = "Instances of:"
        Me.InstancesOfRadioButton.UseVisualStyleBackColor = True
        '
        'OtherRadioButton
        '
        Me.OtherRadioButton.AutoSize = True
        Me.OtherRadioButton.Location = New System.Drawing.Point(11, 77)
        Me.OtherRadioButton.Name = "OtherRadioButton"
        Me.OtherRadioButton.Size = New System.Drawing.Size(55, 19)
        Me.OtherRadioButton.TabIndex = 4
        Me.OtherRadioButton.TabStop = True
        Me.OtherRadioButton.Text = "Other"
        Me.OtherRadioButton.UseVisualStyleBackColor = True
        '
        'LabelsPanel
        '
        Me.LabelsPanel.BackColor = System.Drawing.Color.Transparent
        Me.LabelsPanel.Location = New System.Drawing.Point(6, 116)
        Me.LabelsPanel.Name = "LabelsPanel"
        Me.LabelsPanel.Size = New System.Drawing.Size(108, 30)
        Me.LabelsPanel.TabIndex = 2
        '
        'ControlsPanel
        '
        Me.ControlsPanel.BackColor = System.Drawing.Color.Transparent
        Me.ControlsPanel.Location = New System.Drawing.Point(116, 116)
        Me.ControlsPanel.Name = "ControlsPanel"
        Me.ControlsPanel.Size = New System.Drawing.Size(122, 30)
        Me.ControlsPanel.TabIndex = 3
        '
        'FAction
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(244, 186)
        Me.Controls.Add(Me.LovelyContainer)
        Me.Controls.Add(Me.DOKButton)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FAction"
        Me.Padding = New System.Windows.Forms.Padding(2, 30, 2, 40)
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.LovelyContainer.ResumeLayout(False)
        Me.AppliesToGroupBox.ResumeLayout(False)
        Me.AppliesToGroupBox.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents OtherRadioButton As System.Windows.Forms.RadioButton
    Friend WithEvents InstancesOfRadioButton As System.Windows.Forms.RadioButton
    Friend WithEvents ThisRadioButton As System.Windows.Forms.RadioButton
    Friend WithEvents LabelsPanel As System.Windows.Forms.Panel
    Friend WithEvents ControlsPanel As System.Windows.Forms.Panel
    Friend WithEvents DOKButton As Dark_Flow.SexyButton
    Friend WithEvents AppliesToGroupBox As Dark_Flow.SexyGroupBox
    Friend WithEvents InstancesOfDropper As Dark_Flow.SexyComboBox
    Friend WithEvents LovelyContainer As Dark_Flow.SuperPanel
End Class
