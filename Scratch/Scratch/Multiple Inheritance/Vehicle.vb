Public Class Vehicle
    Implements IVehicle

    Private _MaxSpeed As Integer
    Public Property MaxSpeed() As Integer Implements IVehicle.MaxSpeed
        Get
            Return _MaxSpeed
        End Get
        Set(ByVal value As Integer)
            _MaxSpeed = value
        End Set
    End Property
End Class
