<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MMLCHelperUpdater
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
        Me.Files = New System.Windows.Forms.OpenFileDialog()
        Me.SuspendLayout()
        '
        'Files
        '
        Me.Files.FileName = "File"
        Me.Files.Filter = "VB Files|*.sin|*.vbproj|*.vb|App.config|Application Files|*.exe|*.dll|*.exe.confi" & _
    "g|*.vhost.exe.manifest|All Files|*.*"
        Me.Files.Multiselect = True
        Me.Files.ShowHelp = True
        '
        'MMLCHelperUpdater
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(282, 255)
        Me.Name = "MMLCHelperUpdater"
        Me.Text = "MMLCHelperUpdater"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Files As System.Windows.Forms.OpenFileDialog

End Class
