<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FOptions
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
        Me.MainTabber = New Dark_Flow.SexyTabControl()
        Me.GeneralTab = New System.Windows.Forms.TabPage()
        Me.AutoSave_Checker = New Dark_Flow.SexyCheckBox()
        Me.WelcomeOnBootChecker = New Dark_Flow.SexyCheckBox()
        Me.ShrinkActionsListChecker = New Dark_Flow.SexyCheckBox()
        Me.BrowserTab = New System.Windows.Forms.TabPage()
        Me.BrowsersListBacker = New Dark_Flow.SuperPanel()
        Me.BrowsersList = New System.Windows.Forms.ListBox()
        Me.PreferredBrowserLabel = New System.Windows.Forms.Label()
        Me.EditorsTab = New System.Windows.Forms.TabPage()
        Me.AlphaCapableChecker = New Dark_Flow.SexyCheckBox()
        Me.SoundEditorButton = New Dark_Flow.SexyButton()
        Me.SoundEditorBox = New Dark_Flow.SexyTextBox()
        Me.SoundEditorLabel = New System.Windows.Forms.Label()
        Me.ImageEditorButton = New Dark_Flow.SexyButton()
        Me.ImageEditorBox = New Dark_Flow.SexyTextBox()
        Me.ImageEditorLabel = New System.Windows.Forms.Label()
        Me.DOKButton = New Dark_Flow.SexyButton()
        Me.MainTabber.SuspendLayout()
        Me.GeneralTab.SuspendLayout()
        Me.BrowserTab.SuspendLayout()
        Me.BrowsersListBacker.SuspendLayout()
        Me.EditorsTab.SuspendLayout()
        Me.SuspendLayout()
        '
        'MainTabber
        '
        Me.MainTabber.BorderColor = System.Drawing.Color.FromArgb(CType(CType(80, Byte), Integer), CType(CType(80, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.MainTabber.Controls.Add(Me.GeneralTab)
        Me.MainTabber.Controls.Add(Me.BrowserTab)
        Me.MainTabber.Controls.Add(Me.EditorsTab)
        Me.MainTabber.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed
        Me.MainTabber.GradFrom = System.Drawing.Color.FromArgb(CType(CType(133, Byte), Integer), CType(CType(133, Byte), Integer), CType(CType(133, Byte), Integer))
        Me.MainTabber.Location = New System.Drawing.Point(-1, -2)
        Me.MainTabber.Name = "MainTabber"
        Me.MainTabber.SelectedIndex = 0
        Me.MainTabber.Size = New System.Drawing.Size(312, 327)
        Me.MainTabber.TabIndex = 2
        '
        'GeneralTab
        '
        Me.GeneralTab.Controls.Add(Me.AutoSave_Checker)
        Me.GeneralTab.Controls.Add(Me.WelcomeOnBootChecker)
        Me.GeneralTab.Controls.Add(Me.ShrinkActionsListChecker)
        Me.GeneralTab.Location = New System.Drawing.Point(4, 25)
        Me.GeneralTab.Name = "GeneralTab"
        Me.GeneralTab.Padding = New System.Windows.Forms.Padding(3)
        Me.GeneralTab.Size = New System.Drawing.Size(304, 298)
        Me.GeneralTab.TabIndex = 0
        Me.GeneralTab.Text = "General"
        Me.GeneralTab.UseVisualStyleBackColor = True
        '
        'AutoSave_Checker
        '
        Me.AutoSave_Checker.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.AutoSave_Checker.Checked = False
        Me.AutoSave_Checker.DText = "Auto-Save when the game is tested"
        Me.AutoSave_Checker.Location = New System.Drawing.Point(12, 60)
        Me.AutoSave_Checker.Name = "AutoSave_Checker"
        Me.AutoSave_Checker.Size = New System.Drawing.Size(280, 18)
        Me.AutoSave_Checker.TabIndex = 8
        Me.AutoSave_Checker.Text = "Auto-Save when the game is tested"
        '
        'WelcomeOnBootChecker
        '
        Me.WelcomeOnBootChecker.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.WelcomeOnBootChecker.Checked = False
        Me.WelcomeOnBootChecker.DText = "Show 'Welcome' window when starting"
        Me.WelcomeOnBootChecker.Location = New System.Drawing.Point(12, 36)
        Me.WelcomeOnBootChecker.Name = "WelcomeOnBootChecker"
        Me.WelcomeOnBootChecker.Size = New System.Drawing.Size(280, 18)
        Me.WelcomeOnBootChecker.TabIndex = 7
        Me.WelcomeOnBootChecker.Text = "Show 'Welcome' window when starting"
        '
        'ShrinkActionsListChecker
        '
        Me.ShrinkActionsListChecker.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ShrinkActionsListChecker.Checked = False
        Me.ShrinkActionsListChecker.DText = "Shrink Actions List"
        Me.ShrinkActionsListChecker.Location = New System.Drawing.Point(12, 12)
        Me.ShrinkActionsListChecker.Name = "ShrinkActionsListChecker"
        Me.ShrinkActionsListChecker.Size = New System.Drawing.Size(280, 18)
        Me.ShrinkActionsListChecker.TabIndex = 6
        Me.ShrinkActionsListChecker.Text = "Shrink Actions List"
        '
        'BrowserTab
        '
        Me.BrowserTab.Controls.Add(Me.BrowsersListBacker)
        Me.BrowserTab.Controls.Add(Me.PreferredBrowserLabel)
        Me.BrowserTab.Location = New System.Drawing.Point(4, 25)
        Me.BrowserTab.Name = "BrowserTab"
        Me.BrowserTab.Padding = New System.Windows.Forms.Padding(3)
        Me.BrowserTab.Size = New System.Drawing.Size(304, 298)
        Me.BrowserTab.TabIndex = 1
        Me.BrowserTab.Text = "Browser"
        Me.BrowserTab.UseVisualStyleBackColor = True
        '
        'BrowsersListBacker
        '
        Me.BrowsersListBacker.BorderColor = System.Drawing.Color.Gray
        Me.BrowsersListBacker.BorderRadius = CType(6, Byte)
        Me.BrowsersListBacker.Controls.Add(Me.BrowsersList)
        Me.BrowsersListBacker.GradBottomColor = System.Drawing.Color.White
        Me.BrowsersListBacker.GradTopColor = System.Drawing.Color.White
        Me.BrowsersListBacker.Location = New System.Drawing.Point(12, 32)
        Me.BrowsersListBacker.Name = "BrowsersListBacker"
        Me.BrowsersListBacker.Size = New System.Drawing.Size(272, 185)
        Me.BrowsersListBacker.TabIndex = 2
        '
        'BrowsersList
        '
        Me.BrowsersList.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.BrowsersList.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable
        Me.BrowsersList.FormattingEnabled = True
        Me.BrowsersList.ItemHeight = 36
        Me.BrowsersList.Location = New System.Drawing.Point(3, 3)
        Me.BrowsersList.Name = "BrowsersList"
        Me.BrowsersList.Size = New System.Drawing.Size(266, 178)
        Me.BrowsersList.TabIndex = 0
        '
        'PreferredBrowserLabel
        '
        Me.PreferredBrowserLabel.AutoSize = True
        Me.PreferredBrowserLabel.Location = New System.Drawing.Point(12, 12)
        Me.PreferredBrowserLabel.Name = "PreferredBrowserLabel"
        Me.PreferredBrowserLabel.Size = New System.Drawing.Size(164, 15)
        Me.PreferredBrowserLabel.TabIndex = 1
        Me.PreferredBrowserLabel.Text = "Select your preferred Browser:"
        '
        'EditorsTab
        '
        Me.EditorsTab.Controls.Add(Me.AlphaCapableChecker)
        Me.EditorsTab.Controls.Add(Me.SoundEditorButton)
        Me.EditorsTab.Controls.Add(Me.SoundEditorBox)
        Me.EditorsTab.Controls.Add(Me.SoundEditorLabel)
        Me.EditorsTab.Controls.Add(Me.ImageEditorButton)
        Me.EditorsTab.Controls.Add(Me.ImageEditorBox)
        Me.EditorsTab.Controls.Add(Me.ImageEditorLabel)
        Me.EditorsTab.Location = New System.Drawing.Point(4, 25)
        Me.EditorsTab.Name = "EditorsTab"
        Me.EditorsTab.Size = New System.Drawing.Size(304, 298)
        Me.EditorsTab.TabIndex = 3
        Me.EditorsTab.Text = "Editors"
        Me.EditorsTab.UseVisualStyleBackColor = True
        '
        'AlphaCapableChecker
        '
        Me.AlphaCapableChecker.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.AlphaCapableChecker.Checked = False
        Me.AlphaCapableChecker.DText = "This editor supports alpha transparency"
        Me.AlphaCapableChecker.Location = New System.Drawing.Point(15, 58)
        Me.AlphaCapableChecker.Name = "AlphaCapableChecker"
        Me.AlphaCapableChecker.Size = New System.Drawing.Size(161, 18)
        Me.AlphaCapableChecker.TabIndex = 14
        Me.AlphaCapableChecker.Text = "This editor supports alpha transparency"
        '
        'SoundEditorButton
        '
        Me.SoundEditorButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SoundEditorButton.BackColor = System.Drawing.Color.Transparent
        Me.SoundEditorButton.DText = ""
        Me.SoundEditorButton.ForeColor = System.Drawing.Color.Black
        Me.SoundEditorButton.ImageOnTop = False
        Me.SoundEditorButton.LeftAligned = True
        Me.SoundEditorButton.Location = New System.Drawing.Point(250, 108)
        Me.SoundEditorButton.Name = "SoundEditorButton"
        Me.SoundEditorButton.ShrinkMyIcon = True
        Me.SoundEditorButton.Size = New System.Drawing.Size(32, 24)
        Me.SoundEditorButton.TabIndex = 10
        Me.SoundEditorButton.TabStop = True
        Me.SoundEditorButton.TextImageSpacing = CType(0, Byte)
        Me.SoundEditorButton.XIMage = Global.Dark_Flow.My.Resources.Resources.OpenFileIcon
        '
        'SoundEditorBox
        '
        Me.SoundEditorBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SoundEditorBox.BackColor = System.Drawing.Color.Transparent
        Me.SoundEditorBox.BorderColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.SoundEditorBox.Location = New System.Drawing.Point(15, 108)
        Me.SoundEditorBox.MultiLine = False
        Me.SoundEditorBox.Name = "SoundEditorBox"
        Me.SoundEditorBox.ShadowColor = System.Drawing.Color.FromArgb(CType(CType(72, Byte), Integer), CType(CType(72, Byte), Integer), CType(CType(72, Byte), Integer))
        Me.SoundEditorBox.Size = New System.Drawing.Size(229, 24)
        Me.SoundEditorBox.TabIndex = 9
        Me.SoundEditorBox.UseSystemPasswordChar = False
        '
        'SoundEditorLabel
        '
        Me.SoundEditorLabel.AutoSize = True
        Me.SoundEditorLabel.Location = New System.Drawing.Point(12, 88)
        Me.SoundEditorLabel.Name = "SoundEditorLabel"
        Me.SoundEditorLabel.Size = New System.Drawing.Size(78, 15)
        Me.SoundEditorLabel.TabIndex = 8
        Me.SoundEditorLabel.Text = "Sound Editor:"
        '
        'ImageEditorButton
        '
        Me.ImageEditorButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ImageEditorButton.BackColor = System.Drawing.Color.Transparent
        Me.ImageEditorButton.DText = ""
        Me.ImageEditorButton.ForeColor = System.Drawing.Color.Black
        Me.ImageEditorButton.ImageOnTop = False
        Me.ImageEditorButton.LeftAligned = True
        Me.ImageEditorButton.Location = New System.Drawing.Point(250, 32)
        Me.ImageEditorButton.Name = "ImageEditorButton"
        Me.ImageEditorButton.ShrinkMyIcon = True
        Me.ImageEditorButton.Size = New System.Drawing.Size(32, 24)
        Me.ImageEditorButton.TabIndex = 7
        Me.ImageEditorButton.TabStop = True
        Me.ImageEditorButton.TextImageSpacing = CType(0, Byte)
        Me.ImageEditorButton.XIMage = Global.Dark_Flow.My.Resources.Resources.OpenFileIcon
        '
        'ImageEditorBox
        '
        Me.ImageEditorBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ImageEditorBox.BackColor = System.Drawing.Color.Transparent
        Me.ImageEditorBox.BorderColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.ImageEditorBox.Location = New System.Drawing.Point(15, 32)
        Me.ImageEditorBox.MultiLine = False
        Me.ImageEditorBox.Name = "ImageEditorBox"
        Me.ImageEditorBox.ShadowColor = System.Drawing.Color.FromArgb(CType(CType(72, Byte), Integer), CType(CType(72, Byte), Integer), CType(CType(72, Byte), Integer))
        Me.ImageEditorBox.Size = New System.Drawing.Size(229, 24)
        Me.ImageEditorBox.TabIndex = 6
        Me.ImageEditorBox.UseSystemPasswordChar = False
        '
        'ImageEditorLabel
        '
        Me.ImageEditorLabel.AutoSize = True
        Me.ImageEditorLabel.Location = New System.Drawing.Point(12, 12)
        Me.ImageEditorLabel.Name = "ImageEditorLabel"
        Me.ImageEditorLabel.Size = New System.Drawing.Size(77, 15)
        Me.ImageEditorLabel.TabIndex = 4
        Me.ImageEditorLabel.Text = "Image Editor:"
        '
        'DOKButton
        '
        Me.DOKButton.BackColor = System.Drawing.Color.Transparent
        Me.DOKButton.DText = "OK"
        Me.DOKButton.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(1, Byte), Integer))
        Me.DOKButton.ImageOnTop = False
        Me.DOKButton.LeftAligned = False
        Me.DOKButton.Location = New System.Drawing.Point(200, 331)
        Me.DOKButton.Name = "DOKButton"
        Me.DOKButton.ShrinkMyIcon = False
        Me.DOKButton.Size = New System.Drawing.Size(111, 30)
        Me.DOKButton.TabIndex = 1
        Me.DOKButton.TabStop = True
        Me.DOKButton.Text = "OK"
        Me.DOKButton.TextImageSpacing = CType(0, Byte)
        Me.DOKButton.XIMage = Nothing
        '
        'FOptions
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(312, 361)
        Me.Controls.Add(Me.MainTabber)
        Me.Controls.Add(Me.DOKButton)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FOptions"
        Me.Padding = New System.Windows.Forms.Padding(6, 28, 6, 44)
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Options"
        Me.MainTabber.ResumeLayout(False)
        Me.GeneralTab.ResumeLayout(False)
        Me.BrowserTab.ResumeLayout(False)
        Me.BrowserTab.PerformLayout()
        Me.BrowsersListBacker.ResumeLayout(False)
        Me.EditorsTab.ResumeLayout(False)
        Me.EditorsTab.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents MainTabber As Dark_Flow.SexyTabControl
    Friend WithEvents BrowserTab As System.Windows.Forms.TabPage
    Friend WithEvents BrowsersList As System.Windows.Forms.ListBox
    Friend WithEvents PreferredBrowserLabel As System.Windows.Forms.Label
    Friend WithEvents DOKButton As Dark_Flow.SexyButton
    Friend WithEvents EditorsTab As System.Windows.Forms.TabPage
    Friend WithEvents ImageEditorBox As Dark_Flow.SexyTextBox
    Friend WithEvents ImageEditorLabel As System.Windows.Forms.Label
    Friend WithEvents ImageEditorButton As Dark_Flow.SexyButton
    Friend WithEvents SoundEditorButton As Dark_Flow.SexyButton
    Friend WithEvents SoundEditorBox As Dark_Flow.SexyTextBox
    Friend WithEvents SoundEditorLabel As System.Windows.Forms.Label
    Friend WithEvents AlphaCapableChecker As Dark_Flow.SexyCheckBox
    Friend WithEvents GeneralTab As System.Windows.Forms.TabPage
    Friend WithEvents BrowsersListBacker As Dark_Flow.SuperPanel
    Friend WithEvents ShrinkActionsListChecker As Dark_Flow.SexyCheckBox
    Friend WithEvents WelcomeOnBootChecker As Dark_Flow.SexyCheckBox
    Friend WithEvents AutoSave_Checker As Dark_Flow.SexyCheckBox
End Class
