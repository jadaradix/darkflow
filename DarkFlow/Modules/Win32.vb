Imports System.Drawing
Imports System.Windows.Forms
Imports System.Runtime.InteropServices

    Friend Class Win32
        '
        '		 * GetWindow() Constants
        '		 

        Public Const GW_HWNDFIRST As Integer = 0
        Public Const GW_HWNDLAST As Integer = 1
        Public Const GW_HWNDNEXT As Integer = 2
        Public Const GW_HWNDPREV As Integer = 3
        Public Const GW_OWNER As Integer = 4
        Public Const GW_CHILD As Integer = 5

        Public Const WM_NCCALCSIZE As Integer = &H83
        Public Const WM_WINDOWPOSCHANGING As Integer = &H46
        Public Const WM_PAINT As Integer = &HF
        Public Const WM_CREATE As Integer = &H1
        Public Const WM_NCCREATE As Integer = &H81
        Public Const WM_NCPAINT As Integer = &H85
        Public Const WM_PRINT As Integer = &H317
        Public Const WM_DESTROY As Integer = &H2
        Public Const WM_SHOWWINDOW As Integer = &H18
        Public Const WM_SHARED_MENU As Integer = &H1E2
        Public Const HC_ACTION As Integer = 0
        Public Const WH_CALLWNDPROC As Integer = 4
        Public Const GWL_WNDPROC As Integer = -4

        '
        ' TODO: Add constructor logic here
        '
        Public Sub New()
        End Sub

        <DllImport("User32.dll", CharSet:=CharSet.Auto)> _
        Public Shared Function GetWindowDC(ByVal handle As IntPtr) As IntPtr
        End Function

        <DllImport("User32.dll", CharSet:=CharSet.Auto)> _
        Public Shared Function ReleaseDC(ByVal handle As IntPtr, ByVal hDC As IntPtr) As IntPtr
        End Function

        <DllImport("Gdi32.dll", CharSet:=CharSet.Auto)> _
        Public Shared Function CreateCompatibleDC(ByVal hdc As IntPtr) As IntPtr
        End Function

        <DllImport("User32.dll", CharSet:=CharSet.Auto)> _
        Public Shared Function GetClassName(ByVal hwnd As IntPtr, ByVal className As Char(), ByVal maxCount As Integer) As Integer
        End Function

        <DllImport("User32.dll", CharSet:=CharSet.Auto)> _
        Public Shared Function GetWindow(ByVal hwnd As IntPtr, ByVal uCmd As Integer) As IntPtr
        End Function

        <DllImport("User32.dll", CharSet:=CharSet.Auto)> _
        Public Shared Function IsWindowVisible(ByVal hwnd As IntPtr) As Boolean
        End Function

        <DllImport("user32", CharSet:=CharSet.Auto)> _
        Public Shared Function GetClientRect(ByVal hwnd As IntPtr, ByRef lpRect As RECT) As Integer
        End Function

        <DllImport("user32", CharSet:=CharSet.Auto)> _
        Public Shared Function GetClientRect(ByVal hwnd As IntPtr, <[In](), Out()> ByRef rect As Rectangle) As Integer
        End Function

        <DllImport("user32", CharSet:=CharSet.Auto)> _
        Public Shared Function MoveWindow(ByVal hwnd As IntPtr, ByVal X As Integer, ByVal Y As Integer, ByVal nWidth As Integer, ByVal nHeight As Integer, ByVal bRepaint As Boolean) As Boolean
        End Function

        <DllImport("user32", CharSet:=CharSet.Auto)> _
        Public Shared Function UpdateWindow(ByVal hwnd As IntPtr) As Boolean
        End Function

        <DllImport("user32", CharSet:=CharSet.Auto)> _
        Public Shared Function InvalidateRect(ByVal hwnd As IntPtr, ByRef rect As Rectangle, ByVal bErase As Boolean) As Boolean
        End Function

        <DllImport("user32", CharSet:=CharSet.Auto)> _
        Public Shared Function ValidateRect(ByVal hwnd As IntPtr, ByRef rect As Rectangle) As Boolean
        End Function

        <DllImport("user32.dll", CharSet:=CharSet.Auto)> _
        Friend Shared Function GetWindowRect(ByVal hWnd As IntPtr, <[In](), Out()> ByRef rect As Rectangle) As Boolean
        End Function

        <StructLayout(LayoutKind.Sequential)> _
        Public Structure RECT
            Public Left As Integer
            Public Top As Integer
            Public Right As Integer
            Public Bottom As Integer
        End Structure

        <StructLayout(LayoutKind.Sequential)> _
        Public Structure WINDOWPOS
            Public hwnd As IntPtr
            Public hwndAfter As IntPtr
            Public x As Integer
            Public y As Integer
            Public cx As Integer
            Public cy As Integer
            Public flags As UInteger
        End Structure

        <StructLayout(LayoutKind.Sequential)> _
        Public Structure NCCALCSIZE_PARAMS
            Public rgc As RECT
            Public wndpos As WINDOWPOS
        End Structure
    End Class

#Region "SubClass Classing Handler Class"
    Friend Class SubClass
        Inherits System.Windows.Forms.NativeWindow
        Public Delegate Function SubClassWndProcEventHandler(ByRef m As System.Windows.Forms.Message) As Integer
    'Public Event SubClassedWndProc As SubClassWndProcEventHandler
        Private IsSubClassed As Boolean = False

        Public Sub New(ByVal Handle As IntPtr, ByVal _SubClass As Boolean)
            MyBase.AssignHandle(Handle)
            Me.IsSubClassed = _SubClass
        End Sub

        Public Property SubClassed() As Boolean
            Get
                Return Me.IsSubClassed
            End Get
            Set(ByVal value As Boolean)
                Me.IsSubClassed = value
            End Set
        End Property

        Public Sub CallDefaultWndProc(ByRef m As Message)
            MyBase.WndProc(m)
        End Sub

#Region "HiWord Message Cracker"
        Public Function HiWord(ByVal Number As Integer) As Integer
            Return ((Number >> 16) And &HFFFF)
        End Function
#End Region

#Region "LoWord Message Cracker"
        Public Function LoWord(ByVal Number As Integer) As Integer
            Return (Number And &HFFFF)
        End Function
#End Region

#Region "MakeLong Message Cracker"
        Public Function MakeLong(ByVal LoWord As Integer, ByVal HiWord As Integer) As Integer
            Return (HiWord << 16) Or (LoWord And &HFFFF)
        End Function
#End Region

#Region "MakeLParam Message Cracker"
        Public Function MakeLParam(ByVal LoWord As Integer, ByVal HiWord As Integer) As IntPtr
            Return CType((HiWord << 16) Or (LoWord And &HFFFF), IntPtr)
        End Function
#End Region

    End Class
#End Region