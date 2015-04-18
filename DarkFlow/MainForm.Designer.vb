<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MainForm
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainForm))
        Me.PrimaryToolStrip = New System.Windows.Forms.ToolStrip()
        Me.NewButton = New System.Windows.Forms.ToolStripButton()
        Me.OpenButton = New System.Windows.Forms.ToolStripButton()
        Me.SaveButton = New System.Windows.Forms.ToolStripButton()
        Me.MTSSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.PlayButton = New System.Windows.Forms.ToolStripButton()
        Me.MTSSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.GameSettingsButton = New System.Windows.Forms.ToolStripButton()
        Me.PlatformInputsButton = New System.Windows.Forms.ToolStripButton()
        Me.MTSSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.AddImageButton = New System.Windows.Forms.ToolStripButton()
        Me.AddObjectButton = New System.Windows.Forms.ToolStripButton()
        Me.AddSceneButton = New System.Windows.Forms.ToolStripButton()
        Me.AddSoundButton = New System.Windows.Forms.ToolStripButton()
        Me.MTSSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.OptionsButton = New System.Windows.Forms.ToolStripButton()
        Me.MTSSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.ManageLabel = New System.Windows.Forms.ToolStripLabel()
        Me.VariablesButton = New System.Windows.Forms.ToolStripButton()
        Me.ArraysButton = New System.Windows.Forms.ToolStripButton()
        Me.ManageStructuresButton = New System.Windows.Forms.ToolStripButton()
        Me.StoreButton = New System.Windows.Forms.ToolStripButton()
        Me.DMainMenuStrip = New System.Windows.Forms.MenuStrip()
        Me.FileDropper = New System.Windows.Forms.ToolStripMenuItem()
        Me.NewMenuButton = New System.Windows.Forms.ToolStripMenuItem()
        Me.OpenMenuButton = New System.Windows.Forms.ToolStripMenuItem()
        Me.SaveMenuButton = New System.Windows.Forms.ToolStripMenuItem()
        Me.SaveAsMenuButton = New System.Windows.Forms.ToolStripMenuItem()
        Me.GameDropper = New System.Windows.Forms.ToolStripMenuItem()
        Me.PlayMenuButton = New System.Windows.Forms.ToolStripMenuItem()
        Me.MMSSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.AddImageMenuButton = New System.Windows.Forms.ToolStripMenuItem()
        Me.AddObjectMenuButton = New System.Windows.Forms.ToolStripMenuItem()
        Me.AddSceneMenuButton = New System.Windows.Forms.ToolStripMenuItem()
        Me.AddSoundMenuButton = New System.Windows.Forms.ToolStripMenuItem()
        Me.MMSSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.VariablesMenuButton = New System.Windows.Forms.ToolStripMenuItem()
        Me.ArraysMenuButton = New System.Windows.Forms.ToolStripMenuItem()
        Me.StructuresMenuButton = New System.Windows.Forms.ToolStripMenuItem()
        Me.FilesMenuButton = New System.Windows.Forms.ToolStripMenuItem()
        Me.MMSSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.PlatformInputsMenuButton = New System.Windows.Forms.ToolStripMenuItem()
        Me.GameSettingsMenuButton = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolsDropper = New System.Windows.Forms.ToolStripMenuItem()
        Me.ActionEditorMenuButton = New System.Windows.Forms.ToolStripMenuItem()
        Me.OptionsMenuButton = New System.Windows.Forms.ToolStripMenuItem()
        Me.MMSSeparator7 = New System.Windows.Forms.ToolStripSeparator()
        Me.ShowWelcomeWindowMenuButton = New System.Windows.Forms.ToolStripMenuItem()
        Me.ResetOptionsMenuButton = New System.Windows.Forms.ToolStripMenuItem()
        Me.WindowDropper = New System.Windows.Forms.ToolStripMenuItem()
        Me.HelpDropper = New System.Windows.Forms.ToolStripMenuItem()
        Me.AboutMenuButton = New System.Windows.Forms.ToolStripMenuItem()
        Me.TreeHolder = New System.Windows.Forms.Panel()
        Me.ResourcesList = New DarkFlow.SexyTree()
        Me.ResourceRightClicker = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.AddResourceContextButton = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditResourceContextButton = New System.Windows.Forms.ToolStripMenuItem()
        Me.DeleteResourceContextButton = New System.Windows.Forms.ToolStripMenuItem()
        Me.Glosser = New System.Windows.Forms.Panel()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.StripsContainer = New System.Windows.Forms.Panel()
        Me.MainSplitter = New DarkFlow.SexySplitter()
        Me.PrimaryToolStrip.SuspendLayout()
        Me.DMainMenuStrip.SuspendLayout()
        Me.TreeHolder.SuspendLayout()
        Me.ResourceRightClicker.SuspendLayout()
        Me.Glosser.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.StripsContainer.SuspendLayout()
        Me.SuspendLayout()
        '
        'PrimaryToolStrip
        '
        Me.PrimaryToolStrip.AutoSize = False
        Me.PrimaryToolStrip.BackColor = System.Drawing.Color.Transparent
        Me.PrimaryToolStrip.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PrimaryToolStrip.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PrimaryToolStrip.GripMargin = New System.Windows.Forms.Padding(0)
        Me.PrimaryToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.PrimaryToolStrip.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.PrimaryToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NewButton, Me.OpenButton, Me.SaveButton, Me.MTSSeparator1, Me.PlayButton, Me.MTSSeparator2, Me.GameSettingsButton, Me.PlatformInputsButton, Me.MTSSeparator3, Me.AddImageButton, Me.AddObjectButton, Me.AddSceneButton, Me.AddSoundButton, Me.MTSSeparator4, Me.OptionsButton, Me.MTSSeparator5, Me.ManageLabel, Me.VariablesButton, Me.ArraysButton, Me.ManageStructuresButton, Me.StoreButton})
        Me.PrimaryToolStrip.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow
        Me.PrimaryToolStrip.Location = New System.Drawing.Point(0, 0)
        Me.PrimaryToolStrip.Name = "PrimaryToolStrip"
        Me.PrimaryToolStrip.Padding = New System.Windows.Forms.Padding(0)
        Me.PrimaryToolStrip.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.PrimaryToolStrip.Size = New System.Drawing.Size(572, 30)
        Me.PrimaryToolStrip.TabIndex = 2
        Me.PrimaryToolStrip.Tag = ""
        '
        'NewButton
        '
        Me.NewButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.NewButton.Image = Global.DarkFlow.My.Resources.Resources.NewFileIcon
        Me.NewButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.NewButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.NewButton.Margin = New System.Windows.Forms.Padding(0, -2, 0, 0)
        Me.NewButton.Name = "NewButton"
        Me.NewButton.Size = New System.Drawing.Size(28, 28)
        Me.NewButton.Text = "New..."
        '
        'OpenButton
        '
        Me.OpenButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.OpenButton.Image = Global.DarkFlow.My.Resources.Resources.OpenFileIcon
        Me.OpenButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.OpenButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.OpenButton.Margin = New System.Windows.Forms.Padding(0, -2, 0, 0)
        Me.OpenButton.Name = "OpenButton"
        Me.OpenButton.Size = New System.Drawing.Size(28, 28)
        Me.OpenButton.Text = "Open..."
        '
        'SaveButton
        '
        Me.SaveButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.SaveButton.Image = Global.DarkFlow.My.Resources.Resources.SaveFileIcon
        Me.SaveButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.SaveButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.SaveButton.Margin = New System.Windows.Forms.Padding(0, -2, 0, 0)
        Me.SaveButton.Name = "SaveButton"
        Me.SaveButton.Size = New System.Drawing.Size(28, 28)
        Me.SaveButton.Text = "Save"
        '
        'MTSSeparator1
        '
        Me.MTSSeparator1.AutoSize = False
        Me.MTSSeparator1.Name = "MTSSeparator1"
        Me.MTSSeparator1.Size = New System.Drawing.Size(3, 28)
        '
        'PlayButton
        '
        Me.PlayButton.Image = Global.DarkFlow.My.Resources.Resources.PlayIcon
        Me.PlayButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.PlayButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.PlayButton.Margin = New System.Windows.Forms.Padding(0, -2, 0, 0)
        Me.PlayButton.Name = "PlayButton"
        Me.PlayButton.Size = New System.Drawing.Size(57, 28)
        Me.PlayButton.Text = "Play"
        '
        'MTSSeparator2
        '
        Me.MTSSeparator2.AutoSize = False
        Me.MTSSeparator2.Name = "MTSSeparator2"
        Me.MTSSeparator2.Size = New System.Drawing.Size(3, 28)
        '
        'GameSettingsButton
        '
        Me.GameSettingsButton.Image = Global.DarkFlow.My.Resources.Resources.SettingsIcon
        Me.GameSettingsButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.GameSettingsButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.GameSettingsButton.Margin = New System.Windows.Forms.Padding(0, -2, 0, 0)
        Me.GameSettingsButton.Name = "GameSettingsButton"
        Me.GameSettingsButton.Size = New System.Drawing.Size(111, 28)
        Me.GameSettingsButton.Text = "Game Settings"
        '
        'PlatformInputsButton
        '
        Me.PlatformInputsButton.Image = Global.DarkFlow.My.Resources.Resources.JoyStick
        Me.PlatformInputsButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.PlatformInputsButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.PlatformInputsButton.Margin = New System.Windows.Forms.Padding(0, -2, 0, 0)
        Me.PlatformInputsButton.Name = "PlatformInputsButton"
        Me.PlatformInputsButton.Size = New System.Drawing.Size(117, 28)
        Me.PlatformInputsButton.Text = "Platform Inputs"
        '
        'MTSSeparator3
        '
        Me.MTSSeparator3.AutoSize = False
        Me.MTSSeparator3.Name = "MTSSeparator3"
        Me.MTSSeparator3.Size = New System.Drawing.Size(3, 28)
        '
        'AddImageButton
        '
        Me.AddImageButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.AddImageButton.Image = Global.DarkFlow.My.Resources.Resources.ImageIcon
        Me.AddImageButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.AddImageButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.AddImageButton.Margin = New System.Windows.Forms.Padding(0, -2, 0, 0)
        Me.AddImageButton.Name = "AddImageButton"
        Me.AddImageButton.Size = New System.Drawing.Size(28, 28)
        Me.AddImageButton.Text = "Add Image"
        '
        'AddObjectButton
        '
        Me.AddObjectButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.AddObjectButton.Image = Global.DarkFlow.My.Resources.Resources.ObjectIcon
        Me.AddObjectButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.AddObjectButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.AddObjectButton.Margin = New System.Windows.Forms.Padding(0, -2, 0, 0)
        Me.AddObjectButton.Name = "AddObjectButton"
        Me.AddObjectButton.Size = New System.Drawing.Size(28, 28)
        Me.AddObjectButton.Text = "Add Object"
        '
        'AddSceneButton
        '
        Me.AddSceneButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.AddSceneButton.Image = Global.DarkFlow.My.Resources.Resources.SceneIcon
        Me.AddSceneButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.AddSceneButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.AddSceneButton.Margin = New System.Windows.Forms.Padding(0, -2, 0, 0)
        Me.AddSceneButton.Name = "AddSceneButton"
        Me.AddSceneButton.Size = New System.Drawing.Size(28, 28)
        Me.AddSceneButton.Text = "Add Scene"
        '
        'AddSoundButton
        '
        Me.AddSoundButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.AddSoundButton.Image = Global.DarkFlow.My.Resources.Resources.SoundIcon
        Me.AddSoundButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.AddSoundButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.AddSoundButton.Margin = New System.Windows.Forms.Padding(0, -2, 0, 0)
        Me.AddSoundButton.Name = "AddSoundButton"
        Me.AddSoundButton.Size = New System.Drawing.Size(28, 28)
        Me.AddSoundButton.Text = "Add Sound"
        '
        'MTSSeparator4
        '
        Me.MTSSeparator4.AutoSize = False
        Me.MTSSeparator4.Name = "MTSSeparator4"
        Me.MTSSeparator4.Size = New System.Drawing.Size(3, 28)
        '
        'OptionsButton
        '
        Me.OptionsButton.Image = Global.DarkFlow.My.Resources.Resources.OptionsIcon
        Me.OptionsButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.OptionsButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.OptionsButton.Margin = New System.Windows.Forms.Padding(0, -2, 0, 0)
        Me.OptionsButton.Name = "OptionsButton"
        Me.OptionsButton.Size = New System.Drawing.Size(77, 28)
        Me.OptionsButton.Text = "Options"
        '
        'MTSSeparator5
        '
        Me.MTSSeparator5.AutoSize = False
        Me.MTSSeparator5.Name = "MTSSeparator5"
        Me.MTSSeparator5.Size = New System.Drawing.Size(3, 28)
        Me.MTSSeparator5.Visible = False
        '
        'ManageLabel
        '
        Me.ManageLabel.Margin = New System.Windows.Forms.Padding(0)
        Me.ManageLabel.Name = "ManageLabel"
        Me.ManageLabel.Size = New System.Drawing.Size(53, 15)
        Me.ManageLabel.Text = "Manage:"
        Me.ManageLabel.Visible = False
        '
        'VariablesButton
        '
        Me.VariablesButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.VariablesButton.Enabled = False
        Me.VariablesButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.VariablesButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.VariablesButton.Margin = New System.Windows.Forms.Padding(0, -2, 0, 0)
        Me.VariablesButton.Name = "VariablesButton"
        Me.VariablesButton.Size = New System.Drawing.Size(23, 4)
        Me.VariablesButton.Text = "Manage Variables"
        Me.VariablesButton.Visible = False
        '
        'ArraysButton
        '
        Me.ArraysButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ArraysButton.Enabled = False
        Me.ArraysButton.Image = Global.DarkFlow.My.Resources.Resources.ArrayIcon
        Me.ArraysButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ArraysButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ArraysButton.Margin = New System.Windows.Forms.Padding(0, -2, 0, 0)
        Me.ArraysButton.Name = "ArraysButton"
        Me.ArraysButton.Size = New System.Drawing.Size(28, 28)
        Me.ArraysButton.Text = "Manage Arrays"
        Me.ArraysButton.Visible = False
        '
        'ManageStructuresButton
        '
        Me.ManageStructuresButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ManageStructuresButton.Enabled = False
        Me.ManageStructuresButton.Image = Global.DarkFlow.My.Resources.Resources.ArrayIcon
        Me.ManageStructuresButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ManageStructuresButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ManageStructuresButton.Margin = New System.Windows.Forms.Padding(0, -2, 0, 0)
        Me.ManageStructuresButton.Name = "ManageStructuresButton"
        Me.ManageStructuresButton.Size = New System.Drawing.Size(28, 28)
        Me.ManageStructuresButton.Text = "Manage Structures"
        Me.ManageStructuresButton.Visible = False
        '
        'StoreButton
        '
        Me.StoreButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.StoreButton.Enabled = False
        Me.StoreButton.Image = Global.DarkFlow.My.Resources.Resources.BuyIcon
        Me.StoreButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.StoreButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.StoreButton.Margin = New System.Windows.Forms.Padding(0, -2, 0, 0)
        Me.StoreButton.Name = "StoreButton"
        Me.StoreButton.Size = New System.Drawing.Size(28, 28)
        Me.StoreButton.Text = "Resource Store"
        Me.StoreButton.Visible = False
        '
        'DMainMenuStrip
        '
        Me.DMainMenuStrip.BackColor = System.Drawing.Color.Transparent
        Me.DMainMenuStrip.Dock = System.Windows.Forms.DockStyle.None
        Me.DMainMenuStrip.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DMainMenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileDropper, Me.GameDropper, Me.ToolsDropper, Me.WindowDropper, Me.HelpDropper})
        Me.DMainMenuStrip.Location = New System.Drawing.Point(62, 2)
        Me.DMainMenuStrip.MdiWindowListItem = Me.WindowDropper
        Me.DMainMenuStrip.Name = "DMainMenuStrip"
        Me.DMainMenuStrip.Padding = New System.Windows.Forms.Padding(2, 3, 0, 1)
        Me.DMainMenuStrip.Size = New System.Drawing.Size(246, 24)
        Me.DMainMenuStrip.TabIndex = 1
        '
        'FileDropper
        '
        Me.FileDropper.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NewMenuButton, Me.OpenMenuButton, Me.SaveMenuButton, Me.SaveAsMenuButton})
        Me.FileDropper.Name = "FileDropper"
        Me.FileDropper.Size = New System.Drawing.Size(37, 20)
        Me.FileDropper.Text = "File"
        '
        'NewMenuButton
        '
        Me.NewMenuButton.Image = Global.DarkFlow.My.Resources.Resources.NewFileIcon
        Me.NewMenuButton.Name = "NewMenuButton"
        Me.NewMenuButton.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.N), System.Windows.Forms.Keys)
        Me.NewMenuButton.Size = New System.Drawing.Size(155, 22)
        Me.NewMenuButton.Text = "New"
        '
        'OpenMenuButton
        '
        Me.OpenMenuButton.Image = Global.DarkFlow.My.Resources.Resources.OpenFileIcon
        Me.OpenMenuButton.Name = "OpenMenuButton"
        Me.OpenMenuButton.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.O), System.Windows.Forms.Keys)
        Me.OpenMenuButton.Size = New System.Drawing.Size(155, 22)
        Me.OpenMenuButton.Text = "Open..."
        '
        'SaveMenuButton
        '
        Me.SaveMenuButton.Image = Global.DarkFlow.My.Resources.Resources.SaveFileIcon
        Me.SaveMenuButton.Name = "SaveMenuButton"
        Me.SaveMenuButton.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.S), System.Windows.Forms.Keys)
        Me.SaveMenuButton.Size = New System.Drawing.Size(155, 22)
        Me.SaveMenuButton.Text = "Save"
        '
        'SaveAsMenuButton
        '
        Me.SaveAsMenuButton.Image = Global.DarkFlow.My.Resources.Resources.SaveAsIcon
        Me.SaveAsMenuButton.Name = "SaveAsMenuButton"
        Me.SaveAsMenuButton.Size = New System.Drawing.Size(155, 22)
        Me.SaveAsMenuButton.Text = "Save As..."
        '
        'GameDropper
        '
        Me.GameDropper.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PlayMenuButton, Me.MMSSeparator2, Me.AddImageMenuButton, Me.AddObjectMenuButton, Me.AddSceneMenuButton, Me.AddSoundMenuButton, Me.MMSSeparator4, Me.VariablesMenuButton, Me.ArraysMenuButton, Me.StructuresMenuButton, Me.FilesMenuButton, Me.MMSSeparator5, Me.PlatformInputsMenuButton, Me.GameSettingsMenuButton})
        Me.GameDropper.Name = "GameDropper"
        Me.GameDropper.Size = New System.Drawing.Size(50, 20)
        Me.GameDropper.Text = "Game"
        '
        'PlayMenuButton
        '
        Me.PlayMenuButton.Image = Global.DarkFlow.My.Resources.Resources.PlayIcon
        Me.PlayMenuButton.Name = "PlayMenuButton"
        Me.PlayMenuButton.ShortcutKeys = System.Windows.Forms.Keys.F5
        Me.PlayMenuButton.Size = New System.Drawing.Size(165, 22)
        Me.PlayMenuButton.Text = "Play"
        '
        'MMSSeparator2
        '
        Me.MMSSeparator2.Name = "MMSSeparator2"
        Me.MMSSeparator2.Size = New System.Drawing.Size(162, 6)
        '
        'AddImageMenuButton
        '
        Me.AddImageMenuButton.Image = Global.DarkFlow.My.Resources.Resources.ImageIcon
        Me.AddImageMenuButton.Name = "AddImageMenuButton"
        Me.AddImageMenuButton.Size = New System.Drawing.Size(165, 22)
        Me.AddImageMenuButton.Text = "Add Image"
        '
        'AddObjectMenuButton
        '
        Me.AddObjectMenuButton.Image = Global.DarkFlow.My.Resources.Resources.ObjectIcon
        Me.AddObjectMenuButton.Name = "AddObjectMenuButton"
        Me.AddObjectMenuButton.Size = New System.Drawing.Size(165, 22)
        Me.AddObjectMenuButton.Text = "Add Object"
        '
        'AddSceneMenuButton
        '
        Me.AddSceneMenuButton.Image = Global.DarkFlow.My.Resources.Resources.SceneIcon
        Me.AddSceneMenuButton.Name = "AddSceneMenuButton"
        Me.AddSceneMenuButton.Size = New System.Drawing.Size(165, 22)
        Me.AddSceneMenuButton.Text = "Add Scene"
        '
        'AddSoundMenuButton
        '
        Me.AddSoundMenuButton.Image = Global.DarkFlow.My.Resources.Resources.SoundIcon
        Me.AddSoundMenuButton.Name = "AddSoundMenuButton"
        Me.AddSoundMenuButton.Size = New System.Drawing.Size(165, 22)
        Me.AddSoundMenuButton.Text = "Add Sound"
        '
        'MMSSeparator4
        '
        Me.MMSSeparator4.Name = "MMSSeparator4"
        Me.MMSSeparator4.Size = New System.Drawing.Size(162, 6)
        Me.MMSSeparator4.Visible = False
        '
        'VariablesMenuButton
        '
        Me.VariablesMenuButton.Enabled = False
        Me.VariablesMenuButton.Name = "VariablesMenuButton"
        Me.VariablesMenuButton.Size = New System.Drawing.Size(165, 22)
        Me.VariablesMenuButton.Text = "Variables..."
        Me.VariablesMenuButton.Visible = False
        '
        'ArraysMenuButton
        '
        Me.ArraysMenuButton.Enabled = False
        Me.ArraysMenuButton.Name = "ArraysMenuButton"
        Me.ArraysMenuButton.Size = New System.Drawing.Size(165, 22)
        Me.ArraysMenuButton.Text = "Arrays..."
        Me.ArraysMenuButton.Visible = False
        '
        'StructuresMenuButton
        '
        Me.StructuresMenuButton.Enabled = False
        Me.StructuresMenuButton.Name = "StructuresMenuButton"
        Me.StructuresMenuButton.Size = New System.Drawing.Size(165, 22)
        Me.StructuresMenuButton.Text = "Structures..."
        Me.StructuresMenuButton.Visible = False
        '
        'FilesMenuButton
        '
        Me.FilesMenuButton.Enabled = False
        Me.FilesMenuButton.Name = "FilesMenuButton"
        Me.FilesMenuButton.Size = New System.Drawing.Size(165, 22)
        Me.FilesMenuButton.Text = "Files..."
        Me.FilesMenuButton.Visible = False
        '
        'MMSSeparator5
        '
        Me.MMSSeparator5.Name = "MMSSeparator5"
        Me.MMSSeparator5.Size = New System.Drawing.Size(162, 6)
        '
        'PlatformInputsMenuButton
        '
        Me.PlatformInputsMenuButton.Image = Global.DarkFlow.My.Resources.Resources.JoyStick
        Me.PlatformInputsMenuButton.Name = "PlatformInputsMenuButton"
        Me.PlatformInputsMenuButton.Size = New System.Drawing.Size(165, 22)
        Me.PlatformInputsMenuButton.Text = "Platform Inputs..."
        '
        'GameSettingsMenuButton
        '
        Me.GameSettingsMenuButton.Image = Global.DarkFlow.My.Resources.Resources.SettingsIcon
        Me.GameSettingsMenuButton.Name = "GameSettingsMenuButton"
        Me.GameSettingsMenuButton.Size = New System.Drawing.Size(165, 22)
        Me.GameSettingsMenuButton.Text = "Settings..."
        '
        'ToolsDropper
        '
        Me.ToolsDropper.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ActionEditorMenuButton, Me.OptionsMenuButton, Me.MMSSeparator7, Me.ShowWelcomeWindowMenuButton, Me.ResetOptionsMenuButton})
        Me.ToolsDropper.Name = "ToolsDropper"
        Me.ToolsDropper.Size = New System.Drawing.Size(48, 20)
        Me.ToolsDropper.Text = "Tools"
        '
        'ActionEditorMenuButton
        '
        Me.ActionEditorMenuButton.Image = Global.DarkFlow.My.Resources.Resources.ActionIcon
        Me.ActionEditorMenuButton.Name = "ActionEditorMenuButton"
        Me.ActionEditorMenuButton.Size = New System.Drawing.Size(201, 22)
        Me.ActionEditorMenuButton.Text = "Action Editor..."
        '
        'OptionsMenuButton
        '
        Me.OptionsMenuButton.Image = Global.DarkFlow.My.Resources.Resources.OptionsIcon
        Me.OptionsMenuButton.Name = "OptionsMenuButton"
        Me.OptionsMenuButton.Size = New System.Drawing.Size(201, 22)
        Me.OptionsMenuButton.Text = "Options..."
        '
        'MMSSeparator7
        '
        Me.MMSSeparator7.Name = "MMSSeparator7"
        Me.MMSSeparator7.Size = New System.Drawing.Size(198, 6)
        '
        'ShowWelcomeWindowMenuButton
        '
        Me.ShowWelcomeWindowMenuButton.Name = "ShowWelcomeWindowMenuButton"
        Me.ShowWelcomeWindowMenuButton.Size = New System.Drawing.Size(201, 22)
        Me.ShowWelcomeWindowMenuButton.Text = "Show Welcome window"
        '
        'ResetOptionsMenuButton
        '
        Me.ResetOptionsMenuButton.Name = "ResetOptionsMenuButton"
        Me.ResetOptionsMenuButton.Size = New System.Drawing.Size(201, 22)
        Me.ResetOptionsMenuButton.Text = "Reset Options"
        '
        'WindowDropper
        '
        Me.WindowDropper.Name = "WindowDropper"
        Me.WindowDropper.Size = New System.Drawing.Size(63, 20)
        Me.WindowDropper.Text = "Window"
        '
        'HelpDropper
        '
        Me.HelpDropper.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AboutMenuButton})
        Me.HelpDropper.Name = "HelpDropper"
        Me.HelpDropper.Size = New System.Drawing.Size(44, 20)
        Me.HelpDropper.Text = "Help"
        '
        'AboutMenuButton
        '
        Me.AboutMenuButton.Name = "AboutMenuButton"
        Me.AboutMenuButton.Size = New System.Drawing.Size(116, 22)
        Me.AboutMenuButton.Text = "About..."
        '
        'TreeHolder
        '
        Me.TreeHolder.BackColor = System.Drawing.Color.White
        Me.TreeHolder.Controls.Add(Me.ResourcesList)
        Me.TreeHolder.Dock = System.Windows.Forms.DockStyle.Left
        Me.TreeHolder.Location = New System.Drawing.Point(0, 56)
        Me.TreeHolder.Name = "TreeHolder"
        Me.TreeHolder.Size = New System.Drawing.Size(200, 424)
        Me.TreeHolder.TabIndex = 9
        '
        'ResourcesList
        '
        Me.ResourcesList.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ResourcesList.BackColor = System.Drawing.Color.White
        Me.ResourcesList.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ResourcesList.ContextMenuStrip = Me.ResourceRightClicker
        Me.ResourcesList.DrawMode = System.Windows.Forms.TreeViewDrawMode.OwnerDrawText
        Me.ResourcesList.ItemHeight = 22
        Me.ResourcesList.LineColor = System.Drawing.Color.FromArgb(CType(CType(131, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(175, Byte), Integer))
        Me.ResourcesList.Location = New System.Drawing.Point(0, 0)
        Me.ResourcesList.Name = "ResourcesList"
        Me.ResourcesList.Size = New System.Drawing.Size(200, 424)
        Me.ResourcesList.TabIndex = 6
        '
        'ResourceRightClicker
        '
        Me.ResourceRightClicker.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AddResourceContextButton, Me.EditResourceContextButton, Me.DeleteResourceContextButton})
        Me.ResourceRightClicker.Name = "ResourceContext"
        Me.ResourceRightClicker.Size = New System.Drawing.Size(128, 70)
        '
        'AddResourceContextButton
        '
        Me.AddResourceContextButton.Enabled = False
        Me.AddResourceContextButton.Image = Global.DarkFlow.My.Resources.Resources.AddIcon
        Me.AddResourceContextButton.Name = "AddResourceContextButton"
        Me.AddResourceContextButton.Size = New System.Drawing.Size(127, 22)
        Me.AddResourceContextButton.Text = "Add"
        '
        'EditResourceContextButton
        '
        Me.EditResourceContextButton.Enabled = False
        Me.EditResourceContextButton.Image = Global.DarkFlow.My.Resources.Resources.EditIcon
        Me.EditResourceContextButton.Name = "EditResourceContextButton"
        Me.EditResourceContextButton.Size = New System.Drawing.Size(127, 22)
        Me.EditResourceContextButton.Text = "Edit"
        '
        'DeleteResourceContextButton
        '
        Me.DeleteResourceContextButton.Enabled = False
        Me.DeleteResourceContextButton.Image = Global.DarkFlow.My.Resources.Resources.DeleteIcon
        Me.DeleteResourceContextButton.Name = "DeleteResourceContextButton"
        Me.DeleteResourceContextButton.ShortcutKeys = System.Windows.Forms.Keys.Delete
        Me.DeleteResourceContextButton.Size = New System.Drawing.Size(127, 22)
        Me.DeleteResourceContextButton.Text = "Delete"
        '
        'Glosser
        '
        Me.Glosser.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Glosser.Controls.Add(Me.PictureBox1)
        Me.Glosser.Controls.Add(Me.DMainMenuStrip)
        Me.Glosser.Controls.Add(Me.StripsContainer)
        Me.Glosser.Location = New System.Drawing.Point(0, 0)
        Me.Glosser.Name = "Glosser"
        Me.Glosser.Size = New System.Drawing.Size(640, 56)
        Me.Glosser.TabIndex = 11
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox1.Image = Global.DarkFlow.My.Resources.Resources.MicroLogo
        Me.PictureBox1.Location = New System.Drawing.Point(4, 1)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(54, 54)
        Me.PictureBox1.TabIndex = 2
        Me.PictureBox1.TabStop = False
        '
        'StripsContainer
        '
        Me.StripsContainer.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.StripsContainer.BackColor = System.Drawing.Color.Transparent
        Me.StripsContainer.Controls.Add(Me.PrimaryToolStrip)
        Me.StripsContainer.Location = New System.Drawing.Point(68, 26)
        Me.StripsContainer.Name = "StripsContainer"
        Me.StripsContainer.Size = New System.Drawing.Size(572, 30)
        Me.StripsContainer.TabIndex = 4
        '
        'MainSplitter
        '
        Me.MainSplitter.Location = New System.Drawing.Point(200, 56)
        Me.MainSplitter.Name = "MainSplitter"
        Me.MainSplitter.Size = New System.Drawing.Size(5, 424)
        Me.MainSplitter.TabIndex = 7
        Me.MainSplitter.TabStop = False
        '
        'MainForm
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.Gray
        Me.ClientSize = New System.Drawing.Size(640, 480)
        Me.Controls.Add(Me.Glosser)
        Me.Controls.Add(Me.MainSplitter)
        Me.Controls.Add(Me.TreeHolder)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.DMainMenuStrip
        Me.MinimumSize = New System.Drawing.Size(640, 480)
        Me.Name = "MainForm"
        Me.Padding = New System.Windows.Forms.Padding(0, 56, 0, 0)
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Dark Flow"
        Me.PrimaryToolStrip.ResumeLayout(False)
        Me.PrimaryToolStrip.PerformLayout()
        Me.DMainMenuStrip.ResumeLayout(False)
        Me.DMainMenuStrip.PerformLayout()
        Me.TreeHolder.ResumeLayout(False)
        Me.ResourceRightClicker.ResumeLayout(False)
        Me.Glosser.ResumeLayout(False)
        Me.Glosser.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.StripsContainer.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents DMainMenuStrip As System.Windows.Forms.MenuStrip
    Friend WithEvents FileDropper As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NewMenuButton As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OpenMenuButton As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SaveMenuButton As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SaveAsMenuButton As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PlayMenuButton As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GameDropper As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AddImageMenuButton As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AddObjectMenuButton As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AddSceneMenuButton As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AddSoundMenuButton As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MMSSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents VariablesMenuButton As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ArraysMenuButton As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents StructuresMenuButton As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FilesMenuButton As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MMSSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents GameSettingsMenuButton As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolsDropper As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OptionsMenuButton As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents WindowDropper As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MainSplitter As SexySplitter
    Friend WithEvents AddImageButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents AddObjectButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents AddSceneButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents AddSoundButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents MTSSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ManageLabel As System.Windows.Forms.ToolStripLabel
    Friend WithEvents VariablesButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents ArraysButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents ManageStructuresButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents PrimaryToolStrip As System.Windows.Forms.ToolStrip
    Friend WithEvents NewButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents OpenButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents SaveButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents MTSSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents PlayButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents GameSettingsButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents OptionsButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents TreeHolder As System.Windows.Forms.Panel
    Friend WithEvents ResourcesList As SexyTree
    Friend WithEvents MTSSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents StoreButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents MMSSeparator7 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ResetOptionsMenuButton As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HelpDropper As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AboutMenuButton As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ResourceRightClicker As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents AddResourceContextButton As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditResourceContextButton As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DeleteResourceContextButton As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Glosser As System.Windows.Forms.Panel
    Friend WithEvents PlatformInputsMenuButton As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PlatformInputsButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents ActionEditorMenuButton As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MMSSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ShowWelcomeWindowMenuButton As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MTSSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents MTSSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents StripsContainer As System.Windows.Forms.Panel

End Class
