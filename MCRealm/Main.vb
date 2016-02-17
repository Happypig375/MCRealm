﻿Public Class Main
    Friend ReadOnly MinSize As System.Drawing.Size = Me.Size
    Friend WithEvents Server As New Process()
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

    Private Sub LoadWorld_Click(sender As Object, e As EventArgs) Handles LoadWorld.Click
        If Load_From.ShowDialog = System.Windows.Forms.DialogResult.Cancel Then Exit Sub
        Path.Text = Load_From.Path
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
                Settings.JAVASwitch.Enabled = True
                Server.StandardInput.WriteLine("/stop") 'send an EXIT command to the Command Prompt
                Server.StandardInput.Flush()
                Server.CancelErrorRead()
                Server.CancelOutputRead()
                Server.Kill()
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
                    .Arguments = String.Format("-Xms{0}{1} -Xmx{2}{3} -jar ""{4}"" nogui -o true", Settings.MemoryMinimum.Value,
                                               Settings.MemoryMinimumUnit.SelectedText, Settings.MemoryMaximum.Value,
                                               Settings.MemoryMaximumUnit.SelectedText, JAR.Text)
                    .UseShellExecute = False
                    .CreateNoWindow = True
                    .RedirectStandardInput = True
                    .RedirectStandardOutput = True
                    .RedirectStandardError = True
                End With
                ' You can start any process, HelloWorld is a do-nothing example.
                Settings.JAVASwitch.Enabled = False
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
        Return If(Settings.JAVASwitch.Value = 0, "java.exe", "javaw.exe")
    End Function
    Private Delegate Sub DefaultEventDelegate(sender As Object, e As EventArgs)
    Private Sub Server_Exited(sender As Object, e As EventArgs) Handles Server.Exited
        Settings.JAVASwitch.Enabled = True
        If ServerSwitch.InvokeRequired Then
            Dim myDelegate As New DefaultEventDelegate(AddressOf Server_Exited)
            Me.Invoke(myDelegate, sender, e)
        Else
            ServerSwitch.Text = "Start Server"
        End If
    End Sub
    Private Sub Display(sender As Object, e As System.Diagnostics.DataReceivedEventArgs) Handles Server.ErrorDataReceived, Server.OutputDataReceived
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
#If False Then
        0 	
	Air
(minecraft:air)
1 	
	Stone
(minecraft:stone)
1:1 	
	Granite
(minecraft:stone)
1:2 	
	Polished Granite
(minecraft:stone)
1:3 	
	Diorite
(minecraft:stone)
1:4 	
	Polished Diorite
(minecraft:stone)
1:5 	
	Andesite
(minecraft:stone)
1:6 	
	Polished Andesite
(minecraft:stone)
2 	
	Grass
(minecraft:grass)
3 	
	Dirt
(minecraft:dirt)
3:1 	
	Coarse Dirt
(minecraft:dirt)
3:2 	
	Podzol
(minecraft:dirt)
4 	
	Cobblestone
(minecraft:cobblestone)
5 	
	Oak Wood Plank
(minecraft:planks)
5:1 	
	Spruce Wood Plank
(minecraft:planks)
5:2 	
	Birch Wood Plank
(minecraft:planks)
5:3 	
	Jungle Wood Plank
(minecraft:planks)
5:4 	
	Acacia Wood Plank
(minecraft:planks)
5:5 	
	Dark Oak Wood Plank
(minecraft:planks)
6 	
	Oak Sapling
(minecraft:sapling)
6:1 	
	Spruce Sapling
(minecraft:sapling)
6:2 	
	Birch Sapling
(minecraft:sapling)
6:3 	
	Jungle Sapling
(minecraft:sapling)
6:4 	
	Acacia Sapling
(minecraft:sapling)
6:5 	
	Dark Oak Sapling
(minecraft:sapling)
7 	
	Bedrock
(minecraft:bedrock)
8 	
	Flowing Water
(minecraft:flowing_water)
9 	
	Still Water
(minecraft:water)
10 	
	Flowing Lava
(minecraft:flowing_lava)
11 	
	Still Lava
(minecraft:lava)
12 	
	Sand
(minecraft:sand)
12:1 	
	Red Sand
(minecraft:sand)
13 	
	Gravel
(minecraft:gravel)
14 	
	Gold Ore
(minecraft:gold_ore)
15 	
	Iron Ore
(minecraft:iron_ore)
16 	
	Coal Ore
(minecraft:coal_ore)
17 	
	Oak Wood
(minecraft:log)
17:1 	
	Spruce Wood
(minecraft:log)
17:2 	
	Birch Wood
(minecraft:log)
17:3 	
	Jungle Wood
(minecraft:log)
18 	
	Oak Leaves
(minecraft:leaves)
18:1 	
	Spruce Leaves
(minecraft:leaves)
18:2 	
	Birch Leaves
(minecraft:leaves)
18:3 	
	Jungle Leaves
(minecraft:leaves)
19 	
	Sponge
(minecraft:sponge)
19:1 	
	Wet Sponge
(minecraft:sponge)
20 	
	Glass
(minecraft:glass)
21 	
	Lapis Lazuli Ore
(minecraft:lapis_ore)
22 	
	Lapis Lazuli Block
(minecraft:lapis_block)
23 	
	Dispenser
(minecraft:dispenser)
24 	
	Sandstone
(minecraft:sandstone)
24:1 	
	Chiseled Sandstone
(minecraft:sandstone)
24:2 	
	Smooth Sandstone
(minecraft:sandstone)
25 	
	Note Block
(minecraft:noteblock)
26 	
	Bed
(minecraft:bed)
27 	
	Powered Rail
(minecraft:golden_rail)
28 	
	Detector Rail
(minecraft:detector_rail)
29 	
	Sticky Piston
(minecraft:sticky_piston)
30 	
	Cobweb
(minecraft:web)
31 	
	Dead Shrub
(minecraft:tallgrass)
31:1 	
	Grass
(minecraft:tallgrass)
31:2 	
	Fern
(minecraft:tallgrass)
32 	
	Dead Bush
(minecraft:deadbush)
33 	
	Piston
(minecraft:piston)
34 	
	Piston Head
(minecraft:piston_head)
35 	
	White Wool
(minecraft:wool)
35:1 	
	Orange Wool
(minecraft:wool)
35:2 	
	Magenta Wool
(minecraft:wool)
35:3 	
	Light Blue Wool
(minecraft:wool)
35:4 	
	Yellow Wool
(minecraft:wool)
35:5 	
	Lime Wool
(minecraft:wool)
35:6 	
	Pink Wool
(minecraft:wool)
35:7 	
	Gray Wool
(minecraft:wool)
35:8 	
	Light Gray Wool
(minecraft:wool)
35:9 	
	Cyan Wool
(minecraft:wool)
35:10 	
	Purple Wool
(minecraft:wool)
35:11 	
	Blue Wool
(minecraft:wool)
35:12 	
	Brown Wool
(minecraft:wool)
35:13 	
	Green Wool
(minecraft:wool)
35:14 	
	Red Wool
(minecraft:wool)
35:15 	
	Black Wool
(minecraft:wool)
37 	
	Dandelion
(minecraft:yellow_flower)
38 	
	Poppy
(minecraft:red_flower)
38:1 	
	Blue Orchid
(minecraft:red_flower)
38:2 	
	Allium
(minecraft:red_flower)
38:3 	
	Azure Bluet
(minecraft:red_flower)
38:4 	
	Red Tulip
(minecraft:red_flower)
38:5 	
	Orange Tulip
(minecraft:red_flower)
38:6 	
	White Tulip
(minecraft:red_flower)
38:7 	
	Pink Tulip
(minecraft:red_flower)
38:8 	
	Oxeye Daisy
(minecraft:red_flower)
39 	
	Brown Mushroom
(minecraft:brown_mushroom)
40 	
	Red Mushroom
(minecraft:red_mushroom)
41 	
	Gold Block
(minecraft:gold_block)
42 	
	Iron Block
(minecraft:iron_block)
43 	
	Double Stone Slab
(minecraft:double_stone_slab)
43:1 	
	Double Sandstone Slab
(minecraft:double_stone_slab)
43:2 	
	Double Wooden Slab
(minecraft:double_stone_slab)
43:3 	
	Double Cobblestone Slab
(minecraft:double_stone_slab)
43:4 	
	Double Brick Slab
(minecraft:double_stone_slab)
43:5 	
	Double Stone Brick Slab
(minecraft:double_stone_slab)
43:6 	
	Double Nether Brick Slab
(minecraft:double_stone_slab)
43:7 	
	Double Quartz Slab
(minecraft:double_stone_slab)
44 	
	Stone Slab
(minecraft:stone_slab)
44:1 	
	Sandstone Slab
(minecraft:stone_slab)
44:2 	
	Wooden Slab
(minecraft:stone_slab)
44:3 	
	Cobblestone Slab
(minecraft:stone_slab)
44:4 	
	Brick Slab
(minecraft:stone_slab)
44:5 	
	Stone Brick Slab
(minecraft:stone_slab)
44:6 	
	Nether Brick Slab
(minecraft:stone_slab)
44:7 	
	Quartz Slab
(minecraft:stone_slab)
45 	
	Bricks
(minecraft:brick_block)
46 	
	TNT
(minecraft:tnt)
47 	
	Bookshelf
(minecraft:bookshelf)
48 	
	Moss Stone
(minecraft:mossy_cobblestone)
49 	
	Obsidian
(minecraft:obsidian)
50 	
	Torch
(minecraft:torch)
51 	
	Fire
(minecraft:fire)
52 	
	Monster Spawner
(minecraft:mob_spawner)
53 	
	Oak Wood Stairs
(minecraft:oak_stairs)
54 	
	Chest
(minecraft:chest)
55 	
	Redstone Wire
(minecraft:redstone_wire)
56 	
	Diamond Ore
(minecraft:diamond_ore)
57 	
	Diamond Block
(minecraft:diamond_block)
58 	
	Crafting Table
(minecraft:crafting_table)
59 	
	Wheat Crops
(minecraft:wheat)
60 	
	Farmland
(minecraft:farmland)
61 	
	Furnace
(minecraft:furnace)
62 	
	Burning Furnace
(minecraft:lit_furnace)
63 	
	Standing Sign Block
(minecraft:standing_sign)
64 	
	Oak Door Block
(minecraft:wooden_door)
65 	
	Ladder
(minecraft:ladder)
66 	
	Rail
(minecraft:rail)
67 	
	Cobblestone Stairs
(minecraft:stone_stairs)
68 	
	Wall-mounted Sign Block
(minecraft:wall_sign)
69 	
	Lever
(minecraft:lever)
70 	
	Stone Pressure Plate
(minecraft:stone_pressure_plate)
71 	
	Iron Door Block
(minecraft:iron_door)
72 	
	Wooden Pressure Plate
(minecraft:wooden_pressure_plate)
73 	
	Redstone Ore
(minecraft:redstone_ore)
74 	
	Glowing Redstone Ore
(minecraft:lit_redstone_ore)
75 	
	Redstone Torch (off)
(minecraft:unlit_redstone_torch)
76 	
	Redstone Torch (on)
(minecraft:redstone_torch)
77 	
	Stone Button
(minecraft:stone_button)
78 	
	Snow
(minecraft:snow_layer)
79 	
	Ice
(minecraft:ice)
80 	
	Snow Block
(minecraft:snow)
81 	
	Cactus
(minecraft:cactus)
82 	
	Clay
(minecraft:clay)
83 	
	Sugar Canes
(minecraft:reeds)
84 	
	Jukebox
(minecraft:jukebox)
85 	
	Oak Fence
(minecraft:fence)
86 	
	Pumpkin
(minecraft:pumpkin)
87 	
	Netherrack
(minecraft:netherrack)
88 	
	Soul Sand
(minecraft:soul_sand)
89 	
	Glowstone
(minecraft:glowstone)
90 	
	Nether Portal
(minecraft:portal)
91 	
	Jack o'Lantern
(minecraft:lit_pumpkin)
92 	
	Cake Block
(minecraft:cake)
93 	
	Redstone Repeater Block (off)
(minecraft:unpowered_repeater)
94 	
	Redstone Repeater Block (on)
(minecraft:powered_repeater)
95 	
	White Stained Glass
(minecraft:stained_glass)
95:1 	
	Orange Stained Glass
(minecraft:stained_glass)
95:2 	
	Magenta Stained Glass
(minecraft:stained_glass)
95:3 	
	Light Blue Stained Glass
(minecraft:stained_glass)
95:4 	
	Yellow Stained Glass
(minecraft:stained_glass)
95:5 	
	Lime Stained Glass
(minecraft:stained_glass)
95:6 	
	Pink Stained Glass
(minecraft:stained_glass)
95:7 	
	Gray Stained Glass
(minecraft:stained_glass)
95:8 	
	Light Gray Stained Glass
(minecraft:stained_glass)
95:9 	
	Cyan Stained Glass
(minecraft:stained_glass)
95:10 	
	Purple Stained Glass
(minecraft:stained_glass)
95:11 	
	Blue Stained Glass
(minecraft:stained_glass)
95:12 	
	Brown Stained Glass
(minecraft:stained_glass)
95:13 	
	Green Stained Glass
(minecraft:stained_glass)
95:14 	
	Red Stained Glass
(minecraft:stained_glass)
95:15 	
	Black Stained Glass
(minecraft:stained_glass)
96 	
	Wooden Trapdoor
(minecraft:trapdoor)
97 	
	Stone Monster Egg
(minecraft:monster_egg)
97:1 	
	Cobblestone Monster Egg
(minecraft:monster_egg)
97:2 	
	Stone Brick Monster Egg
(minecraft:monster_egg)
97:3 	
	Mossy Stone Brick Monster Egg
(minecraft:monster_egg)
97:4 	
	Cracked Stone Brick Monster Egg
(minecraft:monster_egg)
97:5 	
	Chiseled Stone Brick Monster Egg
(minecraft:monster_egg)
98 	
	Stone Bricks
(minecraft:stonebrick)
98:1 	
	Mossy Stone Bricks
(minecraft:stonebrick)
98:2 	
	Cracked Stone Bricks
(minecraft:stonebrick)
98:3 	
	Chiseled Stone Bricks
(minecraft:stonebrick)
99 	
	Brown Mushroom Block
(minecraft:brown_mushroom_block)
100 	
	Red Mushroom Block
(minecraft:red_mushroom_block)
101 	
	Iron Bars
(minecraft:iron_bars)
102 	
	Glass Pane
(minecraft:glass_pane)
103 	
	Melon Block
(minecraft:melon_block)
104 	
	Pumpkin Stem
(minecraft:pumpkin_stem)
105 	
	Melon Stem
(minecraft:melon_stem)
106 	
	Vines
(minecraft:vine)
107 	
	Oak Fence Gate
(minecraft:fence_gate)
108 	
	Brick Stairs
(minecraft:brick_stairs)
109 	
	Stone Brick Stairs
(minecraft:stone_brick_stairs)
110 	
	Mycelium
(minecraft:mycelium)
111 	
	Lily Pad
(minecraft:waterlily)
112 	
	Nether Brick
(minecraft:nether_brick)
113 	
	Nether Brick Fence
(minecraft:nether_brick_fence)
114 	
	Nether Brick Stairs
(minecraft:nether_brick_stairs)
115 	
	Nether Wart
(minecraft:nether_wart)
116 	
	Enchantment Table
(minecraft:enchanting_table)
117 	
	Brewing Stand
(minecraft:brewing_stand)
118 	
	Cauldron
(minecraft:cauldron)
119 	
	End Portal
(minecraft:end_portal)
120 	
	End Portal Frame
(minecraft:end_portal_frame)
121 	
	End Stone
(minecraft:end_stone)
122 	
	Dragon Egg
(minecraft:dragon_egg)
123 	
	Redstone Lamp (inactive)
(minecraft:redstone_lamp)
124 	
	Redstone Lamp (active)
(minecraft:lit_redstone_lamp)
125 	
	Double Oak Wood Slab
(minecraft:double_wooden_slab)
125:1 	
	Double Spruce Wood Slab
(minecraft:double_wooden_slab)
125:2 	
	Double Birch Wood Slab
(minecraft:double_wooden_slab)
125:3 	
	Double Jungle Wood Slab
(minecraft:double_wooden_slab)
125:4 	
	Double Acacia Wood Slab
(minecraft:double_wooden_slab)
125:5 	
	Double Dark Oak Wood Slab
(minecraft:double_wooden_slab)
126 	
	Oak Wood Slab
(minecraft:wooden_slab)
126:1 	
	Spruce Wood Slab
(minecraft:wooden_slab)
126:2 	
	Birch Wood Slab
(minecraft:wooden_slab)
126:3 	
	Jungle Wood Slab
(minecraft:wooden_slab)
126:4 	
	Acacia Wood Slab
(minecraft:wooden_slab)
126:5 	
	Dark Oak Wood Slab
(minecraft:wooden_slab)
127 	
	Cocoa
(minecraft:cocoa)
128 	
	Sandstone Stairs
(minecraft:sandstone_stairs)
129 	
	Emerald Ore
(minecraft:emerald_ore)
130 	
	Ender Chest
(minecraft:ender_chest)
131 	
	Tripwire Hook
(minecraft:tripwire_hook)
132 	
	Tripwire
(minecraft:tripwire_hook)
133 	
	Emerald Block
(minecraft:emerald_block)
134 	
	Spruce Wood Stairs
(minecraft:spruce_stairs)
135 	
	Birch Wood Stairs
(minecraft:birch_stairs)
136 	
	Jungle Wood Stairs
(minecraft:jungle_stairs)
137 	
	Command Block
(minecraft:command_block)
138 	
	Beacon
(minecraft:beacon)
139 	
	Cobblestone Wall
(minecraft:cobblestone_wall)
139:1 	
	Mossy Cobblestone Wall
(minecraft:cobblestone_wall)
140 	
	Flower Pot
(minecraft:flower_pot)
141 	
	Carrots
(minecraft:carrots)
142 	
	Potatoes
(minecraft:potatoes)
143 	
	Wooden Button
(minecraft:wooden_button)
144 	
	Mob Head
(minecraft:skull)
145 	
	Anvil
(minecraft:anvil)
146 	
	Trapped Chest
(minecraft:trapped_chest)
147 	
	Weighted Pressure Plate (light)
(minecraft:light_weighted_pressure_plate)
148 	
	Weighted Pressure Plate (heavy)
(minecraft:heavy_weighted_pressure_plate)
149 	
	Redstone Comparator (inactive)
(minecraft:unpowered_comparator)
150 	
	Redstone Comparator (active)
(minecraft:powered_comparator)
151 	
	Daylight Sensor
(minecraft:daylight_detector)
152 	
	Redstone Block
(minecraft:redstone_block)
153 	
	Nether Quartz Ore
(minecraft:quartz_ore)
154 	
	Hopper
(minecraft:hopper)
155 	
	Quartz Block
(minecraft:quartz_block)
155:1 	
	Chiseled Quartz Block
(minecraft:quartz_block)
155:2 	
	Pillar Quartz Block
(minecraft:quartz_block)
156 	
	Quartz Stairs
(minecraft:quartz_stairs)
157 	
	Activator Rail
(minecraft:activator_rail)
158 	
	Dropper
(minecraft:dropper)
159 	
	White Stained Clay
(minecraft:stained_hardened_clay)
159:1 	
	Orange Stained Clay
(minecraft:stained_hardened_clay)
159:2 	
	Magenta Stained Clay
(minecraft:stained_hardened_clay)
159:3 	
	Light Blue Stained Clay
(minecraft:stained_hardened_clay)
159:4 	
	Yellow Stained Clay
(minecraft:stained_hardened_clay)
159:5 	
	Lime Stained Clay
(minecraft:stained_hardened_clay)
159:6 	
	Pink Stained Clay
(minecraft:stained_hardened_clay)
159:7 	
	Gray Stained Clay
(minecraft:stained_hardened_clay)
159:8 	
	Light Gray Stained Clay
(minecraft:stained_hardened_clay)
159:9 	
	Cyan Stained Clay
(minecraft:stained_hardened_clay)
159:10 	
	Purple Stained Clay
(minecraft:stained_hardened_clay)
159:11 	
	Blue Stained Clay
(minecraft:stained_hardened_clay)
159:12 	
	Brown Stained Clay
(minecraft:stained_hardened_clay)
159:13 	
	Green Stained Clay
(minecraft:stained_hardened_clay)
159:14 	
	Red Stained Clay
(minecraft:stained_hardened_clay)
159:15 	
	Black Stained Clay
(minecraft:stained_hardened_clay)
160 	
	White Stained Glass Pane
(minecraft:stained_glass_pane)
160:1 	
	Orange Stained Glass Pane
(minecraft:stained_glass_pane)
160:2 	
	Magenta Stained Glass Pane
(minecraft:stained_glass_pane)
160:3 	
	Light Blue Stained Glass Pane
(minecraft:stained_glass_pane)
160:4 	
	Yellow Stained Glass Pane
(minecraft:stained_glass_pane)
160:5 	
	Lime Stained Glass Pane
(minecraft:stained_glass_pane)
160:6 	
	Pink Stained Glass Pane
(minecraft:stained_glass_pane)
160:7 	
	Gray Stained Glass Pane
(minecraft:stained_glass_pane)
160:8 	
	Light Gray Stained Glass Pane
(minecraft:stained_glass_pane)
160:9 	
	Cyan Stained Glass Pane
(minecraft:stained_glass_pane)
160:10 	
	Purple Stained Glass Pane
(minecraft:stained_glass_pane)
160:11 	
	Blue Stained Glass Pane
(minecraft:stained_glass_pane)
160:12 	
	Brown Stained Glass Pane
(minecraft:stained_glass_pane)
160:13 	
	Green Stained Glass Pane
(minecraft:stained_glass_pane)
160:14 	
	Red Stained Glass Pane
(minecraft:stained_glass_pane)
160:15 	
	Black Stained Glass Pane
(minecraft:stained_glass_pane)
161 	
	Acacia Leaves
(minecraft:leaves2)
161:1 	
	Dark Oak Leaves
(minecraft:leaves2)
162 	
	Acacia Wood
(minecraft:log2)
162:1 	
	Dark Oak Wood
(minecraft:log2)
163 	
	Acacia Wood Stairs
(minecraft:acacia_stairs)
164 	
	Dark Oak Wood Stairs
(minecraft:dark_oak_stairs)
165 	
	Slime Block
(minecraft:slime)
166 	
	Barrier
(minecraft:barrier)
167 	
	Iron Trapdoor
(minecraft:iron_trapdoor)
168 	
	Prismarine
(minecraft:prismarine)
168:1 	
	Prismarine Bricks
(minecraft:prismarine)
168:2 	
	Dark Prismarine
(minecraft:prismarine)
169 	
	Sea Lantern
(minecraft:sea_lantern)
170 	
	Hay Bale
(minecraft:hay_block)
171 	
	White Carpet
(minecraft:carpet)
171:1 	
	Orange Carpet
(minecraft:carpet)
171:2 	
	Magenta Carpet
(minecraft:carpet)
171:3 	
	Light Blue Carpet
(minecraft:carpet)
171:4 	
	Yellow Carpet
(minecraft:carpet)
171:5 	
	Lime Carpet
(minecraft:carpet)
171:6 	
	Pink Carpet
(minecraft:carpet)
171:7 	
	Gray Carpet
(minecraft:carpet)
171:8 	
	Light Gray Carpet
(minecraft:carpet)
171:9 	
	Cyan Carpet
(minecraft:carpet)
171:10 	
	Purple Carpet
(minecraft:carpet)
171:11 	
	Blue Carpet
(minecraft:carpet)
171:12 	
	Brown Carpet
(minecraft:carpet)
171:13 	
	Green Carpet
(minecraft:carpet)
171:14 	
	Red Carpet
(minecraft:carpet)
171:15 	
	Black Carpet
(minecraft:carpet)
172 	
	Hardened Clay
(minecraft:hardened_clay)
173 	
	Block of Coal
(minecraft:coal_block)
174 	
	Packed Ice
(minecraft:packed_ice)
175 	
	Sunflower
(minecraft:double_plant)
175:1 	
	Lilac
(minecraft:double_plant)
175:2 	
	Double Tallgrass
(minecraft:double_plant)
175:3 	
	Large Fern
(minecraft:double_plant)
175:4 	
	Rose Bush
(minecraft:double_plant)
175:5 	
	Peony
(minecraft:double_plant)
176 	
	Free-standing Banner
(minecraft:standing_banner)
177 	
	Wall-mounted Banner
(minecraft:wall_banner)
178 	
	Inverted Daylight Sensor
(minecraft:daylight_detector_inverted)
179 	
	Red Sandstone
(minecraft:red_sandstone)
179:1 	
	Chiseled Red Sandstone
(minecraft:red_sandstone)
179:2 	
	Smooth Red Sandstone
(minecraft:red_sandstone)
180 	
	Red Sandstone Stairs
(minecraft:red_sandstone_stairs)
181 	
	Double Red Sandstone Slab
(minecraft:stone_slab2)
182 	
	Red Sandstone Slab
(minecraft:double_stone_slab2)
183 	
	Spruce Fence Gate
(minecraft:spruce_fence_gate)
184 	
	Birch Fence Gate
(minecraft:birch_fence_gate)
185 	
	Jungle Fence Gate
(minecraft:jungle_fence_gate)
186 	
	Dark Oak Fence Gate
(minecraft:dark_oak_fence_gate)
187 	
	Acacia Fence Gate
(minecraft:acacia_fence_gate)
188 	
	Spruce Fence
(minecraft:spruce_fence)
189 	
	Birch Fence
(minecraft:birch_fence)
190 	
	Jungle Fence
(minecraft:jungle_fence)
191 	
	Dark Oak Fence
(minecraft:dark_oak_fence)
192 	
	Acacia Fence
(minecraft:acacia_fence)
193 	
	Spruce Door Block
(minecraft:spruce_door)
194 	
	Birch Door Block
(minecraft:birch_door)
195 	
	Jungle Door Block
(minecraft:jungle_door)
196 	
	Acacia Door Block
(minecraft:acacia_door)
197 	
	Dark Oak Door Block
(minecraft:dark_oak_door)
256 	
	Iron Shovel
(minecraft:iron_shovel)
257 	
	Iron Pickaxe
(minecraft:iron_pickaxe)
258 	
	Iron Axe
(minecraft:iron_axe)
259 	
	Flint and Steel
(minecraft:flint_and_steel)
260 	
	Apple
(minecraft:apple)
261 	
	Bow
(minecraft:bow)
262 	
	Arrow
(minecraft:arrow)
263 	
	Coal
(minecraft:coal)
263:1 	
	Charcoal
(minecraft:coal)
264 	
	Diamond
(minecraft:diamond)
265 	
	Iron Ingot
(minecraft:iron_ingot)
266 	
	Gold Ingot
(minecraft:gold_ingot)
267 	
	Iron Sword
(minecraft:iron_sword)
268 	
	Wooden Sword
(minecraft:wooden_sword)
269 	
	Wooden Shovel
(minecraft:wooden_shovel)
270 	
	Wooden Pickaxe
(minecraft:wooden_pickaxe)
271 	
	Wooden Axe
(minecraft:wooden_axe)
272 	
	Stone Sword
(minecraft:stone_sword)
273 	
	Stone Shovel
(minecraft:stone_shovel)
274 	
	Stone Pickaxe
(minecraft:stone_pickaxe)
275 	
	Stone Axe
(minecraft:stone_axe)
276 	
	Diamond Sword
(minecraft:diamond_sword)
277 	
	Diamond Shovel
(minecraft:diamond_shovel)
278 	
	Diamond Pickaxe
(minecraft:diamond_pickaxe)
279 	
	Diamond Axe
(minecraft:diamond_axe)
280 	
	Stick
(minecraft:stick)
281 	
	Bowl
(minecraft:bowl)
282 	
	Mushroom Stew
(minecraft:mushroom_stew)
283 	
	Golden Sword
(minecraft:golden_sword)
284 	
	Golden Shovel
(minecraft:golden_shovel)
285 	
	Golden Pickaxe
(minecraft:golden_pickaxe)
286 	
	Golden Axe
(minecraft:golden_axe)
287 	
	String
(minecraft:string)
288 	
	Feather
(minecraft:feather)
289 	
	Gunpowder
(minecraft:gunpowder)
290 	
	Wooden Hoe
(minecraft:wooden_hoe)
291 	
	Stone Hoe
(minecraft:stone_hoe)
292 	
	Iron Hoe
(minecraft:iron_hoe)
293 	
	Diamond Hoe
(minecraft:diamond_hoe)
294 	
	Golden Hoe
(minecraft:golden_hoe)
295 	
	Wheat Seeds
(minecraft:wheat_seeds)
296 	
	Wheat
(minecraft:wheat)
297 	
	Bread
(minecraft:bread)
298 	
	Leather Helmet
(minecraft:leather_helmet)
299 	
	Leather Tunic
(minecraft:leather_chestplate)
300 	
	Leather Pants
(minecraft:leather_leggings)
301 	
	Leather Boots
(minecraft:leather_boots)
302 	
	Chainmail Helmet
(minecraft:chainmail_helmet)
303 	
	Chainmail Chestplate
(minecraft:chainmail_chestplate)
304 	
	Chainmail Leggings
(minecraft:chainmail_leggings)
305 	
	Chainmail Boots
(minecraft:chainmail_boots)
306 	
	Iron Helmet
(minecraft:iron_helmet)
307 	
	Iron Chestplate
(minecraft:iron_chestplate)
308 	
	Iron Leggings
(minecraft:iron_leggings)
309 	
	Iron Boots
(minecraft:iron_boots)
310 	
	Diamond Helmet
(minecraft:diamond_helmet)
311 	
	Diamond Chestplate
(minecraft:diamond_chestplate)
312 	
	Diamond Leggings
(minecraft:diamond_leggings)
313 	
	Diamond Boots
(minecraft:diamond_boots)
314 	
	Golden Helmet
(minecraft:golden_helmet)
315 	
	Golden Chestplate
(minecraft:golden_chestplate)
316 	
	Golden Leggings
(minecraft:golden_leggings)
317 	
	Golden Boots
(minecraft:golden_boots)
318 	
	Flint
(minecraft:flint)
319 	
	Raw Porkchop
(minecraft:porkchop)
320 	
	Cooked Porkchop
(minecraft:cooked_porkchop)
321 	
	Painting
(minecraft:painting)
322 	
	Golden Apple
(minecraft:golden_apple)
322:1 	
	Enchanted Golden Apple
(minecraft:golden_apple)
323 	
	Sign
(minecraft:sign)
324 	
	Oak Door
(minecraft:wooden_door)
325 	
	Bucket
(minecraft:bucket)
326 	
	Water Bucket
(minecraft:water_bucket)
327 	
	Lava Bucket
(minecraft:lava_bucket)
328 	
	Minecart
(minecraft:minecart)
329 	
	Saddle
(minecraft:saddle)
330 	
	Iron Door
(minecraft:iron_door)
331 	
	Redstone
(minecraft:redstone)
332 	
	Snowball
(minecraft:snowball)
333 	
	Boat
(minecraft:boat)
334 	
	Leather
(minecraft:leather)
335 	
	Milk Bucket
(minecraft:milk_bucket)
336 	
	Brick
(minecraft:brick)
337 	
	Clay
(minecraft:clay_ball)
338 	
	Sugar Canes
(minecraft:reeds)
339 	
	Paper
(minecraft:paper)
340 	
	Book
(minecraft:book)
341 	
	Slimeball
(minecraft:slime_ball)
342 	
	Minecart with Chest
(minecraft:chest_minecart)
343 	
	Minecart with Furnace
(minecraft:furnace_minecart)
344 	
	Egg
(minecraft:egg)
345 	
	Compass
(minecraft:compass)
346 	
	Fishing Rod
(minecraft:fishing_rod)
347 	
	Clock
(minecraft:clock)
348 	
	Glowstone Dust
(minecraft:glowstone_dust)
349 	
	Raw Fish
(minecraft:fish)
349:1 	
	Raw Salmon
(minecraft:fish)
349:2 	
	Clownfish
(minecraft:fish)
349:3 	
	Pufferfish
(minecraft:fish)
350 	
	Cooked Fish
(minecraft:cooked_fish)
350:1 	
	Cooked Salmon
(minecraft:cooked_fish)
351 	
	Ink Sack
(minecraft:dye)
351:1 	
	Rose Red
(minecraft:dye)
351:2 	
	Cactus Green
(minecraft:dye)
351:3 	
	Coco Beans
(minecraft:dye)
351:4 	
	Lapis Lazuli
(minecraft:dye)
351:5 	
	Purple Dye
(minecraft:dye)
351:6 	
	Cyan Dye
(minecraft:dye)
351:7 	
	Light Gray Dye
(minecraft:dye)
351:8 	
	Gray Dye
(minecraft:dye)
351:9 	
	Pink Dye
(minecraft:dye)
351:10 	
	Lime Dye
(minecraft:dye)
351:11 	
	Dandelion Yellow
(minecraft:dye)
351:12 	
	Light Blue Dye
(minecraft:dye)
351:13 	
	Magenta Dye
(minecraft:dye)
351:14 	
	Orange Dye
(minecraft:dye)
351:15 	
	Bone Meal
(minecraft:dye)
352 	
	Bone
(minecraft:bone)
353 	
	Sugar
(minecraft:sugar)
354 	
	Cake
(minecraft:cake)
355 	
	Bed
(minecraft:bed)
356 	
	Redstone Repeater
(minecraft:repeater)
357 	
	Cookie
(minecraft:cookie)
358 	
	Map
(minecraft:filled_map)
359 	
	Shears
(minecraft:shears)
360 	
	Melon
(minecraft:melon)
361 	
	Pumpkin Seeds
(minecraft:pumpkin_seeds)
362 	
	Melon Seeds
(minecraft:melon_seeds)
363 	
	Raw Beef
(minecraft:beef)
364 	
	Steak
(minecraft:cooked_beef)
365 	
	Raw Chicken
(minecraft:chicken)
366 	
	Cooked Chicken
(minecraft:cooked_chicken)
367 	
	Rotten Flesh
(minecraft:rotten_flesh)
368 	
	Ender Pearl
(minecraft:ender_pearl)
369 	
	Blaze Rod
(minecraft:blaze_rod)
370 	
	Ghast Tear
(minecraft:ghast_tear)
371 	
	Gold Nugget
(minecraft:gold_nugget)
372 	
	Nether Wart
(minecraft:nether_wart)
373 	
	Potion
(minecraft:potion)
374 	
	Glass Bottle
(minecraft:glass_bottle)
375 	
	Spider Eye
(minecraft:spider_eye)
376 	
	Fermented Spider Eye
(minecraft:fermented_spider_eye)
377 	
	Blaze Powder
(minecraft:blaze_powder)
378 	
	Magma Cream
(minecraft:magma_cream)
379 	
	Brewing Stand
(minecraft:brewing_stand)
380 	
	Cauldron
(minecraft:cauldron)
381 	
	Eye of Ender
(minecraft:ender_eye)
382 	
	Glistering Melon
(minecraft:speckled_melon)
383:50 	
	Spawn Creeper
(minecraft:spawn_egg)
383:51 	
	Spawn Skeleton
(minecraft:spawn_egg)
383:52 	
	Spawn Spider
(minecraft:spawn_egg)
383:54 	
	Spawn Zombie
(minecraft:spawn_egg)
383:55 	
	Spawn Slime
(minecraft:spawn_egg)
383:56 	
	Spawn Ghast
(minecraft:spawn_egg)
383:57 	
	Spawn Pigman
(minecraft:spawn_egg)
383:58 	
	Spawn Enderman
(minecraft:spawn_egg)
383:59 	
	Spawn Cave Spider
(minecraft:spawn_egg)
383:60 	
	Spawn Silverfish
(minecraft:spawn_egg)
383:61 	
	Spawn Blaze
(minecraft:spawn_egg)
383:62 	
	Spawn Magma Cube
(minecraft:spawn_egg)
383:65 	
	Spawn Bat
(minecraft:spawn_egg)
383:66 	
	Spawn Witch
(minecraft:spawn_egg)
383:67 	
	Spawn Endermite
(minecraft:spawn_egg)
383:68 	
	Spawn Guardian
(minecraft:spawn_egg)
383:90 	
	Spawn Pig
(minecraft:spawn_egg)
383:91 	
	Spawn Sheep
(minecraft:spawn_egg)
383:92 	
	Spawn Cow
(minecraft:spawn_egg)
383:93 	
	Spawn Chicken
(minecraft:spawn_egg)
383:94 	
	Spawn Squid
(minecraft:spawn_egg)
383:95 	
	Spawn Wolf
(minecraft:spawn_egg)
383:96 	
	Spawn Mooshroom
(minecraft:spawn_egg)
383:98 	
	Spawn Ocelot
(minecraft:spawn_egg)
383:100 	
	Spawn Horse
(minecraft:spawn_egg)
383:101 	
	Spawn Rabbit
(minecraft:spawn_egg)
383:120 	
	Spawn Villager
(minecraft:spawn_egg)
384 	
	Bottle o' Enchanting
(minecraft:experience_bottle)
385 	
	Fire Charge
(minecraft:fire_charge)
386 	
	Book and Quill
(minecraft:writable_book)
387 	
	Written Book
(minecraft:written_book)
388 	
	Emerald
(minecraft:emerald)
389 	
	Item Frame
(minecraft:item_frame)
390 	
	Flower Pot
(minecraft:flower_pot)
391 	
	Carrot
(minecraft:carrot)
392 	
	Potato
(minecraft:potato)
393 	
	Baked Potato
(minecraft:baked_potato)
394 	
	Poisonous Potato
(minecraft:poisonous_potato)
395 	
	Empty Map
(minecraft:map)
396 	
	Golden Carrot
(minecraft:golden_carrot)
397 	
	Mob Head (Skeleton)
(minecraft:skull)
397:1 	
	Mob Head (Wither Skeleton)
(minecraft:skull)
397:2 	
	Mob Head (Zombie)
(minecraft:skull)
397:3 	
	Mob Head (Human)
(minecraft:skull)
397:4 	
	Mob Head (Creeper)
(minecraft:skull)
398 	
	Carrot on a Stick
(minecraft:carrot_on_a_stick)
399 	
	Nether Star
(minecraft:nether_star)
400 	
	Pumpkin Pie
(minecraft:pumpkin_pie)
401 	
	Firework Rocket
(minecraft:fireworks)
402 	
	Firework Star
(minecraft:firework_charge)
403 	
	Enchanted Book
(minecraft:enchanted_book)
404 	
	Redstone Comparator
(minecraft:comparator)
405 	
	Nether Brick
(minecraft:netherbrick)
406 	
	Nether Quartz
(minecraft:quartz)
407 	
	Minecart with TNT
(minecraft:tnt_minecart)
408 	
	Minecart with Hopper
(minecraft:hopper_minecart)
409 	
	Prismarine Shard
(minecraft:prismarine_shard)
410 	
	Prismarine Crystals
(minecraft:prismarine_crystals)
411 	
	Raw Rabbit
(minecraft:rabbit)
412 	
	Cooked Rabbit
(minecraft:cooked_rabbit)
413 	
	Rabbit Stew
(minecraft:rabbit_stew)
414 	
	Rabbit's Foot
(minecraft:rabbit_foot)
415 	
	Rabbit Hide
(minecraft:rabbit_hide)
416 	
	Armor Stand
(minecraft:armor_stand)
417 	
	Iron Horse Armor
(minecraft:iron_horse_armor)
418 	
	Golden Horse Armor
(minecraft:golden_horse_armor)
419 	
	Diamond Horse Armor
(minecraft:diamond_horse_armor)
420 	
	Lead
(minecraft:lead)
421 	
	Name Tag
(minecraft:name_tag)
422 	
	Minecart with Command Block
(minecraft:command_block_minecart)
423 	
	Raw Mutton
(minecraft:mutton)
424 	
	Cooked Mutton
(minecraft:cooked_mutton)
425 	
	Banner
(minecraft:banner)
427 	
	Spruce Door
(minecraft:spruce_door)
428 	
	Birch Door
(minecraft:birch_door)
429 	
	Jungle Door
(minecraft:jungle_door)
430 	
	Acacia Door
(minecraft:acacia_door)
431 	
	Dark Oak Door
(minecraft:dark_oak_door)
2256 	
	13 Disc
(minecraft:record_13)
2257 	
	Cat Disc
(minecraft:record_cat)
2258 	
	Blocks Disc
(minecraft:record_blocks)
2259 	
	Chirp Disc
(minecraft:record_chirp)
2260 	
	Far Disc
(minecraft:record_far)
2261 	
	Mall Disc
(minecraft:record_mall)
2262 	
	Mellohi Disc
(minecraft:record_mellohi)
2263 	
	Stal Disc
(minecraft:record_stal)
2264 	
	Strad Disc
(minecraft:record_strad)
2265 	
	Ward Disc
(minecraft:record_ward)
2266 	
	11 Disc
(minecraft:record_11)
2267 	
	Wait Disc
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
        Settings.Show()
    End Sub
    Public Sub DisplayError(ByVal Exception As Exception)
        MsgBox(Exception.ToString, MsgBoxStyle.Critical)
    End Sub

    Private Sub Main_Load(sender As Object, e As EventArgs) Handles Me.Load
        Settings.MemoryMaximumUnit.SelectedItem = "M"
        Settings.MemoryMinimumUnit.SelectedItem = "M"
    End Sub
End Class