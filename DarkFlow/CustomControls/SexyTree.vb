Public Class SexyTree

    Inherits TreeView

    Sub New()
        ItemHeight = 22
        DrawMode = TreeViewDrawMode.OwnerDrawText
    End Sub

    Protected Overrides Sub OnResize(ByVal e As System.EventArgs)
        Invalidate()
    End Sub

    Protected Overrides Sub OnNodeMouseClick(ByVal e As System.Windows.Forms.TreeNodeMouseClickEventArgs)
        SelectedNode = e.Node
        MyBase.OnNodeMouseClick(e)
    End Sub

    Protected Overrides Sub OnDrawNode(ByVal e As System.Windows.Forms.DrawTreeNodeEventArgs)

        e.Graphics.FillRectangle(New SolidBrush(Color.White), New Rectangle(e.Bounds.X - 2, e.Bounds.Y, Width - e.Bounds.X, e.Bounds.Height + 2))
        e.Graphics.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias
        e.Graphics.TextRenderingHint = Drawing.Text.TextRenderingHint.ClearTypeGridFit

        If e.Node.IsSelected And e.Node.Level > 0 Then
            Dim SB As Rectangle = New Rectangle(e.Bounds.X, e.Bounds.Y, e.Bounds.Width + 4, e.Bounds.Height - 1)
            e.Graphics.SmoothingMode = Drawing2D.SmoothingMode.Default
            e.Graphics.FillPath(New SolidBrush(Color.FromArgb(255, 224, 228, 236)), CreateAllRoundedRect(SB, 5))
            e.Graphics.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias
            e.Graphics.DrawPath(New Pen(Color.FromArgb(255, 203, 209, 223)), CreateAllRoundedRect(SB, 5))
        End If

        e.Graphics.DrawString(e.Node.Text, MainForm.Font, Brushes.Black, e.Bounds.X + 4, e.Bounds.Y + 2)

        MyBase.OnDrawNode(e)

    End Sub

End Class
