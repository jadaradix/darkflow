Imports System.IO

Public Class FWelcome

    Dim LastProject As String

    Private Sub FWelcome_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        CorrectDialog(Me, False)
        BackColor = CrucialColor
        Icon = My.Resources.Icon

        LastProject = GetOption("LAST_PROJECT")
        OpenLastProjectButton.Enabled = IO.File.Exists(LastProject)

        Dim RCount As UInt16 = 0
        For Each F As String In Directory.GetFiles(AppPath + "Examples")
            Dim D As String = F
            D = D.Substring(D.LastIndexOf("\") + 1)
            D = D.Substring(0, D.LastIndexOf("."))
            ExamplesList.Items.Add(D)
            RCount += 1
        Next

        If RCount > 0 Then
            OpenExampleButton.Enabled = True
            ExamplesList.SelectedIndex = 0
        Else
            OpenExampleButton.Enabled = False
        End If

    End Sub

    Private Sub OpenLastProjectButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpenLastProjectButton.Click
        OpenProject(LastProject)
    End Sub

    Private Sub ExamplesList_DrawItem(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DrawItemEventArgs) Handles ExamplesList.DrawItem
        If e.Index < 0 Then Exit Sub
        GDIRenderItem(Color.White, False, e, 9, New Point(22, e.Bounds.Y + 3), ExamplesList.Items(e.Index), My.Resources.CopyIcon)
    End Sub

    Private Sub ExamplesList_MouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ExamplesList.MouseDoubleClick
        Dim MouseY As UInt16 = e.Location.Y
        If MouseY <= 0 Then Exit Sub
        If MouseY > (ExamplesList.Items.Count * ExamplesList.ItemHeight) Then Exit Sub
        OpenExampleButton_Click()
    End Sub

    Private Sub OpenExampleButton_Click() Handles OpenExampleButton.Click
        OpenProject(AppPath + "Examples\" + ExamplesList.Items(ExamplesList.SelectedIndex) + ".dfk")
    End Sub

    Private Sub OpenExampleButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpenExampleButton.Click

    End Sub
End Class