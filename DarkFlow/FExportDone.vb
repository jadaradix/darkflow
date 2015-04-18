Imports System.IO

Public Class FExportDone

    Public WhichPlatform As Object
    Public ImportantData As String

    Private Sub ExportDone_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        PathLabel.DText = ImportantData
        MainInfoLabel.DText = "Your " + DirectCast(WhichPlatform, Platform).Name + " Game has been created successfully."
        If DirectCast(WhichPlatform, Platform).Category = PlatformCategory.Browser Then
            SubInfoLabel.DText = "Host the files in the below folder to share your work!"
            Function1.DText = "Publish To Website"
            Function2.DText = "Open in Explorer"
            Function1.Enabled = False
        Else
            SubInfoLabel.DText = "Share the below file to let others play it."
            Function1.Enabled = True
            Function1.DText = If(DirectCast(WhichPlatform, Platform).Name = "Mac", "Save App", "Save EXE")
            Function2.DText = "Copy File to Clipboard"
        End If
        GlobalGlass(Me, True, True)
        Icon = ImageToIcon(My.Resources.PlayIcon)
        ReCenter(Me)
    End Sub

    Private Sub DOKButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DOKButton.Click
        Close()
    End Sub

    Private Sub Function1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Function1.Click
        If DirectCast(WhichPlatform, Platform).Name = "Mac" Then
            Dim NewPath As String = SaveFile(String.Empty, "Zip Packages|*.zip", GetSetting("Product") + ".zip")
            If File.Exists(AppPath + "PlatformProfiles\MacInsertion\Contents\Resources\Data.odfx") Then File.Delete(AppPath + "PlatformProfiles\MacInsertion\Contents\Resources\Data.odfx")
            File.Copy(ImportantData, AppPath + "PlatformProfiles\MacInsertion\Contents\Resources\Data.odfx")
            If Directory.Exists(AppPath + "PlatformProfiles\" + GetSetting("Product") + ".app") Then Directory.Delete(AppPath + "PlatformProfiles\" + GetSetting("Product") + ".app", True)
            My.Computer.FileSystem.CopyDirectory(AppPath + "PlatformProfiles\MacInsertion", AppPath + "PlatformProfiles\" + GetSetting("Product") + ".app")
            Dim MyBAT As String = "zip.exe a """ + NewPath + """ """ + GetSetting("Product") + ".app""" + vbCrLf + "exit"
            RunBatchString(MyBAT, AppPath + "PlatformProfiles", True)
        Else
            'Utto!
            Dim ODFXBytes() As Byte = File.ReadAllBytes(ImportantData)
            If ODFXBytes.Length > ((1024 * 1024) - 256) Then
                MsgError("Your game is too big. Try removing some Sounds.")
                Exit Sub
            End If
            Dim NewPath As String = SaveFile(String.Empty, "Executables|*.exe", GetSetting("Product") + ".exe")
            If NewPath.Length = 0 Then Exit Sub
            Dim EXEBytes() As Byte = File.ReadAllBytes(AppPath + "PlatformProfiles\Windows.exe")
            Dim ODFXBytesLength As UInt64 = ODFXBytes.Length
            Dim ODFXBytesLengthString As String = ODFXBytesLength.ToString
            If ODFXBytesLengthString.Length < 8 Then
                'Pad me up, Laddy
                For U As Byte = 0 To (8 - ODFXBytesLengthString.Length - 1)
                    ODFXBytesLengthString = "0" + ODFXBytesLengthString
                Next
            End If

            Dim DataLengthLooker As String = String.Empty
            Dim DataLooker As String = String.Empty
            For Each PLine As String In File.ReadAllLines("PlatformProfiles\WindowsInsertion.bin")
                If PLine.StartsWith("DataLength:") Then
                    DataLengthLooker = PLine.Substring(("DataLength:").Length)
                ElseIf PLine.StartsWith("Data:") Then
                    DataLooker = PLine.Substring(("Data:").Length)
                End If
            Next

            'DataLengthInsertion
            Dim DataLengthInsertion As UInt64 = 0
            For T As UInt64 = 0 To EXEBytes.Length - DataLengthLooker.Length - 1
                Dim LBytes(DataLengthLooker.Length) As Byte
                For Y As Byte = 0 To DataLengthLooker.Length - 1
                    LBytes(Y) = EXEBytes(T + Y)
                Next
                Dim LBytesR As String = String.Empty
                For Y As Byte = 0 To DataLengthLooker.Length - 1
                    LBytesR += Chr(LBytes(Y)).ToString
                Next
                If LBytesR.Length = DataLengthLooker.Length Then
                    If LBytesR = DataLengthLooker Then
                        DataLengthInsertion = T
                        Exit For
                    End If
                End If
            Next

            'DataInsertion
            Dim DataInsertion As UInt64 = 128
            For T As UInt64 = 0 To EXEBytes.Length - DataLooker.Length - 1
                Dim LBytes(DataLooker.Length) As Byte
                For Y As Byte = 0 To DataLooker.Length - 1
                    LBytes(Y) = EXEBytes(T + Y)
                Next
                Dim LBytesR As String = String.Empty
                For Y As Byte = 0 To DataLooker.Length - 1
                    LBytesR += Chr(LBytes(Y)).ToString
                Next
                If LBytesR.Length = DataLooker.Length Then
                    If LBytesR = DataLooker Then
                        DataInsertion = T
                        Exit For
                    End If
                End If
            Next

            'MsgError("Insert length at " + DataLengthInsertion.ToString)
            'MsgError("Insert data at " + DataInsertion.ToString)

            Dim O As UInt64 = 0
            For I As UInt64 = DataLengthInsertion To (DataLengthInsertion + ODFXBytesLengthString.Length - 1)
                EXEBytes(I) = Asc(ODFXBytesLengthString(O))
                O += 1
            Next

            O = 0
            For I As UInt64 = DataInsertion To (DataInsertion + ODFXBytesLength - 1)
                EXEBytes(I) = ODFXBytes(O)
                O += 1
            Next

            File.WriteAllBytes(NewPath, EXEBytes)
        End If

    End Sub

    Private Sub Function2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Function2.Click
        If DirectCast(WhichPlatform, Platform).Category = PlatformCategory.Browser Then
            System.Diagnostics.Process.Start("explorer", """" + ImportantData + """")
        Else
            If DirectCast(WhichPlatform, Platform).Name = "Mac" Then
                If File.Exists(AppPath + "PlatformProfiles\" + GetSetting("Product") + ".zip") Then File.Delete(AppPath + "PlatformProfiles\" + GetSetting("Product") + ".zip")
                If File.Exists(AppPath + "PlatformProfiles\MacInsertion\Contents\Resources\Data.odfx") Then File.Delete(AppPath + "PlatformProfiles\MacInsertion\Contents\Resources\Data.odfx")
                File.Copy(ImportantData, AppPath + "PlatformProfiles\MacInsertion\Contents\Resources\Data.odfx")
                If Directory.Exists(AppPath + "PlatformProfiles\" + GetSetting("Product") + ".app") Then Directory.Delete(AppPath + "PlatformProfiles\" + GetSetting("Product") + ".app", True)
                My.Computer.FileSystem.CopyDirectory(AppPath + "PlatformProfiles\MacInsertion", AppPath + "PlatformProfiles\" + GetSetting("Product") + ".app")
                Dim MyBAT As String = "zip.exe a """ + GetSetting("Product") + ".zip"" """ + GetSetting("Product") + ".app""" + vbCrLf + "exit"
                RunBatchString(MyBAT, AppPath + "PlatformProfiles", True)
            End If

            Dim MyData As New DataObject
            Dim MyFileNames(0) As String
            MyFileNames(0) = If(DirectCast(WhichPlatform, Platform).Name = "Mac", AppPath + "PlatformProfiles\" + GetSetting("Product") + ".zip", ImportantData)
            MyData.SetData(DataFormats.FileDrop, True, MyFileNames)
            Clipboard.SetDataObject(MyData, True)
            End If
    End Sub

End Class