Public Class Form1
    ' Make some objects.
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' Make a HouseBoat.
        Dim house_boat As New HouseBoat()
        house_boat.SquareFeet = 100
        house_boat.MaxSpeed = 10

        ' Make an IVehicle variable.
        Dim i_vehicle As IVehicle = house_boat
        i_vehicle.MaxSpeed = 15
    End Sub
End Class
