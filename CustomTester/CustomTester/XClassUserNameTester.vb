Public Class XClassUserNameTester
    Dim Writer As IO.StreamWriter = New IO.StreamWriter(GetDrive() & ":\Response.log", True)
    Private Sub XClassUserNameTester_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Writer.WriteLine("[" & Now & "] XClass process username is " & GetUserName("xstudent"))
        Writer.Flush()
        End
    End Sub
    Public Function GetUserName(ByVal ProcessName As String)
        Dim selectQuery As Management.SelectQuery = New Management.SelectQuery("Win32_Process")
        Dim searcher As Management.ManagementObjectSearcher =
            New Management.ManagementObjectSearcher(selectQuery)
        Dim y As System.Management.ManagementObjectCollection
        y = searcher.Get
        For Each proc As Management.ManagementObject In y
            Dim s(1) As String
            proc.InvokeMethod("GetOwner", CType(s, Object()))
            Dim n As String = proc("Name").ToString()
            If n = ProcessName & ".exe" Then
                Return ("User: " & s(1) & "\\" & s(0))
            End If
        Next
        Return ("PROCESS NOT RUNNING")
    End Function
    Public Function GetDrive() As Char
        Return Strings.GetChar(My.Computer.FileSystem.CurrentDirectory, 1)
    End Function
End Class
