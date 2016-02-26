Imports System
Imports System.Text

Namespace kbMonitorNet
    <Serializable> _
    Public Class kbMessage
        ' Methods
        Public Sub New()
            Me.Idenfier = ""
            Me.m_buffersize = 0
            Me.buffer = New Byte(100  - 1) {}
        End Sub

        Public Sub New(ByVal msg As Byte(), ByVal MsgSize As Integer, ByVal nSeq As Integer, ByVal type As MSG_TYPE)
            If (MsgSize >= 100) Then
                MsgSize = 100
            End If
            Me.Idenfier = "XClass kbMon"
            Me.buffer = msg
            Me.nSequent = nSeq
            Me.buffer = New Byte(100  - 1) {}
            Array.Copy(msg, Me.buffer, MsgSize)
            Me.m_buffersize = MsgSize
            Me.m_type = CInt(type)
        End Sub

        Public Sub fromByte(ByVal message As Byte())
            Try 
                Me.Idenfier = New UnicodeEncoding().GetString(message, 0, &H18)
                Me.m_type = BitConverter.ToInt32(message, &H18)
                Dim length As Integer = BitConverter.ToInt32(message, &H1C)
                Me.m_buffersize = length
                Array.Copy(message, &H20, Me.buffer, 0, length)
                Me.nSequent = BitConverter.ToInt32(message, (&H20 + length))
            Catch exception As Exception
                Console.WriteLine(exception.ToString)
            End Try
        End Sub

        Public Function ToByteArray() As Byte()
            Dim destinationArray As Byte() = New Byte(150  - 1) {}
            Dim sourceArray As Byte() = Nothing
            Dim encoding As New UnicodeEncoding
            Dim destinationIndex As Integer = 0
            sourceArray = encoding.GetBytes(Me.Idenfier)
            Array.Copy(sourceArray, destinationArray, sourceArray.Length)
            destinationIndex = (destinationIndex + sourceArray.Length)
            sourceArray = BitConverter.GetBytes(Me.m_type)
            Array.Copy(sourceArray, 0, destinationArray, destinationIndex, sourceArray.Length)
            destinationIndex = (destinationIndex + sourceArray.Length)
            sourceArray = BitConverter.GetBytes(Me.m_buffersize)
            Array.Copy(sourceArray, 0, destinationArray, destinationIndex, sourceArray.Length)
            destinationIndex = (destinationIndex + sourceArray.Length)
            Array.Copy(Me.buffer, 0, destinationArray, destinationIndex, Me.m_buffersize)
            destinationIndex = (destinationIndex + Me.m_buffersize)
            sourceArray = BitConverter.GetBytes(Me.nSequent)
            Array.Copy(sourceArray, 0, destinationArray, destinationIndex, sourceArray.Length)
            destinationIndex = (destinationIndex + sourceArray.Length)
            Return destinationArray
        End Function


        ' Fields
        Public buffer As Byte()
        Public Idenfier As String
        Public m_buffersize As Integer
        Public m_type As Integer
        Public nSequent As Integer
    End Class
End Namespace

