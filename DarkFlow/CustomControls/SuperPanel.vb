Imports System.Drawing.Drawing2D

Public Class SuperPanel

    Inherits Panel

    Dim IBorderColor As Color
    Dim IGradTopColor As Color
    Dim IGradBottomColor As Color
    Dim IBorderRadius As Byte

    Property BorderColor() As Color
        Get
            Return IBorderColor
        End Get
        Set(ByVal Input As Color)
            IBorderColor = Input
        End Set
    End Property

    Property GradTopColor() As Color
        Get
            Return IGradTopColor
        End Get
        Set(ByVal Input As Color)
            IGradTopColor = Input
        End Set
    End Property

    Property GradBottomColor() As Color
        Get
            Return IGradBottomColor
        End Get
        Set(ByVal Input As Color)
            IGradBottomColor = Input
        End Set
    End Property

    Property BorderRadius() As Byte
        Get
            Return IBorderRadius
        End Get
        Set(ByVal Input As Byte)
            IBorderRadius = Input
        End Set
    End Property

    Public Sub New()
        Me.DoubleBuffered = True
        Me.IBorderColor = Color.FromArgb(48, 48, 48)
        Me.IGradTopColor = Color.FromArgb(210, 210, 210)
        Me.IGradBottomColor = Color.FromArgb(184, 184, 184)
        Me.IBorderRadius = 6
        SetStyle(ControlStyles.AllPaintingInWmPaint Or ControlStyles.DoubleBuffer Or ControlStyles.ResizeRedraw Or ControlStyles.UserPaint, True)
        UpdateStyles()
    End Sub

    Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)
        e.Graphics.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias
        Dim DPath As GraphicsPath = CreateAllRoundedRect(New Rectangle(0, 0, Me.Width - 1, Me.Height - 1), IBorderRadius)
        e.Graphics.FillPath(New LinearGradientBrush(New Point(0, 0), New Point(0, Me.Height - 1), IGradTopColor, IGradBottomColor), DPath)
        e.Graphics.DrawPath(New Pen(IBorderColor), DPath)
    End Sub

End Class