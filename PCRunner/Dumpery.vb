Public Class Dumpery

    Private Sub SaveButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveButton.Click
        Dim FinalString As String = String.Empty
        For Each LItem As ListViewItem In DataList.Items
            FinalString += LItem.SubItems(0).Text + ": " + LItem.SubItems(1).Text + vbNewLine
        Next
        Dim N As New SaveFileDialog
        With N
            .FileName = "GameDump.txt"
            .Filter = "Text Files|*.txt"
            .InitialDirectory = My.Computer.FileSystem.SpecialDirectories.Desktop
            .Title = Application.ProductName
        End With
        If Not N.ShowDialog = Windows.Forms.DialogResult.OK Then Exit Sub
        Dim NPath As String = N.FileName
        IO.File.WriteAllText(NPath, FinalString)
    End Sub

End Class