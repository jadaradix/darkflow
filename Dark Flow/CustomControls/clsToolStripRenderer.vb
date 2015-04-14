Public Class clsToolstripRenderer
    Inherits System.Windows.Forms.ToolStripProfessionalRenderer

    'Render container background gradient
    Protected Overrides Sub OnRenderToolStripBackground(ByVal e As ToolStripRenderEventArgs)
        MyBase.OnRenderToolStripBackground(e)

        Dim b As New Drawing2D.LinearGradientBrush(e.AffectedBounds, clrVerBG_White, clrVerBG_GrayBlue, _
            Drawing2D.LinearGradientMode.Vertical)
        Dim shadow As New Drawing.SolidBrush(clrVerBG_Shadow)
        Dim rect As New Rectangle(0, e.ToolStrip.Height - 2, e.ToolStrip.Width, 1)
        e.Graphics.FillRectangle(b, e.AffectedBounds)
        e.Graphics.FillRectangle(shadow, rect)
    End Sub

    'Render button selected and pressed state
    Protected Overrides Sub OnRenderButtonBackground(ByVal e As System.Windows.Forms.ToolStripItemRenderEventArgs)
        e.Graphics.SmoothingMode = Drawing2D.SmoothingMode.HighQuality
        If e.Item.IsOnDropDown = False AndAlso e.Item.Selected Then
            'If item is MenuHeader and selected: draw darkblue border
            Dim rect As New Rectangle(2, 2, e.Item.Width - 3, e.Item.Height - 4)
            Dim b As New Drawing2D.LinearGradientBrush(rect, clrSelectedBG_White, clrSelectedBG_Header_Blue, Drawing2D.LinearGradientMode.Vertical)
            Dim b2 As New Drawing.SolidBrush(clrToolstripBtn_Border)
            e.Graphics.FillRectangle(b, rect)
            clsColors.DrawRoundedRectangle(e.Graphics, rect.Left - 1, rect.Top - 1, rect.Width, rect.Height + 1, 4, clrToolstripBtn_Border)
            clsColors.DrawRoundedRectangle(e.Graphics, rect.Left - 2, rect.Top - 2, rect.Width + 2, rect.Height + 3, 4, Color.White)
            e.Item.ForeColor = Color.Black
        End If
        'If item is MenuHeader and menu is dropped down: selection rectangle is now darker
        If e.Item.Pressed Then
            Dim rect As New Rectangle(2, 2, e.Item.Width - 3, e.Item.Height - 4)
            Dim b As New Drawing2D.LinearGradientBrush(rect, Color.White, clrSelectedBG_Drop_Blue, Drawing2D.LinearGradientMode.Vertical)
            Dim b2 As New Drawing.SolidBrush(clrSelectedBG_Drop_Border)
            e.Graphics.FillRectangle(b, rect)
            clsColors.DrawRoundedRectangle(e.Graphics, rect.Left - 1, rect.Top - 1, rect.Width, rect.Height + 1, 4, clrSelectedBG_Drop_Border)
            clsColors.DrawRoundedRectangle(e.Graphics, rect.Left - 2, rect.Top - 2, rect.Width + 2, rect.Height + 3, 4, Color.White)
            e.Item.ForeColor = Color.Black
        End If
    End Sub

End Class