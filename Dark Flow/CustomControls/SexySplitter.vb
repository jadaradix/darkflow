Imports System.Drawing.Drawing2D

Public Class SexySplitter

    Inherits Splitter

    Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)
        e.Graphics.SmoothingMode = Drawing2D.SmoothingMode.None
        e.Graphics.InterpolationMode = Drawing2D.InterpolationMode.NearestNeighbor
        e.Graphics.Clear(Color.FromArgb(64, 64, 64))
        Dim TC As UInt16 = 224
        Dim BC As UInt16 = 48
        Dim TCC As Color = Color.FromArgb(TC, TC, TC)
        Dim BCC As Color = Color.FromArgb(BC, BC, BC)
        'Dim MC As UInt16 = (TC + BC) / 2
        Dim MC As UInt16 = 242
        'Dim MCC As Color = Color.FromArgb(MC, MC, MC)
        Dim MCC As Color = Color.FromArgb(128, 0, 0, 0)
        Dim MyGrad As New LinearGradientBrush(New Point(0, 0), New Point(0, Height), TCC, BCC)
        e.Graphics.FillRectangle(MyGrad, New Rectangle(0, 0, Width, Height))
        e.Graphics.DrawLine(New Pen(MCC, 1), New Point(0, 0), New Point(0, Height))
        e.Graphics.DrawLine(New Pen(MCC, 1), New Point(Width - 1, 0), New Point(Width - 1, Height))
        MyBase.OnPaint(e)
    End Sub

    Protected Overrides Sub OnMove(ByVal e As System.EventArgs)
        Invalidate()
        MyBase.OnMove(e)
    End Sub

    Sub New()
        Width = 5
    End Sub

End Class
