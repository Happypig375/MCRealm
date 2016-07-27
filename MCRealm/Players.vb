Imports System.Windows.Forms
Imports System.IO
Imports System.Net

Public Class Players
    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        DialogResult = DialogResult.OK
        Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        DialogResult = DialogResult.Cancel
        Close()
    End Sub

    Private Sub Apply_Button_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Apply_Button.Click
        DialogResult = DialogResult.Retry
        Close()
    End Sub

    Private Sub Players_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GetSkin("Rex0401YT")
    End Sub

    ''' <summary>
    ''' Gets a Minecraft player skin.
    ''' </summary>
    ''' <param name="Username">The minecraft player username.</param>
    ''' <param name="BasePath">Optional. The player skin is stored in this directory with the username as the filename.
    ''' If not specified, is empty or is nothing, %temp% will be used.</param>
    ''' <returns></returns>
    Friend Shared Function GetSkin(Username As String, Optional BasePath As String = Nothing) As String
        If String.IsNullOrEmpty(BasePath) Then BasePath = My.Computer.FileSystem.SpecialDirectories.Temp 'Change accordingly...
        Dim req As HttpWebRequest = DirectCast(WebRequest.Create($"http://skins.minecraft.net/MinecraftSkins/{Username}.png"), HttpWebRequest)
        req.AllowAutoRedirect = False
        Dim realUrl As String = req.GetResponse.Headers("Location")
        'Dim WebClient As New WebClient()
        'AddHandler WebClient.DownloadFileCompleted, New System.ComponentModel.AsyncCompletedEventHandler(AddressOf Completed)
        'AddHandler WebClient.DownloadProgressChanged, New DownloadProgressChangedEventHandler(AddressOf ProgressChanged)
        'WebClient.DownloadFileAsync(New Uri(realUrl), LocalFile)
#If False Then

        Dim url = "http://findicons.com/icon/download/235456/internet_download/128/png?id=235724"

        Using client = New HttpClient()
            Using response = Await client.GetAsync(url)
		' make sure our request was successful
		response.EnsureSuccessStatusCode()

                ' read the filename from the Content-Disposition header
                Dim filename = response.Content.Headers.ContentDisposition.FileName

                ' read the downloaded file data
                Dim stream = Await response.Content.ReadAsStreamAsync()

		' Where you want the file to be saved
		Dim destinationFile = Path.Combine("C:\local\directory", filename)

                ' write the steam content into a file
                Using fileStream = File.Create(destinationFile)
                    stream.CopyTo(fileStream)
                End Using
            End Using
        End Using
#End If
        Dim Request As HttpWebRequest = DirectCast(WebRequest.Create(realUrl), HttpWebRequest)
        Using Response As HttpWebResponse = DirectCast(Request.GetResponse(), HttpWebResponse)
            Dim Header As String = Response.Headers.ToString
#Const FilenameMethod = 0
#If FilenameMethod = 1 Then
            Dim Filename As String = Header.Remove(0, Header.IndexOf("filename=") + 10)
            Filename = Filename.Remove(Filename.IndexOf(""""c))
#ElseIf FilenameMethod = 2 Then
            Dim Filename = Response.Headers("Content-Disposition").Split(New String() {"="}, StringSplitOptions.None)(1)
#ElseIf FilenameMethod = 0 Then
            Dim Filename As String = String.Empty
#End If
            Dim ResponseStream = Response.GetResponseStream()
            GetSkin = Path.Combine(BasePath, If(UseFileName, Filename, Username))
            If Not My.Computer.FileSystem.DirectoryExists(GetSkin) Then My.Computer.FileSystem.CreateDirectory(GetSkin)
            Using FileStream = File.Create(InlineAssignHelper(GetSkin, GetSkin & If(UseFileName, String.Empty, ".png")))
                CopyStream(ResponseStream, FileStream)
            End Using
        End Using
    End Function

    Friend Shared Function CropImage(img As Image, cropArea As Rectangle) As Image
        Try
            Dim bmpImage As New Bitmap(img)
            Return bmpImage.Clone(cropArea, bmpImage.PixelFormat)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error while cropping player skin")
        Finally
        End Try
        Return Nothing
    End Function

    Private Shared ReadOnly Property UseFileName As Boolean
        Get
#If FilenameMethod = 0 Then
            Return False
#ElseIf True Then
            Return True
#End If
        End Get
    End Property

    Friend Shared Sub CopyStream(input As Stream, output As Stream)
        Dim buffer As Byte() = New Byte(32767) {}
        Dim read As Integer
        While (InlineAssignHelper(read, input.Read(buffer, 0, buffer.Length))) > 0
            output.Write(buffer, 0, read)
        End While
    End Sub

    Private Sub ProgressChanged(sender As Object, e As DownloadProgressChangedEventArgs)
        PlayerSkinProgress.Value = e.ProgressPercentage
        BytesDownloaded.Text = Str(e.BytesReceived)
        TotalBytes.Text = Str(e.TotalBytesToReceive)
    End Sub

    Private Sub Completed(sender As Object, e As System.ComponentModel.AsyncCompletedEventArgs)
        BytesDownloaded.Text = "Download completed!"
        TotalBytes.Text = BytesDownloaded.Text
    End Sub

    Friend Shared Function InlineAssignHelper(Of T)(ByRef target As T, ByVal value As T) As T
        target = value
        Return value
    End Function

    Friend Shared Function InlineCommentHelper(Of T)(Comment As String) As T
        Return Nothing
    End Function
#If False Then'
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

#End If




End Class
