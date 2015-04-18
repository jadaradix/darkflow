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

    Function MakeProHash(ByVal Input As UInt32) As UInt32
        Dim Returnable As UInt32 = Input
        Returnable *= 2
        Returnable += 5
        Return Returnable
    End Function

End Module
