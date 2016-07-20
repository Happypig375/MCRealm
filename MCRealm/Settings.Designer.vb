<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Settings
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.ButtonLayoutPanel = New System.Windows.Forms.TableLayoutPanel()
        Me.Cancel_Button = New System.Windows.Forms.Button()
        Me.OK_Button = New System.Windows.Forms.Button()
        Me.Apply_Button = New System.Windows.Forms.Button()
        Me.World = New System.Windows.Forms.GroupBox()
        Me.MaximumWorldSizeCalculation = New System.Windows.Forms.Label()
        Me.SpawnProtectionCalculation = New System.Windows.Forms.Label()
        Me.SpawnProtection = New System.Windows.Forms.NumericUpDown()
        Me.SpawnProtectionLabel = New System.Windows.Forms.Label()
        Me.Difficulty = New System.Windows.Forms.ComboBox()
        Me.DifficultyLabel = New System.Windows.Forms.Label()
        Me.SpawnVillagers = New System.Windows.Forms.CheckBox()
        Me.SpawnMonsters = New System.Windows.Forms.CheckBox()
        Me.SpawnAnimals = New System.Windows.Forms.CheckBox()
        Me.OPPermissionLevel = New System.Windows.Forms.NumericUpDown()
        Me.OPPermissionLevelLabel = New System.Windows.Forms.Label()
        Me.MaximumWorldSize = New System.Windows.Forms.NumericUpDown()
        Me.MaximumWorldSizeLabel = New System.Windows.Forms.Label()
        Me.MaximumBuildHeight = New System.Windows.Forms.NumericUpDown()
        Me.MaximumBuildHeightLabel = New System.Windows.Forms.Label()
        Me.Hardcore = New System.Windows.Forms.CheckBox()
        Me.GenerateStructures = New System.Windows.Forms.CheckBox()
        Me.EnableCommandBlocks = New System.Windows.Forms.CheckBox()
        Me.AllowNether = New System.Windows.Forms.CheckBox()
        Me.Players = New System.Windows.Forms.GroupBox()
        Me.UseWhiteList = New System.Windows.Forms.CheckBox()
        Me.DefaultGamemode = New System.Windows.Forms.ComboBox()
        Me.DefaultGamemodeLabel = New System.Windows.Forms.Label()
        Me.ForceDefaultGamemode = New System.Windows.Forms.CheckBox()
        Me.AllowFlight = New System.Windows.Forms.CheckBox()
        Me.ViewDistance = New System.Windows.Forms.NumericUpDown()
        Me.BroadcastConsoleToOPs = New System.Windows.Forms.CheckBox()
        Me.AnnouncePlayerAchievements = New System.Windows.Forms.CheckBox()
        Me.PVP = New System.Windows.Forms.CheckBox()
        Me.PlayerIdleTimeout = New System.Windows.Forms.NumericUpDown()
        Me.MaximumPlayersLabel = New System.Windows.Forms.Label()
        Me.PlayerIdleTimeoutLabel = New System.Windows.Forms.Label()
        Me.ViewDistanceLabel = New System.Windows.Forms.Label()
        Me.PlayerIdleTimeoutCheckBox = New System.Windows.Forms.CheckBox()
        Me.MaximumPlayers = New System.Windows.Forms.NumericUpDown()
        Me.Connection = New System.Windows.Forms.GroupBox()
        Me.LoadWorldLabel = New System.Windows.Forms.Label()
        Me.LoadWorld = New System.Windows.Forms.DomainUpDown()
        Me.EnableSnooper = New System.Windows.Forms.CheckBox()
        Me.IP = New System.Windows.Forms.TextBox()
        Me.IPLabel = New System.Windows.Forms.Label()
        Me.NetworkCompressionThresholdUnit = New System.Windows.Forms.Label()
        Me.ServerPort = New System.Windows.Forms.NumericUpDown()
        Me.ServerPortLabel = New System.Windows.Forms.Label()
        Me.RemoteConnectionPasswordButton = New System.Windows.Forms.Button()
        Me.RemoteConnectionPassword = New System.Windows.Forms.TextBox()
        Me.RemoteConnectionLabel = New System.Windows.Forms.Label()
        Me.RemoteConnectionPort = New System.Windows.Forms.NumericUpDown()
        Me.QueryPort = New System.Windows.Forms.NumericUpDown()
        Me.OnlineMode = New System.Windows.Forms.CheckBox()
        Me.NetworkCompressionThreshold = New System.Windows.Forms.NumericUpDown()
        Me.NetworkCompressionThresholdLabel = New System.Windows.Forms.Label()
        Me.MessageOfTheDay = New System.Windows.Forms.TextBox()
        Me.MessageOfTheDayLabel = New System.Windows.Forms.Label()
        Me.EnableRemoteConnection = New System.Windows.Forms.CheckBox()
        Me.EnableQuery = New System.Windows.Forms.CheckBox()
        Me.Debug = New System.Windows.Forms.CheckBox()
        Me.MaximumTickTime = New System.Windows.Forms.NumericUpDown()
        Me.MaximumTickTimeLabel = New System.Windows.Forms.Label()
        Me.ResetToDefault = New System.Windows.Forms.Button()
        Me.SnooperHelp = New System.Windows.Forms.Button()
        Me.ButtonLayoutPanel.SuspendLayout()
        Me.World.SuspendLayout()
        CType(Me.SpawnProtection, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.OPPermissionLevel, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MaximumWorldSize, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MaximumBuildHeight, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Players.SuspendLayout()
        CType(Me.ViewDistance, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PlayerIdleTimeout, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MaximumPlayers, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Connection.SuspendLayout()
        CType(Me.ServerPort, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RemoteConnectionPort, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.QueryPort, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NetworkCompressionThreshold, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MaximumTickTime, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ButtonLayoutPanel
        '
        Me.ButtonLayoutPanel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonLayoutPanel.ColumnCount = 3
        Me.ButtonLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33323!))
        Me.ButtonLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33323!))
        Me.ButtonLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33353!))
        Me.ButtonLayoutPanel.Controls.Add(Me.Cancel_Button, 0, 0)
        Me.ButtonLayoutPanel.Controls.Add(Me.OK_Button, 0, 0)
        Me.ButtonLayoutPanel.Controls.Add(Me.Apply_Button, 1, 0)
        Me.ButtonLayoutPanel.Location = New System.Drawing.Point(204, 500)
        Me.ButtonLayoutPanel.Name = "ButtonLayoutPanel"
        Me.ButtonLayoutPanel.RowCount = 1
        Me.ButtonLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.ButtonLayoutPanel.Size = New System.Drawing.Size(219, 29)
        Me.ButtonLayoutPanel.TabIndex = 0
        '
        'Cancel_Button
        '
        Me.Cancel_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel_Button.Location = New System.Drawing.Point(75, 3)
        Me.Cancel_Button.Name = "Cancel_Button"
        Me.Cancel_Button.Size = New System.Drawing.Size(66, 23)
        Me.Cancel_Button.TabIndex = 2
        Me.Cancel_Button.Text = "Cancel"
        '
        'OK_Button
        '
        Me.OK_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.OK_Button.Location = New System.Drawing.Point(3, 3)
        Me.OK_Button.Name = "OK_Button"
        Me.OK_Button.Size = New System.Drawing.Size(66, 23)
        Me.OK_Button.TabIndex = 0
        Me.OK_Button.Text = "OK"
        '
        'Apply_Button
        '
        Me.Apply_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Apply_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Apply_Button.Location = New System.Drawing.Point(148, 3)
        Me.Apply_Button.Name = "Apply_Button"
        Me.Apply_Button.Size = New System.Drawing.Size(67, 23)
        Me.Apply_Button.TabIndex = 1
        Me.Apply_Button.Text = "Apply"
        '
        'World
        '
        Me.World.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.World.Controls.Add(Me.LoadWorldLabel)
        Me.World.Controls.Add(Me.LoadWorld)
        Me.World.Controls.Add(Me.MaximumWorldSizeCalculation)
        Me.World.Controls.Add(Me.SpawnProtectionCalculation)
        Me.World.Controls.Add(Me.Players)
        Me.World.Controls.Add(Me.SpawnProtection)
        Me.World.Controls.Add(Me.SpawnProtectionLabel)
        Me.World.Controls.Add(Me.Difficulty)
        Me.World.Controls.Add(Me.DifficultyLabel)
        Me.World.Controls.Add(Me.SpawnVillagers)
        Me.World.Controls.Add(Me.SpawnMonsters)
        Me.World.Controls.Add(Me.SpawnAnimals)
        Me.World.Controls.Add(Me.OPPermissionLevel)
        Me.World.Controls.Add(Me.OPPermissionLevelLabel)
        Me.World.Controls.Add(Me.MaximumWorldSize)
        Me.World.Controls.Add(Me.MaximumWorldSizeLabel)
        Me.World.Controls.Add(Me.MaximumBuildHeight)
        Me.World.Controls.Add(Me.MaximumBuildHeightLabel)
        Me.World.Controls.Add(Me.Debug)
        Me.World.Controls.Add(Me.Hardcore)
        Me.World.Controls.Add(Me.GenerateStructures)
        Me.World.Controls.Add(Me.EnableCommandBlocks)
        Me.World.Controls.Add(Me.AllowNether)
        Me.World.Location = New System.Drawing.Point(16, 12)
        Me.World.Name = "World"
        Me.World.Size = New System.Drawing.Size(412, 318)
        Me.World.TabIndex = 14
        Me.World.TabStop = False
        Me.World.Text = "World"
        '
        'MaximumWorldSizeCalculation
        '
        Me.MaximumWorldSizeCalculation.AutoSize = True
        Me.MaximumWorldSizeCalculation.Location = New System.Drawing.Point(15, 183)
        Me.MaximumWorldSizeCalculation.Name = "MaximumWorldSizeCalculation"
        Me.MaximumWorldSizeCalculation.Size = New System.Drawing.Size(37, 13)
        Me.MaximumWorldSizeCalculation.TabIndex = 31
        Me.MaximumWorldSizeCalculation.Text = "2n×2n"
        '
        'SpawnProtectionCalculation
        '
        Me.SpawnProtectionCalculation.AutoSize = True
        Me.SpawnProtectionCalculation.Location = New System.Drawing.Point(103, 269)
        Me.SpawnProtectionCalculation.Name = "SpawnProtectionCalculation"
        Me.SpawnProtectionCalculation.Size = New System.Drawing.Size(73, 13)
        Me.SpawnProtectionCalculation.TabIndex = 30
        Me.SpawnProtectionCalculation.Text = "(2n+1)×(2n+1)"
        '
        'SpawnProtection
        '
        Me.SpawnProtection.Location = New System.Drawing.Point(122, 285)
        Me.SpawnProtection.Maximum = New Decimal(New Integer() {2147483647, 0, 0, 0})
        Me.SpawnProtection.Name = "SpawnProtection"
        Me.SpawnProtection.Size = New System.Drawing.Size(52, 20)
        Me.SpawnProtection.TabIndex = 29
        Me.SpawnProtection.Value = New Decimal(New Integer() {16, 0, 0, 0})
        '
        'SpawnProtectionLabel
        '
        Me.SpawnProtectionLabel.AutoSize = True
        Me.SpawnProtectionLabel.Location = New System.Drawing.Point(8, 287)
        Me.SpawnProtectionLabel.Name = "SpawnProtectionLabel"
        Me.SpawnProtectionLabel.Size = New System.Drawing.Size(91, 13)
        Me.SpawnProtectionLabel.TabIndex = 28
        Me.SpawnProtectionLabel.Text = "Spawn Protection"
        '
        'Difficulty
        '
        Me.Difficulty.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Difficulty.FormattingEnabled = True
        Me.Difficulty.Items.AddRange(New Object() {"0. Peaceful", "1. Easy", "2. Normal", "3. Hard"})
        Me.Difficulty.Location = New System.Drawing.Point(51, 37)
        Me.Difficulty.Name = "Difficulty"
        Me.Difficulty.Size = New System.Drawing.Size(121, 21)
        Me.Difficulty.TabIndex = 27
        '
        'DifficultyLabel
        '
        Me.DifficultyLabel.AutoSize = True
        Me.DifficultyLabel.Location = New System.Drawing.Point(4, 40)
        Me.DifficultyLabel.Name = "DifficultyLabel"
        Me.DifficultyLabel.Size = New System.Drawing.Size(47, 13)
        Me.DifficultyLabel.TabIndex = 26
        Me.DifficultyLabel.Text = "Difficulty"
        '
        'SpawnVillagers
        '
        Me.SpawnVillagers.AutoSize = True
        Me.SpawnVillagers.Location = New System.Drawing.Point(7, 267)
        Me.SpawnVillagers.Name = "SpawnVillagers"
        Me.SpawnVillagers.Size = New System.Drawing.Size(101, 17)
        Me.SpawnVillagers.TabIndex = 14
        Me.SpawnVillagers.Text = "Spawn Villagers"
        Me.SpawnVillagers.UseVisualStyleBackColor = True
        '
        'SpawnMonsters
        '
        Me.SpawnMonsters.AutoSize = True
        Me.SpawnMonsters.Location = New System.Drawing.Point(7, 244)
        Me.SpawnMonsters.Name = "SpawnMonsters"
        Me.SpawnMonsters.Size = New System.Drawing.Size(105, 17)
        Me.SpawnMonsters.TabIndex = 13
        Me.SpawnMonsters.Text = "Spawn Monsters"
        Me.SpawnMonsters.UseVisualStyleBackColor = True
        '
        'SpawnAnimals
        '
        Me.SpawnAnimals.AutoSize = True
        Me.SpawnAnimals.Location = New System.Drawing.Point(7, 221)
        Me.SpawnAnimals.Name = "SpawnAnimals"
        Me.SpawnAnimals.Size = New System.Drawing.Size(98, 17)
        Me.SpawnAnimals.TabIndex = 12
        Me.SpawnAnimals.Text = "Spawn Animals"
        Me.SpawnAnimals.UseVisualStyleBackColor = True
        '
        'OPPermissionLevel
        '
        Me.OPPermissionLevel.Location = New System.Drawing.Point(120, 194)
        Me.OPPermissionLevel.Maximum = New Decimal(New Integer() {4, 0, 0, 0})
        Me.OPPermissionLevel.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.OPPermissionLevel.Name = "OPPermissionLevel"
        Me.OPPermissionLevel.Size = New System.Drawing.Size(52, 20)
        Me.OPPermissionLevel.TabIndex = 11
        Me.OPPermissionLevel.Value = New Decimal(New Integer() {4, 0, 0, 0})
        '
        'OPPermissionLevelLabel
        '
        Me.OPPermissionLevelLabel.AutoSize = True
        Me.OPPermissionLevelLabel.Location = New System.Drawing.Point(6, 196)
        Me.OPPermissionLevelLabel.Name = "OPPermissionLevelLabel"
        Me.OPPermissionLevelLabel.Size = New System.Drawing.Size(104, 13)
        Me.OPPermissionLevelLabel.TabIndex = 10
        Me.OPPermissionLevelLabel.Text = "OP Permission Level"
        '
        'MaximumWorldSize
        '
        Me.MaximumWorldSize.Location = New System.Drawing.Point(120, 164)
        Me.MaximumWorldSize.Maximum = New Decimal(New Integer() {30000000, 0, 0, 0})
        Me.MaximumWorldSize.Name = "MaximumWorldSize"
        Me.MaximumWorldSize.Size = New System.Drawing.Size(52, 20)
        Me.MaximumWorldSize.TabIndex = 9
        '
        'MaximumWorldSizeLabel
        '
        Me.MaximumWorldSizeLabel.AutoSize = True
        Me.MaximumWorldSizeLabel.Location = New System.Drawing.Point(6, 166)
        Me.MaximumWorldSizeLabel.Name = "MaximumWorldSizeLabel"
        Me.MaximumWorldSizeLabel.Size = New System.Drawing.Size(105, 13)
        Me.MaximumWorldSizeLabel.TabIndex = 8
        Me.MaximumWorldSizeLabel.Text = "Maximum World Size"
        '
        'MaximumBuildHeight
        '
        Me.MaximumBuildHeight.Location = New System.Drawing.Point(120, 136)
        Me.MaximumBuildHeight.Maximum = New Decimal(New Integer() {2147483647, 0, 0, 0})
        Me.MaximumBuildHeight.Name = "MaximumBuildHeight"
        Me.MaximumBuildHeight.Size = New System.Drawing.Size(52, 20)
        Me.MaximumBuildHeight.TabIndex = 5
        '
        'MaximumBuildHeightLabel
        '
        Me.MaximumBuildHeightLabel.AutoSize = True
        Me.MaximumBuildHeightLabel.Location = New System.Drawing.Point(6, 138)
        Me.MaximumBuildHeightLabel.Name = "MaximumBuildHeightLabel"
        Me.MaximumBuildHeightLabel.Size = New System.Drawing.Size(111, 13)
        Me.MaximumBuildHeightLabel.TabIndex = 4
        Me.MaximumBuildHeightLabel.Text = "Maximum Build Height"
        '
        'Hardcore
        '
        Me.Hardcore.AutoSize = True
        Me.Hardcore.Location = New System.Drawing.Point(6, 114)
        Me.Hardcore.Name = "Hardcore"
        Me.Hardcore.Size = New System.Drawing.Size(70, 17)
        Me.Hardcore.TabIndex = 3
        Me.Hardcore.Text = "Hardcore"
        Me.Hardcore.UseVisualStyleBackColor = True
        '
        'GenerateStructures
        '
        Me.GenerateStructures.AutoSize = True
        Me.GenerateStructures.Location = New System.Drawing.Point(6, 90)
        Me.GenerateStructures.Name = "GenerateStructures"
        Me.GenerateStructures.Size = New System.Drawing.Size(121, 17)
        Me.GenerateStructures.TabIndex = 2
        Me.GenerateStructures.Text = "Generate Structures"
        Me.GenerateStructures.UseVisualStyleBackColor = True
        '
        'EnableCommandBlocks
        '
        Me.EnableCommandBlocks.AutoSize = True
        Me.EnableCommandBlocks.Location = New System.Drawing.Point(6, 67)
        Me.EnableCommandBlocks.Name = "EnableCommandBlocks"
        Me.EnableCommandBlocks.Size = New System.Drawing.Size(144, 17)
        Me.EnableCommandBlocks.TabIndex = 1
        Me.EnableCommandBlocks.Text = "Enable Command Blocks"
        Me.EnableCommandBlocks.UseVisualStyleBackColor = True
        '
        'AllowNether
        '
        Me.AllowNether.AutoSize = True
        Me.AllowNether.Checked = True
        Me.AllowNether.CheckState = System.Windows.Forms.CheckState.Checked
        Me.AllowNether.Location = New System.Drawing.Point(7, 20)
        Me.AllowNether.Name = "AllowNether"
        Me.AllowNether.Size = New System.Drawing.Size(86, 17)
        Me.AllowNether.TabIndex = 0
        Me.AllowNether.Text = "Allow Nether"
        Me.AllowNether.UseVisualStyleBackColor = True
        '
        'Players
        '
        Me.Players.Controls.Add(Me.UseWhiteList)
        Me.Players.Controls.Add(Me.DefaultGamemode)
        Me.Players.Controls.Add(Me.DefaultGamemodeLabel)
        Me.Players.Controls.Add(Me.ForceDefaultGamemode)
        Me.Players.Controls.Add(Me.AllowFlight)
        Me.Players.Controls.Add(Me.ViewDistance)
        Me.Players.Controls.Add(Me.BroadcastConsoleToOPs)
        Me.Players.Controls.Add(Me.AnnouncePlayerAchievements)
        Me.Players.Controls.Add(Me.PVP)
        Me.Players.Controls.Add(Me.PlayerIdleTimeout)
        Me.Players.Controls.Add(Me.MaximumPlayersLabel)
        Me.Players.Controls.Add(Me.PlayerIdleTimeoutLabel)
        Me.Players.Controls.Add(Me.ViewDistanceLabel)
        Me.Players.Controls.Add(Me.PlayerIdleTimeoutCheckBox)
        Me.Players.Controls.Add(Me.MaximumPlayers)
        Me.Players.Location = New System.Drawing.Point(181, 19)
        Me.Players.Name = "Players"
        Me.Players.Size = New System.Drawing.Size(228, 203)
        Me.Players.TabIndex = 15
        Me.Players.TabStop = False
        Me.Players.Text = "Players"
        '
        'UseWhiteList
        '
        Me.UseWhiteList.AutoSize = True
        Me.UseWhiteList.Location = New System.Drawing.Point(3, 177)
        Me.UseWhiteList.Name = "UseWhiteList"
        Me.UseWhiteList.Size = New System.Drawing.Size(95, 17)
        Me.UseWhiteList.TabIndex = 26
        Me.UseWhiteList.Text = "Use White List"
        Me.UseWhiteList.UseVisualStyleBackColor = True
        '
        'DefaultGamemode
        '
        Me.DefaultGamemode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.DefaultGamemode.FormattingEnabled = True
        Me.DefaultGamemode.Items.AddRange(New Object() {"0. Survival", "1. Creative", "2. Adventure", "3. Spectator"})
        Me.DefaultGamemode.Location = New System.Drawing.Point(101, 80)
        Me.DefaultGamemode.Name = "DefaultGamemode"
        Me.DefaultGamemode.Size = New System.Drawing.Size(121, 21)
        Me.DefaultGamemode.TabIndex = 25
        '
        'DefaultGamemodeLabel
        '
        Me.DefaultGamemodeLabel.AutoSize = True
        Me.DefaultGamemodeLabel.Location = New System.Drawing.Point(3, 83)
        Me.DefaultGamemodeLabel.Name = "DefaultGamemodeLabel"
        Me.DefaultGamemodeLabel.Size = New System.Drawing.Size(98, 13)
        Me.DefaultGamemodeLabel.TabIndex = 24
        Me.DefaultGamemodeLabel.Text = "Default Gamemode"
        '
        'ForceDefaultGamemode
        '
        Me.ForceDefaultGamemode.AutoSize = True
        Me.ForceDefaultGamemode.Location = New System.Drawing.Point(81, 62)
        Me.ForceDefaultGamemode.Name = "ForceDefaultGamemode"
        Me.ForceDefaultGamemode.Size = New System.Drawing.Size(147, 17)
        Me.ForceDefaultGamemode.TabIndex = 0
        Me.ForceDefaultGamemode.Text = "Force Default Gamemode"
        Me.ForceDefaultGamemode.UseVisualStyleBackColor = True
        '
        'AllowFlight
        '
        Me.AllowFlight.AutoSize = True
        Me.AllowFlight.Location = New System.Drawing.Point(6, 62)
        Me.AllowFlight.Name = "AllowFlight"
        Me.AllowFlight.Size = New System.Drawing.Size(79, 17)
        Me.AllowFlight.TabIndex = 1
        Me.AllowFlight.Text = "Allow Flight"
        Me.AllowFlight.UseVisualStyleBackColor = True
        '
        'ViewDistance
        '
        Me.ViewDistance.Location = New System.Drawing.Point(118, 155)
        Me.ViewDistance.Maximum = New Decimal(New Integer() {64, 0, 0, 0})
        Me.ViewDistance.Minimum = New Decimal(New Integer() {2, 0, 0, 0})
        Me.ViewDistance.Name = "ViewDistance"
        Me.ViewDistance.Size = New System.Drawing.Size(52, 20)
        Me.ViewDistance.TabIndex = 17
        Me.ViewDistance.Value = New Decimal(New Integer() {10, 0, 0, 0})
        '
        'BroadcastConsoleToOPs
        '
        Me.BroadcastConsoleToOPs.AutoSize = True
        Me.BroadcastConsoleToOPs.Checked = True
        Me.BroadcastConsoleToOPs.CheckState = System.Windows.Forms.CheckState.Checked
        Me.BroadcastConsoleToOPs.Location = New System.Drawing.Point(6, 42)
        Me.BroadcastConsoleToOPs.Name = "BroadcastConsoleToOPs"
        Me.BroadcastConsoleToOPs.Size = New System.Drawing.Size(154, 17)
        Me.BroadcastConsoleToOPs.TabIndex = 23
        Me.BroadcastConsoleToOPs.Text = "Broadcast Console To OPs"
        Me.BroadcastConsoleToOPs.UseVisualStyleBackColor = True
        '
        'AnnouncePlayerAchievements
        '
        Me.AnnouncePlayerAchievements.AutoSize = True
        Me.AnnouncePlayerAchievements.Checked = True
        Me.AnnouncePlayerAchievements.CheckState = System.Windows.Forms.CheckState.Checked
        Me.AnnouncePlayerAchievements.Location = New System.Drawing.Point(6, 19)
        Me.AnnouncePlayerAchievements.Name = "AnnouncePlayerAchievements"
        Me.AnnouncePlayerAchievements.Size = New System.Drawing.Size(177, 17)
        Me.AnnouncePlayerAchievements.TabIndex = 22
        Me.AnnouncePlayerAchievements.Text = "Announce Player Achievements"
        Me.AnnouncePlayerAchievements.UseVisualStyleBackColor = True
        '
        'PVP
        '
        Me.PVP.AutoSize = True
        Me.PVP.Location = New System.Drawing.Point(164, 110)
        Me.PVP.Name = "PVP"
        Me.PVP.Size = New System.Drawing.Size(47, 17)
        Me.PVP.TabIndex = 21
        Me.PVP.Text = "PVP"
        Me.PVP.UseVisualStyleBackColor = True
        '
        'PlayerIdleTimeout
        '
        Me.PlayerIdleTimeout.Location = New System.Drawing.Point(118, 128)
        Me.PlayerIdleTimeout.Maximum = New Decimal(New Integer() {2147483647, 0, 0, 0})
        Me.PlayerIdleTimeout.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.PlayerIdleTimeout.Name = "PlayerIdleTimeout"
        Me.PlayerIdleTimeout.Size = New System.Drawing.Size(52, 20)
        Me.PlayerIdleTimeout.TabIndex = 19
        Me.PlayerIdleTimeout.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'MaximumPlayersLabel
        '
        Me.MaximumPlayersLabel.AutoSize = True
        Me.MaximumPlayersLabel.Location = New System.Drawing.Point(0, 110)
        Me.MaximumPlayersLabel.Name = "MaximumPlayersLabel"
        Me.MaximumPlayersLabel.Size = New System.Drawing.Size(88, 13)
        Me.MaximumPlayersLabel.TabIndex = 16
        Me.MaximumPlayersLabel.Text = "Maximum Players"
        '
        'PlayerIdleTimeoutLabel
        '
        Me.PlayerIdleTimeoutLabel.AutoSize = True
        Me.PlayerIdleTimeoutLabel.Location = New System.Drawing.Point(174, 130)
        Me.PlayerIdleTimeoutLabel.Name = "PlayerIdleTimeoutLabel"
        Me.PlayerIdleTimeoutLabel.Size = New System.Drawing.Size(44, 13)
        Me.PlayerIdleTimeoutLabel.TabIndex = 18
        Me.PlayerIdleTimeoutLabel.Text = "Minutes"
        '
        'ViewDistanceLabel
        '
        Me.ViewDistanceLabel.AutoSize = True
        Me.ViewDistanceLabel.Location = New System.Drawing.Point(0, 155)
        Me.ViewDistanceLabel.Name = "ViewDistanceLabel"
        Me.ViewDistanceLabel.Size = New System.Drawing.Size(117, 13)
        Me.ViewDistanceLabel.TabIndex = 16
        Me.ViewDistanceLabel.Text = "View Distance (Radius)"
        '
        'PlayerIdleTimeoutCheckBox
        '
        Me.PlayerIdleTimeoutCheckBox.AutoSize = True
        Me.PlayerIdleTimeoutCheckBox.Location = New System.Drawing.Point(1, 129)
        Me.PlayerIdleTimeoutCheckBox.Name = "PlayerIdleTimeoutCheckBox"
        Me.PlayerIdleTimeoutCheckBox.Size = New System.Drawing.Size(116, 17)
        Me.PlayerIdleTimeoutCheckBox.TabIndex = 20
        Me.PlayerIdleTimeoutCheckBox.Text = "Player Idle Timeout"
        Me.PlayerIdleTimeoutCheckBox.UseVisualStyleBackColor = True
        '
        'MaximumPlayers
        '
        Me.MaximumPlayers.Location = New System.Drawing.Point(94, 108)
        Me.MaximumPlayers.Maximum = New Decimal(New Integer() {2147483647, 0, 0, 0})
        Me.MaximumPlayers.Name = "MaximumPlayers"
        Me.MaximumPlayers.Size = New System.Drawing.Size(52, 20)
        Me.MaximumPlayers.TabIndex = 17
        '
        'Connection
        '
        Me.Connection.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Connection.Controls.Add(Me.SnooperHelp)
        Me.Connection.Controls.Add(Me.EnableSnooper)
        Me.Connection.Controls.Add(Me.IP)
        Me.Connection.Controls.Add(Me.IPLabel)
        Me.Connection.Controls.Add(Me.NetworkCompressionThresholdUnit)
        Me.Connection.Controls.Add(Me.ServerPort)
        Me.Connection.Controls.Add(Me.ServerPortLabel)
        Me.Connection.Controls.Add(Me.RemoteConnectionPasswordButton)
        Me.Connection.Controls.Add(Me.RemoteConnectionPassword)
        Me.Connection.Controls.Add(Me.RemoteConnectionLabel)
        Me.Connection.Controls.Add(Me.RemoteConnectionPort)
        Me.Connection.Controls.Add(Me.QueryPort)
        Me.Connection.Controls.Add(Me.OnlineMode)
        Me.Connection.Controls.Add(Me.NetworkCompressionThreshold)
        Me.Connection.Controls.Add(Me.NetworkCompressionThresholdLabel)
        Me.Connection.Controls.Add(Me.MessageOfTheDay)
        Me.Connection.Controls.Add(Me.MessageOfTheDayLabel)
        Me.Connection.Controls.Add(Me.EnableRemoteConnection)
        Me.Connection.Controls.Add(Me.EnableQuery)
        Me.Connection.Controls.Add(Me.MaximumTickTime)
        Me.Connection.Controls.Add(Me.MaximumTickTimeLabel)
        Me.Connection.Location = New System.Drawing.Point(12, 336)
        Me.Connection.Name = "Connection"
        Me.Connection.Size = New System.Drawing.Size(416, 159)
        Me.Connection.TabIndex = 16
        Me.Connection.TabStop = False
        Me.Connection.Text = " Connection"
        '
        'LoadWorldLabel
        '
        Me.LoadWorldLabel.AutoSize = True
        Me.LoadWorldLabel.Location = New System.Drawing.Point(214, 225)
        Me.LoadWorldLabel.Name = "LoadWorldLabel"
        Me.LoadWorldLabel.Size = New System.Drawing.Size(65, 13)
        Me.LoadWorldLabel.TabIndex = 33
        Me.LoadWorldLabel.Text = "Load World:"
        '
        'LoadWorld
        '
        Me.LoadWorld.Location = New System.Drawing.Point(282, 223)
        Me.LoadWorld.Name = "LoadWorld"
        Me.LoadWorld.Size = New System.Drawing.Size(120, 20)
        Me.LoadWorld.TabIndex = 32
        Me.LoadWorld.Text = "Load World..."
        '
        'EnableSnooper
        '
        Me.EnableSnooper.AutoSize = True
        Me.EnableSnooper.Location = New System.Drawing.Point(8, 130)
        Me.EnableSnooper.Name = "EnableSnooper"
        Me.EnableSnooper.Size = New System.Drawing.Size(102, 17)
        Me.EnableSnooper.TabIndex = 31
        Me.EnableSnooper.Text = "Enable Snooper"
        Me.EnableSnooper.UseVisualStyleBackColor = True
        '
        'IP
        '
        Me.IP.Location = New System.Drawing.Point(252, 88)
        Me.IP.Name = "IP"
        Me.IP.Size = New System.Drawing.Size(100, 20)
        Me.IP.TabIndex = 30
        '
        'IPLabel
        '
        Me.IPLabel.AutoSize = True
        Me.IPLabel.Location = New System.Drawing.Point(228, 88)
        Me.IPLabel.Name = "IPLabel"
        Me.IPLabel.Size = New System.Drawing.Size(17, 13)
        Me.IPLabel.TabIndex = 29
        Me.IPLabel.Text = "IP"
        '
        'NetworkCompressionThresholdUnit
        '
        Me.NetworkCompressionThresholdUnit.AutoSize = True
        Me.NetworkCompressionThresholdUnit.Location = New System.Drawing.Point(230, 111)
        Me.NetworkCompressionThresholdUnit.Name = "NetworkCompressionThresholdUnit"
        Me.NetworkCompressionThresholdUnit.Size = New System.Drawing.Size(33, 13)
        Me.NetworkCompressionThresholdUnit.TabIndex = 28
        Me.NetworkCompressionThresholdUnit.Text = "Bytes"
        '
        'ServerPort
        '
        Me.ServerPort.Location = New System.Drawing.Point(244, 65)
        Me.ServerPort.Maximum = New Decimal(New Integer() {65535, 0, 0, 0})
        Me.ServerPort.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.ServerPort.Name = "ServerPort"
        Me.ServerPort.Size = New System.Drawing.Size(50, 20)
        Me.ServerPort.TabIndex = 27
        Me.ServerPort.Value = New Decimal(New Integer() {25565, 0, 0, 0})
        '
        'ServerPortLabel
        '
        Me.ServerPortLabel.AutoSize = True
        Me.ServerPortLabel.Location = New System.Drawing.Point(178, 67)
        Me.ServerPortLabel.Name = "ServerPortLabel"
        Me.ServerPortLabel.Size = New System.Drawing.Size(60, 13)
        Me.ServerPortLabel.TabIndex = 26
        Me.ServerPortLabel.Text = "Server Port"
        '
        'RemoteConnectionPasswordButton
        '
        Me.RemoteConnectionPasswordButton.Location = New System.Drawing.Point(390, 38)
        Me.RemoteConnectionPasswordButton.Name = "RemoteConnectionPasswordButton"
        Me.RemoteConnectionPasswordButton.Size = New System.Drawing.Size(23, 23)
        Me.RemoteConnectionPasswordButton.TabIndex = 25
        Me.RemoteConnectionPasswordButton.Text = "👁"
        Me.RemoteConnectionPasswordButton.UseVisualStyleBackColor = True
        '
        'RemoteConnectionPassword
        '
        Me.RemoteConnectionPassword.Location = New System.Drawing.Point(305, 41)
        Me.RemoteConnectionPassword.Name = "RemoteConnectionPassword"
        Me.RemoteConnectionPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.RemoteConnectionPassword.Size = New System.Drawing.Size(79, 20)
        Me.RemoteConnectionPassword.TabIndex = 24
        '
        'RemoteConnectionLabel
        '
        Me.RemoteConnectionLabel.AutoSize = True
        Me.RemoteConnectionLabel.Location = New System.Drawing.Point(245, 44)
        Me.RemoteConnectionLabel.Name = "RemoteConnectionLabel"
        Me.RemoteConnectionLabel.Size = New System.Drawing.Size(59, 13)
        Me.RemoteConnectionLabel.TabIndex = 23
        Me.RemoteConnectionLabel.Text = "Password :"
        '
        'RemoteConnectionPort
        '
        Me.RemoteConnectionPort.Location = New System.Drawing.Point(195, 42)
        Me.RemoteConnectionPort.Maximum = New Decimal(New Integer() {65535, 0, 0, 0})
        Me.RemoteConnectionPort.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.RemoteConnectionPort.Name = "RemoteConnectionPort"
        Me.RemoteConnectionPort.Size = New System.Drawing.Size(50, 20)
        Me.RemoteConnectionPort.TabIndex = 22
        Me.RemoteConnectionPort.Value = New Decimal(New Integer() {25575, 0, 0, 0})
        '
        'QueryPort
        '
        Me.QueryPort.Location = New System.Drawing.Point(195, 16)
        Me.QueryPort.Maximum = New Decimal(New Integer() {65535, 0, 0, 0})
        Me.QueryPort.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.QueryPort.Name = "QueryPort"
        Me.QueryPort.Size = New System.Drawing.Size(50, 20)
        Me.QueryPort.TabIndex = 21
        Me.QueryPort.Value = New Decimal(New Integer() {25565, 0, 0, 0})
        '
        'OnlineMode
        '
        Me.OnlineMode.AutoSize = True
        Me.OnlineMode.Location = New System.Drawing.Point(320, 19)
        Me.OnlineMode.Name = "OnlineMode"
        Me.OnlineMode.Size = New System.Drawing.Size(86, 17)
        Me.OnlineMode.TabIndex = 19
        Me.OnlineMode.Text = "Online Mode"
        Me.OnlineMode.UseVisualStyleBackColor = True
        '
        'NetworkCompressionThreshold
        '
        Me.NetworkCompressionThreshold.Location = New System.Drawing.Point(172, 109)
        Me.NetworkCompressionThreshold.Maximum = New Decimal(New Integer() {2147483647, 0, 0, 0})
        Me.NetworkCompressionThreshold.Minimum = New Decimal(New Integer() {1, 0, 0, -2147483648})
        Me.NetworkCompressionThreshold.Name = "NetworkCompressionThreshold"
        Me.NetworkCompressionThreshold.Size = New System.Drawing.Size(52, 20)
        Me.NetworkCompressionThreshold.TabIndex = 16
        Me.NetworkCompressionThreshold.Value = New Decimal(New Integer() {256, 0, 0, 0})
        '
        'NetworkCompressionThresholdLabel
        '
        Me.NetworkCompressionThresholdLabel.AutoSize = True
        Me.NetworkCompressionThresholdLabel.Location = New System.Drawing.Point(6, 111)
        Me.NetworkCompressionThresholdLabel.Name = "NetworkCompressionThresholdLabel"
        Me.NetworkCompressionThresholdLabel.Size = New System.Drawing.Size(160, 13)
        Me.NetworkCompressionThresholdLabel.TabIndex = 10
        Me.NetworkCompressionThresholdLabel.Text = "Network Compression Threshold"
        '
        'MessageOfTheDay
        '
        Me.MessageOfTheDay.Location = New System.Drawing.Point(116, 84)
        Me.MessageOfTheDay.Name = "MessageOfTheDay"
        Me.MessageOfTheDay.Size = New System.Drawing.Size(100, 20)
        Me.MessageOfTheDay.TabIndex = 9
        '
        'MessageOfTheDayLabel
        '
        Me.MessageOfTheDayLabel.AutoSize = True
        Me.MessageOfTheDayLabel.Location = New System.Drawing.Point(6, 87)
        Me.MessageOfTheDayLabel.Name = "MessageOfTheDayLabel"
        Me.MessageOfTheDayLabel.Size = New System.Drawing.Size(108, 13)
        Me.MessageOfTheDayLabel.TabIndex = 8
        Me.MessageOfTheDayLabel.Text = "Message Of The Day"
        '
        'EnableRemoteConnection
        '
        Me.EnableRemoteConnection.AutoSize = True
        Me.EnableRemoteConnection.Location = New System.Drawing.Point(8, 43)
        Me.EnableRemoteConnection.Name = "EnableRemoteConnection"
        Me.EnableRemoteConnection.Size = New System.Drawing.Size(190, 17)
        Me.EnableRemoteConnection.TabIndex = 2
        Me.EnableRemoteConnection.Text = "Enable Remote Connection - Port :"
        Me.EnableRemoteConnection.UseVisualStyleBackColor = True
        '
        'EnableQuery
        '
        Me.EnableQuery.AutoSize = True
        Me.EnableQuery.Location = New System.Drawing.Point(72, 20)
        Me.EnableQuery.Name = "EnableQuery"
        Me.EnableQuery.Size = New System.Drawing.Size(124, 17)
        Me.EnableQuery.TabIndex = 1
        Me.EnableQuery.Text = "Enable Query - Port :"
        Me.EnableQuery.UseVisualStyleBackColor = True
        '
        'Debug
        '
        Me.Debug.AutoSize = True
        Me.Debug.Location = New System.Drawing.Point(345, 249)
        Me.Debug.Name = "Debug"
        Me.Debug.Size = New System.Drawing.Size(58, 17)
        Me.Debug.TabIndex = 0
        Me.Debug.Text = "Debug"
        Me.Debug.UseVisualStyleBackColor = True
        '
        'MaximumTickTime
        '
        Me.MaximumTickTime.Location = New System.Drawing.Point(119, 61)
        Me.MaximumTickTime.Maximum = New Decimal(New Integer() {-1, 2147483647, 0, 0})
        Me.MaximumTickTime.Name = "MaximumTickTime"
        Me.MaximumTickTime.Size = New System.Drawing.Size(52, 20)
        Me.MaximumTickTime.TabIndex = 7
        '
        'MaximumTickTimeLabel
        '
        Me.MaximumTickTimeLabel.AutoSize = True
        Me.MaximumTickTimeLabel.Location = New System.Drawing.Point(5, 63)
        Me.MaximumTickTimeLabel.Name = "MaximumTickTimeLabel"
        Me.MaximumTickTimeLabel.Size = New System.Drawing.Size(101, 13)
        Me.MaximumTickTimeLabel.TabIndex = 6
        Me.MaximumTickTimeLabel.Text = "Maximum Tick Time"
        '
        'ResetToDefault
        '
        Me.ResetToDefault.Location = New System.Drawing.Point(12, 503)
        Me.ResetToDefault.Name = "ResetToDefault"
        Me.ResetToDefault.Size = New System.Drawing.Size(98, 23)
        Me.ResetToDefault.TabIndex = 17
        Me.ResetToDefault.Text = "Reset To Default"
        Me.ResetToDefault.UseVisualStyleBackColor = True
        '
        'SnooperHelp
        '
        Me.SnooperHelp.Location = New System.Drawing.Point(110, 130)
        Me.SnooperHelp.Name = "SnooperHelp"
        Me.SnooperHelp.Size = New System.Drawing.Size(119, 23)
        Me.SnooperHelp.TabIndex = 32
        Me.SnooperHelp.Text = "What is Snooper?"
        Me.SnooperHelp.UseVisualStyleBackColor = True
        '
        'Settings
        '
        Me.AcceptButton = Me.OK_Button
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.Apply_Button
        Me.ClientSize = New System.Drawing.Size(435, 541)
        Me.Controls.Add(Me.ResetToDefault)
        Me.Controls.Add(Me.Connection)
        Me.Controls.Add(Me.World)
        Me.Controls.Add(Me.ButtonLayoutPanel)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Settings"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Settings"
        Me.ButtonLayoutPanel.ResumeLayout(False)
        Me.World.ResumeLayout(False)
        Me.World.PerformLayout()
        CType(Me.SpawnProtection, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.OPPermissionLevel, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MaximumWorldSize, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MaximumBuildHeight, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Players.ResumeLayout(False)
        Me.Players.PerformLayout()
        CType(Me.ViewDistance, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PlayerIdleTimeout, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MaximumPlayers, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Connection.ResumeLayout(False)
        Me.Connection.PerformLayout()
        CType(Me.ServerPort, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RemoteConnectionPort, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.QueryPort, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NetworkCompressionThreshold, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MaximumTickTime, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ButtonLayoutPanel As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents Apply_Button As System.Windows.Forms.Button
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents World As System.Windows.Forms.GroupBox
    Friend WithEvents EnableCommandBlocks As System.Windows.Forms.CheckBox
    Friend WithEvents AllowNether As System.Windows.Forms.CheckBox
    Friend WithEvents GenerateStructures As System.Windows.Forms.CheckBox
    Friend WithEvents Hardcore As System.Windows.Forms.CheckBox
    Friend WithEvents MaximumBuildHeight As System.Windows.Forms.NumericUpDown
    Friend WithEvents MaximumBuildHeightLabel As System.Windows.Forms.Label
    Friend WithEvents MaximumWorldSize As System.Windows.Forms.NumericUpDown
    Friend WithEvents MaximumWorldSizeLabel As System.Windows.Forms.Label
    Friend WithEvents OPPermissionLevel As System.Windows.Forms.NumericUpDown
    Friend WithEvents OPPermissionLevelLabel As System.Windows.Forms.Label
    Friend WithEvents SpawnVillagers As System.Windows.Forms.CheckBox
    Friend WithEvents SpawnMonsters As System.Windows.Forms.CheckBox
    Friend WithEvents SpawnAnimals As System.Windows.Forms.CheckBox
    Friend WithEvents Players As System.Windows.Forms.GroupBox
    Friend WithEvents AllowFlight As System.Windows.Forms.CheckBox
    Friend WithEvents ForceDefaultGamemode As System.Windows.Forms.CheckBox
    Friend WithEvents MaximumPlayers As System.Windows.Forms.NumericUpDown
    Friend WithEvents MaximumPlayersLabel As System.Windows.Forms.Label
    Friend WithEvents PlayerIdleTimeoutCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents PlayerIdleTimeout As System.Windows.Forms.NumericUpDown
    Friend WithEvents PlayerIdleTimeoutLabel As System.Windows.Forms.Label
    Friend WithEvents PVP As System.Windows.Forms.CheckBox
    Friend WithEvents ViewDistance As System.Windows.Forms.NumericUpDown
    Friend WithEvents ViewDistanceLabel As System.Windows.Forms.Label
    Friend WithEvents Connection As System.Windows.Forms.GroupBox
    Friend WithEvents AnnouncePlayerAchievements As System.Windows.Forms.CheckBox
    Friend WithEvents BroadcastConsoleToOPs As System.Windows.Forms.CheckBox
    Friend WithEvents Debug As System.Windows.Forms.CheckBox
    Friend WithEvents EnableRemoteConnection As System.Windows.Forms.CheckBox
    Friend WithEvents EnableQuery As System.Windows.Forms.CheckBox
    Friend WithEvents MaximumTickTime As System.Windows.Forms.NumericUpDown
    Friend WithEvents MaximumTickTimeLabel As System.Windows.Forms.Label
    Friend WithEvents MessageOfTheDay As System.Windows.Forms.TextBox
    Friend WithEvents MessageOfTheDayLabel As System.Windows.Forms.Label
    Friend WithEvents NetworkCompressionThresholdLabel As System.Windows.Forms.Label
    Friend WithEvents DefaultGamemode As System.Windows.Forms.ComboBox
    Friend WithEvents DefaultGamemodeLabel As System.Windows.Forms.Label
    Friend WithEvents NetworkCompressionThreshold As System.Windows.Forms.NumericUpDown
    Friend WithEvents OnlineMode As System.Windows.Forms.CheckBox
    Friend WithEvents RemoteConnectionPasswordButton As System.Windows.Forms.Button
    Friend WithEvents RemoteConnectionPassword As System.Windows.Forms.TextBox
    Friend WithEvents RemoteConnectionLabel As System.Windows.Forms.Label
    Friend WithEvents RemoteConnectionPort As System.Windows.Forms.NumericUpDown
    Friend WithEvents QueryPort As System.Windows.Forms.NumericUpDown
    Friend WithEvents Difficulty As System.Windows.Forms.ComboBox
    Friend WithEvents DifficultyLabel As System.Windows.Forms.Label
    Friend WithEvents ServerPort As System.Windows.Forms.NumericUpDown
    Friend WithEvents ServerPortLabel As System.Windows.Forms.Label
    Friend WithEvents NetworkCompressionThresholdUnit As System.Windows.Forms.Label
    Friend WithEvents IP As System.Windows.Forms.TextBox
    Friend WithEvents IPLabel As System.Windows.Forms.Label
    Friend WithEvents EnableSnooper As System.Windows.Forms.CheckBox
    Friend WithEvents UseWhiteList As System.Windows.Forms.CheckBox
    Friend WithEvents SpawnProtectionCalculation As System.Windows.Forms.Label
    Friend WithEvents SpawnProtection As System.Windows.Forms.NumericUpDown
    Friend WithEvents SpawnProtectionLabel As System.Windows.Forms.Label
    Friend WithEvents ResetToDefault As System.Windows.Forms.Button
    Friend WithEvents MaximumWorldSizeCalculation As System.Windows.Forms.Label
    Friend WithEvents LoadWorldLabel As System.Windows.Forms.Label
    Friend WithEvents LoadWorld As System.Windows.Forms.DomainUpDown
    Friend WithEvents SnooperHelp As Button
End Class
