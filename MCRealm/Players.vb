Imports System.Windows.Forms
Imports System.IO
Imports System.Net
Imports System.Drawing.Imaging

Public Class Players
    Dim InitialWidth As Integer
    Dim InitialHeadWidth As Integer
    Dim InitialNameWidth As Integer
    Dim InitialKickWidth As Integer
    Dim InitialBanWidth As Integer
    Dim InitialOpWidth As Integer
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
        AddPlayer("Rex0401YT")
        AddPlayer("MCmario117")
        AddPlayer("henrykwokchihei")
        'AddPlayer("stevef91")
    End Sub

    Friend Sub AddPlayer(Username As String, Optional State As PlayerState = PlayerState.Normal)
        Dim SkinPath As String = GetSkin(Username)
        If String.IsNullOrEmpty(SkinPath) Then Exit Sub
        Images.Images.Add(Username, CropImage(New Bitmap(SkinPath), New Rectangle(8, 8, 8, 8), 2))
        Dim Item As New ListViewItem({String.Empty, Username}, Images.Images.IndexOfKey(Username), GetGroup(Username.First))
        'CropImage(New Bitmap(SkinPath), New Rectangle(8, 8, 8, 8))
        View.Items.Add(Item)
    End Sub

    <Flags> Friend Enum PlayerState As Byte
        Normal
        [Operator]
        Banned
        Owner = 4
    End Enum

    Friend Function GetGroup(Code As Char) As ListViewGroup
        Code = Char.ToUpper(Code)
        Select Case Code
            Case "A"c To "Z"c
                Return View.Groups.Item(AscW(Code) - AscW("A"c))
            Case "0"c To "9"c
                Return View.Groups.Item(27)
            Case Else
                Return View.Groups.Item(28)
        End Select
    End Function

    Friend Function ImageResize(Source As Image, Scale As Single) As Bitmap ' Get the source bitmap and the scale factor.

        ' Make a bitmap for the result.
        Dim bm_dest As New Bitmap(
        CInt(Source.Width * Scale),
        CInt(Source.Height * Scale))

        ' Make a Graphics object for the result Bitmap.
        Dim gr_dest As Graphics = Graphics.FromImage(bm_dest)

        ' Copy the source image into the destination bitmap.
        gr_dest.DrawImage(Source, 0, 0,
        bm_dest.Width + 1,
        bm_dest.Height + 1)

        ' Display the result.
        Return bm_dest
    End Function

    ''' <summary>
    ''' Gets a Minecraft player skin.
    ''' </summary>
    ''' <param name="Username">The minecraft player username.</param>
    ''' <param name="BasePath">Optional. The player skin is stored in this directory with the username as the filename.
    ''' If not specified, is empty or is nothing, %temp% will be used.</param>
    ''' <returns>The skin file's location on this computer. (extension: .png)</returns>
    Friend Shared Function GetSkin(Username As String, Optional BasePath As String = Nothing) As String
        If String.IsNullOrEmpty(BasePath) Then BasePath = My.Computer.FileSystem.SpecialDirectories.Temp 'Change accordingly...
        Dim req As HttpWebRequest = DirectCast(WebRequest.Create($"http://skins.minecraft.net/MinecraftSkins/{Username}.png"), HttpWebRequest)
        req.AllowAutoRedirect = False
        Dim realUrl As String
        Try
            realUrl = req.GetResponse.Headers("Location")
        Catch ex As WebException When ex.Status = WebExceptionStatus.ProtocolError And ex.Message.Contains("404")
            MsgBox($"Unexisting player: {Username}", MsgBoxStyle.MsgBoxSetForeground, "Player not found")
            Return Nothing
        Catch ex As WebException
            MsgBox(ex.ToString)
        End Try
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

    Friend Shared Function CropImage(img As Image, cropArea As Rectangle, ZoomedRatio As Double) As Image
        Try
            Dim ScaledCropRect As New Rectangle()
            ScaledCropRect.X = CInt(cropArea.X / ZoomedRatio)
            ScaledCropRect.Y = CInt(cropArea.Y / ZoomedRatio)
            ScaledCropRect.Width = CInt(cropArea.Width / ZoomedRatio)
            ScaledCropRect.Height = CInt(cropArea.Height / ZoomedRatio)
            Dim bmpImage As New Bitmap(img)
            Return bmpImage.Clone(cropArea, bmpImage.PixelFormat)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error while cropping player skin")
        Finally
        End Try
        Return Nothing
    End Function

    Friend Sub SaveImage(path As String, img As Bitmap, extension As Extensions, quality As Long)
        ' Encoder parameter for image quality
        Dim qualityParam As New EncoderParameter(Encoder.Quality, quality)

        ' Jpeg image codec
        Dim jpegCodec As ImageCodecInfo = GetEncoderInfo(extension)

        If jpegCodec Is Nothing Then
            MessageBox.Show($"Can't find {[Enum].GetName(GetType(Encoders), extension)} encoder?", "Error while saving image")
            Return
        End If
        Dim encoderParams As New EncoderParameters(1)
        encoderParams.Param(0) = qualityParam

        img.Save(path, jpegCodec, encoderParams)
    End Sub

    Friend Function GetEncoderInfo(mimeType As String) As ImageCodecInfo
        ' Get image codecs for all image formats
        Dim codecs As ImageCodecInfo() = ImageCodecInfo.GetImageEncoders()

        ' Find the correct image codec
        For i As Integer = 0 To codecs.Length - 1
            If codecs(i).MimeType = mimeType Then
                Return codecs(i)
            End If
        Next

        Return Nothing
    End Function

    Friend Function GetEncoderInfo(Type As Encoders) As ImageCodecInfo
        Return GetEncoderInfo("image/" & [Enum].GetName(GetType(Encoders), Type).ToLower)
    End Function

    Friend Function GetEncoderInfo(Type As Extensions) As ImageCodecInfo
        Return GetEncoderInfo("image/" & [Enum].GetName(GetType(Encoders), Type).ToLower)
    End Function

    Friend Enum Encoders As Byte
        BMP
        JPEG
        GIF
        TIFF
        PNG
    End Enum

    Friend Enum Extensions As Byte
        BMP = Encoders.BMP
        DIB = Encoders.BMP
        RLE = Encoders.BMP

        JPG = Encoders.JPEG
        JPEG = Encoders.JPEG
        JPE = Encoders.JPEG
        JFIF = Encoders.JPEG

        GIF = Encoders.GIF

        TIF = Encoders.TIFF
        TIFF = Encoders.TIFF

        PNG = Encoders.PNG
    End Enum

    Friend Sub SaveCrop(Image As Image, CropRect As Rectangle, ZoomedRatio As Double,
                        SavePath As String, Extension As Extensions, Optional Quality As Long = 85)
        ' output image size is based upon the visible crop rectangle and scaled to 
        ' the ratio of actual image size to displayed image size
        Dim BMP As Bitmap = Nothing
        Dim ScaledCropRect As New Rectangle()
        ScaledCropRect.X = CInt(CropRect.X / ZoomedRatio)
        ScaledCropRect.Y = CInt(CropRect.Y / ZoomedRatio)
        ScaledCropRect.Width = CInt(CropRect.Width / ZoomedRatio)
        ScaledCropRect.Height = CInt(CropRect.Height / ZoomedRatio)

        Try
            BMP = DirectCast(CropImage(Image, ScaledCropRect), Bitmap)
            ' 85% quality
            SaveImage(SavePath, BMP, Extension, Quality)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error while saving image")
        End Try

        If BMP IsNot Nothing Then BMP.Dispose()
    End Sub
#If Not FilenameMethod = 0 Then
    Private Sub ProgressChanged(sender As Object, e As DownloadProgressChangedEventArgs)
        PlayerSkinProgress.Value = e.ProgressPercentage
        BytesDownloaded.Text = Str(e.BytesReceived)
        TotalBytes.Text = Str(e.TotalBytesToReceive)
    End Sub

    Private Sub Completed(sender As Object, e As System.ComponentModel.AsyncCompletedEventArgs)
        BytesDownloaded.Text = "Download completed!"
        TotalBytes.Text = BytesDownloaded.Text
    End Sub
#End If
    Friend Shared Function InlineAssignHelper(Of T)(ByRef target As T, ByVal value As T) As T
        target = value
        Return value
    End Function

    Friend Shared Function InlineCommentHelper(Of T)(Comment As String) As T
        Return Nothing
    End Function

    Private Sub Players_Resize(sender As Object, e As EventArgs)
        Head.Width = View.Width * InitialHeadWidth \ InitialWidth
        PName.Width = View.Width * InitialNameWidth \ InitialWidth
        Kick.Width = View.Width * InitialKickWidth \ InitialWidth
        Ban.Width = View.Width * InitialBanWidth \ InitialWidth
        Op.Width = View.Width * InitialOpWidth \ InitialWidth
    End Sub

    Private Sub Players_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        InitialWidth = View.Width
        InitialHeadWidth = Head.Width
        InitialNameWidth = PName.Width
        InitialKickWidth = Kick.Width
        InitialBanWidth = Ban.Width
        InitialOpWidth = Op.Width
        AddHandler Resize, AddressOf Players_Resize
        Players_Resize(sender, e)
    End Sub
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
