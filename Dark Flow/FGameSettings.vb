Public Class FGameSettings

    Private Sub GameSettings_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        GlobalGlass(Me, True, True)
        Icon = ImageToIcon(My.Resources.SettingsIcon)
        ReCenter(Me)
        ScenesDropper.BackCombo.Items.Clear()
        For Each P As Scene In Scenes
            ScenesDropper.BackCombo.Items.Add(P.Name)
        Next
        ScenesDropper.BackCombo.DropDownWidth = ScenesDropper.Width
        ScenesDropper.Text = GetSetting("BootScene")
        GameIDBox.Text = GetSetting("GameID")
        CompanyBox.Text = GetSetting("Company")
        CopyrightBox.Text = GetSetting("Copyright")
        DescriptionBox.Text = GetSetting("Description")
        ProductBox.Text = GetSetting("Product")
        LogoBox.Image = GameLogo.Clone()
    End Sub

    Private Sub DOKButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DOKButton.Click
        'A little Validation
        Dim HasScene As Boolean = False
        For Each P As Scene In Scenes
            If P.Name = ScenesDropper.Text Then HasScene = True
        Next
        If Not HasScene Then
            MsgError("The Starting Scene must actually exist.")
            MainTabControl.SelectedIndex = 0
            ScenesDropper.Focus()
            Exit Sub
        End If
        SetSetting("BootScene", ScenesDropper.Text)
        SetSetting("Product", ProductBox.Text)
        SetSetting("Company", CompanyBox.Text)
        SetSetting("Copyright", CopyrightBox.Text)
        SetSetting("Description", DescriptionBox.Text)
        GameLogo = LogoBox.Image.Clone()
        Close()
    End Sub

    Private Sub MainTabControl_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MainTabControl.SelectedIndexChanged
        Select Case MainTabControl.SelectedIndex
            Case 0
                ScenesDropper.BackCombo.Focus()
            Case 1
                '...
            Case 2
                ProductBox.Focus()
        End Select
        'For Each X As Control In MainTabControl.TabPages(MainTabControl.SelectedIndex).Controls
        '    If TypeOf X Is SexyTextBox Then
        '        MsgError("focus on: " + X.Name)
        '        DirectCast(X, SexyTextBox).TextContainer.Focus()
        '        Exit For
        '    End If
        '    If TypeOf X Is SexyComboBox Then
        '        DirectCast(X, SexyComboBox).BackCombo.Focus()
        '        Exit For
        '    End If
        'Next
    End Sub

    Private Sub ChangeLogoButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChangeLogoButton.Click
        Dim Result As String = OpenFile(String.Empty, ImageFilter)
        If Result.Length = 0 Then Exit Sub
        Dim TI As Image = PathToImage(Result)
        If Not TI.Width = 320 Or Not TI.Height = 85 Then
            MsgError("Image size must be 320 * 85.")
            Exit Sub
        End If
        LogoBox.Image = TI.Clone()
    End Sub

End Class