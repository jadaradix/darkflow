Module JimbosKeyLib

    Public DFKeyIdentifiers As New List(Of String)
    Public DFKeyVariables As New List(Of String)

    Sub InitKeys()
        With DFKeyIdentifiers
            .Add("Up Arrow")
            .Add("Down Arrow")
            .Add("Left Arrow")
            .Add("Right Arrow")
            .Add("Space")
            .Add("Enter")
            .Add("Escape")
        End With
        With DFKeyVariables
            .Add("Key_Up")
            .Add("Key_Down")
            .Add("Key_Left")
            .Add("Key_Right")
            .Add("Key_Space")
            .Add("Key_Enter")
            .Add("Key_Escape")
        End With
    End Sub

End Module
