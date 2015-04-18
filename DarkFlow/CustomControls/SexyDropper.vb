Imports System.Drawing.Drawing2D
Public Class SexyDropper

    Inherits ComboBox

    Public IRImage As Image
    Public IFromColor As Color
    Public IToColor As Color
    Public IHighlightSelected As Boolean

    Property RImage() As Image
        Get
            Return IRImage
        End Get
        Set(ByVal Input As Image)
            IRImage = Input
        End Set
    End Property

    Property FromColor() As Color
        Get
            Return IFromColor
        End Get
        Set(ByVal Input As Color)
            IFromColor = Input
        End Set
    End Property

    Property ToColor() As Color
        Get
            Return IToColor
        End Get
        Set(ByVal Input As Color)
            IToColor = Input
        End Set
    End Property

    Property HighlightSelected() As Boolean
        Get
            Return IHighlightSelected
        End Get
        Set(ByVal Input As Boolean)
            IHighlightSelected = Input
        End Set
    End Property

    Public Sub New()
        'Custom properties
        FromColor = Color.FromArgb(224, 224, 224)
        ToColor = Color.Silver
        IRImage = New Bitmap(16, 16)
        'Windows Forms properties
        ItemHeight = 18
        Height = 18
        DrawMode = DrawMode.OwnerDrawFixed
        DropDownStyle = ComboBoxStyle.DropDownList
        DropDownWidth = Width
        'Windows level display
        DoubleBuffered = True
        SetStyle(ControlStyles.AllPaintingInWmPaint Or ControlStyles.DoubleBuffer Or ControlStyles.ResizeRedraw Or ControlStyles.UserPaint, True)
        UpdateStyles()
    End Sub

    Protected Overrides Sub OnDrawItem(ByVal e As System.Windows.Forms.DrawItemEventArgs)
        If e.Index < 0 Then Exit Sub
        Dim IsSelected As Boolean = ((e.State And DrawItemState.Selected) = DrawItemState.Selected)
        e.Graphics.FillRectangle(Brushes.White, e.Bounds)
        If IsSelected Then
            Dim EB As Int16 = 0
            Try
                EB = e.Bounds.Y
            Catch : End Try
            If EB = 3 Then
                If HighlightSelected Then e.Graphics.FillRectangle(New LinearGradientBrush(New Point(0, -3), New Point(0, ItemHeight + 3), IFromColor, IToColor), 0, e.Bounds.Y, e.Bounds.Width + 3, ItemHeight)
            Else
                e.Graphics.FillRectangle(New LinearGradientBrush(New Point(0, 0), New Point(0, ItemHeight), IFromColor, IToColor), 0, e.Bounds.Y, e.Bounds.Width, ItemHeight)
            End If
        End If
        Dim S As Int16 = (e.Bounds.Height - RImage.Height) / 2
        e.Graphics.TextRenderingHint = Drawing.Text.TextRenderingHint.ClearTypeGridFit
        Dim P As New SolidBrush(If(IsSelected, Color.Black, ForeColor))
        If RImage IsNot Nothing Then
            e.Graphics.DrawImage(RImage, e.Bounds.X + S, e.Bounds.Y + S)
            e.Graphics.DrawString(Items(e.Index), Font, P, e.Bounds.X + S + RImage.Width, e.Bounds.Y)
        Else
            e.Graphics.DrawString(Items(e.Index), Font, P, e.Bounds.X + S, e.Bounds.Y)
        End If
        MyBase.OnDrawItem(e)
    End Sub

    Protected Overrides Sub OnValueMemberChanged(ByVal e As System.EventArgs)
        MyBase.OnValueMemberChanged(e)
    End Sub

    Private Sub InitializeComponent()
        SuspendLayout()
        ResumeLayout(False)
    End Sub

End Class