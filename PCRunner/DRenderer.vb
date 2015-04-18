Imports System.IO

Public Module DRenderer

    ''
    '' Fonts
    ''

    Public CurrentFont As String
    Public FontTileWidth As UInt16 = 16
    Public FontTileHeight As UInt16 = 16

    Dim FontCharacters As New List(Of Bitmap)

    Sub InitFontCharacters(ByVal WhatFont As String)
        Dim TFrom As Bitmap = My.Resources.FontMap.Clone()
        Dim iFound As Boolean = False
        For Each P As DImage In Images
            If P.Name = WhatFont Then
                iFound = True
                TFrom = P.Data.Clone()
                Exit For
            End If
        Next
        Dim W As UInt16 = TFrom.Width
        Dim H As UInt16 = TFrom.Height
        FontTileWidth = W / 16
        FontTileHeight = H / 16
        FontCharacters.Clear()
        For Y As Byte = 0 To 16 - 1
            For X As Byte = 0 To 16 - 1
                Dim D As New Bitmap(FontTileWidth, FontTileHeight)
                Dim DGFX As Graphics = Graphics.FromImage(D)
                DGFX.DrawImage(TFrom, New Point((X * FontTileWidth * (-1)), (Y * FontTileHeight * (-1))))
                DGFX.Dispose()
                FontCharacters.Add(D.Clone())
                D.Dispose()
            Next
        Next
    End Sub

    Public Use As Bitmap
    Dim UseGFX As Graphics

    Dim TempBGer As New Bitmap(32, 32)

    Public HorizAdd As UInt16 = 0
    Public VertiAdd As UInt16 = 0

    Sub CalculateAdds()
        Dim P As New Form
        P.FormBorderStyle = FormBorderStyle.FixedSingle
        P.Size = New Size(400, 400)
        HorizAdd = P.Size.Width - P.ClientRectangle.Width
        VertiAdd = P.Size.Height - P.ClientRectangle.Height
        P.Dispose()
    End Sub

    Public Sub RenderBegin()
        Dim NW As Int32 = Convert.ToInt32(CusA.ViewWidth)
        Dim NH As Int32 = Convert.ToInt32(CusA.ViewHeight)
        Use = New Bitmap(NW, NH)
        UseGFX = Graphics.FromImage(Use)
    End Sub

    Structure DrawableInstance
        Public X As Int16
        Public Y As Int16
        Public ProcessedID As UInt16
        Public Depth As Byte
        Sub New(ByVal PX As Int16, ByVal PY As Int16, ByVal PProcessedID As UInt16, ByVal PDepth As Byte)
            X = PX
            Y = PY
            ProcessedID = PProcessedID
            Depth = PDepth
        End Sub
    End Structure

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

    Public Sub MakeBMP()

        'Size Changed: Rebuke canvas
        If SizeChanged Then RenderBegin()

        'Clear
        Dim ClearColor As Color = Color.FromArgb(CusA.BGRed, CusA.BGGreen, CusA.BGBlue)
        UseGFX.Clear(ClearColor)

        'Background
        Dim FoundBackground As Boolean = False
        For Each P As DImage In Images
            If P.Name = CusA.Background Then TempBGer = P.Data.Clone() : FoundBackground = True
        Next
        If FoundBackground Then
            Dim HR As UInt32 = Math.Ceiling(CusA.Width / TempBGer.Width)
            Dim HV As UInt32 = Math.Ceiling(CusA.Height / TempBGer.Height)
            For DX As UInt32 = 0 To HR - 1
                For DY As UInt32 = 0 To HV - 1
                    UseGFX.DrawImageUnscaled(TempBGer, -CusA.ViewX + (DX * TempBGer.Width), -CusA.ViewY + (DY * TempBGer.Height))
                Next
            Next
        End If

        'Instances
        If CusA.Instances.Count > 0 Then
            Dim ProcessedImages As New List(Of Bitmap)
            ProcessedImages.Add(New Bitmap(32, 32)) 'No Image
            Dim OldDrawables As New List(Of DrawableInstance)
            Dim NewDrawables As New List(Of DrawableInstance)
            For I As UInt16 = 0 To CusA.Instances.Count - 1
                If CusA.Instances(I).X >= CusA.ViewX - CusA.Instances(I).Width - 100 And CusA.Instances(I).X <= CusA.ViewX + CusA.ViewWidth + 100 _
    And CusA.Instances(I).Y >= CusA.ViewY - CusA.Instances(I).Height - 100 And CusA.Instances(I).Y <= CusA.ViewY + CusA.ViewHeight + 100 Then
                    If DF_Ignore(I) Then Continue For
                    Dim C As Instance = CusA.Instances(I)
                    Dim actualsize As Size = New Size(0, 0)
                    Dim sprsize As Size = New Size(0, 0)
                    Dim MadeImage As Boolean = False
                    For Each X As DImage In Images
                        If X.Name = C.ImageName Then
                            Dim theta As Double = CusA.Instances(I).T
                            While theta >= 360
                                theta -= 360
                            End While
                            While theta < 0
                                theta += 360
                            End While
                            Dim spr As New Bitmap(X.Data.Width, X.FrameHeight)
                            Dim tempbrap As Graphics = Graphics.FromImage(spr)
                            tempbrap.DrawImageUnscaled(X.Data, New Point(0, 0 - (C.Frame * X.FrameHeight)))
                            Dim TBMP As Bitmap = rotateBMP(spr, theta)
                            MadeImage = True
                            actualsize = TBMP.Size
                            sprsize = spr.Size
                            tempbrap.Dispose()
                            spr.Dispose()
                            ProcessedImages.Add(TBMP.Clone())
                            TBMP.Dispose()
                            Exit For
                        End If
                    Next
                    Dim DI As DrawableInstance
                    If MadeImage Then
                        DI = New DrawableInstance(C.X + (Math.Floor(sprsize.Width / 2) - Math.Floor(actualsize.Width / 2)), C.Y + (Math.Floor(sprsize.Height / 2) - Math.Floor(actualsize.Height / 2)), ProcessedImages.Count - 1, C.Depth)
                    Else
                        DI = New DrawableInstance(C.X, C.Y, 0, C.Depth)
                    End If
                    OldDrawables.Add(DI)
                End If
            Next
            For I As Int16 = 200 To 0 Step -1
                If OldDrawables.Count = 0 Then Exit For
                For F As UInt16 = 0 To OldDrawables.Count - 1
                    If OldDrawables(F).Depth = I Then
                        NewDrawables.Add(New DrawableInstance(OldDrawables(F).X, OldDrawables(F).Y, OldDrawables(F).ProcessedID, I))
                    End If
                Next
            Next
            For Each F As DrawableInstance In NewDrawables
                UseGFX.DrawImageUnscaled(ProcessedImages(F.ProcessedID), -CusA.ViewX + F.X, -CusA.ViewY + F.Y)
            Next
        End If

        'Foreground
        Dim FoundForeground As Boolean = False
        For Each P As DImage In Images
            If P.Name = CusA.Foreground Then TempBGer = P.Data.Clone() : FoundForeground = True
        Next
        If FoundForeground Then
            UseGFX.DrawImageUnscaled(TempBGer, New Point(0, 0))
        End If

        'Text
        For Each P As DText In DTexts

            Dim X As UInt16 = P.X
            Dim OX As UInt16 = X
            Dim Y As UInt16 = P.Y

            InitFontCharacters(P.FontImg)
            Dim ToDraw As String = P.Data.ToString

            If Not ToDraw.Length = 0 Then
                For F As UInt16 = 0 To ToDraw.Length - 1
                    Dim Code As Byte = Asc(ToDraw(F))
                    If Code = 13 Then Continue For
                    If Code = 10 Then
                        Y += FontTileHeight
                        X = OX
                        Continue For
                    End If
                    UseGFX.DrawImageUnscaled(FontCharacters(Code), New Point(X, Y))
                    X += FontTileWidth
                Next
            End If

        Next

        'Pro Ad
        If Not Pro Then UseGFX.DrawImage(My.Resources.DarkFlowLogo, DF_Logo_Rect)

    End Sub

    Public Function rotateBMP(ByVal img As Bitmap, ByVal angle As Single) As Bitmap
        Dim pi2 As Double = Math.PI / 2.0
        Dim oldWidth As Double = img.Width
        Dim oldHeight As Double = img.Height
        Dim theta As Double = angle * Math.PI / 180.0
        Dim locked_theta As Double = theta
        Dim newWidth, newHeight As Double
        Dim nWidth, nHeight As Integer
        Dim adjacentTop, oppositeTop As Double
        Dim adjacentBottom, oppositeBottom As Double


        If (locked_theta >= 0.0 And locked_theta < pi2) Or (locked_theta >= Math.PI And locked_theta < (Math.PI + pi2)) Then

            adjacentTop = Math.Abs(Math.Cos(locked_theta)) * oldWidth
            oppositeTop = Math.Abs(Math.Sin(locked_theta)) * oldWidth

            adjacentBottom = Math.Abs(Math.Cos(locked_theta)) * oldHeight
            oppositeBottom = Math.Abs(Math.Sin(locked_theta)) * oldHeight

        Else

            adjacentTop = Math.Abs(Math.Sin(locked_theta)) * oldHeight
            oppositeTop = Math.Abs(Math.Cos(locked_theta)) * oldHeight

            adjacentBottom = Math.Abs(Math.Sin(locked_theta)) * oldWidth
            oppositeBottom = Math.Abs(Math.Cos(locked_theta)) * oldWidth
        End If
        newWidth = adjacentTop + oppositeBottom
        newHeight = adjacentBottom + oppositeTop
        nWidth = Math.Ceiling(newWidth)
        nHeight = Math.Ceiling(newHeight)
        Dim rotatedBmp As Bitmap = New Bitmap(nWidth, nHeight)
        Dim g As Graphics = Graphics.FromImage(rotatedBmp)
        Dim points(2) As Point
        If locked_theta >= 0.0 And locked_theta < pi2 Then
            points(0) = New Point(CInt(oppositeBottom), 0)
            points(1) = New Point(nWidth, CInt(oppositeTop))
            points(2) = New Point(0, CInt(adjacentBottom))

        ElseIf locked_theta >= pi2 And locked_theta < Math.PI Then
            points(0) = New Point(nWidth, CInt(oppositeTop))
            points(1) = New Point(CInt(adjacentTop), nHeight)
            points(2) = New Point(CInt(oppositeBottom), 0)

        ElseIf locked_theta >= Math.PI And locked_theta < (Math.PI + pi2) Then
            points(0) = New Point(CInt(adjacentTop), nHeight)
            points(1) = New Point(0, CInt(adjacentBottom))
            points(2) = New Point(nWidth, CInt(oppositeTop))
        Else
            points(0) = New Point(0, CInt(adjacentBottom))
            points(1) = New Point(CInt(oppositeBottom), 0)
            points(2) = New Point(CInt(adjacentTop), nHeight)

        End If
        g.DrawImage(img, points)

        g.Dispose()
        Return rotatedBmp

    End Function

End Module

