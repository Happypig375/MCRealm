Imports System
Imports System.Net
Imports System.Net.Sockets
Imports System.Runtime.CompilerServices

Namespace kbMonitorNet
    Public Class kbUdp
        ' Events
        Public Shared Custom Event MsgRecv As kbMsgEventHandler

        ' Methods
        Public Sub New(ByVal ip As String, ByVal port As Integer, ByVal bIsListener As Boolean)
            Me.SetRemoteAddr(ip)
            Me.SetUdpPort(port)
            Me.StartUdp(bIsListener)
            Me.ReceiveBroadcastMessages
        End Sub

        Public Sub BroadcastMessage(ByVal message As kbMessage)
            Try 
                Dim remoteEP As New IPEndPoint(Me.remoteAddress, Me.udpPort)
                Dim buffer As Byte() = message.ToByteArray
                Me.udpSocket.SendTo(buffer, remoteEP)
            Catch exception As Exception
                Console.WriteLine((ChrW(10) & exception.ToString))
            End Try
        End Sub

        Public Sub CloseListener()
            Try 
                Me.udpSocket.Shutdown(SocketShutdown.Receive)
                Me.udpSocket.Close
            Catch exception As Exception
                Console.WriteLine(exception.ToString)
            End Try
        End Sub

        Protected Overrides Sub Finalize()
            Try 
                Me.udpSocket.Close
            Finally
                MyBase.Finalize
            End Try
        End Sub

        Protected Shared Sub OnMsgRecv(ByVal sender As Object, ByVal e As kbMsgEvt)
            If (Not kbUdp.MsgRecv Is Nothing) Then
                kbUdp.MsgRecv.Invoke(sender, e)
            End If
        End Sub

        Public Sub ReceiveBroadcastMessages()
            Try 
                Dim state As New StateObject With { _
                    .workSocket = Me.udpSocket _
                }
                Dim point As New IPEndPoint(IPAddress.Any, 0)
                Dim remoteEP As EndPoint = point
                Me.udpSocket.BeginReceiveFrom(state.buffer, 0, 150, SocketFlags.None, remoteEP, New AsyncCallback(AddressOf Me.ReceiveCallback), state)
            Catch exception As Exception
                Console.WriteLine(exception.ToString)
            End Try
        End Sub

        Private Sub ReceiveCallback(ByVal ar As IAsyncResult)
            Try 
                Dim asyncState As StateObject = DirectCast(ar.AsyncState, StateObject)
                Dim workSocket As Socket = asyncState.workSocket
                Dim point As New IPEndPoint(IPAddress.Any, 0)
                Dim endPoint As EndPoint = point
                If (workSocket.EndReceiveFrom(ar, endPoint) >= 150) Then
                    Dim content As New kbMessage
                    content.fromByte(asyncState.buffer)
                    If (content.Idenfier = "XClass kbMon") Then
                        Dim ip As String = DirectCast(endPoint, IPEndPoint).Address.ToString
                        Dim e As New kbMsgEvt(content, ip)
                        kbUdp.OnMsgRecv(workSocket, e)
                    End If
                End If
                workSocket.BeginReceiveFrom(asyncState.buffer, 0, 150, SocketFlags.None, endPoint, New AsyncCallback(AddressOf Me.ReceiveCallback), asyncState)
            Catch exception As Exception
                Console.WriteLine(exception.ToString)
            End Try
        End Sub

        Private Sub SetRemoteAddr(ByVal ip As String)
            Me.remoteAddress = IPAddress.Parse(ip)
        End Sub

        Private Sub SetUdpPort(ByVal port As Integer)
            Me.udpPort = port
        End Sub

        Public Sub StartUdp(ByVal listener As Boolean)
            Try 
                Me.udpSocket = New Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp)
                Dim any As IPAddress = IPAddress.Any
                If listener Then
                    Dim localEP As EndPoint = New IPEndPoint(any, Me.udpPort)
                    Me.udpSocket.Bind(localEP)
                End If
            Catch exception As Exception
                Console.WriteLine(exception.ToString)
            End Try
        End Sub


        ' Fields
        Private remoteAddress As IPAddress
        Private udpPort As Integer
        Private udpSocket As Socket
    End Class
End Namespace

