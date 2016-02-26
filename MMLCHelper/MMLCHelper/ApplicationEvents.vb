Namespace My

    ' The following events are available for MyApplication:
    ' 
    ' Startup: Raised when the application starts, before the startup form is created.
    ' Shutdown: Raised after all application forms are closed.  This event is not raised if the application terminates abnormally.
    ' UnhandledException: Raised if the application encounters an unhandled exception.
    ' StartupNextInstance: Raised when launching a single-instance application and the application is already active. 
    ' NetworkAvailabilityChanged: Raised when the network connection is connected or disconnected.
    Partial Friend Class MyApplication
#Region "DefaultIniFile"
        Public Const DefaultIniFile As String = "[MMLCHelper]" & vbCrLf &
            "FileVersion=1.0.0" & vbCrLf &
            "MinimumMMLCHelperVersion=0.4.0.0" & vbCrLf &
            "MMLCHelperVersion=0.5.0.0" & vbCrLf &
            "[XClassToggler]" & vbCrLf &
            "Method=Beta" & vbCrLf &
            "AllowAppControl=True" & vbCrLf &
            "AllowBlockInternet=True" & vbCrLf &
            "AllowBlockUserInput=True" & vbCrLf &
            "[Minecraft]" & vbCrLf &
            "ProgramFiles=" & vbCrLf &
            "AppData=" & vbCrLf &
            "[CHY]" & vbCrLf &
            "Loop=False" & vbCrLf &
            "[Options]" & vbCrLf &
            "AutoRun=False" & vbCrLf &
            "SwitchRestart=False" & vbCrLf &
            "RestartPrograms=False" & vbCrLf &
            "Force=False" & vbCrLf &
            "Timeout=0" & vbCrLf &
            "Comment=" & vbCrLf &
            ""
#End Region
        <Flags> Public Enum LogEntryFormat As Byte
            ''' <summary>
            ''' [*Time in GMT*] *Message*
            ''' </summary>
            ''' <remarks></remarks>
            TimeSqrBracketsPrefix
            ''' <summary>
            ''' (*Time in GMT*) *Message*
            ''' </summary>
            ''' <remarks></remarks>
            TimeRndBracketsPrefix
            ''' <summary>
            ''' {*Time in GMT*} *Message*
            ''' </summary>
            ''' <remarks></remarks>
            TimeCurBracketsPrefix
            ''' <summary>
            ''' 【*Time in GMT*】 *Message*
            ''' </summary>
            ''' <remarks></remarks>
            TimeLenticularBracketsPrefix
            ''' <summary>
            ''' ‘*Time in GMT*’ *Message*
            ''' </summary>
            ''' <remarks></remarks>
            TimeSngQuotPrefix
            ''' <summary>
            ''' “*Time in GMT*” *Message*
            ''' </summary>
            ''' <remarks></remarks>
            TimeDblQuotPrefix
#If False Then
            ''' <summary>
            ''' ‹*Time in GMT*› *Message*
            ''' </summary>
            ''' <remarks></remarks>
            TimeSngAnglePrefix
            ''' <summary>
            ''' «*Time in GMT*» *Message*
            ''' </summary>
            ''' <remarks></remarks>
            TimeDblAnglePrefix
#End If
            ''' <summary>
            ''' ［*Time in GMT*］ *Message*
            ''' </summary>
            ''' <remarks></remarks>
            TimeFullWidthSqrBracketsPrefix
            ''' <summary>
            ''' （*Time in GMT*） *Message*
            ''' </summary>
            ''' <remarks></remarks>
            TimeFullWidthRndBracketsPrefix
            ''' <summary>
            ''' ｛*Time in GMT*｝ *Message*
            ''' </summary>
            ''' <remarks></remarks>
            TimeFullWidthCurBracketsPrefix
            ''' <summary>
            ''' 〚*Time in GMT*〛 *Message*
            ''' </summary>
            ''' <remarks></remarks>
            TimeWhiteSqrBracketsPrefix
            ''' <summary>
            ''' ⦅*Time in GMT*⦆ *Message*
            ''' </summary>
            ''' <remarks></remarks>
            TimeWhiteRndBracketsPrefix
            ''' <summary>
            ''' ⦃*Time in GMT*⦄ *Message*
            ''' </summary>
            ''' <remarks></remarks>
            TimeWhiteCurBracketsPrefix
            ''' <summary>
            ''' ｟*Time in GMT*｠ *Message*
            ''' </summary>
            ''' <remarks></remarks>
            TimeFullWidthWhiteCurBracketsPrefix
            ''' <summary>
            ''' 「*Time in GMT*」 *Message*
            ''' </summary>
            ''' <remarks></remarks>
            TimeCornerBracketsPrefix
            ''' <summary>
            ''' 〈*Time in GMT*〉 *Message*
            ''' </summary>
            ''' <remarks></remarks>
            TimeSngAngleBracketPrefix
            ''' <summary>
            ''' 《*Time in GMT*》 *Message*
            ''' </summary>
            ''' <remarks></remarks>
            TimeDblAngleBracketPrefix
        End Enum
        Public Sub WriteLogEntry(ByVal Message As String,
                                 Optional EventType As TraceEventType = TraceEventType.Verbose,
                                 Optional Format As LogEntryFormat =
                                 LogEntryFormat.TimeSqrBracketsPrefix,
                                 Optional ex As Exception = Nothing)
            Select Case Format Mod 16
                Case LogEntryFormat.TimeSqrBracketsPrefix
                    Message = ("["c &
                        My.Computer.Clock.GmtTime.ToString & "]"c & Message)
                Case LogEntryFormat.TimeRndBracketsPrefix
                    Message = ("("c &
                        My.Computer.Clock.GmtTime.ToString & ")"c & Message)
                Case LogEntryFormat.TimeCurBracketsPrefix
                    Message = ("{"c &
                        My.Computer.Clock.GmtTime.ToString & "}"c & Message)
                Case LogEntryFormat.TimeLenticularBracketsPrefix
                    Message = ("【"c &
                        My.Computer.Clock.GmtTime.ToString & "】"c & Message)
                Case LogEntryFormat.TimeSngQuotPrefix
                    Message = ("‘"c &
                        My.Computer.Clock.GmtTime.ToString & "’"c & Message)
                Case LogEntryFormat.TimeDblQuotPrefix
                    Message = (""""c &
                        My.Computer.Clock.GmtTime.ToString & """"c & Message)
                Case LogEntryFormat.TimeFullWidthSqrBracketsPrefix
                    Message = ("［"c &
                        My.Computer.Clock.GmtTime.ToString & "］"c & Message)
                Case LogEntryFormat.TimeFullWidthRndBracketsPrefix
                    Message = ("（"c &
                        My.Computer.Clock.GmtTime.ToString & "）"c & Message)
                Case LogEntryFormat.TimeFullWidthCurBracketsPrefix
                    Message = ("｛"c &
                        My.Computer.Clock.GmtTime.ToString & "｝"c & Message)
                Case LogEntryFormat.TimeWhiteSqrBracketsPrefix
                    Message = ("〚"c &
                        My.Computer.Clock.GmtTime.ToString & "〛"c & Message)
                Case LogEntryFormat.TimeWhiteRndBracketsPrefix
                    Message = ("⦅"c &
                        My.Computer.Clock.GmtTime.ToString & "⦆"c & Message)
                Case LogEntryFormat.TimeWhiteCurBracketsPrefix
                    Message = ("⦃"c &
                        My.Computer.Clock.GmtTime.ToString & "⦄"c & Message)
                Case LogEntryFormat.TimeFullWidthWhiteCurBracketsPrefix
                    Message = ("｟"c &
                        My.Computer.Clock.GmtTime.ToString & "｠"c & Message)
                Case LogEntryFormat.TimeCornerBracketsPrefix
                    Message = ("「"c &
                        My.Computer.Clock.GmtTime.ToString & "」"c & Message)
                Case LogEntryFormat.TimeSngAngleBracketPrefix
                    Message = ("〈"c &
                        My.Computer.Clock.GmtTime.ToString & "〉"c & Message)
            End Select
            If IsNothing(ex) Then
                My.Application.Log.WriteEntry(Message, EventType)
                System.Diagnostics.Trace.WriteLine(Message, EventType.ToString)
            Else
                My.Application.Log.WriteException(ex, EventType, Message)
                System.Diagnostics.Trace.WriteLine(New Exception(Message, ex), EventType.ToString)
            End If
        End Sub
        Public Options As New IniFile
        Public Event CommandLineRead(sender As Object, e As StartEventArgs)
        Public Event OptionsRead(sender As Object, e As EventArgs)
        <Flags()> Friend Enum RunMode As Byte
            QuestionMark = 0
            Normal = 1
            Batch = 2
            Interfer = 4
        End Enum
        Public Class StartEventArgs
            Inherits System.EventArgs
            Public ReadOnly RunMode As RunMode
            Friend Sub New(_RunMode As RunMode)
                RunMode = _RunMode
            End Sub
            Friend SpecifiedArguments As New List(Of String)
        End Class
        Private Sub ReadCommandLine(ByVal sender As Object,
        ByVal e As Microsoft.VisualBasic.ApplicationServices.StartupEventArgs) Handles Me.Startup
            Dim EArgs As New StartEventArgs(RunMode.Normal)
            My.Application.Log.WriteEntry("Application started at " &
                My.Computer.Clock.GmtTime.ToString)
            For Each s As String In My.Application.CommandLineArgs
                Select Case s.ToLower()
                    Case "/?"
                        WriteLogEntry("Displayed application parameter help.",
                                      TraceEventType.Information)
                        ' Stop the start form from loading.
                        e.Cancel = True
                        EArgs = New StartEventArgs(EArgs.RunMode Or RunMode.QuestionMark)
                    Case "/batch"
                        WriteLogEntry("Loaded batch mode.", TraceEventType.Information)
                        ' Stop the start form from loading.
                        e.Cancel = True
                        EArgs = New StartEventArgs(EArgs.RunMode Or RunMode.Batch)
                    Case "/interfer"
                        WriteLogEntry("Application started with interference.",
                                      TraceEventType.Information)
                        EArgs = New StartEventArgs(EArgs.RunMode Or RunMode.Interfer)
                End Select
            Next
            If e.Cancel And EArgs.RunMode.HasFlag(RunMode.Batch) Then
                ' Call the main routine for windowless operation.
                Dim c As MyModes.BatchMode
                RaiseEvent CommandLineRead(sender, EArgs)
                c.Main()
            ElseIf e.Cancel And (EArgs.RunMode = RunMode.QuestionMark Or
                                 EArgs.RunMode - RunMode.QuestionMark = RunMode.Interfer) Then
                Dim c As New MyModes.BatchMode
                c.DisplayHelp(EArgs.RunMode.HasFlag(RunMode.Interfer))
            Else
                RaiseEvent CommandLineRead(sender, EArgs)
            End If
        End Sub
        Private Sub ReadOptions(sender As Object,
            ByVal e As StartEventArgs) Handles Me.CommandLineRead
            If e.RunMode.HasFlag(RunMode.Normal) Then
                Dim TempException As New UnauthorizedAccessException
Written:        Try
                    Options.Load("MMLCHelper.ini", False, True)
                    Exit Try
Caught2:            Throw TempException
                Catch ex As IO.FileNotFoundException
                    Try
                        Dim Writer As New IO.StreamWriter("MMLCHelper.ini")
                        Writer.Write(DefaultIniFile)
                        Writer.Flush()
                        GoTo Written
                    Catch exc As UnauthorizedAccessException
                        TempException = exc
                        GoTo Caught
                    End Try
                    Exit Try
Caught:             GoTo Caught2
                Catch ex As UnauthorizedAccessException
                    MsgBox("Do not have the permission to load or write the options file!" & vbCrLf &
                           "The exception is : " & ex.ToString(), MsgBoxStyle.Exclamation)
                    GoTo Raise
                End Try
                If True Then
                    Dim MMLCHelperVersionKey As New IniFile.IniSection.IniKey(
                        New IniFile.IniSection(Options, "MMLCHelper"), "MMLCHelperVersion")
                    MMLCHelperVersionKey.SetValue(My.Application.Info.Version.ToString)
                    If My.Application.Info.Version.CompareTo(New System.Version(
                                Options.GetKeyValue("MMLCHelper", "MinimumMMLCHelperVersion"))) < 0 Then
                        MsgBox("Options file is too new!", MsgBoxStyle.Exclamation, "Error")
                        Exit Sub
                    End If : Options.Save("MMLCHelper.ini") : End If
                If True Then
                    Select Case Options.GetKeyValue("XClassToggler", "Method") 'New IniFile.IniSection(
                        '     Options, "XClassToggler").GetKey("Method").GetValue
                        Case "Alpha"
                            MMLCHelper.MethodAlpha.Checked = True
                        Case "Beta"
                            MMLCHelper.MethodBeta.Checked = True
                        Case "Gamma"
                            ' MMLCHelper.MethodGamma.Checked = True
                    End Select
                    MMLCHelper.XCAppControl.Checked =
                        CBool(Options.GetKeyValue("XClassToggler", "AllowAppControl"))
                    MMLCHelper.XCBlockInternet.Checked =
                        CBool(Options.GetKeyValue("XClassToggler", "AllowBlockInternet"))
                    MMLCHelper.XCHookInput.Checked =
                        CBool(Options.GetKeyValue("XClassToggler", "AllowBlockUserInput"))
                End If
                If True Then
                    Select Case Options.GetKeyValue("Minecraft", "ProgFiles")
                        Case Nothing
                            MMLCHelper.ProgFiles.Checked = True
                        Case Else
                            MMLCHelper.InstallDirFinder.SelectedPath =
                                Options.GetKeyValue("Minecraft", "ProgFiles")
                            MMLCHelper.ProgFiles.Checked = False
                    End Select
                    Select Case Options.GetKeyValue("Minecraft", "AppData")
                        Case Nothing
                            MMLCHelper.AppData.Checked = True
                        Case Else
                            MMLCHelper.AppDataFinder.SelectedPath =
                                Options.GetKeyValue("Minecraft", "AppData")
                            MMLCHelper.AppData.Checked = False
                    End Select
                End If
                MMLCHelper.CHYLoop.Checked =
                    CBool(Options.GetKeyValue("CHY", "Loop"))
                If True Then
                    MMLCHelper.Autorun.Checked =
                        CBool(Options.GetKeyValue("Options", "AutoRun"))
                    MMLCHelper.SwitchIfEnabled.Checked =
                        CBool(Options.GetKeyValue("Options", "SwitchRestart"))
                    MMLCHelper.SwitchPrograms.Checked =
                        CBool(Options.GetKeyValue("Options", "RestartPrograms"))
                    MMLCHelper.SwitchForce.Checked =
                        CBool(Options.GetKeyValue("Options", "Force"))
                    MMLCHelper.SwitchTimeout.Value =
                        CDec(Options.GetKeyValue("Options", "Timeout"))
                    MMLCHelper.SwitchComment.Text =
                        Options.GetKeyValue("Options", "Comment")
                End If

            ElseIf e.RunMode.HasFlag(RunMode.Batch) Then
                Dim TempException As New UnauthorizedAccessException
WrittenBatch:   Try
                    Options.Load("MMLCHelper.ini", False, True)
                    Exit Try
Caught4:            Throw TempException
                Catch ex As IO.FileNotFoundException
                    Try
                        Dim Writer As New IO.StreamWriter("MMLCHelper.ini")
                        Writer.Write(DefaultIniFile)
                        Writer.Flush()
                        GoTo WrittenBatch
                    Catch exc As UnauthorizedAccessException
                        TempException = exc
                        GoTo Caught3
                    End Try
                    Exit Try
Caught3:            GoTo Caught4
                Catch ex As UnauthorizedAccessException
                    Console.WriteLine(
                        "Do not have the permission to load or write the options file!" & vbCrLf &
                           "The exception is : " & ex.ToString())
                    GoTo Raise
                End Try
                If True Then
                    Dim MMLCHelperVersionKey As New IniFile.IniSection.IniKey(
                        New IniFile.IniSection(Options, "MMLCHelper"), "MMLCHelperVersion")
                    MMLCHelperVersionKey.SetValue(My.Application.Info.Version.ToString)
                    If My.Application.Info.Version.CompareTo(New System.Version(Options.
                                GetKeyValue("MMLCHelper", "MinimumMMLCHelperVersion"))) < 0 Then
                        Console.WriteLine("Options file is too new!")
                        Exit Sub
                    End If : Options.Save("MMLCHelper.ini") : End If
                If True Then
                    Select Case Options.GetKeyValue("XClassToggler", "Method")
                        'New IniFile.IniSection(
                        '     Options, "XClassToggler").GetKey("Method").GetValue
                        Case "Alpha"
                            MMLCHelper.MethodAlpha.Checked = True
                        Case "Beta"
                            MMLCHelper.MethodBeta.Checked = True
                        Case "Gamma"
                            ' MMLCHelper.MethodGamma.Checked = True
                    End Select
                    MMLCHelper.XCAppControl.Checked =
                        CBool(Options.GetKeyValue("XClassToggler", "AllowAppControl"))
                    MMLCHelper.XCBlockInternet.Checked =
                        CBool(Options.GetKeyValue("XClassToggler", "AllowBlockInternet"))
                    MMLCHelper.XCHookInput.Checked =
                        CBool(Options.GetKeyValue("XClassToggler", "AllowBlockUserInput"))
                End If
                If True Then
                    Select Case Options.GetKeyValue("Minecraft", "ProgFiles")
                        Case Nothing
                            MMLCHelper.ProgFiles.Checked = True
                        Case Else
                            MMLCHelper.InstallDirFinder.SelectedPath =
                                Options.GetKeyValue("Minecraft", "ProgFiles")
                            MMLCHelper.ProgFiles.Checked = False
                    End Select
                    Select Case Options.GetKeyValue("Minecraft", "AppData")
                        Case Nothing
                            MMLCHelper.AppData.Checked = True
                        Case Else
                            MMLCHelper.AppDataFinder.SelectedPath =
                                Options.GetKeyValue("Minecraft", "AppData")
                            MMLCHelper.AppData.Checked = False
                    End Select
                End If
                MMLCHelper.CHYLoop.Checked =
                    CBool(Options.GetKeyValue("CHY", "Loop"))
                If True Then
                    MMLCHelper.Autorun.Checked =
                        CBool(Options.GetKeyValue("Options", "AutoRun"))
                    MMLCHelper.SwitchIfEnabled.Checked =
                        CBool(Options.GetKeyValue("Options", "SwitchRestart"))
                    MMLCHelper.SwitchPrograms.Checked =
                        CBool(Options.GetKeyValue("Options", "RestartPrograms"))
                    MMLCHelper.SwitchForce.Checked =
                        CBool(Options.GetKeyValue("Options", "Force"))
                    MMLCHelper.SwitchTimeout.Value =
                        CDec(Options.GetKeyValue("Options", "Timeout"))
                    MMLCHelper.SwitchComment.Text =
                        Options.GetKeyValue("Options", "Comment")
                End If
            End If
            MMLCHelper.Register(sender, e)
Raise:      RaiseEvent OptionsRead(sender, e)
        End Sub
        Private Function ReadINIFile(Data(,) As String) As Boolean
            For Each Section As String In Data
                Dim Location As Integer() = Data.FindIndex(Section)

            Next
            Throw New InvalidOperationException("Method is obsolete and deprecated.")
        End Function
        Public Function GetStrongName(T As Type) As String
            Return (T.FullName & ", " & T.Assembly.FullName)
        End Function
        Private Sub MyApplication_UnhandledException(
                 ByVal sender As Object,
                 ByVal e As ApplicationServices.UnhandledExceptionEventArgs
                 ) Handles Me.UnhandledException
            MMLCHelper.Unregister(sender, e)
            My.Application.Log.WriteException(e.Exception,
                TraceEventType.Critical,
                "Application shut down at " &
                My.Computer.Clock.GmtTime.ToString)
        End Sub

        Private Sub MyApplication_ShutDown(ByVal sender As Object,
                                           ByVal e As EventArgs) Handles Me.Shutdown
            MMLCHelper.Unregister(sender, e)
            Options.SetKeyValue("XClassToggler", "Method", If(MMLCHelper.MethodAlpha.Checked,
                                "Alpha", If(MMLCHelper.MethodBeta.Checked, "Beta", "Gamma")))
            Options.SetKeyValue("XClassToggler", "AllowAppControl",
                                MMLCHelper.XCAppControl.Checked.ToString)
            Options.SetKeyValue("XClassToggler", "AllowBlockInternet",
                                MMLCHelper.XCBlockInternet.Checked.ToString)
            Options.SetKeyValue("XClassToggler", "AllowBlockUserInput",
                                MMLCHelper.XCHookInput.Checked.ToString)
            Options.SetKeyValue("Minecraft", "ProgramFiles",
            If(MMLCHelper.ProgFiles.Checked, Nothing, MMLCHelper.InstallDirFinder.SelectedPath))
            Options.SetKeyValue("Minecraft", "AppData",
            If(MMLCHelper.AppData.Checked, Nothing, MMLCHelper.AppDataFinder.SelectedPath))
            Options.SetKeyValue("CHY", "Loop", MMLCHelper.CHYLoop.Checked.ToString)
            Options.SetKeyValue("Options", "AutoRun", MMLCHelper.Autorun.Checked.ToString)
            Options.SetKeyValue("Options", "SwitchRestart",
                                MMLCHelper.SwitchIfEnabled.Checked.ToString)
            Options.SetKeyValue("Options", "RestartPrograms",
                                MMLCHelper.SwitchPrograms.Checked.ToString)
            Options.SetKeyValue("Options", "Force", MMLCHelper.SwitchForce.Checked.ToString)
            Options.SetKeyValue("Options", "Timeout", MMLCHelper.SwitchTimeout.Value.ToString)
            Options.SetKeyValue("Options", "Comment", MMLCHelper.SwitchComment.Text)
            Options.Save("MMLCHelper.ini")
#If True Then
        End Sub
        Public Sub nn(ByVal sender As Object,
                                           ByVal e As EventArgs)
#If True Then

#End If
#If True Then
#End If
#End If
        End Sub
    End Class
#If True Then
End Namespace
#Else
End Namespace
#End If
Public Module Extensions
    <System.Runtime.CompilerServices.Extension> _
    Public Function FindIndex(haystack As Array, needle As Object) As Integer()
        If haystack.Rank = 1 Then
            Return New Integer() {Array.IndexOf(haystack, needle)}
        End If
        Dim found = haystack.OfType(Of Object)().[Select](Function(v, i) New Integer() { _
            CInt(v), i}).FirstOrDefault(Function(s) (s.Equals(needle)))
        If found Is Nothing Then
            Throw New Exception("needle not found in set")
        End If

        Dim indexes = New Integer(haystack.Rank - 1) {}
        Dim last = found.Last
        Dim lastLength = Enumerable.Range(0, haystack.Rank).Aggregate(1,
                                        Function(a, v) a * haystack.GetLength(v))
        For rank As Integer = 0 To haystack.Rank - 1
            lastLength = CInt(lastLength / haystack.GetLength(rank))
            Dim value = last / lastLength
            last -= CInt(value * lastLength)

            Dim index = value + haystack.GetLowerBound(rank)
            If index > haystack.GetUpperBound(rank) Then
                Throw New IndexOutOfRangeException()
            End If
            indexes(rank) = CInt(index)
        Next

        Return indexes
    End Function
End Module
'=======================================================