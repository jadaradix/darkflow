Imports System.IO
Imports System.Text

Module OptionsLib

    Public OptionNames As New List(Of String)
    Public OptionValues As New List(Of String)
    Public OptionsPath As String = String.Empty

    Public Sub LoadOptions()
        OptionNames.Clear()
        OptionValues.Clear()
        For Each OptionLine As String In File.ReadAllLines(OptionsPath)
            Dim OName As String = OptionLine.Substring(0, OptionLine.IndexOf(" "))
            Dim OValue As String = OptionLine.Substring(OptionLine.IndexOf(" ") + 1)
            OptionNames.Add(OName)
            OptionValues.Add(OValue)
        Next
        Dim MadeCorrections As Boolean = False
        For Each P As String In StringToLines(Encoding.ASCII.GetString(My.Resources.RestoreData))
            Dim OName As String = P.Substring(0, P.IndexOf(" "))
            If Not OptionNames.Contains(OName) Then
                OptionNames.Add(OName)
                OptionValues.Add(P.Substring(P.IndexOf(" ") + 1))
                MadeCorrections = True
            End If
        Next
        'If GetOption("BROWSER").Length = 0 Then
        '    SetOption("BROWSER", "Internet Explorer")
        '    MustSave = True
        'End If
        If GetOption("HOSTUSER").Length = 0 Then
            SetOption("HOSTUSER", "fking_")
        End If
        If GetOption("IMAGE_EDITOR").Length = 0 Then
            Dim PaintDotNetPath As String = My.Computer.FileSystem.SpecialDirectories.ProgramFiles + "\Paint.NET\PaintDotNet.exe"
            If File.Exists(PaintDotNetPath) Then
                SetOption("IMAGE_EDITOR", PaintDotNetPath)
                SetOption("ALPHA_CAPABLE", "1")
            Else
                Dim MSPaintPath As String = Environment.GetFolderPath(Environment.SpecialFolder.System) + "\mspaint.exe"
                SetOption("IMAGE_EDITOR", MSPaintPath)
                SetOption("ALPHA_CAPABLE", "0")
            End If
            MadeCorrections = True
        End If
        If GetOption("WELCOME_ON_BOOT").Length = 0 Then
            SetOption("WELCOME_ON_BOOT", "1")
            MadeCorrections = True
        End If
        If GetOption("AUTO_SAVE").Length = 0 Then
            SetOption("AUTO_SAVE", "0")
            MadeCorrections = True
        End If
        If GetOption("SOUND_EDITOR").Length = 0 Then
            Dim AudacityFoundPath As String = String.Empty
            For Each P As String In Directory.GetDirectories(My.Computer.FileSystem.SpecialDirectories.ProgramFiles)
                Dim DirName As String = P.Substring(P.LastIndexOf("\") + 1)
                If DirName.StartsWith("Audacity") And File.Exists(P + "\audacity.exe") Then
                    AudacityFoundPath = P + "\audacity.exe"
                End If
            Next
            If AudacityFoundPath.Length > 0 Then
                SetOption("SOUND_EDITOR", AudacityFoundPath)
                MadeCorrections = True
            End If
        End If
        If MadeCorrections Then SaveOptions()
        ThinList = GetOption("SHRINK_ACTIONS_LIST")
    End Sub

    Public Sub SaveOptions()
        Dim FinalString As String = String.Empty
        For OptionNo As Byte = 0 To OptionNames.Count - 1
            FinalString += OptionNames(OptionNo) + " " + OptionValues(OptionNo) + vbCrLf
        Next
        File.WriteAllText(OptionsPath, FinalString)
    End Sub

    Public Function GetOption(ByVal OName As String) As String
        For OptionNo As Byte = 0 To OptionNames.Count - 1
            If OptionNames(OptionNo) = OName Then Return OptionValues(OptionNo)
        Next
        Return String.Empty
    End Function

    Public Sub SetOption(ByVal OName As String, ByVal OValue As String)
        Dim BackupValues As New List(Of String)
        Dim DidExist As Boolean = False
        For OptionNo As Byte = 0 To OptionNames.Count - 1
            If OptionNames(OptionNo) = OName Then
                BackupValues.Add(OValue)
                DidExist = True
            Else
                BackupValues.Add(OptionValues(OptionNo))
            End If
        Next
        OptionValues.Clear()
        For OptionNo As Byte = 0 To BackupValues.Count - 1
            OptionValues.Add(BackupValues(OptionNo))
        Next
        BackupValues.Clear()
        If Not DidExist Then
            OptionNames.Add(OName)
            OptionValues.Add(OValue)
        End If
    End Sub

End Module
