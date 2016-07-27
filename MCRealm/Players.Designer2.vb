<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Players2
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.Buttons = New System.Windows.Forms.TableLayoutPanel()
        Me.Cancel_Button = New System.Windows.Forms.Button()
        Me.OK_Button = New System.Windows.Forms.Button()
        Me.Apply_Button = New System.Windows.Forms.Button()
#If Not FilenameMethod = 0 Then
        Me.PlayerSkinProgress = New System.Windows.Forms.ProgressBar()
        Me.PlayerSkinProgressLabel = New System.Windows.Forms.Label()
        Me.BytesDownload = New System.Windows.Forms.Label()
        Me.BytesDownloaded = New System.Windows.Forms.Label()
        Me.TotalBytes = New System.Windows.Forms.Label()
        Me.TotalByte = New System.Windows.Forms.Label()
#End If
        Me.Buttons.SuspendLayout()
        Me.SuspendLayout()
        '
        'Buttons
        '
        Me.Buttons.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Buttons.ColumnCount = 3
        Me.Buttons.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33323!))
        Me.Buttons.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33323!))
        Me.Buttons.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33353!))
        Me.Buttons.Controls.Add(Me.Cancel_Button, 0, 0)
        Me.Buttons.Controls.Add(Me.OK_Button, 0, 0)
        Me.Buttons.Controls.Add(Me.Apply_Button, 1, 0)
        Me.Buttons.Location = New System.Drawing.Point(290, 500)
        Me.Buttons.Name = "Buttons"
        Me.Buttons.RowCount = 1
        Me.Buttons.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.Buttons.Size = New System.Drawing.Size(219, 29)
        Me.Buttons.TabIndex = 0
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
#If Not FilenameMethod = 0 Then
        '
        'PlayerSkinProgress
        '
        Me.PlayerSkinProgress.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PlayerSkinProgress.Location = New System.Drawing.Point(155, 9)
        Me.PlayerSkinProgress.Name = "PlayerSkinProgress"
        Me.PlayerSkinProgress.Size = New System.Drawing.Size(354, 17)
        Me.PlayerSkinProgress.TabIndex = 1
        '
        'PlayerSkinProgressLabel
        '
        Me.PlayerSkinProgressLabel.AutoSize = True
        Me.PlayerSkinProgressLabel.Location = New System.Drawing.Point(12, 9)
        Me.PlayerSkinProgressLabel.Name = "PlayerSkinProgressLabel"
        Me.PlayerSkinProgressLabel.Size = New System.Drawing.Size(137, 13)
        Me.PlayerSkinProgressLabel.TabIndex = 2
        Me.PlayerSkinProgressLabel.Text = "Progress of skin download: "
        '
        'BytesDownload
        '
        Me.BytesDownload.AutoSize = True
        Me.BytesDownload.Location = New System.Drawing.Point(12, 29)
        Me.BytesDownload.Name = "BytesDownload"
        Me.BytesDownload.Size = New System.Drawing.Size(100, 13)
        Me.BytesDownload.TabIndex = 3
        Me.BytesDownload.Text = "Bytes downloaded: "
        '
        'BytesDownloaded
        '
        Me.BytesDownloaded.AutoSize = True
        Me.BytesDownloaded.Location = New System.Drawing.Point(118, 29)
        Me.BytesDownloaded.Name = "BytesDownloaded"
        Me.BytesDownloaded.Size = New System.Drawing.Size(121, 13)
        Me.BytesDownloaded.TabIndex = 4
        Me.BytesDownloaded.Text = "9223372036854775807"
        '
        'TotalBytes
        '
        Me.TotalBytes.AutoSize = True
        Me.TotalBytes.Location = New System.Drawing.Point(389, 29)
        Me.TotalBytes.Name = "TotalBytes"
        Me.TotalBytes.Size = New System.Drawing.Size(121, 13)
        Me.TotalBytes.TabIndex = 6
        Me.TotalBytes.Text = "9223372036854775807"
        '
        'TotalByte
        '
        Me.TotalByte.AutoSize = True
        Me.TotalByte.Location = New System.Drawing.Point(245, 29)
        Me.TotalByte.Name = "TotalByte"
        Me.TotalByte.Size = New System.Drawing.Size(138, 13)
        Me.TotalByte.TabIndex = 5
        Me.TotalByte.Text = "Total bytes to downloaded: "
#End If
        '
        'Players
        '
        Me.AcceptButton = Me.OK_Button
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.Apply_Button
        Me.ClientSize = New System.Drawing.Size(521, 541)
#If Not FilenameMethod = 0 Then
        Me.Controls.Add(Me.TotalBytes)
        Me.Controls.Add(Me.TotalByte)
        Me.Controls.Add(Me.BytesDownloaded)
        Me.Controls.Add(Me.BytesDownload)
        Me.Controls.Add(Me.PlayerSkinProgressLabel)
        Me.Controls.Add(Me.PlayerSkinProgress)
#End If
        Me.Controls.Add(Me.Buttons)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.HelpButton = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Players"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Players"
        Me.Buttons.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Buttons As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents Apply_Button As System.Windows.Forms.Button
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
#If Not FilenameMethod = 0 Then
    Friend WithEvents PlayerSkinProgress As ProgressBar
    Friend WithEvents PlayerSkinProgressLabel As Label
    Friend WithEvents BytesDownload As Label
    Friend WithEvents BytesDownloaded As Label
    Friend WithEvents TotalBytes As Label
    Friend WithEvents TotalByte As Label
#End If
End Class
