Partial Class JavaProperties
    ''' <summary>
    ''' Custom code, not from the source.
    ''' </summary>
    ''' <returns>The time now in a string just like the Minecraft signature.</returns>
    Public Shared ReadOnly Property JavaNow As String
        Get
#If True Then
            Return String.Format(
                         "{0} {1} {2} {3} {4} {5}", WeekdayName(Weekday(Now), True), MonthName(Month(Now), True), Now.Day,
                         Now.TimeOfDay.ToString, If(TimeZone.CurrentTimeZone.IsDaylightSavingTime(Now),
                         TimeZone.CurrentTimeZone.DaylightName.TakeWhile(Function(Character) Char.IsUpper(Character)
                     ), TimeZone.CurrentTimeZone.StandardName.TakeWhile(Function(Character) Char.IsUpper(Character))), Now.Year)
#Else
            Return $"{WeekdayName(Weekday(Now), True)} {MonthName(Month(Now), True)} {Now.Day} {Now.TimeOfDay.
                     ToString} {If(TimeZone.CurrentTimeZone.IsDaylightSavingTime(Now),
                     TimeZone.CurrentTimeZone.DaylightName.TakeWhile(Function(Character) Char.IsUpper(Character)
                     ), TimeZone.CurrentTimeZone.StandardName.TakeWhile(Function(Character) Char.IsUpper(Character)))} {Now.Year}"
#End If
        End Get
    End Property
End Class
''' <summary>
''' Run upon loading of Main. Used for quick test of functons and stuff.
''' </summary>
Friend Module TestCode
    Friend Sub Main()
        'Return
        'http://superuser.com/questions/305901/possible-values-of-processor-architecture
        MsgBox(System.Environment.GetEnvironmentVariable("PROCESSOR_ARCHITECTURE").ToString())
        End
        BanList.Main()
        End
    End Sub
End Module
