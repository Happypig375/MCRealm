Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.Collections
Imports System.Diagnostics
Imports System.Runtime.InteropServices

Namespace ApplicationMon_Student
    Public Class vStudProcess
        ' Methods
        Public Sub DisableProcessRun()
            Dim list As New ArrayList
            Dim process As Process
            For Each process In Process.GetProcesses
                Try 
                    If (((process.MainWindowHandle <> IntPtr.Zero) AndAlso (process.MainWindowTitle.ToString <> "")) AndAlso (Not vStudProcess.allowAppList.Contains(process.Id.ToString) AndAlso Not Me.AllowApp.Contains(process.ProcessName))) Then
                        process.Kill
                    End If
                Catch exception1 As Exception
                    ProjectData.SetProjectError(exception1)
                    Dim exception As Exception = exception1
                    Interaction.MsgBox(exception.Message.ToString, MsgBoxStyle.ApplicationModal, Nothing)
                    ProjectData.ClearProjectError
                End Try
            Next
        End Sub

        Public Function GetActiveWindowTitle() As String
            Dim str As String = ""
            Try 
                Dim num As Integer
                vStudProcess.GetWindowThreadProcessId(vStudProcess.GetForegroundWindow, num)
                str = Process.GetProcessById(num).MainWindowTitle.ToString
            Catch exception1 As Exception
                ProjectData.SetProjectError(exception1)
                Dim exception As Exception = exception1
                Interaction.MsgBox(exception.Message.ToString, MsgBoxStyle.ApplicationModal, Nothing)
                ProjectData.ClearProjectError
            End Try
            If (str = "") Then
                str = "N/A"
            End If
            Return str
        End Function

        Public Function GetEnableRun() As Boolean
            Return vStudProcess.isEnableRun
        End Function

        <DllImport("user32.dll", CharSet:=CharSet.Auto, ExactSpelling:=True)> _
        Public Shared Function GetForegroundWindow() As IntPtr
        End Function

        Public Function GetProcessIDList() As ArrayList
            Dim list2 As New ArrayList
            Dim process As Process
            For Each process In Process.GetProcesses
                Try 
                    If ((process.MainWindowHandle <> IntPtr.Zero) AndAlso (process.MainWindowTitle.ToString <> "")) Then
                        list2.Add(process.Id.ToString)
                    End If
                Catch exception1 As Exception
                    ProjectData.SetProjectError(exception1)
                    Dim exception As Exception = exception1
                    Interaction.MsgBox(exception.Message.ToString, MsgBoxStyle.ApplicationModal, Nothing)
                    ProjectData.ClearProjectError
                End Try
            Next
            Return list2
        End Function

        Public Function GetProcessList() As ArrayList
            Dim list2 As New ArrayList
            Dim process As Process
            For Each process In Process.GetProcesses
                Try 
                    If ((process.MainWindowHandle <> IntPtr.Zero) AndAlso (process.MainWindowTitle.ToString <> "")) Then
                        list2.Add(process.MainWindowTitle.ToString)
                    End If
                Catch exception1 As Exception
                    ProjectData.SetProjectError(exception1)
                    Dim exception As Exception = exception1
                    Interaction.MsgBox(exception.Message.ToString, MsgBoxStyle.ApplicationModal, Nothing)
                    ProjectData.ClearProjectError
                End Try
            Next
            Return list2
        End Function

        <DllImport("user32.dll", CharSet:=CharSet.Auto, SetLastError:=True)> _
        Public Shared Function GetWindowThreadProcessId(ByVal handle As IntPtr, <Out> ByRef processId As Integer) As Integer
        End Function

        Public Sub KillActiveWindow()
            Dim str As String = ""
            Try 
                Dim num As Integer
                vStudProcess.GetWindowThreadProcessId(vStudProcess.GetForegroundWindow, num)
                Dim processById As Process = Process.GetProcessById(num)
                str = Process.GetProcessById(num).MainWindowTitle.ToString
                If ((Not processById Is Nothing) And (str <> String.Empty)) Then
                    processById.Kill
                End If
            Catch exception1 As Exception
                ProjectData.SetProjectError(exception1)
                Dim exception As Exception = exception1
                Interaction.MsgBox(exception.Message.ToString, MsgBoxStyle.ApplicationModal, Nothing)
                ProjectData.ClearProjectError
            End Try
        End Sub

        Public Sub KillProcessByWindowsTitle(ByVal winTitle As Object)
            Dim processes As Process() = System.Diagnostics.Process.GetProcesses
            Dim flag As Boolean = False
            Dim process As Process
            For Each process In processes
                Try 
                    If Operators.ConditionalCompareObjectEqual(process.MainWindowTitle.ToString, winTitle, False) Then
                        process.Kill
                        flag = True
                        Exit For
                    End If
                Catch exception1 As Exception
                    ProjectData.SetProjectError(exception1)
                    Dim exception As Exception = exception1
                    ProjectData.ClearProjectError
                End Try
            Next
        End Sub

        Public Sub SetEnableRun(ByVal isEnable As Boolean)
            If Not isEnable Then
                Try 
                    If (Not vStudProcess.allowAppList Is Nothing) Then
                        vStudProcess.allowAppList.Clear
                    End If
                    vStudProcess.allowAppList = Me.GetProcessIDList
                Catch exception1 As Exception
                    ProjectData.SetProjectError(exception1)
                    Dim exception As Exception = exception1
                    ProjectData.ClearProjectError
                End Try
            End If
            vStudProcess.isEnableRun = isEnable
        End Sub


        ' Fields
        Private AllowApp As ArrayList = New ArrayList(New String() { "xstudent" })
        Private Shared allowAppList As ArrayList
        Private Shared isEnableRun As Boolean = True
    End Class
End Namespace

