Public Class LoginIPrincipal
    Implements System.Security.Principal.IPrincipal

    Private identityValue As LoginIIdentity

    Public ReadOnly Property Identity() As System.Security.Principal.
        IIdentity Implements System.Security.Principal.IPrincipal.Identity
        Get
            Return identityValue
        End Get
    End Property

    Public Function IsInRole(ByVal role As String) As Boolean Implements System.
        Security.Principal.IPrincipal.IsInRole
        Return role = identityValue.Role.ToString
    End Function

    Public Sub New(ByVal name As String, ByVal password As String)
        identityValue = New LoginIIdentity(name, password)
    End Sub

End Class
