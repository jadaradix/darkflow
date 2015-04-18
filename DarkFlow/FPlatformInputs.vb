Public Class FPlatformInputs

    Dim IsInput As Boolean
    Dim IsAdd As Boolean

    Public Class Input
        Public Name As String
        Public Executors As New List(Of InputExecutor)
        Sub New(ByVal DName As String, ByVal DExecutors As List(Of InputExecutor))
            Name = DName
            Executors = DExecutors
        End Sub
        Function CloneMe() As Input
            Dim iList As New List(Of InputExecutor)
            For P As UInt16 = 0 To Executors.Count - 1
                iList.Add(Executors(P).CloneMe())
            Next
            Return New Input(Name, iList)
        End Function
    End Class
    Public Inputs As New List(Of Input)

    Class InputExecutor
        Public PlatformName As String
        Public PlatformInputIdentifier As String
        Sub New(ByVal DPlatformName As String, ByVal DPlatformInputIdentifier As String)
            PlatformName = DPlatformName
            PlatformInputIdentifier = DPlatformInputIdentifier
        End Sub
        Function CloneMe() As InputExecutor
            Return New InputExecutor(PlatformName, PlatformInputIdentifier)
        End Function
    End Class

    Sub AddInput(ByVal NewName As String)
        Inputs.Add(New Input(NewName, New List(Of InputExecutor)))
        MainList.Items.Add(NewName)
    End Sub

    Sub AddExecutor(ByVal PlatformName As String, ByVal PlatformInputIdentifier As String)
        Inputs(MainList.SelectedIndex).Executors.Add(New InputExecutor(PlatformName, PlatformInputIdentifier))
        SubList.Items.Add(PlatformName + " " + PlatformInputIdentifier)
    End Sub

    Sub DeleteInput(ByVal Position As UInt16)
        Inputs.RemoveAt(Position)
        MainList.Items.RemoveAt(Position)
    End Sub

    Private Sub FPlatformInputs_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Icon = ImageToIcon(My.Resources.JoyStick)
        ReCenter(Me)
        GlobalGlass(Me, True, True)
        MainList.Items.Clear()
        SubList.Items.Clear()
        For Each P As Input In Inputs
            MainList.Items.Add(P.Name)
        Next
        If Inputs.Count > 0 Then
            MainList.SelectedIndex = 0
        End If
    End Sub

    Private Sub MainList_DrawItem(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DrawItemEventArgs) Handles MainList.DrawItem
        If e.Index < 0 Then Exit Sub
        GDIRenderItem(Color.White, True, e, Font.Size, New Point(e.Bounds.X + 36, e.Bounds.Y + 7), Inputs(e.Index).Name, My.Resources.BigKeyIcon)
    End Sub

    Private Sub SubList_DrawItem(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DrawItemEventArgs) Handles SubList.DrawItem
        If e.Index < 0 Then Exit Sub
        If MainList.SelectedIndices.Count = 0 Then Exit Sub
        If Not e.Index < Inputs(MainList.SelectedIndex).Executors.Count Then Exit Sub
        Dim TempExecutor As InputExecutor = Inputs(MainList.SelectedIndex).Executors(e.Index)
        GDIRenderItem(Color.Silver, False, e, Font.Size, New Point(e.Bounds.X + 20, e.Bounds.Y + 3), TempExecutor.PlatformName + " - " + TempExecutor.PlatformInputIdentifier, My.Resources.EventKey)
    End Sub

    Private Sub DOKButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DOKButton.Click
        Close()
    End Sub

    Function IsInputNameFree(ByVal InputName As String) As Boolean
        If Inputs.Count = 0 Then Return True
        For I As UInt16 = 0 To Inputs.Count - 1
            If Inputs(I).Name = InputName Then Return False
        Next
        Return True
    End Function

    Sub ClearOutControls()
        For P As UInt16 = 0 To DataPanel.Controls.Count - 1
            If DataPanel.Controls(P).Name = "InputBox" Then
                RemoveHandler CType(DataPanel.Controls(P), SexyTextBox).DKeyPress, AddressOf InputNameHandler
                RemoveHandler CType(DataPanel.Controls(P), SexyTextBox).DTextChanged, AddressOf InputNameHandler2
            ElseIf DataPanel.Controls(P).Name = "PlatformDropper" Then
                RemoveHandler CType(DataPanel.Controls(P), SexyComboBox).SelectedIndexChanged, AddressOf ExecutorHandler
            End If
        Next
        Dim CTLList(DataPanel.Controls.Count - 1) As Control
        DataPanel.Controls.CopyTo(CTLList, 0)
        For Each P As Control In Array.FindAll(CTLList, AddressOf ControlFits)
            DataPanel.Controls.Remove(P)
        Next
    End Sub

    Sub SetUpInputControls(ByVal DefaultName As String)
        ClearOutControls()
        IsInput = True
        Dim NL As New SexyGDILabel
        With NL
            .Location = New Point(3, 19)
            .Size = New Size(194, 16)
            .DText = "Name:"
            .Name = "InputLabel"
        End With
        Dim NT As New SexyTextBox
        With NT
            .Location = New Point(3, 38)
            .BackColor = Color.Transparent
            .Text = DefaultName
            .Size = New Size(194, 24)
            .Name = "InputBox"
        End With
        AddHandler NT.DKeyPress, AddressOf InputNameHandler
        AddHandler NT.DTextChanged, AddressOf InputNameHandler2
        With DataPanel
            .Controls.Add(NL)
            .Controls.Add(NT)
            .Visible = True
        End With
        NT.TextContainer.Focus()
    End Sub

    Dim IIToSet As String = String.Empty

    Sub SetUpExecutorControls(ByVal DPlatformName As String, ByVal DPlatformII As String)
        ClearOutControls()
        IsInput = False
        Dim PlatformDropper As New SexyComboBox
        With PlatformDropper
            .Location = New Point(3, 16)
            .Size = New Size(194, 24)
            .Image = My.Resources.SettingsIcon
            .Name = "PlatformDropper"
        End With
        For Each P As Platform In Platforms
            If P.Inputs.Count = 0 Then Continue For
            PlatformDropper.BackCombo.Items.Add(P.Name)
        Next
        AddHandler PlatformDropper.SelectedIndexChanged, AddressOf ExecutorHandler
        Dim ExecutorDropper As New SexyComboBox
        With ExecutorDropper
            .Location = New Point(3, 42)
            .Size = New Size(194, 24)
            .Image = My.Resources.EventKey
            .Name = "ExecutorDropper"
        End With
        With DataPanel
            .Controls.Add(PlatformDropper)
            .Controls.Add(ExecutorDropper)
            .Visible = True
        End With
        IIToSet = String.Empty
        If DPlatformII.Length > 0 Then IIToSet = DPlatformII
        If DPlatformName.Length > 0 Then
            PlatformDropper.Text = DPlatformName
        Else
            PlatformDropper.BackCombo.SelectedIndex = 0
        End If
    End Sub

    Sub InputNameHandler(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If e.KeyChar = ChrW(Keys.Return) Then
            DataAcceptButton_Click()
        End If
    End Sub

    Sub InputNameHandler2(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim ShouldBeAllowed As Boolean = True
        Dim TMP As TextBox = CType(sender, TextBox)
        ShouldBeAllowed = (TMP.Text.Length > 0)
        If Not IsInputNameFree(TMP.Text) Then ShouldBeAllowed = False
        DataAcceptButton.Enabled = ShouldBeAllowed
    End Sub

    Sub ExecutorHandler(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim PlatformName As String = CType(sender, SexyDropper).Text
        Dim PlatformID As UInt16 = 0
        Dim DoIt As Boolean = False
        For P As UInt16 = 0 To Platforms.Count - 1
            If Platforms(P).Name = PlatformName Then PlatformID = P : DoIt = True : Exit For
        Next
        If Not DoIt Then Exit Sub
        For Each P As Control In DataPanel.Controls
            If P.Name = "ExecutorDropper" Then
                CType(P, SexyComboBox).BackCombo.Items.Clear()
                Dim NoAdded As UInt16 = 0
                For Each D As String In Platforms(PlatformID).Inputs
                    CType(P, SexyComboBox).BackCombo.Items.Add(D)
                    NoAdded += 1
                Next
                If IIToSet.Length > 0 Then
                    CType(P, SexyComboBox).BackCombo.Text = IIToSet
                Else
                    If NoAdded > 0 Then CType(P, SexyComboBox).BackCombo.SelectedIndex = 0
                End If
            End If
        Next
    End Sub

    Private Sub AddInputButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddInputButton.Click
        Dim Prefix As String = "Input_"
        Dim NID As UInt16 = 0
        While Not IsInputNameFree(Prefix + NID.ToString)
            NID += 1
        End While
        IsAdd = True
        SetUpInputControls(Prefix + NID.ToString)
    End Sub

    Private Sub EditInputButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditInputButton.Click
        If MainList.SelectedIndices.Count = 0 Then Exit Sub
        IsAdd = False
        SetUpInputControls(Inputs(MainList.SelectedIndex).Name)
    End Sub

    Private Sub DeleteInputButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteInputButton.Click
        If MainList.SelectedIndices.Count = 0 Then Exit Sub
        If IsInput Then DataPanel.Visible = False
        Dim OldName As String = Inputs(MainList.SelectedIndex).Name
        DeleteInput(MainList.SelectedIndex)
        For Each P As DObject In Objects
            For Each I As DEvent In P.Events
                If I.EventType = "Input" And I.EventData = OldName Then
                    I.EventData = "<Unknown>"
                End If
            Next
        Next
        For Each P As Form In MainForm.MdiChildren
            If P.Name = "FObject" Then
                CType(P, FObject).RenameInput(OldName, "<Unknown>")
            End If
        Next
        If Inputs.Count > 0 Then MainList.SelectedIndex = 0
    End Sub

    Private Sub AddExecutorButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddExecutorButton.Click
        If MainList.SelectedIndices.Count = 0 Then Exit Sub
        IsAdd = True
        SetUpExecutorControls(String.Empty, String.Empty)
    End Sub

    Private Sub EditExecutorButton_Click() Handles EditExecutorButton.Click
        If MainList.SelectedIndices.Count = 0 Then Exit Sub
        If SubList.SelectedIndices.Count = 0 Then Exit Sub
        IsAdd = False
        SetUpExecutorControls(Inputs(MainList.SelectedIndex).Executors(SubList.SelectedIndex).PlatformName, Inputs(MainList.SelectedIndex).Executors(SubList.SelectedIndex).PlatformInputIdentifier)
    End Sub

    Private Sub DeleteExecutorButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteExecutorButton.Click
        If MainList.SelectedIndices.Count = 0 Then Exit Sub
        If SubList.SelectedIndices.Count = 0 Then Exit Sub
        If Not IsInput Then DataPanel.Visible = False
        Dim NI As UInt16 = MainList.SelectedIndex
        Dim SNI As UInt16 = SubList.SelectedIndex
        Inputs(NI).Executors.RemoveAt(SNI)
        SubList.Items.RemoveAt(SNI)
        If Inputs(NI).Executors.Count > 0 Then SubList.SelectedIndex = 0
    End Sub

    Function ControlFits(ByVal CTL As Control) As Boolean
        Return Not CTL.Name = "DataAcceptButton"
    End Function

    Private Sub DataAcceptButton_Click() Handles DataAcceptButton.Click
        Dim Data1 As String = String.Empty
        Dim Data2 As String = String.Empty
        For P As UInt16 = 0 To DataPanel.Controls.Count - 1
            If DataPanel.Controls(P).Name = "InputBox" Then
                Data1 = CType(DataPanel.Controls(P), SexyTextBox).Text
            ElseIf DataPanel.Controls(P).Name = "PlatformDropper" Then
                Data1 = CType(DataPanel.Controls(P), SexyComboBox).Text
            ElseIf DataPanel.Controls(P).Name = "ExecutorDropper" Then
                Data2 = CType(DataPanel.Controls(P), SexyComboBox).Text
            End If
        Next
        If IsInput Then
            If IsAdd Then
                AddInput(Data1)
                MainList.SelectedIndex = MainList.Items.Count - 1
            Else
                Dim OldName As String = Inputs(MainList.SelectedIndex).Name
                Inputs(MainList.SelectedIndex).Name = Data1
                MainList.Items(MainList.SelectedIndex) = Data1
                For Each P As DObject In Objects
                    For Each I As DEvent In P.Events
                        If I.EventType = "Input" And I.EventData = OldName Then
                            I.EventData = Data1
                        End If
                    Next
                Next
                For Each P As Form In MainForm.MdiChildren
                    If P.Name = "FObject" Then
                        CType(P, FObject).RenameInput(OldName, Data1)
                    End If
                Next
            End If
        Else
            If IsAdd Then
                Dim NewID As UInt16 = 0
                Dim DidExist As Boolean = False
                If Inputs(MainList.SelectedIndex).Executors.Count > 0 Then
                    For U As UInt16 = 0 To Inputs(MainList.SelectedIndex).Executors.Count - 1
                        Dim TempExc As InputExecutor = Inputs(MainList.SelectedIndex).Executors(U)
                        If TempExc.PlatformName = Data1 And TempExc.PlatformInputIdentifier = Data2 Then NewID = U : DidExist = True : Exit For
                    Next
                End If
                If DidExist Then
                    SubList.SelectedIndex = NewID
                Else
                    AddExecutor(Data1, Data2)
                    SubList.SelectedIndex = SubList.Items.Count - 1
                End If
            Else
                Inputs(MainList.SelectedIndex).Executors(SubList.SelectedIndex).PlatformName = Data1
                Inputs(MainList.SelectedIndex).Executors(SubList.SelectedIndex).PlatformInputIdentifier = Data2
                SubList.Items(SubList.SelectedIndex) = Data1 + " " + Data2
            End If
        End If
        DataPanel.Visible = False
    End Sub

    Private Sub DataPanel_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles DataPanel.Paint
        e.Graphics.TextRenderingHint = Drawing.Text.TextRenderingHint.ClearTypeGridFit
    End Sub

    Private Sub MainList_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MainList.SelectedIndexChanged
        SubList.SelectedIndices.Clear()
        SubList.Items.Clear()
        If MainList.SelectedIndices.Count = 0 Then Exit Sub
        Dim NI As UInt16 = MainList.SelectedIndex
        If Inputs(NI).Executors.Count = 0 Then Exit Sub
        For P As UInt16 = 0 To Inputs(NI).Executors.Count - 1
            Dim Temp As InputExecutor = Inputs(NI).Executors(P)
            SubList.Items.Add(Temp.PlatformName + " " + Temp.PlatformInputIdentifier)
        Next
        If SubList.Items.Count > 0 Then SubList.SelectedIndex = 0
        If Not IsAdd Then DataPanel.Visible = False
    End Sub

    Private Sub SubList_MouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles SubList.MouseDoubleClick
        Dim MouseY As UInt16 = e.Location.Y
        If MouseY <= 0 Then Exit Sub
        If MouseY > (SubList.Items.Count * SubList.ItemHeight) Then Exit Sub
        EditExecutorButton_Click()
    End Sub

    Private Sub EditExecutorButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditExecutorButton.Click

    End Sub
    Private Sub DataAcceptButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DataAcceptButton.Click

    End Sub
End Class