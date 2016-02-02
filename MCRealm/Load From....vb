Imports System.Windows.Forms

Public Class Load_From
    Public Function Display(ByVal FromFolder As Boolean, Optional ByVal Args As String = "") As System.Windows.Forms.DialogResult
        Me.Hide()
        If FromFolder Then
            Dim Result As System.Windows.Forms.DialogResult = Folder.ShowDialog()
            _Path = Folder.SelectedPath
            Return Result
        Else
            File.Filter = Args & If(Args = "", "All Files|*.*", "|All Files|*.*")
            Dim Result As System.Windows.Forms.DialogResult = File.ShowDialog()
            _Path = File.FileName
            Return Result
        End If
    End Function
    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Dim Result As System.Windows.Forms.DialogResult = Folder.ShowDialog()
        _Path = Folder.SelectedPath
        [Exit](Result)
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Dim Result As System.Windows.Forms.DialogResult = File.ShowDialog()
        _Path = File.FileName
        [Exit](Result)
    End Sub

    Private Sub [Exit](ByVal Result As System.Windows.Forms.DialogResult)
        Me.DialogResult = Result
        Me.Close()
    End Sub

    Public Property Path As String
End Class
