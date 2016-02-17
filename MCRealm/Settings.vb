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
        If Me.DialogResult = Windows.Forms.DialogResult.None OrElse Me.DialogResult = Windows.Forms.DialogResult.Cancel OrElse ErrorOccurred Then Exit Sub
        Dim RestartServer As Boolean = False
        If Changed OrElse Main.ServerRunning Then
            Select Case MsgBox("Server restart needed to apply changes. Restart server?", MsgBoxStyle.YesNoCancel Or MsgBoxStyle.Question)
                Case MsgBoxResult.Yes
                    RestartServer = True
                Case MsgBoxResult.Cancel
                    e.Cancel = True
                    Exit Sub
            End Select
        End If
        Writer = New System.IO.StreamWriter(PropertiesPath, False, System.Text.Encoding.Unicode)
        Writer.WriteLine("#Minecraft server properties")
        Writer.WriteLine("#{0} {1} {2} {3} {4} {5}", WeekdayName(Weekday(Now), True), MonthName(Month(Now), True), Now.Day, Now.TimeOfDay.ToString,
                         If(TimeZone.CurrentTimeZone.IsDaylightSavingTime(Now), TimeZone.CurrentTimeZone.DaylightName.TakeWhile(Function(Character) _
                     Char.IsUpper(Character)), TimeZone.CurrentTimeZone.StandardName.TakeWhile(Function(Character) Char.IsUpper(Character))), Now.Year)
        '#Thu Feb 04 18:24:36 CST 2016
        Writer.WriteLine("allow-flight={0}", AllowFlight.Checked.ToString.ToLower)
        Writer.WriteLine("allow-nether={0}", AllowNether.Checked.ToString.ToLower)
        Writer.WriteLine("announce-player-achievements={0}", AnnouncePlayerAchievements.Checked.ToString.ToLower)
        Writer.WriteLine("broadcast-console-to-ops={0}", BroadcastConsoleToOPs.Checked.ToString.ToLower)
        Writer.WriteLine("debug={0}", Debug.Checked.ToString.ToLower)
        Writer.WriteLine("difficulty={0}", Difficulty.SelectedIndex)
        Writer.WriteLine("enable-command-block={0}", EnableCommandBlocks.Checked.ToString.ToLower)
        Writer.WriteLine("enable-query={0}", EnableQuery.Checked.ToString.ToLower)
        Writer.WriteLine("enable-rcon={0}", EnableRemoteConnection.Checked.ToString.ToLower)
        Writer.WriteLine("force-gamemode={0}", ForceDefaultGamemode.Checked.ToString.ToLower)
        Writer.WriteLine("gamemode={0}", DefaultGamemode.SelectedIndex)
        Writer.WriteLine("generate-structures={0}", GenerateStructures.Checked.ToString.ToLower)
        Writer.WriteLine("hardcore={0}", Hardcore.Checked.ToString.ToLower)
        Writer.WriteLine("max-build-height={0}", MaximumBuildHeight.Value)
        Writer.WriteLine("max-players={0}", MaximumPlayers.Value)
        Writer.WriteLine("max-tick-time={0}", MaximumTickTime.Value)
        Writer.WriteLine("max-world-size={0}", MaximumWorldSize.Value)
        Writer.WriteLine("motd={0}", MessageOfTheDay.Text)
        Writer.WriteLine("network-compression-threshold={0}", NetworkCompressionThreshold.Value)
        Writer.WriteLine("online-mode={0}", OnlineMode.Checked.ToString.ToLower)
        Writer.WriteLine("op-permission-level={0}", OPPermissionLevel.Value)
        Writer.WriteLine("player-idle-timeout={0}", If(PlayerIdleTimeoutCheckBox.Checked, PlayerIdleTimeout.Value, 0))
        Writer.WriteLine("pvp={0}", PVP.Checked.ToString.ToLower)
        Writer.WriteLine("query.port={0}", QueryPort.Value)
        Writer.WriteLine("rcon.port={0}", RemoteConnectionPort.Value)
        Writer.WriteLine("rcon.password={0}", RemoteConnectionPassword.Text)
        Writer.WriteLine("server-ip={0}", IP.Text)
        Writer.WriteLine("server-port={0}", ServerPort.Value)
        Writer.WriteLine("snooper-enabled={0}", EnableSnooper.Checked)
        Writer.WriteLine("spawn-animals={0}", SpawnAnimals.Checked)
        Writer.WriteLine("spawn-monsters={0}", SpawnMonsters.Checked)
        Writer.WriteLine("spawn-npcs={0}", SpawnVillagers.Checked)
        Writer.WriteLine("spawn-protection={0}", SpawnProtection.Value)
        Writer.WriteLine("view-distance={0}", ViewDistance.Value)
        Writer.WriteLine("white-list={0}", UseWhiteList.Checked)
        Writer.Flush()
        Writer.Close()
        If RestartServer Then
            Main.RunServer_Click(sender, e)
            Main.RunServer_Click(sender, e)
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

    Private Sub SpawnProtection_ValueChanged(sender As Object, e As EventArgs) Handles SpawnProtection.ValueChanged, SpawnProtection.KeyUp, SpawnProtection.Scroll,
                                                                                       MaximumWorldSize.ValueChanged, MaximumWorldSize.KeyUp, MaximumWorldSize.Scroll
        SpawnProtectionCalculation.Text = String.Format("{0}×{0}", 2 * SpawnProtection.Value + 1)
        MaximumWorldSizeCalculation.Text = String.Format("{0}×{0}", 2 * MaximumWorldSize.Value)
    End Sub

    Private Sub ResetToDefault_Click(sender As Object, e As EventArgs) Handles ResetToDefault.Click
        JAVASwitch.Value = 1
        MemoryMinimum.Value = 512
        MemoryMinimumUnit.SelectedIndex = 1
        MemoryMaximum.Value = 2048
        MemoryMaximumUnit.SelectedIndex = 1
        AllowFlight.Checked = False
        AllowNether.Checked = True
        AnnouncePlayerAchievements.Checked = True
        BroadcastConsoleToOPs.Checked = True
        Debug.Checked = False
        DefaultGamemode.SelectedIndex = 0
        Difficulty.SelectedIndex = 1
        EnableCommandBlocks.Checked = False
        EnableQuery.Checked = False
        EnableRemoteConnection.Checked = False
        EnableSnooper.Checked = True
        ForceDefaultGamemode.Checked = False
        GenerateStructures.Checked = True
        Hardcore.Checked = False
        IP.Text = Nothing
        MaximumBuildHeight.Value = 256
        MaximumPlayers.Value = 20
        MaximumTickTime.Value = 60000
        MaximumWorldSize.Value = 29999984
        MessageOfTheDay.Text = "A Minecraft Server"
        NetworkCompressionThresholdValue = 256
        NetworkCompressionThreshold.Value = 256
        OnlineMode.Checked = True
        OPPermissionLevel.Value = 4
        PlayerIdleTimeout.Value = 30
        PlayerIdleTimeoutCheckBox.Checked = False
        PVP.Checked = True
        QueryPort.Value = 25565
        RemoteConnectionPassword.Text = Nothing
        RemoteConnectionPort.Value = 25575
        ServerPort.Value = 25565
        SpawnAnimals.Checked = True
        SpawnMonsters.Checked = True
        SpawnProtection.Value = 16
        SpawnVillagers.Checked = True
        UseWhiteList.Checked = False
        ViewDistance.Value = 10
    End Sub
End Class
