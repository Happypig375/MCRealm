Public Class Domicile
    Private _SquareFeet As Integer
    Public Property SquareFeet() As Integer
        Get
            Return _SquareFeet
        End Get
        Set(ByVal value As Integer)
            _SquareFeet = value
        End Set
    End Property
End Class
