Public Class SexyNumeric

    Inherits UserControl

    'Display Properties
    Public IBorderColor As Color
    Dim IInputColor As Color
    Public IShadowColor As Color

    'Functional Properties
    Dim UpHover As Boolean = False
    Dim DownHover As Boolean = False
    Dim HeldTime As UInt16 = 0
    Dim InputOn As Boolean = False
    Dim GoRed As Boolean = False
    Dim iMax As UInt16 = 0
    Dim iMin As UInt16 = 0
    Dim MaxLength As UInt16 = 0
    Dim TemporaryVal As String = String.Empty

    Dim HeldTimer As New Timer

    'External Properties
    Public IValue As UInt16 = 0

    Private Sub Tick(ByVal sender As System.Object, ByVal e As System.EventArgs)
        HeldTime += 1
        If HeldTime >= 8 And HeldTime < 16 Then
            If HeldTime Mod 8 = 0 Then DoChanges()
        End If
        If HeldTime >= 16 And HeldTime < 32 Then
            If HeldTime Mod 4 = 0 Then DoChanges()
        End If
        If HeldTime >= 32 Then DoChanges()
        Me.Invalidate()
    End Sub

    Sub DoChanges()
        Dim DoRaise As Boolean = False
        If DownHover And Value > iMin Then Value -= 1 : DoRaise = True
        If UpHover And Value < iMax Then Value += 1 : DoRaise = True
        If DownHover = False And UpHover = False Then GoRed = True
        RaiseEvent ValueChanged(Me, New System.EventArgs)
    End Sub

#Region "Property Declarations"
    Public Property Maximum() As UInt16
        Get
            Return iMax
        End Get
        Set(ByVal Input As UInt16)
            iMax = Input
            If Input.ToString.Length >= iMin.ToString.Length Then
                MaxLength = Input.ToString.Length
            Else
                MaxLength = iMin.ToString.Length
            End If
        End Set
    End Property

    Public Property Minimum() As UInt16
        Get
            Return iMin
        End Get
        Set(ByVal Input As UInt16)
            iMin = Input
            If iMax.ToString.Length >= Input.ToString.Length Then
                MaxLength = iMax.ToString.Length
            Else
                MaxLength = Input.ToString.Length
            End If
        End Set
    End Property

    Public Property Value() As UInt16
        Get
            Return IValue
        End Get
        Set(ByVal val As UInt16)
            IValue = val
            Me.Invalidate()
        End Set
    End Property

    Property BorderColor() As Color
        Get
            Return IBorderColor
        End Get
        Set(ByVal Input As Color)
            IBorderColor = Input
        End Set
    End Property

    Public Property InputColor() As Color
        Get
            Return IInputColor
        End Get
        Set(ByVal Input As Color)
            IInputColor = Input
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

    'Functional Property Specifiers

#End Region

#Region "Events Stuff"

    Public Event ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs)

#End Region

    Public Sub New()
        IBorderColor = Color.FromArgb(128, 128, 128)
        IInputColor = Color.FromArgb(41, 153, 255)
        IShadowColor = Color.FromArgb(72, 72, 72)
        BackColor = Color.Transparent
        DoubleBuffered = True
        HeldTimer.Enabled = False
        HeldTimer.Interval = 20
        AddHandler HeldTimer.Tick, AddressOf Tick
    End Sub

    Protected Overrides Sub OnLostFocus(ByVal e As System.EventArgs)
        If InputOn Then
            If TemporaryVal = String.Empty Or TemporaryVal = "-" Then
                InputOn = False
                TemporaryVal = String.Empty
            Else
                Dim DoRaise As Boolean = False
                If Not Value = Convert.ToInt16(TemporaryVal) Then DoRaise = True
                Dim NewVal As Int16 = Convert.ToInt16(TemporaryVal)
                If NewVal > iMax Then NewVal = iMax
                If NewVal < iMin Then NewVal = iMin
                'BELOW: If IMaximum > NewVal And IMinimum < NewVal Then 
                Value = NewVal
                TemporaryVal = String.Empty
                InputOn = False
                If DoRaise = True Then
                    RaiseEvent ValueChanged(Me, New System.EventArgs)
                End If
            End If
        End If
        GoRed = False
        Me.Invalidate()
        MyBase.OnLostFocus(e)
    End Sub

    Protected Overrides Sub OnKeyDown(ByVal e As System.Windows.Forms.KeyEventArgs)
        If InputOn Then
            If e.KeyCode = Keys.Enter Then
                If TemporaryVal = String.Empty Or TemporaryVal = "-" Then
                    InputOn = False
                    TemporaryVal = String.Empty
                Else
                    Value = 0
                    Try
                        Value = Convert.ToInt16(TemporaryVal)
                    Catch : End Try
                    If iMax < Val(TemporaryVal) Then Value = iMax
                    If iMax > Val(TemporaryVal) Then Value = iMin
                    If iMax > Val(TemporaryVal) And iMin < Val(TemporaryVal) Then Value = Convert.ToUInt16(TemporaryVal)
                    TemporaryVal = String.Empty
                    InputOn = False
                    RaiseEvent ValueChanged(Me, New System.EventArgs)
                End If
            End If
            If e.KeyCode = Keys.Escape Then
                InputOn = False
                TemporaryVal = String.Empty
            End If
            If e.KeyCode = Keys.Back And TemporaryVal.Length > 0 Then
                TemporaryVal = TemporaryVal.Substring(0, TemporaryVal.Length - 1)
            End If
        End If
        If GoRed And Not InputOn Then
            If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Escape Then
                GoRed = False
            End If
        End If
        If e.KeyData.ToString.StartsWith("OemMinus") Or e.KeyData.ToString.StartsWith("Subtract") Then
            If InputOn Then
                If TemporaryVal = "" Then
                    Dim input As String = "-"
                    TemporaryVal += input
                End If
            Else
                InputOn = True
                Dim input As String = "-"
                TemporaryVal = input
            End If
        End If
        If (e.KeyData.ToString.StartsWith("NumPad") Or e.KeyData.ToString.StartsWith("D")) And (Not TemporaryVal.Length = MaxLength) Then
            If InputOn Then
                Dim input As String = e.KeyData.ToString.Replace("NumPad", String.Empty).Replace("D", String.Empty)
                TemporaryVal += input
            Else
                InputOn = True
                Dim input As String = e.KeyData.ToString.Replace("NumPad", String.Empty).Replace("D", String.Empty)
                TemporaryVal = input
            End If
        End If
        Me.Invalidate()
        MyBase.OnKeyDown(e)
    End Sub

    Protected Overrides Sub OnClick(ByVal e As System.EventArgs)
        Dim DoRaise As Boolean = False
        If DownHover And Value > iMin Then
            Value -= 1
            DoRaise = True
            InputOn = False
        End If
        If UpHover And Value < iMax Then
            Value += 1
            DoRaise = True
            InputOn = False
        End If
        If Not DownHover And Not UpHover Then GoRed = True
        Invalidate()
        If DoRaise Then RaiseEvent ValueChanged(Me, New System.EventArgs)
        MyBase.OnClick(e)
    End Sub

#Region "Drawing"

    Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)
        e.Graphics.TextRenderingHint = Drawing.Text.TextRenderingHint.ClearTypeGridFit
        e.Graphics.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias
        Dim S As New Rectangle(0, 1, Me.Width - 1, Me.Height - 1)
        e.Graphics.DrawPath(New Pen(ShadowColor, 1), CreateAllRoundedRect(S, MasterRadius))
        Dim P As New Rectangle(0, 0, Me.Width - 1, Me.Height - 1)
        e.Graphics.FillPath(New System.Drawing.Drawing2D.LinearGradientBrush(New Point(0, 0), New Point(0, Me.Height + 4), Color.White, Color.Gainsboro), CreateAllRoundedRect(P, MasterRadius))
        e.Graphics.DrawPath(New Pen(IBorderColor, 1), CreateAllRoundedRect(P, MasterRadius))
        If InputOn = False Then e.Graphics.DrawString(Value.ToString, Me.Font, If(GoRed, New SolidBrush(IInputColor), New SolidBrush(Me.ForeColor)), ((Me.Width / 2) - (e.Graphics.MeasureString(Value.ToString, Me.Font).Width / 2)), 2)
        If InputOn Then e.Graphics.DrawString(TemporaryVal, Me.Font, New SolidBrush(IInputColor), ((Me.Width / 2) - (e.Graphics.MeasureString(TemporaryVal, Me.Font).Width / 2)), 2)
        DrawUpButton(e.Graphics, Me.Width - 17, 4)
        DrawDownButton(e.Graphics, 4, 4)
    End Sub

    Sub DrawUpButton(ByRef e As Graphics, ByVal XPos As Integer, ByVal YPos As Integer)
        e.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias
        If UpHover Then
            e.FillEllipse(Brushes.Gainsboro, New Rectangle(XPos, YPos, 13, 13))
            e.DrawEllipse(Pens.Gray, New Rectangle(XPos, YPos, 13, 13))
        End If
        e.DrawImage(My.Resources.CCIncrease, New Point(XPos + 4, YPos + 4))
    End Sub

    Sub DrawDownButton(ByRef e As Graphics, ByVal XPos As Integer, ByVal YPos As Integer)
        e.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias
        If DownHover Then
            e.FillEllipse(Brushes.Gainsboro, New Rectangle(XPos, YPos, 13, 13))
            e.DrawEllipse(Pens.Gray, New Rectangle(XPos, YPos, 13, 13))
        End If
        e.DrawImage(My.Resources.CCDecrease, New Point(XPos + 4, YPos + 4))
    End Sub

#End Region

#Region "Mouse Events"

    Protected Overrides Sub OnMouseMove(ByVal e As System.Windows.Forms.MouseEventArgs)
        Dim MouseLocation As Point = Me.PointToClient(Cursor.Position)
        UpHover = New Rectangle(Me.Width - 17, 4, 13, 13).Contains(MouseLocation)
        DownHover = New Rectangle(4, 4, 13, 13).Contains(MouseLocation)
        Invalidate()
        MyBase.OnMouseMove(e)
    End Sub

    Protected Overrides Sub OnMouseDown(ByVal e As System.Windows.Forms.MouseEventArgs)
        HeldTimer.Enabled = True
        HeldTime = 0
        MyBase.OnMouseDown(e)
    End Sub

    Protected Overrides Sub OnMouseUp(ByVal e As System.Windows.Forms.MouseEventArgs)
        HeldTimer.Enabled = False
        HeldTime = 0
        MyBase.OnMouseUp(e)
    End Sub

#End Region

    Private Sub InitializeComponent()
        Me.SuspendLayout()
        '
        'SexyNumeric
        '
        Me.Name = "SexyNumeric"
        Me.Size = New System.Drawing.Size(150, 24)
        Me.ResumeLayout(False)

    End Sub
End Class
