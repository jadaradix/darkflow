Public Class SexyComboBox

    Dim IState As Integer = 1
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
    Property Image() As Image
        Get
            Return BackCombo.RImage
        End Get
        Set(ByVal Input As Image)
            Dim nimg As New Bitmap(16, 16)
            Dim g As Graphics = Graphics.FromImage(nimg)
            g.DrawImage(Input, 0, 0, 16, 16)
            BackCombo.RImage = nimg
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

    Overrides Property Text() As String
        Get
            Return BackCombo.Text
        End Get
        Set(ByVal Input As String)
            BackCombo.Text = Input
        End Set
    End Property

    Public Custom Event SelectedIndexChanged As EventHandler
        AddHandler(ByVal value As EventHandler)
            AddHandler BackCombo.SelectedIndexChanged, value
        End AddHandler
        RemoveHandler(ByVal value As EventHandler)
            RemoveHandler BackCombo.SelectedIndexChanged, value
        End RemoveHandler
        RaiseEvent(ByVal sender As System.Object, ByVal e As System.EventArgs)
        End RaiseEvent
    End Event

    Public Custom Event DTextChanged As EventHandler
        AddHandler(ByVal value As EventHandler)
            AddHandler BackCombo.TextChanged, value
        End AddHandler
        RemoveHandler(ByVal value As EventHandler)
            RemoveHandler BackCombo.TextChanged, value
        End RemoveHandler
        RaiseEvent(ByVal sender As System.Object, ByVal e As System.EventArgs)
        End RaiseEvent
    End Event

    Sub New()
        IBorderColor = Color.FromArgb(128, 128, 128)
        IShadowColor = Color.FromArgb(72, 72, 72)
        BackColor = Color.Transparent
        InitializeComponent()
        CommonCrap()
    End Sub

    Sub CommonCrap()
        BackCombo.Width = Width
        BackCombo.Height = Height - 6
        FrontSkin.Size = Size
        FrontSkin.Location = New Point(0, 0)
        BackCombo.SendToBack()
        Invalidate()
    End Sub

    Protected Overrides Sub OnResize(ByVal e As System.EventArgs)
        CommonCrap()
    End Sub

    Private Sub SexyTextBox_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CommonCrap()
    End Sub

    Public Sub FrontSkin_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles FrontSkin.Click
        BackCombo.DroppedDown = True
    End Sub

    Public Sub FrontSkin_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles FrontSkin.MouseDown
        IState = 3
        FrontSkin.Invalidate()
    End Sub

    Private Sub FrontSkin_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles FrontSkin.MouseEnter
        IState = 2
        FrontSkin.Invalidate()
    End Sub

    Private Sub FrontSkin_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles FrontSkin.MouseLeave
        IState = 1
        FrontSkin.Invalidate()
    End Sub

    Private Sub FrontSkin_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles FrontSkin.MouseUp
        IState = 2
        FrontSkin.Invalidate()
    End Sub

    Private Sub FrontSkin_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles FrontSkin.Paint
        e.Graphics.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias
        e.Graphics.TextRenderingHint = Drawing.Text.TextRenderingHint.ClearTypeGridFit
        Dim S As New Rectangle(0, 1, Width - 1, Height - 1)
        e.Graphics.DrawPath(New Pen(ShadowColor, 1), CreateAllRoundedRect(S, 6))
        Dim P As New Rectangle(0, 0, Width - 1, Height - 1)
        e.Graphics.FillPath(New SolidBrush(If(Enabled, Color.White, Color.FromKnownColor(KnownColor.Control))), CreateAllRoundedRect(P, 6))
        e.Graphics.DrawPath(New Pen(IBorderColor, 1), CreateAllRoundedRect(P, 6))
        If Not BackCombo.SelectedIndex = -1 Then
            Dim Q As Int16 = (BackCombo.ItemHeight - BackCombo.RImage.Height) / 2
            e.Graphics.DrawImage(BackCombo.RImage, Q + 4, Q + 3)
            e.Graphics.DrawString(BackCombo.Items(BackCombo.SelectedIndex), Font, Brushes.Black, Q + 6 + BackCombo.RImage.Width, 3)
        End If

        Dim rect As Rectangle = New Rectangle(Width - Height + 3, 3, Height - 5, Height - 7)
        If rect.Height = 0 Then rect.Height = 1
        e.Graphics.FillRectangle(New SolidBrush(If(Enabled, Color.White, Color.FromKnownColor(KnownColor.Control))), New RectangleF(Width - Height, 2, Height - 1.5, Height - 4))
        e.Graphics.DrawImage(My.Resources.CCDropperArrow, New Point(Width - Height + 5, 5))
    End Sub

    Private Sub BackCombo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BackCombo.SelectedIndexChanged
        FrontSkin.Invalidate()
    End Sub

    Private Sub BackCombo_DropDown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BackCombo.DropDown
        FrontSkin_MouseUp(Me, New MouseEventArgs(Windows.Forms.MouseButtons.Left, 1, 0, 0, 1))
    End Sub

End Class
