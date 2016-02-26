Public Class MMLCHelperUpdater

    Private Sub MMLCHelperUpdater_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        For Each OneFile As String In My.Settings.Setting.ToArray
            Files.FileName &= """"c
            Files.FileName &= OneFile
            Files.FileName &= """"c
            Files.FileName &= " "c
        Next
    End Sub

    Private Sub Files_FileOk(sender As Object,
                             e As System.ComponentModel.CancelEventArgs) Handles Files.FileOk
        My.Settings.Setting = CType(CType(Files.FileNames.ToList, IList), ArrayList)
    End Sub

    Private Sub Files_HelpRequest(sender As Object, e As EventArgs) Handles Files.HelpRequest
        MessageBox.Show("Select multiple files to copy to the update directory.", "Help",
                        MessageBoxButtons.OK, MessageBoxIcon.Asterisk,
                        MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification)
    End Sub
End Class
