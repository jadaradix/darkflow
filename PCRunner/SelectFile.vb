Imports System.Drawing.Drawing2D

Public Class SelectFile

    Public PossibleFiles As New List(Of String)

    Private Sub SelectFile_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Icon = My.Resources.InternalAppIcon
        PossibleFiles = MainForm.FilesFound
        For Each P As String In PossibleFiles
            P = P.Substring(P.LastIndexOf("\") + 1)
            FilesListBox.Items.Add(P)
        Next
    End Sub

    Private Sub SelectFile_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown
        FilesListBox.SelectedIndex = 0
    End Sub

    Private Sub FilesListBox_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles FilesListBox.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Enter) Then
            DoOK()
            e.Handled = True
        End If
    End Sub

    Private Sub DOKButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DOKButton.Click
        DoOK()
    End Sub

    Sub DoOK()
        Me.Close()
    End Sub

End Class