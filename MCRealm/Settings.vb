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

    Private Sub Apply_Button_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Apply_Button.Click

    End Sub

    Private Sub Settings_FormClosed(ByVal sender As Object, ByVal e As FormClosedEventArgs) Handles Me.FormClosed

    End Sub

    Private Sub Settings_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
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
        Try
            Do While Reader.Peek() >= 0
                Dim Line(1) As String
                Line(0) = Reader.ReadLine
                If Not Line(0).Contains("="c) Then Continue Do
                'Line = Line(0).Split("="c)
                Line(1) = Line(0).Skip(Line(0).IndexOf("="c) + 1).ToString
                Line(0) = Line(0).Take(Line(0).IndexOf("="c) + 1).ToString.ToLower
                Select Case Line(0)
                    Case "#"
                        Continue Do
                    Case "allow-flight"
                        AllowFlight.Checked = Convert.ToBoolean(Line(1))
                    Case "allow-nether"
                        AllowNether.Checked = Convert.ToBoolean(Line(1))
                    Case "announce-player-achievements"
                        AnnouncePlayerAchievements.Checked = Convert.ToBoolean(Line(1))
                    Case "broadcast-console-to-ops"
                        BroadcastConsoleToOPs.Checked = Convert.ToBoolean(Line(1))
                    Case "debug"
                        Debug.Checked = Convert.ToBoolean(Line(1))
                    Case "difficulty"
                        Difficulty.SelectedIndex = CInt(Line(1))
                    Case "enable-command-block"
                        EnableCommandBlocks.Checked = Convert.ToBoolean(Line(1))
                    Case "enable-query"
                        EnableQuery.Checked = Convert.ToBoolean(Line(1))
                    Case "enable-rcon"
                        EnableRemoteConnection.Checked = Convert.ToBoolean(Line(1))
                    Case "force-gamemode"
                        ForceDefaultGamemode.Checked = Convert.ToBoolean(Line(1))
                    Case "gamemode"
                        DefaultGamemode.SelectedIndex = CInt(Line(1))
                    Case "generate-structures"
                        GenerateStructures.Checked = Convert.ToBoolean(Line(1))
                    Case "generator-settings"
                    Case "hardcore"
                        Hardcore.Checked = Convert.ToBoolean(Line(1))
                    Case "level-name"
                    Case "level-seed"
                    Case "level-type"
                    Case "max-build-height"
                        MaximumBuildHeight.Value = CDec(Line(1))
                    Case "max-players"
                        MaximumPlayers.Value = CDec(Line(1))
                    Case "max-tick-time"
                        MaximumTickTime.Value = CDec(Line(1))
                    Case "max-world-size"
                        MaximumWorldSize.Value = CDec(Line(1))
                    Case "motd"
                        MessageOfTheDay.Text = Line(1)
                    Case "network-compression-threshold"
                        NetworkCompressionThreshold.Value = CDec(Line(1))
                    Case "online-mode"
                        OnlineMode.Checked = Convert.ToBoolean(Line(1))
                    Case "op-permission-level"
                        OPPermissionLevel.Value = CDec(Line(1))
                    Case "player-idle-timeout"
                        If Val(Line(1)) = 0 Then
                            PlayerIdleTimeoutCheckBox.Checked = False
                            PlayerIdleTimeout.Enabled = False
                        Else
                            PlayerIdleTimeoutCheckBox.Checked = True
                            PlayerIdleTimeout.Value = CDec(Line(1))
                        End If
                    Case "pvp"
                        PVP.Checked = Convert.ToBoolean(Line(1))
                    Case "query.port"
                        QueryPort.Value = CDec(Line(1))
                    Case "rcon.port"
                        RemoteConnectionPort.Value = CDec(Line(1))
                    Case "rcon.password"
                        RemoteConnectionPassword.Text = Line(1)
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

    Private Sub RemoteConnectionPasswordButton_MouseDown(ByVal sender As Object, ByVal e As MouseEventArgs) Handles RemoteConnectionPasswordButton.MouseDown
        RemoteConnectionPassword.PasswordChar = Nothing
    End Sub

    Private Sub RemoteConnectionPasswordButton_MouseMove(ByVal sender As Object, ByVal e As MouseEventArgs) Handles RemoteConnectionPasswordButton.MouseMove
        If e.X < RemoteConnectionPasswordButton.Location.X OrElse e.X > RemoteConnectionPasswordButton.Location.X +
            RemoteConnectionPasswordButton.Size.Width OrElse e.Y < RemoteConnectionPasswordButton.Location.Y OrElse e.Y >
            RemoteConnectionPasswordButton.Location.Y + RemoteConnectionPasswordButton.Size.Height Then RemoteConnectionPassword.PasswordChar = "*"c
    End Sub

    Private Sub RemoteConnectionPasswordButton_MouseUp(ByVal sender As Object, ByVal e As EventArgs) Handles RemoteConnectionPasswordButton.MouseUp
        RemoteConnectionPassword.PasswordChar = "*"c
    End Sub

End Class
