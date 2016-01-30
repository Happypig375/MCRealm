Public Class Main
    Friend WithEvents Server As New Process()

    Private Sub Main_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Server.StandardInput.WriteLine("EXIT") 'send an EXIT command to the Command Prompt
        Server.StandardInput.Flush()
        Server.Close()
    End Sub
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

    Private Delegate Sub AppendOutputTextDelegate(sender As Object, e As System.Diagnostics.DataReceivedEventArgs)
    Private Sub RunServer_Click(sender As Object, e As EventArgs) Handles RunServer.Click
        Try

            With Server.StartInfo
                .WorkingDirectory = System.IO.Path.GetDirectoryName(JAR.Text)
                .FileName = "java.exe"
                .Arguments = String.Format("-Xms1024M -Xmx2048M -jar {0} nogui -o true", JAR.Text)
                .UseShellExecute = False
                .CreateNoWindow = True
                .RedirectStandardInput = True
                .RedirectStandardOutput = True
                .RedirectStandardError = True
            End With
            ' You can start any process, HelloWorld is a do-nothing example.
            With Server
                .Start()
                .BeginErrorReadLine()
                .BeginOutputReadLine()
            End With
            ' This code assumes the process you are starting will terminate itself. 
            ' Given that is is started without a window so you cannot terminate it 
            ' on the desktop, it must terminate itself or you can do it programmatically
            ' from this application using the Kill method.
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Critical)
        End Try
    End Sub
    Private Sub Display(sender As Object, e As System.Diagnostics.DataReceivedEventArgs) Handles Server.ErrorDataReceived, Server.OutputDataReceived

    End Sub
    Private Sub AppendOutputText(Text As String)
#If True Then

        If Output.InvokeRequired Then
            Dim myDelegate As New AppendOutputTextDelegate(AddressOf Display)
            Me.Invoke(myDelegate, Text)
        Else
            Output.AppendText(Text)
        End If
#Else
        Output.Text &= Text
#End If
    End Sub
End Class
