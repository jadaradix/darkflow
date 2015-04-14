Imports System.Drawing.Drawing2D

Public Class FEvent

    Public EventType As String
    Public EventData As String
    Public UseData As Boolean
    Dim ListIcon As Bitmap

    Private Sub FEvent_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        GlobalGlass(Me, True, True)
        Icon = ImageToIcon(My.Resources.SettingsIcon)
        UseData = False
        InputButton_Click(InputButton, New System.EventArgs)
    End Sub

    Private Sub CreateButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CreateButton.Click
        EventType = "Create" : EventData = String.Empty
        ExitProc()
    End Sub

    Private Sub CollisionButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CollisionButton.Click
        InfoHeaderLabel.Text = "Fire on Collision with" + ":"
        EventType = "Collision"
        ListIcon = My.Resources.ObjectIcon
        OptionsList.Items.Clear()
        For Each P As DObject In Objects
            OptionsList.Items.Add(P.Name)
        Next
        TryLastItem()
    End Sub

    Private Sub InputButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles InputButton.Click
        InfoHeaderLabel.Text = "Fire on Input" + ":"
        EventType = "Input"
        ListIcon = My.Resources.EventKey
        OptionsList.Items.Clear()
        For Each P As FPlatformInputs.Input In FPlatformInputs.Inputs
            OptionsList.Items.Add(P.Name)
        Next
        TryLastItem()
    End Sub

    Private Sub StepButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StepButton.Click
        EventType = "Step" : EventData = String.Empty
        ExitProc()
    End Sub

    Private Sub PointerButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PointerButton.Click
        InfoHeaderLabel.Text = "Fire on Pointer" + ":"
        EventType = "Pointer"
        ListIcon = My.Resources.EventMouse
        OptionsList.Items.Clear()
        OptionsList.Items.Add("Click")
        OptionsList.Items.Add("Held")
        OptionsList.Items.Add("Over")
        OptionsList.Items.Add("Down")
        OptionsList.Items.Add("Up")
        TryLastItem()
    End Sub

    Private Sub AcceptButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DAcceptButton.Click
        EventData = OptionsList.Items(OptionsList.SelectedIndex)
        ExitProc()
    End Sub

    Sub TryLastItem()
        If OptionsList.Items.Count > 0 Then
            OptionsList.SelectedIndex = 0
            DAcceptButton.Enabled = True
        Else
            DAcceptButton.Enabled = False
        End If
    End Sub

    Sub ExitProc()
        UseData = True
        Close()
    End Sub

    Private Sub OptionsList_DrawItem(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DrawItemEventArgs) Handles OptionsList.DrawItem
        If e.Index < 0 Then Exit Sub
        GDIRenderItem(Color.White, False, e, 9, New Point(22, e.Bounds.Y + 3), OptionsList.Items(e.Index), ListIcon)
    End Sub

End Class