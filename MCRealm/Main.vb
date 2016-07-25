Public Class Main
    Friend ReadOnly MinSize As Size = Size
    Friend WithEvents Server As New Process()
    Friend JavaArgs As JavaRuntimeArgs
    Friend Structure JavaRuntimeArgs
        Friend JavaW As Boolean
        Friend MemoryMin As UInt32
        Friend MemoryInit As UInt32
        Friend MemoryMax As UInt32
        Friend MemoryMinUnit As MemoryUnit
        Friend MemoryInitUnit As MemoryUnit
        Friend MemoryMaxUnit As MemoryUnit
        Friend Bit64 As Boolean
        Friend NoGUI As Boolean
        Friend Online As Boolean
        Friend Args As String
        Friend Enum MemoryUnit As Byte
            [Byte]
            ''' <summary>
            ''' Kilobyte (1024 Bytes)
            ''' </summary>
            K
            ''' <summary>
            ''' Megabyte (1024 Kilobytes)
            ''' </summary>
            M
            ''' <summary>
            ''' Gigabyte (1024 Megabytes)
            ''' </summary>
            G
            ''' <summary>
            ''' Tetrabyte (1024 Gigabytes)
            ''' Do not use this as java thinks that this is too big for a size.
            ''' </summary>
            T
        End Enum
    End Structure
    Friend ReadOnly Property ServerRunning As Boolean
        Get
            Try
                Return Not Server.HasExited
            Catch ex As InvalidOperationException
                Return False
            End Try
        End Get
    End Property
    Private Sub Main_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If ServerRunning Then RunServer_Click(sender, e)
    End Sub

    Private Sub RefreshWorlds_Click(sender As Object, e As EventArgs) Handles RefreshWorlds.Click

    End Sub

    Private Sub LoadJAR_Click(sender As Object, e As EventArgs) Handles LoadJAR.Click
        If Load_From.Display(False, "JAR files|*.jar") = System.Windows.Forms.DialogResult.Cancel Then Exit Sub
        JAR.Text = Load_From.Path
    End Sub

    Private Sub About_Click(sender As Object, e As EventArgs) Handles About.Click
        AboutBox.Show()
    End Sub
    'Dim ProcID As Integer
    Friend Sub RunServer_Click(sender As Object, e As EventArgs) Handles ServerSwitch.Click
        Try
            If ServerRunning Then
                KillServer()
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
                Try
                    For Each p In Process.GetProcesses
                        If p.ProcessName = Determine() Then
                            p.Kill()
                        End If
                    Next
                Catch exc As System.ComponentModel.Win32Exception
                    MsgBox(exc.ToString)
                End Try
                With Server.StartInfo
                    .WorkingDirectory = System.IO.Path.GetDirectoryName(JAR.Text)
                    .FileName = Determine()
                    .Arguments = String.Format(
                     "-Xmn{0}{1} -Xms{2}{3} -Xmx{4}{5} -d{6} -jar ""{7}"" {8} -o {9}{10}",
                                               JavaArgs.MemoryMin, '-XX:+CMSIncrementalMode
                                               JavaArgs.MemoryMinUnit.ToString(),
                                               JavaArgs.MemoryInit, JavaArgs.MemoryInitUnit,
                                               JavaArgs.MemoryMax, JavaArgs.MemoryMaxUnit,
                                               If(JavaArgs.Bit64, "64", "32"),
                                               JAR.Text, If(JavaArgs.NoGUI, "nogui", String.Empty),
                                               JavaArgs.Online.ToString.ToLower,
                                               If(String.IsNullOrEmpty(JavaArgs.Args), String.Empty, " "c & JavaArgs.Args)
                                               ).Replace("Byte", String.Empty)
                    .UseShellExecute = False
                    .CreateNoWindow = True
                    .RedirectStandardInput = True
                    .RedirectStandardOutput = True
                    .RedirectStandardError = True
                End With
                ' You can start any process, HelloWorld is a do-nothing example.
                UpdateButtons(True)
                ServerSwitch.Text = "Stop Server"
                With Server
                    .EnableRaisingEvents = True
                    .Start()
                    .BeginErrorReadLine()
                    .BeginOutputReadLine()
                End With
#End If
                ' This code assumes the process you are starting will terminate itself. 
                ' Given that is is started without a window so you cannot terminate it 
                ' on the desktop, it must terminate itself or you can do it programmatically
                ' from this application using the Kill method.
            End If
        Catch ex As Exception
            DisplayError(ex)
        End Try
    End Sub
    Friend Function Determine() As String
        Return If(JavaArgs.JavaW, "javaw.exe", "java.exe")
    End Function
    Private Delegate Sub DefaultEventDelegate(sender As Object, e As EventArgs)
    Private Sub Server_Exited(sender As Object, e As EventArgs) Handles Server.Exited
        UpdateButtons(False)
        If ServerSwitch.InvokeRequired Then
            Dim myDelegate As New DefaultEventDelegate(AddressOf Server_Exited)
            Me.Invoke(myDelegate, sender, e)
        Else
            ServerSwitch.Text = "Start Server"
        End If
    End Sub
    Private Sub Display(sender As Object, e As DataReceivedEventArgs) Handles Server.ErrorDataReceived, Server.OutputDataReceived
        AppendOutputText(e.Data & vbCrLf)
    End Sub
    Private Delegate Sub AppendTextDelegate(Text As String)
    Private Sub AppendOutputText(Text As String)
#If True Then
        If Output.InvokeRequired Then
            Dim myDelegate As New AppendTextDelegate(AddressOf AppendOutputText)
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
        Input.ResetText()
#End If
    End Sub

    Private Sub Output_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Output.KeyPress
        e.Handled = True
    End Sub

    Private Sub SpeechButton_Click(sender As Object, e As EventArgs) Handles SpeechButton.Click

        ' Create a new SpeechRecognitionEngine instance.
        Dim recognizer As New Speech.Recognition.SpeechRecognizer()

        ' Create a simple grammar that recognizes "red", "green", or "blue".
        Dim Commands As New Speech.Recognition.Choices(New String() {"achievement", "ban", "ban-ip", "banlist", "blockdata", "clear", "clone", "debug",
                                                                     "defaultgamemode", "deop", "difficulty", "effect", "enchant", "entitydata", "execute",
                                                                     "fill", "gamemode", "gamerule", "give", "help", "kick", "kill", "list", "me", "op",
                                                                     "pardon", "particle", "playsound", "publish", "replaceitem", "save-all", "save-off",
                                                                     "save-on", "say", "scoreboard", "seed", "setblock", "setidletimeout", "setworldspawn",
                                                                     "spawnpoint", "spreadplayers", "stats", "stop", "summon", "tell", "tellraw", "testfor",
                                                                     "testforblock", "testforblocks", "time", "title", "toggledownfall", "tp", "trigger",
                                                                     "weather", "whitelist", "worldborder", "xp"})
        Dim Blocks As New Speech.Recognition.Choices("air", "stone")
        'Adminium:Aggressive:Alpha:Arrow:Asperguim :Attack:Bedrock:Beta:Biomes:Blocks:Book:Bookshelf:Bone:Bonemeal:Bow:Cactus:Cake:Charcoal:Chest:Clock:Cobblestone/Cobble:Compass:Coal:Crafting:Creeper:
        '(?<=\s+)(\w+)
#If False Then
	"Air"
(minecraft:air)
	"Stone"
(minecraft:stone)
	"Granite"
(minecraft:stone)
	"Polished" "Granite"
(minecraft:stone)
	"Diorite"
(minecraft:stone)
	"Polished" "Diorite"
(minecraft:stone)
	"Andesite"
(minecraft:stone)
	"Polished" "Andesite"
(minecraft:stone)
	"Grass"
(minecraft:grass)
	"Dirt"
(minecraft:dirt)
	"Coarse" "Dirt"
(minecraft:dirt)
	"Podzol"
(minecraft:dirt)
	"Cobblestone"
(minecraft:cobblestone)
	"Oak" "Wood" "Plank"
(minecraft:planks)
	"Spruce" "Wood" "Plank"
(minecraft:planks)
	"Birch" "Wood" "Plank"
(minecraft:planks)
	"Jungle" "Wood" "Plank"
(minecraft:planks)
	"Acacia" "Wood" "Plank"
(minecraft:planks)
	"Dark" "Oak" "Wood" "Plank"
(minecraft:planks)
	"Oak" "Sapling"
(minecraft:sapling)
	"Spruce" "Sapling"
(minecraft:sapling)
	"Birch" "Sapling"
(minecraft:sapling)
	"Jungle" "Sapling"
(minecraft:sapling)
	"Acacia" "Sapling"
(minecraft:sapling)
	"Dark" "Oak" "Sapling"
(minecraft:sapling)
	"Bedrock"
(minecraft:bedrock)
	"Flowing" "Water"
(minecraft:flowing_water)
	"Still" "Water"
(minecraft:water)
	"Flowing" "Lava"
(minecraft:flowing_lava)
	"Still" "Lava"
(minecraft:lava)
	"Sand"
(minecraft:sand)
	"Red" "Sand"
(minecraft:sand)
	"Gravel"
(minecraft:gravel)
	"Gold" "Ore"
(minecraft:gold_ore)
	"Iron" "Ore"
(minecraft:iron_ore)
	"Coal" "Ore"
(minecraft:coal_ore)
	"Oak" "Wood"
(minecraft:log)
	"Spruce" "Wood"
(minecraft:log)
	"Birch" "Wood"
(minecraft:log)
	"Jungle" "Wood"
(minecraft:log)
	"Oak" "Leaves"
(minecraft:leaves)
	"Spruce" "Leaves"
(minecraft:leaves)
	"Birch" "Leaves"
(minecraft:leaves)
	"Jungle" "Leaves"
(minecraft:leaves)
	"Sponge"
(minecraft:sponge)
	"Wet" "Sponge"
(minecraft:sponge)
	"Glass"
(minecraft:glass)
	"Lapis" "Lazuli" "Ore"
(minecraft:lapis_ore)
	"Lapis" "Lazuli" "Block"
(minecraft:lapis_block)
	"Dispenser"
(minecraft:dispenser)
	"Sandstone"
(minecraft:sandstone)
	"Chiseled" "Sandstone"
(minecraft:sandstone)
	"Smooth" "Sandstone"
(minecraft:sandstone)
	"Note" "Block"
(minecraft:noteblock)
	"Bed"
(minecraft:bed)
	"Powered" "Rail"
(minecraft:golden_rail)
	"Detector" "Rail"
(minecraft:detector_rail)
	"Sticky" "Piston"
(minecraft:sticky_piston)
	"Cobweb"
(minecraft:web)
	"Dead" "Shrub"
(minecraft:tallgrass)
	"Grass"
(minecraft:tallgrass)
	"Fern"
(minecraft:tallgrass)
	"Dead" "Bush"
(minecraft:deadbush)
	"Piston"
(minecraft:piston)
	"Piston" "Head"
(minecraft:piston_head)
	"White" "Wool"
(minecraft:wool)
	"Orange" "Wool"
(minecraft:wool)
	"Magenta" "Wool"
(minecraft:wool)
	"Light" "Blue" "Wool"
(minecraft:wool)
	"Yellow" "Wool"
(minecraft:wool)
	"Lime" "Wool"
(minecraft:wool)
	"Pink" "Wool"
(minecraft:wool)
	"Gray" "Wool"
(minecraft:wool)
	"Light" "Gray" "Wool"
(minecraft:wool)
	"Cyan" "Wool"
(minecraft:wool)
	"Purple" "Wool"
(minecraft:wool)
	"Blue" "Wool"
(minecraft:wool)
	"Brown" "Wool"
(minecraft:wool)
	"Green" "Wool"
(minecraft:wool)
	"Red" "Wool"
(minecraft:wool)
	"Black" "Wool"
(minecraft:wool)
	"Dandelion"
(minecraft:yellow_flower)
	"Poppy"
(minecraft:red_flower)
	"Blue" "Orchid"
(minecraft:red_flower)
	"Allium"
(minecraft:red_flower)
	"Azure" "Bluet"
(minecraft:red_flower)
	"Red" "Tulip"
(minecraft:red_flower)
	"Orange" "Tulip"
(minecraft:red_flower)
	"White" "Tulip"
(minecraft:red_flower)
	"Pink" "Tulip"
(minecraft:red_flower)
	"Oxeye" "Daisy"
(minecraft:red_flower)
	"Brown" "Mushroom"
(minecraft:brown_mushroom)
	"Red" "Mushroom"
(minecraft:red_mushroom)
	"Gold" "Block"
(minecraft:gold_block)
	"Iron" "Block"
(minecraft:iron_block)
	"Double" "Stone" "Slab"
(minecraft:double_stone_slab)
	"Double" "Sandstone" "Slab"
(minecraft:double_stone_slab)
	"Double" "Wooden" "Slab"
(minecraft:double_stone_slab)
	"Double" "Cobblestone" "Slab"
(minecraft:double_stone_slab)
	"Double" "Brick" "Slab"
(minecraft:double_stone_slab)
	"Double" "Stone" "Brick" "Slab"
(minecraft:double_stone_slab)
	"Double" "Nether" "Brick" "Slab"
(minecraft:double_stone_slab)
	"Double" "Quartz" "Slab"
(minecraft:double_stone_slab)
	"Stone" "Slab"
(minecraft:stone_slab)
	"Sandstone" "Slab"
(minecraft:stone_slab)
	"Wooden" "Slab"
(minecraft:stone_slab)
	"Cobblestone" "Slab"
(minecraft:stone_slab)
	"Brick" "Slab"
(minecraft:stone_slab)
	"Stone" "Brick" "Slab"
(minecraft:stone_slab)
	"Nether" "Brick" "Slab"
(minecraft:stone_slab)
	"Quartz" "Slab"
(minecraft:stone_slab)
	"Bricks"
(minecraft:brick_block)
	"TNT"
(minecraft:tnt)
	"Bookshelf"
(minecraft:bookshelf)
	"Moss" "Stone"
(minecraft:mossy_cobblestone)
	"Obsidian"
(minecraft:obsidian)
	"Torch"
(minecraft:torch)
	"Fire"
(minecraft:fire)
	"Monster" "Spawner"
(minecraft:mob_spawner)
	"Oak" "Wood" "Stairs"
(minecraft:oak_stairs)
	"Chest"
(minecraft:chest)
	"Redstone" "Wire"
(minecraft:redstone_wire)
	"Diamond" "Ore"
(minecraft:diamond_ore)
	"Diamond" "Block"
(minecraft:diamond_block)
	"Crafting" "Table"
(minecraft:crafting_table)
	"Wheat" "Crops"
(minecraft:wheat)
	"Farmland"
(minecraft:farmland)
	"Furnace"
(minecraft:furnace)
	"Burning" "Furnace"
(minecraft:lit_furnace)
	"Standing" "Sign" "Block"
(minecraft:standing_sign)
	"Oak" "Door" "Block"
(minecraft:wooden_door)
	"Ladder"
(minecraft:ladder)
	"Rail"
(minecraft:rail)
	"Cobblestone" "Stairs"
(minecraft:stone_stairs)
	"Wall"-mounted "Sign" "Block"
(minecraft:wall_sign)
	"Lever"
(minecraft:lever)
	"Stone" "Pressure" "Plate"
(minecraft:stone_pressure_plate)
	"Iron" "Door" "Block"
(minecraft:iron_door)
	"Wooden" "Pressure" "Plate"
(minecraft:wooden_pressure_plate)
	"Redstone" "Ore"
(minecraft:redstone_ore)
	"Glowing" "Redstone" "Ore"
(minecraft:lit_redstone_ore)
	"Redstone" "Torch" (off)
(minecraft:unlit_redstone_torch)
	"Redstone" "Torch" (on)
(minecraft:redstone_torch)
	"Stone" "Button"
(minecraft:stone_button)
	"Snow"
(minecraft:snow_layer)
	"Ice"
(minecraft:ice)
	"Snow" "Block"
(minecraft:snow)
	"Cactus"
(minecraft:cactus)
	"Clay"
(minecraft:clay)
	"Sugar" "Canes"
(minecraft:reeds)
	"Jukebox"
(minecraft:jukebox)
	"Oak" "Fence"
(minecraft:fence)
	"Pumpkin"
(minecraft:pumpkin)
	"Netherrack"
(minecraft:netherrack)
	"Soul" "Sand"
(minecraft:soul_sand)
	"Glowstone"
(minecraft:glowstone)
	"Nether" "Portal"
(minecraft:portal)
	"Jack" "o"'Lantern
(minecraft:lit_pumpkin)
	"Cake" "Block"
(minecraft:cake)
	"Redstone" "Repeater" "Block" (off)
(minecraft:unpowered_repeater)
	"Redstone" "Repeater" "Block" (on)
(minecraft:powered_repeater)
	"White" "Stained" "Glass"
(minecraft:stained_glass)
	"Orange" "Stained" "Glass"
(minecraft:stained_glass)
	"Magenta" "Stained" "Glass"
(minecraft:stained_glass)
	"Light" "Blue" "Stained" "Glass"
(minecraft:stained_glass)
	"Yellow" "Stained" "Glass"
(minecraft:stained_glass)
	"Lime" "Stained" "Glass"
(minecraft:stained_glass)
	"Pink" "Stained" "Glass"
(minecraft:stained_glass)
	"Gray" "Stained" "Glass"
(minecraft:stained_glass)
	"Light" "Gray" "Stained" "Glass"
(minecraft:stained_glass)
	"Cyan" "Stained" "Glass"
(minecraft:stained_glass)
	"Purple" "Stained" "Glass"
(minecraft:stained_glass)
	"Blue" "Stained" "Glass"
(minecraft:stained_glass)
	"Brown" "Stained" "Glass"
(minecraft:stained_glass)
	"Green" "Stained" "Glass"
(minecraft:stained_glass)
	"Red" "Stained" "Glass"
(minecraft:stained_glass)
	"Black" "Stained" "Glass"
(minecraft:stained_glass)
	"Wooden" "Trapdoor"
(minecraft:trapdoor)
	"Stone" "Monster" "Egg"
(minecraft:monster_egg)
	"Cobblestone" "Monster" "Egg"
(minecraft:monster_egg)
	"Stone" "Brick" "Monster" "Egg"
(minecraft:monster_egg)
	"Mossy" "Stone" "Brick" "Monster" "Egg"
(minecraft:monster_egg)
	"Cracked" "Stone" "Brick" "Monster" "Egg"
(minecraft:monster_egg)
	"Chiseled" "Stone" "Brick" "Monster" "Egg"
(minecraft:monster_egg)
	"Stone" "Bricks"
(minecraft:stonebrick)
	"Mossy" "Stone" "Bricks"
(minecraft:stonebrick)
	"Cracked" "Stone" "Bricks"
(minecraft:stonebrick)
	"Chiseled" "Stone" "Bricks"
(minecraft:stonebrick)
	"Brown" "Mushroom" "Block"
(minecraft:brown_mushroom_block)
	"Red" "Mushroom" "Block"
(minecraft:red_mushroom_block)
	"Iron" "Bars"
(minecraft:iron_bars)
	"Glass" "Pane"
(minecraft:glass_pane)
	"Melon" "Block"
(minecraft:melon_block)
	"Pumpkin" "Stem"
(minecraft:pumpkin_stem)
	"Melon" "Stem"
(minecraft:melon_stem)
	"Vines"
(minecraft:vine)
	"Oak" "Fence" "Gate"
(minecraft:fence_gate)
	"Brick" "Stairs"
(minecraft:brick_stairs)
	"Stone" "Brick" "Stairs"
(minecraft:stone_brick_stairs)
	"Mycelium"
(minecraft:mycelium)
	"Lily" "Pad"
(minecraft:waterlily)
	"Nether" "Brick"
(minecraft:nether_brick)
	"Nether" "Brick" "Fence"
(minecraft:nether_brick_fence)
	"Nether" "Brick" "Stairs"
(minecraft:nether_brick_stairs)
	"Nether" "Wart"
(minecraft:nether_wart)
	"Enchantment" "Table"
(minecraft:enchanting_table)
	"Brewing" "Stand"
(minecraft:brewing_stand)
	"Cauldron"
(minecraft:cauldron)
	"End" "Portal"
(minecraft:end_portal)
	"End" "Portal" "Frame"
(minecraft:end_portal_frame)
	"End" "Stone"
(minecraft:end_stone)
	"Dragon" "Egg"
(minecraft:dragon_egg)
	"Redstone" "Lamp" (inactive)
(minecraft:redstone_lamp)
	"Redstone" "Lamp" (active)
(minecraft:lit_redstone_lamp)
	"Double" "Oak" "Wood" "Slab"
(minecraft:double_wooden_slab)
	"Double" "Spruce" "Wood" "Slab"
(minecraft:double_wooden_slab)
	"Double" "Birch" "Wood" "Slab"
(minecraft:double_wooden_slab)
	"Double" "Jungle" "Wood" "Slab"
(minecraft:double_wooden_slab)
	"Double" "Acacia" "Wood" "Slab"
(minecraft:double_wooden_slab)
	"Double" "Dark" "Oak" "Wood" "Slab"
(minecraft:double_wooden_slab)
	"Oak" "Wood" "Slab"
(minecraft:wooden_slab)
	"Spruce" "Wood" "Slab"
(minecraft:wooden_slab)
	"Birch" "Wood" "Slab"
(minecraft:wooden_slab)
	"Jungle" "Wood" "Slab"
(minecraft:wooden_slab)
	"Acacia" "Wood" "Slab"
(minecraft:wooden_slab)
	"Dark" "Oak" "Wood" "Slab"
(minecraft:wooden_slab)
	"Cocoa"
(minecraft:cocoa)
	"Sandstone" "Stairs"
(minecraft:sandstone_stairs)
	"Emerald" "Ore"
(minecraft:emerald_ore)
	"Ender" "Chest"
(minecraft:ender_chest)
	"Tripwire" "Hook"
(minecraft:tripwire_hook)
	"Tripwire"
(minecraft:tripwire_hook)
	"Emerald" "Block"
(minecraft:emerald_block)
	"Spruce" "Wood" "Stairs"
(minecraft:spruce_stairs)
	"Birch" "Wood" "Stairs"
(minecraft:birch_stairs)
	"Jungle" "Wood" "Stairs"
(minecraft:jungle_stairs)
	"Command" "Block"
(minecraft:command_block)
	"Beacon"
(minecraft:beacon)
	"Cobblestone" "Wall"
(minecraft:cobblestone_wall)
	"Mossy" "Cobblestone" "Wall"
(minecraft:cobblestone_wall)
	"Flower" "Pot"
(minecraft:flower_pot)
	"Carrots"
(minecraft:carrots)
	"Potatoes"
(minecraft:potatoes)
	"Wooden" "Button"
(minecraft:wooden_button)
	"Mob" "Head"
(minecraft:skull)
	"Anvil"
(minecraft:anvil)
	"Trapped" "Chest"
(minecraft:trapped_chest)
	"Weighted" "Pressure" "Plate" (light)
(minecraft:light_weighted_pressure_plate)
	"Weighted" "Pressure" "Plate" (heavy)
(minecraft:heavy_weighted_pressure_plate)
	"Redstone" "Comparator" (inactive)
(minecraft:unpowered_comparator)
	"Redstone" "Comparator" (active)
(minecraft:powered_comparator)
	"Daylight" "Sensor"
(minecraft:daylight_detector)
	"Redstone" "Block"
(minecraft:redstone_block)
	"Nether" "Quartz" "Ore"
(minecraft:quartz_ore)
	"Hopper"
(minecraft:hopper)
	"Quartz" "Block"
(minecraft:quartz_block)
	"Chiseled" "Quartz" "Block"
(minecraft:quartz_block)
	"Pillar" "Quartz" "Block"
(minecraft:quartz_block)
	"Quartz" "Stairs"
(minecraft:quartz_stairs)
	"Activator" "Rail"
(minecraft:activator_rail)
	"Dropper"
(minecraft:dropper)
	"White" "Stained" "Clay"
(minecraft:stained_hardened_clay)
	"Orange" "Stained" "Clay"
(minecraft:stained_hardened_clay)
	"Magenta" "Stained" "Clay"
(minecraft:stained_hardened_clay)
	"Light" "Blue" "Stained" "Clay"
(minecraft:stained_hardened_clay)
	"Yellow" "Stained" "Clay"
(minecraft:stained_hardened_clay)
	"Lime" "Stained" "Clay"
(minecraft:stained_hardened_clay)
	"Pink" "Stained" "Clay"
(minecraft:stained_hardened_clay)
	"Gray" "Stained" "Clay"
(minecraft:stained_hardened_clay)
	"Light" "Gray" "Stained" "Clay"
(minecraft:stained_hardened_clay)
	"Cyan" "Stained" "Clay"
(minecraft:stained_hardened_clay)
	"Purple" "Stained" "Clay"
(minecraft:stained_hardened_clay)
	"Blue" "Stained" "Clay"
(minecraft:stained_hardened_clay)
	"Brown" "Stained" "Clay"
(minecraft:stained_hardened_clay)
	"Green" "Stained" "Clay"
(minecraft:stained_hardened_clay)
	"Red" "Stained" "Clay"
(minecraft:stained_hardened_clay)
	"Black" "Stained" "Clay"
(minecraft:stained_hardened_clay)
	"White" "Stained" "Glass" "Pane"
(minecraft:stained_glass_pane)
	"Orange" "Stained" "Glass" "Pane"
(minecraft:stained_glass_pane)
	"Magenta" "Stained" "Glass" "Pane"
(minecraft:stained_glass_pane)
	"Light" "Blue" "Stained" "Glass" "Pane"
(minecraft:stained_glass_pane)
	"Yellow" "Stained" "Glass" "Pane"
(minecraft:stained_glass_pane)
	"Lime" "Stained" "Glass" "Pane"
(minecraft:stained_glass_pane)
	"Pink" "Stained" "Glass" "Pane"
(minecraft:stained_glass_pane)
	"Gray" "Stained" "Glass" "Pane"
(minecraft:stained_glass_pane)
	"Light" "Gray" "Stained" "Glass" "Pane"
(minecraft:stained_glass_pane)
	"Cyan" "Stained" "Glass" "Pane"
(minecraft:stained_glass_pane)
	"Purple" "Stained" "Glass" "Pane"
(minecraft:stained_glass_pane)
	"Blue" "Stained" "Glass" "Pane"
(minecraft:stained_glass_pane)
	"Brown" "Stained" "Glass" "Pane"
(minecraft:stained_glass_pane)
	"Green" "Stained" "Glass" "Pane"
(minecraft:stained_glass_pane)
	"Red" "Stained" "Glass" "Pane"
(minecraft:stained_glass_pane)
	"Black" "Stained" "Glass" "Pane"
(minecraft:stained_glass_pane)
	"Acacia" "Leaves"
(minecraft:leaves2)
	"Dark" "Oak" "Leaves"
(minecraft:leaves2)
	"Acacia" "Wood"
(minecraft:log2)
	"Dark" "Oak" "Wood"
(minecraft:log2)
	"Acacia" "Wood" "Stairs"
(minecraft:acacia_stairs)
	"Dark" "Oak" "Wood" "Stairs"
(minecraft:dark_oak_stairs)
	"Slime" "Block"
(minecraft:slime)
	"Barrier"
(minecraft:barrier)
	"Iron" "Trapdoor"
(minecraft:iron_trapdoor)
	"Prismarine"
(minecraft:prismarine)
	"Prismarine" "Bricks"
(minecraft:prismarine)
	"Dark" "Prismarine"
(minecraft:prismarine)
	"Sea" "Lantern"
(minecraft:sea_lantern)
	"Hay" "Bale"
(minecraft:hay_block)
	"White" "Carpet"
(minecraft:carpet)
	"Orange" "Carpet"
(minecraft:carpet)
	"Magenta" "Carpet"
(minecraft:carpet)
	"Light" "Blue" "Carpet"
(minecraft:carpet)
	"Yellow" "Carpet"
(minecraft:carpet)
	"Lime" "Carpet"
(minecraft:carpet)
	"Pink" "Carpet"
(minecraft:carpet)
	"Gray" "Carpet"
(minecraft:carpet)
	"Light" "Gray" "Carpet"
(minecraft:carpet)
	"Cyan" "Carpet"
(minecraft:carpet)
	"Purple" "Carpet"
(minecraft:carpet)
	"Blue" "Carpet"
(minecraft:carpet)
	"Brown" "Carpet"
(minecraft:carpet)
	"Green" "Carpet"
(minecraft:carpet)
	"Red" "Carpet"
(minecraft:carpet)
	"Black" "Carpet"
(minecraft:carpet)
	"Hardened" "Clay"
(minecraft:hardened_clay)
	"Block" "of" "Coal"
(minecraft:coal_block)
	"Packed" "Ice"
(minecraft:packed_ice)
	"Sunflower"
(minecraft:double_plant)
	"Lilac"
(minecraft:double_plant)
	"Double" "Tallgrass"
(minecraft:double_plant)
	"Large" "Fern"
(minecraft:double_plant)
	"Rose" "Bush"
(minecraft:double_plant)
	"Peony"
(minecraft:double_plant)
	"Free"-standing "Banner"
(minecraft:standing_banner)
	"Wall"-mounted "Banner"
(minecraft:wall_banner)
	"Inverted" "Daylight" "Sensor"
(minecraft:daylight_detector_inverted)
	"Red" "Sandstone"
(minecraft:red_sandstone)
	"Chiseled" "Red" "Sandstone"
(minecraft:red_sandstone)
	"Smooth" "Red" "Sandstone"
(minecraft:red_sandstone)
	"Red" "Sandstone" "Stairs"
(minecraft:red_sandstone_stairs)
	"Double" "Red" "Sandstone" "Slab"
(minecraft:stone_slab2)
	"Red" "Sandstone" "Slab"
(minecraft:double_stone_slab2)
	"Spruce" "Fence" "Gate"
(minecraft:spruce_fence_gate)
	"Birch" "Fence" "Gate"
(minecraft:birch_fence_gate)
	"Jungle" "Fence" "Gate"
(minecraft:jungle_fence_gate)
	"Dark" "Oak" "Fence" "Gate"
(minecraft:dark_oak_fence_gate)
	"Acacia" "Fence" "Gate"
(minecraft:acacia_fence_gate)
	"Spruce" "Fence"
(minecraft:spruce_fence)
	"Birch" "Fence"
(minecraft:birch_fence)
	"Jungle" "Fence"
(minecraft:jungle_fence)
	"Dark" "Oak" "Fence"
(minecraft:dark_oak_fence)
	"Acacia" "Fence"
(minecraft:acacia_fence)
	"Spruce" "Door" "Block"
(minecraft:spruce_door)
	"Birch" "Door" "Block"
(minecraft:birch_door)
	"Jungle" "Door" "Block"
(minecraft:jungle_door)
	"Acacia" "Door" "Block"
(minecraft:acacia_door)
	"Dark" "Oak" "Door" "Block"
(minecraft:dark_oak_door)
	"Iron" "Shovel"
(minecraft:iron_shovel)
	"Iron" "Pickaxe"
(minecraft:iron_pickaxe)
	"Iron" "Axe"
(minecraft:iron_axe)
	"Flint" "and" "Steel"
(minecraft:flint_and_steel)
	"Apple"
(minecraft:apple)
	"Bow"
(minecraft:bow)
	"Arrow"
(minecraft:arrow)
	"Coal"
(minecraft:coal)
	"Charcoal"
(minecraft:coal)
	"Diamond"
(minecraft:diamond)
	"Iron" "Ingot"
(minecraft:iron_ingot)
	"Gold" "Ingot"
(minecraft:gold_ingot)
	"Iron" "Sword"
(minecraft:iron_sword)
	"Wooden" "Sword"
(minecraft:wooden_sword)
	"Wooden" "Shovel"
(minecraft:wooden_shovel)
	"Wooden" "Pickaxe"
(minecraft:wooden_pickaxe)
	"Wooden" "Axe"
(minecraft:wooden_axe)
	"Stone" "Sword"
(minecraft:stone_sword)
	"Stone" "Shovel"
(minecraft:stone_shovel)
	"Stone" "Pickaxe"
(minecraft:stone_pickaxe)
	"Stone" "Axe"
(minecraft:stone_axe)
	"Diamond" "Sword"
(minecraft:diamond_sword)
	"Diamond" "Shovel"
(minecraft:diamond_shovel)
	"Diamond" "Pickaxe"
(minecraft:diamond_pickaxe)
	"Diamond" "Axe"
(minecraft:diamond_axe)
	"Stick"
(minecraft:stick)
	"Bowl"
(minecraft:bowl)
	"Mushroom" "Stew"
(minecraft:mushroom_stew)
	"Golden" "Sword"
(minecraft:golden_sword)
	"Golden" "Shovel"
(minecraft:golden_shovel)
	"Golden" "Pickaxe"
(minecraft:golden_pickaxe)
	"Golden" "Axe"
(minecraft:golden_axe)
	"String"
(minecraft:string)
	"Feather"
(minecraft:feather)
	"Gunpowder"
(minecraft:gunpowder)
	"Wooden" "Hoe"
(minecraft:wooden_hoe)
	"Stone" "Hoe"
(minecraft:stone_hoe)
	"Iron" "Hoe"
(minecraft:iron_hoe)
	"Diamond" "Hoe"
(minecraft:diamond_hoe)
	"Golden" "Hoe"
(minecraft:golden_hoe)
	"Wheat" "Seeds"
(minecraft:wheat_seeds)
	"Wheat"
(minecraft:wheat)
	"Bread"
(minecraft:bread)
	"Leather" "Helmet"
(minecraft:leather_helmet)
	"Leather" "Tunic"
(minecraft:leather_chestplate)
	"Leather" "Pants"
(minecraft:leather_leggings)
	"Leather" "Boots"
(minecraft:leather_boots)
	"Chainmail" "Helmet"
(minecraft:chainmail_helmet)
	"Chainmail" "Chestplate"
(minecraft:chainmail_chestplate)
	"Chainmail" "Leggings"
(minecraft:chainmail_leggings)
	"Chainmail" "Boots"
(minecraft:chainmail_boots)
	"Iron" "Helmet"
(minecraft:iron_helmet)
	"Iron" "Chestplate"
(minecraft:iron_chestplate)
	"Iron" "Leggings"
(minecraft:iron_leggings)
	"Iron" "Boots"
(minecraft:iron_boots)
	"Diamond" "Helmet"
(minecraft:diamond_helmet)
	"Diamond" "Chestplate"
(minecraft:diamond_chestplate)
	"Diamond" "Leggings"
(minecraft:diamond_leggings)
	"Diamond" "Boots"
(minecraft:diamond_boots)
	"Golden" "Helmet"
(minecraft:golden_helmet)
	"Golden" "Chestplate"
(minecraft:golden_chestplate)
	"Golden" "Leggings"
(minecraft:golden_leggings)
	"Golden" "Boots"
(minecraft:golden_boots)
	"Flint"
(minecraft:flint)
	"Raw" "Porkchop"
(minecraft:porkchop)
	"Cooked" "Porkchop"
(minecraft:cooked_porkchop)
	"Painting"
(minecraft:painting)
	"Golden" "Apple"
(minecraft:golden_apple)
	"Enchanted" "Golden" "Apple"
(minecraft:golden_apple)
	"Sign"
(minecraft:sign)
	"Oak" "Door"
(minecraft:wooden_door)
	"Bucket"
(minecraft:bucket)
	"Water" "Bucket"
(minecraft:water_bucket)
	"Lava" "Bucket"
(minecraft:lava_bucket)
	"Minecart"
(minecraft:minecart)
	"Saddle"
(minecraft:saddle)
	"Iron" "Door"
(minecraft:iron_door)
	"Redstone"
(minecraft:redstone)
	"Snowball"
(minecraft:snowball)
	"Boat"
(minecraft:boat)
	"Leather"
(minecraft:leather)
	"Milk" "Bucket"
(minecraft:milk_bucket)
	"Brick"
(minecraft:brick)
	"Clay"
(minecraft:clay_ball)
	"Sugar" "Canes"
(minecraft:reeds)
	"Paper"
(minecraft:paper)
	"Book"
(minecraft:book)
	"Slimeball"
(minecraft:slime_ball)
	"Minecart" "with" "Chest"
(minecraft:chest_minecart)
	"Minecart" "with" "Furnace"
(minecraft:furnace_minecart)
	"Egg"
(minecraft:egg)
	"Compass"
(minecraft:compass)
	"Fishing" "Rod"
(minecraft:fishing_rod)
	"Clock"
(minecraft:clock)
	"Glowstone" "Dust"
(minecraft:glowstone_dust)
	"Raw" "Fish"
(minecraft:fish)
	"Raw" "Salmon"
(minecraft:fish)
	"Clownfish"
(minecraft:fish)
	"Pufferfish"
(minecraft:fish)
	"Cooked" "Fish"
(minecraft:cooked_fish)
	"Cooked" "Salmon"
(minecraft:cooked_fish)
	"Ink" "Sack"
(minecraft:dye)
	"Rose" "Red"
(minecraft:dye)
	"Cactus" "Green"
(minecraft:dye)
	"Coco" "Beans"
(minecraft:dye)
	"Lapis" "Lazuli"
(minecraft:dye)
	"Purple" "Dye"
(minecraft:dye)
	"Cyan" "Dye"
(minecraft:dye)
	"Light" "Gray" "Dye"
(minecraft:dye)
	"Gray" "Dye"
(minecraft:dye)
	"Pink" "Dye"
(minecraft:dye)
	"Lime" "Dye"
(minecraft:dye)
	"Dandelion" "Yellow"
(minecraft:dye)
	"Light" "Blue" "Dye"
(minecraft:dye)
	"Magenta" "Dye"
(minecraft:dye)
	"Orange" "Dye"
(minecraft:dye)
	"Bone" "Meal"
(minecraft:dye)
	"Bone"
(minecraft:bone)
	"Sugar"
(minecraft:sugar)
	"Cake"
(minecraft:cake)
	"Bed"
(minecraft:bed)
	"Redstone" "Repeater"
(minecraft:repeater)
	"Cookie"
(minecraft:cookie)
	"Map"
(minecraft:filled_map)
	"Shears"
(minecraft:shears)
	"Melon"
(minecraft:melon)
	"Pumpkin" "Seeds"
(minecraft:pumpkin_seeds)
	"Melon" "Seeds"
(minecraft:melon_seeds)
	"Raw" "Beef"
(minecraft:beef)
	"Steak"
(minecraft:cooked_beef)
	"Raw" "Chicken"
(minecraft:chicken)
	"Cooked" "Chicken"
(minecraft:cooked_chicken)
	"Rotten" "Flesh"
(minecraft:rotten_flesh)
	"Ender" "Pearl"
(minecraft:ender_pearl)
	"Blaze" "Rod"
(minecraft:blaze_rod)
	"Ghast" "Tear"
(minecraft:ghast_tear)
	"Gold" "Nugget"
(minecraft:gold_nugget)
	"Nether" "Wart"
(minecraft:nether_wart)
	"Potion"
(minecraft:potion)
	"Glass" "Bottle"
(minecraft:glass_bottle)
	"Spider" "Eye"
(minecraft:spider_eye)
	"Fermented" "Spider" "Eye"
(minecraft:fermented_spider_eye)
	"Blaze" "Powder"
(minecraft:blaze_powder)
	"Magma" "Cream"
(minecraft:magma_cream)
	"Brewing" "Stand"
(minecraft:brewing_stand)
	"Cauldron"
(minecraft:cauldron)
	"Eye" "of" "Ender"
(minecraft:ender_eye)
	"Glistering" "Melon"
(minecraft:speckled_melon)
	"Spawn" "Creeper"
(minecraft:spawn_egg)
	"Spawn" "Skeleton"
(minecraft:spawn_egg)
	"Spawn" "Spider"
(minecraft:spawn_egg)
	"Spawn" "Zombie"
(minecraft:spawn_egg)
	"Spawn" "Slime"
(minecraft:spawn_egg)
	"Spawn" "Ghast"
(minecraft:spawn_egg)
	"Spawn" "Pigman"
(minecraft:spawn_egg)
	"Spawn" "Enderman"
(minecraft:spawn_egg)
	"Spawn" "Cave" "Spider"
(minecraft:spawn_egg)
	"Spawn" "Silverfish"
(minecraft:spawn_egg)
	"Spawn" "Blaze"
(minecraft:spawn_egg)
	"Spawn" "Magma" "Cube"
(minecraft:spawn_egg)
	"Spawn" "Bat"
(minecraft:spawn_egg)
	"Spawn" "Witch"
(minecraft:spawn_egg)
	"Spawn" "Endermite"
(minecraft:spawn_egg)
	"Spawn" "Guardian"
(minecraft:spawn_egg)
	"Spawn" "Pig"
(minecraft:spawn_egg)
	"Spawn" "Sheep"
(minecraft:spawn_egg)
	"Spawn" "Cow"
(minecraft:spawn_egg)
	"Spawn" "Chicken"
(minecraft:spawn_egg)
	"Spawn" "Squid"
(minecraft:spawn_egg)
	"Spawn" "Wolf"
(minecraft:spawn_egg)
	"Spawn" "Mooshroom"
(minecraft:spawn_egg)
	"Spawn" "Ocelot"
(minecraft:spawn_egg)
	"Spawn" "Horse"
(minecraft:spawn_egg)
	"Spawn" "Rabbit"
(minecraft:spawn_egg)
	"Spawn" "Villager"
(minecraft:spawn_egg)
	"Bottle" "o"' "Enchanting"
(minecraft:experience_bottle)
	"Fire" "Charge"
(minecraft:fire_charge)
	"Book" "and" "Quill"
(minecraft:writable_book)
	"Written" "Book"
(minecraft:written_book)
	"Emerald"
(minecraft:emerald)
	"Item" "Frame"
(minecraft:item_frame)
	"Flower" "Pot"
(minecraft:flower_pot)
	"Carrot"
(minecraft:carrot)
	"Potato"
(minecraft:potato)
	"Baked" "Potato"
(minecraft:baked_potato)
	"Poisonous" "Potato"
(minecraft:poisonous_potato)
	"Empty" "Map"
(minecraft:map)
	"Golden" "Carrot"
(minecraft:golden_carrot)
	"Mob" "Head" (Skeleton)
(minecraft:skull)
	"Mob" "Head" (Wither "Skeleton")
(minecraft:skull)
	"Mob" "Head" (Zombie)
(minecraft:skull)
	"Mob" "Head" (Human)
(minecraft:skull)
	"Mob" "Head" (Creeper)
(minecraft:skull)
	"Carrot" "on" "a" "Stick"
(minecraft:carrot_on_a_stick)
	"Nether" "Star"
(minecraft:nether_star)
	"Pumpkin" "Pie"
(minecraft:pumpkin_pie)
	"Firework" "Rocket"
(minecraft:fireworks)
	"Firework" "Star"
(minecraft:firework_charge)
	"Enchanted" "Book"
(minecraft:enchanted_book)
	"Redstone" "Comparator"
(minecraft:comparator)
	"Nether" "Brick"
(minecraft:netherbrick)
	"Nether" "Quartz"
(minecraft:quartz)
	"Minecart" "with" "TNT"
(minecraft:tnt_minecart)
	"Minecart" "with" "Hopper"
(minecraft:hopper_minecart)
	"Prismarine" "Shard"
(minecraft:prismarine_shard)
	"Prismarine" "Crystals"
(minecraft:prismarine_crystals)
	"Raw" "Rabbit"
(minecraft:rabbit)
	"Cooked" "Rabbit"
(minecraft:cooked_rabbit)
	"Rabbit" "Stew"
(minecraft:rabbit_stew)
	"Rabbit"'s "Foot"
(minecraft:rabbit_foot)
	"Rabbit" "Hide"
(minecraft:rabbit_hide)
	"Armor" "Stand"
(minecraft:armor_stand)
	"Iron" "Horse" "Armor"
(minecraft:iron_horse_armor)
	"Golden" "Horse" "Armor"
(minecraft:golden_horse_armor)
	"Diamond" "Horse" "Armor"
(minecraft:diamond_horse_armor)
	"Lead"
(minecraft:lead)
	"Name" "Tag"
(minecraft:name_tag)
	"Minecart" "with" "Command" "Block"
(minecraft:command_block_minecart)
	"Raw" "Mutton"
(minecraft:mutton)
	"Cooked" "Mutton"
(minecraft:cooked_mutton)
	"Banner"
(minecraft:banner)
	"Spruce" "Door"
(minecraft:spruce_door)
	"Birch" "Door"
(minecraft:birch_door)
	"Jungle" "Door"
(minecraft:jungle_door)
	"Acacia" "Door"
(minecraft:acacia_door)
	"Dark" "Oak" "Door"
(minecraft:dark_oak_door)
	"13" "Disc"
(minecraft:record_13)
	"Cat" "Disc"
(minecraft:record_cat)
	"Blocks" "Disc"
(minecraft:record_blocks)
	"Chirp" "Disc"
(minecraft:record_chirp)
	"Far" "Disc"
(minecraft:record_far)
	"Mall" "Disc"
(minecraft:record_mall)
	"Mellohi" "Disc"
(minecraft:record_mellohi)
	"Stal" "Disc"
(minecraft:record_stal)
	"Strad" "Disc"
(minecraft:record_strad)
	"Ward" "Disc"
(minecraft:record_ward)
	"11" "Disc"
(minecraft:record_11)
	"Wait" "Disc"
(minecraft:record_wait)
#End If
        ' Create a GrammarBuilder object and append the Choices object.
        Dim gb As New Speech.Recognition.GrammarBuilder()
        gb.Append(Commands)
        gb.Append(Blocks)
        ' Create the Grammar instance and load it into the speech recognition engine.
        recognizer.LoadGrammar(New Speech.Recognition.Grammar(gb))

        ' Register a handler for the SpeechRecognized event.
        AddHandler recognizer.SpeechRecognized, New EventHandler(Of Speech.Recognition.SpeechRecognizedEventArgs)(AddressOf sre_SpeechRecognized)
    End Sub

    ' Create a simple handler for the SpeechRecognized event.
    Private Sub sre_SpeechRecognized(sender As Object, e As Speech.Recognition.SpeechRecognizedEventArgs)
        AppendInputext(e.Result.Text)
    End Sub
    Private Sub AppendInputext(Text As String)
        If Input.InvokeRequired Then
            Dim myDelegate As New AppendTextDelegate(AddressOf AppendOutputText)
            Me.Invoke(myDelegate, Text)
        Else
            Input.Text &= Text
        End If
    End Sub

    Private Sub Main_Layout(sender As Object, e As EventArgs) Handles Me.Layout
        If Me.Size.Width < MinSize.Width OrElse Me.Size.Height < MinSize.Height Then Me.Size = MinSize
    End Sub

    Private Sub SettingsButton_Click(sender As Object, e As EventArgs) Handles SettingsButton.Click
        If Settings.Visible Then
            Settings.TopMost = True
        Else Settings.Show()
        End If
    End Sub
    Public Sub DisplayError(ByVal Exception As Exception)
        MsgBox(Exception.ToString, MsgBoxStyle.Critical)
    End Sub

    Private Sub Main_Load(sender As Object, e As EventArgs) Handles Me.Load
        With JavaArgs
            .JavaW = False
            .MemoryInit = 1024
            .MemoryInitUnit = JavaRuntimeArgs.MemoryUnit.M
            .MemoryMax = 2048
            .MemoryMaxUnit = JavaRuntimeArgs.MemoryUnit.M
            .MemoryMin = 1024
            .MemoryMinUnit = JavaRuntimeArgs.MemoryUnit.M
            .Bit64 = False
            .NoGUI = True
            .Online = True
        End With
    End Sub

    Private Sub EnvironmentButton_Click(sender As Object, e As EventArgs) Handles EnvironmentButton.Click
        Environment.Show()
    End Sub

    Friend Sub UpdateButtons(ServerRunning As Boolean)
        For Each Control As Control In Environment.Controls
            Control.Enabled = Not ServerRunning
        Next
        For Each Control As Control In Settings.Controls
            Control.Enabled = Not ServerRunning
        Next
    End Sub

    Private Sub RestartServer_Click(sender As Object, e As EventArgs) Handles RestartServer.Click
        If ServerRunning Then KillServer()
        Threading.Thread.Sleep(10000)

    End Sub

    Friend Sub KillServer()
        UpdateButtons(False)
        With Server
            Try
                .StandardInput.WriteLine("/stop") 'send an EXIT command to the Command Prompt
                .StandardInput.Flush()
                .WaitForExit(15000)
            Catch ex As InvalidOperationException
            Finally
                Try
                    .CancelErrorRead()
                    .CancelOutputRead()
                    .Kill()
                Catch ex As InvalidOperationException
                End Try
            End Try
        End With
    End Sub
End Class

Public Class PropertiesFile
    Inherits Dictionary(Of String, String)
    Implements IDictionary(Of String, String),
        IDictionary, Runtime.Serialization.ISerializable, Runtime.Serialization.IDeserializationCallback,
        ICollection(Of KeyValuePair(Of String, String)), IEnumerable(Of KeyValuePair(Of String, String)), IEnumerable

    Private AsyncReader As IO.StreamReader
    Private AsyncWriter As IO.StreamWriter

#Region "Constructers"

    Public Sub New()
        MyBase.New
    End Sub

    Public Sub New(dictionary As IDictionary(Of String, String))
        MyBase.New(dictionary)
    End Sub

    Public Sub New(Key As String, Value As String)
        Me.New
        Add(Key, Value)
    End Sub

    Public Sub New(KeyValuePair As KeyValuePair(Of String, String))
        Me.New
        Add(KeyValuePair)
    End Sub

    Public Sub New(KeyValuePairs As KeyValuePair(Of String, String)())
        MyBase.New(KeyValuePairs.ToDictionary(Function(x) x.Key, Function(x) x.Value))
    End Sub

    Public Sub New(ParamArray KeyValuePairs As String()())
        Me.New
        AddRange(KeyValuePairs)
    End Sub

    Public Sub New(dictionary As IDictionary(Of String, String), Key As String, Value As String)
        Me.New(dictionary)
        Add(Key, Value)
    End Sub

    Public Sub New(dictionary As IDictionary(Of String, String), KeyValuePair As KeyValuePair(Of String, String))
        Me.New(dictionary)
        Add(KeyValuePair)
    End Sub

    Public Sub New(dictionary As IDictionary(Of String, String), KeyValuePairs As KeyValuePair(Of String, String)())
        Me.New(dictionary)
        AddRange(KeyValuePairs)
    End Sub

    Public Sub New(dictionary As IDictionary(Of String, String), ParamArray KeyValuePairs As String()())
        Me.New(dictionary)
        AddRange(KeyValuePairs)
    End Sub

#End Region

#Region "IEqualityComparer<String> Constructers"

    Public Sub New(comparer As IEqualityComparer(Of String))
        MyBase.New(comparer)
    End Sub

    Public Sub New(dictionary As IDictionary(Of String, String), comparer As IEqualityComparer(Of String))
        MyBase.New(dictionary, comparer)
    End Sub

    Public Sub New(Key As String, Value As String, comparer As IEqualityComparer(Of String))
        Me.New(comparer)
        Add(Key, Value)
    End Sub

    Public Sub New(KeyValuePair As KeyValuePair(Of String, String), comparer As IEqualityComparer(Of String))
        Me.New(comparer)
        Add(KeyValuePair)
    End Sub

    Public Sub New(KeyValuePairs As KeyValuePair(Of String, String)(), comparer As IEqualityComparer(Of String))
        Me.New(comparer)
        AddRange(KeyValuePairs.ToDictionary(Function(x) x.Key, Function(x) x.Value).ToArray)
    End Sub

    Public Sub New(comparer As IEqualityComparer(Of String), ParamArray KeyValuePairs As String()())
        Me.New(comparer)
        For Each KeyValue As String() In KeyValuePairs
            Add(KeyValue(0), KeyValue(1))
        Next
    End Sub

    Public Sub New(dictionary As IDictionary(Of String, String), Key As String, Value As String,
                       comparer As IEqualityComparer(Of String))
        Me.New(dictionary, comparer)
        Add(Key, Value)
    End Sub

    Public Sub New(dictionary As IDictionary(Of String, String), KeyValuePair As KeyValuePair(Of String, String),
                       comparer As IEqualityComparer(Of String))
        Me.New(dictionary, comparer)
        Add(KeyValuePair)
    End Sub

    Public Sub New(dictionary As IDictionary(Of String, String), KeyValuePairs As KeyValuePair(Of String, String)(),
                       comparer As IEqualityComparer(Of String))
        Me.New(dictionary, comparer)
        AddRange(KeyValuePairs.ToDictionary(Function(x) x.Key, Function(x) x.Value).ToArray)
    End Sub

    Public Sub New(dictionary As IDictionary(Of String, String), comparer As IEqualityComparer(Of String),
                       ParamArray KeyValuePairs As String()())
        Me.New(dictionary, comparer)
        For Each KeyValue As String() In KeyValuePairs
            Add(KeyValue(0), KeyValue(1))
        Next
    End Sub
#End Region

    Public Overloads Sub Add(KeyValuePair As KeyValuePair(Of String, String))
        Add(KeyValuePair.Key, KeyValuePair.Value)
    End Sub


    Public Sub AddRange(KeyValuePairs As KeyValuePair(Of String, String)())
        For Each KeyValuePair As KeyValuePair(Of String, String) In KeyValuePairs
            Add(KeyValuePair)
        Next
    End Sub

    Public Sub AddRange(<[ParamArray]> ParamArray KeyValuePairs As String()())
        For Each KeyValue As String() In KeyValuePairs
            Add(KeyValue(0), KeyValue(1))
        Next
    End Sub

    Public Function ToDictionary() As Dictionary(Of String, String)
        Return New Dictionary(Of String, String)(Me)
    End Function

    Public Sub LoadFile(Path As String)
        LoadString(My.Computer.FileSystem.ReadAllText(Path))
    End Sub

    Public Sub LoadFile(Path As String, Encoding As System.Text.Encoding)
        LoadString(My.Computer.FileSystem.ReadAllText(Path, Encoding))
    End Sub

    Public Sub LoadFileAsync(Path As String)
        AsyncReader = New IO.StreamReader(Path)

    End Sub

    Public Sub LoadFileAsync(Path As String, Encoding As System.Text.Encoding)
        AsyncReader = New IO.StreamReader(Path, Encoding)
    End Sub

    Public Sub LoadStream(Stream As IO.Stream)
        AsyncReader = New IO.StreamReader(Stream)
    End Sub

    Public Sub LoadString(Content As String)
        Dim Prepend As String = String.Empty
        For Each Line As String In Content.Split({vbCr, vbLf}, StringSplitOptions.RemoveEmptyEntries)
            If Not Line.EndsWith("\\") AndAlso Line.EndsWith("\"c) Then
                Prepend &= Line.TrimEnd("\"c)
            ElseIf Prepend IsNot String.Empty Then

                Prepend = String.Empty
            Else
            End If
        Next
    End Sub
    Public Shared ReadOnly Empty As Integer
    Public Sub LoadLine(Line As String)

    End Sub
End Class