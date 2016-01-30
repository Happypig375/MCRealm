Public Class Main
    Dim Server As New Process()
    Private Sub Main_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub LoadWorld_Click(sender As Object, e As EventArgs) Handles LoadWorld.Click
        If Load_From.ShowDialog = System.Windows.Forms.DialogResult.Cancel Then Exit Sub
        Path.Text = Load_From.Path
    End Sub

    Private Sub LoadJAR_Click(sender As Object, e As EventArgs) Handles LoadJAR.Click
        If Load_From.ShowDialog = System.Windows.Forms.DialogResult.Cancel Then Exit Sub
        JAR.Text = Load_From.Path
    End Sub

    Private Sub About_Click(sender As Object, e As EventArgs) Handles About.Click
        AboutBox.Show()
    End Sub

    Private Sub RunServer_Click(sender As Object, e As EventArgs) Handles RunServer.Click
        Try

            Server.StartInfo.UseShellExecute = False
            ' You can start any process, HelloWorld is a do-nothing example.
            Server.StartInfo.FileName = JAR.Text
            Server.StartInfo.CreateNoWindow = True
            Server.Start()
            ' This code assumes the process you are starting will terminate itself. 
            ' Given that is is started without a window so you cannot terminate it 
            ' on the desktop, it must terminate itself or you can do it programmatically
            ' from this application using the Kill method.
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Critical)
        End Try
    End Sub
End Class
