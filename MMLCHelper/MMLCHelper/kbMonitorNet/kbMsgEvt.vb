Imports System

Namespace kbMonitorNet
    Public Class kbMsgEvt
        Inherits EventArgs
        ' Methods
        Public Sub New(ByVal content As kbMessage, ByVal ip As String)
            Me.kbMsgContent = content
            Me.strIp = ip
        End Sub

        Public Function Content() As kbMessage
            Return Me.kbMsgContent
        End Function

        Public Function IpFrom() As String
            Return Me.strIp
        End Function


        ' Fields
        Private kbMsgContent As kbMessage
        Private strIp As String
    End Class
End Namespace

