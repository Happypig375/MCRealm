Partial Public Class Sprite
    Partial Public NotInheritable Class Script
        Private _Operators As OperatorsBlock
        Public ReadOnly Property Operators As OperatorsBlock
            Get
                Return _Operators
            End Get
        End Property
        <ComponentModel.EditorBrowsable(ComponentModel.EditorBrowsableState.Never)> _
        Public NotInheritable Class OperatorsBlock

        End Class
    End Class
End Class