Imports System.IO
Public Class FAction

    Public UseData As Boolean = False
    Public ActionName As String
    Public ArgumentString As String
    Public AppliesTo As String

    Public ParentPoint As Point
    Public ParentWidth As UInt16
    Public ParentHeight As UInt16

    'Public Caller As Control

    Sub EnterHandler(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If e.KeyChar = ChrW(Keys.Return) Then
            DOKButton_Click()
        End If
    End Sub

    Private Sub Action_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Icon = ImageToIcon(My.Resources.ObjectIcon)

        UseData = False
        InstancesOfDropper.Text = String.Empty
        Text = ActionName
        Dim DOn As Byte = 0

        Size = New Size(250, 211)
        LovelyContainer.Size = New Size(ClientRectangle.Width, 150)
        LovelyContainer.Location = New Point(0, 0)
        LabelsPanel.Height = 30
        ControlsPanel.Height = 30
        DOKButton.Location = New Point(133, 156)

        MatchFindName = ActionName
        Height = ControlsPanel.Location.Y + ((DActions.Find(AddressOf MatchAction).Arguments.Count + 1) * 30) + 37
        LovelyContainer.Height = Me.ClientRectangle.Height - 37
        DOKButton.Location = New Point(DOKButton.Location.X, Me.ClientRectangle.Height - DOKButton.Height)

        'Location = ReCenterParentCoOrds(Width, Height, ParentHeight, ParentWidth, ParentPoint)

        MatchFindName = ActionName

        For Each X As DArgument In DActions.Find(AddressOf MatchAction).CloneMe().Arguments 'write protection bodge
            Dim NewLabel As New Label
            NewLabel.Text = X.Name
            NewLabel.Location = New Point(0, 8 + (DOn * 30))
            LabelsPanel.Controls.Add(NewLabel)
            Dim InputControl As Control
            Dim TheContent As String = iGet(ArgumentString, DOn, CS)
            'Quick bodge for 'old' actions
            If X.Type.Length = 1 Then X.Type = "Generic"
            If X.Type = "Generic" Then
                InputControl = New SexyTextBox
                DirectCast(InputControl, SexyTextBox).Location = New Point(0, 3 + (DOn * 30))
                DirectCast(InputControl, SexyTextBox).BackColor = Color.Transparent
                InputControl.Name = "Generic" + DOn.ToString
                AddHandler DirectCast(InputControl, SexyTextBox).DKeyPress, AddressOf EnterHandler
            Else
                InputControl = New SexyComboBox
                DirectCast(InputControl, SexyComboBox).Location = New Point(0, 3 + (DOn * 30))
                InputControl.Height = 25
            End If
            InputControl.Width = ControlsPanel.Width
            If X.Type = "TrueFalse" Then
                If TheContent = "1" Then TheContent = "True"
                If TheContent = "0" Then TheContent = "False"
                DirectCast(InputControl, SexyComboBox).BackCombo.Items.Add("True")
                DirectCast(InputControl, SexyComboBox).BackCombo.Items.Add("False")
                InputControl.Name = "TrueFalse" + DOn.ToString
            ElseIf X.Type = "Image" Then
                With DirectCast(InputControl, SexyComboBox)
                    For Each D As DImage In Images
                        .BackCombo.Items.Add(D.Name)
                    Next
                    .Name = "Image" + DOn.ToString
                    .Image = My.Resources.ImageIcon
                End With

            ElseIf X.Type = "Object" Then
                With DirectCast(InputControl, SexyComboBox)
                    For Each D As DObject In Objects
                        .BackCombo.Items.Add(D.Name)
                    Next
                    .Name = "Object" + DOn.ToString
                    .Image = My.Resources.ObjectIcon
                End With
            ElseIf X.Type = "Scene" Then
                With DirectCast(InputControl, SexyComboBox)
                    For Each D As Scene In Scenes
                        .BackCombo.Items.Add(D.Name)
                    Next
                    .Name = "Scene" + DOn.ToString
                    .Image = My.Resources.SceneIcon
                End With
            ElseIf X.Type = "Sound" Then
                With DirectCast(InputControl, SexyComboBox)
                    For Each D As Sound In Sounds
                        .BackCombo.Items.Add(D.Name)
                    Next
                    .Name = "Sound" + DOn.ToString
                    .Image = My.Resources.SoundIcon
                End With
            ElseIf X.Type = "Platform" Then
                With DirectCast(InputControl, SexyComboBox)
                    .Name = "Platform" + DOn.ToString
                    .Image = My.Resources.JoyStick
                    For Each P In Platforms
                        If P.EXEPath.Length > 0 Then
                            .BackCombo.Items.Add(P.Name)
                        End If
                    Next
                End With
            End If
            If X.Type = "Generic" Then
                DirectCast(InputControl, SexyTextBox).Text = TheContent
            Else
                DirectCast(InputControl, SexyComboBox).Text = TheContent
            End If
            ControlsPanel.Controls.Add(InputControl)
            DOn += 1
        Next

        InstancesOfDropper.BackCombo.Items.Clear()
        For Each X As DObject In Objects
            InstancesOfDropper.BackCombo.Items.Add(X.Name)
        Next
        Dim CheckedSomething As Boolean = False
        If AppliesTo = "this" Then
            ThisRadioButton.Checked = True
            CheckedSomething = True
        ElseIf AppliesTo = "other" Then
            OtherRadioButton.Checked = True
            CheckedSomething = True
        ElseIf IsObject(AppliesTo) Then
            InstancesOfRadioButton.Checked = True
            InstancesOfDropper.Text = AppliesTo
            CheckedSomething = True
        End If

        If Not CheckedSomething Then ThisRadioButton.Checked = True

        LabelsPanel.Visible = (DOn > 0)
        ControlsPanel.Visible = (DOn > 0)

        If DOn > 0 Then
            ControlsPanel.Height = DOn * 30
            LabelsPanel.Height = ControlsPanel.Height
        End If

        GlobalGlass(Me, True, False)

    End Sub

    Sub ClearMyControls()
        LabelsPanel.Controls.Clear()
        For Each P As Control In ControlsPanel.Controls
            If P.Name.StartsWith("Generic") Then
                RemoveHandler DirectCast(P, SexyTextBox).DKeyPress, AddressOf EnterHandler
            End If
        Next
        ControlsPanel.Controls.Clear()
    End Sub

    Private Sub DOKButton_Click() Handles DOKButton.Click

        If ControlsPanel.Visible Then
            Dim Focusable As String = String.Empty
            For Each X As Control In ControlsPanel.Controls
                If X.Text.Length = 0 Then
                    MsgWarn("You must put something in every Argument box or selector.")
                    Focusable = X.Name
                    Exit For
                End If
            Next
            If Focusable.Length > 0 Then
                For Each X As Control In ControlsPanel.Controls
                    If X.Name = Focusable And Focusable.StartsWith("Generic") Then X.Focus() : Exit For
                Next
                Exit Sub
            End If
        End If
        ArgumentString = String.Empty
        If ThisRadioButton.Checked Then
            AppliesTo = "this"
        ElseIf InstancesOfRadioButton.Checked Then
            AppliesTo = InstancesOfDropper.Text
        ElseIf OtherRadioButton.Checked Then
            AppliesTo = "other"
        End If
        UseData = True
        If ControlsPanel.Controls.Count > 0 Then
            For Each X As Control In ControlsPanel.Controls
                Dim TheText As String = X.Text
                If X.Name.StartsWith("TrueFalse") Then
                    If TheText = "True" Then TheText = "1"
                    If TheText = "False" Then TheText = "0"
                End If
                ArgumentString += TheText + CS
            Next
            ArgumentString = ArgumentString.Substring(0, ArgumentString.Length - 1)
        End If

        ClearMyControls()

        Close()

    End Sub

    Private Sub ThisRadioButton_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ThisRadioButton.CheckedChanged
        InstancesOfDropper.Enabled = False
    End Sub

    Private Sub InstancesOfRadioButton_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles InstancesOfRadioButton.CheckedChanged
        InstancesOfDropper.Enabled = DirectCast(sender, RadioButton).Checked
        If DirectCast(sender, RadioButton).Checked And InstancesOfDropper.Text.Length = 0 Then
            InstancesOfDropper.FrontSkin_MouseDown(InstancesOfDropper, New MouseEventArgs(Windows.Forms.MouseButtons.Left, 1, 0, 0, 1))
            InstancesOfDropper.FrontSkin_Click(InstancesOfDropper, New System.EventArgs)
        End If
    End Sub

    Private Sub FormAction_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        ClearMyControls()
    End Sub

    Private Sub FAction_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown
        If ControlsPanel.Controls.Count > 0 Then
            ControlsPanel.Controls(0).Focus()
        End If
    End Sub

End Class