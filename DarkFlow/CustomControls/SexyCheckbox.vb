Public Class SexyCheckBox

    Inherits Panel
    Dim IState As Integer = 1
    Dim IBorderColor As Color = Color.White
    Dim Internaller As New CheckBox

    Property DText() As String
        Get
            Return Text
        End Get
        Set(ByVal Input As String)
            Text = Input
        End Set
    End Property

    Property Checked() As Boolean
        Get
            Return Internaller.Checked
        End Get
        Set(ByVal Input As Boolean)
            UpdateChecked(Input)
        End Set
    End Property

    Sub UpdateChecked(ByVal input As Boolean)
        Internaller.Checked = input
        Invalidate()
    End Sub

    Public Custom Event CheckedChanged As EventHandler
        AddHandler(ByVal value As EventHandler)
            AddHandler Internaller.CheckedChanged, value
        End AddHandler

        RemoveHandler(ByVal value As EventHandler)
            RemoveHandler Internaller.CheckedChanged, value
        End RemoveHandler

        RaiseEvent(ByVal sender As System.Object, ByVal e As System.EventArgs)

        End RaiseEvent
    End Event

    Public Sub New()
        DoubleBuffered = True
    End Sub

    Protected Overrides Sub OnMouseEnter(ByVal e As System.EventArgs)
        IState = 2
        Invalidate()
    End Sub

    Protected Overrides Sub OnMouseLeave(ByVal e As System.EventArgs)
        IState = 1
        Invalidate()
    End Sub

    Protected Overrides Sub OnMouseDown(ByVal mevent As System.Windows.Forms.MouseEventArgs)
        IState = 3
        Invalidate()
    End Sub

    Protected Overrides Sub OnMouseUp(ByVal e As System.Windows.Forms.MouseEventArgs)
        IState = 2
        Invalidate()
    End Sub

    Protected Overrides Sub OnMouseClick(ByVal e As System.Windows.Forms.MouseEventArgs)
        UpdateChecked(If(Internaller.Checked, False, True))
        Invalidate()
    End Sub

    Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)

        e.Graphics.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias
        e.Graphics.TextRenderingHint = Drawing.Text.TextRenderingHint.ClearTypeGridFit
        Dim TempRect As Rectangle = New Rectangle(0, 0, Height, Height)
        If TempRect.Width = 0 Then TempRect.Width = 18
        If TempRect.Height = 0 Then TempRect.Height = 18

        Dim BC As Color = Color.FromArgb(204, 204, 204)
        Dim DBC As Color = Color.FromArgb(40, 40, 40)
        Dim GradTop As Byte = 255
        Dim GradBottom As Byte = 200

        If IState = 1 Then
            DBC = Color.FromArgb(80, 80, 80)
        End If

        If IState = 2 Then
            GradTop = 230
            GradBottom = 190
        End If

        If IState = 3 Then
            GradTop = 190
            GradBottom = 230
            'BC = Color.FromArgb(156, 156, 156)
        End If

        Dim NB As Drawing2D.LinearGradientBrush = New Drawing2D.LinearGradientBrush(TempRect, Color.FromArgb(GradTop, GradTop, GradTop), Color.FromArgb(GradBottom, GradBottom, GradBottom), Drawing2D.LinearGradientMode.Vertical)
        e.Graphics.FillRectangle(NB, TempRect)

        'Gray Bit
        e.Graphics.DrawRectangle(New Pen(DBC), TempRect.Left + 1, TempRect.Top + 1, TempRect.Width - 3, TempRect.Height - 3)

        'White Surrounder
        e.Graphics.DrawRectangle(New Pen(BC), TempRect.Left, TempRect.Top, TempRect.Width - 1, TempRect.Height - 1)

        Dim TS As SizeF = e.Graphics.MeasureString(Text, Font)
        Dim R As New SolidBrush(If(Enabled, ForeColor, Color.FromArgb(128, 128, 128)))

        If Internaller.Checked Then e.Graphics.DrawImage(My.Resources.CCCheckMark, New Point((Height / 2) - (My.Resources.CCCheckMark.Width / 2), (Height / 2) - (My.Resources.CCCheckMark.Height / 2)))
        e.Graphics.DrawString(Text, Font, New SolidBrush(ForeColor), Height + 1, 0)

    End Sub

End Class