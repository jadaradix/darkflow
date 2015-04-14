Public Class SexyGDILabel

    Inherits Panel

    Dim IText As String

    Property DText As String
        Get
            Return IText
        End Get
        Set(ByVal Input As String)
            IText = Input
        End Set
    End Property

    Sub New()
        DoubleBuffered = True
        SetStyle(ControlStyles.AllPaintingInWmPaint Or ControlStyles.DoubleBuffer Or ControlStyles.ResizeRedraw Or ControlStyles.UserPaint, True)
        UpdateStyles()
    End Sub

    Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)
        e.Graphics.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias
        e.Graphics.TextRenderingHint = Drawing.Text.TextRenderingHint.ClearTypeGridFit
        e.Graphics.DrawString(IText, Font, New SolidBrush(ForeColor), New Point(0, 0))
    End Sub

End Class
