Imports System.Drawing.Drawing2D

Public Class SexyGroupBox

    Inherits GroupBox

    Public IBorderColor As Color

    Property BorderColor() As Color
        Get
            Return IBorderColor
        End Get
        Set(ByVal Input As Color)
            IBorderColor = Input
        End Set
    End Property

    Public Sub New()
        'Custom properties
        IBorderColor = Color.FromArgb(128, 128, 128)
        'Windows level display
        DoubleBuffered = True
        SetStyle(ControlStyles.AllPaintingInWmPaint Or ControlStyles.DoubleBuffer Or ControlStyles.ResizeRedraw Or ControlStyles.UserPaint, True)
        UpdateStyles()
    End Sub

    Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)
        e.Graphics.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias
        e.Graphics.TextRenderingHint = Drawing.Text.TextRenderingHint.ClearTypeGridFit
        Dim W As Int16 = e.Graphics.MeasureString(Me.Text, Me.Font).Width
        Dim x As New Drawing2D.LinearGradientBrush(New Rectangle(10, 0, 4 + W, 18), Color.Transparent, Color.White, LinearGradientMode.Vertical)
        e.Graphics.FillRectangle(x, New Rectangle(10, 0, 4 + W, 18))
        e.Graphics.DrawPath(New Pen(IBorderColor, 1), CreateGap(New Rectangle(2, 2, Me.Width - 4, Me.Height - 4), 10, Me.Text, Me.Font))
        e.Graphics.DrawString(Me.Text, Me.Font, New SolidBrush(Me.ForeColor), 14, 0)
    End Sub
End Class