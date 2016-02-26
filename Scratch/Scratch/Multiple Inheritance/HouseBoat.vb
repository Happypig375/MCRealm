Public Class HouseBoat
    Inherits Domicile
    Implements IVehicle

    ' Inherits the SquareFeet property from Domicile.

    ' Delegate IVehicle features to a Vehicle object.
    Private _Vehicle As New Vehicle()
    Public Property MaxSpeed() As Integer Implements IVehicle.MaxSpeed
        Get
            Return _Vehicle.MaxSpeed
        End Get
        Set(ByVal value As Integer)
            _Vehicle.MaxSpeed = value
        End Set
    End Property
End Class
