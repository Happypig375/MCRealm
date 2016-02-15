Imports System.Windows.Forms
Imports System.IO

Public Class Settings
    Friend Reader As System.IO.StreamReader
    Friend Writer As System.IO.StreamWriter
    Friend Changed As Boolean
    Friend ErrorOccurred As Boolean
    Friend PropertiesPath As String
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

    Private Sub Settings_FormClosing(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles Me.FormClosing
        If Not (Me.DialogResult = Windows.Forms.DialogResult.None Or Me.DialogResult = Windows.Forms.DialogResult.Cancel Or ErrorOccurred) Then
            Writer = New System.IO.StreamWriter(PropertiesPath, False, System.Text.Encoding.Unicode)
            Writer.WriteLine("#Minecraft server properties")
            Writer.WriteLine("#{0} {1} {2} {3} {4} {5}", WeekdayName(Weekday(Now)), MonthName(Month(Now)), Now.Day, Now.TimeOfDay.ToString,
                             If(TimeZone.CurrentTimeZone.IsDaylightSavingTime(Now), TimeZone.CurrentTimeZone.DaylightName.TakeWhile(Function(Character) _
                         Char.IsUpper(Character)), TimeZone.CurrentTimeZone.StandardName.TakeWhile(Function(Character) Char.IsUpper(Character))), Now.Year)
            '#Thu Feb 04 18:24:36 CST 2016
            Writer.WriteLine("allow-flight={0}", AllowFlight.Checked.ToString.ToLower)
            Writer.WriteLine("allow-nether={0}", AllowNether.Checked.ToString.ToLower)
        End If
    End Sub

    Private Sub Settings_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        Try
            PropertiesPath = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(Main.JAR.Text), "server.properties")
        Catch ex As ArgumentException
            ErrorOccurred = True
            Main.DisplayError(ex)
            Me.Close()
            Exit Sub
        End Try
        If Not File.Exists(PropertiesPath) Then
            ErrorOccurred = True
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
                Line(1) = New String(Line(0).Skip(Line(0).IndexOf("="c) + 1).ToArray)
                Line(0) = New String(Line(0).Take(Line(0).IndexOf("="c)).ToArray).ToLower
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
                        IP.Text = Line(1)
                    Case "server-port"
                        ServerPort.Value = CDec(Line(1))
                    Case "snooper-enabled"
                        EnableSnooper.Checked = Convert.ToBoolean(Line(1))
                    Case "spawn-animals"
                        SpawnAnimals.Checked = Convert.ToBoolean(Line(1))
                    Case "spawn-monsters"
                        SpawnMonsters.Checked = Convert.ToBoolean(Line(1))
                    Case "spawn-npcs"
                        SpawnVillagers.Checked = Convert.ToBoolean(Line(1))
                    Case "spawn-protection"
                        SpawnProtection.Value = Convert.ToDecimal(Line(1))
                    Case "view-distance"
                        ViewDistance.Value = CDec(Line(1))
                    Case "white-list"
                        UseWhiteList.Checked = Convert.ToBoolean(Line(1))
                End Select
            Loop
        Catch ex As Exception
            Main.DisplayError(ex)
        Finally
            Reader.Close()
            Changed = False
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
    Friend NetworkCompressionThresholdValue As Integer
    Private Sub NetworkCompressionThreshold_ValueChanged(sender As Object, e As EventArgs) Handles NetworkCompressionThreshold.ValueChanged
        Select Case NetworkCompressionThreshold.Value
            Case Is < 40
                If MsgBox("The Ethernet spec requires that packets less than 64 bytes become padded to 64 bytes." & vbCrLf &
                       "Thus, setting a value lower than 64 may not be beneficial." & vbCrLf & "Do you still want to continue?",
                       MsgBoxStyle.YesNo Or MsgBoxStyle.Question) = MsgBoxResult.No Then
                    NetworkCompressionThreshold.Value = NetworkCompressionThresholdValue
                End If
            Case Is > 1500
                If MsgBox("It is not recommended to exceed the Maximum Transmission Unit (MTU), typically 1500 bytes." & vbCrLf &
                       "Do you still want to continue?",
                       MsgBoxStyle.YesNo Or MsgBoxStyle.Question) = MsgBoxResult.No Then
                    NetworkCompressionThreshold.Value = NetworkCompressionThresholdValue
                End If
            Case Else
                NetworkCompressionThresholdValue = CInt(NetworkCompressionThreshold.Value)
        End Select
    End Sub
    Private Sub Settings_Changed(sender As Object, e As EventArgs) Handles AllowFlight.CheckedChanged, AllowNether.CheckedChanged,
         AnnouncePlayerAchievements.CheckedChanged, BroadcastConsoleToOPs.CheckedChanged, Debug.CheckedChanged, DefaultGamemode.SelectedIndexChanged,
         Difficulty.SelectedIndexChanged, EnableCommandBlocks.CheckedChanged, EnableQuery.CheckedChanged, EnableRemoteConnection.CheckedChanged,
         EnableSnooper.CheckedChanged, ForceDefaultGamemode.CheckedChanged, GenerateStructures.CheckedChanged, Hardcore.CheckedChanged, IP.TextChanged,
         JAVASwitch.ValueChanged, MaximumBuildHeight.ValueChanged, MaximumPlayers.ValueChanged, MaximumTickTime.ValueChanged, MaximumWorldSize.ValueChanged,
         MemoryMaximum.ValueChanged, MemoryMaximumUnit.SelectedIndexChanged, MemoryMinimum.ValueChanged, MemoryMinimumUnit.SelectedIndexChanged,
        MessageOfTheDay.TextChanged, NetworkCompressionThreshold.ValueChanged, OnlineMode.CheckedChanged, OPPermissionLevel.ValueChanged, PlayerIdleTimeout.ValueChanged,
        PlayerIdleTimeoutCheckBox.CheckedChanged, PVP.CheckedChanged, QueryPort.ValueChanged, RemoteConnectionPassword.TextChanged, RemoteConnectionPort.ValueChanged,
        ServerPort.ValueChanged, SpawnAnimals.CheckedChanged, SpawnMonsters.CheckedChanged, SpawnVillagers.CheckedChanged, SpawnProtection.ValueChanged,
        UseWhiteList.CheckedChanged, ViewDistance.ValueChanged
        Changed = True
    End Sub

    Private Sub SpawnProtection_ValueChanged(sender As Object, e As EventArgs) Handles SpawnProtection.ValueChanged, SpawnProtection.KeyUp, SpawnProtection.Scroll
        SpawnProtectionCalculation.Text = String.Format("{0}×{0}", 2 * SpawnProtection.Value + 1)
    End Sub
End Class
