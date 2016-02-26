Partial Public Class Sprite
    Partial Public NotInheritable Class Script
        Private _Sound As SoundBlock
        Public ReadOnly Property Sound As SoundBlock
            Get
                Return _Sound
            End Get
        End Property
        <ComponentModel.EditorBrowsable(ComponentModel.EditorBrowsableState.Never)> _
        Public NotInheritable Class SoundBlock

        End Class
    End Class
End Class