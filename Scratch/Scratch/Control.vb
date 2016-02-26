Partial Public Class Sprite
    Partial Public NotInheritable Class Script
        Private _Control As ControlBlock
        Public ReadOnly Property Control As ControlBlock
            Get
                Return _Control
            End Get
        End Property
        <ComponentModel.EditorBrowsable(ComponentModel.EditorBrowsableState.Never)> _
        Public NotInheritable Class ControlBlock

        End Class
    End Class
End Class