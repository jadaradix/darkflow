Public Class metroMenuRenderer
    Inherits System.Windows.Forms.ToolStripRenderer

    '// Make sure the textcolor is black
    Protected Overrides Sub InitializeItem(ByVal item As System.Windows.Forms.ToolStripItem)
        MyBase.InitializeItem(item)
        item.ForeColor = Color.Black
    End Sub
    Protected Overrides Sub Initialize(ByVal toolStrip As System.Windows.Forms.ToolStrip)
        MyBase.Initialize(toolStrip)
        toolStrip.ForeColor = Color.Black
    End Sub

    'Render horizontal bakcground gradient
    Protected Overrides Sub OnRenderToolStripBackground(ByVal e As ToolStripRenderEventArgs)
        e.Graphics.Clear(Color.Transparent)
    End Sub

    'Render Image Margin and gray itembackground
    Protected Overrides Sub OnRenderImageMargin(ByVal e As System.Windows.Forms.ToolStripRenderEventArgs)
        'Draw ImageMargin background gradient
        Dim b As New SolidBrush(Color.White)
        'Shadow at the right of image margin
        Dim WhiteLine As New Drawing.SolidBrush(Color.FromArgb(128, 65, 183))
        Dim rect As New Rectangle(e.AffectedBounds.Width, 2, 1, e.AffectedBounds.Height)
        Dim rect2 As New Rectangle(e.AffectedBounds.Width + 1, 2, 1, e.AffectedBounds.Height)
        'Gray background
        Dim SubmenuBGbrush As New Drawing.SolidBrush(Color.FromArgb(240, 240, 240))
        Dim rect3 As New Rectangle(0, 0, e.ToolStrip.Width, e.ToolStrip.Height)
        'Border
        Dim borderPen As New Pen(clrMenuBorder)
        Dim rect4 As New Rectangle(0, 1, e.ToolStrip.Width - 1, e.ToolStrip.Height - 2)
        e.Graphics.FillRectangle(SubmenuBGbrush, rect3)
        e.Graphics.FillRectangle(b, e.AffectedBounds)
        e.Graphics.FillRectangle(WhiteLine, rect2)
        e.Graphics.DrawRectangle(borderPen, rect4)
    End Sub

    'Render separator
    Protected Overrides Sub OnRenderSeparator(ByVal e As System.Windows.Forms.ToolStripSeparatorRenderEventArgs)
        e.Graphics.DrawLine(New Pen(Color.FromArgb(128, 65, 183)), New Point(32, 4), New Point(e.Item.Width - 8, 4))
    End Sub

    '// Render arrow
    Protected Overrides Sub OnRenderArrow(ByVal e As System.Windows.Forms.ToolStripArrowRenderEventArgs)
        e.ArrowColor = Color.Black
        MyBase.OnRenderArrow(e)
    End Sub

    '// Render Menuitem background: lightblue if selected, darkblue if dropped down
    Protected Overrides Sub OnRenderMenuItemBackground(ByVal e As System.Windows.Forms.ToolStripItemRenderEventArgs)
        If e.Item.Enabled Then
            If e.Item.IsOnDropDown = False AndAlso e.Item.Selected Then
                e.Graphics.FillRectangle(New SolidBrush(Color.FromArgb(128, 65, 183)), New Rectangle(0, 0, e.Item.Width, e.Item.Height))
            ElseIf e.Item.IsOnDropDown AndAlso e.Item.Selected Then
                e.Graphics.FillRectangle(New SolidBrush(Color.FromArgb(128, 65, 183)), New Rectangle(0, 0, e.Item.Width, e.Item.Height))
            End If
            '// If item is MenuHeader and menu is dropped down: selection rectangle is now darker
            If CType(e.Item, ToolStripMenuItem).DropDown.Visible AndAlso e.Item.IsOnDropDown = False Then 'CType(e.Item, ToolStripMenuItem).OwnerItem Is Nothing Then
                e.Graphics.FillRectangle(New SolidBrush(Color.FromArgb(100, 51, 142)), New Rectangle(0, 0, e.Item.Width, e.Item.Height))
            End If
        End If
    End Sub

    Protected Overrides Sub OnRenderItemText(ByVal e As System.Windows.Forms.ToolStripItemTextRenderEventArgs)

        If e.Item.IsOnDropDown = True Then
            e.Graphics.TextRenderingHint = Drawing.Text.TextRenderingHint.AntiAlias
            Dim mybrush As Brush = Brushes.Black
            If (e.Item.IsOnDropDown = False AndAlso e.Item.Selected) Or
        (e.Item.IsOnDropDown AndAlso e.Item.Selected) Or (CType(e.Item, ToolStripMenuItem).DropDown.Visible AndAlso e.Item.IsOnDropDown = False) Then
                mybrush = Brushes.White
            End If
            If e.Item.Enabled = False Then mybrush = Brushes.Gray
            If e.Text.Contains("+") Or DirectCast(e.Item, ToolStripMenuItem).ShortcutKeys.ToString = e.Text Then
                e.Graphics.DrawString(e.Text, e.TextFont, mybrush, e.TextRectangle.Location.X + e.TextRectangle.Width - e.Graphics.MeasureString(e.Text, e.TextFont).Width, e.TextRectangle.Location.Y)
            Else
                e.Graphics.DrawString(e.Text, e.TextFont, mybrush, e.TextRectangle.Location.X + 1, e.TextRectangle.Location.Y)
            End If

        End If
    End Sub

    Protected Overrides Sub OnRenderItemImage(ByVal e As System.Windows.Forms.ToolStripItemImageRenderEventArgs)
        Dim thisimg As Image = e.Image
        Dim newimg As Bitmap = New Bitmap(16, 16)
        Dim g As Graphics = Graphics.FromImage(newimg)
        g.DrawImage(thisimg, 0, 0, 16, 16)
        thisimg = newimg

        If (e.Item.IsOnDropDown = False AndAlso e.Item.Selected) Or
        (e.Item.IsOnDropDown AndAlso e.Item.Selected) Or (CType(e.Item, ToolStripMenuItem).DropDown.Visible AndAlso e.Item.IsOnDropDown = False) Then
            For x = 0 To 15
                For y = 0 To 15
                    Dim col As Color = newimg.GetPixel(x, y)
                    newimg.SetPixel(x, y, Color.FromArgb(col.A, 255, 255, 255))
                    thisimg = newimg
                Next
            Next
        End If

        If e.Item.Enabled = False Then
            For x = 0 To 15
                For y = 0 To 15
                    Dim col As Color = newimg.GetPixel(x, y)
                    newimg.SetPixel(x, y, Color.FromArgb(col.A, 128, 128, 128))
                    thisimg = newimg
                Next
            Next
        End If
        e.Graphics.DrawImage(thisimg, e.ImageRectangle.Location)

    End Sub

End Class