Imports System.Windows.Forms
Imports System.IO

Public Class Settings
    Friend Reader As System.IO.StreamReader
    Friend Writer As System.IO.StreamWriter
    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub Apply_Button_Click(sender As Object, e As EventArgs) Handles Apply_Button.Click

    End Sub

    Private Sub Settings_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed

    End Sub

    Private Sub Settings_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim PropertiesPath As String
        Try
            PropertiesPath = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(Main.JAR.Text), "server.properties")
        Catch ex As ArgumentException
            Main.DisplayError(ex)
            Me.Close()
            Exit Sub
        End Try
        If Not File.Exists(PropertiesPath) Then
            Main.DisplayError(New FileNotFoundException("server.properties not found!", PropertiesPath))
            Me.Close()
            Exit Sub
        End If
        Reader = New System.IO.StreamReader(PropertiesPath)
        Reader.ReadLine()
        Try
            Do While Reader.Peek() >= 0
                Dim Line As String = Reader.ReadLine
                If Not Line.Contains("="c) Then Continue Do
                Select Case Line.Take(Line.IndexOf("="c)).ToString.ToLower
                    Case "#"
                        Continue Do
                    Case "allow-flight"
                    Case "allow-nether"
                    Case "announce-player-achievements"
                    Case "broadcast-console-to-ops"
                    Case "debug"
                    Case "difficulty"
                    Case "enable-command-block"
                    Case "enable-query"
                    Case "enable-rcon"
                    Case "force-gamemode"
                    Case "gamemode"
                    Case "generate-structures"
                    Case "generator-settings"
                    Case "hardcore"
                    Case "level-name"
                    Case "level-seed"
                    Case "level-type"
                    Case "max-build-height"
                    Case "max-players"
                    Case "max-tick-time"
                    Case "max-world-size"
                    Case "motd"
                    Case "network-compression-threshold"
                    Case "online-mode"
                    Case "op-permission-level"
                    Case "player-idle-timeout"
                    Case "pvp"
                    Case "query.port"
                    Case "rcon.port"
                    Case "rcon.password"
                    Case "resource-pack"
                    Case "resource-pack-hash"
                    Case "resource-pack-sha1"
                    Case "server-ip"
                    Case "server-port"
                    Case "snooper-enabled"
                    Case "spawn-animals"
                    Case "spawn-monsters"
                    Case "spawn-npcs"
                    Case "spawn-protection"
                    Case "view-distance"
                    Case "white-list"
                End Select
            Loop
            Reader.Close()
        Catch ex As Exception
            Main.DisplayError(ex)
        End Try
    End Sub
    'Writer = New System.IO.StreamWriter(PropertiesPath)

    Private Sub RemoteConnectionPasswordButton_MouseDown(sender As Object, e As MouseEventArgs) Handles RemoteConnectionPasswordButton.MouseDown
        RemoteConnectionPassword.PasswordChar = Nothing
    End Sub

    Private Sub RemoteConnectionPasswordButton_MouseMove(sender As Object, e As MouseEventArgs) Handles RemoteConnectionPasswordButton.MouseMove
        If e.X < RemoteConnectionPasswordButton.Location.X OrElse e.X > RemoteConnectionPasswordButton.Location.X +
            RemoteConnectionPasswordButton.Size.Width OrElse e.Y < RemoteConnectionPasswordButton.Location.Y OrElse e.Y >
            RemoteConnectionPasswordButton.Location.Y + RemoteConnectionPasswordButton.Size.Height Then RemoteConnectionPassword.PasswordChar = "*"c
    End Sub

    Private Sub RemoteConnectionPasswordButton_MouseUp(sender As Object, e As EventArgs) Handles RemoteConnectionPasswordButton.MouseUp
        RemoteConnectionPassword.PasswordChar = "*"c
    End Sub

End Class
