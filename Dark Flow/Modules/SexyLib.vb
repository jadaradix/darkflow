Imports System.Drawing.Drawing2D
Module SexyLib

    Private Sub PaintToolBar(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs)

        Dim gBrush As LinearGradientBrush = New LinearGradientBrush(New Point(0, 0) _
                                              , New Point(0, DirectCast(sender,Control).Height) _
                                              , Color.FromArgb(238, 238, 238) _
                                              , Color.White)
        e.Graphics.FillRectangle(gBrush, New Rectangle(New Point(0, 0), New Point(DirectCast(sender, Control).Width, DirectCast(sender, Control).Height)))
        e.Graphics.DrawLine(New Pen(Color.FromArgb(181, 190, 206)), New Point(0, DirectCast(sender, Control).Height - 1), New Point(DirectCast(sender, Control).Width, DirectCast(sender, Control).Height - 1))
    End Sub

    Sub SexUpToolStrip(ByRef Stripper As ToolStrip, ByVal AttemptControlShift As Boolean, ByVal IncreaseHeight As Boolean, Optional ByRef RefForm As Form = Nothing)
        Dim pan As New Panel
        pan.BackColor = Color.FromArgb(245, 245, 245)
        pan.Dock = DockStyle.Top
        pan.Height = 28
        Stripper.Parent.Controls.Add(pan)
        Stripper.Parent = pan
        AddHandler pan.Paint, AddressOf PaintToolBar
        Stripper.Renderer = New metroToolstripRenderer
        Stripper.BackColor = Color.Transparent
        Stripper.Size = New Size(Stripper.Width, 28)
        Stripper.GripMargin = New Padding(0, 0, 0, 0)
        Stripper.GripStyle = ToolStripGripStyle.Hidden
        Stripper.ImageScalingSize = New Size(24, 24)
        Stripper.LayoutStyle = ToolStripLayoutStyle.Flow
        Stripper.Padding = New Padding(2, 0, 0, 0)
        If Stripper.Items.Count > 0 Then
            For I As Byte = 0 To Stripper.Items.Count - 1
                'Stripper.Items(I).Padding = New Padding(2, 2, 2, 2)
                Stripper.Items(I).Padding = New Padding(0, 0, 0, 0)
                Stripper.Items(I).Margin = New Padding(0, 0, 0, 0)
                Try
                    DirectCast(Stripper.Items(I), ToolStripButton).TextAlign = ContentAlignment.MiddleCenter
                    DirectCast(Stripper.Items(I), ToolStripButton).AutoSize = False
                    DirectCast(Stripper.Items(I), ToolStripButton).Height = 28
                Catch ex As Exception
                    Try
                        DirectCast(Stripper.Items(I), ToolStripSeparator).AutoSize = False
                        DirectCast(Stripper.Items(I), ToolStripSeparator).Size = New Size(3, 28)
                    Catch ex2 As Exception
                    End Try
                End Try

            Next
        End If
        If AttemptControlShift Then
            For Each P As Control In RefForm.Controls
                If P.Name = Stripper.Name Then Continue For
                P.Location = New Point(P.Location.X, P.Location.Y + 3)
            Next
            If IncreaseHeight Then RefForm.Height += 3
        End If
    End Sub
    Sub SexUpToolStrip_New(ByRef Stripper As ToolStrip, ByVal AttemptControlShift As Boolean, ByVal IncreaseHeight As Boolean, Optional ByRef RefForm As Form = Nothing)
        Stripper.Renderer = New metroToolstripRenderer
        Stripper.Padding = New Padding(1, 0, 1, 1)
        If Stripper.Items.Count > 0 Then
            For I As Byte = 0 To Stripper.Items.Count - 1
                Stripper.Items(I).Padding = New Padding(2, 2, 2, 2)
            Next
        End If
        If AttemptControlShift Then
            For Each P As Control In RefForm.Controls
                If P.Name = Stripper.Name Then Continue For
                P.Location = New Point(P.Location.X, P.Location.Y + 3)
            Next
            If IncreaseHeight Then RefForm.Height += 3
        End If
    End Sub

    Function ReCenterParent(ByRef TFWidth As UInt16, ByVal TFHeight As UInt16, ByRef TP As Control) As Point
        Dim TL As Point = TP.PointToScreen(New Point(0, 0))
        Return New Point(TL.X + ((TP.Width - TFWidth) / 2), TL.Y + ((TP.Height - TFHeight) / 2))
    End Function

    Function ReCenterParentCoOrds(ByRef TFWidth As Int16, ByVal TFHeight As Int16, ByVal TPH As Int16, ByVal TPW As Int16, ByVal TPXY As Point) As Point
        Return New Point(TPXY.X + ((TPW - TFWidth) / 2), TPXY.Y + ((TPH - TFHeight) / 2))
    End Function

    Sub ReCenter(ByRef TF As Form)
        If MainForm.WindowState = FormWindowState.Normal Then
            'Dim YA As Int16 = MainForm.PrimaryToolStrip.Height + MainForm.SecondaryToolStrip.Height + MainForm.Glosser.Height
            Dim YA As Int16 = MainForm.PrimaryToolStrip.Height + MainForm.Glosser.Height
            TF.Location = New Point(TF.Location.X + (MainForm.ResourcesList.Width / 2), TF.Location.Y + (YA / 2))
        End If
    End Sub

    Sub SexyDoings(ByRef TF As Form, ByVal BigAss As Boolean)
        Dim W As Int16 = My.Computer.Screen.WorkingArea.Width
        Dim H As Int16 = My.Computer.Screen.WorkingArea.Height
        If BigAss Then
            Dim X As Int16 = (W / 2) - (TF.Width / 2)
            Dim Y As Int16 = (H / 2) - (TF.Height / 2)
            TF.Location = New Point(X, Y)
            TF.Size = New Size(W - (X * 2), H - (Y * 2))
        Else
            TF.Location = New Point(96, 64)
            TF.Size = New Size(W - (96 * 2), H - 128)
        End If
    End Sub

End Module
