Module JimbosKeyLib

    Class KeyElement
        Public Descriptor As String
        Public Firer As UInt16
        Sub New(ByVal PDescriptor As String, ByVal PFirer As UInt16)
            Descriptor = PDescriptor
            Firer = PFirer
        End Sub
    End Class

    Public DFKeys As New List(Of KeyElement)

    Sub AddKey(ByVal Descriptor As String, ByVal Firer As UInt16)
        Dim NE As New KeyElement(Descriptor, Firer)
        DFKeys.Add(NE)
    End Sub

    Sub InitKeys()
        AddKey("Left Arrow", Keys.Left)
        AddKey("Right Arrow", Keys.Right)
        AddKey("Up Arrow", Keys.Up)
        AddKey("Down Arrow", Keys.Down)
        AddKey("Space", Keys.Space)
        AddKey("Enter", Keys.Return)
        AddKey("Escape", Keys.Escape)
    End Sub

End Module
