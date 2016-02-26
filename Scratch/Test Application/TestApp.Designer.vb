<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TestApp
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
        Me.Sprite21 = New Scratch.Sprite2(Me.components)
        Me.Sprite1 = New Scratch.Sprite(Me.components)
        CType(Me.Sprite1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Sprite1
        '
        Me.Sprite1.Location = New System.Drawing.Point(121, 77)
        Me.Sprite1.Name = "Sprite1"
        Me.Sprite1.Size = New System.Drawing.Size(100, 50)
        Me.Sprite1.TabIndex = 0
        Me.Sprite1.TabStop = False
        '
        'TestApp
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(282, 255)
        Me.Controls.Add(Me.Sprite1)
        Me.Name = "TestApp"
        Me.Text = "Test Application"
        CType(Me.Sprite1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Sprite21 As Scratch.Sprite2
    Friend WithEvents Sprite1 As Scratch.Sprite

End Class
