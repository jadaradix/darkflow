Imports System.Drawing.Drawing2D
Imports System.ComponentModel

<DefaultEvent("Click")> Public Class SexyButton

    Inherits Panel

    Dim ILeftAligned As Boolean
    Dim IState As Integer
    Dim IXImage As Image
    Dim IImageOnTop As Boolean = False
    Dim ITextImageSpacing As Byte = 0
    Dim IShrinkMyIcon As Boolean = False

    Public Sub New()
        ILeftAligned = False
        DoubleBuffered = True
        BackColor = Color.Transparent
        ForeColor = Color.Black
        IState = 1
        SetStyle(ControlStyles.AllPaintingInWmPaint Or ControlStyles.DoubleBuffer Or ControlStyles.ResizeRedraw Or ControlStyles.UserPaint, True)
        UpdateStyles()
        TabStop = True
        IImageOnTop = False
    End Sub

    Property DText() As String
        Get
            Return Text
        End Get
        Set(ByVal Input As String)
            Text = Input
            Refresh()
        End Set
    End Property

    Property ImageOnTop() As Boolean
        Get
            Return IImageOnTop
        End Get
        Set(ByVal Input As Boolean)
            IImageOnTop = Input
        End Set
    End Property

    Property LeftAligned() As Boolean
        Get
            Return ILeftAligned
        End Get
        Set(ByVal Input As Boolean)
            ILeftAligned = Input
        End Set
    End Property

    Property XIMage() As Image
        Get
            Return IXImage
        End Get
        Set(ByVal Input As Image)
            IXImage = Input
        End Set
    End Property

    Property TextImageSpacing() As Byte
        Get
            Return ITextImageSpacing
        End Get
        Set(ByVal Input As Byte)
            ITextImageSpacing = Input
        End Set
    End Property

    Property ShrinkMyIcon() As Boolean
        Get
            Return IShrinkMyIcon
        End Get
        Set(ByVal Input As Boolean)
            IShrinkMyIcon = Input
        End Set
    End Property

    Protected Overrides Sub OnEnabledChanged(ByVal e As System.EventArgs)
        Invalidate()
        MyBase.OnEnabledChanged(e)
    End Sub

    Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)

        e.Graphics.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias
        e.Graphics.TextRenderingHint = Drawing.Text.TextRenderingHint.ClearTypeGridFit
        Dim TempRect As Rectangle = New Rectangle(0, 0, Width, Height)
        If TempRect.Width = 0 Then TempRect.Width = 20
        If TempRect.Height = 0 Then TempRect.Height = 20

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

        Dim ToDraw As Bitmap

        If IShrinkMyIcon Then
            ToDraw = New Bitmap(16, 16)
            Dim NGFX As Graphics = Graphics.FromImage(ToDraw)
            With NGFX
                .DrawImage(IXImage, New Rectangle(0, 0, 16, 16))
                .Dispose()
            End With
        Else
            ToDraw = IXImage
        End If

        If IImageOnTop Then
            If XIMage Is Nothing Then
                e.Graphics.DrawString(Text, Font, R, (Width / 2) - (TS.Width / 2), (Height / 2) - (TS.Height / 2))
            Else
                Dim ImS As Size = IXImage.Size
                e.Graphics.DrawImage(ToDraw, New Point((Width / 2) - (ImS.Width / 2), (Height / 2) - (ImS.Height / 2) - (TS.Height / 2)))
                e.Graphics.DrawString(Text, Font, R, (Width / 2) - (TS.Width / 2), (Height / 2) - (TS.Height / 2) + (ImS.Height / 2))
            End If
        Else
            If XIMage Is Nothing Then
                If Not ILeftAligned Then
                    e.Graphics.DrawString(Text, Font, R, (Width / 2) - (TS.Width / 2), (Height / 2) - (TS.Height / 2))
                Else
                    e.Graphics.DrawString(Text, Font, R, 8, (Height / 2) - (TS.Height / 2))
                End If
            Else
                Dim ImS As Size = ToDraw.Size
                If Not ILeftAligned Then
                    e.Graphics.DrawImage(ToDraw, New Point((Width / 2) - (ImS.Width / 2) - (TS.Width / 2) - 4, (Height / 2) - (ImS.Height / 2)))
                    e.Graphics.DrawString(Text, Font, R, (Width / 2) - (TS.Width / 2) + (ImS.Width / 2) + 4, (Height / 2) - (TS.Height / 2))
                Else
                    e.Graphics.DrawImage(ToDraw, New Point(8, (Height / 2) - (ImS.Height / 2)))
                    e.Graphics.DrawString(Text, Font, R, (ImS.Width / 2) + 20 + ITextImageSpacing, (Height / 2) - (TS.Height / 2))
                End If
            End If
        End If
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

    Private Sub InitializeComponent()
        SuspendLayout()
        Name = "SexyButton"
        ResumeLayout(False)
    End Sub

End Class