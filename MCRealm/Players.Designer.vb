<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Players
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
        Me.components = New System.ComponentModel.Container()
        Dim ListViewGroup29 As System.Windows.Forms.ListViewGroup = New System.Windows.Forms.ListViewGroup("A", System.Windows.Forms.HorizontalAlignment.Left)
        Dim ListViewGroup30 As System.Windows.Forms.ListViewGroup = New System.Windows.Forms.ListViewGroup("B", System.Windows.Forms.HorizontalAlignment.Left)
        Dim ListViewGroup31 As System.Windows.Forms.ListViewGroup = New System.Windows.Forms.ListViewGroup("C", System.Windows.Forms.HorizontalAlignment.Left)
        Dim ListViewGroup32 As System.Windows.Forms.ListViewGroup = New System.Windows.Forms.ListViewGroup("D", System.Windows.Forms.HorizontalAlignment.Left)
        Dim ListViewGroup33 As System.Windows.Forms.ListViewGroup = New System.Windows.Forms.ListViewGroup("E", System.Windows.Forms.HorizontalAlignment.Left)
        Dim ListViewGroup34 As System.Windows.Forms.ListViewGroup = New System.Windows.Forms.ListViewGroup("F", System.Windows.Forms.HorizontalAlignment.Left)
        Dim ListViewGroup35 As System.Windows.Forms.ListViewGroup = New System.Windows.Forms.ListViewGroup("G", System.Windows.Forms.HorizontalAlignment.Left)
        Dim ListViewGroup36 As System.Windows.Forms.ListViewGroup = New System.Windows.Forms.ListViewGroup("H", System.Windows.Forms.HorizontalAlignment.Left)
        Dim ListViewGroup37 As System.Windows.Forms.ListViewGroup = New System.Windows.Forms.ListViewGroup("I", System.Windows.Forms.HorizontalAlignment.Left)
        Dim ListViewGroup38 As System.Windows.Forms.ListViewGroup = New System.Windows.Forms.ListViewGroup("J", System.Windows.Forms.HorizontalAlignment.Left)
        Dim ListViewGroup39 As System.Windows.Forms.ListViewGroup = New System.Windows.Forms.ListViewGroup("K", System.Windows.Forms.HorizontalAlignment.Left)
        Dim ListViewGroup40 As System.Windows.Forms.ListViewGroup = New System.Windows.Forms.ListViewGroup("L", System.Windows.Forms.HorizontalAlignment.Left)
        Dim ListViewGroup41 As System.Windows.Forms.ListViewGroup = New System.Windows.Forms.ListViewGroup("M", System.Windows.Forms.HorizontalAlignment.Left)
        Dim ListViewGroup42 As System.Windows.Forms.ListViewGroup = New System.Windows.Forms.ListViewGroup("N", System.Windows.Forms.HorizontalAlignment.Left)
        Dim ListViewGroup43 As System.Windows.Forms.ListViewGroup = New System.Windows.Forms.ListViewGroup("O", System.Windows.Forms.HorizontalAlignment.Left)
        Dim ListViewGroup44 As System.Windows.Forms.ListViewGroup = New System.Windows.Forms.ListViewGroup("P", System.Windows.Forms.HorizontalAlignment.Left)
        Dim ListViewGroup45 As System.Windows.Forms.ListViewGroup = New System.Windows.Forms.ListViewGroup("Q", System.Windows.Forms.HorizontalAlignment.Left)
        Dim ListViewGroup46 As System.Windows.Forms.ListViewGroup = New System.Windows.Forms.ListViewGroup("R", System.Windows.Forms.HorizontalAlignment.Left)
        Dim ListViewGroup47 As System.Windows.Forms.ListViewGroup = New System.Windows.Forms.ListViewGroup("S", System.Windows.Forms.HorizontalAlignment.Left)
        Dim ListViewGroup48 As System.Windows.Forms.ListViewGroup = New System.Windows.Forms.ListViewGroup("T", System.Windows.Forms.HorizontalAlignment.Left)
        Dim ListViewGroup49 As System.Windows.Forms.ListViewGroup = New System.Windows.Forms.ListViewGroup("U", System.Windows.Forms.HorizontalAlignment.Left)
        Dim ListViewGroup50 As System.Windows.Forms.ListViewGroup = New System.Windows.Forms.ListViewGroup("V", System.Windows.Forms.HorizontalAlignment.Left)
        Dim ListViewGroup51 As System.Windows.Forms.ListViewGroup = New System.Windows.Forms.ListViewGroup("W", System.Windows.Forms.HorizontalAlignment.Left)
        Dim ListViewGroup52 As System.Windows.Forms.ListViewGroup = New System.Windows.Forms.ListViewGroup("X", System.Windows.Forms.HorizontalAlignment.Left)
        Dim ListViewGroup53 As System.Windows.Forms.ListViewGroup = New System.Windows.Forms.ListViewGroup("Y", System.Windows.Forms.HorizontalAlignment.Left)
        Dim ListViewGroup54 As System.Windows.Forms.ListViewGroup = New System.Windows.Forms.ListViewGroup("Z", System.Windows.Forms.HorizontalAlignment.Left)
        Dim ListViewGroup55 As System.Windows.Forms.ListViewGroup = New System.Windows.Forms.ListViewGroup("#", System.Windows.Forms.HorizontalAlignment.Left)
        Dim ListViewGroup56 As System.Windows.Forms.ListViewGroup = New System.Windows.Forms.ListViewGroup("*", System.Windows.Forms.HorizontalAlignment.Left)
        Me.Buttons = New System.Windows.Forms.TableLayoutPanel()
        Me.Ban = New System.Windows.Forms.Button()
        Me.Kick = New System.Windows.Forms.Button()
        Me.Op = New System.Windows.Forms.Button()
        Me.View = New System.Windows.Forms.ListView()
        Me.PHead = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.PName = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.PBan = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.POp = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Images = New System.Windows.Forms.ImageList(Me.components)
        Me.ImageLoader = New System.ComponentModel.BackgroundWorker()
        Me.HeadLoading = New System.Windows.Forms.Label()
        Me.HeadLoad = New System.Windows.Forms.Label()
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
        Me.Buttons.Controls.Add(Me.Ban, 0, 0)
        Me.Buttons.Controls.Add(Me.Kick, 0, 0)
        Me.Buttons.Controls.Add(Me.Op, 1, 0)
        Me.Buttons.Location = New System.Drawing.Point(283, 500)
        Me.Buttons.Name = "Buttons"
        Me.Buttons.RowCount = 1
        Me.Buttons.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.Buttons.Size = New System.Drawing.Size(219, 29)
        Me.Buttons.TabIndex = 0
        '
        'Ban
        '
        Me.Ban.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Ban.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Ban.Location = New System.Drawing.Point(75, 3)
        Me.Ban.Name = "Ban"
        Me.Ban.Size = New System.Drawing.Size(66, 23)
        Me.Ban.TabIndex = 2
        Me.Ban.Text = "Ban"
        '
        'Kick
        '
        Me.Kick.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Kick.Location = New System.Drawing.Point(3, 3)
        Me.Kick.Name = "Kick"
        Me.Kick.Size = New System.Drawing.Size(66, 23)
        Me.Kick.TabIndex = 0
        Me.Kick.Text = "Kick"
        '
        'Op
        '
        Me.Op.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Op.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Op.Location = New System.Drawing.Point(148, 3)
        Me.Op.Name = "Op"
        Me.Op.Size = New System.Drawing.Size(67, 23)
        Me.Op.TabIndex = 1
        Me.Op.Text = "Op"
        '
        'View
        '
        Me.View.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.View.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.PHead, Me.PName, Me.PBan, Me.POp})
        ListViewGroup29.Header = "A"
        ListViewGroup29.Name = "A"
        ListViewGroup30.Header = "B"
        ListViewGroup30.Name = "B"
        ListViewGroup31.Header = "C"
        ListViewGroup31.Name = "C"
        ListViewGroup32.Header = "D"
        ListViewGroup32.Name = "D"
        ListViewGroup33.Header = "E"
        ListViewGroup33.Name = "E"
        ListViewGroup34.Header = "F"
        ListViewGroup34.Name = "F"
        ListViewGroup35.Header = "G"
        ListViewGroup35.Name = "G"
        ListViewGroup36.Header = "H"
        ListViewGroup36.Name = "H"
        ListViewGroup37.Header = "I"
        ListViewGroup37.Name = "I"
        ListViewGroup38.Header = "J"
        ListViewGroup38.Name = "J"
        ListViewGroup39.Header = "K"
        ListViewGroup39.Name = "K"
        ListViewGroup40.Header = "L"
        ListViewGroup40.Name = "L"
        ListViewGroup41.Header = "M"
        ListViewGroup41.Name = "M"
        ListViewGroup42.Header = "N"
        ListViewGroup42.Name = "N"
        ListViewGroup43.Header = "O"
        ListViewGroup43.Name = "O"
        ListViewGroup44.Header = "P"
        ListViewGroup44.Name = "P"
        ListViewGroup45.Header = "Q"
        ListViewGroup45.Name = "Q"
        ListViewGroup46.Header = "R"
        ListViewGroup46.Name = "R"
        ListViewGroup47.Header = "S"
        ListViewGroup47.Name = "S"
        ListViewGroup48.Header = "T"
        ListViewGroup48.Name = "T"
        ListViewGroup49.Header = "U"
        ListViewGroup49.Name = "U"
        ListViewGroup50.Header = "V"
        ListViewGroup50.Name = "V"
        ListViewGroup51.Header = "W"
        ListViewGroup51.Name = "W"
        ListViewGroup52.Header = "X"
        ListViewGroup52.Name = "X"
        ListViewGroup53.Header = "Y"
        ListViewGroup53.Name = "Y"
        ListViewGroup54.Header = "Z"
        ListViewGroup54.Name = "Z"
        ListViewGroup55.Header = "#"
        ListViewGroup55.Name = "#"
        ListViewGroup56.Header = "*"
        ListViewGroup56.Name = "*"
        Me.View.Groups.AddRange(New System.Windows.Forms.ListViewGroup() {ListViewGroup29, ListViewGroup30, ListViewGroup31, ListViewGroup32, ListViewGroup33, ListViewGroup34, ListViewGroup35, ListViewGroup36, ListViewGroup37, ListViewGroup38, ListViewGroup39, ListViewGroup40, ListViewGroup41, ListViewGroup42, ListViewGroup43, ListViewGroup44, ListViewGroup45, ListViewGroup46, ListViewGroup47, ListViewGroup48, ListViewGroup49, ListViewGroup50, ListViewGroup51, ListViewGroup52, ListViewGroup53, ListViewGroup54, ListViewGroup55, ListViewGroup56})
        Me.View.Location = New System.Drawing.Point(0, 0)
        Me.View.Name = "View"
        Me.View.Size = New System.Drawing.Size(514, 495)
        Me.View.SmallImageList = Me.Images
        Me.View.TabIndex = 1
        Me.View.UseCompatibleStateImageBehavior = False
        Me.View.View = System.Windows.Forms.View.Details
        '
        'PHead
        '
        Me.PHead.Text = "Head"
        '
        'PName
        '
        Me.PName.Text = "Name"
        Me.PName.Width = 330
        '
        'PBan
        '
        Me.PBan.Text = "Banned"
        '
        'POp
        '
        Me.POp.Text = "Opped"
        '
        'Images
        '
        Me.Images.ColorDepth = System.Windows.Forms.ColorDepth.Depth16Bit
        Me.Images.ImageSize = New System.Drawing.Size(16, 26)
        Me.Images.TransparentColor = System.Drawing.Color.Transparent
        '
        'ImageLoader
        '
        Me.ImageLoader.WorkerReportsProgress = True
        Me.ImageLoader.WorkerSupportsCancellation = True
        '
        'HeadLoading
        '
        Me.HeadLoading.AutoSize = True
        Me.HeadLoading.Location = New System.Drawing.Point(12, 508)
        Me.HeadLoading.Name = "HeadLoading"
        Me.HeadLoading.Size = New System.Drawing.Size(102, 13)
        Me.HeadLoading.TabIndex = 2
        Me.HeadLoading.Text = "Head load progress:"
        '
        'HeadLoad
        '
        Me.HeadLoad.AutoSize = True
        Me.HeadLoad.Location = New System.Drawing.Point(120, 508)
        Me.HeadLoad.Name = "HeadLoad"
        Me.HeadLoad.Size = New System.Drawing.Size(60, 13)
        Me.HeadLoad.TabIndex = 3
        Me.HeadLoad.Text = "Completed!"
        '
        'Players
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(514, 541)
        Me.Controls.Add(Me.HeadLoad)
        Me.Controls.Add(Me.HeadLoading)
        Me.Controls.Add(Me.View)
        Me.Controls.Add(Me.Buttons)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
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
    Friend WithEvents Kick As System.Windows.Forms.Button
    Friend WithEvents Op As System.Windows.Forms.Button
    Friend WithEvents Ban As System.Windows.Forms.Button
    Friend WithEvents View As ListView
    Friend WithEvents PHead As ColumnHeader
    Friend WithEvents PName As ColumnHeader
    Friend WithEvents PBan As ColumnHeader
    Friend WithEvents POp As ColumnHeader
    Friend WithEvents Images As ImageList
    Friend WithEvents ImageLoader As System.ComponentModel.BackgroundWorker
    Friend WithEvents HeadLoading As Label
    Friend WithEvents HeadLoad As Label
End Class
