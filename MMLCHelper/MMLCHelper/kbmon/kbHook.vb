Imports System
Imports System.Diagnostics
Imports System.IO
Imports System.Runtime.CompilerServices
Imports System.Runtime.InteropServices
Imports System.Text
Imports System.Threading

Namespace kbCapture
    Public Class kbHook
        ' Methods
        Public Sub New()
            kbHook.khp = New keyboardHookProc(AddressOf Me.hookProc)
            kbHook.CaptureBuffer = New Byte(&H3E8  - 1) {}
            kbHook.BufferLock = New Mutex(False, "kbBuffer")
            kbHook.cutIndex = 0
            kbHook.usedIndex = 0
            Me.msgID = kbHook.RegisterWindowMessage("kb Mon Msg")
            Me.MsgThread = New Thread(New ThreadStart(AddressOf Me.GetMsgLoop))
            Me.MsgThread.Start
            Me.hook
        End Sub

        Public Shared Sub AddToBuffer(ByVal code As Short)
            kbHook.BufferLock.WaitOne
            Dim bytes As Byte() = BitConverter.GetBytes(code)
            Dim cutIndex As Integer = kbHook.cutIndex
            Dim i As Integer
            For i = 0 To 2 - 1
                kbHook.CaptureBuffer(cutIndex) = bytes(i)
                cutIndex += 1
                If (cutIndex > &H3E7) Then
                    cutIndex = (cutIndex - &H3E8)
                End If
            Next i
            kbHook.cutIndex = cutIndex
            kbHook.BufferLock.ReleaseMutex
        End Sub

        <DllImport("user32.dll")> _
        Private Shared Function CallNextHookEx(ByVal idHook As IntPtr, ByVal nCode As Integer, ByVal wParam As Integer, ByRef lParam As keyboardHookStruct) As Integer
        End Function

        <DllImport("user32.dll")> _
        Private Shared Function CallNextHookEx(ByVal idHook As IntPtr, ByVal nCode As Integer, ByVal wParam As Integer, ByRef lParam As MessageHookStruct) As Integer
        End Function

        Protected Overrides Sub Finalize()
            Try
                Me.unhook()
            Finally
                MyBase.Finalize()
            End Try
        End Sub

        Public Function GetBuffer(ByRef OutBuffer As Byte()) As Integer
            Dim num As Integer
            If (kbHook.cutIndex = kbHook.usedIndex) Then
                Return 0
            End If
            kbHook.BufferLock.WaitOne()
            If (kbHook.cutIndex > kbHook.usedIndex) Then
                num = (kbHook.cutIndex - kbHook.usedIndex)
            Else
                num = ((kbHook.cutIndex + &H3E8) - kbHook.usedIndex)
            End If
            If (num > 100) Then
                num = 100
            End If
            Dim usedIndex As Integer = kbHook.usedIndex
            Dim i As Integer
            For i = 0 To num - 1
                OutBuffer(i) = kbHook.CaptureBuffer(usedIndex)
                usedIndex += 1
                If (usedIndex > &H3E7) Then
                    usedIndex = (usedIndex - &H3E8)
                End If
            Next i
            kbHook.usedIndex = usedIndex
            kbHook.BufferLock.ReleaseMutex()
            Return num
        End Function

        <DllImport("Kernel32.dll")> _
        Private Shared Function GetCurrentThreadId() As Integer
        End Function

        <DllImport("user32")> _
        Private Shared Function GetKeyboardState(ByVal pbKeyState As Byte()) As Integer
        End Function

        <DllImport("user32.dll", CallingConvention:=CallingConvention.StdCall, CharSet:=CharSet.Auto)> _
        Private Shared Function GetKeyState(ByVal vKey As Integer) As Short
        End Function

        <DllImport("Kernel32.dll")> _
        Private Shared Function GetLastError() As Integer
        End Function

        <DllImport("kernel32.dll")> _
        Public Shared Function GetModuleHandle(ByVal lpModuleName As String) As IntPtr
        End Function

        Private Sub GetMsgLoop()
            Dim flag As Boolean = False
            Do While Not flag
                Dim msg As MSG
                If (Me.msgThreadID = -1) Then
                    Me.msgThreadID = kbHook.GetCurrentThreadId
                    Dim lpFilename As String = (Directory.GetCurrentDirectory & "\msgID.ini")
                    kbHook.WritePrivateProfileString("General", "ThreadID", Convert.ToString(Me.msgThreadID), lpFilename)
                End If
                Dim hWnd As New IntPtr
                If kbHook.PeekMessage(msg, hWnd, 0, 0, 1) Then
                    If (msg.message = Me.msgID) Then
                        If (msg.wParam = &H16) Then
                            If (Me.ctrl_V_count = 0) Then
                                Me.ctrl_V_count += 1
                            Else
                                Me.ctrl_V_count = 0
                                kbHook.AddToBuffer(CShort(msg.wParam))
                            End If
                        Else
                            kbHook.AddToBuffer(CShort(msg.wParam))
                        End If
                        Console.WriteLine(msg.wParam)
                    End If
                Else
                    kbHook.GetLastError()
                End If
                Thread.Sleep(1)
            Loop
        End Sub

        <DllImport("KERNEL32.DLL", EntryPoint:="GetPrivateProfileStringW", CallingConvention:=CallingConvention.StdCall, CharSet:=CharSet.Unicode, SetLastError:=True, ExactSpelling:=True)> _
        Private Shared Function GetPrivateProfileString(ByVal lpAppName As String, ByVal lpKeyName As String, ByVal lpDefault As String, ByVal lpReturnString As StringBuilder, ByVal nSize As Integer, ByVal lpFilename As String) As Integer
        End Function

        <DllImport("kernel32.dll", SetLastError:=True)> _
        Friend Shared Function GetProcAddress(ByVal hModule As IntPtr, ByVal procName As String) As IntPtr
        End Function

        Public Sub hook()
            kbHook.LoadLibrary("User32")
            Dim mainModule As ProcessModule = Process.GetCurrentProcess.MainModule
            kbHook.hhook = kbHook.SetWindowsHookEx(13, kbHook.khp, kbHook.GetModuleHandle(mainModule.ModuleName), 0)
        End Sub

        Public Function hookProc(ByVal code As Integer, ByVal wParam As Integer, ByRef lParam As keyboardHookStruct) As Integer
            If ((code >= 0) AndAlso ((wParam = &H100) OrElse (wParam = 260))) Then
                kbHook.AddToBuffer(CShort(lParam.vkCode))
            End If
            Return kbHook.CallNextHookEx(kbHook.hhook, code, wParam, lParam)
        End Function

        <DllImport("user32")> _
        Private Shared Function LoadKeyboardLayout(ByVal pwszKLID As Byte(), ByVal Flags As Integer) As IntPtr
        End Function

        <DllImport("kernel32.dll")> _
        Private Shared Function LoadLibrary(ByVal lpFileName As String) As IntPtr
        End Function

        <DllImport("user32.dll", SetLastError:=True)> _
        Private Shared Function PeekMessage(<Out> ByRef lpMsg As MSG, ByVal hWnd As IntPtr, ByVal MsgFilterMin As UInt32, ByVal wMsgFilterMax As UInt32, ByVal wRemoveMsg As UInt32) As Boolean
        End Function

        <DllImport("user32.dll", CallingConvention:=CallingConvention.StdCall, CharSet:=CharSet.Auto)> _
        Private Shared Function RegisterWindowMessage(ByVal lpString As String) As Integer
        End Function

        <DllImport("user32.dll")> _
        Private Shared Function SetWindowsHookEx(ByVal idHook As Integer, ByVal callback As keyboardHookProc, ByVal hInstance As IntPtr, ByVal threadId As UInt32) As IntPtr
        End Function

        <DllImport("user32")> _
        Private Shared Function ToAscii(ByVal uVirtKey As Integer, ByVal uScanCode As Integer, ByVal lpbKeyState As Byte(), ByVal lpwTransKey As Byte(), ByVal fuState As Integer) As Integer
        End Function

        <DllImport("user32")> _
        Private Shared Function ToUnicode(ByVal uVirtKey As Integer, ByVal uScanCode As Integer, ByVal lpbKeyState As Byte(), ByVal lpwTransKey As Byte(), ByVal fuState As Integer) As Integer
        End Function

        Public Sub unhook()
            kbHook.UnhookWindowsHookEx(kbHook.hhook)
        End Sub

        <DllImport("user32.dll")> _
        Private Shared Function UnhookWindowsHookEx(ByVal hInstance As IntPtr) As Boolean
        End Function

        <DllImport("KERNEL32.DLL", EntryPoint:="WritePrivateProfileStringW", CallingConvention:=CallingConvention.StdCall, CharSet:=CharSet.Unicode, SetLastError:=True, ExactSpelling:=True)> _
        Private Shared Function WritePrivateProfileString(ByVal lpAppName As String, ByVal lpKeyName As String, ByVal lpString As String, ByVal lpFilename As String) As Integer
        End Function


        ' Fields
        Private Shared BufferLock As Mutex
        Private Shared CaptureBuffer As Byte()
        Private ctrl_V_count As Integer
        Private Shared cutIndex As Integer
        Private Shared hhook As IntPtr = IntPtr.Zero
        Private Shared hhookMsg As IntPtr = IntPtr.Zero
        Private Shared khp As keyboardHookProc
        Private Const KLF_ACTIVATE As Integer = 1
        Private msgID As Integer
        Private MsgThread As Thread
        Private msgThreadID As Integer = -1
        Private Const PM_REMOVE As Integer = 1
        Private Shared usedIndex As Integer
        Private Const VK_CAPITAL As Byte = 20
        Private Const VK_RETURN As Byte = 13
        Private Const VK_SHIFT As Byte = &H10
        Private Const VK_SPACE As Byte = &H20
        Private Const WH_GETMESSAGE As Integer = 3
        Private Const WH_KEYBOARD_LL As Integer = 13
        Private Const WM_CHAR As Integer = &H102
        Private Const WM_IME_COMPOSITION As Integer = &H10F
        Private Const WM_KEYDOWN As Integer = &H100
        Private Const WM_KEYPRESS As Integer = &H102
        Private Const WM_KEYUP As Integer = &H101
        Private Const WM_SYSKEYDOWN As Integer = 260
        Private Const WM_SYSKEYPRESS As Integer = &H106
        Private Const WM_SYSKEYUP As Integer = &H105

        ' Nested Types
        Public Delegate Function keyboardHookProc(ByVal code As Integer, ByVal wParam As Integer, ByRef lParam As keyboardHookStruct) As Integer

        <StructLayout(LayoutKind.Sequential)> _
        Public Structure keyboardHookStruct
            Public vkCode As Integer
            Public scanCode As Integer
            Public flags As Integer
            Public time As Integer
            Public dwExtraInfo As Integer
        End Structure

        <StructLayout(LayoutKind.Sequential)> _
        Public Structure MessageHookStruct
            Public hwnd As IntPtr
            Public msg As Integer
            Public wParam As IntPtr
            Public lParam As IntPtr
            Public time As Integer
            Public ptx As Integer
            Public pty As Integer
        End Structure

        <StructLayout(LayoutKind.Sequential)> _
        Public Structure MSG
            Public hwnd As IntPtr
            Public message As UInt32
            Public wParam As Integer
            Public lParam As IntPtr
            Public time As UInt32
            Public pt As POINT
        End Structure

        <StructLayout(LayoutKind.Sequential)> _
        Public Structure POINT
            Private x As Integer
            Private y As Integer
        End Structure

        Public Delegate Sub VoidProc()
    End Class
End Namespace

