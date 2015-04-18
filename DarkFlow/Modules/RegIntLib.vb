Imports Microsoft.Win32
Imports System.Runtime.InteropServices

Module RegIntLib

    Public Sub SetFileType(ByVal extension As String, ByVal FileType As String)
        Dim ext As RegistryKey = Registry.ClassesRoot.CreateSubKey(extension, RegistryKeyPermissionCheck.ReadWriteSubTree)
        ext.SetValue("", FileType)
    End Sub

    Public Sub SetFileDescription(ByVal FileType As String, ByVal Description As String)
        Dim ext As RegistryKey = Registry.ClassesRoot.CreateSubKey(FileType, RegistryKeyPermissionCheck.ReadWriteSubTree)
        ext.SetValue("", Description)
    End Sub

    Public Sub SetDefaultIcon(ByVal FileType As String, ByVal Icon As String)
        Dim ext As RegistryKey = Registry.ClassesRoot.OpenSubKey(FileType, True)
        ext.SetValue("DefaultIcon", Icon)
    End Sub

    Public Sub AddAction(ByVal FileType As String, ByVal Verb As String, ByVal ActionDescription As String)
        Dim ext As RegistryKey = Registry.ClassesRoot.OpenSubKey(FileType, True).CreateSubKey("Shell").CreateSubKey(Verb)
        ext.SetValue("", ActionDescription)
    End Sub

    Public Sub SetExtensionCommandLine(ByVal Command As String, ByVal FileType As String, ByVal CommandLine As String, Optional ByVal Name As String = "")
        Dim rk As RegistryKey = Registry.ClassesRoot
        Dim ext As RegistryKey = rk.OpenSubKey(FileType, True).OpenSubKey("Shell", True).OpenSubKey(Command, True).CreateSubKey("Command", RegistryKeyPermissionCheck.ReadWriteSubTree)
        ext.SetValue(Name, CommandLine)
    End Sub

    <DllImport("WININET", CharSet:=CharSet.Auto)> _
Private Function InternetGetConnectedState(ByRef lpdwFlags As InternetConnectionState, ByVal dwReserved As Integer) As Boolean
    End Function

    <Flags()> _
    Public Enum InternetConnectionState As Integer
        INTERNET_CONNECTION_MODEM = &H1
        INTERNET_CONNECTION_LAN = &H2
        INTERNET_CONNECTION_PROXY = &H4
        INTERNET_RAS_INSTALLED = &H10
        INTERNET_CONNECTION_OFFLINE = &H20
        INTERNET_CONNECTION_CONFIGURED = &H40
    End Enum

End Module
