Module DActions

    Function Count_Instances(ByVal DObject As String) As UInt16
        Dim Returnable As UInt16 = 0
        For I As UInt16 = 0 To CusA.Instances.Count - 1
            If DF_Ignore(I) Then Continue For
            If CusA.Instances(I).InUse And CusA.Instances(I).ObjectName = DObject Then Returnable += 1
        Next
        Return Returnable
    End Function

    Function Object_Under_Point(ByVal X As Int32, ByVal Y As Int32, ByVal DObject As String) As Boolean
        For I As UInt16 = 0 To CusA.Instances.Count - 1
            If DF_Ignore(I) Then Continue For
            Dim IX As Int32 = CusA.Instances(I).X
            Dim IY As Int32 = CusA.Instances(I).Y
            Dim IW As UInt16 = CusA.Instances(I).Width
            Dim IH As UInt16 = CusA.Instances(I).Height
            If CusA.Instances(I).ObjectName = DObject And X >= IX And X < (IX + IW) And Y >= IY And Y < (IY + IH) Then Return True
        Next
        Return False
    End Function

    Function Object_Under_H_Line(ByVal X1 As Int16, ByVal X2 As Int16, ByVal Y As Int16, ByVal DObject As String) As Boolean
        For I As UInt16 = 0 To CusA.Instances.Count - 1
            If DF_Ignore(I) Then Continue For
            Dim O As UInt16 = CusA.Instances(I).ObjectName
            Dim DX As Int16 = CusA.Instances(I).X
            Dim DY As UInt16 = CusA.Instances(I).Y
            Dim DW As Int16 = CusA.Instances(I).Width
            Dim DH As Int16 = CusA.Instances(I).Height
            If O = DObject And CusA.Instances(I).X > X1 - DW And DX < X2 And DY <= Y And DY + DH >= Y Then Return True
        Next
        Return False
    End Function

    Function Object_Under_V_Line(ByVal Y1 As Int16, ByVal Y2 As Int16, ByVal X As Int16, ByVal DObject As String) As Boolean
        For I As UInt16 = 0 To CusA.Instances.Count - 1
            If DF_Ignore(I) Then Continue For
            Dim O As UInt16 = CusA.Instances(I).ObjectName
            Dim DX As Int16 = CusA.Instances(I).X
            Dim DY As UInt16 = CusA.Instances(I).Y
            Dim DW As Int16 = CusA.Instances(I).Width
            Dim DH As Int16 = CusA.Instances(I).Height
            If O = DObject And DY > Y1 - DH And DY < Y2 And DX <= X And DX + DW >= X Then Return True
        Next
        Return False
    End Function

    Function Object_At_Position(ByVal ObjectName As String, ByVal X As Int16, ByVal Y As Int16) As Boolean
        For I As UInt16 = 0 To CusA.Instances.Count - 1
            If DF_Ignore(I) Then Continue For
            If CusA.Instances(I).ObjectName = ObjectName And CusA.Instances(I).X = X And CusA.Instances(I).Y = Y Then Return True
        Next
        Return False
    End Function

    Function Test_Chance(ByVal Sides As UInt16) As Int32
        Return (Random(1, Sides) = 1)
    End Function

    Function Is_Divisible(ByVal Input As Int16, ByVal Divisor As Int16) As Boolean
        Return ((Input Mod Divisor) = 0)
    End Function

End Module
