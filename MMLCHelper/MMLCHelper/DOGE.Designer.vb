<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DOGEDisplay
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DOGEDisplay))
        Me.RealDoge = New System.Windows.Forms.PictureBox()
        Me.ASCIIDoge = New System.Windows.Forms.Label()
        Me.MovementTimer = New System.Windows.Forms.Timer(Me.components)
        Me.SwitchTimer = New System.Windows.Forms.Timer(Me.components)
        Me.DOGEPlayer0 = New AxWMPLib.AxWindowsMediaPlayer()
        Me.DOGEPlayer1 = New AxWMPLib.AxWindowsMediaPlayer()
        Me.DOGEPlayer2 = New AxWMPLib.AxWindowsMediaPlayer()
        Me.DOGEPlayer3 = New AxWMPLib.AxWindowsMediaPlayer()
        Me.DOGEPlayer4 = New AxWMPLib.AxWindowsMediaPlayer()
        Me.DOGEPlayer5 = New AxWMPLib.AxWindowsMediaPlayer()
        Me.DOGEPlayer6 = New AxWMPLib.AxWindowsMediaPlayer()
        Me.DOGEPlayer7 = New AxWMPLib.AxWindowsMediaPlayer()
        Me.DOGEPlayer8 = New AxWMPLib.AxWindowsMediaPlayer()
        Me.DOGEPlayer9 = New AxWMPLib.AxWindowsMediaPlayer()
        CType(Me.RealDoge, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DOGEPlayer0, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DOGEPlayer1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DOGEPlayer2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DOGEPlayer3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DOGEPlayer4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DOGEPlayer5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DOGEPlayer6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DOGEPlayer7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DOGEPlayer8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DOGEPlayer9, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'RealDoge
        '
        Me.RealDoge.Dock = System.Windows.Forms.DockStyle.Fill
        Me.RealDoge.Image = CType(resources.GetObject("RealDoge.Image"), System.Drawing.Image)
        Me.RealDoge.Location = New System.Drawing.Point(0, 0)
        Me.RealDoge.Name = "RealDoge"
        Me.RealDoge.Size = New System.Drawing.Size(288, 328)
        Me.RealDoge.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.RealDoge.TabIndex = 1
        Me.RealDoge.TabStop = False
        '
        'ASCIIDoge
        '
        Me.ASCIIDoge.AutoSize = True
        Me.ASCIIDoge.Location = New System.Drawing.Point(0, 0)
        Me.ASCIIDoge.Name = "ASCIIDoge"
        Me.ASCIIDoge.Size = New System.Drawing.Size(285, 323)
        Me.ASCIIDoge.TabIndex = 2
        Me.ASCIIDoge.Text = resources.GetString("ASCIIDoge.Text")
        '
        'MovementTimer
        '
        Me.MovementTimer.Enabled = True
        '
        'SwitchTimer
        '
        Me.SwitchTimer.Enabled = True
        Me.SwitchTimer.Interval = 500
        '
        'Me.DOGEPlayer
        '
        Me.DOGEPlayer0.Enabled = True
        Me.DOGEPlayer0.Location = New System.Drawing.Point(0, 0)
        Me.DOGEPlayer0.Name = "Me.DOGEPlayer"
        Me.DOGEPlayer0.OcxState = CType(resources.GetObject("Me.DOGEPlayer.OcxState"), System.Windows.Forms.AxHost.State)
        Me.DOGEPlayer0.Size = Me.Size
        Me.DOGEPlayer0.TabIndex = 11

        Me.DOGEPlayer1.Enabled = True
        Me.DOGEPlayer1.Location = New System.Drawing.Point(0, 0)
        Me.DOGEPlayer1.Name = "Me.DOGEPlayer"
        Me.DOGEPlayer1.OcxState = CType(resources.GetObject("Me.DOGEPlayer.OcxState"), System.Windows.Forms.AxHost.State)
        Me.DOGEPlayer1.Size = Me.Size
        Me.DOGEPlayer1.TabIndex = 11

        Me.DOGEPlayer2.Enabled = True
        Me.DOGEPlayer2.Location = New System.Drawing.Point(0, 0)
        Me.DOGEPlayer2.Name = "Me.DOGEPlayer"
        Me.DOGEPlayer2.OcxState = CType(resources.GetObject("Me.DOGEPlayer.OcxState"), System.Windows.Forms.AxHost.State)
        Me.DOGEPlayer2.Size = Me.Size
        Me.DOGEPlayer2.TabIndex = 11

        Me.DOGEPlayer3.Enabled = True
        Me.DOGEPlayer3.Location = New System.Drawing.Point(0, 0)
        Me.DOGEPlayer3.Name = "Me.DOGEPlayer"
        Me.DOGEPlayer3.OcxState = CType(resources.GetObject("Me.DOGEPlayer.OcxState"), System.Windows.Forms.AxHost.State)
        Me.DOGEPlayer3.Size = Me.Size
        Me.DOGEPlayer3.TabIndex = 11

        Me.DOGEPlayer4.Enabled = True
        Me.DOGEPlayer4.Location = New System.Drawing.Point(0, 0)
        Me.DOGEPlayer4.Name = "Me.DOGEPlayer"
        Me.DOGEPlayer4.OcxState = CType(resources.GetObject("Me.DOGEPlayer.OcxState"), System.Windows.Forms.AxHost.State)
        Me.DOGEPlayer4.Size = Me.Size
        Me.DOGEPlayer4.TabIndex = 11

        Me.DOGEPlayer5.Enabled = True
        Me.DOGEPlayer5.Location = New System.Drawing.Point(0, 0)
        Me.DOGEPlayer5.Name = "Me.DOGEPlayer"
        Me.DOGEPlayer5.OcxState = CType(resources.GetObject("Me.DOGEPlayer.OcxState"), System.Windows.Forms.AxHost.State)
        Me.DOGEPlayer5.Size = Me.Size
        Me.DOGEPlayer5.TabIndex = 11

        Me.DOGEPlayer6.Enabled = True
        Me.DOGEPlayer6.Location = New System.Drawing.Point(0, 0)
        Me.DOGEPlayer6.Name = "Me.DOGEPlayer"
        Me.DOGEPlayer6.OcxState = CType(resources.GetObject("Me.DOGEPlayer.OcxState"), System.Windows.Forms.AxHost.State)
        Me.DOGEPlayer6.Size = Me.Size
        Me.DOGEPlayer6.TabIndex = 11

        Me.DOGEPlayer7.Enabled = True
        Me.DOGEPlayer7.Location = New System.Drawing.Point(0, 0)
        Me.DOGEPlayer7.Name = "Me.DOGEPlayer"
        Me.DOGEPlayer7.OcxState = CType(resources.GetObject("Me.DOGEPlayer.OcxState"), System.Windows.Forms.AxHost.State)
        Me.DOGEPlayer7.Size = Me.Size
        Me.DOGEPlayer7.TabIndex = 11

        Me.DOGEPlayer8.Enabled = True
        Me.DOGEPlayer8.Location = New System.Drawing.Point(0, 0)
        Me.DOGEPlayer8.Name = "Me.DOGEPlayer"
        Me.DOGEPlayer8.OcxState = CType(resources.GetObject("Me.DOGEPlayer.OcxState"), System.Windows.Forms.AxHost.State)
        Me.DOGEPlayer8.Size = Me.Size
        Me.DOGEPlayer8.TabIndex = 11

        Me.DOGEPlayer9.Enabled = True
        Me.DOGEPlayer9.Location = New System.Drawing.Point(0, 0)
        Me.DOGEPlayer9.Name = "Me.DOGEPlayer"
        Me.DOGEPlayer9.OcxState = CType(resources.GetObject("Me.DOGEPlayer.OcxState"), System.Windows.Forms.AxHost.State)
        Me.DOGEPlayer9.Size = Me.Size
        Me.DOGEPlayer9.TabIndex = 11


        '
        'DOGEDisplay
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(288, 328)
        Me.Controls.Add(Me.ASCIIDoge)
        Me.Controls.Add(Me.RealDoge)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "DOGEDisplay"
        Me.Text = "DOGE"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.RealDoge, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DOGEPlayer0, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DOGEPlayer1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DOGEPlayer2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DOGEPlayer3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DOGEPlayer4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DOGEPlayer5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DOGEPlayer6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DOGEPlayer7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DOGEPlayer8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DOGEPlayer9, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents RealDoge As System.Windows.Forms.PictureBox
    Friend WithEvents ASCIIDoge As System.Windows.Forms.Label
    Friend WithEvents MovementTimer As System.Windows.Forms.Timer
    Friend WithEvents SwitchTimer As System.Windows.Forms.Timer
    Friend WithEvents DOGEPlayer0 As AxWMPLib.AxWindowsMediaPlayer
    Friend WithEvents DOGEPlayer1 As AxWMPLib.AxWindowsMediaPlayer
    Friend WithEvents DOGEPlayer2 As AxWMPLib.AxWindowsMediaPlayer
    Friend WithEvents DOGEPlayer3 As AxWMPLib.AxWindowsMediaPlayer
    Friend WithEvents DOGEPlayer4 As AxWMPLib.AxWindowsMediaPlayer
    Friend WithEvents DOGEPlayer5 As AxWMPLib.AxWindowsMediaPlayer
    Friend WithEvents DOGEPlayer6 As AxWMPLib.AxWindowsMediaPlayer
    Friend WithEvents DOGEPlayer7 As AxWMPLib.AxWindowsMediaPlayer
    Friend WithEvents DOGEPlayer8 As AxWMPLib.AxWindowsMediaPlayer
    Friend WithEvents DOGEPlayer9 As AxWMPLib.AxWindowsMediaPlayer
End Class
