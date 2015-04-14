Imports System.ComponentModel
Imports System.Drawing
Imports System.Drawing.Drawing2D

<ToolboxBitmap(GetType(System.Windows.Forms.TabControl))> _
Public Class SexyTabControl
    Inherits System.Windows.Forms.TabControl

    ''' <summary> 
    ''' Required designer variable.
    ''' </summary>
    Private components As System.ComponentModel.Container = Nothing
    Private scUpDown As SubClass = Nothing
    Private bUpDown As Boolean
    ' true when the button UpDown is required
    Private leftRightImages As ImageList = Nothing
    Private Const nMargin As Integer = 5
    Private mBackColor As Color
    Private iBorderCol As Color
    Private mGrad As Color
    Public Overrides Property BackColor() As Color
        Get
            Return mBackColor
        End Get
        Set(ByVal value As Color)
            mBackColor = value
        End Set
    End Property
    Public Property GradFrom() As Color
        Get
            Return mGrad
        End Get
        Set(ByVal value As Color)
            mGrad = value
        End Set
    End Property

    Public Property BorderColor() As Color
        Get
            Return iBorderCol
        End Get
        Set(ByVal value As Color)
            iBorderCol = value
        End Set
    End Property

    Public Sub New()
        ' This call is required by the Windows.Forms Form Designer.
        InitializeComponent()
        mBackColor = Color.Transparent
        iBorderCol = Color.FromArgb(80, 80, 80)
        mGrad = Color.FromArgb(133, 133, 133)
        ' double buffering
        SetStyle(ControlStyles.UserPaint, True)
        SetStyle(ControlStyles.AllPaintingInWmPaint, True)
        SetStyle(ControlStyles.DoubleBuffer, True)
        SetStyle(ControlStyles.ResizeRedraw, True)
        SetStyle(ControlStyles.SupportsTransparentBackColor, True)

        bUpDown = False

        AddHandler Me.ControlAdded, New ControlEventHandler(AddressOf FlatTabControl_ControlAdded)
        AddHandler Me.ControlRemoved, New ControlEventHandler(AddressOf FlatTabControl_ControlRemoved)
        AddHandler Me.SelectedIndexChanged, New EventHandler(AddressOf FlatTabControl_SelectedIndexChanged)

        leftRightImages = New ImageList()

        Dim resources As New System.Resources.ResourceManager(GetType(SexyTabControl))
        Dim updownImage As Bitmap = DirectCast(resources.GetObject("TabIcons.bmp"), System.Drawing.Bitmap)

        If updownImage IsNot Nothing Then
            updownImage.MakeTransparent(Color.White)
            leftRightImages.Images.AddStrip(updownImage)
        End If

    End Sub

    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If components IsNot Nothing Then components.Dispose()
            leftRightImages.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
        MyBase.OnPaint(e)
        DrawControl(e.Graphics)
    End Sub

    Friend Sub DrawControl(ByVal g As Graphics)
        g.TextRenderingHint = Drawing.Text.TextRenderingHint.ClearTypeGridFit
        g.SmoothingMode = SmoothingMode.AntiAlias
        If Not Visible Then
            Return
        End If
        Dim TabControlArea As Rectangle = Me.ClientRectangle
        Dim TabArea As Rectangle = Me.DisplayRectangle

        Dim nDelta As Integer = SystemInformation.Border3DSize.Width

        TabArea.Inflate(nDelta, nDelta)
        g.FillRectangle(Brushes.White, TabArea)
        g.DrawRectangle(New Pen(iBorderCol), TabArea)
        Dim rsaved As Region = g.Clip
        Dim rreg As Rectangle

        Dim nWidth As Integer = TabArea.Width + nMargin
        If bUpDown Then

            If Win32.IsWindowVisible(scUpDown.Handle) Then
                Dim rupdown As New Rectangle()
                Win32.GetWindowRect(scUpDown.Handle, rupdown)
                Dim rupdown2 As Rectangle = Me.RectangleToClient(rupdown)

                nWidth = rupdown2.X
            End If
        End If

        rreg = New Rectangle(TabArea.Left, TabControlArea.Top, nWidth - nMargin, TabControlArea.Height)

        g.SetClip(rreg)

        g.Clip = rsaved

        If TabCount > 0 Then
            For i As Integer = 0 To TabCount - 1
                If Not Me.SelectedIndex = i Then DrawTab(g, Me.TabPages(i), i)
            Next
        End If

        If Me.SelectedTab IsNot Nothing Then
            Dim tabPage As TabPage = Me.SelectedTab
            Dim color As Color = tabPage.BackColor
            Dim border As Pen
            border = New Pen(color)

            TabArea.Offset(1, 1)
            TabArea.Width -= 2
            TabArea.Height -= 2

            g.DrawRectangle(border, TabArea)
            TabArea.Width -= 1
            TabArea.Height -= 1
            g.DrawRectangle(border, TabArea)

            border.Dispose()
            DrawTab(g, Me.TabPages(Me.SelectedIndex), Me.SelectedIndex)
        End If
    End Sub

    Friend Sub DrawTab(ByVal g As Graphics, ByVal tabPage As TabPage, ByVal nIndex As Integer)
        Dim recBounds As Rectangle = Me.GetTabRect(nIndex)
        Dim tabTextArea As RectangleF = CType(Me.GetTabRect(nIndex), RectangleF)
        g.SmoothingMode = SmoothingMode.AntiAlias
        Dim bSelected As Boolean = (Me.SelectedIndex = nIndex)

        Dim br As Brush = New SolidBrush(Color.White)
        g.FillPath(br, CreateTopRoundedRect(recBounds, 8))
        g.TextRenderingHint = Drawing.Text.TextRenderingHint.ClearTypeGridFit
        br = New SolidBrush(tabPage.BackColor)
        If Me.SelectedIndex = nIndex Then
            br = New LinearGradientBrush(New Point(0, 0), New Point(0, recBounds.Height + 2), mGrad, tabPage.BackColor)
        End If
        g.FillPath(br, CreateTopRoundedRect(recBounds, 8))
        br.Dispose()

        g.DrawPath(New Pen(iBorderCol), CreateTopRoundedRect(recBounds, 8))
        If Me.SelectedIndex = nIndex Then
            g.SmoothingMode = SmoothingMode.None
            g.DrawLine(Pens.White, recBounds.X + 1, recBounds.Y + recBounds.Height, recBounds.X + recBounds.Width - 1, recBounds.Y + recBounds.Height)
            g.SmoothingMode = SmoothingMode.AntiAlias
        End If
        If bSelected Then

            Dim pen As New Pen(tabPage.BackColor)

            Select Case Me.Alignment
                Case TabAlignment.Top
                    g.DrawLine(pen, recBounds.Left + 1, recBounds.Bottom, recBounds.Right - 1, recBounds.Bottom)
                    g.DrawLine(pen, recBounds.Left + 1, recBounds.Bottom + 1, recBounds.Right - 1, recBounds.Bottom + 1)
                    Exit Select

                Case TabAlignment.Bottom
                    g.DrawLine(pen, recBounds.Left + 1, recBounds.Top, recBounds.Right - 1, recBounds.Top)
                    g.DrawLine(pen, recBounds.Left + 1, recBounds.Top - 1, recBounds.Right - 1, recBounds.Top - 1)
                    g.DrawLine(pen, recBounds.Left + 1, recBounds.Top - 2, recBounds.Right - 1, recBounds.Top - 2)
                    Exit Select
            End Select

            '----------------------------
            pen.Dispose()
        End If
        '----------------------------

        '----------------------------
        ' draw tab's icon
        If (tabPage.ImageIndex >= 0) AndAlso (ImageList IsNot Nothing) AndAlso (ImageList.Images(tabPage.ImageIndex) IsNot Nothing) Then
            Dim nLeftMargin As Integer = 8
            Dim nRightMargin As Integer = 2

            Dim img As Image = ImageList.Images(tabPage.ImageIndex)

            Dim rimage As New Rectangle(recBounds.X + nLeftMargin, recBounds.Y + 1, img.Width, img.Height)

            ' adjust rectangles
            Dim nAdj As Single = CSng(nLeftMargin + img.Width + nRightMargin)

            rimage.Y += (recBounds.Height - img.Height) \ 2
            tabTextArea.X += nAdj
            tabTextArea.Width -= nAdj

            ' draw icon
            g.DrawImage(img, rimage)
        End If
        '----------------------------

        '----------------------------
        ' draw string
        Dim stringFormat As New StringFormat()
        stringFormat.Alignment = StringAlignment.Center
        stringFormat.LineAlignment = StringAlignment.Center

        br = New SolidBrush(tabPage.ForeColor)

        g.DrawString(tabPage.Text, Font, br, tabTextArea, stringFormat)
        '----------------------------
    End Sub

    Friend Sub DrawIcons(ByVal g As Graphics)
        If (leftRightImages Is Nothing) OrElse (leftRightImages.Images.Count <> 4) Then
            Return
        End If

        '----------------------------
        ' calc positions
        Dim TabControlArea As Rectangle = Me.ClientRectangle

        Dim r0 As New Rectangle()
        Win32.GetClientRect(scUpDown.Handle, r0)

        Dim br As Brush = New SolidBrush(SystemColors.Control)
        g.FillRectangle(br, r0)
        br.Dispose()

        Dim border As New Pen(SystemColors.ControlDark)
        Dim rborder As Rectangle = r0
        rborder.Inflate(-1, -1)
        g.DrawRectangle(border, rborder)
        border.Dispose()

        Dim nMiddle As Integer = (r0.Width \ 2)
        Dim nTop As Integer = (r0.Height - 16) \ 2
        Dim nLeft As Integer = (nMiddle - 16) \ 2

        Dim r1 As New Rectangle(nLeft, nTop, 16, 16)
        Dim r2 As New Rectangle(nMiddle + nLeft, nTop, 16, 16)
        '----------------------------

        '----------------------------
        ' draw buttons
        Dim img As Image = leftRightImages.Images(1)
        If img IsNot Nothing Then
            If Me.TabCount > 0 Then
                Dim r3 As Rectangle = Me.GetTabRect(0)
                If r3.Left < TabControlArea.Left Then
                    g.DrawImage(img, r1)
                Else
                    img = leftRightImages.Images(3)
                    If img IsNot Nothing Then
                        g.DrawImage(img, r1)
                    End If
                End If
            End If
        End If

        img = leftRightImages.Images(0)
        If img IsNot Nothing Then
            If Me.TabCount > 0 Then
                Dim r3 As Rectangle = Me.GetTabRect(Me.TabCount - 1)
                If r3.Right > (TabControlArea.Width - r0.Width) Then
                    g.DrawImage(img, r2)
                Else
                    img = leftRightImages.Images(2)
                    If img IsNot Nothing Then
                        g.DrawImage(img, r2)
                    End If
                End If
            End If
        End If
        '----------------------------
    End Sub

    Protected Overrides Sub OnCreateControl()
        MyBase.OnCreateControl()

        FindUpDown()
    End Sub

    Private Sub FlatTabControl_ControlAdded(ByVal sender As Object, ByVal e As ControlEventArgs)
        FindUpDown()
        UpdateUpDown()
    End Sub

    Private Sub FlatTabControl_ControlRemoved(ByVal sender As Object, ByVal e As ControlEventArgs)
        FindUpDown()
        UpdateUpDown()
    End Sub

    Private Sub FlatTabControl_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
        UpdateUpDown()
        Invalidate()
        ' we need to update border and background colors
    End Sub

    Private Sub FindUpDown()
        Dim bFound As Boolean = False

        ' find the UpDown control
        Dim pWnd As IntPtr = Win32.GetWindow(Me.Handle, Win32.GW_CHILD)

        While pWnd <> IntPtr.Zero
            '----------------------------
            ' Get the window class name
            Dim className As Char() = New Char(32) {}

            Dim length As Integer = Win32.GetClassName(pWnd, className, 32)

            Dim s As New String(className, 0, length)
            '----------------------------

            If s = "msctls_updown32" Then
                bFound = True

                If Not bUpDown Then
                    '----------------------------
                    ' Subclass it
                    Me.scUpDown = New SubClass(pWnd, True)
                    'Me.scUpDown.SubClassedWndProc += New SubClass.SubClassWndProcEventHandler(AddressOf scUpDown_SubClassedWndProc)
                    '----------------------------

                    bUpDown = True
                End If
                Exit While
            End If

            pWnd = Win32.GetWindow(pWnd, Win32.GW_HWNDNEXT)
        End While

        If (Not bFound) AndAlso (bUpDown) Then
            bUpDown = False
        End If
    End Sub

    Private Sub UpdateUpDown()
        If bUpDown Then
            If Win32.IsWindowVisible(scUpDown.Handle) Then
                Dim rect As New Rectangle()

                Win32.GetClientRect(scUpDown.Handle, rect)
                Win32.InvalidateRect(scUpDown.Handle, rect, True)
            End If
        End If
    End Sub

#Region "scUpDown_SubClassedWndProc Event Handler"

    Private Function scUpDown_SubClassedWndProc(ByRef m As Message) As Integer
        Select Case m.Msg
            Case Win32.WM_PAINT
                If True Then
                    '------------------------
                    ' redraw
                    Dim hDC As IntPtr = Win32.GetWindowDC(scUpDown.Handle)
                    Dim g As Graphics = Graphics.FromHdc(hDC)

                    DrawIcons(g)

                    g.Dispose()
                    Win32.ReleaseDC(scUpDown.Handle, hDC)
                    '------------------------

                    ' return 0 (processed)
                    m.Result = IntPtr.Zero

                    '------------------------
                    ' validate current rect
                    Dim rect As New Rectangle()

                    Win32.GetClientRect(scUpDown.Handle, rect)
                    Win32.ValidateRect(scUpDown.Handle, rect)
                    '------------------------
                End If
                Return 1
        End Select

        Return 0
    End Function
#End Region

#Region "Component Designer generated code"
    ''' <summary>
    ''' Required method for Designer support - do not modify 
    ''' the contents of this method with the code editor.
    ''' </summary>
    Private Sub InitializeComponent()
        components = New System.ComponentModel.Container()
    End Sub


#End Region

#Region "Properties"

    Public Shadows ReadOnly Property TabPages() As TabPageCollection
        Get
            Return MyBase.TabPages
        End Get
    End Property

    Public Shadows Property Alignment() As TabAlignment
        Get
            Return MyBase.Alignment
        End Get
        Set(ByVal value As TabAlignment)
            Dim ta As TabAlignment = value
            If (ta <> TabAlignment.Top) AndAlso (ta <> TabAlignment.Bottom) Then
                ta = TabAlignment.Top
            End If

            MyBase.Alignment = ta
        End Set
    End Property

    <Browsable(False)> _
    Public Shadows Property Multiline() As Boolean
        Get
            Return MyBase.Multiline
        End Get
        Set(ByVal value As Boolean)
            MyBase.Multiline = False
        End Set
    End Property

#End Region

End Class