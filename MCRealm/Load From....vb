﻿Imports System.Windows.Forms

Public Class Load_From
    Public Sub Display(ByVal Mode As Boolean, Optional ByVal Args As String = "")
        Me.Hide()
        If Mode Then
            OK_Button_Click(Nothing, Nothing)
        Else
            File.Filter = Args & If(Args = "", "All Files|*.*", "|All Files|*.*")
            Cancel_Button_Click(Nothing, Nothing)
        End If
    End Sub
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
