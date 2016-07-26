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
        If Not ServerRunning Then Exit Sub
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


        ' Create a GrammarBuilder object and append the Choices object.
        Dim gb As New Speech.Recognition.GrammarBuilder(New Speech.Recognition.Choices(
                                                       "achievement", "ban", "ban-ip", "banlist", "blockdata", "clear", "clone", "debug",
                                                       "defaultgamemode", "deop", "difficulty", "effect", "enchant", "entitydata", "execute",
                                                       "fill", "gamemode", "gamerule", "give", "help", "kick", "kill", "list", "me", "op",
                                                       "pardon", "particle", "playsound", "publish", "replaceitem", "save-all", "save-off",
                                                       "save-on", "say", "scoreboard", "seed", "setblock", "setidletimeout", "setworldspawn",
                                                       "spawnpoint", "spreadplayers", "stats", "stop", "summon", "teleport", "tell", "tellraw",
                                                       "testfor", "testforblock", "testforblocks", "time", "title", "toggledownfall", "tp",
                                                        "trigger", "weather", "whitelist", "worldborder", "xp"))
        ' Create a simple grammar that recognizes "red", "green", or "blue".

        Dim Blocks As New Speech.Recognition.Choices("11", "13", "Acacia", "Activator", "Air", "Allium", "Andesite", "Anvil", "Apple", "Armor",
                                                     "Arrow", "Axe", "Azure", "Baked", "Bale", "Banner", "Barrier", "Bars", "Bat", "Beacon",
                                                     "Beans", "Bed", "Bedrock", "Beef", "Birch", "Black", "Blaze", "Block", "Blocks", "Blue",
                                                     "Bluet", "Boat", "Bone", "Book", "Bookshelf", "Boots", "Bottle", "Bow", "Bowl", "Bread",
                                                     "Brewing", "Brick", "Bricks", "Brown", "Bucket", "Burning", "Bush", "Button", "Cactus",
                                                     "Cake", "Canes", "Carpet", "Carrot", "Carrots", "Cat", "Cauldron", "Cave", "Chainmail",
                                                     "Charcoal", "Charge", "Chest", "Chestplate", "Chicken", "Chirp", "Chiseled", "Clay",
                                                     "Clock", "Clownfish", "Coal", "Coarse", "Cobblestone", "Cobweb", "Coco", "Cocoa",
                                                     "Command", "Comparator", "Compass", "Cooked", "Cookie", "Cow", "Cracked", "Crafting",
                                                     "Cream", "Creeper", "Crops", "Crystals", "Cube", "Cyan", "Daisy", "Dandelion", "Dark",
                                                     "Daylight", "Dead", "Detector", "Diamond", "Diorite", "Dirt", "Disc", "Dispenser", "Door",
                                                     "Double", "Dragon", "Dropper", "Dust", "Dye", "Egg", "Emerald", "Empty", "Enchanted",
                                                     "Enchanting", "Enchantment", "End", "Ender", "Enderman", "Endermite", "Eye", "Far",
                                                     "Farmland", "Feather", "Fence", "Fermented", "Fern", "Fire", "Firework", "Fish",
                                                     "Fishing", "Flesh", "Flint", "Flower", "Flowing", "Foot", "Frame", "Free", "Furnace",
                                                     "Gate", "Ghast", "Glass", "Glistering", "Glowing", "Glowstone", "Gold", "Golden",
                                                     "Granite", "Grass", "Gravel", "Gray", "Green", "Guardian", "Gunpowder", "Hardened", "Hay",
                                                     "Head", "Helmet", "Hide", "Hoe", "Hook", "Hopper", "Horse", "Human", "Ice", "Ingot",
                                                     "Ink", "Inverted", "Iron", "Item", "Jack", "Jukebox", "Jungle", "Ladder", "Lamp",
                                                     "Lantern", "Lapis", "Large", "Lava", "Lazuli", "Lead", "Leather", "Leaves", "Leggings",
                                                     "Lever", "Light", "Lilac", "Lily", "Lime", "Magenta", "Magma", "Mall", "Map", "Meal",
                                                     "Mellohi", "Melon", "Milk", "Minecart", "Mob", "Monster", "Mooshroom", "Moss", "Mossy",
                                                     "Mushroom", "Mutton", "Mycelium", "Name", "Nether", "Netherrack", "Note", "Nugget", "Oak",
                                                     "Obsidian", "Ocelot", "Orange", "Orchid", "Ore", "Oxeye", "Packed", "Pad", "Painting",
                                                     "Pane", "Pants", "Paper", "Pearl", "Peony", "Pickaxe", "Pie", "Pig", "Pigman", "Pillar",
                                                     "Pink", "Piston", "Plank", "Plate", "Podzol", "Poisonous", "Polished", "Poppy",
                                                     "Porkchop", "Portal", "Pot", "Potato", "Potatoes", "Potion", "Powder", "Powered",
                                                     "Pressure", "Prismarine", "Pufferfish", "Pumpkin", "Purple", "Quartz", "Quill", "Rabbit",
                                                     "Rabbit's", "Rail", "Raw", "Red", "Redstone", "Repeater", "Rocket", "Rod", "Rose",
                                                     "Rotten", "Sack", "Saddle", "Salmon", "Sand", "Sandstone", "Sapling", "Sea", "Seeds",
                                                     "Sensor", "Shard", "Shears", "Sheep", "Shovel", "Shrub", "Sign", "Silverfish", "Skeleton",
                                                     "Skeleton", "Slab", "Slime", "Slimeball", "Smooth", "Snow", "Snowball", "Soul", "Spawn",
                                                     "Spawner", "Spider", "Sponge", "Spruce", "Squid", "Stained", "Stairs", "Stal", "Stand",
                                                     "Standing", "Star", "Steak", "Steel", "Stem", "Stew", "Stick", "Sticky", "Still", "Stone",
                                                     "Strad", "String", "Sugar", "Sunflower", "Sword", "TNT", "Table", "Tag", "Tallgrass",
                                                     "Tear", "Torch", "Trapdoor", "Trapped", "Tripwire", "Tulip", "Tunic", "Villager", "Vines",
                                                     "Wait", "Wall", "Ward", "Wart", "Water", "Weighted", "Wet", "Wheat", "White", "Wire",
                                                     "Witch", "Wither", "Wolf", "Wood", "Wooden", "Wool", "Written", "Yellow", "Zombie", "a",
                                                     "active", "and", "heavy", "inactive", "light", "mounted", "o'", "of", "off", "on",
                                                     "standing", "with")
        Dim IDs As New Speech.Recognition.Choices("minecraft:acacia_door", "minecraft:acacia_fence", "minecraft:acacia_fence_gate",
                                                  "minecraft:acacia_stairs", "minecraft:activator_rail", "minecraft:air", "minecraft:anvil",
                                                  "minecraft:apple", "minecraft:armor_stand", "minecraft:arrow", "minecraft:baked_potato",
                                                  "minecraft:banner", "minecraft:barrier", "minecraft:beacon", "minecraft:bed",
                                                  "minecraft:bedrock", "minecraft:beef", "minecraft:birch_door", "minecraft:birch_fence",
                                                  "minecraft:birch_fence_gate", "minecraft:birch_stairs", "minecraft:blaze_powder",
                                                  "minecraft:blaze_rod", "minecraft:boat", "minecraft:bone", "minecraft:book",
                                                  "minecraft:bookshelf", "minecraft:bow", "minecraft:bowl", "minecraft:bread",
                                                  "minecraft:brewing_stand", "minecraft:brick", "minecraft:brick_block",
                                                  "minecraft:brick_stairs", "minecraft:brown_mushroom", "minecraft:brown_mushroom_block",
                                                  "minecraft:bucket", "minecraft:cactus", "minecraft:cake", "minecraft:carpet",
                                                  "minecraft:carrot", "minecraft:carrot_on_a_stick", "minecraft:carrots", "minecraft:cauldron",
                                                  "minecraft:chainmail_boots", "minecraft:chainmail_chestplate", "minecraft:chainmail_helmet",
                                                  "minecraft:chainmail_leggings", "minecraft:chest", "minecraft:chest_minecart",
                                                  "minecraft:chicken", "minecraft:clay", "minecraft:clay_ball", "minecraft:clock",
                                                  "minecraft:coal", "minecraft:coal_block", "minecraft:coal_ore", "minecraft:cobblestone",
                                                  "minecraft:cobblestone_wall", "minecraft:cocoa", "minecraft:command_block",
                                                  "minecraft:command_block_minecart", "minecraft:comparator", "minecraft:compass",
                                                  "minecraft:cooked_beef", "minecraft:cooked_chicken", "minecraft:cooked_fish",
                                                  "minecraft:cooked_mutton", "minecraft:cooked_porkchop", "minecraft:cooked_rabbit",
                                                  "minecraft:cookie", "minecraft:crafting_table", "minecraft:dark_oak_door",
                                                  "minecraft:dark_oak_fence", "minecraft:dark_oak_fence_gate", "minecraft:dark_oak_stairs",
                                                  "minecraft:daylight_detector", "minecraft:daylight_detector_inverted", "minecraft:deadbush",
                                                  "minecraft:detector_rail", "minecraft:diamond", "minecraft:diamond_axe",
                                                  "minecraft:diamond_block", "minecraft:diamond_boots", "minecraft:diamond_chestplate",
                                                  "minecraft:diamond_helmet", "minecraft:diamond_hoe", "minecraft:diamond_horse_armor",
                                                  "minecraft:diamond_leggings", "minecraft:diamond_ore", "minecraft:diamond_pickaxe",
                                                  "minecraft:diamond_shovel", "minecraft:diamond_sword", "minecraft:dirt",
                                                  "minecraft:dispenser", "minecraft:double_plant", "minecraft:double_stone_slab",
                                                  "minecraft:double_stone_slab2", "minecraft:double_wooden_slab", "minecraft:dragon_egg",
                                                  "minecraft:dropper", "minecraft:dye", "minecraft:egg", "minecraft:emerald",
                                                  "minecraft:emerald_block", "minecraft:emerald_ore", "minecraft:enchanted_book",
                                                  "minecraft:enchanting_table", "minecraft:end_portal", "minecraft:end_portal_frame",
                                                  "minecraft:end_stone", "minecraft:ender_chest", "minecraft:ender_eye",
                                                  "minecraft:ender_pearl", "minecraft:experience_bottle", "minecraft:farmland",
                                                  "minecraft:feather", "minecraft:fence", "minecraft:fence_gate",
                                                  "minecraft:fermented_spider_eye", "minecraft:filled_map", "minecraft:fire",
                                                  "minecraft:fire_charge", "minecraft:firework_charge", "minecraft:fireworks",
                                                  "minecraft:fish", "minecraft:fishing_rod", "minecraft:flint", "minecraft:flint_and_steel",
                                                  "minecraft:flower_pot", "minecraft:flowing_lava", "minecraft:flowing_water",
                                                  "minecraft:furnace", "minecraft:furnace_minecart", "minecraft:ghast_tear", "minecraft:glass",
                                                  "minecraft:glass_bottle", "minecraft:glass_pane", "minecraft:glowstone",
                                                  "minecraft:glowstone_dust", "minecraft:gold_block", "minecraft:gold_ingot",
                                                  "minecraft:gold_nugget", "minecraft:gold_ore", "minecraft:golden_apple",
                                                  "minecraft:golden_axe", "minecraft:golden_boots", "minecraft:golden_carrot",
                                                  "minecraft:golden_chestplate", "minecraft:golden_helmet", "minecraft:golden_hoe",
                                                  "minecraft:golden_horse_armor", "minecraft:golden_leggings", "minecraft:golden_pickaxe",
                                                  "minecraft:golden_rail", "minecraft:golden_shovel", "minecraft:golden_sword",
                                                  "minecraft:grass", "minecraft:gravel", "minecraft:gunpowder", "minecraft:hardened_clay",
                                                  "minecraft:hay_block", "minecraft:heavy_weighted_pressure_plate", "minecraft:hopper",
                                                  "minecraft:hopper_minecart", "minecraft:ice", "minecraft:iron_axe", "minecraft:iron_bars",
                                                  "minecraft:iron_block", "minecraft:iron_boots", "minecraft:iron_chestplate",
                                                  "minecraft:iron_door", "minecraft:iron_helmet", "minecraft:iron_hoe",
                                                  "minecraft:iron_horse_armor", "minecraft:iron_ingot", "minecraft:iron_leggings",
                                                  "minecraft:iron_ore", "minecraft:iron_pickaxe", "minecraft:iron_shovel",
                                                  "minecraft:iron_sword", "minecraft:iron_trapdoor", "minecraft:item_frame",
                                                  "minecraft:jukebox", "minecraft:jungle_door", "minecraft:jungle_fence",
                                                  "minecraft:jungle_fence_gate", "minecraft:jungle_stairs", "minecraft:ladder",
                                                  "minecraft:lapis_block", "minecraft:lapis_ore", "minecraft:lava", "minecraft:lava_bucket",
                                                  "minecraft:lead", "minecraft:leather", "minecraft:leather_boots",
                                                  "minecraft:leather_chestplate", "minecraft:leather_helmet", "minecraft:leather_leggings",
                                                  "minecraft:leaves", "minecraft:leaves2", "minecraft:lever",
                                                  "minecraft:light_weighted_pressure_plate", "minecraft:lit_furnace", "minecraft:lit_pumpkin",
                                                  "minecraft:lit_redstone_lamp", "minecraft:lit_redstone_ore", "minecraft:log",
                                                  "minecraft:log2", "minecraft:magma_cream", "minecraft:map", "minecraft:melon",
                                                  "minecraft:melon_block", "minecraft:melon_seeds", "minecraft:melon_stem",
                                                  "minecraft:milk_bucket", "minecraft:minecart", "minecraft:mob_spawner",
                                                  "minecraft:monster_egg", "minecraft:mossy_cobblestone", "minecraft:mushroom_stew",
                                                  "minecraft:mutton", "minecraft:mycelium", "minecraft:name_tag", "minecraft:nether_brick",
                                                  "minecraft:nether_brick_fence", "minecraft:nether_brick_stairs", "minecraft:nether_star",
                                                  "minecraft:nether_wart", "minecraft:netherbrick", "minecraft:netherrack",
                                                  "minecraft:noteblock", "minecraft:oak_stairs", "minecraft:obsidian", "minecraft:packed_ice",
                                                  "minecraft:painting", "minecraft:paper", "minecraft:piston", "minecraft:piston_head",
                                                  "minecraft:planks", "minecraft:poisonous_potato", "minecraft:porkchop", "minecraft:portal",
                                                  "minecraft:potato", "minecraft:potatoes", "minecraft:potion", "minecraft:powered_comparator",
                                                  "minecraft:powered_repeater", "minecraft:prismarine", "minecraft:prismarine_crystals",
                                                  "minecraft:prismarine_shard", "minecraft:pumpkin", "minecraft:pumpkin_pie",
                                                  "minecraft:pumpkin_seeds", "minecraft:pumpkin_stem", "minecraft:quartz",
                                                  "minecraft:quartz_block", "minecraft:quartz_ore", "minecraft:quartz_stairs",
                                                  "minecraft:rabbit", "minecraft:rabbit_foot", "minecraft:rabbit_hide",
                                                  "minecraft:rabbit_stew", "minecraft:rail", "minecraft:record_11", "minecraft:record_13",
                                                  "minecraft:record_blocks", "minecraft:record_cat", "minecraft:record_chirp",
                                                  "minecraft:record_far", "minecraft:record_mall", "minecraft:record_mellohi",
                                                  "minecraft:record_stal", "minecraft:record_strad", "minecraft:record_wait",
                                                  "minecraft:record_ward", "minecraft:red_flower", "minecraft:red_mushroom",
                                                  "minecraft:red_mushroom_block", "minecraft:red_sandstone", "minecraft:red_sandstone_stairs",
                                                  "minecraft:redstone", "minecraft:redstone_block", "minecraft:redstone_lamp",
                                                  "minecraft:redstone_ore", "minecraft:redstone_torch", "minecraft:redstone_wire",
                                                  "minecraft:reeds", "minecraft:repeater", "minecraft:rotten_flesh", "minecraft:saddle",
                                                  "minecraft:sand", "minecraft:sandstone", "minecraft:sandstone_stairs", "minecraft:sapling",
                                                  "minecraft:sea_lantern", "minecraft:shears", "minecraft:sign", "minecraft:skull",
                                                  "minecraft:slime", "minecraft:slime_ball", "minecraft:snow", "minecraft:snow_layer",
                                                  "minecraft:snowball", "minecraft:soul_sand", "minecraft:spawn_egg",
                                                  "minecraft:speckled_melon", "minecraft:spider_eye", "minecraft:sponge",
                                                  "minecraft:spruce_door", "minecraft:spruce_fence", "minecraft:spruce_fence_gate",
                                                  "minecraft:spruce_stairs", "minecraft:stained_glass", "minecraft:stained_glass_pane",
                                                  "minecraft:stained_hardened_clay", "minecraft:standing_banner", "minecraft:standing_sign",
                                                  "minecraft:stick", "minecraft:sticky_piston", "minecraft:stone", "minecraft:stone_axe",
                                                  "minecraft:stone_brick_stairs", "minecraft:stone_button", "minecraft:stone_hoe",
                                                  "minecraft:stone_pickaxe", "minecraft:stone_pressure_plate", "minecraft:stone_shovel",
                                                  "minecraft:stone_slab", "minecraft:stone_slab2", "minecraft:stone_stairs",
                                                  "minecraft:stone_sword", "minecraft:stonebrick", "minecraft:string", "minecraft:sugar",
                                                  "minecraft:tallgrass", "minecraft:tnt", "minecraft:tnt_minecart", "minecraft:torch",
                                                  "minecraft:trapdoor", "minecraft:trapped_chest", "minecraft:tripwire_hook",
                                                  "minecraft:unlit_redstone_torch", "minecraft:unpowered_comparator",
                                                  "minecraft:unpowered_repeater", "minecraft:vine", "minecraft:wall_banner",
                                                  "minecraft:wall_sign", "minecraft:water", "minecraft:water_bucket", "minecraft:waterlily",
                                                  "minecraft:web", "minecraft:wheat", "minecraft:wheat_seeds", "minecraft:wooden_axe",
                                                  "minecraft:wooden_button", "minecraft:wooden_door", "minecraft:wooden_hoe",
                                                  "minecraft:wooden_pickaxe", "minecraft:wooden_pressure_plate", "minecraft:wooden_shovel",
                                                  "minecraft:wooden_slab", "minecraft:wooden_sword", "minecraft:wool",
                                                  "minecraft:writable_book", "minecraft:written_book", "minecraft:yellow_flower")

        ' Create a new SpeechRecognitionEngine instance.
        Dim recognizer As New Speech.Recognition.SpeechRecognizer()
        gb.Append(Blocks)
        gb.Append(IDs)
        ' Create the Grammar instance and load it into the speech recognition engine.
        recognizer.LoadGrammar(New Speech.Recognition.Grammar(gb))
        ' Register a handler for the SpeechRecognized event.
        AddHandler recognizer.SpeechRecognized, New EventHandler(Of
            Speech.Recognition.SpeechRecognizedEventArgs)(AddressOf sre_SpeechRecognized)
    End Sub

    ' Create a simple handler for the SpeechRecognized event.
    Private Sub sre_SpeechRecognized(sender As Object, e As Speech.Recognition.SpeechRecognizedEventArgs)
        AppendInputText(e.Result.Text)
    End Sub
    Private Sub AppendInputText(Text As String)
        If Input.InvokeRequired Then
            Dim myDelegate As New AppendTextDelegate(AddressOf AppendInputText)
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