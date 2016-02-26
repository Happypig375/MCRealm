Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.Collections
Imports System.Diagnostics
Imports System.Net
Imports System.Net.Sockets
Imports System.Runtime.InteropServices
Imports System.Text
Imports System.Threading
Imports System.Windows.Forms
Imports MMLCHelper.ApplicationMon_Student.command

Namespace ApplicationMon_Student
    Public Class sMessager
        ' Methods
        Public Sub New()
            Me.SetRemoteAddress()
        End Sub

        Private Sub BeginListen()
            Dim port As Integer = &H303C
            Try
                Dim client As New UdpClient(port)
                Dim remoteEP As New IPEndPoint(IPAddress.Any, 0)
                Do While True
                    Dim bytes As Byte() = client.Receive(remoteEP)
                    Dim message As String = Encoding.Unicode.GetString(bytes)
                    Dim packet As New vPacket
                    Dim destPCName As String = packet.GetDestPCName(message)
                    If Environment.MachineName.ToString.Equals(destPCName, StringComparison.CurrentCultureIgnoreCase) Then
                        Dim hostPCName As String = packet.GetHostPCName(message)
                        Dim flag As Boolean = Convert.ToBoolean(packet.GetAcknowledgement(message))
                        Dim receivedMsgData As ArrayList = packet.GetReceivedMsgData(message)
                        Me.ReceiveMessage(packet.GetReceivedCommand(message), hostPCName, receivedMsgData)
                        If flag Then
                            Dim obj2 As Object = DirectCast([Enum].Parse(GetType(APPMON_CMD), packet.GetReceivedCommand(message)), APPMON_CMD)
                            Me.StartSend(hostPCName, DirectCast(Conversions.ToInteger(obj2), APPMON_CMD), True, "")
                        End If
                    End If
                Loop
            Catch exception1 As Exception
                ProjectData.SetProjectError(exception1)
                Dim exception As Exception = exception1
                Interaction.MsgBox(exception.Message.ToString, MsgBoxStyle.ApplicationModal, Nothing)
                Application.Exit()
                ProjectData.ClearProjectError()
            End Try
        End Sub

        Private Sub BeginSend(ByVal targetIP As String, ByVal messageStr As String)
            Dim port As Integer = &H303C
            Try
                Dim socket As New Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp)
                Dim remoteEP As New IPEndPoint(IPAddress.Parse(targetIP), port)
                Dim packet As New vPacket
                Dim data As String = Environment.MachineName.ToString
                messageStr = packet.AddPacket(data, messageStr)
                Dim bytes As Byte() = Encoding.Unicode.GetBytes(messageStr)
                socket.SendTo(bytes, remoteEP)
                socket.Close()
            Catch exception1 As Exception
                ProjectData.SetProjectError(exception1)
                Dim exception As Exception = exception1
                Application.Exit()
                ProjectData.ClearProjectError()
            End Try
        End Sub

        Private Sub CloseApplicationMonitor()
            Process.GetCurrentProcess.Kill()
        End Sub

        Private Sub EnableRun(ByVal enable As Boolean)
            Dim VSProc As New vStudProcess
            VSProc.SetEnableRun(enable)
        End Sub

        Private Sub KillActiveProcess()
            Dim VSProc As New vStudProcess
            VSProc.KillActiveWindow()
        End Sub

        Private Sub KillProcessByWinTitle(ByVal msgData As ArrayList)
            Dim winTitle As String = Conversions.ToString(msgData.Item(0))
            If Not ((winTitle = "") Or (winTitle Is Nothing)) Then
                Dim VSProc As New vStudProcess
                VSProc.KillProcessByWindowsTitle(winTitle)
            End If
        End Sub

        Public Sub ReceiveMessage(ByVal cmd As String, ByVal sendTo As String, ByVal msgData As ArrayList)
            If (cmd = APPMON_CMD.CMD_STUDENT_PROCESS_LIST.ToString) Then
                Me.SendMessage(APPMON_CMD.CMD_STUDENT_SEND_PROCESS_LIST, sendTo)
            ElseIf (cmd = APPMON_CMD.CMD_STUDENT_CURRENT_PROCESS.ToString) Then
                Me.SendMessage(APPMON_CMD.CMD_STUDENT_GET_CURRENT_PROCESS, sendTo)
            ElseIf (cmd = APPMON_CMD.CMD_STUDENT_KILL_PROCESS.ToString) Then
                Me.KillProcessByWinTitle(msgData)
            ElseIf (cmd = APPMON_CMD.CMD_STUDENT_KILL_CURRENT_PROCESS.ToString) Then
                Me.KillActiveProcess()
            ElseIf (cmd = APPMON_CMD.CMD_CLOSE_APP_MON.ToString) Then
                Me.CloseApplicationMonitor()
            ElseIf (cmd = APPMON_CMD.CMD_STUDENT_ENABLE_RUN.ToString) Then
                Me.EnableRun(True)
            ElseIf (cmd = APPMON_CMD.CMD_STUDENT_DISABLE_RUN.ToString) Then
                Me.EnableRun(False)
            End If
        End Sub

        Public Sub SendMessage(ByVal cmdMsg As APPMON_CMD, ByVal sendTo As String)
            If (cmdMsg = APPMON_CMD.CMD_STUDENT_SEND_PROCESS_LIST) Then
                Me.SendProcessList(sendTo)
            ElseIf (cmdMsg = APPMON_CMD.CMD_STUDENT_GET_CURRENT_PROCESS) Then
                Me.SendPCuurentrocess(sendTo)
            End If
        End Sub

        Private Sub SendPCuurentrocess(ByVal sendTo As String)
            Dim process As New vStudProcess
            If (sMessager.activeApp <> process.GetActiveWindowTitle) Then
                sMessager.activeApp = process.GetActiveWindowTitle
                Me.StartSend(sendTo, APPMON_CMD.CMD_TEACHER_POST_CURRENT_PROCESS, False, sMessager.activeApp)
            End If
        End Sub

        Private Sub SendProcessList(ByVal sendTo As String)
            Dim process As New vStudProcess
            Dim packet As New vPacket
            Dim strMessage As String = Conversions.ToString(packet.ConvertArrayListToPacket(process.GetProcessList))
            Me.StartSend(sendTo, APPMON_CMD.CMD_TEACHER_POST_PROCESS_LIST, False, strMessage)
        End Sub

        Private Sub SetRemoteAddress()
            Dim file As New IniFile
            file.Load((Application.StartupPath & "\studentinfo.ini"), False)
            Try
                sMessager.remoteAddress = file.GetKeyValue("General", "remote_address")
            Catch exception1 As Exception
                ProjectData.SetProjectError(exception1)
                Dim exception As Exception = exception1
                Interaction.MsgBox("Fail to gather remote address", MsgBoxStyle.ApplicationModal, Nothing)
                ProjectData.ClearProjectError()
            End Try
        End Sub

        Public Sub StartListen()
            Dim Thr As New ThreadStart(AddressOf Me.BeginListen)
            Dim Th As New Thread(Thr)
            Th.Start()
        End Sub

        Public Sub StartSend(ByVal sendTo As String, ByVal cmdMessage As APPMON_CMD, ByVal bIsAckRequired As Boolean, Optional ByVal strMessage As String = "")
            Dim packet As New vPacket
            Dim newData As String = packet.AddPacket(bIsAckRequired.ToString, strMessage)
            newData = packet.AddPacket(cmdMessage.ToString, newData)
            newData = packet.AddPacket(sendTo, newData)
            Me.BeginSend(sMessager.remoteAddress, newData)
        End Sub


        ' Fields
        Private Shared activeApp As String
        Public command As command
        Private Shared GroupEP As IPEndPoint
        Private Shared GroupIP As IPAddress
        Private Shared ListenUdp As UdpClient
        Private Shared remoteAddress As String
    End Class
End Namespace

