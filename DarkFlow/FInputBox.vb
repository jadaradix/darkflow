Public Class FInputBox

    Public Descriptor As String
    Public TheInput As String
    Public Validation As Byte = 0

    Private Sub FInputBox_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Text = Application.ProductName
        Icon = ImageToIcon(My.Resources.SettingsIcon)
        BackColor = clsColors.CrucialColor
        DescriptionLabel.Text = Descriptor
        MainTextBox.Text = TheInput
        If MainTextBox.Text.Length = 0 Then DOkayButton.Enabled = False
    End Sub

    Private Sub FInputBox_Activated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        MainTextBox.TextContainer.Focus()
    End Sub

    Private Sub DOkayButton_Click() Handles DOkayButton.Click
        TheInput = MainTextBox.Text
        Close()
    End Sub

    Private Sub DCancelButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DCancelButton.Click
        Close()
    End Sub

    Private Sub MainTextBox_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MainTextBox.DTextChanged
        DOkayButton.Enabled = ValidateSomething(MainTextBox.Text, Validation)
    End Sub

    Private Sub MainTextBox_DKeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MainTextBox.DKeyPress
        If e.KeyChar = ChrW(Keys.Return) And ValidateSomething(MainTextBox.Text, Validation) Then
            DOkayButton_Click()
        End If
    End Sub

End Class