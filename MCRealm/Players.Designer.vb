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
        Dim ListViewGroup1 As System.Windows.Forms.ListViewGroup = New System.Windows.Forms.ListViewGroup("A", System.Windows.Forms.HorizontalAlignment.Left)
        Dim ListViewGroup2 As System.Windows.Forms.ListViewGroup = New System.Windows.Forms.ListViewGroup("B", System.Windows.Forms.HorizontalAlignment.Left)
        Dim ListViewGroup3 As System.Windows.Forms.ListViewGroup = New System.Windows.Forms.ListViewGroup("C", System.Windows.Forms.HorizontalAlignment.Left)
        Dim ListViewGroup4 As System.Windows.Forms.ListViewGroup = New System.Windows.Forms.ListViewGroup("D", System.Windows.Forms.HorizontalAlignment.Left)
        Dim ListViewGroup5 As System.Windows.Forms.ListViewGroup = New System.Windows.Forms.ListViewGroup("E", System.Windows.Forms.HorizontalAlignment.Left)
        Dim ListViewGroup6 As System.Windows.Forms.ListViewGroup = New System.Windows.Forms.ListViewGroup("F", System.Windows.Forms.HorizontalAlignment.Left)
        Dim ListViewGroup7 As System.Windows.Forms.ListViewGroup = New System.Windows.Forms.ListViewGroup("G", System.Windows.Forms.HorizontalAlignment.Left)
        Dim ListViewGroup8 As System.Windows.Forms.ListViewGroup = New System.Windows.Forms.ListViewGroup("H", System.Windows.Forms.HorizontalAlignment.Left)
        Dim ListViewGroup9 As System.Windows.Forms.ListViewGroup = New System.Windows.Forms.ListViewGroup("I", System.Windows.Forms.HorizontalAlignment.Left)
        Dim ListViewGroup10 As System.Windows.Forms.ListViewGroup = New System.Windows.Forms.ListViewGroup("J", System.Windows.Forms.HorizontalAlignment.Left)
        Dim ListViewGroup11 As System.Windows.Forms.ListViewGroup = New System.Windows.Forms.ListViewGroup("K", System.Windows.Forms.HorizontalAlignment.Left)
        Dim ListViewGroup12 As System.Windows.Forms.ListViewGroup = New System.Windows.Forms.ListViewGroup("L", System.Windows.Forms.HorizontalAlignment.Left)
        Dim ListViewGroup13 As System.Windows.Forms.ListViewGroup = New System.Windows.Forms.ListViewGroup("M", System.Windows.Forms.HorizontalAlignment.Left)
        Dim ListViewGroup14 As System.Windows.Forms.ListViewGroup = New System.Windows.Forms.ListViewGroup("N", System.Windows.Forms.HorizontalAlignment.Left)
        Dim ListViewGroup15 As System.Windows.Forms.ListViewGroup = New System.Windows.Forms.ListViewGroup("O", System.Windows.Forms.HorizontalAlignment.Left)
        Dim ListViewGroup16 As System.Windows.Forms.ListViewGroup = New System.Windows.Forms.ListViewGroup("P", System.Windows.Forms.HorizontalAlignment.Left)
        Dim ListViewGroup17 As System.Windows.Forms.ListViewGroup = New System.Windows.Forms.ListViewGroup("Q", System.Windows.Forms.HorizontalAlignment.Left)
        Dim ListViewGroup18 As System.Windows.Forms.ListViewGroup = New System.Windows.Forms.ListViewGroup("R", System.Windows.Forms.HorizontalAlignment.Left)
        Dim ListViewGroup19 As System.Windows.Forms.ListViewGroup = New System.Windows.Forms.ListViewGroup("S", System.Windows.Forms.HorizontalAlignment.Left)
        Dim ListViewGroup20 As System.Windows.Forms.ListViewGroup = New System.Windows.Forms.ListViewGroup("T", System.Windows.Forms.HorizontalAlignment.Left)
        Dim ListViewGroup21 As System.Windows.Forms.ListViewGroup = New System.Windows.Forms.ListViewGroup("U", System.Windows.Forms.HorizontalAlignment.Left)
        Dim ListViewGroup22 As System.Windows.Forms.ListViewGroup = New System.Windows.Forms.ListViewGroup("V", System.Windows.Forms.HorizontalAlignment.Left)
        Dim ListViewGroup23 As System.Windows.Forms.ListViewGroup = New System.Windows.Forms.ListViewGroup("W", System.Windows.Forms.HorizontalAlignment.Left)
        Dim ListViewGroup24 As System.Windows.Forms.ListViewGroup = New System.Windows.Forms.ListViewGroup("X", System.Windows.Forms.HorizontalAlignment.Left)
        Dim ListViewGroup25 As System.Windows.Forms.ListViewGroup = New System.Windows.Forms.ListViewGroup("Y", System.Windows.Forms.HorizontalAlignment.Left)
        Dim ListViewGroup26 As System.Windows.Forms.ListViewGroup = New System.Windows.Forms.ListViewGroup("Z", System.Windows.Forms.HorizontalAlignment.Left)
        Dim ListViewGroup27 As System.Windows.Forms.ListViewGroup = New System.Windows.Forms.ListViewGroup("#", System.Windows.Forms.HorizontalAlignment.Left)
        Dim ListViewGroup28 As System.Windows.Forms.ListViewGroup = New System.Windows.Forms.ListViewGroup("*", System.Windows.Forms.HorizontalAlignment.Left)
        Me.Buttons = New System.Windows.Forms.TableLayoutPanel()
        Me.Cancel_Button = New System.Windows.Forms.Button()
        Me.OK_Button = New System.Windows.Forms.Button()
        Me.Apply_Button = New System.Windows.Forms.Button()
        Me.View = New System.Windows.Forms.ListView()
        Me.Head = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.PName = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Kick = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Ban = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Op = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Images = New System.Windows.Forms.ImageList(Me.components)
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
        Me.Buttons.Location = New System.Drawing.Point(283, 500)
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
        '
        'View
        '
        Me.View.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.View.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.Head, Me.PName, Me.Kick, Me.Ban, Me.Op})
        ListViewGroup1.Header = "A"
        ListViewGroup1.Name = "A"
        ListViewGroup2.Header = "B"
        ListViewGroup2.Name = "B"
        ListViewGroup3.Header = "C"
        ListViewGroup3.Name = "C"
        ListViewGroup4.Header = "D"
        ListViewGroup4.Name = "D"
        ListViewGroup5.Header = "E"
        ListViewGroup5.Name = "E"
        ListViewGroup6.Header = "F"
        ListViewGroup6.Name = "F"
        ListViewGroup7.Header = "G"
        ListViewGroup7.Name = "G"
        ListViewGroup8.Header = "H"
        ListViewGroup8.Name = "H"
        ListViewGroup9.Header = "I"
        ListViewGroup9.Name = "I"
        ListViewGroup10.Header = "J"
        ListViewGroup10.Name = "J"
        ListViewGroup11.Header = "K"
        ListViewGroup11.Name = "K"
        ListViewGroup12.Header = "L"
        ListViewGroup12.Name = "L"
        ListViewGroup13.Header = "M"
        ListViewGroup13.Name = "M"
        ListViewGroup14.Header = "N"
        ListViewGroup14.Name = "N"
        ListViewGroup15.Header = "O"
        ListViewGroup15.Name = "O"
        ListViewGroup16.Header = "P"
        ListViewGroup16.Name = "P"
        ListViewGroup17.Header = "Q"
        ListViewGroup17.Name = "Q"
        ListViewGroup18.Header = "R"
        ListViewGroup18.Name = "R"
        ListViewGroup19.Header = "S"
        ListViewGroup19.Name = "S"
        ListViewGroup20.Header = "T"
        ListViewGroup20.Name = "T"
        ListViewGroup21.Header = "U"
        ListViewGroup21.Name = "U"
        ListViewGroup22.Header = "V"
        ListViewGroup22.Name = "V"
        ListViewGroup23.Header = "W"
        ListViewGroup23.Name = "W"
        ListViewGroup24.Header = "X"
        ListViewGroup24.Name = "X"
        ListViewGroup25.Header = "Y"
        ListViewGroup25.Name = "Y"
        ListViewGroup26.Header = "Z"
        ListViewGroup26.Name = "Z"
        ListViewGroup27.Header = "#"
        ListViewGroup27.Name = "#"
        ListViewGroup28.Header = "*"
        ListViewGroup28.Name = "*"
        Me.View.Groups.AddRange(New System.Windows.Forms.ListViewGroup() {ListViewGroup1, ListViewGroup2, ListViewGroup3, ListViewGroup4, ListViewGroup5, ListViewGroup6, ListViewGroup7, ListViewGroup8, ListViewGroup9, ListViewGroup10, ListViewGroup11, ListViewGroup12, ListViewGroup13, ListViewGroup14, ListViewGroup15, ListViewGroup16, ListViewGroup17, ListViewGroup18, ListViewGroup19, ListViewGroup20, ListViewGroup21, ListViewGroup22, ListViewGroup23, ListViewGroup24, ListViewGroup25, ListViewGroup26, ListViewGroup27, ListViewGroup28})
        Me.View.Location = New System.Drawing.Point(0, 0)
        Me.View.Name = "View"
        Me.View.Size = New System.Drawing.Size(514, 495)
        Me.View.SmallImageList = Me.Images
        Me.View.TabIndex = 1
        Me.View.UseCompatibleStateImageBehavior = False
        Me.View.View = System.Windows.Forms.View.Details
        '
        'Head
        '
        Me.Head.Text = "Head"
        '
        'PName
        '
        Me.PName.Text = "Name"
        Me.PName.Width = 270
        '
        'Kick
        '
        Me.Kick.Text = "Kick"
        '
        'Ban
        '
        Me.Ban.Text = "Ban"
        '
        'Op
        '
        Me.Op.Text = "Op"
        '
        'Images
        '
        Me.Images.ColorDepth = System.Windows.Forms.ColorDepth.Depth16Bit
        Me.Images.ImageSize = New System.Drawing.Size(16, 26)
        Me.Images.TransparentColor = System.Drawing.Color.Transparent
        '
        'Players
        '
        Me.AcceptButton = Me.OK_Button
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.Apply_Button
        Me.ClientSize = New System.Drawing.Size(514, 541)
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

    End Sub
    Friend WithEvents Buttons As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents Apply_Button As System.Windows.Forms.Button
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents View As ListView
    Friend WithEvents Head As ColumnHeader
    Friend WithEvents PName As ColumnHeader
    Friend WithEvents Kick As ColumnHeader
    Friend WithEvents Ban As ColumnHeader
    Friend WithEvents Op As ColumnHeader
    Friend WithEvents Images As ImageList
End Class
