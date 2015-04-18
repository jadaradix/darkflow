Public Class SexyTextBox

    Public IBorderColor As Color
    Public IShadowColor As Color

    Property BorderColor() As Color
        Get
            Return IBorderColor
        End Get
        Set(ByVal Input As Color)
            IBorderColor = Input
        End Set
    End Property

    Property ShadowColor() As Color
        Get
            Return IShadowColor
        End Get
        Set(ByVal Input As Color)
            IShadowColor = Input
        End Set
    End Property

    Property UseSystemPasswordChar() As Boolean
        Get
            Return TextContainer.UseSystemPasswordChar
        End Get
        Set(ByVal Input As Boolean)
            TextContainer.UseSystemPasswordChar = Input
        End Set
    End Property

    Property MultiLine() As Boolean
        Get
            Return TextContainer.Multiline
        End Get
        Set(ByVal Input As Boolean)
            TextContainer.Multiline = Input
        End Set
    End Property

    Public Custom Event DKeyPress As KeyPressEventHandler
        AddHandler(ByVal Input As KeyPressEventHandler)
            AddHandler TextContainer.KeyPress, Input
        End AddHandler
        RemoveHandler(ByVal Input As KeyPressEventHandler)
            RemoveHandler TextContainer.KeyPress, Input
        End RemoveHandler
        RaiseEvent(ByVal sender As System.Object, ByVal e As KeyPressEventArgs)
        End RaiseEvent
    End Event

    Sub New()
        IBorderColor = Color.FromArgb(128, 128, 128)
        IShadowColor = Color.FromArgb(72, 72, 72)
        BackColor = Color.Transparent
        DoubleBuffered = True
        SetStyle(ControlStyles.AllPaintingInWmPaint Or ControlStyles.DoubleBuffer Or ControlStyles.ResizeRedraw Or ControlStyles.UserPaint, True)
        UpdateStyles()
        InitializeComponent()
        MultiLine = False
    End Sub

    Public Custom Event DTextChanged As EventHandler
        AddHandler(ByVal value As EventHandler)
            AddHandler TextContainer.TextChanged, value
        End AddHandler
        RemoveHandler(ByVal value As EventHandler)
            RemoveHandler TextContainer.TextChanged, value
        End RemoveHandler
        RaiseEvent(ByVal sender As System.Object, ByVal e As System.EventArgs)
        End RaiseEvent
    End Event

    Public Overrides Property Text() As String
        Get
            Return TextContainer.Text
        End Get
        Set(ByVal Input As String)
            TextContainer.Text = Input
        End Set
    End Property

    Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)
        e.Graphics.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias
        Dim S As New Rectangle(0, 1, Width - 1, Height - 1)
        e.Graphics.DrawPath(New Pen(ShadowColor, 1), CreateAllRoundedRect(S, MasterRadius))
        Dim P As New Rectangle(0, 0, Width - 1, Height - 1)
        e.Graphics.FillPath(New SolidBrush(If(Enabled, TextContainer.BackColor, Color.FromKnownColor(KnownColor.Control))), CreateAllRoundedRect(P, MasterRadius))
        e.Graphics.DrawPath(New Pen(IBorderColor, 1), CreateAllRoundedRect(P, MasterRadius))
    End Sub

    Sub CommonCrap()
        TextContainer.Location = New Point(5, 4)
        TextContainer.Size = New Size(Me.Width - 10, Me.Height - 8)
    End Sub

    Private Sub SexyTextBox_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CommonCrap()
    End Sub

    Private Sub SexyTextBox_Resize(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Resize
        CommonCrap()
    End Sub

    Private Sub TextContainer_Click(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles TextContainer.Paint
        e.Graphics.TextRenderingHint = Drawing.Text.TextRenderingHint.ClearTypeGridFit
    End Sub

End Class
