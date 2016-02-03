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
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Cancel_Button = New System.Windows.Forms.Button()
        Me.OK_Button = New System.Windows.Forms.Button()
        Me.Apply_Button = New System.Windows.Forms.Button()
        Me.JAVAWLabel = New System.Windows.Forms.Label()
        Me.JAVALabel = New System.Windows.Forms.Label()
        Me.JAVASwitch = New System.Windows.Forms.TrackBar()
        Me.Environment = New System.Windows.Forms.GroupBox()
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.JAVASwitch, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Environment.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.ColumnCount = 3
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33323!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33323!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33353!))
        Me.TableLayoutPanel1.Controls.Add(Me.Cancel_Button, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.OK_Button, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Apply_Button, 1, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(204, 274)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(219, 29)
        Me.TableLayoutPanel1.TabIndex = 0
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
        'JAVAWLabel
        '
        Me.JAVAWLabel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.JAVAWLabel.AutoSize = True
        Me.JAVAWLabel.Location = New System.Drawing.Point(159, 16)
        Me.JAVAWLabel.Name = "JAVAWLabel"
        Me.JAVAWLabel.Size = New System.Drawing.Size(35, 13)
        Me.JAVAWLabel.TabIndex = 12
        Me.JAVAWLabel.Text = "javaw"
        '
        'JAVALabel
        '
        Me.JAVALabel.AutoSize = True
        Me.JAVALabel.Location = New System.Drawing.Point(11, 16)
        Me.JAVALabel.Name = "JAVALabel"
        Me.JAVALabel.Size = New System.Drawing.Size(27, 13)
        Me.JAVALabel.TabIndex = 11
        Me.JAVALabel.Text = "java"
        '
        'JAVASwitch
        '
        Me.JAVASwitch.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.JAVASwitch.AutoSize = False
        Me.JAVASwitch.LargeChange = 1
        Me.JAVASwitch.Location = New System.Drawing.Point(34, 11)
        Me.JAVASwitch.Maximum = 1
        Me.JAVASwitch.Name = "JAVASwitch"
        Me.JAVASwitch.Size = New System.Drawing.Size(119, 23)
        Me.JAVASwitch.TabIndex = 10
        '
        'Environment
        '
        Me.Environment.Controls.Add(Me.JAVAWLabel)
        Me.Environment.Controls.Add(Me.JAVASwitch)
        Me.Environment.Controls.Add(Me.JAVALabel)
        Me.Environment.Location = New System.Drawing.Point(12, 12)
        Me.Environment.Name = "Environment"
        Me.Environment.Size = New System.Drawing.Size(200, 48)
        Me.Environment.TabIndex = 13
        Me.Environment.TabStop = False
        Me.Environment.Text = "Environment"
        '
        'Settings
        '
        Me.AcceptButton = Me.OK_Button
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.Apply_Button
        Me.ClientSize = New System.Drawing.Size(435, 315)
        Me.Controls.Add(Me.Environment)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Settings"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Settings"
        Me.TableLayoutPanel1.ResumeLayout(False)
        CType(Me.JAVASwitch, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Environment.ResumeLayout(False)
        Me.Environment.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents Apply_Button As System.Windows.Forms.Button
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents JAVAWLabel As System.Windows.Forms.Label
    Friend WithEvents JAVALabel As System.Windows.Forms.Label
    Friend WithEvents JAVASwitch As System.Windows.Forms.TrackBar
    Friend WithEvents Environment As System.Windows.Forms.GroupBox

End Class
