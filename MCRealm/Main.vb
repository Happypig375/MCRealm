Public Class Main
    Friend WithEvents Server As New Process()
    Friend ReadOnly Property ServerRunning As Boolean
        Get
            Return Not Server.HasExited
        End Get
    End Property
    Private Sub Main_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If ServerRunning Then RunServer_Click(sender, e)
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
    'Dim ProcID As Integer
    Private Delegate Sub AppendOutputTextDelegate(Text As String)
    Private Sub RunServer_Click(sender As Object, e As EventArgs) Handles ServerSwitch.Click
        Try
            If ServerRunning Then
                    Server.StandardInput.WriteLine("/stop") 'send an EXIT command to the Command Prompt
                    Server.StandardInput.Flush()
                    Server.Close()
                Main_FormClosing(sender, CType(e, FormClosingEventArgs))
                ServerSwitch.Text = "Run Server"
            Else
#If False Then
            ProcID = Shell("java.exe", AppWinStyle.NormalFocus)
            AppActivate(ProcID)
            SendKeys.Send(Input.Text)
            Me.TopMost = True
            Me.Focus()
#Else
#If False Then
            'Declare Processes
            Dim appDataStartInfo As ProcessStartInfo = New ProcessStartInfo()
            Dim javaStartInfo As ProcessStartInfo = New ProcessStartInfo()
            Dim appPath As String = Application.StartupPath()
            'Launch appdata relocation process
            appDataStartInfo.FileName = "cmd.exe"
            appDataStartInfo.Arguments = "/c start cd " & appPath & "&& set APPDATA=" & appPath & "\LocalAppData"
            appDataStartInfo.UseShellExecute = True
            Process.Start(appDataStartInfo)
            'Launch Minecraft
            javaStartInfo.FileName = "javaw.exe"
            javaStartInfo.Arguments = "-Xms4096M -Xmx4096M -cp " & appPath & "\LocalAppData\.minecraft\bin\Minecraft.jar net.minecraft.LauncherFrame"
            javaStartInfo.UseShellExecute = True
            Process.Start(javaStartInfo)
#End If

                With Server.StartInfo
                    .WorkingDirectory = System.IO.Path.GetDirectoryName(JAR.Text)
                    .FileName = "javaw.exe"
                    .Arguments = String.Format("-Xms1024M -Xmx2048M -jar ""{0}"" nogui -o true", JAR.Text)
                    .UseShellExecute = False
                    .CreateNoWindow = True
                    .RedirectStandardInput = True
                    .RedirectStandardOutput = True
                    .RedirectStandardError = True
                End With
                ' You can start any process, HelloWorld is a do-nothing example.
                With Server
                    .EnableRaisingEvents = True
                    .Start()
                    .BeginErrorReadLine()
                    .BeginOutputReadLine()
                End With
#End If
                ServerSwitch.Text = "Stop Server"
                ' This code assumes the process you are starting will terminate itself. 
                ' Given that is is started without a window so you cannot terminate it 
                ' on the desktop, it must terminate itself or you can do it programmatically
                ' from this application using the Kill method.
            End If
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Critical)
        End Try
    End Sub
    Private Sub Display(sender As Object, e As System.Diagnostics.DataReceivedEventArgs) Handles Server.ErrorDataReceived, Server.OutputDataReceived
        AppendOutputText(e.Data & vbCrLf)
    End Sub
    Private Sub AppendOutputText(Text As String)
#If True Then

        If Output.InvokeRequired Then
            Dim myDelegate As New AppendOutputTextDelegate(AddressOf AppendOutputText)
            Me.Invoke(myDelegate, Text)
        Else
            Output.AppendText(Text)
        End If
#Else
        Output.Text &= Text
#End If
    End Sub

    Private Sub Input_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Input.KeyPress
        If e.KeyChar <> Chr(13) Then Exit Sub
#If False Then
        AppActivate(Server.Id)
        SendKeys.Send(Input.Text)
        Me.TopMost = True
        Me.Focus()
#Else
        Server.StandardInput.WriteLine(Input.Text)
        Input.Clear()
#End If
    End Sub
End Class
