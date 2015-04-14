Public Class metroToolstripRenderer
    Inherits System.Windows.Forms.ToolStripProfessionalRenderer

    Protected Overrides Sub OnRenderToolStripBackground(ByVal e As System.Windows.Forms.ToolStripRenderEventArgs)

    End Sub

    Protected Overrides Sub OnRenderToolStripBorder(ByVal e As ToolStripRenderEventArgs)
        
    End Sub

    Protected Overrides Sub OnRenderGrip(ByVal e As System.Windows.Forms.ToolStripGripRenderEventArgs)

    End Sub

    Protected Overrides Sub OnRenderItemText(ByVal e As System.Windows.Forms.ToolStripItemTextRenderEventArgs)
        e.Graphics.TextRenderingHint = Drawing.Text.TextRenderingHint.AntiAlias
        Dim mybrush As Brush = Brushes.Black
        If (e.Item.IsOnDropDown = False AndAlso e.Item.Selected) Or e.Item.Pressed Then
            mybrush = Brushes.White
        End If
        e.Graphics.DrawString(e.Text, e.TextFont, mybrush, e.TextRectangle.Location.X + 1, e.TextRectangle.Location.Y)
    End Sub

    Protected Overrides Sub OnRenderSeparator(ByVal e As System.Windows.Forms.ToolStripSeparatorRenderEventArgs)
        e.Graphics.SmoothingMode = Drawing2D.SmoothingMode.HighQuality
        e.Graphics.DrawLine(New Pen(Color.FromArgb(134, 74, 186), 1), New Point(1, 3), New Point(1, 25))
    End Sub
    'Render button selected and pressed state
    Protected Overrides Sub OnRenderItemImage(ByVal e As System.Windows.Forms.ToolStripItemImageRenderEventArgs)
        Dim thisimg As Image = e.Image
        If thisimg Is Nothing Then
            Exit Sub
        End If
        If (e.Item.IsOnDropDown = False AndAlso e.Item.Selected) Or e.Item.Pressed Then
            Dim newimg As Bitmap = New Bitmap(thisimg.Width, thisimg.Height)
            Dim g As Graphics = Graphics.FromImage(newimg)
            g.DrawImage(thisimg, 0, 0)
            If Not (thisimg.Width = 0 Or thisimg.Height = 0) Then
                For x = 0 To thisimg.Width - 1
                    For y = 0 To thisimg.Height - 1
                        Dim col As Color = newimg.GetPixel(x, y)
                        newimg.SetPixel(x, y, Color.FromArgb(col.A, 255, 255, 255))
                    Next
                Next
            End If
            thisimg = newimg
        End If
        e.Graphics.DrawImage(thisimg, e.ImageRectangle.Location)

    End Sub

    Protected Overrides Sub OnRenderButtonBackground(ByVal e As System.Windows.Forms.ToolStripItemRenderEventArgs)
        e.Graphics.SmoothingMode = Drawing2D.SmoothingMode.HighQuality
        If e.Item.IsOnDropDown = False AndAlso e.Item.Selected Then
            e.Graphics.FillRectangle(New SolidBrush(Color.FromArgb(128, 65, 183)), New Rectangle(0, 0, e.Item.Width, e.Item.Height))
        End If
        'If item is MenuHeader and menu is dropped down: selection rectangle is now darker
        If e.Item.Pressed Then
            e.Graphics.FillRectangle(New SolidBrush(Color.FromArgb(100, 51, 142)), New Rectangle(0, 0, e.Item.Width, e.Item.Height))
        End If
    End Sub
End Class