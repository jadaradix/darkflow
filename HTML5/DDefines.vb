Imports System.Drawing

Public Module DDefines

    Public Pro As Boolean = False

    Public LoadingWidth As UInt16 = 256
    Public LoadingHeight As UInt16 = 192
    Public LoadingPadding As UInt16 = 8

    ''
    '' Image
    ''

    Class DImage
        Function CloneMe() As DImage
            Return New DImage(Name, Width, Height, FrameHeight)
        End Function
        Public Name As String
        Public Width As Int16
        Public Height As Int16
        Public FrameHeight As Int16
        Sub New(ByVal DName As String, ByVal DWidth As UInt16, ByVal DHeight As UInt16, ByVal DFrameHeight As UInt16)
            Name = DName
            Width = DWidth
            Height = DHeight
            FrameHeight = DFrameHeight
        End Sub
    End Class

    Class Sound
        Public Name As String
        Sub New(ByVal DName As String)
            Name = DName
        End Sub
    End Class

    ''
    '' Object
    ''

    Public Class DObject
        Public Sub New(ByVal PName As String, ByVal PImageName As String, ByVal PDepth As Byte)
            Name = PName
            ImageName = PImageName
            Depth = PDepth
        End Sub
        Function CloneMe() As DObject
            Return New DObject(Name, ImageName, Depth)
        End Function
        Public Name As String
        Public ImageName As String
        Public Depth As Byte
    End Class

    ''
    '' Scene
    ''

    Public Class Scene
        Public Name As String
        Public Width As Int32
        Public Height As Int32
        Public ViewWidth As Int16
        Public ViewHeight As Int16
        Public ViewX As Int32
        Public ViewY As Int32
        Public BGRed As Byte
        Public BGGreen As Byte
        Public BGBlue As Byte
        Public Foreground As String
        Public Background As String
        Public Instances As List(Of Instance)
        Sub New()
            Instances = New List(Of Instance)
        End Sub
    End Class

    ''
    '' Instance
    ''

    Public Class Instance
        Public ObjectName As String
        Public X As Int16
        Public Y As Int16
    End Class

    ''
    '' Event
    ''

    Class DEvent
        Public ObjectName As String
        Public EventType As String
        Public EventData As String
    End Class

    ''
    '' Inputs!
    ''

    Public Class Input
        Public Name As String
        Public Executors As New List(Of InputExecutor)
        Sub New(ByVal DName As String, ByVal DExecutors As List(Of InputExecutor))
            Name = DName
            Executors = DExecutors
        End Sub
    End Class

    Class InputExecutor
        Public PlatformName As String
        Public PlatformInputIdentifier As String
        Sub New(ByVal DConsoleName As String, ByVal DConsoleInputIdentifier As String)
            PlatformName = DConsoleName
            PlatformInputIdentifier = DConsoleInputIdentifier
        End Sub
    End Class


End Module
