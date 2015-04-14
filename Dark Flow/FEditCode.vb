Public Class FEditCode

    Public ReturnableCode As String = String.Empty
    Public CodeMode As Byte = 0
    Public ImportExport As Boolean = False
    Public SwapOutSymbols As Boolean = True

    Private Sub EditCode_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        'Icon = ImageToIcon(My.Resources.ScriptIcon)
        MainToolStrip.Renderer = New clsToolstripRenderer
        SexUpToolStrip(MainToolStrip, False, False)
        LoadInButton.Enabled = ImportExport
        SaveOutButton.Enabled = ImportExport

        Dim NewCode As String = ReturnableCode
        NewCode = NewCode.Replace("<br|>", vbCrLf)
        MainTextBox.Text = NewCode

    End Sub

    Private Sub DAcceptButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DAcceptButton.Click
        If SwapOutSymbols Then ReturnableCode = MainTextBox.Text.Replace(vbCrLf, "<br|>") Else ReturnableCode = MainTextBox.Text
        DialogResult = Windows.Forms.DialogResult.OK
        Close()
    End Sub

End Class