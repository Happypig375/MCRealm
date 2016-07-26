Imports System.Windows.Forms
Imports System.IO

Public Class Settings
    Friend Changed As Boolean
    Friend ErrorOccurred As Boolean
    Friend PropertiesPath As String
    Friend Properties As New JavaProperties
    Dim PropertiesStream As FileStream
    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub Apply_Button_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Apply_Button.Click
        Me.DialogResult = DialogResult.Retry
        Me.Close()
    End Sub

    Private Sub Settings_FormClosing(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles Me.FormClosing
        If Me.DialogResult = Windows.Forms.DialogResult.None OrElse
            Me.DialogResult = Windows.Forms.DialogResult.Cancel OrElse ErrorOccurred Then Exit Sub
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
        Properties.SetProperty("allow-flight={0}", AllowFlight.Checked.ToString.ToLower)
        Properties.SetProperty("allow-nether={0}", AllowNether.Checked.ToString.ToLower)
        Properties.SetProperty("announce-player-achievements={0}", AnnouncePlayerAchievements.Checked.ToString.ToLower)
        Properties.SetProperty("broadcast-console-to-ops={0}", BroadcastConsoleToOPs.Checked.ToString.ToLower)
        Properties.SetProperty("debug={0}", Debug.Checked.ToString.ToLower)
        Properties.SetProperty("difficulty={0}", Str(Difficulty.SelectedIndex))
        Properties.SetProperty("enable-command-block={0}", EnableCommandBlocks.Checked.ToString.ToLower)
        Properties.SetProperty("enable-query={0}", EnableQuery.Checked.ToString.ToLower)
        Properties.SetProperty("enable-rcon={0}", EnableRemoteConnection.Checked.ToString.ToLower)
        Properties.SetProperty("force-gamemode={0}", ForceDefaultGamemode.Checked.ToString.ToLower)
        Properties.SetProperty("gamemode={0}", Str(DefaultGamemode.SelectedIndex))
        Properties.SetProperty("generate-structures={0}", GenerateStructures.Checked.ToString.ToLower)
        Properties.SetProperty("hardcore={0}", Hardcore.Checked.ToString.ToLower)
        Properties.SetProperty("max-build-height={0}", Str(MaximumBuildHeight.Value))
        Properties.SetProperty("max-players={0}", Str(MaximumPlayers.Value))
        Properties.SetProperty("max-tick-time={0}", Str(MaximumTickTime.Value))
        Properties.SetProperty("max-world-size={0}", Str(MaximumWorldSize.Value))
        Properties.SetProperty("motd={0}", MessageOfTheDay.Text)
        Properties.SetProperty("network-compression-threshold={0}", Str(NetworkCompressionThreshold.Value))
        Properties.SetProperty("online-mode={0}", OnlineMode.Checked.ToString.ToLower)
        Properties.SetProperty("op-permission-level={0}", Str(OPPermissionLevel.Value))
        Properties.SetProperty("player-idle-timeout={0}", If(PlayerIdleTimeoutCheckBox.Checked, Str(PlayerIdleTimeout.Value), "0"c))
        Properties.SetProperty("pvp={0}", PVP.Checked.ToString.ToLower)
        Properties.SetProperty("query.port={0}", Str(QueryPort.Value))
        Properties.SetProperty("rcon.port={0}", Str(RemoteConnectionPort.Value))
        Properties.SetProperty("rcon.password={0}", RemoteConnectionPassword.Text)
        Properties.SetProperty("resource-pack={0}", RescPack.Text)
        Properties.SetProperty("server-ip={0}", IP.Text)
        Properties.SetProperty("server-port={0}", Str(ServerPort.Value))
        Properties.SetProperty("snooper-enabled={0}", EnableSnooper.Checked.ToString.ToLower)
        Properties.SetProperty("spawn-animals={0}", SpawnAnimals.Checked.ToString.ToLower)
        Properties.SetProperty("spawn-monsters={0}", SpawnMonsters.Checked.ToString.ToLower)
        Properties.SetProperty("spawn-npcs={0}", SpawnVillagers.Checked.ToString.ToLower)
        Properties.SetProperty("spawn-protection={0}", Str(SpawnProtection.Value))
        Properties.SetProperty("view-distance={0}", Str(ViewDistance.Value))
        Properties.SetProperty("white-list={0}", UseWhiteList.Checked.ToString.ToLower)
        Properties.Store(PropertiesStream, "Minecraft server properties", String.Format(
                         "{0} {1} {2} {3} {4} {5}", WeekdayName(Weekday(Now), True), MonthName(Month(Now), True), Now.Day,
                         Now.TimeOfDay.ToString, If(TimeZone.CurrentTimeZone.IsDaylightSavingTime(Now),
                         TimeZone.CurrentTimeZone.DaylightName.TakeWhile(Function(Character) Char.IsUpper(Character)
                     ), TimeZone.CurrentTimeZone.StandardName.TakeWhile(Function(Character) Char.IsUpper(Character))), Now.Year))
        '#Thu Feb 04 18:24:36 CST 2016
        With PropertiesStream
            .Flush()
            .Unlock(0, .Length)
            .Close()
            .Dispose()
        End With
        If DialogResult = DialogResult.Retry Then e.Cancel = True
        If RestartServer Then
            Main.RunServer_Click(sender, e)
            Threading.Thread.Sleep(1000)
            Main.RunServer_Click(sender, e)
        End If
    End Sub

    Private Sub Settings_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        Try
            PropertiesPath = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(Main.JAR.Text), "server.properties")
            PropertiesStream = New FileStream(PropertiesPath, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite)
            PropertiesStream.Lock(0, PropertiesStream.Length)
            Dim Reader As New JavaPropertyReader(Properties)
            Reader.Parse(PropertiesStream)
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
        For Each Pair As DictionaryEntry In Properties
            Try
                Select Case CStr(Pair.Key)
                    Case "allow-flight"
                        AllowFlight.Checked = CBool(Pair.Value)
                    Case "allow-nether"
                        AllowNether.Checked = CBool(Pair.Value)
                    Case "announce-player-achievements"
                        AnnouncePlayerAchievements.Checked = CBool(Pair.Value)
                        ' Not in default server.properties, but probably deprecated
                    Case "broadcast-console-to-ops"
                        BroadcastConsoleToOPs.Checked = CBool(Pair.Value)
                        ' Not in default server.properties, but probably deprecated
                    Case "debug"
                        Debug.Checked = CBool(Pair.Value)
                    Case "difficulty"
                        Difficulty.SelectedIndex = CInt(Pair.Value)
                    Case "enable-command-block"
                        EnableCommandBlocks.Checked = CBool(Pair.Value)
                    Case "enable-query"
                        EnableQuery.Checked = CBool(Pair.Value)
                    Case "enable-rcon"
                        EnableRemoteConnection.Checked = CBool(Pair.Value)
                    Case "force-gamemode"
                        ForceDefaultGamemode.Checked = CBool(Pair.Value)
                    Case "gamemode"
                        DefaultGamemode.SelectedIndex = CInt(Pair.Value)
                    Case "generate-structures"
                        GenerateStructures.Checked = CBool(Pair.Value)
                    Case "generator-settings"
                    Case "hardcore"
                        Hardcore.Checked = CBool(Pair.Value)
                    Case "level-name"
                    Case "level-seed"
                    Case "level-type"
                    Case "max-build-height"
                        MaximumBuildHeight.Value = CDec(Pair.Value)
                    Case "max-players"
                        MaximumPlayers.Value = CDec(Pair.Value)
                    Case "max-tick-time"
                        MaximumTickTime.Value = CDec(Pair.Value)
                    Case "max-world-size"
                        MaximumWorldSize.Value = CDec(Pair.Value)
                    Case "motd"
                        MessageOfTheDay.Text = CStr(Pair.Value)
                    Case "network-compression-threshold"
                        NetworkCompressionThreshold.Value = CDec(Pair.Value)
                    Case "online-mode"
                        OnlineMode.Checked = CBool(Pair.Value)
                    Case "op-permission-level"
                        OPPermissionLevel.Value = CDec(Pair.Value)
                    Case "player-idle-timeout"
                        If Val(Pair.Value) = 0 Then
                            PlayerIdleTimeoutCheckBox.Checked = False
                            PlayerIdleTimeout.Enabled = False
                        Else
                            PlayerIdleTimeoutCheckBox.Checked = True
                            PlayerIdleTimeout.Value = CDec(Pair.Value)
                        End If
                    Case "pvp"
                        PVP.Checked = CBool(Pair.Value)
                        ' Not in default server.properties, but verified
                    Case "query.port"
                        QueryPort.Value = CDec(Pair.Value)
                        ' Not in default server.properties, but verified
                    Case "rcon.port"
                        RemoteConnectionPort.Value = CDec(Pair.Value)
                        ' Not in default server.properties, but verified
                    Case "rcon.password"
                        RemoteConnectionPassword.Text = CStr(Pair.Value)
                    Case "resource-pack"
                        RescPack.Text = CStr(Pair.Value)
                        ' Not in default server.properties, but probably deprecated
                    Case "resource-pack-hash"
                    Case "resource-pack-sha1"
                    Case "server-ip"
                        IP.Text = CStr(Pair.Value)
                    Case "server-port"
                        ServerPort.Value = CDec(Pair.Value)
                    Case "snooper-enabled"
                        EnableSnooper.Checked = CBool(Pair.Value)
                    Case "spawn-animals"
                        SpawnAnimals.Checked = CBool(Pair.Value)
                    Case "spawn-monsters"
                        SpawnMonsters.Checked = CBool(Pair.Value)
                    Case "spawn-npcs"
                        SpawnVillagers.Checked = CBool(Pair.Value)
                        ' Not in default server.properties, but verified
                    Case "spawn-protection"
                        SpawnProtection.Value = CDec(Pair.Value)
                    Case "view-distance"
                        ViewDistance.Value = CDec(Pair.Value)
                    Case "white-list"
                        UseWhiteList.Checked = CBool(Pair.Value)
                End Select
            Catch ex As Exception : Main.DisplayError(ex)
            Finally : Changed = False
            End Try
        Next
    End Sub
    'Writer = New System.IO.StreamWriter(PropertiesPath)

    Private Sub RemoteConnectionPasswordButton_MouseDown(ByVal sender As Object,
                                                         ByVal e As MouseEventArgs) Handles RemoteConnectionPasswordButton.MouseDown
        RemoteConnectionPassword.PasswordChar = Nothing
    End Sub

    Private Sub RemoteConnectionPasswordButton_MouseMove(ByVal sender As Object,
                                                         ByVal e As MouseEventArgs) Handles RemoteConnectionPasswordButton.MouseMove
        If e.X < RemoteConnectionPasswordButton.Location.X OrElse
            e.X > RemoteConnectionPasswordButton.Location.X + RemoteConnectionPasswordButton.Size.Width OrElse
            e.Y < RemoteConnectionPasswordButton.Location.Y OrElse
            e.Y > RemoteConnectionPasswordButton.Location.Y +
            RemoteConnectionPasswordButton.Size.Height Then RemoteConnectionPassword.PasswordChar = "*"c
    End Sub

    Private Sub RemoteConnectionPasswordButton_MouseUp(ByVal sender As Object,
                                                       ByVal e As EventArgs) Handles RemoteConnectionPasswordButton.MouseUp
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
    Private Sub Settings_Changed(sender As Object, e As EventArgs) Handles AllowFlight.CheckedChanged,
        AllowNether.CheckedChanged, AnnouncePlayerAchievements.CheckedChanged, BroadcastConsoleToOPs.CheckedChanged,
        Debug.CheckedChanged, DefaultGamemode.SelectedIndexChanged, Difficulty.SelectedIndexChanged,
        EnableCommandBlocks.CheckedChanged, EnableQuery.CheckedChanged, EnableRemoteConnection.CheckedChanged,
        EnableSnooper.CheckedChanged, ForceDefaultGamemode.CheckedChanged, GenerateStructures.CheckedChanged,
        Hardcore.CheckedChanged, IP.TextChanged, MaximumBuildHeight.ValueChanged, MaximumPlayers.ValueChanged,
        MaximumTickTime.ValueChanged, MaximumWorldSize.ValueChanged, MessageOfTheDay.TextChanged,
        NetworkCompressionThreshold.ValueChanged, OnlineMode.CheckedChanged, OPPermissionLevel.ValueChanged,
        PlayerIdleTimeout.ValueChanged, PlayerIdleTimeoutCheckBox.CheckedChanged, PVP.CheckedChanged,
        QueryPort.ValueChanged, RemoteConnectionPassword.TextChanged, RemoteConnectionPort.ValueChanged,
        ServerPort.ValueChanged, SpawnAnimals.CheckedChanged, SpawnMonsters.CheckedChanged,
        SpawnVillagers.CheckedChanged, SpawnProtection.ValueChanged, UseWhiteList.CheckedChanged, ViewDistance.ValueChanged
        Changed = True
    End Sub

    Private Sub SpawnProtection_ValueChanged(sender As Object, e As EventArgs) Handles _
             SpawnProtection.ValueChanged, SpawnProtection.KeyUp, SpawnProtection.Scroll,
             MaximumWorldSize.ValueChanged, MaximumWorldSize.KeyUp, MaximumWorldSize.Scroll
        SpawnProtectionCalculation.Text = String.Format("{0}×{0}", 2 * SpawnProtection.Value + 1)
        MaximumWorldSizeCalculation.Text = String.Format("{0}×{0}", 2 * MaximumWorldSize.Value)
    End Sub

    Private Sub ResetToDefault_Click(sender As Object, e As EventArgs) Handles ResetToDefault.Click
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
        RescPack.Text = Nothing
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

#Region "Help Messages"
    Private Sub Settings_HelpRequested(sender As Object, hlpevent As HelpEventArgs) Handles MyBase.HelpRequested, Players.HelpRequested,
        World.HelpRequested, Connection.HelpRequested, ResetToDefault.HelpRequested,
        OK_Button.HelpRequested, Cancel_Button.HelpRequested, Apply_Button.HelpRequested
        DisplayHelp("How to use the help feature:

    1. Click on the help button top-right.
    2. Click on a control to get help information, or click the window to get this how-to-use message.
    3. A message box will pop up with the message.
    4. Click OK to continue.")
    End Sub

    Friend Function DisplayHelp(Help As String) As MsgBoxResult
        Return MsgBox(Help, MsgBoxStyle.Information Or MsgBoxStyle.MsgBoxSetForeground)
    End Function

    Private Sub AllowFlight_HelpRequested(sender As Object, hlpevent As HelpEventArgs) Handles AllowFlight.HelpRequested
        DisplayHelp("Allows users to use flight on your server while in Survival mode, if they have a mod that provides flight installed.

With allow-flight enabled, griefers will possibly be more common, because it will make their work easier. In Creative mode this has no effect.

    false - Flight is not allowed (players in air for at least 5 seconds will be kicked).
    true - Flight is allowed, and used if the player has a fly mod installed. ")
    End Sub

    Private Sub AllowNether_HelpRequested(sender As Object, hlpevent As HelpEventArgs) Handles AllowNether.HelpRequested
        DisplayHelp("Allows players to travel to the Nether.

    false - Nether portals will not work.
    true - The server will allow portals to send players to the Nether. ")
    End Sub

    Private Sub AnnouncePlayerAchievements_HelpRequested(sender As Object,
                                                         hlpevent As HelpEventArgs) Handles AnnouncePlayerAchievements.HelpRequested
        DisplayHelp("Allows server to announce when a player gets an achievement.")
    End Sub

    Private Sub BroadcastConsoleToOPs_HelpRequested(sender As Object, hlpevent As HelpEventArgs) Handles BroadcastConsoleToOPs.HelpRequested
        DisplayHelp("This isn't a feature, have a plugin writer write you a plugin to do this. " &
                    "It would be easy and would do what you want it to do. (Boo!)")
    End Sub

    Private Sub DifficultyLabel_HelpRequested(sender As Object,
                                              hlpevent As HelpEventArgs) Handles DifficultyLabel.HelpRequested, Difficulty.HelpRequested
        DisplayHelp("Defines the difficulty (such as damage dealt by mobs and the way hunger and poison affects players) of the server.

    0 - Peaceful
    1 - Easy
    2 - Normal
    3 - Hard ")
    End Sub

    Private Sub EnableQuery_HelpRequested(sender As Object, hlpevent As HelpEventArgs) Handles EnableQuery.HelpRequested
        DisplayHelp("Enables GameSpy4 protocol server listener. Used to get information about server.")
    End Sub

    Private Sub EnableRemoteConnection_HelpRequested(sender As Object, hlpevent As HelpEventArgs) Handles EnableRemoteConnection.HelpRequested
        DisplayHelp("Enables remote access to the server console.")
    End Sub

    Private Sub EnableCommandBlocks_HelpRequested(sender As Object, hlpevent As HelpEventArgs) Handles EnableCommandBlocks.HelpRequested
        DisplayHelp("Enables command blocks.")
    End Sub

    Private Sub ForceDefaultGamemode_HelpRequested(sender As Object, hlpevent As HelpEventArgs) Handles ForceDefaultGamemode.HelpRequested
        DisplayHelp("Force players to join in the default game mode.

    false - Players will join in the gamemode they left in.
    true - Players will always join in the default gamemode. ")
    End Sub

    Private Sub DefaultGamemodeLabel_HelpRequested(sender As Object,
                                           hlpevent As HelpEventArgs) Handles DefaultGamemodeLabel.HelpRequested, DefaultGamemode.HelpRequested
        DisplayHelp("Defines the mode of gameplay.

    0 - Survival
    1 - Creative
    2 - Adventure
    3 - Spectator ")
    End Sub

    Private Sub GenerateStructures_HelpRequested(sender As Object, hlpevent As HelpEventArgs) Handles GenerateStructures.HelpRequested
        DisplayHelp("Defines whether structures (such as villages) will be generated.

    false - Structures will not be generated in new chunks.
    true - Structures will be generated in new chunks.

Note: Dungeons will still generate if this is set to false.")
    End Sub

    Private Sub Hardcore_HelpRequested(sender As Object, hlpevent As HelpEventArgs) Handles Hardcore.HelpRequested
        DisplayHelp("If set to true, players will be set to spectator mode if they die.")
    End Sub

    Private Sub MaximumBuildHeightLabel_HelpRequested(sender As Object,
             hlpevent As HelpEventArgs) Handles MaximumBuildHeightLabel.HelpRequested, MaximumBuildHeight.HelpRequested
        DisplayHelp("The maximum height in which building is allowed. Terrain may still naturally generate above a low height limit.")
    End Sub

    Private Sub MaximumPlayersLabel_HelpRequested(sender As Object,
                                             hlpevent As HelpEventArgs) Handles MaximumPlayersLabel.HelpRequested, MaximumPlayers.HelpRequested
        DisplayHelp("The maximum number of players that can play on the server at the same time." &
                    " Note that if more players are on the server it will use more resources." &
                    " Note also, op player connections are not supposed to count against the max players," &
                    " but ops currently cannot join a full server. Extremely large values for this" &
                    " field result in the client-side user list being broken.")
    End Sub

    Private Sub MaximumTickTimeLabel_HelpRequested(sender As Object,
                                           hlpevent As HelpEventArgs) Handles MaximumTickTimeLabel.HelpRequested, MaximumTickTime.HelpRequested
        DisplayHelp("The maximum number of milliseconds a single tick may take before the server watchdog" &
                    " stops the server with the message, ""A single server tick took 60.00 seconds (should be max 0.05);" &
                    " Considering it to be crashed, server will forcibly shutdown.""" &
                    " Once this criteria is met, it calls System.exit(1).

    -1 - disable watchdog entirely (this disable option was added in 14w32a) ")
    End Sub

    Private Sub MaximumWorldSizeLabel_HelpRequested(sender As Object, hlpevent As HelpEventArgs) Handles MaximumWorldSizeLabel.HelpRequested,
                                                                      MaximumWorldSizeCalculation.HelpRequested, MaximumWorldSize.HelpRequested
        DisplayHelp("This sets the maximum possible size in blocks, expressed as a radius," &
                    " that the world border can obtain. Setting the world border bigger causes" &
                    " the commands to complete successfully but the actual border will not move past this block limit" &
                    ". Setting the max-world-size higher than the default (29999984) doesn't appear to do anything.

Examples:

    Setting max-world-size to 1000 will allow you to have a 2000x2000 world border.
    Setting max-world-size to 4000 will give you an 8000 x 8000 world border.
")
    End Sub

    Private Sub MessageOfTheDayLabel_HelpRequested(sender As Object,
                                           hlpevent As HelpEventArgs) Handles MessageOfTheDayLabel.HelpRequested, MessageOfTheDay.HelpRequested
        DisplayHelp("MOTD is short for Message of the day, though you do not need to change it every day. " &
                    "This is the message that is displayed in the server list of the client, below the name.

    The MOTD does support color and formatting codes.
    The MOTD supports special characters, such as ""♥"". However, such characters must be converted to escaped Unicode form. " &
    "But no worries, we will do it for you - just type in the unicode character and we will do it. " &
    "If you are interested, an online converter can be found here - http://www.freeformatter.com/string-utilities.html#charinfo
    If the MOTD is over 59 characters, the server list will likely report a communication error.
")
    End Sub

    Private Sub NetworkCompressionThresholdLabel_HelpRequested(sender As Object,
                                                hlpevent As HelpEventArgs) Handles NetworkCompressionThresholdUnit.HelpRequested,
                                                NetworkCompressionThresholdLabel.HelpRequested, NetworkCompressionThreshold.HelpRequested
        DisplayHelp("By default it allows packets that are n-1 bytes big to go normally, but a packet that n bytes or more " &
                    "will be compressed down. So, lower number means more compression but compressing small amounts of bytes might" &
                    " actually end up with a larger result than what went in.

    -1 - disable compression entirely
    0 - compress everything

Note: The Ethernet spec requires that packets less than 64 bytes become padded to 64 bytes. Thus, setting a value lower than 64 " &
"may not be beneficial. It is also not recommended to exceed the MTU, typically 1500 bytes.")
    End Sub

    Private Sub OnlineMode_HelpRequested(sender As Object, hlpevent As HelpEventArgs) Handles OnlineMode.HelpRequested
        DisplayHelp("Server checks connecting players against Minecraft's account database." &
                    " Only set this to false if your server is not connected to the Internet." &
                    " Hackers with fake accounts can connect if this is set to false! If minecraft.net is down or inaccessible," &
                    " no players will be able to connect if this is set to true. Setting this variable to off purposely is called ""cracking" &
                    """ a server, and servers that are presently with online mode off are called ""cracked"" servers, " &
                    "allowing players with unlicensed copies of Minecraft to join.

    true - Enabled. The server will assume it has an Internet connection and check every connecting player.
    false - Disabled. The server will not attempt to check connecting players. ")
    End Sub

    Private Sub OPPermissionLevelLabel_HelpRequested(sender As Object, hlpevent As HelpEventArgs) Handles OPPermissionLevelLabel.HelpRequested,
                                                                                                               OPPermissionLevel.HelpRequested
        DisplayHelp(" 	Sets permission level for ops.

    1 - Ops can bypass spawn protection.
    2 - Ops can use /clear, /difficulty, /effect, /gamemode, /gamerule, /give, /tp" &
    " and other singleplayer commands, and can edit command blocks.
    3 - Ops can use /ban, /deop, /kick, and /op.
    4 - Ops can use /stop. ")
    End Sub

    Private Sub PlayerIdleTimeoutCheckBox_HelpRequested(sender As Object, hlpevent As HelpEventArgs) Handles _
        PlayerIdleTimeoutLabel.HelpRequested, PlayerIdleTimeoutCheckBox.HelpRequested, PlayerIdleTimeout.HelpRequested
        DisplayHelp("If non-zero (aka checkbox checked), players are kicked from the server if they are idle for more than that many minutes.

    Note: Idle time is reset when the server receives one of the following packets:

        102 (0x66) WindowClick
        108 (0x6c) ButtonClick
        130 (0x82) UpdateSign
        14 (0xe) BlockDig
        15 (0xf) Place
        16 (0x10) BlockItemSwitch
        18 (0x12) ArmAnimation
        19 (0x13) EntityAction
        205 (0xcd) ClientCommand
        3 (0x3) Chat
        7 (0x7) UseEntity

")
    End Sub

    Private Sub PVP_HelpRequested(sender As Object, hlpevent As HelpEventArgs) Handles PVP.HelpRequested
        DisplayHelp("Enable PvP on the server. Players shooting themselves with arrows will only receive damage if PvP is enabled.

    true - Players will be able to kill each other.
    false - Players cannot kill other players (also known as Player versus Environment (PvE)).

Note: Indirect damage sources spawned by players (such as lava, fire, TNT and to some extent water, "&
"sand and gravel) will still deal damage to other players.")
    End Sub

    Private Sub QueryPort_HelpRequested(sender As Object, hlpevent As HelpEventArgs) Handles QueryPort.HelpRequested
        DisplayHelp("Sets the port for the query server (see enable-query).")
    End Sub

    Private Sub RemoteConnectionPort_HelpRequested(sender As Object, hlpevent As HelpEventArgs) Handles RemoteConnectionPort.HelpRequested
        DisplayHelp("Sets the port to rcon.")
    End Sub

    Private Sub RemoteConnectionLabel_HelpRequested(sender As Object,
                                 hlpevent As HelpEventArgs) Handles RemoteConnectionPassword.HelpRequested, RemoteConnectionLabel.HelpRequested
        DisplayHelp("Sets the password to rcon.")
    End Sub

    Private Sub RemoteConnectionPasswordButton_HelpRequested(sender As Object,
                                                             hlpevent As HelpEventArgs) Handles RemoteConnectionPasswordButton.HelpRequested
        DisplayHelp("Temporarily shows the password to the user.")
    End Sub

    Private Sub RescPack_HelpRequested(sender As Object,
                                       hlpevent As HelpEventArgs) Handles RescPackDownload.HelpRequested, RescPack.HelpRequested
        DisplayHelp("Optional URI to a resource pack. The player may choose to use it.

If the pack isn't working, then...

- Make sure that your resource pack is in a .zip file.
- Ensure that the resource pack size is 50 MB or less. This is a restriction from Mojang.
- Verify that the file has completely uploaded to your hosting site.
- If you are using Dropbox, ensure that your resource pack's URL ends in ""?dl=1""," &
" which directs Minecraft to download instead of the preview page.")
    End Sub

    Private Sub IPLabel_HelpRequested(sender As Object, hlpevent As HelpEventArgs) Handles IPLabel.HelpRequested, IP.HelpRequested
        DisplayHelp("Set this if you want the server to bind to a particular IP. It is strongly recommended that you leave server-ip blank!

    Set to blank, or the IP you want your server to run (listen) on. ")
    End Sub

    Private Sub ServerPortLabel_HelpRequested(sender As Object,
                                              hlpevent As HelpEventArgs) Handles ServerPortLabel.HelpRequested, ServerPort.HelpRequested
        DisplayHelp("Changes the port the server is hosting (listening) on. " &
                    "This port must be forwarded if the server is hosted in a network " &
                    "using NAT (Network address translation) (If you have a home router/firewall).")
    End Sub

    Private Sub EnableSnooper_HelpRequested(sender As Object, hlpevent As HelpEventArgs) Handles EnableSnooper.HelpRequested
        DisplayHelp("Sets whether the server sends snoop data regularly to http://snoop.minecraft.net.

Snooper allows Mojang to collect information about your" &
               " machine to help improve Minecraft by knowing what they" &
               " can support and where the biggest problems are. All of " &
               "this information is completely anonymous and able to be " &
               "viewed within the settings page. They promise they won't" &
               " do anything bad with this data, but if you want to opt " &
               "out then feel free to toggle it off!


    false - disable snooping.
    true - enable snooping. ")
    End Sub

    Private Sub SpawnAnimals_HelpRequested(sender As Object, hlpevent As HelpEventArgs) Handles SpawnAnimals.HelpRequested
        DisplayHelp(" 	Determines if animals will be able to spawn.

    true - Animals spawn as normal.
    false - Animals will immediately vanish.

Tip: if you have major lag, turn this off/set to false.")
    End Sub

    Private Sub SpawnMonsters_HelpRequested(sender As Object, hlpevent As HelpEventArgs) Handles SpawnMonsters.HelpRequested
        DisplayHelp("Determines if monsters will be spawned.

    true - Enabled. Monsters will appear at night and in the dark.
    false - Disabled. No monsters.

This does nothing if difficulty = 0 (peaceful) Unless your difficulty is not set to 0, " &
"when a monster can still spawn from a Monster Spawner. Tip: if you have major lag, turn this off/set to false.")
    End Sub

    Private Sub SpawnVillagers_HelpRequested(sender As Object, hlpevent As HelpEventArgs) Handles SpawnVillagers.HelpRequested
        DisplayHelp("Determines if villagers will be spawned.

    true - Enabled. Villagers will spawn.
    false - Disabled. No villagers. ")
    End Sub

    Private Sub SpawnProtectionLabel_HelpRequested(sender As Object, hlpevent As HelpEventArgs) Handles SpawnProtectionLabel.HelpRequested,
        SpawnProtectionCalculation.HelpRequested, SpawnProtection.HelpRequested
        DisplayHelp("Determines the radius of the spawn protection. Setting this to 0 will not disable spawn protection." &
                    " 0 will protect the single block at the spawn point. 1 will protect a 3x3 area centered on the spawn point." &
                    " 2 will protect 5x5, 3 will protect 7x7, etc. This option is not generated on the first server start and" &
                    " appears when the first player joins. If there are no ops set on the server," &
                    " the spawn protection will be disabled automatically.")
    End Sub

    Private Sub ViewDistanceLabel_HelpRequested(sender As Object,
                                                hlpevent As HelpEventArgs) Handles ViewDistanceLabel.HelpRequested, ViewDistance.HelpRequested
        DisplayHelp("Sets the amount of world data the server sends the client, measured in chunks in each direction " &
                    "of the player (radius, not diameter). It determines the server-side viewing distance.

10 is the default/recommended. If you have major lag, reduce this value.")
    End Sub

    Private Sub UseWhiteList_HelpRequested(sender As Object, hlpevent As HelpEventArgs) Handles UseWhiteList.HelpRequested
        DisplayHelp("Enables a whitelist on the server.

With a whitelist enabled, users not on the whitelist will be unable to connect. Intended for private servers, " &
"such as those for real-life friends or strangers carefully selected via an application process, for example.

    false - No white list is used.
    true - The file whitelist.json is used to generate the white list.

Note: Ops are automatically white listed, and there is no need to add them to the whitelist.")
    End Sub

#End Region

End Class
