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
        Me.RefreshWorlds = New System.Windows.Forms.Button()
        Me.LoadJAR = New System.Windows.Forms.Button()
        Me.JAR = New System.Windows.Forms.TextBox()
        Me.Output = New System.Windows.Forms.TextBox()
        Me.ServerSwitch = New System.Windows.Forms.Button()
        Me.About = New System.Windows.Forms.Button()
        Me.SpeechButton = New System.Windows.Forms.Button()
        Me.Input = New System.Windows.Forms.ComboBox()
        Me.SettingsButton = New System.Windows.Forms.Button()
        Me.EnvironmentButton = New System.Windows.Forms.Button()
        Me.Worlds = New System.Windows.Forms.ComboBox()
        Me.RestartServer = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'RefreshWorlds
        '
        Me.RefreshWorlds.Location = New System.Drawing.Point(13, 12)
        Me.RefreshWorlds.Name = "RefreshWorlds"
        Me.RefreshWorlds.Size = New System.Drawing.Size(91, 23)
        Me.RefreshWorlds.TabIndex = 0
        Me.RefreshWorlds.Text = "Refresh Worlds"
        Me.RefreshWorlds.UseVisualStyleBackColor = True
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
        Me.JAR.Size = New System.Drawing.Size(406, 20)
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
        Me.Output.Size = New System.Drawing.Size(493, 220)
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
        'SpeechButton
        '
        Me.SpeechButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SpeechButton.Location = New System.Drawing.Point(484, 322)
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
        Me.Input.Items.AddRange(New Object() {"achievement", "ban", "ban-ip", "banlist", "blockdata", "clear", "clone", "debug", "defaultgamemode", "deop", "difficulty", "effect", "enchant", "entitydata", "execute", "fill", "gamemode", "gamerule", "give", "help", "kick", "kill", "list", "me", "op", "pardon", "particle", "playsound", "publish", "replaceitem", "save-all", "save-off", "save-on", "say", "scoreboard", "seed", "setblock", "setidletimeout", "setworldspawn", "spawnpoint", "spreadplayers", "stats", "stop", "summon", "tell", "tellraw", "testfor", "testforblock", "testforblocks", "time", "title", "toggledownfall", "tp", "trigger", "weather", "whitelist", "worldborder", "xp"})
        Me.Input.Location = New System.Drawing.Point(13, 322)
        Me.Input.Name = "Input"
        Me.Input.Size = New System.Drawing.Size(465, 21)
        Me.Input.TabIndex = 11
        '
        'SettingsButton
        '
        Me.SettingsButton.Location = New System.Drawing.Point(184, 67)
        Me.SettingsButton.Name = "SettingsButton"
        Me.SettingsButton.Size = New System.Drawing.Size(75, 23)
        Me.SettingsButton.TabIndex = 12
        Me.SettingsButton.Text = "Settings..."
        Me.SettingsButton.UseVisualStyleBackColor = True
        '
        'EnvironmentButton
        '
        Me.EnvironmentButton.Location = New System.Drawing.Point(265, 67)
        Me.EnvironmentButton.Name = "EnvironmentButton"
        Me.EnvironmentButton.Size = New System.Drawing.Size(83, 23)
        Me.EnvironmentButton.TabIndex = 13
        Me.EnvironmentButton.Text = "Environment..."
        Me.EnvironmentButton.UseVisualStyleBackColor = True
        '
        'Worlds
        '
        Me.Worlds.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Worlds.FormattingEnabled = True
        Me.Worlds.Location = New System.Drawing.Point(111, 14)
        Me.Worlds.Name = "Worlds"
        Me.Worlds.Size = New System.Drawing.Size(395, 21)
        Me.Worlds.TabIndex = 14
        '
        'RestartServer
        '
        Me.RestartServer.Location = New System.Drawing.Point(354, 67)
        Me.RestartServer.Name = "RestartServer"
        Me.RestartServer.Size = New System.Drawing.Size(87, 23)
        Me.RestartServer.TabIndex = 15
        Me.RestartServer.Text = "Restart Server"
        Me.RestartServer.UseVisualStyleBackColor = True
        '
        'Main
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(518, 348)
        Me.Controls.Add(Me.RestartServer)
        Me.Controls.Add(Me.Worlds)
        Me.Controls.Add(Me.EnvironmentButton)
        Me.Controls.Add(Me.SettingsButton)
        Me.Controls.Add(Me.Input)
        Me.Controls.Add(Me.SpeechButton)
        Me.Controls.Add(Me.About)
        Me.Controls.Add(Me.ServerSwitch)
        Me.Controls.Add(Me.Output)
        Me.Controls.Add(Me.JAR)
        Me.Controls.Add(Me.LoadJAR)
        Me.Controls.Add(Me.RefreshWorlds)
        Me.Name = "Main"
        Me.Text = "MCRealm"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents RefreshWorlds As System.Windows.Forms.Button
    Friend WithEvents LoadJAR As System.Windows.Forms.Button
    Friend WithEvents JAR As System.Windows.Forms.TextBox
    Friend WithEvents Output As System.Windows.Forms.TextBox
    Friend WithEvents ServerSwitch As System.Windows.Forms.Button
    Friend WithEvents About As System.Windows.Forms.Button
    Friend WithEvents SpeechButton As System.Windows.Forms.Button
    Friend WithEvents Input As System.Windows.Forms.ComboBox
    Friend WithEvents SettingsButton As System.Windows.Forms.Button
    Friend WithEvents EnvironmentButton As Button
    Friend WithEvents Worlds As ComboBox
    Friend WithEvents RestartServer As Button
End Class
