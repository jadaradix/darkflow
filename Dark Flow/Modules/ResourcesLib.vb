Imports System.IO

Module ResourcesLib

    Public DefaultObjectToPlot As String = String.Empty

    Public Enum ResourceType
        Image = 0
        DObject = 1
        Scene = 2
        Sound = 3
    End Enum

    Sub InitResourcesList()
        MainForm.ResourcesList.ImageList = GlobalImages
        For Each Resource As String In ResourceTypes
            Dim ResourceNode As New TreeNode
            With ResourceNode
                .ImageIndex = 0
                .SelectedImageIndex = 0
                .Name = "ResourceParent"
                .Text = Resource + "s"
                MainForm.ResourcesList.Nodes.Add(ResourceNode)
            End With
        Next
    End Sub

    Function GenerateResourceName(ByVal Prefix As String, ByVal IResourceType As Byte)
        Dim I As UInt16 = 1
        While GUIResNameChecker(Prefix + I.ToString, False)
            I += 1
        End While
        Return Prefix + I.ToString
    End Function

    Function ShowResourceEditMessage(ByVal ResourceName As String) As Byte
        Dim Message As String = "'" + ResourceName + "' has been opened. When you are finished, click 'OK'." + vbNewLine + vbNewLine + "To reverse any changes, please click 'Cancel'."
        Dim Response As Byte = MessageBox.Show(Message, Application.ProductName, MessageBoxButtons.OKCancel, MessageBoxIcon.Information)
        Return Response
    End Function

    Function AddResource(ByVal IResourceType As Byte, ByVal RealChange As Boolean, ByVal Quietly As Boolean) As String
        Dim Prefix As String = ResourceTypes(IResourceType) + "_"
        Dim NewName As String = GenerateResourceName(Prefix, IResourceType)
        Dim NewNode As New TreeNode
        With NewNode
            .ImageIndex = IResourceType + 1
            .SelectedImageIndex = IResourceType + 1
            .Text = NewName
            .Name = NewName
        End With
        Select Case IResourceType
            Case ResourceType.Image
                Dim NewImage As New DarkLib.DImage(NewName, 64)
                With NewImage
                    If GetOption("ALPHA_CAPABLE") = "1" Then
                        .Data = My.Resources.DefaultImage
                    Else
                        .Data = My.Resources.DefaultImageNoAA
                    End If
                End With
                Images.Add(NewImage)
            Case ResourceType.DObject
                Dim MyEvents As New List(Of DEvent)
                MyEvents.Add(New DEvent("Create", String.Empty, New List(Of String)))
                Dim NewObject As New DObject(NewName, String.Empty, 0, MyEvents, 0)
                Objects.Add(NewObject)
            Case ResourceType.Scene
                Dim NewScene As New Scene(NewName, 320, 240, 320, 240, 0, 0, 232, 232, 232, String.Empty, String.Empty)
                Scenes.Add(NewScene)
            Case ResourceType.Sound
                Dim NewSound As New Sound(NewName, My.Resources.DefaultSound)
                Sounds.Add(NewSound)
        End Select
        MainForm.ResourcesList.Nodes(IResourceType).Nodes.Add(NewNode)
        If Not Quietly Then MainForm.OpenResource(NewNode)
        MainForm.ResourcesList.Nodes(IResourceType).Expand()
        If RealChange Then ChangeMade = True
        Return NewName
    End Function

    Function IsAlreadyResource(ByVal DName As String) As Boolean
        For Each P As TreeNode In MainForm.ResourcesList.Nodes
            For Each F As TreeNode In P.Nodes
                If F.Text = DName Then Return True
            Next
        Next
        Return False
    End Function

    Function GetObjectSize(ByVal ObjectName As String) As Size
        Dim W As Int16 = 16
        Dim H As Int16 = 16
        For Each P As DObject In Objects
            If Not P.Name = ObjectName Then Continue For
            If P.ImageName.Length = 0 Then
                Return New Size(32, 32)
            Else
                For Each D As DImage In Images
                    If Not D.Name = P.ImageName Then Continue For
                    W = D.Data.Width
                    H = D.FrameHeight
                    Exit For
                Next
                Return New Size(W, H)
            End If
            Exit For
        Next
    End Function

    Function GUIResNameChecker(ByVal TheName As String, Optional ByVal ShowMessage As Boolean = True) As Boolean
        If IsAlreadyResource(TheName) Then
            If ShowMessage Then
                MsgError("There is already a Resource called '" + TheName + "'." + vbNewLine + vbNewLine + "You must choose another name.")
            End If
            Return True
        Else
            If TheName.StartsWith("DF_") Then
                If ShowMessage Then
                    MsgError("The name may not start with DF_.")
                End If
                Return True
            End If
            If Not ValidateSomething(TheName, ValidateLevel.Tight) Then
                If ShowMessage Then
                    MsgError("The name may not contain a space or other unusual character.")
                End If
                Return True
            End If
            If Not ValidateSomething(TheName, ValidateLevel.NumberStart) Then
                If ShowMessage Then
                    MsgError("The name may not start with a number.")
                End If
                Return True
            End If
        End If
        Return False
    End Function

End Module
