Imports System.IO
Imports System.Text

Module SettingsLib

    Public SettingNames As New List(Of String)
    Public SettingValues As New List(Of String)

    Public Function GetSetting(ByVal OName As String) As String
        For SettingNo As Byte = 0 To SettingNames.Count - 1
            If SettingNames(SettingNo) = OName Then Return SettingValues(SettingNo)
        Next
        Return String.Empty
    End Function

    Public Sub SetSetting(ByVal OName As String, ByVal OValue As String)
        Dim BackupValues As New List(Of String)
        Dim DidExist As Boolean = False
        If SettingNames.Count = 0 Then
            SettingNames.Add(OName)
            SettingValues.Add(OValue)
            Exit Sub
        End If
        For SettingNo As Byte = 0 To SettingNames.Count - 1
            If SettingNames(SettingNo) = OName Then
                BackupValues.Add(OValue)
                DidExist = True
            Else
                BackupValues.Add(SettingValues(SettingNo))
            End If
        Next
        SettingValues.Clear()
        For SettingNo As Byte = 0 To BackupValues.Count - 1
            SettingValues.Add(BackupValues(SettingNo))
        Next
        BackupValues.Clear()
        If Not DidExist Then
            SettingNames.Add(OName)
            SettingValues.Add(OValue)
        End If
    End Sub

End Module
