<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MMLCHelper
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MMLCHelper))
        Dim ListViewGroup1 As System.Windows.Forms.ListViewGroup = New System.Windows.Forms.ListViewGroup("AllProcesses", System.Windows.Forms.HorizontalAlignment.Left)
        Dim ListViewItem1 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(New String() {"d", "ww", "", ""}, -1)
        Dim ListViewItem2 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("")
        Dim ListViewItem3 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("")
        Dim ListViewItem4 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("")
        Me.Tabs = New System.Windows.Forms.TabControl()
        Me.XClassToggler = New System.Windows.Forms.TabPage()
        Me.XCHookInput = New System.Windows.Forms.CheckBox()
        Me.XCAppControl = New System.Windows.Forms.CheckBox()
        Me.XCBlockInternet = New System.Windows.Forms.CheckBox()
        Me.MethodBeta = New System.Windows.Forms.RadioButton()
        Me.MethodAlpha = New System.Windows.Forms.RadioButton()
        Me.Disabled = New System.Windows.Forms.Label()
        Me.Enabled = New System.Windows.Forms.Label()
        Me.Warning = New System.Windows.Forms.Label()
        Me.Toggler = New System.Windows.Forms.TrackBar()
        Me.Minecraft = New System.Windows.Forms.TabPage()
        Me.ProgFiles = New System.Windows.Forms.CheckBox()
        Me.UpdateMC = New System.Windows.Forms.Button()
        Me.AppDataButton = New System.Windows.Forms.Button()
        Me.AppDataPath = New System.Windows.Forms.TextBox()
        Me.AppData = New System.Windows.Forms.CheckBox()
        Me.CreateZip = New System.Windows.Forms.Button()
        Me.InstallDirButton = New System.Windows.Forms.Button()
        Me.InstallDir = New System.Windows.Forms.TextBox()
        Me.InstallDirLabel = New System.Windows.Forms.Label()
        Me.Uninstall = New System.Windows.Forms.Button()
        Me.Install = New System.Windows.Forms.Button()
        Me.DOGE = New System.Windows.Forms.TabPage()
        Me.DOGE2 = New System.Windows.Forms.TextBox()
        Me.DOGESwitch = New System.Windows.Forms.Button()
        Me.DOGE1 = New System.Windows.Forms.Label()
        Me.CHY = New System.Windows.Forms.TabPage()
        Me.CHYLoop = New System.Windows.Forms.CheckBox()
        Me.敬酒歌Stop = New System.Windows.Forms.Button()
        Me.別雲間Stop = New System.Windows.Forms.Button()
        Me.敬酒歌Pause = New System.Windows.Forms.Button()
        Me.別雲間Pause = New System.Windows.Forms.Button()
        Me.敬酒歌Play = New System.Windows.Forms.Button()
        Me.別雲間Play = New System.Windows.Forms.Button()
        Me.別雲間Label = New System.Windows.Forms.Label()
        Me.敬酒歌Label = New System.Windows.Forms.Label()
        Me.ComputerControl = New System.Windows.Forms.TabPage()
        Me.RunProgramWithParamRO = New System.Windows.Forms.CheckBox()
        Me.RunProgramWithParamO = New System.Windows.Forms.TextBox()
        Me.RunProgramWithParamE = New System.Windows.Forms.CheckBox()
        Me.RunProgramWithParamW = New System.Windows.Forms.CheckBox()
        Me.RunProgramWithParamS = New System.Windows.Forms.CheckBox()
        Me.RunProgramWithParamB = New System.Windows.Forms.Button()
        Me.RunProgramWithParamPL = New System.Windows.Forms.Label()
        Me.RunProgramWithParamRL = New System.Windows.Forms.Label()
        Me.RunProgramWithParamP = New System.Windows.Forms.TextBox()
        Me.RunProgramWithParamR = New System.Windows.Forms.TextBox()
        Me.RunProgramWithParam = New System.Windows.Forms.Button()
        Me.RunBatch = New System.Windows.Forms.Button()
        Me.RunCmd = New System.Windows.Forms.Button()
        Me.MiniControlPanelClear = New System.Windows.Forms.Button()
        Me.MiniControlPanel = New System.Windows.Forms.Button()
        Me.HappyBrowerTab = New System.Windows.Forms.TabPage()
        Me.URLLabel = New System.Windows.Forms.Label()
        Me.URL = New System.Windows.Forms.TextBox()
        Me.HappyBrowser = New System.Windows.Forms.WebBrowser()
        Me.Tasks = New System.Windows.Forms.TabPage()
        Me.ProcessAutoRefresh = New System.Windows.Forms.CheckBox()
        Me.Processes = New System.Windows.Forms.ListView()
        Me.ProcessName = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ProcessUser = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ProcessCPU = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ProcessMemory = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ProcessDescription = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ProcessRefresh = New System.Windows.Forms.Button()
        Me.ProcessEnd = New System.Windows.Forms.Button()
        Me.Options = New System.Windows.Forms.TabPage()
        Me.Administrator = New System.Windows.Forms.Label()
        Me.Authenticated = New System.Windows.Forms.Label()
        Me.Authenticate = New System.Windows.Forms.Button()
        Me.Developing = New System.Windows.Forms.Label()
        Me.Autorun = New System.Windows.Forms.CheckBox()
        Me.AutorunBox = New System.Windows.Forms.GroupBox()
        Me.SwitchOptions = New System.Windows.Forms.GroupBox()
        Me.SwitchTimeout = New System.Windows.Forms.NumericUpDown()
        Me.SwitchCommentLabel = New System.Windows.Forms.Label()
        Me.SwitchComment = New System.Windows.Forms.TextBox()
        Me.SwitchForce = New System.Windows.Forms.CheckBox()
        Me.SwitchTimeoutLabel = New System.Windows.Forms.Label()
        Me.SwitchPrograms = New System.Windows.Forms.CheckBox()
        Me.SwitchIfEnabled = New System.Windows.Forms.CheckBox()
        Me.About = New System.Windows.Forms.TabPage()
        Me.TableLayoutPanel = New System.Windows.Forms.TableLayoutPanel()
        Me.LogoPictureBox = New System.Windows.Forms.PictureBox()
        Me.LabelProductName = New System.Windows.Forms.Label()
        Me.LabelVersion = New System.Windows.Forms.Label()
        Me.LabelCopyright = New System.Windows.Forms.Label()
        Me.LabelCompanyName = New System.Windows.Forms.Label()
        Me.TextBoxDescription = New System.Windows.Forms.TextBox()
        Me.OKButton = New System.Windows.Forms.Button()
        Me.InstallDirFinder = New System.Windows.Forms.FolderBrowserDialog()
        Me.AppDataFinder = New System.Windows.Forms.FolderBrowserDialog()
        Me.UpdateMCFinder = New System.Windows.Forms.FolderBrowserDialog()
        Me.ProcessUpdate = New System.Windows.Forms.Timer(Me.components)
        Me.XCTester = New System.Windows.Forms.Timer(Me.components)
        Me.RunProgramWithParamF = New System.Windows.Forms.OpenFileDialog()
        Me.ReloadPage = New System.Windows.Forms.Button()
        Me.SpeakLabel = New System.Windows.Forms.Label()
        Me.Speak = New System.Windows.Forms.TextBox()
        CType(Me.Toggler, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SwitchTimeout, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel.SuspendLayout()
        CType(Me.LogoPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Tabs
        '
        Me.Tabs.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Tabs.Location = New System.Drawing.Point(0, 0)
        Me.Tabs.Margin = New System.Windows.Forms.Padding(4)
        Me.Tabs.Name = "Tabs"
        Me.Tabs.SelectedIndex = 0
        Me.Tabs.Size = New System.Drawing.Size(547, 357)
        Me.Tabs.TabIndex = 4
        '
        'XClassToggler
        '
        Me.XClassToggler.BackColor = System.Drawing.SystemColors.Control
        Me.XClassToggler.Location = New System.Drawing.Point(4, 25)
        Me.XClassToggler.Margin = New System.Windows.Forms.Padding(4)
        Me.XClassToggler.Name = "XClassToggler"
        Me.XClassToggler.Padding = New System.Windows.Forms.Padding(4)
        Me.XClassToggler.Size = New System.Drawing.Size(539, 328)
        Me.XClassToggler.TabIndex = 0
        Me.XClassToggler.Text = "XClassToggler"
        '
        'XCHookInput
        '
        Me.XCHookInput.Appearance = System.Windows.Forms.Appearance.Button
        Me.XCHookInput.AutoSize = True
        Me.XCHookInput.Checked = True
        Me.XCHookInput.CheckState = System.Windows.Forms.CheckState.Checked
        Me.XCHookInput.Location = New System.Drawing.Point(301, 172)
        Me.XCHookInput.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.XCHookInput.Name = "XCHookInput"
        Me.XCHookInput.Size = New System.Drawing.Size(173, 27)
        Me.XCHookInput.TabIndex = 13
        Me.XCHookInput.Text = "Allow blocking user input"
        Me.XCHookInput.UseVisualStyleBackColor = True
        '
        'XCAppControl
        '
        Me.XCAppControl.Appearance = System.Windows.Forms.Appearance.Button
        Me.XCAppControl.AutoSize = True
        Me.XCAppControl.Checked = True
        Me.XCAppControl.CheckState = System.Windows.Forms.CheckState.Checked
        Me.XCAppControl.Location = New System.Drawing.Point(7, 172)
        Me.XCAppControl.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.XCAppControl.Name = "XCAppControl"
        Me.XCAppControl.Size = New System.Drawing.Size(125, 27)
        Me.XCAppControl.TabIndex = 12
        Me.XCAppControl.Text = "Allow app control"
        Me.XCAppControl.UseVisualStyleBackColor = True
        '
        'XCBlockInternet
        '
        Me.XCBlockInternet.Appearance = System.Windows.Forms.Appearance.Button
        Me.XCBlockInternet.AutoSize = True
        Me.XCBlockInternet.Checked = True
        Me.XCBlockInternet.CheckState = System.Windows.Forms.CheckState.Checked
        Me.XCBlockInternet.Location = New System.Drawing.Point(139, 172)
        Me.XCBlockInternet.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.XCBlockInternet.Name = "XCBlockInternet"
        Me.XCBlockInternet.Size = New System.Drawing.Size(158, 27)
        Me.XCBlockInternet.TabIndex = 11
        Me.XCBlockInternet.Text = "Allow blocking internet"
        Me.XCBlockInternet.UseVisualStyleBackColor = True
        '
        'MethodBeta
        '
        Me.MethodBeta.Appearance = System.Windows.Forms.Appearance.Button
        Me.MethodBeta.AutoSize = True
        Me.MethodBeta.Location = New System.Drawing.Point(9, 139)
        Me.MethodBeta.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.MethodBeta.Name = "MethodBeta"
        Me.MethodBeta.Size = New System.Drawing.Size(527, 27)
        Me.MethodBeta.TabIndex = 10
        Me.MethodBeta.TabStop = True
        Me.MethodBeta.Text = "Use experimental beta method (not guaranteed to work, does not require restart)"
        Me.MethodBeta.UseVisualStyleBackColor = True
        '
        'MethodAlpha
        '
        Me.MethodAlpha.Appearance = System.Windows.Forms.Appearance.Button
        Me.MethodAlpha.AutoSize = True
        Me.MethodAlpha.Location = New System.Drawing.Point(107, 106)
        Me.MethodAlpha.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.MethodAlpha.Name = "MethodAlpha"
        Me.MethodAlpha.Size = New System.Drawing.Size(315, 27)
        Me.MethodAlpha.TabIndex = 9
        Me.MethodAlpha.TabStop = True
        Me.MethodAlpha.Text = "Use traditional alpha method (Requires restart)"
        Me.MethodAlpha.UseVisualStyleBackColor = True
        '
        'Disabled
        '
        Me.Disabled.AutoSize = True
        Me.Disabled.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Disabled.Location = New System.Drawing.Point(361, 63)
        Me.Disabled.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Disabled.Name = "Disabled"
        Me.Disabled.Size = New System.Drawing.Size(159, 39)
        Me.Disabled.TabIndex = 8
        Me.Disabled.Text = "Disabled"
        '
        'Enabled
        '
        Me.Enabled.AutoSize = True
        Me.Enabled.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Enabled.Location = New System.Drawing.Point(8, 63)
        Me.Enabled.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Enabled.Name = "Enabled"
        Me.Enabled.Size = New System.Drawing.Size(150, 39)
        Me.Enabled.TabIndex = 7
        Me.Enabled.Text = "Enabled"
        '
        'Warning
        '
        Me.Warning.AutoSize = True
        Me.Warning.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Warning.ForeColor = System.Drawing.Color.Red
        Me.Warning.Location = New System.Drawing.Point(100, 250)
        Me.Warning.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Warning.Name = "Warning"
        Me.Warning.Size = New System.Drawing.Size(359, 39)
        Me.Warning.TabIndex = 6
        Me.Warning.Text = "Changes not applied!"
        Me.Warning.Visible = False
        '
        'Toggler
        '
        Me.Toggler.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Toggler.BackColor = System.Drawing.SystemColors.Control
        Me.Toggler.LargeChange = 1
        Me.Toggler.Location = New System.Drawing.Point(47, 31)
        Me.Toggler.Margin = New System.Windows.Forms.Padding(4)
        Me.Toggler.Maximum = 1
        Me.Toggler.Name = "Toggler"
        Me.Toggler.Size = New System.Drawing.Size(416, 45)
        Me.Toggler.TabIndex = 5
        '
        'Minecraft
        '
        Me.Minecraft.BackColor = System.Drawing.SystemColors.Control
        Me.Minecraft.Location = New System.Drawing.Point(4, 25)
        Me.Minecraft.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Minecraft.Name = "Minecraft"
        Me.Minecraft.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Minecraft.Size = New System.Drawing.Size(539, 328)
        Me.Minecraft.TabIndex = 3
        Me.Minecraft.Text = "Minecraft"
        '
        'ProgFiles
        '
        Me.ProgFiles.Appearance = System.Windows.Forms.Appearance.Button
        Me.ProgFiles.AutoSize = True
        Me.ProgFiles.Checked = True
        Me.ProgFiles.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ProgFiles.Location = New System.Drawing.Point(265, 92)
        Me.ProgFiles.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.ProgFiles.Name = "ProgFiles"
        Me.ProgFiles.Size = New System.Drawing.Size(196, 27)
        Me.ProgFiles.TabIndex = 10
        Me.ProgFiles.Text = "Use Program Files\Minecraft"
        Me.ProgFiles.UseVisualStyleBackColor = True
        '
        'UpdateMC
        '
        Me.UpdateMC.Location = New System.Drawing.Point(96, 224)
        Me.UpdateMC.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.UpdateMC.Name = "UpdateMC"
        Me.UpdateMC.Size = New System.Drawing.Size(173, 23)
        Me.UpdateMC.TabIndex = 9
        Me.UpdateMC.Text = "Update versions"
        Me.UpdateMC.UseVisualStyleBackColor = True
        '
        'AppDataButton
        '
        Me.AppDataButton.Location = New System.Drawing.Point(491, 181)
        Me.AppDataButton.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.AppDataButton.Name = "AppDataButton"
        Me.AppDataButton.Size = New System.Drawing.Size(23, 23)
        Me.AppDataButton.TabIndex = 8
        Me.AppDataButton.Text = "…"
        Me.AppDataButton.UseVisualStyleBackColor = True
        '
        'AppDataPath
        '
        Me.AppDataPath.Enabled = False
        Me.AppDataPath.Location = New System.Drawing.Point(91, 182)
        Me.AppDataPath.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.AppDataPath.Name = "AppDataPath"
        Me.AppDataPath.Size = New System.Drawing.Size(393, 26)
        Me.AppDataPath.TabIndex = 7
        '
        'AppData
        '
        Me.AppData.Appearance = System.Windows.Forms.Appearance.Button
        Me.AppData.AutoSize = True
        Me.AppData.Checked = True
        Me.AppData.CheckState = System.Windows.Forms.CheckState.Checked
        Me.AppData.Location = New System.Drawing.Point(265, 149)
        Me.AppData.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.AppData.Name = "AppData"
        Me.AppData.Size = New System.Drawing.Size(168, 27)
        Me.AppData.TabIndex = 6
        Me.AppData.Text = "Use AppData\.minecraft"
        Me.AppData.UseVisualStyleBackColor = True
        '
        'CreateZip
        '
        Me.CreateZip.Location = New System.Drawing.Point(96, 254)
        Me.CreateZip.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.CreateZip.Name = "CreateZip"
        Me.CreateZip.Size = New System.Drawing.Size(388, 26)
        Me.CreateZip.TabIndex = 5
        Me.CreateZip.Text = "Create Minecraft.zip"
        Me.CreateZip.UseVisualStyleBackColor = True
        '
        'InstallDirButton
        '
        Me.InstallDirButton.Location = New System.Drawing.Point(491, 126)
        Me.InstallDirButton.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.InstallDirButton.Name = "InstallDirButton"
        Me.InstallDirButton.Size = New System.Drawing.Size(23, 23)
        Me.InstallDirButton.TabIndex = 4
        Me.InstallDirButton.Text = "…"
        Me.InstallDirButton.UseVisualStyleBackColor = True
        '
        'InstallDir
        '
        Me.InstallDir.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.FileSystemDirectories
        Me.InstallDir.Location = New System.Drawing.Point(91, 126)
        Me.InstallDir.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.InstallDir.Name = "InstallDir"
        Me.InstallDir.Size = New System.Drawing.Size(393, 26)
        Me.InstallDir.TabIndex = 3
        '
        'InstallDirLabel
        '
        Me.InstallDirLabel.AutoSize = True
        Me.InstallDirLabel.Location = New System.Drawing.Point(195, 97)
        Me.InstallDirLabel.Name = "InstallDirLabel"
        Me.InstallDirLabel.Size = New System.Drawing.Size(64, 17)
        Me.InstallDirLabel.TabIndex = 2
        Me.InstallDirLabel.Text = "Install to:"
        '
        'Uninstall
        '
        Me.Uninstall.Location = New System.Drawing.Point(291, 47)
        Me.Uninstall.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Uninstall.Name = "Uninstall"
        Me.Uninstall.Size = New System.Drawing.Size(75, 23)
        Me.Uninstall.TabIndex = 1
        Me.Uninstall.Text = "Uninstall"
        Me.Uninstall.UseVisualStyleBackColor = True
        '
        'Install
        '
        Me.Install.Location = New System.Drawing.Point(96, 47)
        Me.Install.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Install.Name = "Install"
        Me.Install.Size = New System.Drawing.Size(75, 23)
        Me.Install.TabIndex = 0
        Me.Install.Text = "Install"
        Me.Install.UseVisualStyleBackColor = True
        '
        'DOGE
        '
        Me.DOGE.Location = New System.Drawing.Point(4, 25)
        Me.DOGE.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.DOGE.Name = "DOGE"
        Me.DOGE.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.DOGE.Size = New System.Drawing.Size(539, 328)
        Me.DOGE.TabIndex = 4
        Me.DOGE.Text = "DOGE"
        Me.DOGE.UseVisualStyleBackColor = True
        '
        'DOGE2
        '
        Me.DOGE2.BackColor = System.Drawing.Color.White
        Me.DOGE2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.DOGE2.Location = New System.Drawing.Point(0, 2)
        Me.DOGE2.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.DOGE2.Multiline = True
        Me.DOGE2.Name = "DOGE2"
        Me.DOGE2.ReadOnly = True
        Me.DOGE2.Size = New System.Drawing.Size(335, 335)
        Me.DOGE2.TabIndex = 2
        Me.DOGE2.Text = resources.GetString("DOGE2.Text")
        Me.DOGE2.Visible = False
        '
        'DOGESwitch
        '
        Me.DOGESwitch.Location = New System.Drawing.Point(517, 2)
        Me.DOGESwitch.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.DOGESwitch.Name = "DOGESwitch"
        Me.DOGESwitch.Size = New System.Drawing.Size(21, 23)
        Me.DOGESwitch.TabIndex = 1
        Me.DOGESwitch.UseVisualStyleBackColor = True
        '
        'DOGE1
        '
        Me.DOGE1.AutoSize = True
        Me.DOGE1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DOGE1.Location = New System.Drawing.Point(3, 2)
        Me.DOGE1.Name = "DOGE1"
        Me.DOGE1.Size = New System.Drawing.Size(285, 323)
        Me.DOGE1.TabIndex = 0
        Me.DOGE1.Text = resources.GetString("DOGE1.Text")
        '
        'CHY
        '
        Me.CHY.Location = New System.Drawing.Point(4, 25)
        Me.CHY.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.CHY.Name = "CHY"
        Me.CHY.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.CHY.Size = New System.Drawing.Size(539, 328)
        Me.CHY.TabIndex = 5
        Me.CHY.Text = "CHY"
        Me.CHY.UseVisualStyleBackColor = True
        '
        'CHYLoop
        '
        Me.CHYLoop.Appearance = System.Windows.Forms.Appearance.Button
        Me.CHYLoop.AutoSize = True
        Me.CHYLoop.Location = New System.Drawing.Point(248, 41)
        Me.CHYLoop.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.CHYLoop.Name = "CHYLoop"
        Me.CHYLoop.Size = New System.Drawing.Size(50, 27)
        Me.CHYLoop.TabIndex = 10
        Me.CHYLoop.Text = "Loop"
        Me.CHYLoop.UseVisualStyleBackColor = True
        '
        '敬酒歌Stop
        '
        Me.敬酒歌Stop.Location = New System.Drawing.Point(299, 128)
        Me.敬酒歌Stop.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.敬酒歌Stop.Name = "敬酒歌Stop"
        Me.敬酒歌Stop.Size = New System.Drawing.Size(33, 33)
        Me.敬酒歌Stop.TabIndex = 9
        Me.敬酒歌Stop.Text = "■"
        Me.敬酒歌Stop.UseVisualStyleBackColor = True
        '
        '別雲間Stop
        '
        Me.別雲間Stop.Location = New System.Drawing.Point(299, 73)
        Me.別雲間Stop.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.別雲間Stop.Name = "別雲間Stop"
        Me.別雲間Stop.Size = New System.Drawing.Size(33, 33)
        Me.別雲間Stop.TabIndex = 8
        Me.別雲間Stop.Text = "■"
        Me.別雲間Stop.UseVisualStyleBackColor = True
        '
        '敬酒歌Pause
        '
        Me.敬酒歌Pause.AutoSize = True
        Me.敬酒歌Pause.Enabled = False
        Me.敬酒歌Pause.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.敬酒歌Pause.Location = New System.Drawing.Point(265, 128)
        Me.敬酒歌Pause.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.敬酒歌Pause.Name = "敬酒歌Pause"
        Me.敬酒歌Pause.Size = New System.Drawing.Size(37, 33)
        Me.敬酒歌Pause.TabIndex = 7
        Me.敬酒歌Pause.Text = "| |"
        Me.敬酒歌Pause.UseVisualStyleBackColor = True
        '
        '別雲間Pause
        '
        Me.別雲間Pause.Enabled = False
        Me.別雲間Pause.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.別雲間Pause.Location = New System.Drawing.Point(265, 73)
        Me.別雲間Pause.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.別雲間Pause.Name = "別雲間Pause"
        Me.別雲間Pause.Size = New System.Drawing.Size(33, 33)
        Me.別雲間Pause.TabIndex = 6
        Me.別雲間Pause.Text = "| |"
        Me.別雲間Pause.UseVisualStyleBackColor = True
        '
        '敬酒歌Play
        '
        Me.敬酒歌Play.AutoSize = True
        Me.敬酒歌Play.Location = New System.Drawing.Point(232, 128)
        Me.敬酒歌Play.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.敬酒歌Play.Name = "敬酒歌Play"
        Me.敬酒歌Play.Size = New System.Drawing.Size(33, 33)
        Me.敬酒歌Play.TabIndex = 5
        Me.敬酒歌Play.Text = "▶"
        Me.敬酒歌Play.UseVisualStyleBackColor = True
        '
        '別雲間Play
        '
        Me.別雲間Play.AutoSize = True
        Me.別雲間Play.Location = New System.Drawing.Point(232, 73)
        Me.別雲間Play.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.別雲間Play.Name = "別雲間Play"
        Me.別雲間Play.Size = New System.Drawing.Size(33, 33)
        Me.別雲間Play.TabIndex = 4
        Me.別雲間Play.Text = "▶"
        Me.別雲間Play.UseVisualStyleBackColor = True
        '
        '別雲間Label
        '
        Me.別雲間Label.AutoSize = True
        Me.別雲間Label.Location = New System.Drawing.Point(157, 73)
        Me.別雲間Label.Name = "別雲間Label"
        Me.別雲間Label.Size = New System.Drawing.Size(50, 17)
        Me.別雲間Label.TabIndex = 3
        Me.別雲間Label.Text = "別雲間"
        '
        '敬酒歌Label
        '
        Me.敬酒歌Label.AutoSize = True
        Me.敬酒歌Label.Location = New System.Drawing.Point(157, 133)
        Me.敬酒歌Label.Name = "敬酒歌Label"
        Me.敬酒歌Label.Size = New System.Drawing.Size(50, 17)
        Me.敬酒歌Label.TabIndex = 2
        Me.敬酒歌Label.Text = "敬酒歌"
        '
        'ComputerControl
        '
        Me.ComputerControl.Location = New System.Drawing.Point(4, 25)
        Me.ComputerControl.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.ComputerControl.Name = "ComputerControl"
        Me.ComputerControl.Size = New System.Drawing.Size(539, 328)
        Me.ComputerControl.TabIndex = 7
        Me.ComputerControl.Text = "Computer Control"
        Me.ComputerControl.UseVisualStyleBackColor = True
        '
        'RunProgramWithParamRO
        '
        Me.RunProgramWithParamRO.AutoSize = True
        Me.RunProgramWithParamRO.Checked = True
        Me.RunProgramWithParamRO.CheckState = System.Windows.Forms.CheckState.Checked
        Me.RunProgramWithParamRO.Location = New System.Drawing.Point(405, 93)
        Me.RunProgramWithParamRO.Name = "RunProgramWithParamRO"
        Me.RunProgramWithParamRO.Size = New System.Drawing.Size(130, 21)
        Me.RunProgramWithParamRO.TabIndex = 14
        Me.RunProgramWithParamRO.Text = "Redirect Output"
        Me.RunProgramWithParamRO.UseVisualStyleBackColor = True
        '
        'RunProgramWithParamO
        '
        Me.RunProgramWithParamO.Cursor = System.Windows.Forms.Cursors.Default
        Me.RunProgramWithParamO.Location = New System.Drawing.Point(4, 118)
        Me.RunProgramWithParamO.Multiline = True
        Me.RunProgramWithParamO.Name = "RunProgramWithParamO"
        Me.RunProgramWithParamO.ReadOnly = True
        Me.RunProgramWithParamO.Size = New System.Drawing.Size(527, 80)
        Me.RunProgramWithParamO.TabIndex = 13
        '
        'RunProgramWithParamE
        '
        Me.RunProgramWithParamE.AutoSize = True
        Me.RunProgramWithParamE.Checked = True
        Me.RunProgramWithParamE.CheckState = System.Windows.Forms.CheckState.Checked
        Me.RunProgramWithParamE.Location = New System.Drawing.Point(290, 92)
        Me.RunProgramWithParamE.Name = "RunProgramWithParamE"
        Me.RunProgramWithParamE.Size = New System.Drawing.Size(113, 21)
        Me.RunProgramWithParamE.TabIndex = 12
        Me.RunProgramWithParamE.Text = "Raise Events"
        Me.RunProgramWithParamE.UseVisualStyleBackColor = True
        '
        'RunProgramWithParamW
        '
        Me.RunProgramWithParamW.AutoSize = True
        Me.RunProgramWithParamW.Checked = True
        Me.RunProgramWithParamW.CheckState = System.Windows.Forms.CheckState.Checked
        Me.RunProgramWithParamW.Location = New System.Drawing.Point(158, 90)
        Me.RunProgramWithParamW.Name = "RunProgramWithParamW"
        Me.RunProgramWithParamW.Size = New System.Drawing.Size(125, 21)
        Me.RunProgramWithParamW.TabIndex = 11
        Me.RunProgramWithParamW.Text = "Create Window"
        Me.RunProgramWithParamW.UseVisualStyleBackColor = True
        '
        'RunProgramWithParamS
        '
        Me.RunProgramWithParamS.AutoSize = True
        Me.RunProgramWithParamS.Location = New System.Drawing.Point(9, 90)
        Me.RunProgramWithParamS.Name = "RunProgramWithParamS"
        Me.RunProgramWithParamS.Size = New System.Drawing.Size(144, 21)
        Me.RunProgramWithParamS.TabIndex = 10
        Me.RunProgramWithParamS.Text = "Use Shell Execute"
        Me.RunProgramWithParamS.UseVisualStyleBackColor = True
        '
        'RunProgramWithParamB
        '
        Me.RunProgramWithParamB.Location = New System.Drawing.Point(509, 35)
        Me.RunProgramWithParamB.Name = "RunProgramWithParamB"
        Me.RunProgramWithParamB.Size = New System.Drawing.Size(20, 23)
        Me.RunProgramWithParamB.TabIndex = 9
        Me.RunProgramWithParamB.Text = "…"
        Me.RunProgramWithParamB.UseVisualStyleBackColor = True
        '
        'RunProgramWithParamPL
        '
        Me.RunProgramWithParamPL.AutoSize = True
        Me.RunProgramWithParamPL.Location = New System.Drawing.Point(5, 69)
        Me.RunProgramWithParamPL.Name = "RunProgramWithParamPL"
        Me.RunProgramWithParamPL.Size = New System.Drawing.Size(147, 17)
        Me.RunProgramWithParamPL.TabIndex = 8
        Me.RunProgramWithParamPL.Text = "with these parameters"
        '
        'RunProgramWithParamRL
        '
        Me.RunProgramWithParamRL.AutoSize = True
        Me.RunProgramWithParamRL.Location = New System.Drawing.Point(9, 39)
        Me.RunProgramWithParamRL.Name = "RunProgramWithParamRL"
        Me.RunProgramWithParamRL.Size = New System.Drawing.Size(117, 17)
        Me.RunProgramWithParamRL.TabIndex = 7
        Me.RunProgramWithParamRL.Text = "Run this program"
        '
        'RunProgramWithParamP
        '
        Me.RunProgramWithParamP.Location = New System.Drawing.Point(158, 63)
        Me.RunProgramWithParamP.Name = "RunProgramWithParamP"
        Me.RunProgramWithParamP.Size = New System.Drawing.Size(238, 26)
        Me.RunProgramWithParamP.TabIndex = 6
        '
        'RunProgramWithParamR
        '
        Me.RunProgramWithParamR.Location = New System.Drawing.Point(132, 35)
        Me.RunProgramWithParamR.Name = "RunProgramWithParamR"
        Me.RunProgramWithParamR.Size = New System.Drawing.Size(371, 26)
        Me.RunProgramWithParamR.TabIndex = 5
        '
        'RunProgramWithParam
        '
        Me.RunProgramWithParam.Location = New System.Drawing.Point(405, 63)
        Me.RunProgramWithParam.Name = "RunProgramWithParam"
        Me.RunProgramWithParam.Size = New System.Drawing.Size(125, 23)
        Me.RunProgramWithParam.TabIndex = 4
        Me.RunProgramWithParam.Text = "Run the program"
        Me.RunProgramWithParam.UseVisualStyleBackColor = True
        '
        'RunBatch
        '
        Me.RunBatch.Location = New System.Drawing.Point(405, 4)
        Me.RunBatch.Margin = New System.Windows.Forms.Padding(4)
        Me.RunBatch.Name = "RunBatch"
        Me.RunBatch.Size = New System.Drawing.Size(125, 23)
        Me.RunBatch.TabIndex = 3
        Me.RunBatch.Text = "Run Batch Mode"
        Me.RunBatch.UseVisualStyleBackColor = True
        '
        'RunCmd
        '
        Me.RunCmd.Location = New System.Drawing.Point(191, 4)
        Me.RunCmd.Margin = New System.Windows.Forms.Padding(4)
        Me.RunCmd.Name = "RunCmd"
        Me.RunCmd.Size = New System.Drawing.Size(205, 23)
        Me.RunCmd.TabIndex = 2
        Me.RunCmd.Text = "Run Command Prompt Mode"
        Me.RunCmd.UseVisualStyleBackColor = True
        '
        'MiniControlPanelClear
        '
        Me.MiniControlPanelClear.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MiniControlPanelClear.Location = New System.Drawing.Point(161, 2)
        Me.MiniControlPanelClear.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.MiniControlPanelClear.Name = "MiniControlPanelClear"
        Me.MiniControlPanelClear.Size = New System.Drawing.Size(23, 23)
        Me.MiniControlPanelClear.TabIndex = 1
        Me.MiniControlPanelClear.Text = "ⓧ"
        Me.MiniControlPanelClear.UseVisualStyleBackColor = True
        '
        'MiniControlPanel
        '
        Me.MiniControlPanel.Location = New System.Drawing.Point(8, 2)
        Me.MiniControlPanel.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.MiniControlPanel.Name = "MiniControlPanel"
        Me.MiniControlPanel.Size = New System.Drawing.Size(148, 23)
        Me.MiniControlPanel.TabIndex = 0
        Me.MiniControlPanel.Text = "Mini-Control Panel"
        Me.MiniControlPanel.UseVisualStyleBackColor = True
        '
        'HappyBrowerTab
        '
        Me.HappyBrowerTab.Location = New System.Drawing.Point(4, 25)
        Me.HappyBrowerTab.Name = "HappyBrowerTab"
        Me.HappyBrowerTab.Padding = New System.Windows.Forms.Padding(3)
        Me.HappyBrowerTab.Size = New System.Drawing.Size(539, 328)
        Me.HappyBrowerTab.TabIndex = 8
        Me.HappyBrowerTab.Text = "HappyBrowser"
        Me.HappyBrowerTab.UseVisualStyleBackColor = True
        '
        'URLLabel
        '
        Me.URLLabel.AutoSize = True
        Me.URLLabel.Location = New System.Drawing.Point(0, 6)
        Me.URLLabel.Name = "URLLabel"
        Me.URLLabel.Size = New System.Drawing.Size(36, 17)
        Me.URLLabel.TabIndex = 2
        Me.URLLabel.Text = "URL"
        '
        'URL
        '
        Me.URL.Location = New System.Drawing.Point(32, 3)
        Me.URL.Name = "URL"
        Me.URL.Size = New System.Drawing.Size(486, 26)
        Me.URL.TabIndex = 1
        '
        'HappyBrowser
        '
        Me.HappyBrowser.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.HappyBrowser.Location = New System.Drawing.Point(3, 25)
        Me.HappyBrowser.MinimumSize = New System.Drawing.Size(20, 20)
        Me.HappyBrowser.Name = "HappyBrowser"
        Me.HappyBrowser.ScriptErrorsSuppressed = True
        Me.HappyBrowser.Size = New System.Drawing.Size(533, 300)
        Me.HappyBrowser.TabIndex = 0
        '
        'Tasks
        '
        Me.Tasks.Location = New System.Drawing.Point(4, 25)
        Me.Tasks.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Tasks.Name = "Tasks"
        Me.Tasks.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Tasks.Size = New System.Drawing.Size(539, 328)
        Me.Tasks.TabIndex = 6
        Me.Tasks.Text = "Tasks"
        Me.Tasks.UseVisualStyleBackColor = True
        '
        'ProcessAutoRefresh
        '
        Me.ProcessAutoRefresh.Appearance = System.Windows.Forms.Appearance.Button
        Me.ProcessAutoRefresh.AutoSize = True
        Me.ProcessAutoRefresh.Location = New System.Drawing.Point(91, 295)
        Me.ProcessAutoRefresh.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.ProcessAutoRefresh.Name = "ProcessAutoRefresh"
        Me.ProcessAutoRefresh.Size = New System.Drawing.Size(101, 27)
        Me.ProcessAutoRefresh.TabIndex = 4
        Me.ProcessAutoRefresh.Text = "Auto Refresh"
        Me.ProcessAutoRefresh.UseVisualStyleBackColor = True
        '
        'Processes
        '
        Me.Processes.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ProcessName, Me.ProcessUser, Me.ProcessCPU, Me.ProcessMemory, Me.ProcessDescription})
        ListViewGroup1.Header = "AllProcesses"
        ListViewGroup1.Name = "All Processes"
        Me.Processes.Groups.AddRange(New System.Windows.Forms.ListViewGroup() {ListViewGroup1})
        Me.Processes.Items.AddRange(New System.Windows.Forms.ListViewItem() {ListViewItem1, ListViewItem2, ListViewItem3, ListViewItem4})
        Me.Processes.Location = New System.Drawing.Point(8, 6)
        Me.Processes.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Processes.Name = "Processes"
        Me.Processes.Size = New System.Drawing.Size(523, 285)
        Me.Processes.TabIndex = 3
        Me.Processes.UseCompatibleStateImageBehavior = False
        Me.Processes.View = System.Windows.Forms.View.Details
        '
        'ProcessName
        '
        Me.ProcessName.Text = "Image Name"
        Me.ProcessName.Width = 170
        '
        'ProcessUser
        '
        Me.ProcessUser.Text = "User Name"
        Me.ProcessUser.Width = 90
        '
        'ProcessCPU
        '
        Me.ProcessCPU.Text = "CPU"
        Me.ProcessCPU.Width = 40
        '
        'ProcessMemory
        '
        Me.ProcessMemory.Text = "Memory"
        Me.ProcessMemory.Width = 100
        '
        'ProcessDescription
        '
        Me.ProcessDescription.Text = "Description"
        Me.ProcessDescription.Width = 120
        '
        'ProcessRefresh
        '
        Me.ProcessRefresh.Location = New System.Drawing.Point(197, 295)
        Me.ProcessRefresh.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.ProcessRefresh.Name = "ProcessRefresh"
        Me.ProcessRefresh.Size = New System.Drawing.Size(100, 27)
        Me.ProcessRefresh.TabIndex = 2
        Me.ProcessRefresh.Text = "Refresh"
        Me.ProcessRefresh.UseVisualStyleBackColor = True
        '
        'ProcessEnd
        '
        Me.ProcessEnd.Location = New System.Drawing.Point(317, 295)
        Me.ProcessEnd.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.ProcessEnd.Name = "ProcessEnd"
        Me.ProcessEnd.Size = New System.Drawing.Size(100, 27)
        Me.ProcessEnd.TabIndex = 1
        Me.ProcessEnd.Text = "End Process"
        Me.ProcessEnd.UseVisualStyleBackColor = True
        '
        'Options
        '
        Me.Options.BackColor = System.Drawing.SystemColors.Control
        Me.Options.Location = New System.Drawing.Point(4, 25)
        Me.Options.Margin = New System.Windows.Forms.Padding(4)
        Me.Options.Name = "Options"
        Me.Options.Size = New System.Drawing.Size(539, 328)
        Me.Options.TabIndex = 2
        Me.Options.Text = "Options"
        '
        'Administrator
        '
        Me.Administrator.AutoSize = True
        Me.Administrator.Location = New System.Drawing.Point(8, 250)
        Me.Administrator.Name = "Administrator"
        Me.Administrator.Size = New System.Drawing.Size(32, 17)
        Me.Administrator.TabIndex = 5
        Me.Administrator.Text = "      "
        '
        'Authenticated
        '
        Me.Authenticated.AutoSize = True
        Me.Authenticated.Location = New System.Drawing.Point(8, 233)
        Me.Authenticated.Name = "Authenticated"
        Me.Authenticated.Size = New System.Drawing.Size(32, 17)
        Me.Authenticated.TabIndex = 4
        Me.Authenticated.Text = "      "
        '
        'Authenticate
        '
        Me.Authenticate.Location = New System.Drawing.Point(4, 207)
        Me.Authenticate.Name = "Authenticate"
        Me.Authenticate.Size = New System.Drawing.Size(95, 23)
        Me.Authenticate.TabIndex = 3
        Me.Authenticate.Text = "Authenticate"
        Me.Authenticate.UseVisualStyleBackColor = True
        Me.Authenticate.Visible = False
        '
        'Developing
        '
        Me.Developing.AutoSize = True
        Me.Developing.Location = New System.Drawing.Point(151, 210)
        Me.Developing.Name = "Developing"
        Me.Developing.Size = New System.Drawing.Size(238, 34)
        Me.Developing.TabIndex = 2
        Me.Developing.Text = "This tab page is under development!" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "It's not working right now."
        '
        'Autorun
        '
        Me.Autorun.AutoSize = True
        Me.Autorun.Location = New System.Drawing.Point(4, 4)
        Me.Autorun.Margin = New System.Windows.Forms.Padding(4)
        Me.Autorun.Name = "Autorun"
        Me.Autorun.Size = New System.Drawing.Size(80, 21)
        Me.Autorun.TabIndex = 0
        Me.Autorun.Text = "Autorun"
        Me.Autorun.UseVisualStyleBackColor = True
        '
        'AutorunBox
        '
        Me.AutorunBox.Location = New System.Drawing.Point(96, 4)
        Me.AutorunBox.Margin = New System.Windows.Forms.Padding(4)
        Me.AutorunBox.Name = "AutorunBox"
        Me.AutorunBox.Padding = New System.Windows.Forms.Padding(4)
        Me.AutorunBox.Size = New System.Drawing.Size(347, 134)
        Me.AutorunBox.TabIndex = 1
        Me.AutorunBox.TabStop = False
        Me.AutorunBox.Text = "Autorun options"
        '
        'SwitchOptions
        '
        Me.SwitchOptions.Location = New System.Drawing.Point(8, 43)
        Me.SwitchOptions.Margin = New System.Windows.Forms.Padding(4)
        Me.SwitchOptions.Name = "SwitchOptions"
        Me.SwitchOptions.Padding = New System.Windows.Forms.Padding(4)
        Me.SwitchOptions.Size = New System.Drawing.Size(331, 84)
        Me.SwitchOptions.TabIndex = 1
        Me.SwitchOptions.TabStop = False
        Me.SwitchOptions.Text = "Options"
        '
        'SwitchTimeout
        '
        Me.SwitchTimeout.Location = New System.Drawing.Point(108, 58)
        Me.SwitchTimeout.Margin = New System.Windows.Forms.Padding(4)
        Me.SwitchTimeout.Maximum = New Decimal(New Integer() {315360000, 0, 0, 0})
        Me.SwitchTimeout.Name = "SwitchTimeout"
        Me.SwitchTimeout.Size = New System.Drawing.Size(101, 26)
        Me.SwitchTimeout.TabIndex = 6
        Me.SwitchTimeout.Tag = "/t [num]"
        '
        'SwitchCommentLabel
        '
        Me.SwitchCommentLabel.AutoSize = True
        Me.SwitchCommentLabel.Location = New System.Drawing.Point(213, 5)
        Me.SwitchCommentLabel.Name = "SwitchCommentLabel"
        Me.SwitchCommentLabel.Size = New System.Drawing.Size(117, 17)
        Me.SwitchCommentLabel.TabIndex = 5
        Me.SwitchCommentLabel.Text = "Restart Comment"
        '
        'SwitchComment
        '
        Me.SwitchComment.Location = New System.Drawing.Point(219, 26)
        Me.SwitchComment.Margin = New System.Windows.Forms.Padding(4)
        Me.SwitchComment.MaxLength = 512
        Me.SwitchComment.Multiline = True
        Me.SwitchComment.Name = "SwitchComment"
        Me.SwitchComment.Size = New System.Drawing.Size(105, 50)
        Me.SwitchComment.TabIndex = 4
        Me.SwitchComment.Tag = "/c [comment]"
        '
        'SwitchForce
        '
        Me.SwitchForce.Appearance = System.Windows.Forms.Appearance.Button
        Me.SwitchForce.AutoSize = True
        Me.SwitchForce.Location = New System.Drawing.Point(148, 25)
        Me.SwitchForce.Margin = New System.Windows.Forms.Padding(4)
        Me.SwitchForce.Name = "SwitchForce"
        Me.SwitchForce.Size = New System.Drawing.Size(54, 27)
        Me.SwitchForce.TabIndex = 3
        Me.SwitchForce.Tag = "/f"
        Me.SwitchForce.Text = "Force"
        Me.SwitchForce.UseVisualStyleBackColor = True
        '
        'SwitchTimeoutLabel
        '
        Me.SwitchTimeoutLabel.AutoSize = True
        Me.SwitchTimeoutLabel.Location = New System.Drawing.Point(9, 60)
        Me.SwitchTimeoutLabel.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.SwitchTimeoutLabel.Name = "SwitchTimeoutLabel"
        Me.SwitchTimeoutLabel.Size = New System.Drawing.Size(95, 17)
        Me.SwitchTimeoutLabel.TabIndex = 2
        Me.SwitchTimeoutLabel.Text = "Timeout (sec)"
        '
        'SwitchPrograms
        '
        Me.SwitchPrograms.Appearance = System.Windows.Forms.Appearance.Button
        Me.SwitchPrograms.AutoSize = True
        Me.SwitchPrograms.Location = New System.Drawing.Point(8, 23)
        Me.SwitchPrograms.Margin = New System.Windows.Forms.Padding(4)
        Me.SwitchPrograms.Name = "SwitchPrograms"
        Me.SwitchPrograms.Size = New System.Drawing.Size(129, 27)
        Me.SwitchPrograms.TabIndex = 0
        Me.SwitchPrograms.Tag = "equals to /g, else /r"
        Me.SwitchPrograms.Text = "Restart Programs"
        Me.SwitchPrograms.UseVisualStyleBackColor = True
        '
        'SwitchIfEnabled
        '
        Me.SwitchIfEnabled.AutoSize = True
        Me.SwitchIfEnabled.Location = New System.Drawing.Point(8, 23)
        Me.SwitchIfEnabled.Margin = New System.Windows.Forms.Padding(4)
        Me.SwitchIfEnabled.Name = "SwitchIfEnabled"
        Me.SwitchIfEnabled.Size = New System.Drawing.Size(332, 21)
        Me.SwitchIfEnabled.TabIndex = 0
        Me.SwitchIfEnabled.Text = "Immediately switch and restart if XClass enabled"
        Me.SwitchIfEnabled.UseVisualStyleBackColor = True
        '
        'About
        '
        Me.About.BackColor = System.Drawing.SystemColors.Control
        Me.About.Location = New System.Drawing.Point(4, 25)
        Me.About.Margin = New System.Windows.Forms.Padding(4)
        Me.About.Name = "About"
        Me.About.Padding = New System.Windows.Forms.Padding(4)
        Me.About.Size = New System.Drawing.Size(539, 328)
        Me.About.TabIndex = 1
        Me.About.Text = "About"
        '
        'TableLayoutPanel
        '
        Me.TableLayoutPanel.ColumnCount = 2
        Me.TableLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.0!))
        Me.TableLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 67.0!))
        Me.TableLayoutPanel.Controls.Add(Me.LogoPictureBox, 0, 0)
        Me.TableLayoutPanel.Controls.Add(Me.LabelProductName, 1, 0)
        Me.TableLayoutPanel.Controls.Add(Me.LabelVersion, 1, 1)
        Me.TableLayoutPanel.Controls.Add(Me.LabelCopyright, 1, 2)
        Me.TableLayoutPanel.Controls.Add(Me.LabelCompanyName, 1, 3)
        Me.TableLayoutPanel.Controls.Add(Me.TextBoxDescription, 1, 4)
        Me.TableLayoutPanel.Controls.Add(Me.OKButton, 1, 5)
        Me.TableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel.Location = New System.Drawing.Point(4, 4)
        Me.TableLayoutPanel.Margin = New System.Windows.Forms.Padding(4)
        Me.TableLayoutPanel.Name = "TableLayoutPanel"
        Me.TableLayoutPanel.RowCount = 6
        Me.TableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.TableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.TableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.TableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.TableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.TableLayoutPanel.Size = New System.Drawing.Size(531, 320)
        Me.TableLayoutPanel.TabIndex = 1
        '
        'LogoPictureBox
        '
        Me.LogoPictureBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LogoPictureBox.Image = CType(resources.GetObject("LogoPictureBox.Image"), System.Drawing.Image)
        Me.LogoPictureBox.Location = New System.Drawing.Point(4, 4)
        Me.LogoPictureBox.Margin = New System.Windows.Forms.Padding(4)
        Me.LogoPictureBox.Name = "LogoPictureBox"
        Me.TableLayoutPanel.SetRowSpan(Me.LogoPictureBox, 6)
        Me.LogoPictureBox.Size = New System.Drawing.Size(167, 312)
        Me.LogoPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.LogoPictureBox.TabIndex = 0
        Me.LogoPictureBox.TabStop = False
        '
        'LabelProductName
        '
        Me.LabelProductName.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LabelProductName.Location = New System.Drawing.Point(183, 0)
        Me.LabelProductName.Margin = New System.Windows.Forms.Padding(8, 0, 4, 0)
        Me.LabelProductName.MaximumSize = New System.Drawing.Size(0, 21)
        Me.LabelProductName.Name = "LabelProductName"
        Me.LabelProductName.Size = New System.Drawing.Size(344, 21)
        Me.LabelProductName.TabIndex = 0
        Me.LabelProductName.Text = "Product Name"
        Me.LabelProductName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LabelVersion
        '
        Me.LabelVersion.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LabelVersion.Location = New System.Drawing.Point(183, 32)
        Me.LabelVersion.Margin = New System.Windows.Forms.Padding(8, 0, 4, 0)
        Me.LabelVersion.MaximumSize = New System.Drawing.Size(0, 21)
        Me.LabelVersion.Name = "LabelVersion"
        Me.LabelVersion.Size = New System.Drawing.Size(344, 21)
        Me.LabelVersion.TabIndex = 0
        Me.LabelVersion.Text = "Version"
        Me.LabelVersion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LabelCopyright
        '
        Me.LabelCopyright.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LabelCopyright.Location = New System.Drawing.Point(183, 64)
        Me.LabelCopyright.Margin = New System.Windows.Forms.Padding(8, 0, 4, 0)
        Me.LabelCopyright.MaximumSize = New System.Drawing.Size(0, 21)
        Me.LabelCopyright.Name = "LabelCopyright"
        Me.LabelCopyright.Size = New System.Drawing.Size(344, 21)
        Me.LabelCopyright.TabIndex = 0
        Me.LabelCopyright.Text = "Copyright"
        Me.LabelCopyright.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LabelCompanyName
        '
        Me.LabelCompanyName.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LabelCompanyName.Location = New System.Drawing.Point(183, 96)
        Me.LabelCompanyName.Margin = New System.Windows.Forms.Padding(8, 0, 4, 0)
        Me.LabelCompanyName.MaximumSize = New System.Drawing.Size(0, 21)
        Me.LabelCompanyName.Name = "LabelCompanyName"
        Me.LabelCompanyName.Size = New System.Drawing.Size(344, 21)
        Me.LabelCompanyName.TabIndex = 0
        Me.LabelCompanyName.Text = "Company Name"
        Me.LabelCompanyName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TextBoxDescription
        '
        Me.TextBoxDescription.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBoxDescription.Location = New System.Drawing.Point(183, 132)
        Me.TextBoxDescription.Margin = New System.Windows.Forms.Padding(8, 4, 4, 4)
        Me.TextBoxDescription.Multiline = True
        Me.TextBoxDescription.Name = "TextBoxDescription"
        Me.TextBoxDescription.ReadOnly = True
        Me.TextBoxDescription.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.TextBoxDescription.Size = New System.Drawing.Size(344, 152)
        Me.TextBoxDescription.TabIndex = 0
        Me.TextBoxDescription.TabStop = False
        Me.TextBoxDescription.Text = resources.GetString("TextBoxDescription.Text")
        '
        'OKButton
        '
        Me.OKButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.OKButton.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.OKButton.Location = New System.Drawing.Point(427, 296)
        Me.OKButton.Margin = New System.Windows.Forms.Padding(4)
        Me.OKButton.Name = "OKButton"
        Me.OKButton.Size = New System.Drawing.Size(100, 20)
        Me.OKButton.TabIndex = 0
        Me.OKButton.Text = "&OK"
        '
        'InstallDirFinder
        '
        Me.InstallDirFinder.SelectedPath = "C:\Program Files (x86)\Minecraft"
        '
        'ProcessUpdate
        '
        Me.ProcessUpdate.Interval = 2000
        '
        'XCTester
        '
        Me.XCTester.Interval = 1000
        '
        'RunProgramWithParamF
        '
        Me.RunProgramWithParamF.FileName = "OpenFileDialog1"
        Me.RunProgramWithParamF.Filter = "Program|*.exe"
        '
        'ReloadPage
        '
        Me.ReloadPage.Location = New System.Drawing.Point(516, 3)
        Me.ReloadPage.Name = "ReloadPage"
        Me.ReloadPage.Size = New System.Drawing.Size(23, 23)
        Me.ReloadPage.TabIndex = 3
        Me.ReloadPage.Text = "↻"
        Me.ReloadPage.UseVisualStyleBackColor = True
        '
        'SpeakLabel
        '
        Me.SpeakLabel.AutoSize = True
        Me.SpeakLabel.Location = New System.Drawing.Point(4, 205)
        Me.SpeakLabel.Name = "SpeakLabel"
        Me.SpeakLabel.Size = New System.Drawing.Size(56, 17)
        Me.SpeakLabel.TabIndex = 15
        Me.SpeakLabel.Text = "Speak: "
        '
        'Speak
        '
        Me.Speak.Location = New System.Drawing.Point(54, 199)
        Me.Speak.Name = "Speak"
        Me.Speak.Size = New System.Drawing.Size(475, 26)
        Me.Speak.TabIndex = 16
        '
        'MMLCHelper
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(615, 446)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Name = "MMLCHelper"
        Me.ShowInTaskbar = False
        Me.Text = "MMLCHelper"
        Me.TopMost = True
        CType(Me.Toggler, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SwitchTimeout, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel.ResumeLayout(False)
        Me.TableLayoutPanel.PerformLayout()
        CType(Me.LogoPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Tabs As System.Windows.Forms.TabControl
    Friend WithEvents XClassToggler As System.Windows.Forms.TabPage
    Friend WithEvents Warning As System.Windows.Forms.Label
    Friend WithEvents Toggler As System.Windows.Forms.TrackBar
    Friend WithEvents About As System.Windows.Forms.TabPage
    Friend WithEvents TableLayoutPanel As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents LogoPictureBox As System.Windows.Forms.PictureBox
    Friend WithEvents LabelProductName As System.Windows.Forms.Label
    Friend WithEvents LabelVersion As System.Windows.Forms.Label
    Friend WithEvents LabelCopyright As System.Windows.Forms.Label
    Friend WithEvents LabelCompanyName As System.Windows.Forms.Label
    Friend WithEvents TextBoxDescription As System.Windows.Forms.TextBox
    Friend WithEvents OKButton As System.Windows.Forms.Button
    Friend WithEvents Disabled As System.Windows.Forms.Label
    Friend Shadows WithEvents Enabled As System.Windows.Forms.Label
    Friend WithEvents Options As System.Windows.Forms.TabPage
    Friend WithEvents Autorun As System.Windows.Forms.CheckBox
    Friend WithEvents AutorunBox As System.Windows.Forms.GroupBox
    Friend WithEvents SwitchOptions As System.Windows.Forms.GroupBox
    Friend WithEvents SwitchIfEnabled As System.Windows.Forms.CheckBox
    Friend WithEvents SwitchTimeoutLabel As System.Windows.Forms.Label
    Friend WithEvents SwitchPrograms As System.Windows.Forms.CheckBox
    Friend WithEvents SwitchForce As System.Windows.Forms.CheckBox
    Friend WithEvents SwitchComment As System.Windows.Forms.TextBox
    Friend WithEvents SwitchCommentLabel As System.Windows.Forms.Label
    Friend WithEvents SwitchTimeout As System.Windows.Forms.NumericUpDown
    Friend WithEvents Minecraft As System.Windows.Forms.TabPage
    Friend WithEvents Uninstall As System.Windows.Forms.Button
    Friend WithEvents Install As System.Windows.Forms.Button
    Friend WithEvents InstallDirButton As System.Windows.Forms.Button
    Friend WithEvents InstallDir As System.Windows.Forms.TextBox
    Friend WithEvents InstallDirLabel As System.Windows.Forms.Label
    Friend WithEvents InstallDirFinder As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents CreateZip As System.Windows.Forms.Button
    Friend WithEvents AppData As System.Windows.Forms.CheckBox
    Friend WithEvents AppDataPath As System.Windows.Forms.TextBox
    Friend WithEvents AppDataButton As System.Windows.Forms.Button
    Friend WithEvents AppDataFinder As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents DOGE As System.Windows.Forms.TabPage
    Friend WithEvents DOGE1 As System.Windows.Forms.Label
    Friend WithEvents DOGE2 As System.Windows.Forms.TextBox
    Friend WithEvents DOGESwitch As System.Windows.Forms.Button
    Friend WithEvents Developing As System.Windows.Forms.Label
    Friend WithEvents CHY As System.Windows.Forms.TabPage
    Friend WithEvents 別雲間Label As System.Windows.Forms.Label
    Friend WithEvents 敬酒歌Label As System.Windows.Forms.Label
    Friend WithEvents 敬酒歌Play As System.Windows.Forms.Button
    Friend WithEvents 別雲間Play As System.Windows.Forms.Button
    Friend WithEvents 敬酒歌Stop As System.Windows.Forms.Button
    Friend WithEvents 別雲間Stop As System.Windows.Forms.Button
    Friend WithEvents 敬酒歌Pause As System.Windows.Forms.Button
    Friend WithEvents 別雲間Pause As System.Windows.Forms.Button
    Friend WithEvents UpdateMC As System.Windows.Forms.Button
    Friend WithEvents UpdateMCFinder As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents ProgFiles As System.Windows.Forms.CheckBox
    Friend WithEvents MethodBeta As System.Windows.Forms.RadioButton
    Friend WithEvents MethodAlpha As System.Windows.Forms.RadioButton
    Friend WithEvents XCBlockInternet As System.Windows.Forms.CheckBox
    Friend WithEvents Tasks As System.Windows.Forms.TabPage
    Friend WithEvents ProcessRefresh As System.Windows.Forms.Button
    Friend WithEvents ProcessEnd As System.Windows.Forms.Button
    Friend WithEvents Processes As System.Windows.Forms.ListView
    Friend WithEvents ProcessName As System.Windows.Forms.ColumnHeader
    Friend WithEvents ProcessUser As System.Windows.Forms.ColumnHeader
    Friend WithEvents ProcessCPU As System.Windows.Forms.ColumnHeader
    Friend WithEvents ProcessMemory As System.Windows.Forms.ColumnHeader
    Friend WithEvents ProcessDescription As System.Windows.Forms.ColumnHeader
    Friend WithEvents ProcessAutoRefresh As System.Windows.Forms.CheckBox
    Friend WithEvents ProcessUpdate As System.Windows.Forms.Timer
    Friend WithEvents ComputerControl As System.Windows.Forms.TabPage
    Friend WithEvents MiniControlPanel As System.Windows.Forms.Button
    Friend WithEvents XCAppControl As System.Windows.Forms.CheckBox
    Friend WithEvents XCHookInput As System.Windows.Forms.CheckBox
    Friend WithEvents XCTester As System.Windows.Forms.Timer
    Friend WithEvents MiniControlPanelClear As System.Windows.Forms.Button
    Friend WithEvents CHYLoop As System.Windows.Forms.CheckBox
    Friend WithEvents RunCmd As System.Windows.Forms.Button
    Friend WithEvents RunBatch As System.Windows.Forms.Button
    Friend WithEvents RunProgramWithParamP As System.Windows.Forms.TextBox
    Friend WithEvents RunProgramWithParamR As System.Windows.Forms.TextBox
    Friend WithEvents RunProgramWithParam As System.Windows.Forms.Button
    Friend WithEvents RunProgramWithParamPL As System.Windows.Forms.Label
    Friend WithEvents RunProgramWithParamRL As System.Windows.Forms.Label
    Friend WithEvents RunProgramWithParamB As System.Windows.Forms.Button
    Friend WithEvents RunProgramWithParamF As System.Windows.Forms.OpenFileDialog
    Friend WithEvents RunProgramWithParamS As System.Windows.Forms.CheckBox
    Friend WithEvents RunProgramWithParamW As System.Windows.Forms.CheckBox
    Friend WithEvents RunProgramWithParamE As System.Windows.Forms.CheckBox
    Friend WithEvents RunProgramWithParamO As System.Windows.Forms.TextBox
    Friend WithEvents RunProgramWithParamRO As System.Windows.Forms.CheckBox
    Friend WithEvents Authenticate As System.Windows.Forms.Button
    Friend WithEvents Administrator As System.Windows.Forms.Label
    Friend WithEvents Authenticated As System.Windows.Forms.Label
    Friend WithEvents HappyBrowerTab As System.Windows.Forms.TabPage
    Friend WithEvents HappyBrowser As System.Windows.Forms.WebBrowser
    Friend WithEvents URL As System.Windows.Forms.TextBox
    Friend WithEvents URLLabel As System.Windows.Forms.Label
    Friend WithEvents ReloadPage As System.Windows.Forms.Button
    Friend WithEvents SpeakLabel As System.Windows.Forms.Label
    Friend WithEvents Speak As System.Windows.Forms.TextBox

End Class
