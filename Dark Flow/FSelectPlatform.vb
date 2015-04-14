Imports System.IO

Public Class FSelectPlatform

    Public SelectedPlatform As String = String.Empty
    Public FoundAt As String = String.Empty

    Private Sub DCancelButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DCancelButton.Click
        SelectedPlatform = String.Empty
        Close()
    End Sub

    Dim BoxWidth As Byte = 80

    Sub AddButton(ByRef ThePlatform As Object, ByVal XPosition As UInt16, ByVal YPosition As UInt16)
        Dim T As Platform = DirectCast(ThePlatform, Platform)
        Dim D As New SexyButton
        With D
            .DText = T.Name
            .Tag = T.EXEPath
            .Name = T.Name.Replace(" ", String.Empty) + "Button"
            .Size = New Size(BoxWidth, 90)
            .Location = New Point(XPosition, YPosition)
            .ImageOnTop = True
            .XIMage = T.Icon
            .Enabled = File.Exists(AppPath + "PlatformProfiles\" + T.EXEPath)
        End With
        Controls.Add(D)
        AddHandler D.Click, AddressOf ButtonClick
    End Sub

    Sub ButtonClick(ByVal Sender As Object, ByVal e As System.EventArgs)
        SelectedPlatform = DirectCast(Sender, SexyButton).DText
        Close()
    End Sub

    Private Sub FSelectPlatform_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        ReCenter(Me)
        BackColor = CrucialColor
        HideTitleBar(Me)

        Dim BrowserCount As UInt16 = 0
        Dim ConsoleCount As UInt16 = 0
        For Each X As Platform In Platforms
            If X.Category = PlatformCategory.Browser Then
                BrowserCount += 1
            End If
            If X.Category = PlatformCategory.Runner Then
                ConsoleCount += 1
            End If
        Next
        BrowserCount = 3
        ConsoleCount = 1

        Dim Start As Int16 = (ClientRectangle.Width - (BrowserCount * BoxWidth)) / 2
        Dim U As UInt16 = 0
        Dim J As UInt16 = 8
        For Each X As Platform In Platforms
            If X.Category = PlatformCategory.Runner Then
                'AddButton(X, Start + (U * BoxWidth), 75)
                AddButton(X, J, 75)
                J += 75 + 8
                U += 1
            End If
        Next
        Start = (ClientRectangle.Width - (ConsoleCount * BoxWidth)) / 2
        U = 0
        J = 8
        For Each X As Platform In Platforms
            If X.Category = PlatformCategory.Browser Then
                'AddButton(X, Start + (U * BoxWidth), 210)
                AddButton(X, J, 210)
                J += 75 + 8
                U += 1
            End If
        Next

    End Sub

End Class