<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Main
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
        Me.LoadWorld = New System.Windows.Forms.Button()
        Me.Path = New System.Windows.Forms.TextBox()
        Me.LoadJAR = New System.Windows.Forms.Button()
        Me.JAR = New System.Windows.Forms.TextBox()
        Me.Output = New System.Windows.Forms.TextBox()
        Me.ServerSwitch = New System.Windows.Forms.Button()
        Me.About = New System.Windows.Forms.Button()
        Me.JAVASwitch = New System.Windows.Forms.TrackBar()
        Me.JAVALabel = New System.Windows.Forms.Label()
        Me.JAVAWLabel = New System.Windows.Forms.Label()
        Me.SpeechButton = New System.Windows.Forms.Button()
        Me.Input = New System.Windows.Forms.ComboBox()
        CType(Me.JAVASwitch, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LoadWorld
        '
        Me.LoadWorld.Location = New System.Drawing.Point(13, 12)
        Me.LoadWorld.Name = "LoadWorld"
        Me.LoadWorld.Size = New System.Drawing.Size(83, 23)
        Me.LoadWorld.TabIndex = 0
        Me.LoadWorld.Text = "Load World..."
        Me.LoadWorld.UseVisualStyleBackColor = True
        '
        'Path
        '
        Me.Path.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Path.Location = New System.Drawing.Point(102, 15)
        Me.Path.Name = "Path"
        Me.Path.Size = New System.Drawing.Size(171, 20)
        Me.Path.TabIndex = 1
        '
        'LoadJAR
        '
        Me.LoadJAR.Location = New System.Drawing.Point(13, 41)
        Me.LoadJAR.Name = "LoadJAR"
        Me.LoadJAR.Size = New System.Drawing.Size(83, 23)
        Me.LoadJAR.TabIndex = 2
        Me.LoadJAR.Text = "Load JAR..."
        Me.LoadJAR.UseVisualStyleBackColor = True
        '
        'JAR
        '
        Me.JAR.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.JAR.Location = New System.Drawing.Point(101, 41)
        Me.JAR.Name = "JAR"
        Me.JAR.Size = New System.Drawing.Size(172, 20)
        Me.JAR.TabIndex = 3
        '
        'Output
        '
        Me.Output.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Output.Location = New System.Drawing.Point(13, 96)
        Me.Output.Multiline = True
        Me.Output.Name = "Output"
        Me.Output.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.Output.Size = New System.Drawing.Size(259, 158)
        Me.Output.TabIndex = 4
        '
        'ServerSwitch
        '
        Me.ServerSwitch.Location = New System.Drawing.Point(102, 67)
        Me.ServerSwitch.Name = "ServerSwitch"
        Me.ServerSwitch.Size = New System.Drawing.Size(75, 23)
        Me.ServerSwitch.TabIndex = 5
        Me.ServerSwitch.Text = "Start Server"
        Me.ServerSwitch.UseVisualStyleBackColor = True
        '
        'About
        '
        Me.About.Location = New System.Drawing.Point(12, 67)
        Me.About.Name = "About"
        Me.About.Size = New System.Drawing.Size(84, 23)
        Me.About.TabIndex = 7
        Me.About.Text = "About..."
        Me.About.UseVisualStyleBackColor = True
        '
        'JAVASwitch
        '
        Me.JAVASwitch.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.JAVASwitch.AutoSize = False
        Me.JAVASwitch.LargeChange = 1
        Me.JAVASwitch.Location = New System.Drawing.Point(201, 67)
        Me.JAVASwitch.Maximum = 1
        Me.JAVASwitch.Name = "JAVASwitch"
        Me.JAVASwitch.Size = New System.Drawing.Size(37, 23)
        Me.JAVASwitch.TabIndex = 1
        '
        'JAVALabel
        '
        Me.JAVALabel.AutoSize = True
        Me.JAVALabel.Location = New System.Drawing.Point(178, 72)
        Me.JAVALabel.Name = "JAVALabel"
        Me.JAVALabel.Size = New System.Drawing.Size(27, 13)
        Me.JAVALabel.TabIndex = 8
        Me.JAVALabel.Text = "java"
        '
        'JAVAWLabel
        '
        Me.JAVAWLabel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.JAVAWLabel.AutoSize = True
        Me.JAVAWLabel.Location = New System.Drawing.Point(238, 72)
        Me.JAVAWLabel.Name = "JAVAWLabel"
        Me.JAVAWLabel.Size = New System.Drawing.Size(35, 13)
        Me.JAVAWLabel.TabIndex = 9
        Me.JAVAWLabel.Text = "javaw"
        '
        'SpeechButton
        '
        Me.SpeechButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SpeechButton.Location = New System.Drawing.Point(250, 260)
        Me.SpeechButton.Name = "SpeechButton"
        Me.SpeechButton.Size = New System.Drawing.Size(23, 23)
        Me.SpeechButton.TabIndex = 10
        Me.SpeechButton.Text = "🎤"
        Me.SpeechButton.UseVisualStyleBackColor = True
        '
        'Input
        '
        Me.Input.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Input.FormattingEnabled = True
        Me.Input.Items.AddRange(New String() {"achievement", "ban", "ban-ip", "banlist", "blockdata", "clear", "clone", "debug",
                                                                     "defaultgamemode", "deop", "difficulty", "effect", "enchant", "entitydata", "execute",
                                                                     "fill", "gamemode", "gamerule", "give", "help", "kick", "kill", "list", "me", "op",
                                                                     "pardon", "particle", "playsound", "publish", "replaceitem", "save-all", "save-off",
                                                                     "save-on", "say", "scoreboard", "seed", "setblock", "setidletimeout", "setworldspawn",
                                                                     "spawnpoint", "spreadplayers", "stats", "stop", "summon", "tell", "tellraw", "testfor",
                                                                     "testforblock", "testforblocks", "time", "title", "toggledownfall", "tp", "trigger",
                                                                     "weather", "whitelist", "worldborder", "xp"})
        Me.Input.Location = New System.Drawing.Point(13, 260)
        Me.Input.Name = "Input"
        Me.Input.Size = New System.Drawing.Size(231, 21)
        Me.Input.TabIndex = 11
        '
        'Main
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(284, 286)
        Me.Controls.Add(Me.Input)
        Me.Controls.Add(Me.SpeechButton)
        Me.Controls.Add(Me.JAVAWLabel)
        Me.Controls.Add(Me.JAVALabel)
        Me.Controls.Add(Me.JAVASwitch)
        Me.Controls.Add(Me.About)
        Me.Controls.Add(Me.ServerSwitch)
        Me.Controls.Add(Me.Output)
        Me.Controls.Add(Me.JAR)
        Me.Controls.Add(Me.LoadJAR)
        Me.Controls.Add(Me.Path)
        Me.Controls.Add(Me.LoadWorld)
        Me.Name = "Main"
        Me.Text = "MCRealm"
        CType(Me.JAVASwitch, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents LoadWorld As System.Windows.Forms.Button
    Friend WithEvents Path As System.Windows.Forms.TextBox
    Friend WithEvents LoadJAR As System.Windows.Forms.Button
    Friend WithEvents JAR As System.Windows.Forms.TextBox
    Friend WithEvents Output As System.Windows.Forms.TextBox
    Friend WithEvents ServerSwitch As System.Windows.Forms.Button
    Friend WithEvents About As System.Windows.Forms.Button
    Friend WithEvents JAVASwitch As System.Windows.Forms.TrackBar
    Friend WithEvents JAVALabel As System.Windows.Forms.Label
    Friend WithEvents JAVAWLabel As System.Windows.Forms.Label
    Friend WithEvents SpeechButton As System.Windows.Forms.Button
    Friend WithEvents Input As System.Windows.Forms.ComboBox

End Class
