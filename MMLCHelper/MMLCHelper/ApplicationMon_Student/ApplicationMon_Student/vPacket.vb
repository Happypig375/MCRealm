Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.Collections

Namespace ApplicationMon_Student
    Public Class vPacket
        ' Methods
        Public Function AddPacket(ByVal data As String, ByVal newData As String) As String
            Return (data & "|||||" & newData)
        End Function

        Public Function ConvertArrayListToPacket(ByVal strArrayList As ArrayList) As Object
            Dim data As String = ""
            Dim count As Integer = strArrayList.Count
            Dim num3 As Integer = (count - 1)
            Dim i As Integer = 0
            Do While (i <= num3)
                data = Me.AddPacket(data, Conversions.ToString(strArrayList.Item(i)))
                i += 1
            Loop
            Return data
        End Function

        Public Function GetAcknowledgement(ByVal message As String) As String
            Return message.Split(New String() { "|||||" }, StringSplitOptions.RemoveEmptyEntries)(3)
        End Function

        Public Function GetDestPCName(ByVal message As String) As String
            Return message.Split(New String() { "|||||" }, StringSplitOptions.RemoveEmptyEntries)(1)
        End Function

        Public Function GetHostPCName(ByVal message As String) As String
            Return message.Split(New String() { "|||||" }, StringSplitOptions.RemoveEmptyEntries)(0)
        End Function

        Public Function GetReceivedCommand(ByVal message As String) As String
            Return message.Split(New String() { "|||||" }, StringSplitOptions.RemoveEmptyEntries)(2)
        End Function

        Public Function GetReceivedMsgData(ByVal message As String) As ArrayList
            Dim list2 As New ArrayList
            Dim strArray As String() = message.Split(New String() { "|||||" }, StringSplitOptions.RemoveEmptyEntries)
            Dim num2 As Integer = (strArray.Length - 1)
            Dim i As Integer = 4
            Do While (i <= num2)
                list2.Add(strArray(i))
                i += 1
            Loop
            Return list2
        End Function

    End Class
End Namespace

