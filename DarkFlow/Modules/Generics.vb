Imports System.Net
Imports System.IO

Module Generics

    Private Declare Function InternetCheckConnection Lib "wininet.dll" _
    Alias "InternetCheckConnectionA" (ByVal lpszUrl As String, ByVal dwFlags As Long, ByVal dwReserved As Long) As Boolean

    Public BannedChars() As String = New String() {" ", ",", ".", CS, "/", "\", "!", """", "(", ")", "£", "$", "%", "^", "&", "*", "{", "}", _
                                          "[", "]", "@", "#", "'", "~", "<", ">", "?", "+", "=", "-", "|", "¬", "`"}

    Public Numbers() As String = New String() {"1", "2", "3", "4", "5", "6", "7", "8", "9", "0"}
    'Public ImageFilter As String = "Graphics|*.png; *.gif; *.bmp|PNG Images|*.png|GIF Images|*.gif|Bitmap Images|*.bmp"
    Public ImageFilter As String = "Portable Network Graphics|*.png|JPEG Images|*.jpg;*.jpeg|Graphics Interchange Format|*.gif|Bitmap Images|*.bmp"

    Public LoadDefaultFolder As String = My.Computer.FileSystem.SpecialDirectories.Desktop
    Public SaveDefaultFolder As String = My.Computer.FileSystem.SpecialDirectories.Desktop

    Public AppPath As String = String.Empty
    Public CDrive As String = String.Empty

    Public WC As New System.Net.WebClient

    Public Enum ValidateLevel As Byte
        None = 0
        NumberStart = 2
        Loose = 4
        Tight = 5
    End Enum

    Function GetHTTPData(ByVal URL As String) As String
        Try
            Return WC.DownloadString(URL)
        Catch : Return String.Empty : End Try
    End Function

    Public Function SQLSanitize(ByVal InputData As String, ByVal AlsoSpaces As Boolean) As String
        InputData = InputData.Replace("(", String.Empty)
        InputData = InputData.Replace("'", String.Empty)
        InputData = InputData.Replace("""", String.Empty)
        If AlsoSpaces Then InputData = InputData.Replace(" ", String.Empty)
        Return InputData
    End Function

    Function MakeSpaces(ByVal HowMany As Byte) As String
        Dim Returnable As String = String.Empty
        If HowMany = 0 Then Return Returnable
        For X As Byte = 0 To HowMany - 1
            Returnable += " "
        Next
        Return Returnable
    End Function

    Public Function GetTime() As String
        Dim Returnable As String = Now.Hour.ToString + ":"
        If Now.Minute = 0 Then Returnable += "00"
        If Now.Minute > 0 And Now.Minute < 10 Then Returnable += "0" + Now.Minute.ToString
        If Now.Minute >= 10 Then Returnable += Now.Minute.ToString
        Return Returnable
    End Function

    Function HowManyChar(ByVal TheText As String, ByVal WhichChar As String) As Int16
        If TheText.Length = 0 Then Return 0
        Dim Returnable As UInt32 = 0
        For X As UInt32 = 0 To TheText.Length - 1
            If TheText.Substring(X, 1) = WhichChar Then Returnable += 1
        Next
        Return Returnable
    End Function

    Function IsNumeric(ByVal val As String, ByVal NumberStyle As System.Globalization.NumberStyles) As Boolean
        Return [Double].TryParse(val, NumberStyle, System.Globalization.CultureInfo.CurrentCulture, 0)
    End Function

    Sub MsgWarn(ByVal Message As String, Optional ByVal Title As String = "Dark Flow")
        MessageBox.Show(Message, Title, MessageBoxButtons.OK, MessageBoxIcon.Warning)
    End Sub

    Sub MsgError(ByVal Message As String, Optional ByVal Title As String = "Dark Flow")
        MessageBox.Show(Message, Title, MessageBoxButtons.OK, MessageBoxIcon.Error)
    End Sub

    Sub MsgInfo(ByVal msg As String, Optional ByVal Title As String = "Dark Flow")
        MessageBox.Show(msg, Title, MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Function WarnYesNo(ByVal Message As String, Optional ByVal Title As String = "Dark Flow") As Boolean
        Dim Result As Byte = MessageBox.Show(Message, Title, MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
        Return (Result = MsgBoxResult.Yes)
    End Function

    Function CanDivide(ByVal Biggun As Int16, ByVal Dividant As Int16) As Boolean
        If Biggun = 0 Or Dividant = 0 Then Return False
        Return ((Biggun Mod Dividant) = 0)
    End Function

    Function ImageCountColors(ByVal TheImage As Bitmap) As Int16
        Dim DOn As Int16 = 0
        If TheImage.Palette.Entries.Length = 0 Then
            Dim AllColors As New Collection
            For X As Int16 = 0 To TheImage.Width - 1
                For Y As Int16 = 0 To TheImage.Height - 1
                    Dim TheColor As Color = TheImage.GetPixel(X, Y)
                    Dim TheColorString As String = TheColor.R.ToString + TheColor.G.ToString + TheColor.B.ToString
                    Dim AlreadyThere As Boolean = False
                    For Each P As String In AllColors
                        If P = TheColorString Then AlreadyThere = True : Exit For
                    Next
                    If Not AlreadyThere Then AllColors.Add(TheColorString)
                Next
            Next
            Return AllColors.Count
        Else
            For Each MyColor As Color In TheImage.Palette.Entries
                If Not DOn = 0 And MyColor.R = 0 And MyColor.G = 0 And MyColor.B = 0 Then Exit For
                DOn += 1
            Next
            Return DOn
        End If
    End Function

    Public Function ValidateSomething(ByVal ThingToValidate As String, ByVal VMode As Byte) As Boolean
        If VMode = ValidateLevel.None Then Return True
        If ThingToValidate.Contains("!") Then Return False
        If ThingToValidate.Length = 0 Then Return False
        Dim Returnable As Boolean = True
        If VMode = ValidateLevel.NumberStart Or VMode = ValidateLevel.Loose Then
            If ThingToValidate.StartsWith(" ") Then Returnable = False
            For Each Number As String In Numbers
                If ThingToValidate.StartsWith(Number) Then Returnable = False
            Next
        End If
        If VMode = ValidateLevel.Tight Then
            For Each BannedChar As String In BannedChars
                If ThingToValidate.Contains(BannedChar) Then Returnable = False
            Next
        End If
        Return Returnable
    End Function

    Public Function OpenFile(ByVal Directory As String, ByVal Filter As String) As String
        Dim Returnable As String
        Dim OFD As New OpenFileDialog
        With OFD
            .InitialDirectory = Directory
            .FileName = String.Empty
            .Filter = Filter
            .Title = "Open File"
            If Not .ShowDialog() = Windows.Forms.DialogResult.OK Then Returnable = String.Empty Else Returnable = .FileName
            .Dispose()
        End With
        If Returnable.Length > 0 Then
            Dim PR As String = Returnable.Substring(0, Returnable.LastIndexOf("\"))
            LoadDefaultFolder = PR
        End If
        Return Returnable
    End Function

    'Public Function GetInput(ByVal Descriptor As String, ByVal DefaultValue As String, ByVal VM As Byte) As String
    '    Dim X As New FInputBox
    '    X.Descriptor = Descriptor
    '    X.TheInput = DefaultValue
    '    X.Validation = VM
    '    X.ShowDialog()
    '    Dim ToGive As String = X.TheInput
    '    X.Dispose()
    '    Return ToGive
    'End Function

    Public Function SelectColor(ByVal InputColor As Color) As Color
        Dim CPicker As New ColorDialog
        With CPicker
            .AllowFullOpen = True
            .AnyColor = True
            .Color = InputColor
            If .ShowDialog() = Windows.Forms.DialogResult.OK Then Return .Color
        End With
        Return InputColor
    End Function

    Function PathToImage(ByVal path As String) As Image
        Dim imgData() As Byte = SafeGetFileData(path)
        Return New Bitmap(System.Drawing.Image.FromStream(New MemoryStream(imgData)))
    End Function

    Function SafeGetFileData(ByVal filePath As String) As Byte()
        Dim MyFileStream As FileStream = New FileStream(filePath, FileMode.Open, FileAccess.Read)
        Dim MyBinaryReader As BinaryReader = New BinaryReader(MyFileStream)
        Dim FinalData() As Byte = MyBinaryReader.ReadBytes(MyFileStream.Length)
        MyBinaryReader.Close()
        MyFileStream.Close()
        Return FinalData
    End Function

    Function MakeBMPTransparent(ByVal InputImage As Image, ByVal InputColor As Color) As Image
        Dim Returnable As Bitmap = InputImage
        Returnable.MakeTransparent(InputColor)
        Return Returnable
        Returnable.Dispose()
    End Function

    Sub SilentMoveFile(ByVal FromPath As String, ByVal ToPath As String)
        Dim BackupDate As Date = File.GetLastWriteTime(FromPath)
        File.Move(FromPath, ToPath)
        File.SetLastWriteTime(ToPath, BackupDate)
    End Sub

    Function StringToLines(ByVal InputString As String) As String()
        Return System.Text.RegularExpressions.Regex.Split(InputString, vbNewLine)
    End Function

    Function iGet(ByVal InputString As String, ByVal ReturnableItem As Byte, ByVal SeperatorChar As String) As String
        Try
            Dim TempArray() As String = InputString.Split(SeperatorChar)
            Return TempArray(ReturnableItem)
        Catch
            Return String.Empty
        End Try
    End Function

    Function IsWindowPositionFree(ByVal X As Int16, ByVal Y As Int16) As Boolean
        Dim Returnable As Boolean = True
        For Each D As Form In MainForm.MdiChildren
            If D.Location.X = X And D.Location.Y = Y Then Returnable = False
        Next
        Return Returnable
    End Function

    Sub ShowInternalForm(ByRef Instance As Form)
        Dim T As Int16 = 24
        While Not IsWindowPositionFree(T, T)
            T += 24
        End While
        With Instance
            .TopLevel = False
            .MdiParent = MainForm
            .Show()
            .BringToFront()
            .Location = New Point(T, T)
        End With
    End Sub

    Sub URL(ByVal URL As String)
        System.Diagnostics.Process.Start(URL)
    End Sub

    Sub RunBatchString(ByVal BatchString As String, ByVal WorkingDirectory As String, ByVal is7Zip As Boolean)
        'MsgError(WorkingDirectory + "\zip.exe")
        If is7Zip Then File.Copy(AppPath + "zip.exe", WorkingDirectory + "\zip.exe", True)
        File.WriteAllText(WorkingDirectory + "\TBatch.bat", BatchString)
        Dim MyProcess As New Process
        Dim MyStartInfo As New ProcessStartInfo(WorkingDirectory + "\TBatch.bat")
        With MyStartInfo
            .WorkingDirectory = WorkingDirectory
            .WindowStyle = ProcessWindowStyle.Hidden
        End With
        With MyProcess
            .StartInfo = MyStartInfo
            .Start()
            .WaitForExit()
            .Dispose()
        End With
        File.Delete(WorkingDirectory + "\TBatch.bat")
        Try
            If is7Zip Then File.Delete(WorkingDirectory + "zip.exe")
        Catch : End Try
    End Sub

    Public Function SaveFile(ByVal Directory As String, ByVal Filter As String, ByVal DefaultFileName As String) As String
        If Directory.Length = 0 Then Directory = SaveDefaultFolder
        Dim Returnable As String
        Dim SFD As New SaveFileDialog
        With SFD
            .InitialDirectory = Directory
            .FileName = DefaultFileName
            .Filter = Filter
            .Title = "Save File"
            If Not .ShowDialog() = Windows.Forms.DialogResult.OK Then Returnable = String.Empty Else Returnable = .FileName
            .Dispose()
        End With
        SaveDefaultFolder = Directory
        Return Returnable
    End Function

    Function GetOSVersion() As Byte
        Return Convert.ToByte(System.Environment.OSVersion.Version.ToString.Substring(0, 1))
    End Function

    Function ImageToIcon(ByVal img As Bitmap) As Icon
        Dim nimg As New Bitmap(16, 16)
        Dim g As Graphics = Graphics.FromImage(nimg)
        g.DrawImage(img, 0, 0, 16, 16)

        Return (Icon.FromHandle(nimg.GetHicon()))
    End Function

    Public Function Base64Encode(ByVal Input As String) As String
        Return Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(Input))
    End Function

    Public Function Base64Decode(ByVal Input As String) As String
        Return System.Text.Encoding.UTF8.GetString(Convert.FromBase64String(Input))
    End Function

    'Function StringToComparative(ByVal InputString As String) As String
    '    If InputString = "Less than" Then Return "<"
    '    If InputString = "Greater than" Then Return ">"
    '    If InputString = "Equal to" Then Return "=="
    '    If InputString = "Less than or Equal to" Then Return "<="
    '    If InputString = "Greater than or Equal to" Then Return ">="
    '    If InputString = "Not Equal to" Then Return "!="
    '    Return "=="
    'End Function

    'Function ComparativeToString(ByVal InputString As String) As String
    '    If InputString = "<" Then Return "Less than"
    '    If InputString = ">" Then Return "Greater than"
    '    If InputString = "==" Then Return "Equal to"
    '    If InputString = "<=" Then Return "Less than or Equal to"
    '    If InputString = ">=" Then Return "Greater than or Equal to"
    '    If InputString = "!=" Then Return "Not equal to"
    '    Return "Equal to"
    'End Function

    Dim RandomMaker As New System.Random(CType(System.DateTime.Now.Ticks Mod System.Int32.MaxValue, Integer))

    Function Random(ByVal Min As Int32, ByVal Max As Int32) As Int32
        Return RandomMaker.Next(Min, Max + 1)
    End Function

    Public Function GetInput(ByVal Descriptor As String, ByVal DefaultValue As String, ByVal VM As Byte) As String
        'Dim X As New FInputBox
        'X.Descriptor = Descriptor
        'X.TheInput = DefaultValue
        'X.Validation = VM
        'X.ShowDialog()
        'Dim ToGive As String = X.TheInput
        'X.Dispose()
        'Return ToGive
        With FInputBox
            .Descriptor = Descriptor
            .TheInput = DefaultValue
            .Validation = VM
            .ShowDialog()
            Return .TheInput
        End With
    End Function

End Module
