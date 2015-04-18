Imports System.Net
Imports System.IO

Module Generics

    Public AppPath As String = String.Empty
    Public WC As New System.Net.WebClient

    Public Function PointInRotatedRect(ByVal TestPnt As Point, ByVal startRect As Rectangle, ByVal Theta As Double) As Boolean
        Dim outBool As Boolean = False

        'Rectangle Coordinates are:
        '  P---Q
        '  |   |
        '  |   |
        '  S---R

        While Theta >= 360
            Theta -= 360
        End While
        While Theta < 0
            Theta += 360
        End While

        Dim h As UInt16 = startRect.Height
        Dim w As UInt16 = startRect.Width
        Dim a As Double = Math.PI * Theta / 180
        Dim X As Int16 = startRect.Location.X
        Dim Y As Int16 = startRect.Location.Y

        'Once they have been rotated about the centre for startRect by theta degrees (by the power of maths), their coordinates will be:

        Dim P As New Point(Math.Round(X + 0.5 * (w - w * Math.Cos(a) + h * Math.Sin(a))), Math.Round(Y + 0.5 * (h - w * Math.Sin(a) - h * Math.Cos(a))))
        Dim Q As New Point(Math.Round(X + 0.5 * (w + w * Math.Cos(a) + h * Math.Sin(a))), Math.Round(Y + 0.5 * (h + w * Math.Sin(a) - h * Math.Cos(a))))
        Dim R As New Point(Math.Round(X + 0.5 * (w + w * Math.Cos(a) - h * Math.Sin(a))), Math.Round(Y + 0.5 * (h + w * Math.Sin(a) + h * Math.Cos(a))))
        Dim S As New Point(Math.Round(X + 0.5 * (w - w * Math.Cos(a) - h * Math.Sin(a))), Math.Round(Y + 0.5 * (h - w * Math.Sin(a) + h * Math.Cos(a))))

        If Theta >= 90 And Theta < 180 Then
            Dim nP As Point = S
            Dim nQ As Point = P
            Dim nR As Point = Q
            Dim nS As Point = R
            P = nP
            Q = nQ
            R = nR
            S = nS

        End If

        If Theta >= 180 And Theta < 270 Then
            Dim nP As Point = R
            Dim nQ As Point = S
            Dim nR As Point = P
            Dim nS As Point = Q
            P = nP
            Q = nQ
            R = nR
            S = nS
        End If

        If Theta >= 270 And Theta < 360 Then
            Dim nP As Point = Q
            Dim nQ As Point = R
            Dim nR As Point = S
            Dim nS As Point = P
            P = nP
            Q = nQ
            R = nR
            S = nS
        End If

        'Get Lines:
        Dim G1 As Double = 0
        Dim G2 As Double = 0

        Dim isRect As Boolean = False
        If Not (P.X = S.X Or P.X = Q.X) Then
            G1 = ((P.Y - S.Y) / (P.X - S.X))
            G2 = ((P.Y - Q.Y) / (P.X - Q.X))
        Else
            isRect = True
        End If
        '    P
        'L1 / \ L2
        '  /   Q
        ' S   /
        '  \ /
        '   R

        Dim L1Valid As Boolean = False
        Dim L2Valid As Boolean = False

        If Not isRect Then
            If (TestPnt.X - S.X) * G1 <= TestPnt.Y - S.Y And (TestPnt.X - R.X) * G1 >= TestPnt.Y - R.Y Then
                L1Valid = True
            End If
            If (TestPnt.X - Q.X) * G2 <= TestPnt.Y - Q.Y And (TestPnt.X - R.X) * G2 >= TestPnt.Y - R.Y Then
                L2Valid = True
            End If
        Else

            If P.X = S.X Then
                If P.X < Q.X Then
                    If TestPnt.X >= P.X And TestPnt.X <= Q.X Then L1Valid = True
                Else
                    If TestPnt.X >= Q.X And TestPnt.X <= P.X Then L1Valid = True
                End If
            Else
                If P.X < S.X Then
                    If TestPnt.X >= P.X And TestPnt.X <= S.X Then L1Valid = True
                Else
                    If TestPnt.X >= S.X And TestPnt.X <= P.X Then L1Valid = True
                End If
            End If

            If P.Y = S.Y Then
                If P.Y < Q.Y Then
                    If TestPnt.Y >= P.Y And TestPnt.Y <= Q.Y Then L2Valid = True
                Else
                    If TestPnt.Y >= Q.Y And TestPnt.Y <= P.Y Then L2Valid = True
                End If
            Else
                If P.Y < S.Y Then
                    If TestPnt.Y >= P.Y And TestPnt.Y <= S.Y Then L2Valid = True
                Else
                    If TestPnt.Y >= S.Y And TestPnt.Y <= P.Y Then L2Valid = True
                End If
            End If

        End If
        If L1Valid And L2Valid Then
            outBool = True
        End If
        Return outBool
    End Function

    Sub MsgWarn(ByVal Message As String, Optional ByVal Title As String = "Dark Flow")
        MessageBox.Show(Message, Title, MessageBoxButtons.OK, MessageBoxIcon.Warning)
    End Sub

    Sub MsgError(ByVal Message As String, Optional ByVal Title As String = "Dark Flow")
        MessageBox.Show(Message, Title, MessageBoxButtons.OK, MessageBoxIcon.Error)
    End Sub

    Sub MsgInfo(ByVal msg As String, Optional ByVal Title As String = "Dark Flow")
        MessageBox.Show(msg, Title, MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Function WarnYesNo(ByVal Message As String, Optional ByVal Title As String = "Dark Flow") As Boolean
        Dim Result As Byte = MessageBox.Show(Message, Title, MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
        Return (Result = MsgBoxResult.Yes)
    End Function

    Sub URL(ByVal URL As String)
        System.Diagnostics.Process.Start(URL)
    End Sub

    Public Function Base64Encode(ByVal Input As String) As String
        Return Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(Input))
    End Function

    Public Function Base64Decode(ByVal Input As String) As String
        Return System.Text.Encoding.UTF8.GetString(Convert.FromBase64String(Input))
    End Function

    Dim RandomMaker As New System.Random(CType(System.DateTime.Now.Ticks Mod System.Int32.MaxValue, Integer))

    Function Random(ByVal Min As Int32, ByVal Max As Int32) As Int32
        Return RandomMaker.Next(Min, Max + 1)
    End Function

End Module
