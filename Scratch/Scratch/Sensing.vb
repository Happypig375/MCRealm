Partial Public Class Sprite
    Partial Public NotInheritable Class Script
        Private _Sensing As SensingBlock
        Public ReadOnly Property Sensing As SensingBlock
            Get
                Return _Sensing
            End Get
        End Property
        <ComponentModel.EditorBrowsable(ComponentModel.EditorBrowsableState.Never)> _
        Public NotInheritable Class SensingBlock

        End Class
    End Class
End Class