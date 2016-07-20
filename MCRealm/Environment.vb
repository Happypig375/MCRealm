Public Class Environment
    Private Sub Reset_Click(sender As Object, e As EventArgs) Handles Reset.Click
        JAVASwitch.Value = 1
        MemoryMinimum.Value = 512
        MemoryMinimumUnit.SelectedIndex = 2
        MemoryMaximum.Value = 2048
        MemoryMaximumUnit.SelectedIndex = 2
        MemoryInitial.Value = MemoryMinimum.Value
        MemoryInitialUnit.SelectedIndex = MemoryMinimumUnit.SelectedIndex
    End Sub

    Private Sub OK_Button_Click(sender As Object, e As EventArgs) Handles OK_Button.Click
        With Main.JavaArgs
            .JavaW = JAVASwitch.Value = 1
            .MemoryMin = Convert.ToUInt32(MemoryMinimum.Value)
            .MemoryInit = Convert.ToUInt32(MemoryInitial.Value)
            .MemoryMax = Convert.ToUInt32(MemoryMaximum.Value)
            .MemoryMinUnit = CType(MemoryMinimumUnit.SelectedIndex, Main.JavaRuntimeArgs.MemoryUnit)
            .MemoryInitUnit = CType(MemoryInitialUnit.SelectedIndex, Main.JavaRuntimeArgs.MemoryUnit)
            .MemoryMaxUnit = CType(MemoryMaximumUnit.SelectedIndex, Main.JavaRuntimeArgs.MemoryUnit)
        End With
        DialogResult = DialogResult.OK
        Close()
    End Sub

    Private Sub Cancel_Button_Click(sender As Object, e As EventArgs) Handles Cancel_Button.Click
        DialogResult = DialogResult.Cancel
        Close()
    End Sub

    Private Sub Environment_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        With Main.JavaArgs
            JAVASwitch.Value = If(.JavaW, 1, 0)
            Enabled = Not .Running
            MemoryMinimum.Value = .MemoryMin
            MemoryInitial.Value = .MemoryInit
            MemoryMaximum.Value = .MemoryMax
            MemoryMinimumUnit.SelectedIndex = .MemoryMinUnit
            MemoryInitialUnit.SelectedIndex = .MemoryInitUnit
            MemoryMaximumUnit.SelectedIndex = .MemoryMaxUnit
        End With
    End Sub
End Class