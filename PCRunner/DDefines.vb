Module DDefines

    'Split string constants - use asc(int)

    Public ParentSplitter As Byte = 30
    Public ChildSplitter As Byte = 31
    Public CP As String = Chr(ParentSplitter)
    Public CC As String = Chr(ChildSplitter)

    Public CommandSep As String = Chr(11)
    Public ArgSep As String = Chr(12)

    'Meta Data

    Public Version As Byte = 103 'Byte 1
    Public Pro As Boolean = False

    'Cached Data

    Public SizeChanged As Boolean = True

    'Variables

    Public CuS As UInt16 = 0
    Public CusA As Scene

    Public Score As UInt32 = 0
    Public Lives As UInt32 = 3
    Public Health As UInt32 = 100

    Public Frames As UInt64 = 0
    Public RoomFrames As UInt64 = 0
    Public Seconds As UInt64 = 0
    Public RoomSeconds As UInt64 = 0

    Public Pointer_X As UInt16 = 0
    Public Pointer_Y As UInt16 = 0
    Public Pointer_In As Boolean = False
    Public Pointer_Held As Boolean = False

    'Views (not scoped)
    Public View_VX As Int16 = 0
    Public View_VY As Int16 = 0

    'Dark Flow Logo Rendering

    Public DF_Logo_X As UInt16 = 5
    Public DF_Logo_Y As UInt16 = 5
    Public DF_Logo_Width As UInt16 = 320
    Public DF_Logo_Height As UInt16 = 85
    Public DF_Logo_Rect As Rectangle

    ''
    '' Image
    ''

    Class DImage
        Function CloneMe() As DImage
            Return New DImage(Name, Width, Height, FrameHeight, Data)
        End Function
        Public Name As String
        Public Width As Double
        Public Height As Double
        Public Data As Image
        Public FrameHeight As Int16
        Sub New(ByVal DName As String, ByVal DWidth As UInt16, ByVal DHeight As UInt16, ByVal DFrameHeight As UInt16, Optional ByVal DData As Bitmap = Nothing)
            Name = DName
            Width = DWidth
            Height = DHeight
            FrameHeight = DFrameHeight
            Data = DData
        End Sub
    End Class
    Public Images As New List(Of DImage)

    ''
    '' Object
    ''

    Public Class DObject
        Public Sub New(ByVal PName As String, ByVal PImageName As String, ByVal PEvents As List(Of DEvent), ByVal PDepth As Byte)
            Name = PName
            ImageName = PImageName
            Events = PEvents
            Depth = PDepth
        End Sub
        Function CloneMe() As DObject
            Return New DObject(Name, ImageName, Events, Depth)
        End Function
        Public Name As String
        Public ImageName As String
        Public Depth As Byte
        Public Events As List(Of DEvent)
    End Class
    Public Objects As New List(Of DObject)

    ''
    '' Event
    ''

    Class DEvent
        Public ObjectName As String
        Public EventType As String
        Public EventData As String
        Public Code As String
    End Class
    Public DEvents As New List(Of DEvent)

    ''
    '' Scene
    ''

    Public Class Scene
        Public Sub New(ByVal DName As String, ByVal DWidth As Int32, ByVal DHeight As Int32, ByVal DViewWidth As Int32, ByVal DViewHeight As Int32, ByVal DViewX As Int32, ByVal DViewY As Int32, ByVal DBGRed As Byte, ByVal DBGGreen As Byte, ByVal DBGBlue As Byte, ByVal DForeground As String, ByVal DBackground As String, ByVal DInstances As List(Of Instance))
            Name = DName
            Width = DWidth
            Height = DHeight
            ViewWidth = DViewWidth
            ViewHeight = DViewHeight
            ViewX = DViewX
            ViewY = DViewY
            BGRed = DBGRed
            BGGreen = DBGGreen
            BGBlue = DBGBlue
            Foreground = DForeground
            Background = DBackground
            Me.Instances = DInstances
        End Sub
        Function CloneMe() As Scene
            Dim iList As New List(Of Instance)
            If Instances.Count > 0 Then
                For P As UInt16 = 0 To Instances.Count - 1
                    iList.Add(Instances(P).CloneMe())
                Next
            End If
            Return New Scene(Name, Width, Height, ViewWidth, ViewHeight, ViewX, ViewY, BGRed, BGGreen, BGBlue, Foreground, Background, iList)
        End Function
        Public Name As String
        Public Width As UInt32
        Public Height As UInt32
        Public ViewWidth As UInt16
        Public ViewHeight As UInt16
        Public ViewX As Double
        Public ViewY As Double
        Public BGRed As Byte
        Public BGGreen As Byte
        Public BGBlue As Byte
        Public Foreground As String
        Public Background As String
        Public Instances As List(Of Instance)
    End Class
    Public Scenes As New List(Of Scene)

    ''
    '' Instance
    ''

    Public Class Instance
        Public InUse As Boolean
        Public ObjectName As String
        Public ImageName As String
        Public X As Double
        Public Y As Double
        Public StartX As Double
        Public StartY As Double
        Public Width As Double
        Public Height As Double
        Public T As Double
        Public TV As Double
        Public VX As Double
        Public VY As Double
        Public AX As Double
        Public AY As Double
        Public Depth As Byte
        Public IsMade As Boolean = False
        Public FrameSpeed As Double
        Public HasChanged As Boolean = True
        Public Frame As Int16
        Public Variables As New List(Of Variable)
        Sub New(ByVal DObjectName As String, ByVal DImageName As String, ByVal DX As Double, ByVal DY As Double, ByVal DStartX As Int16, ByVal DStartY As Int16, ByVal DWidth As UInt16, ByVal DHeight As UInt16, ByVal DVX As Double, ByVal DVY As Double, ByVal PAX As Double, ByVal PAY As Double, ByVal DFrame As UInt16, ByVal DFrameSpeed As Double, ByVal DVariables As List(Of Variable), ByVal DDepth As Byte, ByVal DT As Double, ByVal DTV As Double)
            InUse = True
            ObjectName = DObjectName
            ImageName = DImageName
            X = DX
            Y = DY
            Width = DWidth
            Height = DHeight
            VX = DVX
            VY = DVY
            AX = PAX
            AY = PAY
            T = DT
            TV = DTV
            StartX = DStartX
            StartY = DStartY
            Depth = DDepth
            Variables = DVariables
            Frame = DFrame
            FrameSpeed = DFrameSpeed
        End Sub
        Public ReadOnly Property V As Double
            Get
                Return Math.Sqrt(VX ^ 2 + VY ^ 2)
            End Get
        End Property
        Public ReadOnly Property VA As Double
            Get
                Dim theta As Double = 0

                If Not (VX = 0 And VY = 0) Then
                    theta = Math.Atan(VY / VX)
                End If
                If VX < 0 Then
                    theta += Math.PI
                End If
                Return (theta * 180) / Math.PI
            End Get
        End Property
        Public ReadOnly Property A As Double
            Get
                Return Math.Sqrt(AX ^ 2 + AY ^ 2)
            End Get
        End Property
        Public ReadOnly Property AA As Double
            Get
                Dim theta As Double = 0

                If Not (AX = 0 And AY = 0) Then
                    theta = Math.Atan(AY / AX)
                End If
                If AX < 0 Then
                    theta += Math.PI
                End If
                Return (theta * 180) / Math.PI
            End Get
        End Property
        Function CloneMe() As Instance
            Return New Instance(ObjectName, ImageName, X, Y, StartX, StartY, Width, Height, VX, VY, AX, AY, Frame, FrameSpeed, Variables, Depth, T, TV)
        End Function
    End Class

    ''
    '' Sound
    ''

    Public Class Sound
        Public Name As String
        Public Data() As Byte
        Sub New(ByVal DName As String, Optional ByVal FData() As Byte = Nothing)
            Name = DName
            Data = FData
        End Sub
    End Class
    Public Sounds As New List(Of Sound)

    ''
    '' Script
    ''

    Public Class Script
        Sub New(ByVal DName As String, ByVal DContents As String, ByVal DArgumentNames As List(Of String), ByVal DArgumentTypes As List(Of String))
            Name = DName
            Contents = DContents
            ArgumentNames = DArgumentNames
            ArgumentTypes = DArgumentTypes
        End Sub
        Function CloneMe() As Script
            Return New Script(Name, Contents, ArgumentNames, ArgumentTypes)
        End Function
        Public Name As String
        Public Contents As String
        Public ArgumentNames As List(Of String)
        Public ArgumentTypes As List(Of String)
        Function ContaintsArgument(ByVal ArgName As String) As Boolean
            Return ArgumentNames.Contains(ArgName)
        End Function
    End Class
    Public Scripts As New List(Of Script)

    ''
    '' Inputs
    ''

    Public Class Input
        Public Name As String
        Public Executors As New List(Of InputExecutor)
        Sub New(ByVal DName As String, ByVal DExecutors As List(Of InputExecutor))
            Name = DName
            Executors = DExecutors
        End Sub
    End Class
    Public Inputs As New List(Of Input)

    Class InputExecutor
        Public ConsoleName As String
        Public ConsoleInputIdentifier As String
        Sub New(ByVal DConsoleName As String, ByVal DConsoleInputIdentifier As String)
            ConsoleName = DConsoleName
            ConsoleInputIdentifier = DConsoleInputIdentifier
        End Sub
    End Class

    ''
    '' Variables
    ''

    Class Variable
        Public Name As String
        Public Value As String
    End Class
    Public GlobalVariables As New List(Of Variable)

    ''
    '' Texts
    ''

    Class DText
        Public X As Double
        Public Y As Double
        Public Data As String = String.Empty
        Public FontImg As String = String.Empty
    End Class
    Public DTexts As New List(Of DText)

End Module
