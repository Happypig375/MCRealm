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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.MemoryInitialUnit = New System.Windows.Forms.ComboBox()
        Me.MemoryInitial = New System.Windows.Forms.NumericUpDown()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Cancel_Button = New System.Windows.Forms.Button()
        Me.OK_Button = New System.Windows.Forms.Button()
        CType(Me.JAVASwitch, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MemoryMaximum, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MemoryMinimum, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MemoryInitial, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel1.SuspendLayout()
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
        Me.MemoryUsageTo.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.MemoryUsageTo.AutoSize = True
        Me.MemoryUsageTo.Location = New System.Drawing.Point(100, 57)
        Me.MemoryUsageTo.Name = "MemoryUsageTo"
        Me.MemoryUsageTo.Size = New System.Drawing.Size(20, 13)
        Me.MemoryUsageTo.TabIndex = 28
        Me.MemoryUsageTo.Text = "To"
        '
        'MemoryMaximumUnit
        '
        Me.MemoryMaximumUnit.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.MemoryMaximumUnit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.MemoryMaximumUnit.FormattingEnabled = True
        Me.MemoryMaximumUnit.Items.AddRange(New Object() {"(bytes)", "K", "M", "G", "T"})
        Me.MemoryMaximumUnit.Location = New System.Drawing.Point(177, 54)
        Me.MemoryMaximumUnit.Name = "MemoryMaximumUnit"
        Me.MemoryMaximumUnit.Size = New System.Drawing.Size(34, 21)
        Me.MemoryMaximumUnit.TabIndex = 27
        '
        'JAVASwitch
        '
        Me.JAVASwitch.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.JAVASwitch.AutoSize = False
        Me.JAVASwitch.LargeChange = 1
        Me.JAVASwitch.Location = New System.Drawing.Point(40, 10)
        Me.JAVASwitch.Maximum = 1
        Me.JAVASwitch.Name = "JAVASwitch"
        Me.JAVASwitch.Size = New System.Drawing.Size(132, 23)
        Me.JAVASwitch.TabIndex = 20
        '
        'MemoryMaximum
        '
        Me.MemoryMaximum.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.MemoryMaximum.Location = New System.Drawing.Point(126, 55)
        Me.MemoryMaximum.Maximum = New Decimal(New Integer() {-1, -1, -1, 0})
        Me.MemoryMaximum.Name = "MemoryMaximum"
        Me.MemoryMaximum.Size = New System.Drawing.Size(45, 20)
        Me.MemoryMaximum.TabIndex = 26
        Me.MemoryMaximum.Value = New Decimal(New Integer() {2048, 0, 0, 0})
        '
        'JAVALabel
        '
        Me.JAVALabel.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.JAVALabel.AutoSize = True
        Me.JAVALabel.Location = New System.Drawing.Point(7, 14)
        Me.JAVALabel.Name = "JAVALabel"
        Me.JAVALabel.Size = New System.Drawing.Size(27, 13)
        Me.JAVALabel.TabIndex = 21
        Me.JAVALabel.Text = "java"
        '
        'MemoryMinimumUnit
        '
        Me.MemoryMinimumUnit.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.MemoryMinimumUnit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.MemoryMinimumUnit.FormattingEnabled = True
        Me.MemoryMinimumUnit.Items.AddRange(New Object() {"(bytes)", "K", "M", "G", "T"})
        Me.MemoryMinimumUnit.Location = New System.Drawing.Point(59, 54)
        Me.MemoryMinimumUnit.Name = "MemoryMinimumUnit"
        Me.MemoryMinimumUnit.Size = New System.Drawing.Size(36, 21)
        Me.MemoryMinimumUnit.TabIndex = 25
        '
        'JAVAWLabel
        '
        Me.JAVAWLabel.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.JAVAWLabel.AutoSize = True
        Me.JAVAWLabel.Location = New System.Drawing.Point(188, 14)
        Me.JAVAWLabel.Name = "JAVAWLabel"
        Me.JAVAWLabel.Size = New System.Drawing.Size(35, 13)
        Me.JAVAWLabel.TabIndex = 22
        Me.JAVAWLabel.Text = "javaw"
        '
        'MemoryMinimum
        '
        Me.MemoryMinimum.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.MemoryMinimum.Location = New System.Drawing.Point(7, 55)
        Me.MemoryMinimum.Maximum = New Decimal(New Integer() {-1, -1, -1, 0})
        Me.MemoryMinimum.Name = "MemoryMinimum"
        Me.MemoryMinimum.Size = New System.Drawing.Size(45, 20)
        Me.MemoryMinimum.TabIndex = 24
        Me.MemoryMinimum.Value = New Decimal(New Integer() {1024, 0, 0, 0})
        '
        'MemoryUsage
        '
        Me.MemoryUsage.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.MemoryUsage.AutoSize = True
        Me.MemoryUsage.Location = New System.Drawing.Point(17, 36)
        Me.MemoryUsage.Name = "MemoryUsage"
        Me.MemoryUsage.Size = New System.Drawing.Size(78, 13)
        Me.MemoryUsage.TabIndex = 23
        Me.MemoryUsage.Text = "Memory Usage"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(7, 88)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(56, 13)
        Me.Label1.TabIndex = 30
        Me.Label1.Text = "Initialize to"
        '
        'MemoryInitialUnit
        '
        Me.MemoryInitialUnit.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.MemoryInitialUnit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.MemoryInitialUnit.FormattingEnabled = True
        Me.MemoryInitialUnit.Items.AddRange(New Object() {"(bytes)", "K", "M", "G", "T"})
        Me.MemoryInitialUnit.Location = New System.Drawing.Point(121, 85)
        Me.MemoryInitialUnit.Name = "MemoryInitialUnit"
        Me.MemoryInitialUnit.Size = New System.Drawing.Size(36, 21)
        Me.MemoryInitialUnit.TabIndex = 32
        '
        'MemoryInitial
        '
        Me.MemoryInitial.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.MemoryInitial.Location = New System.Drawing.Point(69, 86)
        Me.MemoryInitial.Maximum = New Decimal(New Integer() {-1, -1, -1, 0})
        Me.MemoryInitial.Name = "MemoryInitial"
        Me.MemoryInitial.Size = New System.Drawing.Size(45, 20)
        Me.MemoryInitial.TabIndex = 31
        Me.MemoryInitial.Value = New Decimal(New Integer() {1024, 0, 0, 0})
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.ColumnCount = 3
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334!))
        Me.TableLayoutPanel1.Controls.Add(Me.Cancel_Button, 2, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.OK_Button, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Reset, 0, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(7, 220)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(219, 29)
        Me.TableLayoutPanel1.TabIndex = 34
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
        'Environment
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(230, 261)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Controls.Add(Me.MemoryInitialUnit)
        Me.Controls.Add(Me.MemoryInitial)
        Me.Controls.Add(Me.Label1)
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
        Me.Text = "`"
        CType(Me.JAVASwitch, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MemoryMaximum, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MemoryMinimum, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MemoryInitial, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel1.ResumeLayout(False)
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
    Friend WithEvents Label1 As Label
    Friend WithEvents MemoryInitialUnit As ComboBox
    Friend WithEvents MemoryInitial As NumericUpDown
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents OK_Button As Button
    Friend WithEvents Cancel_Button As Button
End Class
