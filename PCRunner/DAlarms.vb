Module DAlarms

    Public Class Alarm
        Public Enabled As Boolean = False
        Public Time As UInt16
        Sub New(ByVal PTime As UInt16, ByVal PEnabled As Boolean)
            Time = PTime
            Enabled = PEnabled
        End Sub
    End Class
    Public Alarms As New List(Of Alarm)

    Sub SetAlarm(ByVal AlarmID As UInt16, ByVal PTime As UInt16, ByVal EnableGleichZeitig As Boolean)
        Alarms(AlarmID).Time = PTime
        Alarms(AlarmID).Enabled = EnableGleichZeitig
        'Console.WriteLine("set and act.' al " + AlarmID.ToString + " at time " + PTime.ToString)
    End Sub

    Sub AlarmsSync()
        If Alarms.Count = 0 Then Exit Sub
        For I As UInt16 = 0 To Alarms.Count - 1
            If Not Alarms(I).Enabled Then Continue For
            If Alarms(I).Time = 0 Then
                Alarms(I).Enabled = False
                Continue For
            End If
            Alarms(I).Time -= 1
        Next
    End Sub

    Sub InitAlarms(ByVal DCount As UInt16)
        For I As UInt16 = 0 To DCount - 1
            Alarms.Add(New Alarm(30, False))
        Next
    End Sub

End Module
