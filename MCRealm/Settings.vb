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

    Private Sub Settings_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim PropertiesPath As String
        Try
            PropertiesPath = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(Main.JAR.Text), "server.properites")
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
        Writer = New System.IO.StreamWriter(PropertiesPath)
        Reader.ReadLine()
        Try
            Do While Reader.Peek() >= 0
                Dim Line As String = Reader.ReadLine
                If Not Line.Contains("="c) Then Continue Do
                Select Case Line.Take(Line.IndexOf("="c)).ToString.ToLower
                    Case "#"
                        Continue Do
                    Case "allow-flight"
                    Case "spawn-protection"
                    Case "max-tick-time"
                    Case "query.port"
                    Case "generator-Settings"
                    Case "force-gamemode"
                    Case "allow-nether"
                    Case "gamemode"
                    Case "broadcast-console-to-ops"
                    Case "enable-query"
                    Case "player-idle-timeout"
                    Case "difficulty"
                    Case "spawn-monsters"
                    Case "op-permission-level"
                    Case "resource-pack-hash"
                    Case "announce-player-achievements"
                    Case "pvp"
                    Case "snooper-enabled"
                    Case "level-type"
                    Case "hardcore"
                    Case "enable-Command-block"
                    Case "max-players"
                    Case "network-compression-threshold"
                    Case "resource-pack-sha1"
                    Case "max-world-size"
                    Case "rcon.port"
                    Case "server-port"
                    Case "debug"
                    Case "server-ip"
                    Case "spawn-npcs"
                    Case "level-name"
                    Case "view-distance"
                    Case "resource-pack"
                    Case "spawn-animals"
                    Case "white-list"
                    Case "rcon.password"
                    Case "generate-structures"
                    Case "max-build-height"
                    Case "online-mode"
                    Case "level-seed"
                    Case "motd"
                    Case "enable-rcon"
                End Select
            Loop
            Reader.Close()
        Catch ex As Exception
            Main.DisplayError(ex)
        End Try
    End Sub
End Class
