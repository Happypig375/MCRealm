Namespace My
    ' The following events are available for MyApplication:
    ' 
    ' Startup: Raised when the application starts, before the startup form is created.
    ' Shutdown: Raised after all application forms are closed.  This event is not raised if the application terminates abnormally.
    ' UnhandledException: Raised if the application encounters an unhandled exception.
    ' StartupNextInstance: Raised when launching a single-instance application and the application is already active. 
    ' NetworkAvailabilityChanged: Raised when the network connection is connected or disconnected.
    Partial Friend Class MyApplication
        'Declare Function Lock Lib "Lock.dll" Alias "0x10001517" ()
        Partial Friend Class MyModes
            Public Class BatchMode
                'Console Application Sample
                'Written by Nir Sofer.
                '
                'Web site: http://nirsoft.mirrorz.com
                '
                'In order to create a console application from this code, 
                'follow the instructions below:
                '1. Make an executable file from this project.
                '2. Run the "Application Mode Changer" utility and change the 
                'mode of the executable file
                'to "Console Application".

                Public Declare Function GetStdHandle Lib "kernel32" _
                (ByVal nStdHandle As Long) As Long

                Private Declare Function WriteFile Lib "kernel32" _
                (ByVal hFile As Long, _
                lpBuffer As Object, _
                ByVal nNumberOfBytesToWrite As Long, _
                lpNumberOfBytesWritten As Long, _
                lpOverlapped As Object) As Long

                Public Const STD_OUTPUT_HANDLE = -11&

                Private Structure COORD
                    Dim x As Integer
                    Dim y As Integer
                End Structure

                Private Structure SMALL_RECT
                    Dim Left As Integer
                    Dim Top As Integer
                    Dim Right As Integer
                    Dim Bottom As Integer
                End Structure

                Private Structure CONSOLE_SCREEN_BUFFER_INFO
                    Dim dwSize As COORD
                    Dim dwCursorPosition As COORD
                    Dim wAttributes As Integer
                    Dim srWindow As SMALL_RECT
                    Dim dwMaximumWindowSize As COORD
                End Structure
                Private Declare Function GetConsoleScreenBufferInfo Lib "kernel32" _
                (ByVal hConsoleOutput As Long, _
                lpConsoleScreenBufferInfo As CONSOLE_SCREEN_BUFFER_INFO) As Long

                Private Declare Function SetConsoleTextAttribute Lib "kernel32" _
                (ByVal hConsoleOutput As Long, ByVal wAttributes As Long) As Long

                Private Const FOREGROUND_BLUE = &H1     '  text color contains blue.
                Private Const FOREGROUND_GREEN = &H2     '  text color contains green.
                Private Const FOREGROUND_INTENSITY = &H8     '  text color is intensified.
                Private Const FOREGROUND_RED = &H4     '  text color contains red.



                Private hOutput As Long

                'The following function writes the content of sText variable into the console window:
                Private Function WriteToConsole(sText As String) As Boolean
                    Dim lWritten As Long

                    If WriteFile(hOutput, sText, Len(sText), lWritten, 0) = 0 Then
                        WriteToConsole = False
                    Else
                        WriteToConsole = True
                    End If
                End Function

                Declare Function sys Lib "msvcrt.dll" Alias "system" (
                                                        ByVal command As String) As Integer
                Public ReadOnly AvaliableCommands As String(,) =
                    {{"cmd", "Either enters into CMD mode if no parameters are specified," &
                            " or executes the specified MS-DOS (aka Command Prompt) command."},
                     {"help", "Displays information for different commands."},
                     {"exit", "Exits the application."}}
                Public Sub DisplayHelp(ByVal Interfer As Boolean)
                    Startup()
                    Win32.FreeConsole()
                    End
                End Sub
                Public Sub Main() 'CheckBox1_CheckedChanged(
                    'sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
                    Dim State As Boolean
                    If Not State Then
                        State = True
                        Startup()
                        Dim User As String() = GetUser()
                        Do
                            Console.Write(User(1) & " -->")
                            Dim Command As String = Console.ReadLine
                            Dim CommandHead As String
                            Dim CommandTail As String
                            If Command.Contains(" "c) Then
                                CommandHead = Command.Split(" "c).First
                                CommandTail = Command.Substring(Command.IndexOf(" "c))
                            Else
                                CommandHead = Command
                                CommandTail = Nothing
                            End If
                            Select Case CommandHead.ToLower
                                Case "cmd"
                                    If CommandTail = Nothing Then
                                        Console.WriteLine("Starting CMD mode...")
                                        CMD.Main()
                                    Else
                                        sys(CommandTail)
                                    End If
                                Case "cmdproc"

                                Case "ui"
                                    Dim CommandMid As String
                                    Try
                                        CommandMid = CommandTail.Split(" "c).First
                                        CommandTail = CommandTail.ToLower.Substring(
                                                    CommandTail.IndexOf(" "c))
                                    Catch ex As NullReferenceException
                                        Console.WriteLine("How to use command ""ui"" :")
                                        Exit Select
                                    End Try
                                    Select Case CommandMid.ToLower
                                        Case "color", "colour"
                                            Dim Where = CommandTail.ToLower.Substring(
                                                CommandTail.IndexOf(" "c))
                                            Dim Colour = Where.Substring(Where.IndexOf(" "c))
                                            Select Case Where.ToLower
                                                Case "front", "fore"
                                                    Select Case Colour.ToLower
                                                        Case ConsoleColor.Black.ToString, "black"
                                                            Console.ForegroundColor =
                                                                ConsoleColor.Black
                                                        Case ConsoleColor.DarkBlue.ToString,
                                                            "darkblue", "dark-blue", "dark blue"
                                                            Console.ForegroundColor =
                                                                ConsoleColor.DarkBlue
                                                    End Select
                                            End Select
                                    End Select
                                Case "help"
                                    Console.WriteLine("Information for commands :")
                                    For Counter As Integer = 0 To AvaliableCommands.GetLength(0) - 1
                                        Console.Write(AvaliableCommands(Counter, 0).
                                                      ToUpper.PadRight(15))
                                        Console.WriteLine(AvaliableCommands(Counter, 1))
                                    Next
                                Case "exit"
                                    Dim Param() As String = CommandTail.Split(" "c)
                                    If Not Param.Contains("/r") Then
                                        Console.WriteLine("Exiting...")
                                        System.Windows.Forms.Application.Exit()
                                        State = False
                                        End
                                    Else
                                        Console.WriteLine("Restarting...")
                                        System.Windows.Forms.Application.Restart()
                                    End If
                                Case "test"
                                    Dim scrbuf As CONSOLE_SCREEN_BUFFER_INFO

                                    'Get the standard output handle
                                    hOutput = GetStdHandle(STD_OUTPUT_HANDLE)
                                    GetConsoleScreenBufferInfo(hOutput, scrbuf)
                                    WriteToConsole("Console Application Example In Visual Basic." & vbCrLf)
                                    WriteToConsole("Written by Nir Sofer" & vbCrLf)
                                    WriteToConsole("Web site: http://nirsoft.mirrorz.com" & vbCrLf & vbCrLf)

                                    'Change the text color to blue
                                    SetConsoleTextAttribute(hOutput, FOREGROUND_BLUE Or FOREGROUND_INTENSITY)
                                    WriteToConsole("Blue Color !!" & vbCrLf)

                                    'Change the text color to yellow
                                    SetConsoleTextAttribute(hOutput, FOREGROUND_RED Or _
                                        FOREGROUND_GREEN Or FOREGROUND_INTENSITY)
                                    WriteToConsole("Yellow Color !!" & vbCrLf)

                                    'Restore the previous text attributes.
                                    SetConsoleTextAttribute(hOutput, scrbuf.wAttributes)
                                    If Len(Command$) <> 0 Then
                                        'Show the command line parameters:
                                        WriteToConsole(vbCrLf &
                                        "Command Line Parameters: " & Command$ & vbCrLf)
                                    End If
                            End Select
                        Loop
                    Else
                        Win32.FreeConsole()
                        End
                    End If
                End Sub
                Friend Function GetUser() As String()
                    If TypeOf My.User.CurrentPrincipal Is  _
                    Security.Principal.WindowsPrincipal Then
                        ' The application is using Windows authentication. 
                        ' The name format is DOMAIN\USERNAME. 
                        Return Split(My.User.Name, "\")
                    Else
                        ' The application is using custom authentication. 
                        Return {"", My.User.Name}
                    End If
                End Function
                Friend Sub Startup()
                    Win32.AllocConsole()
                    Console.WriteLine("MMLCHelper [Version " &
                                      My.Application.Info.Version.ToString & "]")
                    Console.WriteLine("Copyright (c) 2015 Happypig375.    All rights reserved.")
                    Console.Title = "MMLCHelper"
                    Console.WriteLine()
                End Sub
                Private Class Win32
                    <Runtime.InteropServices.DllImport("kernel32.dll")>
                    Public Shared Function AllocConsole() As Boolean
                    End Function
                    <Runtime.InteropServices.DllImport("kernel32.dll")>
                    Public Shared Function FreeConsole() As Boolean
                    End Function
                End Class
            End Class
#If VBC_VER <= 10 Then
            'Iterator
            Private Function EvenSequence(
ByVal firstNumber As Integer, ByVal lastNumber As Integer) _
As System.Collections.Generic.IEnumerable(Of Integer)
                ' Yield even numbers in the range.
                For number = firstNumber To lastNumber
                    If number Mod 2 = 0 Then
                        'Yield(number)
                    End If
                Next
            End Function
#ElseIf VBC_VER > 10 Then
            Private Iterator Function EvenSequence(
ByVal firstNumber As Integer, ByVal lastNumber As Integer) _
As System.Collections.Generic.IEnumerable(Of Integer)
                ' Yield even numbers in the range.
                For number = firstNumber To lastNumber
                    If number Mod 2 = 0 Then
                        Yield(number)
                    End If
                Next
            End Function
#End If
        End Class
    End Class
End Namespace