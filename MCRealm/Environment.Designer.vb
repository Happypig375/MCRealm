<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Environment
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
        Me.Reset = New System.Windows.Forms.Button()
        Me.MemoryUsageTo = New System.Windows.Forms.Label()
        Me.MemoryMaximumUnit = New System.Windows.Forms.ComboBox()
        Me.JAVASwitch = New System.Windows.Forms.TrackBar()
        Me.MemoryMaximum = New System.Windows.Forms.NumericUpDown()
        Me.JAVALabel = New System.Windows.Forms.Label()
        Me.MemoryMinimumUnit = New System.Windows.Forms.ComboBox()
        Me.JAVAWLabel = New System.Windows.Forms.Label()
        Me.MemoryMinimum = New System.Windows.Forms.NumericUpDown()
        Me.MemoryUsage = New System.Windows.Forms.Label()
        Me.InitializeTo = New System.Windows.Forms.Label()
        Me.MemoryInitialUnit = New System.Windows.Forms.ComboBox()
        Me.MemoryInitial = New System.Windows.Forms.NumericUpDown()
        Me.Buttons = New System.Windows.Forms.TableLayoutPanel()
        Me.Cancel_Button = New System.Windows.Forms.Button()
        Me.OK_Button = New System.Windows.Forms.Button()
        Me.BitSwitch = New System.Windows.Forms.TrackBar()
        Me.Bit32 = New System.Windows.Forms.Label()
        Me.Bit64 = New System.Windows.Forms.Label()
        Me.GUI = New System.Windows.Forms.CheckBox()
        Me.Online = New System.Windows.Forms.CheckBox()
        Me.AdvancedJavaArgs = New System.Windows.Forms.Label()
        Me.JavaArgs = New System.Windows.Forms.TextBox()
        CType(Me.JAVASwitch, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MemoryMaximum, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MemoryMinimum, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MemoryInitial, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Buttons.SuspendLayout()
        CType(Me.BitSwitch, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Reset
        '
        Me.Reset.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Reset.Location = New System.Drawing.Point(3, 3)
        Me.Reset.Name = "Reset"
        Me.Reset.Size = New System.Drawing.Size(67, 23)
        Me.Reset.TabIndex = 29
        Me.Reset.Text = "Reset"
        Me.Reset.UseVisualStyleBackColor = True
        '
        'MemoryUsageTo
        '
        Me.MemoryUsageTo.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.MemoryUsageTo.AutoSize = True
        Me.MemoryUsageTo.Location = New System.Drawing.Point(100, 59)
        Me.MemoryUsageTo.Name = "MemoryUsageTo"
        Me.MemoryUsageTo.Size = New System.Drawing.Size(20, 13)
        Me.MemoryUsageTo.TabIndex = 28
        Me.MemoryUsageTo.Text = "To"
        '
        'MemoryMaximumUnit
        '
        Me.MemoryMaximumUnit.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.MemoryMaximumUnit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.MemoryMaximumUnit.FormattingEnabled = True
        Me.MemoryMaximumUnit.Items.AddRange(New Object() {"(bytes)", "K", "M", "G", "T"})
        Me.MemoryMaximumUnit.Location = New System.Drawing.Point(177, 56)
        Me.MemoryMaximumUnit.Name = "MemoryMaximumUnit"
        Me.MemoryMaximumUnit.Size = New System.Drawing.Size(34, 21)
        Me.MemoryMaximumUnit.TabIndex = 27
        '
        'JAVASwitch
        '
        Me.JAVASwitch.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.JAVASwitch.AutoSize = False
        Me.JAVASwitch.LargeChange = 1
        Me.JAVASwitch.Location = New System.Drawing.Point(40, 12)
        Me.JAVASwitch.Maximum = 1
        Me.JAVASwitch.Name = "JAVASwitch"
        Me.JAVASwitch.Size = New System.Drawing.Size(132, 23)
        Me.JAVASwitch.TabIndex = 20
        '
        'MemoryMaximum
        '
        Me.MemoryMaximum.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.MemoryMaximum.Location = New System.Drawing.Point(126, 57)
        Me.MemoryMaximum.Maximum = New Decimal(New Integer() {-1, -1, -1, 0})
        Me.MemoryMaximum.Name = "MemoryMaximum"
        Me.MemoryMaximum.Size = New System.Drawing.Size(45, 20)
        Me.MemoryMaximum.TabIndex = 26
        Me.MemoryMaximum.Value = New Decimal(New Integer() {2048, 0, 0, 0})
        '
        'JAVALabel
        '
        Me.JAVALabel.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.JAVALabel.AutoSize = True
        Me.JAVALabel.Location = New System.Drawing.Point(7, 16)
        Me.JAVALabel.Name = "JAVALabel"
        Me.JAVALabel.Size = New System.Drawing.Size(27, 13)
        Me.JAVALabel.TabIndex = 21
        Me.JAVALabel.Text = "java"
        '
        'MemoryMinimumUnit
        '
        Me.MemoryMinimumUnit.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.MemoryMinimumUnit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.MemoryMinimumUnit.FormattingEnabled = True
        Me.MemoryMinimumUnit.Items.AddRange(New Object() {"(bytes)", "K", "M", "G", "T"})
        Me.MemoryMinimumUnit.Location = New System.Drawing.Point(59, 56)
        Me.MemoryMinimumUnit.Name = "MemoryMinimumUnit"
        Me.MemoryMinimumUnit.Size = New System.Drawing.Size(36, 21)
        Me.MemoryMinimumUnit.TabIndex = 25
        '
        'JAVAWLabel
        '
        Me.JAVAWLabel.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.JAVAWLabel.AutoSize = True
        Me.JAVAWLabel.Location = New System.Drawing.Point(188, 16)
        Me.JAVAWLabel.Name = "JAVAWLabel"
        Me.JAVAWLabel.Size = New System.Drawing.Size(35, 13)
        Me.JAVAWLabel.TabIndex = 22
        Me.JAVAWLabel.Text = "javaw"
        '
        'MemoryMinimum
        '
        Me.MemoryMinimum.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.MemoryMinimum.Location = New System.Drawing.Point(7, 57)
        Me.MemoryMinimum.Maximum = New Decimal(New Integer() {-1, -1, -1, 0})
        Me.MemoryMinimum.Name = "MemoryMinimum"
        Me.MemoryMinimum.Size = New System.Drawing.Size(45, 20)
        Me.MemoryMinimum.TabIndex = 24
        Me.MemoryMinimum.Value = New Decimal(New Integer() {1024, 0, 0, 0})
        '
        'MemoryUsage
        '
        Me.MemoryUsage.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.MemoryUsage.AutoSize = True
        Me.MemoryUsage.Location = New System.Drawing.Point(17, 38)
        Me.MemoryUsage.Name = "MemoryUsage"
        Me.MemoryUsage.Size = New System.Drawing.Size(78, 13)
        Me.MemoryUsage.TabIndex = 23
        Me.MemoryUsage.Text = "Memory Usage"
        '
        'InitializeTo
        '
        Me.InitializeTo.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.InitializeTo.AutoSize = True
        Me.InitializeTo.Location = New System.Drawing.Point(7, 88)
        Me.InitializeTo.Name = "InitializeTo"
        Me.InitializeTo.Size = New System.Drawing.Size(56, 13)
        Me.InitializeTo.TabIndex = 30
        Me.InitializeTo.Text = "Initialize to"
        '
        'MemoryInitialUnit
        '
        Me.MemoryInitialUnit.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.MemoryInitialUnit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.MemoryInitialUnit.FormattingEnabled = True
        Me.MemoryInitialUnit.Items.AddRange(New Object() {"(bytes)", "K", "M", "G", "T"})
        Me.MemoryInitialUnit.Location = New System.Drawing.Point(121, 87)
        Me.MemoryInitialUnit.Name = "MemoryInitialUnit"
        Me.MemoryInitialUnit.Size = New System.Drawing.Size(36, 21)
        Me.MemoryInitialUnit.TabIndex = 32
        '
        'MemoryInitial
        '
        Me.MemoryInitial.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.MemoryInitial.Location = New System.Drawing.Point(69, 88)
        Me.MemoryInitial.Maximum = New Decimal(New Integer() {-1, -1, -1, 0})
        Me.MemoryInitial.Name = "MemoryInitial"
        Me.MemoryInitial.Size = New System.Drawing.Size(45, 20)
        Me.MemoryInitial.TabIndex = 31
        Me.MemoryInitial.Value = New Decimal(New Integer() {1024, 0, 0, 0})
        '
        'Buttons
        '
        Me.Buttons.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.Buttons.ColumnCount = 3
        Me.Buttons.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334!))
        Me.Buttons.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.Buttons.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334!))
        Me.Buttons.Controls.Add(Me.Cancel_Button, 2, 0)
        Me.Buttons.Controls.Add(Me.OK_Button, 1, 0)
        Me.Buttons.Controls.Add(Me.Reset, 0, 0)
        Me.Buttons.Location = New System.Drawing.Point(7, 233)
        Me.Buttons.Name = "Buttons"
        Me.Buttons.RowCount = 1
        Me.Buttons.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.Buttons.Size = New System.Drawing.Size(219, 29)
        Me.Buttons.TabIndex = 34
        '
        'Cancel_Button
        '
        Me.Cancel_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel_Button.Location = New System.Drawing.Point(148, 3)
        Me.Cancel_Button.Name = "Cancel_Button"
        Me.Cancel_Button.Size = New System.Drawing.Size(67, 23)
        Me.Cancel_Button.TabIndex = 1
        Me.Cancel_Button.Text = "Cancel"
        '
        'OK_Button
        '
        Me.OK_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.OK_Button.Location = New System.Drawing.Point(76, 3)
        Me.OK_Button.Name = "OK_Button"
        Me.OK_Button.Size = New System.Drawing.Size(66, 23)
        Me.OK_Button.TabIndex = 0
        Me.OK_Button.Text = "OK"
        '
        'BitSwitch
        '
        Me.BitSwitch.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.BitSwitch.AutoSize = False
        Me.BitSwitch.LargeChange = 1
        Me.BitSwitch.Location = New System.Drawing.Point(39, 110)
        Me.BitSwitch.Maximum = 1
        Me.BitSwitch.Name = "BitSwitch"
        Me.BitSwitch.Size = New System.Drawing.Size(132, 23)
        Me.BitSwitch.TabIndex = 35
        '
        'Bit32
        '
        Me.Bit32.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Bit32.AutoSize = True
        Me.Bit32.Location = New System.Drawing.Point(6, 114)
        Me.Bit32.Name = "Bit32"
        Me.Bit32.Size = New System.Drawing.Size(31, 13)
        Me.Bit32.TabIndex = 36
        Me.Bit32.Text = "32Bit"
        '
        'Bit64
        '
        Me.Bit64.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Bit64.AutoSize = True
        Me.Bit64.Location = New System.Drawing.Point(187, 114)
        Me.Bit64.Name = "Bit64"
        Me.Bit64.Size = New System.Drawing.Size(31, 13)
        Me.Bit64.TabIndex = 37
        Me.Bit64.Text = "64Bit"
        '
        'GUI
        '
        Me.GUI.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.GUI.AutoSize = True
        Me.GUI.Location = New System.Drawing.Point(12, 139)
        Me.GUI.Name = "GUI"
        Me.GUI.Size = New System.Drawing.Size(160, 17)
        Me.GUI.TabIndex = 38
        Me.GUI.Text = "Display java GUI (not javaw)"
        Me.GUI.UseVisualStyleBackColor = True
        '
        'Online
        '
        Me.Online.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Online.AutoSize = True
        Me.Online.Checked = True
        Me.Online.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Online.Location = New System.Drawing.Point(12, 162)
        Me.Online.Name = "Online"
        Me.Online.Size = New System.Drawing.Size(178, 17)
        Me.Online.TabIndex = 39
        Me.Online.Text = "Online mode (overrides Settings)"
        Me.Online.UseVisualStyleBackColor = True
        '
        'AdvancedJavaArgs
        '
        Me.AdvancedJavaArgs.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.AdvancedJavaArgs.AutoSize = True
        Me.AdvancedJavaArgs.Location = New System.Drawing.Point(10, 186)
        Me.AdvancedJavaArgs.Name = "AdvancedJavaArgs"
        Me.AdvancedJavaArgs.Size = New System.Drawing.Size(134, 13)
        Me.AdvancedJavaArgs.TabIndex = 40
        Me.AdvancedJavaArgs.Text = "Advanced java arguments:"
        '
        'JavaArgs
        '
        Me.JavaArgs.Location = New System.Drawing.Point(7, 203)
        Me.JavaArgs.Name = "JavaArgs"
        Me.JavaArgs.Size = New System.Drawing.Size(211, 20)
        Me.JavaArgs.TabIndex = 41
        Me.JavaArgs.Text = "-XX:+UseConcMarkSweepGC -XX:-UseAdaptiveSizePolicy"
        '
        'Environment
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(230, 274)
        Me.Controls.Add(Me.JavaArgs)
        Me.Controls.Add(Me.AdvancedJavaArgs)
        Me.Controls.Add(Me.Online)
        Me.Controls.Add(Me.GUI)
        Me.Controls.Add(Me.BitSwitch)
        Me.Controls.Add(Me.Bit32)
        Me.Controls.Add(Me.Bit64)
        Me.Controls.Add(Me.Buttons)
        Me.Controls.Add(Me.MemoryInitialUnit)
        Me.Controls.Add(Me.MemoryInitial)
        Me.Controls.Add(Me.InitializeTo)
        Me.Controls.Add(Me.MemoryUsageTo)
        Me.Controls.Add(Me.MemoryMaximumUnit)
        Me.Controls.Add(Me.JAVASwitch)
        Me.Controls.Add(Me.MemoryMaximum)
        Me.Controls.Add(Me.JAVALabel)
        Me.Controls.Add(Me.MemoryMinimumUnit)
        Me.Controls.Add(Me.JAVAWLabel)
        Me.Controls.Add(Me.MemoryMinimum)
        Me.Controls.Add(Me.MemoryUsage)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Environment"
        Me.Text = "Environment Settings"
        CType(Me.JAVASwitch, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MemoryMaximum, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MemoryMinimum, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MemoryInitial, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Buttons.ResumeLayout(False)
        CType(Me.BitSwitch, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Reset As Button
    Friend WithEvents MemoryUsageTo As Label
    Friend WithEvents MemoryMaximumUnit As ComboBox
    Friend WithEvents JAVASwitch As TrackBar
    Friend WithEvents MemoryMaximum As NumericUpDown
    Friend WithEvents JAVALabel As Label
    Friend WithEvents MemoryMinimumUnit As ComboBox
    Friend WithEvents JAVAWLabel As Label
    Friend WithEvents MemoryMinimum As NumericUpDown
    Friend WithEvents MemoryUsage As Label
    Friend WithEvents InitializeTo As Label
    Friend WithEvents MemoryInitialUnit As ComboBox
    Friend WithEvents MemoryInitial As NumericUpDown
    Friend WithEvents Buttons As TableLayoutPanel
    Friend WithEvents OK_Button As Button
    Friend WithEvents Cancel_Button As Button
    Friend WithEvents BitSwitch As TrackBar
    Friend WithEvents Bit32 As Label
    Friend WithEvents Bit64 As Label
    Friend WithEvents GUI As CheckBox
    Friend WithEvents Online As CheckBox
    Friend WithEvents AdvancedJavaArgs As Label
    Friend WithEvents JavaArgs As TextBox
End Class
