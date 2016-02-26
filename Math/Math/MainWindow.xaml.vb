Option Explicit On
Option Strict On

Imports System.Numerics

Class MainWindow


    ''' <summary>
    ''' Returns all the primes from 2 up to N
    ''' </summary>
    ''' <param name="N">Find all primes below N</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function SieveOfEratosthenes(ByVal N As BigInteger) As List(Of BigInteger)
        'Stores all the prime numbers
        Dim result As New List(Of BigInteger)

        'We need an boolean array that indicates if the number is a prime
        Dim IsPrime As New List(Of Boolean)

        'Fill the array with all true values and we will start at the number 2
        For i As BigInteger = 0 To N - 2
            IsPrime.Add(True)
        Next

        'Find and store how many numbers we need to check
        Dim NumberOfPrimeChecks As BigInteger = SqrtN(N)

        'Start checking at the number 2
        Dim CurrentNumber As BigInteger = 2

        'Loop through all the nessecary checks 
        For i As BigInteger = 0 To NumberOfPrimeChecks - 1
            If IsPrime(CInt(i)) Then
                'if the number 2 is prime the number 4 is not etc...
                For j As BigInteger = i + CurrentNumber To IsPrime.Count - 1 Step CurrentNumber
                    IsPrime(CInt(j)) = False
                Next
            End If
            'Increments the counter
            CurrentNumber += 1
        Next

        'Print the stored result in our list based on the boolean values
        For i As BigInteger = 0 To IsPrime.Count - 1
            If IsPrime(CInt(i)) Then
                result.Add(CInt(i) + 2)
            End If
        Next

        Return result
    End Function

    

    ''' <summary>
    ''' Gives out all the primes from 2 to N, given the primes below M and the start finding new primes at M
    ''' </summary>
    ''' <param name="M">Start the check fore new primes at M</param>
    ''' <param name="N">The upper boundary for finding primes N</param>
    ''' <param name="PiPrime">All the primes below M, includeed M</param>
    ''' <returns>A list of primes from 2 to N</returns>
    ''' <remarks>This function requires that you have all the prime numbers below M</remarks>
    Private Function SieveOfEratosthenes(ByVal M As BigInteger, ByVal N As BigInteger, ByVal PiPrime As List(Of BigInteger)) As List(Of BigInteger)
        'Stores all the prime numbers
        Dim result As New List(Of BigInteger)
        result = PiPrime

        If M <= PiPrime(PiPrime.Count - 1) Then
            M = PiPrime(PiPrime.Count - 1) + 1
        End If

        'We still have to do Sieveing with the lowest prime numbers 
        Dim HigestModPi As New List(Of BigInteger)
        For i As BigInteger = 0 To PiPrime.Count - 1
            Dim temp As BigInteger = ((M / PiPrime(CInt(i)))) * PiPrime(CInt(i))
            If temp < M Then
                temp += PiPrime(CInt(i))
            End If
            HigestModPi.Add(temp)

        Next

        'We need an boolean array that indicates if the number is a prime
        Dim IsPrime As New List(Of Boolean)

        'Fill the array with all true values and we will start at the number 2
        For i As BigInteger = M To N - 1
            IsPrime.Add(True)
        Next

        'Find and store how many numbers we need to check
        Dim PrimeCheckStop As BigInteger = SqrtN(N)

        For i As BigInteger = 0 To PiPrime.Count - 1
            If PiPrime(CInt(i)) > PrimeCheckStop Then
                Exit For
            End If

            For j As BigInteger = 0 To IsPrime.Count - 1 Step PiPrime(CInt(i))
                Dim h As BigInteger = HigestModPi(CInt(i)) - M + j
                If h > IsPrime.Count - 1 Then Exit For
                IsPrime(CInt(h)) = False
            Next
        Next

        'Check if we have performed all checks fo rthe possible primes primes between M and N
        If M < SqrtN(N) Then
            For i As BigInteger = M To PrimeCheckStop
                If IsPrime(CInt(i)) Then
                    For j As BigInteger = i * 2 To N Step i
                        IsPrime(CInt(j)) = False
                    Next
                End If
            Next
        End If

        For k As BigInteger = 0 To IsPrime.Count - 1
            If IsPrime(CInt(k)) Then
                result.Add(M + k)
            End If
        Next

        Return result
    End Function

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="N"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function SqrtN(ByVal N As BigInteger) As BigInteger
        If (0 = N) Then Return 0
        Dim n1 As BigInteger = (N >> 1) + 1
        Dim n2 As BigInteger = (n1 + (N / n1)) >> 1
        While (n2 < n1)
            n1 = n2
            n2 = (n1 + (N / n1)) >> 1
        End While
        Return n1
    End Function


    ''' <summary>
    ''' Returns a list of Primes from 2 to N
    ''' </summary>
    ''' <param name="N">Find prime numbers equal or lower than N</param>
    ''' <returns>List of primes as List(of BigInteger)</returns>
    ''' <remarks>For large primes you can get out of memory exceptions</remarks>
    Private Function SieveOfAtkin(ByVal N As System.Numerics.BigInteger) As List(Of System.Numerics.BigInteger)
        Dim primes As New List(Of System.Numerics.BigInteger)

        Dim isPrime = New Boolean(CInt(N)) {}
        Dim sqrt As System.Numerics.BigInteger = SqrtN(N)
        '  sqrt = Math.Sqrt(N)
        For x As System.Numerics.BigInteger = 1 To sqrt
            For y As System.Numerics.BigInteger = 1 To sqrt
                Dim n1 = 4 * x * x + y * y
                If n1 <= N AndAlso (n1 Mod 12 = 1 OrElse n1 Mod 12 = 5) Then
                    isPrime(CInt(n1)) = isPrime(CInt(n1)) Xor True
                End If

                n1 = 3 * x * x + y * y
                If n1 <= N AndAlso n1 Mod 12 = 7 Then
                    isPrime(CInt(n1)) = isPrime(CInt(n1)) Xor True
                End If

                n1 = 3 * x * x - y * y
                If x > y AndAlso n1 <= N AndAlso n1 Mod 12 = 11 Then
                    isPrime(CInt(n1)) = isPrime(CInt(n1)) Xor True
                End If
            Next
        Next

        For n2 As System.Numerics.BigInteger = 5 To sqrt
            If isPrime(CInt(n2)) Then
                Dim s = n2 * n2
                Dim k As System.Numerics.BigInteger = s
                While k <= N
                    isPrime(CInt(k)) = False
                    k += s
                End While
            End If
        Next

        primes.Add(2)
        primes.Add(3)
        For n3 As System.Numerics.BigInteger = 5 To N Step 2
            If isPrime(CInt(n3)) Then
                primes.Add(n3)
            End If
        Next
        Return primes
    End Function



    Private Sub Window_Loaded(sender As System.Object, e As EventArgs)
        Dim str As String = ""

        'Test Sieve of Atkin
        'For Each i As System.Numerics.BigInteger In SieveOfAtkin(120000)
        '    str &= i.ToString & ", "
        'Next

        ''Test  SieveOfEratosthenes
        'For Each i As Integer In SieveOfEratosthenes(120000)
        '    str &= i.ToString & ", "
        'Next

        ''Test SieveOfEratosthenes separated method
        'Dim lstPrime As New List(Of BigInteger)
        'lstPrime = SieveOfEratosthenes(11)
        'lstPrime = SieveOfEratosthenes(11, 120, lstPrime)
        'For Each i As Integer In lstPrime
        '    str &= i.ToString & ", "
        'Next

        'TextBox1.Text = str
    End Sub
End Class
