Imports System.IO
Imports System.Drawing

Module ODFXWork

    Enum LineType
        Image = 0
        DObject = 1
        Scene = 2
        Sound = 3
        Script = 4
        DEvent = 5
        Action = 6
        Instance = 7
        Setting = 8
        ScriptArg = 9
        Input = 10
        InputExecutor = 11
    End Enum

    Enum BinaryDataType
        Image = 1
        Sound = 2
        Generic = 3
    End Enum

    Sub ExpandArray(ByRef TheArray() As Byte, ByVal ElementCount As UInt64)
        Array.Resize(TheArray, TheArray.Length + ElementCount)
    End Sub

    Function MakeProHash(ByVal Input As UInt32) As UInt32
        Dim Returnable As UInt32 = Input
        Returnable *= 2
        Returnable += 5
        Return Returnable
    End Function

    Function BMPToMemory(ByVal TBMP As Bitmap) As Byte()
        Dim RMS As New MemoryStream
        TBMP.Save(RMS, Imaging.ImageFormat.Png)
        Dim BA() As Byte = RMS.GetBuffer()
        'TBMP.Dispose() 'Well, we expected this, Dr. Garner.
        RMS.Close()
        Return BA
    End Function

    Function MemoryToBMP(ByVal ThoseBytes() As Byte) As Bitmap
        Dim MyMemory As New MemoryStream(ThoseBytes, False)
        Dim MyBinaryReader As BinaryReader = New BinaryReader(MyMemory)
        Dim FinalData() As Byte = MyBinaryReader.ReadBytes(CType(MyMemory.Length, Integer))
        MyBinaryReader.Close()
        MyMemory.Close()
        Return New Bitmap(System.Drawing.Image.FromStream(New MemoryStream(FinalData)))
    End Function

End Module
