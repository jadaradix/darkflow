Public Class DoubleBufferPanel

    Inherits Panel

    Sub DrawingWork()
        DoubleBuffered = True
        SetStyle(ControlStyles.AllPaintingInWmPaint Or ControlStyles.DoubleBuffer Or ControlStyles.ResizeRedraw Or ControlStyles.UserPaint, True)
        SetStyle(ControlStyles.OptimizedDoubleBuffer, True)
        UpdateStyles()
    End Sub

    Public Sub New()
        DrawingWork()
    End Sub

    Sub FixMe()
        DrawingWork()
    End Sub

End Class