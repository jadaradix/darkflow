Public Class FAbout

    Private Sub FormAbout_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        MainContainerPanel.BackColor = CrucialColor
        GlobalGlass(Me, True, True)
        Icon = My.Resources.Icon
        ReCenter(Me)
        HideTitleBar(Me)
    End Sub

    Private Sub ViewLicenseButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ViewLicenseButton.Click
        System.Diagnostics.Process.Start("notepad", AppPath + "Dark Flow License.txt")
    End Sub

    Private Sub View7ZipLicenseButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles View7ZipLicenseButton.Click
        System.Diagnostics.Process.Start("notepad", AppPath + "7-Zip License.txt")
    End Sub

    Private Sub DOKButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DOKButton.Click
        Close()
    End Sub

    Private Sub ImagePanel_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles ImagePanel.Paint
        e.Graphics.TextRenderingHint = Drawing.Text.TextRenderingHint.ClearTypeGridFit
        Dim W As UInt16 = CType(sender, Panel).Width
        Dim H As UInt16 = CType(sender, Panel).Height
    End Sub

End Class