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
        Me.DialogResult = DialogResult.None
        Me.Hide()
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
        If File.Exists(PropertiesPath) Then
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

    Private Sub SnooperHelp_Click(sender As Object, e As EventArgs) Handles SnooperHelp.Click
        DisplayHelp("Snooper allows Mojang to collect information about your" &
               " machine to help improve Minecraft by knowing what they" &
               " can support and where the biggest problems are. All of " &
               "this information is completely anonymous and able to be " &
               "viewed within the settings page. They promise they won't" &
               " do anything bad with this data, but if you want to opt " &
               "out then feel free to toggle it off!")

    End Sub

    Private Sub RescPackHelp_Click(sender As Object, e As EventArgs) Handles RescPackHelp.Click
        DisplayHelp("- Make sure that your resource pack is in a .zip file.
- Ensure that the resource pack size is 50 MB or less. This is a restriction from Mojang.
- Verify that the file has completely uploaded to your hosting site.
- If you are using Dropbox, ensure that your resource pack's URL ends in ""?dl=1""," &
" which directs Minecraft to download instead of the preview page.")
    End Sub

    Friend Function DisplayHelp(Help As String) As MsgBoxResult
        Return MsgBox(Help, MsgBoxStyle.Information Or MsgBoxStyle.MsgBoxSetForeground)
    End Function
End Class
