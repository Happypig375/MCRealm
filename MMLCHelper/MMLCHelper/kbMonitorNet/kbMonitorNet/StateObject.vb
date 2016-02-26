Imports System
Imports System.Net.Sockets
Imports System.Text

Namespace kbMonitorNet
    Public Class StateObject
        ' Fields
        Public buffer As Byte() = New Byte(150  - 1) {}
        Public sb As StringBuilder = New StringBuilder
        Public workSocket As Socket
    End Class
End Namespace

