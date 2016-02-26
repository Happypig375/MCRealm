Partial Public Class Sprite
    Partial Public NotInheritable Class Script
        Private _Looks As LooksBlock
        Public ReadOnly Property Looks As LooksBlock
            Get
                Return _Looks
            End Get
        End Property
        <ComponentModel.EditorBrowsable(ComponentModel.EditorBrowsableState.Never)> _
        Public NotInheritable Class LooksBlock

        End Class
    End Class
End Class