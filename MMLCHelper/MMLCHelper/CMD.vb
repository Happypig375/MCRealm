Public Module CMD
    Declare Function sys Lib "msvcrt.dll" Alias "system" (ByVal command As String) As Integer
    Sub Main()
        Dim mydata As String
        If Convert.ToBoolean(AllocConsole()) Then
            Dim Command As String
            Do
                Console.WriteLine("THIS IS FIRST LINE")
                Console.WriteLine("THIS IS SECOND LINE")
                Console.WriteLine("THIS IS THIRD LINE")
                Console.WriteLine("THIS IS FOURTH LINE")
                Console.WriteLine("THIS IS FIFTH LINE")
                Console.WriteLine()
                Console.Write("Now enter some data:  ")
                mydata = Console.ReadLine
                Console.WriteLine("You wrote:  " & mydata)
                Console.WriteLine()
                Console.WriteLine("Press any key to Clear")
                Console.ReadKey()
                Console.Clear()
                Console.WriteLine("THE CONSOLE WAS CLEARED")
                Console.WriteLine("Press any key to close console")
                Console.ReadKey()
                FreeConsole()
                'System.Environment.Exit(1)      'ends entire application
                Command = System.Console.ReadLine()
                If Command = "exit" Then Return
                sys(Command)
            Loop
        End If
    End Sub
    Declare Function AllocConsole Lib "kernel32" () As Integer
    Declare Function FreeConsole Lib "kernel32" () As Integer
End Module
