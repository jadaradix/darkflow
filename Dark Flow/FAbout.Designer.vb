<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FAbout
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FAbout))
        Me.ImagePanel = New System.Windows.Forms.Panel()
        Me.MainContainerPanel = New System.Windows.Forms.Panel()
        Me.SevenZipLicenseLabel = New System.Windows.Forms.Label()
        Me.CopyrightLabel = New System.Windows.Forms.Label()
        Me.View7ZipLicenseButton = New Dark_Flow.SexyButton()
        Me.ViewLicenseButton = New Dark_Flow.SexyButton()
        Me.AboutLabel = New System.Windows.Forms.Label()
        Me.WrittenByLabel = New System.Windows.Forms.Label()
        Me.DOKButton = New Dark_Flow.SexyButton()
        Me.MainContainerPanel.SuspendLayout()
        Me.SuspendLayout()
        '
        'ImagePanel
        '
        Me.ImagePanel.BackgroundImage = Global.Dark_Flow.My.Resources.Resources.AboutBanner
        Me.ImagePanel.Location = New System.Drawing.Point(0, 0)
        Me.ImagePanel.Name = "ImagePanel"
        Me.ImagePanel.Size = New System.Drawing.Size(340, 100)
        Me.ImagePanel.TabIndex = 0
        '
        'MainContainerPanel
        '
        Me.MainContainerPanel.Controls.Add(Me.SevenZipLicenseLabel)
        Me.MainContainerPanel.Controls.Add(Me.CopyrightLabel)
        Me.MainContainerPanel.Controls.Add(Me.View7ZipLicenseButton)
        Me.MainContainerPanel.Controls.Add(Me.ViewLicenseButton)
        Me.MainContainerPanel.Controls.Add(Me.AboutLabel)
        Me.MainContainerPanel.Controls.Add(Me.WrittenByLabel)
        Me.MainContainerPanel.Location = New System.Drawing.Point(1, 106)
        Me.MainContainerPanel.Name = "MainContainerPanel"
        Me.MainContainerPanel.Size = New System.Drawing.Size(338, 230)
        Me.MainContainerPanel.TabIndex = 3
        '
        'SevenZipLicenseLabel
        '
        Me.SevenZipLicenseLabel.Location = New System.Drawing.Point(4, 120)
        Me.SevenZipLicenseLabel.Name = "SevenZipLicenseLabel"
        Me.SevenZipLicenseLabel.Size = New System.Drawing.Size(331, 50)
        Me.SevenZipLicenseLabel.TabIndex = 6
        Me.SevenZipLicenseLabel.Text = "In Dark Flow, we have used parts of the 7-Zip program, which is licensed under th" & _
    "e GNU LGPL license. Visit www.7-zip.org, where the source code can be found."
        '
        'CopyrightLabel
        '
        Me.CopyrightLabel.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CopyrightLabel.Location = New System.Drawing.Point(4, 181)
        Me.CopyrightLabel.Name = "CopyrightLabel"
        Me.CopyrightLabel.Size = New System.Drawing.Size(331, 19)
        Me.CopyrightLabel.TabIndex = 5
        Me.CopyrightLabel.Text = "Copyright James Garner && Robert Dixon, 2010-2015"
        '
        'View7ZipLicenseButton
        '
        Me.View7ZipLicenseButton.BackColor = System.Drawing.Color.Transparent
        Me.View7ZipLicenseButton.DText = "View 7-Zip License"
        Me.View7ZipLicenseButton.ForeColor = System.Drawing.Color.Black
        Me.View7ZipLicenseButton.ImageOnTop = False
        Me.View7ZipLicenseButton.LeftAligned = False
        Me.View7ZipLicenseButton.Location = New System.Drawing.Point(157, 203)
        Me.View7ZipLicenseButton.Name = "View7ZipLicenseButton"
        Me.View7ZipLicenseButton.ShrinkMyIcon = False
        Me.View7ZipLicenseButton.Size = New System.Drawing.Size(114, 24)
        Me.View7ZipLicenseButton.TabIndex = 3
        Me.View7ZipLicenseButton.TabStop = True
        Me.View7ZipLicenseButton.Text = "View 7-Zip License"
        Me.View7ZipLicenseButton.TextImageSpacing = CType(0, Byte)
        Me.View7ZipLicenseButton.XIMage = Nothing
        '
        'ViewLicenseButton
        '
        Me.ViewLicenseButton.BackColor = System.Drawing.Color.Transparent
        Me.ViewLicenseButton.DText = "View License"
        Me.ViewLicenseButton.ForeColor = System.Drawing.Color.Black
        Me.ViewLicenseButton.ImageOnTop = False
        Me.ViewLicenseButton.LeftAligned = False
        Me.ViewLicenseButton.Location = New System.Drawing.Point(67, 203)
        Me.ViewLicenseButton.Name = "ViewLicenseButton"
        Me.ViewLicenseButton.ShrinkMyIcon = False
        Me.ViewLicenseButton.Size = New System.Drawing.Size(86, 24)
        Me.ViewLicenseButton.TabIndex = 2
        Me.ViewLicenseButton.TabStop = True
        Me.ViewLicenseButton.Text = "View License"
        Me.ViewLicenseButton.TextImageSpacing = CType(0, Byte)
        Me.ViewLicenseButton.XIMage = Nothing
        '
        'AboutLabel
        '
        Me.AboutLabel.Location = New System.Drawing.Point(4, 23)
        Me.AboutLabel.Name = "AboutLabel"
        Me.AboutLabel.Size = New System.Drawing.Size(331, 94)
        Me.AboutLabel.TabIndex = 1
        Me.AboutLabel.Text = resources.GetString("AboutLabel.Text")
        '
        'WrittenByLabel
        '
        Me.WrittenByLabel.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.WrittenByLabel.Location = New System.Drawing.Point(4, 4)
        Me.WrittenByLabel.Name = "WrittenByLabel"
        Me.WrittenByLabel.Size = New System.Drawing.Size(331, 19)
        Me.WrittenByLabel.TabIndex = 0
        Me.WrittenByLabel.Text = "With love from James && Robert."
        '
        'DOKButton
        '
        Me.DOKButton.BackColor = System.Drawing.Color.Transparent
        Me.DOKButton.DText = "OK"
        Me.DOKButton.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(1, Byte), Integer))
        Me.DOKButton.ImageOnTop = False
        Me.DOKButton.LeftAligned = False
        Me.DOKButton.Location = New System.Drawing.Point(229, 342)
        Me.DOKButton.Name = "DOKButton"
        Me.DOKButton.ShrinkMyIcon = False
        Me.DOKButton.Size = New System.Drawing.Size(111, 30)
        Me.DOKButton.TabIndex = 2
        Me.DOKButton.TabStop = True
        Me.DOKButton.Text = "OK"
        Me.DOKButton.TextImageSpacing = CType(0, Byte)
        Me.DOKButton.XIMage = Nothing
        '
        'FAbout
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(340, 372)
        Me.Controls.Add(Me.MainContainerPanel)
        Me.Controls.Add(Me.DOKButton)
        Me.Controls.Add(Me.ImagePanel)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FAbout"
        Me.Padding = New System.Windows.Forms.Padding(1, 106, 1, 36)
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "About"
        Me.MainContainerPanel.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ImagePanel As System.Windows.Forms.Panel
    Friend WithEvents DOKButton As Dark_Flow.SexyButton
    Friend WithEvents MainContainerPanel As System.Windows.Forms.Panel
    Friend WithEvents WrittenByLabel As System.Windows.Forms.Label
    Friend WithEvents AboutLabel As System.Windows.Forms.Label
    Friend WithEvents View7ZipLicenseButton As Dark_Flow.SexyButton
    Friend WithEvents ViewLicenseButton As Dark_Flow.SexyButton
    Friend WithEvents CopyrightLabel As System.Windows.Forms.Label
    Friend WithEvents SevenZipLicenseLabel As System.Windows.Forms.Label
End Class
