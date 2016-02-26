Public Class LoginIIdentity
    Implements System.Security.Principal.IIdentity

    Private nameValue As String
    Private authenticatedValue As Boolean
    Private roleValue As ApplicationServices.BuiltInRole

    Public ReadOnly Property AuthenticationType() As String Implements System.
        Security.Principal.IIdentity.AuthenticationType
        Get
            Return "Custom Authentication"
        End Get
    End Property

    Public ReadOnly Property IsAuthenticated() As Boolean Implements System.
        Security.Principal.IIdentity.IsAuthenticated
        Get
            Return authenticatedValue
        End Get
    End Property

    Public ReadOnly Property Name() As String Implements System.Security.Principal.IIdentity.Name
        Get
            Return nameValue
        End Get
    End Property

    Public ReadOnly Property Role() As ApplicationServices.BuiltInRole
        Get
            Return roleValue
        End Get
    End Property

    Public Sub New(ByVal name As String, ByVal password As String)
        ' The name is not case sensitive, but the password is.
        If IsValidNameAndPassword(name, password) Then
            nameValue = name
            authenticatedValue = True
            roleValue = ApplicationServices.BuiltInRole.Administrator
        Else
            nameValue = ""
            authenticatedValue = False
            roleValue = ApplicationServices.BuiltInRole.Guest
        End If
    End Sub

    Private Function IsValidNameAndPassword(
        ByVal username As String,
        ByVal password As String) As Boolean

        ' Look up the stored hashed password and salt for the username.
        Dim storedHashedPW As String = GetHashedPassword(username)
        Dim salt As String = GetSalt(username)

        'Create the salted hash.
        Dim rawSalted As String = salt & Trim(password)
        Dim saltedPwBytes() As Byte =
            System.Text.Encoding.Unicode.GetBytes(rawSalted)
        Dim sha1 As New System.Security.Cryptography.
            SHA1CryptoServiceProvider
        Dim hashedPwBytes() As Byte = sha1.ComputeHash(saltedPwBytes)
        Dim hashedPw As String = Convert.ToBase64String(hashedPwBytes)

        ' Compare the hashed password with the stored password.
        Return hashedPw = storedHashedPW
    End Function

    Private Function Register(
    ByVal username As String,
    ByVal password As String) As Boolean

        ' Look up the stored hashed password and salt for the username.
        Dim storedHashedPW As String = GetHashedPassword(username)
        Dim salt As String = GetSalt(username)

        'Create the salted hash.
        Dim rawSalted As String = salt & Trim(password)
        Dim saltedPwBytes() As Byte =
            System.Text.Encoding.Unicode.GetBytes(rawSalted)
        Dim sha1 As New System.Security.Cryptography.
            SHA1CryptoServiceProvider
        Dim hashedPwBytes() As Byte = sha1.ComputeHash(saltedPwBytes)
        Dim hashedPw As String = Convert.ToBase64String(hashedPwBytes)

        ' Compare the hashed password with the stored password.
        Return hashedPw = storedHashedPW
    End Function

    Private Function GetHashedPassword(ByVal username As String) As String
        ' Code that gets the user's hashed password goes here.
        ' This example uses a hard-coded hashed passcode.
        ' In general, the hashed passcode should be stored 
        ' outside of the application.
        Select Case Trim(username).ToLower
            Case "testuser"
                Return "ZFFzgfsGjgtmExzWBRmZI5S4w6o="
            Case Else
                Return ""
        End Select
    End Function

    Private Function GetSalt(ByVal username As String) As String
        ' Code that gets the user's salt goes here.
        ' This example uses a hard-coded salt.
        ' In general, the salt should be stored 
        ' outside of the application.
        Select Case Trim(username).ToLower
            Case "testuser"
                Return "Should be a different random value for each user"
            Case Else
                Return ""
        End Select
    End Function

    Private Function ValidateUser(ByVal userName As String, ByVal passWord As String) As Boolean
        Dim conn As SqlClient.SqlConnection
        Dim cmd As SqlClient.SqlCommand
        Dim lookupPassword As String

        lookupPassword = Nothing

        ' Check for an invalid userName.
        ' userName  must not be set to nothing and must be between one and 15 characters.
        If ((userName Is Nothing)) Then
            System.Diagnostics.Trace.WriteLine("[ValidateUser] Input validation of userName failed.")
            Return False
        End If
        If ((userName.Length = 0) Or (userName.Length > 15)) Then
            System.Diagnostics.Trace.WriteLine("[ValidateUser] Input validation of userName failed.")
            Return False
        End If

        ' Check for invalid passWord.
        ' passWord must not be set to nothing and must be between one and 25 characters.
        If (passWord Is Nothing) Then
            System.Diagnostics.Trace.WriteLine("[ValidateUser] Input validation of passWord failed.")
            Return False
        End If
        If ((passWord.Length = 0) Or (passWord.Length > 25)) Then
            System.Diagnostics.Trace.WriteLine("[ValidateUser] Input validation of passWord failed.")
            Return False
        End If

        Try
            ' Consult with your SQL Server administrator for an appropriate connection
            ' string to use to connect to your local SQL Server.
            conn = New SqlClient.SqlConnection(
                "server=localhost;Integrated Security=SSPI;database=pubs")
            conn.Open()

            ' Create SqlCommand to select pwd field from the users table given a supplied userName.
            cmd = New SqlClient.SqlCommand("Select pwd from users where uname=@userName", conn)
            cmd.Parameters.Add("@userName", SqlDbType.VarChar, 25)
            cmd.Parameters("@userName").Value = userName


            ' Execute command and fetch pwd field into lookupPassword string.
            lookupPassword = CStr(cmd.ExecuteScalar())

            ' Cleanup command and connection objects.
            cmd.Dispose()
            conn.Dispose()
        Catch ex As Exception
            ' Add error handling here for debugging.
            ' This error message should not be sent back to the caller.
            System.Diagnostics.Trace.WriteLine("[ValidateUser] Exception " & ex.Message)
        End Try

        ' If no password found, return false.
        If (lookupPassword Is Nothing) Then
            ' You could write failed login attempts here to the event log for additional security.
            Return False
        End If

        ' Compare lookupPassword and input passWord by using a case-sensitive comparison.
        Return (String.Compare(lookupPassword, passWord, False) = 0)

    End Function
End Class
