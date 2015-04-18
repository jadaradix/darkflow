Imports System.Drawing

Module MainMod

    Public MyVersion As Byte = 103

    Public ParentSplitter As Byte = 30
    Public ChildSplitter As Byte = 31

    Dim CP As String = Chr(ParentSplitter)
    Dim CC As String = Chr(ChildSplitter)

    Dim CommandSep As String = Chr(11)
    Dim ArgSep As String = Chr(12)

    Dim Folder As String = String.Empty

    Function PathToImage(ByVal path As String) As Image
        Dim imgData() As Byte = SafeGetFileData(path)
        Return New Bitmap(System.Drawing.Image.FromStream(New MemoryStream(imgData)))
    End Function

    Function SafeGetFileData(ByVal filePath As String) As Byte()
        Dim MyFileStream As FileStream = New FileStream(filePath, FileMode.Open, FileAccess.Read)
        Dim MyBinaryReader As BinaryReader = New BinaryReader(MyFileStream)
        Dim FinalData() As Byte = MyBinaryReader.ReadBytes(CType(MyFileStream.Length, Integer))
        MyBinaryReader.Close()
        MyFileStream.Close()
        Return FinalData
    End Function

    Sub Main()

        If Not My.Application.CommandLineArgs.Count = 4 Then
            Console.WriteLine("This executable must be called with exactly 4 arguments. Exit.")
            End
        End If

        Dim LFolder As String = My.Application.CommandLineArgs(0)
        If Not Directory.Exists(LFolder) Then
            Console.WriteLine("The passed directory did not exist. Exit.")
            End
        End If

        If Not LFolder.EndsWith("\") Then LFolder += "\"
        Folder = LFolder

        Dim SGameID As String = My.Application.CommandLineArgs(1)

        Dim ActionsFolder As String = My.Application.CommandLineArgs(2)

        Dim IsPro As Boolean = (Convert.ToByte(My.Application.CommandLineArgs(3)) = 1)

        Dim GameID As UInt32 = Convert.ToUInt32(SGameID)
        Dim ProHash As UInt32 = If(IsPro, MakeProHash(GameID), 0)
        Dim GameIDArray() As Byte = BitConverter.GetBytes(GameID)
        Dim ProHashArray() As Byte = BitConverter.GetBytes(ProHash)

        Dim FinalData(0) As Byte
        Array.Resize(FinalData, 0)

        '1-4: BASIC META DATA
        ExpandArray(FinalData, 4)
        FinalData(0) = MyVersion 'RUNNER VERSION
        FinalData(1) = 0 'JUNK 1
        FinalData(2) = 0 'JUNK 2
        FinalData(3) = 0 'JUNK 3

        '5-8: GAMEID 4 BYTES
        ExpandArray(FinalData, 4)
        GameIDArray.CopyTo(FinalData, 4)

        '9-12: PROHASH 4 BYTES
        ExpandArray(FinalData, 4)
        ProHashArray.CopyTo(FinalData, 8)

        '13-16: MAGIC 4 BYTES (reads 'YoYo' just for laughs)
        ExpandArray(FinalData, 4)
        FinalData(12) = 89
        FinalData(13) = 111
        FinalData(14) = 89
        FinalData(15) = 111

        '17-18: BIN COUNT
        ExpandArray(FinalData, 2)

        Dim Images As New List(Of String)
        Dim Sounds As New List(Of String)
        Dim BinCount As UInt16 = 0

        For Each X As String In Split(IO.File.ReadAllText(Folder + "DFK.dfk"), CP)
            If X.Length = 0 Then Continue For
            Dim LS As Byte = Asc(X.Substring(0, 1))
            X = X.Substring(1)
            Select Case LS
                Case LineType.Image
                    Dim DName As String = X.Substring(0, X.IndexOf(CC))
                    Images.Add(DName)
                Case LineType.Sound
                    Sounds.Add(X)
            End Select
        Next

        Dim AllCount As UInt16 = Images.Count + Sounds.Count + BinCount

        Dim BinArray() As Byte = BitConverter.GetBytes(AllCount)
        FinalData(16) = BinArray(0)
        FinalData(17) = BinArray(1)

        Dim BlockBytesNeeded As UInt32 = AllCount * 5
        Dim WritePos As UInt64 = FinalData.Length

        ExpandArray(FinalData, BlockBytesNeeded)
        Dim ActualDataLength As UInt64 = 0

        For Each X As String In Images
            Dim FullPath As String = Folder + "Images\" + X + ".png"
            Dim MyBytesLength As UInt32 = BMPToMemory(PathToImage(FullPath)).Count
            ActualDataLength += MyBytesLength
            Dim MyBytesBytes() As Byte = BitConverter.GetBytes(MyBytesLength)
            FinalData(WritePos) = BinaryDataType.Image
            For F As Byte = 1 To 4
                FinalData(WritePos + F) = MyBytesBytes(F - 1)
            Next
            WritePos += 5
        Next

        For Each X As String In Sounds
            Dim FullPath As String = Folder + "Sounds\" + X + ".wav"
            Dim MyBytesLength As UInt32 = File.ReadAllBytes(FullPath).Count
            ActualDataLength += MyBytesLength
            Dim MyBytesBytes() As Byte = BitConverter.GetBytes(MyBytesLength)
            FinalData(WritePos) = BinaryDataType.Sound
            For F As Byte = 1 To 4
                FinalData(WritePos + F) = MyBytesBytes(F - 1)
            Next
            WritePos += 5
        Next

        ExpandArray(FinalData, ActualDataLength)

        For Each X As String In Images
            Dim FullPath As String = Folder + "Images\" + X + ".png"
            Dim ActualData() As Byte = BMPToMemory(PathToImage(FullPath))
            ActualData.CopyTo(FinalData, Convert.ToInt32(WritePos))
            WritePos += ActualData.Length
        Next

        For Each X As String In Sounds
            Dim FullPath As String = Folder + "Sounds\" + X + ".wav"
            Dim ActualData() As Byte = File.ReadAllBytes(FullPath)
            ActualData.CopyTo(FinalData, Convert.ToInt32(WritePos))
            WritePos += ActualData.Length
        Next

        Dim EventObjects As New List(Of String)
        Dim EventTypes As New List(Of String)
        Dim EventDatas As New List(Of String)
        Dim EventCodes As New List(Of String)

        Dim DFKContent As String = IO.File.ReadAllText(Folder + "DFK.dfk")
        For Each P As String In DFKContent.Split(CP)
            If Not P.StartsWith(Chr(LineType.DEvent)) Then Continue For
            P = P.Substring(1)
            Dim ObjectName As String = P.Substring(0, P.IndexOf(CC))
            P = P.Substring(ObjectName.Length + 1)
            Dim EventType As String = P.Substring(0, P.IndexOf(CC))
            P = P.Substring(EventType.Length + 1)
            Dim EventData As String = P
            EventObjects.Add(ObjectName)
            EventTypes.Add(EventType)
            EventDatas.Add(EventData)
            EventCodes.Add(String.Empty)
        Next

        If EventObjects.Count > 0 Then
            For I As UInt16 = 0 To EventObjects.Count - 1
                Dim Finaller As String = String.Empty
                For Each P As String In DFKContent.Split(CP)
                    If P.StartsWith(Chr(LineType.Action)) Then
                        P = P.Substring(1)
                        Dim ObjectName As String = P.Substring(0, P.IndexOf(CC))
                        P = P.Substring(ObjectName.Length + 1)
                        Dim EventType As String = P.Substring(0, P.IndexOf(CC))
                        P = P.Substring(EventType.Length + 1)
                        Dim EventData As String = P.Substring(0, P.IndexOf(CC))
                        P = P.Substring(EventData.Length + 1)
                        If ObjectName = EventObjects(I) And EventType = EventTypes(I) And EventData = EventDatas(I) Then
                            Dim ActionName As String = ActionGetPartition(P, "name")
                            Dim Arguments As String = ActionGetPartition(P, "arguments")
                            Dim ArgumentsList As New List(Of String)
                            Dim Current As String = String.Empty
                            For Each R As String In Arguments
                                If R = CommandSep Then
                                    ArgumentsList.Add(Current)
                                    Current = String.Empty
                                Else
                                    Current += R
                                End If
                            Next
                            If Current.Length > 0 Then ArgumentsList.Add(Current)
                            Dim Applies As String = ActionGetPartition(P, "appliesto")
                            Finaller += "SET_APPLICATION " + Applies + CommandSep
                            For Each X As String In IO.File.ReadAllLines(ActionsFolder + "\" + ActionName + ".action")
                                If X.StartsWith("TYPE ") Then Continue For
                                If X.StartsWith("DISPLAY ") Then Continue For
                                If X.StartsWith("ICON ") Then Continue For
                                If X = "BG" Then Continue For
                                If X = "NOAPPLIES" Then Continue For
                                If X = "INDENT" Then Continue For
                                If X = "DEDENT" Then Continue For
                                If X = "CONDITIONAL" Then Continue For
                                If X.StartsWith("ARG ") Then Continue For
                                Dim ArgumentCount As UInt16 = 0
                                For Each F As String In X
                                    If F = ";" Then ArgumentCount += 1
                                Next
                                If ArgumentCount = 0 Then
                                    If X.Contains("!1!") Then ArgumentCount = 1
                                Else
                                    ArgumentCount += 1
                                End If
                                X = X.Replace(";", ArgSep)
                                If ArgumentCount > 0 Then
                                    Dim Y As String = X
                                    If ArgumentCount = 1 Then
                                        Y = Y.Replace("!1!", Arguments)
                                    Else
                                        For G As UInt16 = 1 To ArgumentsList.Count
                                            Y = Y.Replace("!" + G.ToString + "!", ArgumentsList(G - 1))
                                        Next
                                    End If
                                    Finaller += Y + CommandSep
                                Else
                                    Finaller += X + CommandSep
                                End If
                            Next
                        End If
                    End If
                Next
                If Finaller.Length > 0 Then Finaller = Finaller.Substring(0, Finaller.Length - 1)
                EventCodes(I) = Finaller
            Next
        End If

        Dim FinalContent As String = String.Empty

        For Each P As String In DFKContent.Split(CP)
            If P.Length = 0 Then Continue For
            If Not (P.StartsWith(Chr(LineType.DEvent)) Or P.StartsWith(Chr(LineType.Action))) Then
                FinalContent += P + CP
            End If
        Next

        If EventObjects.Count > 0 Then
            For I As UInt16 = 0 To EventObjects.Count - 1
                Dim LocalLine As String = String.Empty
                LocalLine += Convert.ToString(Chr(LineType.DEvent))
                LocalLine += EventObjects(I)
                LocalLine += CC
                LocalLine += EventTypes(I)
                LocalLine += CC
                LocalLine += EventDatas(I)
                LocalLine += CC
                LocalLine += EventCodes(I)
                FinalContent += LocalLine + CP
            Next
        End If

        'FinalContent = FinalContent.Substring(0, FinalContent.Length - 1)
        'FinalContent += CP

        ExpandArray(FinalData, FinalContent.Length)
        StringToBytes(FinalContent).CopyTo(FinalData, Convert.ToInt32(WritePos))

        IO.File.WriteAllBytes(Folder + "Data.odfx", FinalData)

    End Sub

    Public Function StringToBytes(ByVal TheInput As String) As Byte()
        Return New System.Text.ASCIIEncoding().GetBytes(TheInput)
    End Function

    Function ActionGetPartition(ByRef TheString As String, ByVal Partition As String) As String
        Try
            If Not TheString.Contains("<" + Partition + ">") And TheString.Contains("</" + Partition + ">") Then Return String.Empty
            Dim Tag1 As String = "<" + Partition + ">"
            Dim Returnable As String = TheString.Substring(TheString.IndexOf(Tag1) + Tag1.Length)
            Dim Tag2 As String = "</" + Partition + ">"
            Returnable = Returnable.Substring(0, Returnable.LastIndexOf(Tag2))
            Return Returnable
        Catch : Return String.Empty : End Try
    End Function

End Module
