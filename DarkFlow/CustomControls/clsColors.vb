Module clsColors

    Public clrHorBG_GrayBlue As Color = Color.FromArgb(255, 233, 236, 250)
    Public clrHorBG_White As Color = Color.FromArgb(255, 244, 247, 252)
    Public clrSubmenuBG As Color = Color.FromArgb(255, 240, 240, 240)
    Public clrImageMarginBlue As Color = Color.FromArgb(255, 212, 216, 230)
    Public clrImageMarginWhite As Color = Color.FromArgb(255, 244, 247, 252)
    Public clrImageMarginLine As Color = Color.FromArgb(255, 160, 160, 180)
    Public clrSelectedBG_Blue As Color = Color.FromArgb(255, 186, 228, 246)
    Public clrSelectedBG_Header_Blue As Color = Color.FromArgb(255, 146, 202, 230)
    Public clrSelectedBG_White As Color = Color.FromArgb(255, 241, 248, 251)
    Public clrSelectedBG_Border As Color = Color.FromArgb(255, 150, 217, 249)
    Public clrSelectedBG_Drop_Blue As Color = Color.FromArgb(255, 139, 195, 225)
    Public clrSelectedBG_Drop_Border As Color = Color.FromArgb(255, 48, 127, 177)
    Public clrMenuBorder As Color = Color.FromArgb(255, 160, 160, 160)
    Public clrCheckBG As Color = Color.FromArgb(255, 206, 237, 250)

    Public clrVerBG_GrayBlue As Color = Color.FromArgb(255, 196, 203, 219)
    Public clrVerBG_White As Color = Color.FromArgb(255, 250, 250, 253)
    Public clrVerBG_Shadow As Color = Color.FromArgb(255, 181, 190, 206)

    Public clrToolstripBtnGrad_Blue As Color = Color.FromArgb(255, 129, 192, 224)
    Public clrToolstripBtnGrad_White As Color = Color.FromArgb(255, 237, 248, 253)
    Public clrToolstripBtn_Border As Color = Color.FromArgb(255, 41, 153, 255)
    Public clrToolstripBtnGrad_Blue_Pressed As Color = Color.FromArgb(255, 124, 177, 204)
    Public clrToolstripBtnGrad_White_Pressed As Color = Color.FromArgb(255, 228, 245, 252)

    Public CrucialColor As Color = Color.FromArgb(226, 229, 238)

    Public Sub DrawRoundedRectangle(ByRef iGraphics As Graphics, _
                                ByVal XAxis As Integer, _
                                ByVal YAxis As Integer, _
                                ByVal MWidth As Integer, _
                                ByVal MHeight As Integer, _
                                ByVal MDiameter As Integer, ByVal DC As Color)

        'Dim MyPen As New Pen(DC)
        'Dim BaseRect As New RectangleF(XAxis, YAxis, MWidth, MHeight)
        'Dim ArcRect As New RectangleF(BaseRect.Location, New SizeF(MDiameter, MDiameter))

        ''Top Left Arc
        'iGraphics.DrawArc(MyPen, ArcRect, 180, 90)
        'iGraphics.DrawLine(MyPen, XAxis + CInt(MDiameter / 2), YAxis, XAxis + MWidth - CInt(MDiameter / 2), YAxis)

        ''Top Right Arc
        'ArcRect.X = BaseRect.Right - MDiameter
        'iGraphics.DrawArc(MyPen, ArcRect, 270, 90)
        'iGraphics.DrawLine(MyPen, XAxis + MWidth, YAxis + CInt(MDiameter / 2), XAxis + MWidth, YAxis + MHeight - CInt(MDiameter / 2))

        ''Bottom Right Arc
        'ArcRect.Y = BaseRect.Bottom - MDiameter
        'iGraphics.DrawArc(MyPen, ArcRect, 0, 90)
        'iGraphics.DrawLine(MyPen, XAxis + CInt(MDiameter / 2), YAxis + MHeight, XAxis + MWidth - CInt(MDiameter / 2), YAxis + MHeight)

        ''Bottom Left Arc
        'ArcRect.X = BaseRect.Left
        'iGraphics.DrawArc(MyPen, ArcRect, 90, 90)
        'iGraphics.DrawLine(MyPen, XAxis, YAxis + CInt(MDiameter / 2), XAxis, YAxis + MHeight - CInt(MDiameter / 2))

        iGraphics.DrawRectangle(New Pen(Brushes.DarkCyan), New Rectangle(XAxis, YAxis, MWidth, MHeight))
    End Sub

    Sub FillRoundedRectangle(ByRef iGraphics As Graphics, ByVal TheRect As Rectangle, ByVal MDiameter As Integer, ByVal TheBrush As Brush)
        'Dim GP As System.Drawing.Drawing2D.GraphicsPath = New System.Drawing.Drawing2D.GraphicsPath
        'GP.AddArc(TheRect.X, TheRect.Y, MDiameter, MDiameter, 180, 90)
        'GP.AddArc(TheRect.X + TheRect.Width - MDiameter - 1, TheRect.Y, MDiameter, MDiameter, 270, 90)
        'GP.AddArc(TheRect.X + TheRect.Width - MDiameter - 1, TheRect.Y + TheRect.Height - MDiameter - 1, MDiameter, MDiameter, 0, 90)
        'GP.AddArc(TheRect.X, TheRect.Y + TheRect.Height - MDiameter - 1, MDiameter, MDiameter, 90, 90)
        'iGraphics.FillPath(TheBrush, GP)
        iGraphics.FillRectangle(TheBrush, TheRect)
    End Sub

End Module