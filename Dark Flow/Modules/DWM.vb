Imports System.Runtime.InteropServices
Imports System.Drawing.Drawing2D

Module DWM

    Declare Sub SetGlass Lib "dwmapi.dll" Alias "DwmExtendFrameIntoClientArea" (ByVal hWnd As System.IntPtr, ByRef pMargins As Margins)

    <DllImport("dwmapi.dll")> _
    Private Function DwmIsCompositionEnabled(ByRef enabled As Boolean) As Integer
    End Function

    <StructLayout(LayoutKind.Sequential)> _
  Public Structure DMARGINS
        Public Left As Integer
        Public Right As Integer
        Public Top As Integer
        Public Bottom As Integer
    End Structure

    Public WTNCA_NODRAWCAPTION As UInteger = &H1
    Public WTNCA_NODRAWICON As UInteger = &H2
    Public WTNCA_NOSYSMENU As UInteger = &H4
    Public WTNCA_NOMIRRORHELP As UInteger = &H8

    <StructLayout(LayoutKind.Sequential)> _
    Public Structure WTA_OPTIONS
        Public Flags As UInteger
        Public Mask As UInteger
    End Structure

    Public Enum WindowThemeAttributeType
        WTA_NONCLIENT = 1
    End Enum

    <DllImport("UxTheme.dll")> _
    Public Function SetWindowThemeAttribute(ByVal hWnd As IntPtr, ByVal wtype As WindowThemeAttributeType, ByRef attributes As WTA_OPTIONS, ByVal size As UInteger) As Integer
    End Function

    Public Function AeroEnabled() As Boolean
        If Environment.OSVersion.Version.Major < 6 Then Return False
        Dim Enabled As Boolean
        DwmIsCompositionEnabled(Enabled)
        Return Enabled
    End Function

    Public MasterRadius As Byte = 5

    Structure Margins
        Public cLeft As Integer, cRight As Integer, cTop As Integer, cBottom As Integer
        Sub New(ByVal Left As Integer, ByVal Right As Integer, _
                    ByVal Top As Integer, ByVal Bottom As Integer)
            cLeft = Left
            cRight = Right
            cTop = Top
            cBottom = Bottom
        End Sub
        Sub New(ByVal Thickness As Integer)
            cLeft = Thickness
            cRight = Thickness
            cTop = Thickness
            cBottom = Thickness
        End Sub
        Sub New(ByVal [Padding] As Padding)
            cLeft = [Padding].Left
            cRight = [Padding].Right
            cTop = [Padding].Top
            cBottom = [Padding].Bottom
        End Sub
    End Structure

    Public Sub GlassOn(ByRef TheForm As Form, ByVal Padd As Padding)
        SetGlass(TheForm.Handle, New Margins(Padd))
    End Sub

    Public Sub GDIRenderItem(ByVal BGColor As Color, ByVal LargeRadius As Boolean, ByVal e As DrawItemEventArgs, ByVal TextSize As Byte, ByVal TextLoc As Point, ByVal TheText As String, ByVal Img As Image, Optional ByVal SecondColumnText As String = "")
        e.Graphics.TextRenderingHint = Drawing.Text.TextRenderingHint.ClearTypeGridFit
        If e.Index < 0 Then Exit Sub
        Dim IsSelected As Boolean = False
        If (e.State And DrawItemState.Selected) = DrawItemState.Selected Then IsSelected = True
        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias
        e.Graphics.FillRectangle(New SolidBrush(BGColor), New Rectangle(e.Bounds.X - 1, e.Bounds.Y - 1, e.Bounds.Width + 1, e.Bounds.Height + 1))
        If IsSelected Then
            Dim x As New Drawing2D.LinearGradientBrush(New Rectangle(e.Bounds.X, e.Bounds.Y, e.Bounds.Width - 1, e.Bounds.Height - 1), Color.FromArgb(220, 235, 252), Color.FromArgb(193, 219, 252), LinearGradientMode.Vertical)
            e.Graphics.FillPath(x, CreateAllRoundedRect(New Rectangle(e.Bounds.X, e.Bounds.Y, e.Bounds.Width - 1, e.Bounds.Height - 1), If(LargeRadius, 8, 4)))
            e.Graphics.DrawPath(New Pen(Color.FromArgb(125, 162, 206)), CreateAllRoundedRect(New Rectangle(e.Bounds.X, e.Bounds.Y, e.Bounds.Width - 1, e.Bounds.Height - 1), If(LargeRadius, 8, 4)))
        End If
        Dim F As New Font("Segoe UI", TextSize)
        Dim TheBrush As Brush = If(IsSelected, Brushes.Black, New SolidBrush(Color.FromArgb(48, 48, 48)))
        e.Graphics.DrawString(TheText, F, TheBrush, TextLoc)
        If SecondColumnText.Length > 0 Then
            Dim TW As Byte = e.Graphics.MeasureString(SecondColumnText, F, e.Bounds.Size, StringFormat.GenericDefault, SecondColumnText.Length, 1).Width
            e.Graphics.DrawString(SecondColumnText, F, TheBrush, New Point(e.Bounds.Width - TW - 4, TextLoc.Y))
        End If
        Dim Spac As SByte = (e.Bounds.Height / 2) - (Img.Height / 2)
        e.Graphics.DrawImageUnscaled(Img, New Point(e.Bounds.X + Spac, e.Bounds.Y + Spac))
    End Sub

    'Public Function CreateTopRoundedRect(ByVal rect As Rectangle, ByVal curve As Single) As System.Drawing.Drawing2D.GraphicsPath
    '    Dim gPath As New System.Drawing.Drawing2D.GraphicsPath
    '    Dim aRect As New RectangleF(rect.Location, New SizeF(curve, curve))
    '    Dim i As Single = CType(curve / 2, Single)
    '    With gPath
    '        .AddArc(aRect, 180, 90)
    '        .AddLine(rect.X + i, rect.Y, rect.X + rect.Width - i, rect.Y) 'TOP LINE
    '        aRect.X = rect.Right - curve
    '        .AddArc(aRect, 270, 90)     'Top right corner
    '        .AddLine(rect.Right, rect.Y + i, rect.Right, rect.Bottom) 'RIGHT LINE
    '        .AddLine(rect.Right, rect.Bottom, rect.Left, rect.Bottom)    'BOTTOM LINE
    '        .AddLine(rect.Left, rect.Bottom, rect.Left, rect.Y + i) 'LEFT LINE
    '        .CloseFigure()
    '    End With
    '    Return gPath
    'End Function

    'Public Function CreateAllRoundedRect(ByVal rect As Rectangle, ByVal curve As Single) As System.Drawing.Drawing2D.GraphicsPath
    '    Dim gPath As New System.Drawing.Drawing2D.GraphicsPath
    '    Dim aRect As New RectangleF(rect.Location, New SizeF(curve, curve))
    '    Dim i As Single = CType(curve / 2, Single)
    '    With gPath
    '        .AddArc(aRect, 180, 90)     'Top left corner
    '        .AddLine(rect.X + i, rect.Y, rect.X + rect.Width - i, rect.Y) 'TOP LINE
    '        aRect.X = rect.Right - curve
    '        .AddArc(aRect, 270, 90)     'Top right corner
    '        .AddLine(rect.X + rect.Width, rect.Y + i, rect.X + rect.Width, rect.Y + rect.Height - 1 - i) 'RIGHT LINE
    '        aRect.Y = rect.Bottom - curve - 1
    '        .AddArc(aRect, 0, 90)     'bottom right corner
    '        .AddLine(rect.X + rect.Width - i, rect.Y + rect.Height - 1, rect.X + i, rect.Y + rect.Height - 1)    'BOTTOM LINE
    '        aRect.X = rect.Left
    '        .AddArc(aRect, 90, 90)     'bottom right corner
    '        .AddLine(rect.X, rect.Y + rect.Height - 1 - i, rect.X, rect.Y + i) 'LEFT LINE
    '        .CloseFigure()
    '    End With
    '    Return gPath
    'End Function
    Public Function CreateTopRoundedRect(ByVal rect As Rectangle, ByVal curve As Single) As System.Drawing.Drawing2D.GraphicsPath
        Return CreateAllRoundedRect(rect, curve)
    End Function
    Public Function CreateAllRoundedRect(ByVal rect As Rectangle, ByVal curve As Single) As System.Drawing.Drawing2D.GraphicsPath
        Dim gPath As New System.Drawing.Drawing2D.GraphicsPath
        gPath.AddRectangle(rect)
        Return gPath
    End Function

    Public Function CreateGap(ByVal rect As Rectangle, ByVal curve As Single, ByVal drawString As String, ByVal drawFont As Font) As System.Drawing.Drawing2D.GraphicsPath

        curve = 0
        Dim gPath As New System.Drawing.Drawing2D.GraphicsPath
        ' Dim aRect As New RectangleF(rect.Location, New SizeF(curve, curve))
        Dim i As Single = CType(curve / 2, Single)
        Dim e As Graphics
        e = Graphics.FromImage(New Bitmap(100, 100))
        Dim W As Int16 = e.MeasureString(drawString, drawFont).Width
        With gPath
            .AddLine(rect.X + 12 + W, rect.Y, rect.X + rect.Width - i, rect.Y) 'TOP LINE
            .AddLine(rect.X + rect.Width, rect.Y + i, rect.X + rect.Width, rect.Y + rect.Height - 1 - i) 'RIGHT LINE
            
            .AddLine(rect.X + rect.Width - i, rect.Y + rect.Height - 1, rect.X + i, rect.Y + rect.Height - 1)    'BOTTOM LINE
          
            .AddLine(rect.X, rect.Y + rect.Height - 1 - i, rect.X, rect.Y + i) 'LEFT LINE
     
            .AddLine(rect.X + i, rect.Y, rect.X + 8, rect.Y) 'TOP LINE
            .AddLine(rect.X + 8, rect.Y, rect.X + 8, rect.Y + 16)
            .AddLine(rect.X + 8, rect.Y + 16, rect.X + 12 + W, rect.Y + 16)
            .CloseFigure()
        End With
        Return gPath
    End Function

    Sub HideTitleBar(ByRef TF As Form)
        If AeroEnabled() Then
            Dim ops As New DWM.WTA_OPTIONS()
            ops.Flags = DWM.WTNCA_NODRAWCAPTION Or DWM.WTNCA_NODRAWICON
            ops.Mask = DWM.WTNCA_NODRAWCAPTION Or DWM.WTNCA_NODRAWICON
            DWM.SetWindowThemeAttribute(TF.Handle, DWM.WindowThemeAttributeType.WTA_NONCLIENT, ops, CUInt(Marshal.SizeOf(GetType(DWM.WTA_OPTIONS))))
        End If
    End Sub

    Dim SingularDoneList As New List(Of String)

    Sub CorrectDialog(ByRef TF As Form, ByVal Singular As Boolean)

        If Singular And SingularDoneList.Contains(TF.Name) Then Exit Sub
        Dim ThePads As UInt16 = 6

        Dim OldMaxWidth As UInt16 = If(TF.MaximumSize.Width = 0, TF.Width, TF.MaximumSize.Width)
        Dim OldMaxHeight As UInt16 = If(TF.MaximumSize.Height = 0, TF.Height, TF.MaximumSize.Height)

        'If Singular Then
        TF.MaximumSize = New Size(OldMaxWidth + (ThePads * 2), OldMaxHeight + (ThePads * 2))
        TF.MinimumSize = New Size(TF.MinimumSize.Width + (ThePads * 2), TF.MinimumSize.Height + (ThePads * 2))
        'End If

        TF.Width += (ThePads * 2)
        TF.Height += (ThePads * 2)

        For Each D As Control In TF.Controls
            D.Location = New Point(D.Location.X + ThePads, D.Location.Y + ThePads)
        Next

        If Singular Then
            SingularDoneList.Add(TF.Name)
        End If

    End Sub

    Sub GlobalGlass(ByRef TF As Form, ByVal DoCorrectMe As Boolean, ByVal IsSingular As Boolean)
        If AeroEnabled() Then
            TF.BackColor = Color.Black
            GlassOn(TF, TF.Padding)
        Else
            TF.BackColor = clsColors.CrucialColor
            If DoCorrectMe Then CorrectDialog(TF, IsSingular)
        End If
    End Sub

End Module