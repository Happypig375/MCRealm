Partial Public Class Sprite
    Partial Public NotInheritable Class Script
        Private _Variables As VariablesBlock
        Public ReadOnly Property Variables As VariablesBlock
            Get
                Return _Variables
            End Get
        End Property
        <ComponentModel.EditorBrowsable(ComponentModel.EditorBrowsableState.Never)> _
        Public NotInheritable Class VariablesBlock

        End Class
    End Class
End Class