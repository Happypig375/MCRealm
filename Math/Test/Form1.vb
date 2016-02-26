Imports Happypig375.Math
Public Class Form1

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim A As Double = InputBox("First Number", "Prompt", 100)
        Dim B As Double = InputBox("Second Number", "Prompt", 120)
        Dim C As Double = InputBox("Third Number", "Prompt", 150)
        MsgBox(HCF(A, B).ToString, , "HCF(A,B)")
        MsgBox(LCM(A, B).ToString, , "LCM(A,B)")
        MsgBox(Curved(A, B, C, ), , "Curved(Speed:A,Init:B,Final:C)")
        MsgBox(ULong.MaxValue)
    End Sub
End Class
