<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FGameSettings
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FGameSettings))
        Me.MainTabControl = New DarkFlow.SexyTabControl()
        Me.GeneralTab = New System.Windows.Forms.TabPage()
        Me.GameIDBox = New DarkFlow.SexyTextBox()
        Me.GameIDLabel = New System.Windows.Forms.Label()
        Me.ScenesDropper = New DarkFlow.SexyComboBox()
        Me.StartingSceneLabel = New System.Windows.Forms.Label()
        Me.DisplayTab = New System.Windows.Forms.TabPage()
        Me.LogoBoxContainer = New DarkFlow.SuperPanel()
        Me.LogoBox = New System.Windows.Forms.PictureBox()
        Me.LogoLabel = New System.Windows.Forms.Label()
        Me.ChangeLogoButton = New DarkFlow.SexyButton()
        Me.InformationTab = New System.Windows.Forms.TabPage()
        Me.DescriptionBox = New DarkFlow.SexyTextBox()
        Me.DescriptionLabel = New System.Windows.Forms.Label()
        Me.CompanyBox = New DarkFlow.SexyTextBox()
        Me.CompanyLabel = New System.Windows.Forms.Label()
        Me.CopyrightBox = New DarkFlow.SexyTextBox()
        Me.CopyrightLabel = New System.Windows.Forms.Label()
        Me.ProductBox = New DarkFlow.SexyTextBox()
        Me.ProductLabel = New System.Windows.Forms.Label()
        Me.DOKButton = New DarkFlow.SexyButton()
        Me.MainTabControl.SuspendLayout()
        Me.GeneralTab.SuspendLayout()
        Me.DisplayTab.SuspendLayout()
        Me.LogoBoxContainer.SuspendLayout()
        CType(Me.LogoBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.InformationTab.SuspendLayout()
        Me.SuspendLayout()
        '
        'MainTabControl
        '
        Me.MainTabControl.BorderColor = System.Drawing.Color.FromArgb(CType(CType(80, Byte), Integer), CType(CType(80, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.MainTabControl.Controls.Add(Me.GeneralTab)
        Me.MainTabControl.Controls.Add(Me.DisplayTab)
        Me.MainTabControl.Controls.Add(Me.InformationTab)
        Me.MainTabControl.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed
        Me.MainTabControl.GradFrom = System.Drawing.Color.FromArgb(CType(CType(133, Byte), Integer), CType(CType(133, Byte), Integer), CType(CType(133, Byte), Integer))
        Me.MainTabControl.Location = New System.Drawing.Point(0, 0)
        Me.MainTabControl.Name = "MainTabControl"
        Me.MainTabControl.SelectedIndex = 0
        Me.MainTabControl.Size = New System.Drawing.Size(312, 327)
        Me.MainTabControl.TabIndex = 3
        '
        'GeneralTab
        '
        Me.GeneralTab.Controls.Add(Me.GameIDBox)
        Me.GeneralTab.Controls.Add(Me.GameIDLabel)
        Me.GeneralTab.Controls.Add(Me.ScenesDropper)
        Me.GeneralTab.Controls.Add(Me.StartingSceneLabel)
        Me.GeneralTab.Location = New System.Drawing.Point(4, 25)
        Me.GeneralTab.Name = "GeneralTab"
        Me.GeneralTab.Padding = New System.Windows.Forms.Padding(3)
        Me.GeneralTab.Size = New System.Drawing.Size(304, 298)
        Me.GeneralTab.TabIndex = 0
        Me.GeneralTab.Text = "General"
        Me.GeneralTab.UseVisualStyleBackColor = True
        '
        'GameIDBox
        '
        Me.GameIDBox.BackColor = System.Drawing.Color.White
        Me.GameIDBox.BorderColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.GameIDBox.Enabled = False
        Me.GameIDBox.Location = New System.Drawing.Point(106, 69)
        Me.GameIDBox.MultiLine = False
        Me.GameIDBox.Name = "GameIDBox"
        Me.GameIDBox.ShadowColor = System.Drawing.Color.FromArgb(CType(CType(72, Byte), Integer), CType(CType(72, Byte), Integer), CType(CType(72, Byte), Integer))
        Me.GameIDBox.Size = New System.Drawing.Size(72, 24)
        Me.GameIDBox.TabIndex = 3
        Me.GameIDBox.UseSystemPasswordChar = False
        '
        'GameIDLabel
        '
        Me.GameIDLabel.AutoSize = True
        Me.GameIDLabel.Location = New System.Drawing.Point(49, 74)
        Me.GameIDLabel.Name = "GameIDLabel"
        Me.GameIDLabel.Size = New System.Drawing.Size(55, 15)
        Me.GameIDLabel.TabIndex = 2
        Me.GameIDLabel.Text = "Game ID:"
        '
        'ScenesDropper
        '
        Me.ScenesDropper.BackColor = System.Drawing.Color.Transparent
        Me.ScenesDropper.BorderColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.ScenesDropper.Image = CType(resources.GetObject("ScenesDropper.Image"), System.Drawing.Image)
        Me.ScenesDropper.Location = New System.Drawing.Point(106, 31)
        Me.ScenesDropper.Name = "ScenesDropper"
        Me.ScenesDropper.ShadowColor = System.Drawing.Color.FromArgb(CType(CType(72, Byte), Integer), CType(CType(72, Byte), Integer), CType(CType(72, Byte), Integer))
        Me.ScenesDropper.Size = New System.Drawing.Size(173, 25)
        Me.ScenesDropper.TabIndex = 1
        '
        'StartingSceneLabel
        '
        Me.StartingSceneLabel.AutoSize = True
        Me.StartingSceneLabel.Location = New System.Drawing.Point(19, 37)
        Me.StartingSceneLabel.Name = "StartingSceneLabel"
        Me.StartingSceneLabel.Size = New System.Drawing.Size(85, 15)
        Me.StartingSceneLabel.TabIndex = 0
        Me.StartingSceneLabel.Text = "Starting Scene:"
        '
        'DisplayTab
        '
        Me.DisplayTab.Controls.Add(Me.LogoBoxContainer)
        Me.DisplayTab.Controls.Add(Me.LogoLabel)
        Me.DisplayTab.Controls.Add(Me.ChangeLogoButton)
        Me.DisplayTab.Location = New System.Drawing.Point(4, 25)
        Me.DisplayTab.Name = "DisplayTab"
        Me.DisplayTab.Padding = New System.Windows.Forms.Padding(3)
        Me.DisplayTab.Size = New System.Drawing.Size(304, 298)
        Me.DisplayTab.TabIndex = 1
        Me.DisplayTab.Text = "Display"
        Me.DisplayTab.UseVisualStyleBackColor = True
        '
        'LogoBoxContainer
        '
        Me.LogoBoxContainer.BorderColor = System.Drawing.Color.FromArgb(CType(CType(48, Byte), Integer), CType(CType(48, Byte), Integer), CType(CType(48, Byte), Integer))
        Me.LogoBoxContainer.BorderRadius = CType(6, Byte)
        Me.LogoBoxContainer.Controls.Add(Me.LogoBox)
        Me.LogoBoxContainer.GradBottomColor = System.Drawing.Color.White
        Me.LogoBoxContainer.GradTopColor = System.Drawing.Color.White
        Me.LogoBoxContainer.Location = New System.Drawing.Point(18, 56)
        Me.LogoBoxContainer.Name = "LogoBoxContainer"
        Me.LogoBoxContainer.Size = New System.Drawing.Size(268, 78)
        Me.LogoBoxContainer.TabIndex = 10
        '
        'LogoBox
        '
        Me.LogoBox.Location = New System.Drawing.Point(4, 4)
        Me.LogoBox.Name = "LogoBox"
        Me.LogoBox.Size = New System.Drawing.Size(260, 70)
        Me.LogoBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.LogoBox.TabIndex = 4
        Me.LogoBox.TabStop = False
        '
        'LogoLabel
        '
        Me.LogoLabel.AutoSize = True
        Me.LogoLabel.Location = New System.Drawing.Point(19, 38)
        Me.LogoLabel.Name = "LogoLabel"
        Me.LogoLabel.Size = New System.Drawing.Size(83, 15)
        Me.LogoLabel.TabIndex = 9
        Me.LogoLabel.Text = "Loading Logo:"
        '
        'ChangeLogoButton
        '
        Me.ChangeLogoButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ChangeLogoButton.BackColor = System.Drawing.Color.Transparent
        Me.ChangeLogoButton.DText = "Change..."
        Me.ChangeLogoButton.ForeColor = System.Drawing.Color.Black
        Me.ChangeLogoButton.ImageOnTop = False
        Me.ChangeLogoButton.LeftAligned = True
        Me.ChangeLogoButton.Location = New System.Drawing.Point(185, 138)
        Me.ChangeLogoButton.Name = "ChangeLogoButton"
        Me.ChangeLogoButton.ShrinkMyIcon = False
        Me.ChangeLogoButton.Size = New System.Drawing.Size(101, 26)
        Me.ChangeLogoButton.TabIndex = 8
        Me.ChangeLogoButton.TabStop = True
        Me.ChangeLogoButton.Text = "Change..."
        Me.ChangeLogoButton.TextImageSpacing = CType(5, Byte)
        Me.ChangeLogoButton.XIMage = Global.DarkFlow.My.Resources.Resources.OpenFileIcon
        '
        'InformationTab
        '
        Me.InformationTab.Controls.Add(Me.DescriptionBox)
        Me.InformationTab.Controls.Add(Me.DescriptionLabel)
        Me.InformationTab.Controls.Add(Me.CompanyBox)
        Me.InformationTab.Controls.Add(Me.CompanyLabel)
        Me.InformationTab.Controls.Add(Me.CopyrightBox)
        Me.InformationTab.Controls.Add(Me.CopyrightLabel)
        Me.InformationTab.Controls.Add(Me.ProductBox)
        Me.InformationTab.Controls.Add(Me.ProductLabel)
        Me.InformationTab.Location = New System.Drawing.Point(4, 25)
        Me.InformationTab.Name = "InformationTab"
        Me.InformationTab.Padding = New System.Windows.Forms.Padding(3)
        Me.InformationTab.Size = New System.Drawing.Size(304, 298)
        Me.InformationTab.TabIndex = 2
        Me.InformationTab.Text = "Information"
        Me.InformationTab.UseVisualStyleBackColor = True
        '
        'DescriptionBox
        '
        Me.DescriptionBox.BackColor = System.Drawing.Color.White
        Me.DescriptionBox.BorderColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.DescriptionBox.Location = New System.Drawing.Point(20, 150)
        Me.DescriptionBox.MultiLine = True
        Me.DescriptionBox.Name = "DescriptionBox"
        Me.DescriptionBox.ShadowColor = System.Drawing.Color.FromArgb(CType(CType(72, Byte), Integer), CType(CType(72, Byte), Integer), CType(CType(72, Byte), Integer))
        Me.DescriptionBox.Size = New System.Drawing.Size(264, 120)
        Me.DescriptionBox.TabIndex = 7
        Me.DescriptionBox.UseSystemPasswordChar = False
        '
        'DescriptionLabel
        '
        Me.DescriptionLabel.AutoSize = True
        Me.DescriptionLabel.Location = New System.Drawing.Point(17, 132)
        Me.DescriptionLabel.Name = "DescriptionLabel"
        Me.DescriptionLabel.Size = New System.Drawing.Size(70, 15)
        Me.DescriptionLabel.TabIndex = 6
        Me.DescriptionLabel.Text = "Description:"
        '
        'CompanyBox
        '
        Me.CompanyBox.BackColor = System.Drawing.Color.White
        Me.CompanyBox.BorderColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.CompanyBox.Location = New System.Drawing.Point(144, 84)
        Me.CompanyBox.MultiLine = False
        Me.CompanyBox.Name = "CompanyBox"
        Me.CompanyBox.ShadowColor = System.Drawing.Color.FromArgb(CType(CType(72, Byte), Integer), CType(CType(72, Byte), Integer), CType(CType(72, Byte), Integer))
        Me.CompanyBox.Size = New System.Drawing.Size(140, 24)
        Me.CompanyBox.TabIndex = 5
        Me.CompanyBox.UseSystemPasswordChar = False
        '
        'CompanyLabel
        '
        Me.CompanyLabel.AutoSize = True
        Me.CompanyLabel.Location = New System.Drawing.Point(46, 89)
        Me.CompanyLabel.Name = "CompanyLabel"
        Me.CompanyLabel.Size = New System.Drawing.Size(62, 15)
        Me.CompanyLabel.TabIndex = 4
        Me.CompanyLabel.Text = "Company:"
        '
        'CopyrightBox
        '
        Me.CopyrightBox.BackColor = System.Drawing.Color.White
        Me.CopyrightBox.BorderColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.CopyrightBox.Location = New System.Drawing.Point(144, 54)
        Me.CopyrightBox.MultiLine = False
        Me.CopyrightBox.Name = "CopyrightBox"
        Me.CopyrightBox.ShadowColor = System.Drawing.Color.FromArgb(CType(CType(72, Byte), Integer), CType(CType(72, Byte), Integer), CType(CType(72, Byte), Integer))
        Me.CopyrightBox.Size = New System.Drawing.Size(140, 24)
        Me.CopyrightBox.TabIndex = 3
        Me.CopyrightBox.UseSystemPasswordChar = False
        '
        'CopyrightLabel
        '
        Me.CopyrightLabel.AutoSize = True
        Me.CopyrightLabel.Location = New System.Drawing.Point(45, 59)
        Me.CopyrightLabel.Name = "CopyrightLabel"
        Me.CopyrightLabel.Size = New System.Drawing.Size(63, 15)
        Me.CopyrightLabel.TabIndex = 2
        Me.CopyrightLabel.Text = "Copyright:"
        '
        'ProductBox
        '
        Me.ProductBox.BackColor = System.Drawing.Color.White
        Me.ProductBox.BorderColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.ProductBox.Location = New System.Drawing.Point(144, 24)
        Me.ProductBox.MultiLine = False
        Me.ProductBox.Name = "ProductBox"
        Me.ProductBox.ShadowColor = System.Drawing.Color.FromArgb(CType(CType(72, Byte), Integer), CType(CType(72, Byte), Integer), CType(CType(72, Byte), Integer))
        Me.ProductBox.Size = New System.Drawing.Size(140, 24)
        Me.ProductBox.TabIndex = 1
        Me.ProductBox.UseSystemPasswordChar = False
        '
        'ProductLabel
        '
        Me.ProductLabel.AutoSize = True
        Me.ProductLabel.Location = New System.Drawing.Point(56, 29)
        Me.ProductLabel.Name = "ProductLabel"
        Me.ProductLabel.Size = New System.Drawing.Size(52, 15)
        Me.ProductLabel.TabIndex = 0
        Me.ProductLabel.Text = "Product:"
        '
        'DOKButton
        '
        Me.DOKButton.BackColor = System.Drawing.Color.Transparent
        Me.DOKButton.DText = "OK"
        Me.DOKButton.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(1, Byte), Integer))
        Me.DOKButton.ImageOnTop = False
        Me.DOKButton.LeftAligned = False
        Me.DOKButton.Location = New System.Drawing.Point(201, 331)
        Me.DOKButton.Name = "DOKButton"
        Me.DOKButton.ShrinkMyIcon = False
        Me.DOKButton.Size = New System.Drawing.Size(111, 30)
        Me.DOKButton.TabIndex = 2
        Me.DOKButton.TabStop = True
        Me.DOKButton.Text = "OK"
        Me.DOKButton.TextImageSpacing = CType(0, Byte)
        Me.DOKButton.XIMage = Nothing
        '
        'FGameSettings
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(312, 361)
        Me.Controls.Add(Me.MainTabControl)
        Me.Controls.Add(Me.DOKButton)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FGameSettings"
        Me.Padding = New System.Windows.Forms.Padding(6, 28, 6, 44)
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Game Settings"
        Me.MainTabControl.ResumeLayout(False)
        Me.GeneralTab.ResumeLayout(False)
        Me.GeneralTab.PerformLayout()
        Me.DisplayTab.ResumeLayout(False)
        Me.DisplayTab.PerformLayout()
        Me.LogoBoxContainer.ResumeLayout(False)
        CType(Me.LogoBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.InformationTab.ResumeLayout(False)
        Me.InformationTab.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents DOKButton As DarkFlow.SexyButton
    Friend WithEvents DisplayTab As System.Windows.Forms.TabPage
    Friend WithEvents GeneralTab As System.Windows.Forms.TabPage
    Friend WithEvents MainTabControl As DarkFlow.SexyTabControl
    Friend WithEvents InformationTab As System.Windows.Forms.TabPage
    Friend WithEvents StartingSceneLabel As System.Windows.Forms.Label
    Friend WithEvents ScenesDropper As DarkFlow.SexyComboBox
    Friend WithEvents ProductLabel As System.Windows.Forms.Label
    Friend WithEvents ProductBox As DarkFlow.SexyTextBox
    Friend WithEvents CopyrightBox As DarkFlow.SexyTextBox
    Friend WithEvents CopyrightLabel As System.Windows.Forms.Label
    Friend WithEvents CompanyBox As DarkFlow.SexyTextBox
    Friend WithEvents CompanyLabel As System.Windows.Forms.Label
    Friend WithEvents DescriptionLabel As System.Windows.Forms.Label
    Friend WithEvents DescriptionBox As DarkFlow.SexyTextBox
    Friend WithEvents GameIDLabel As System.Windows.Forms.Label
    Friend WithEvents GameIDBox As DarkFlow.SexyTextBox
    Friend WithEvents LogoBox As System.Windows.Forms.PictureBox
    Friend WithEvents ChangeLogoButton As DarkFlow.SexyButton
    Friend WithEvents LogoLabel As System.Windows.Forms.Label
    Friend WithEvents LogoBoxContainer As DarkFlow.SuperPanel
End Class
