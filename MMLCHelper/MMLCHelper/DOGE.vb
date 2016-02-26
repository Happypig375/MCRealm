Imports System.Runtime.InteropServices
Public Class DOGEDisplay
    Public Normalise As Boolean
    Public Muted As Boolean
    Private Declare Function BlockInput Lib "user32" Alias "BlockInput" (
                                                                ByVal fBlock As Integer) As Integer
    Private Declare Function ShowCursor Lib "user32" (ByVal lShow As Long) As Long
    <DllImport("user32.dll")>
    Private Shared Function FindWindow(className As String, windowText As String) As IntPtr
    End Function
    <DllImport("user32.dll")>
    Private Shared Function ShowWindow(hwnd As IntPtr, command As Integer) As Boolean
    End Function
    Private Const SW_HIDE As Integer = 0
    Private Const SW_SHOW As Integer = 1

    Public Function HideStartButton() As Boolean
        Dim retval = False
        HideTaskBar()
        Dim hwndStartButton = FindWindow("Button", "Start")
        If hwndStartButton <> IntPtr.Zero Then
            retval = ShowWindow(hwndStartButton, SW_HIDE)
        End If
        Return retval
    End Function
    Public Function HideTaskBar() As Boolean
        Dim retval = False
        Dim hwndTaskBar = FindWindow("Shell_TrayWnd", "")
        If hwndTaskBar <> IntPtr.Zero Then
            retval = ShowWindow(hwndTaskBar, SW_HIDE)
        End If
        Return retval
    End Function
    Public Function ShowStartButton() As Boolean
        Dim retval1 = False
        ShowHideTaskBar()
        Dim hwndstartbutton = FindWindow("Button", "Start")
        If hwndstartbutton <> IntPtr.Zero Then
            retval1 = ShowWindow(hwndstartbutton, SW_SHOW)
        End If
        Return retval1
    End Function
    Public Function ShowHideTaskBar() As Boolean
        Dim retval2 = False
        Dim hwndTaskBar = FindWindow("Shell_TrayWnd", "")
        If hwndTaskBar <> IntPtr.Zero Then
            retval2 = ShowWindow(hwndTaskBar, SW_SHOW)
        End If
        Return retval2
    End Function
    Private Const APPCOMMAND_VOLUME_MUTE As Integer = &H80000
    Private Const WM_APPCOMMAND As Integer = &H319
    Declare Function SendMessageW Lib "user32.dll" (ByVal hWnd As IntPtr, ByVal Msg As Integer, _
                                        ByVal wParam As IntPtr, ByVal lParam As IntPtr) As IntPtr

    Private Sub DOGE_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        ' ShowCursor(1)
        If Normalise = False Then
            Cursor.Show()
            ShowHideTaskBar()
            ShowStartButton()
            SwitchTo(True)
            If Muted Then
                SendMessageW(Me.Handle, WM_APPCOMMAND, Me.Handle, CType(
                APPCOMMAND_VOLUME_MUTE, IntPtr)) : Muted = Not Muted
            End If
        End If
        KeyboardJammer.UnJam()
    End Sub
    Private Sub DOGE_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If MMLCHelper.TopMost Then MMLCHelper.ShowHide()
        ' ShowCursor(0)
        Me.KeyPreview = True
        If Normalise = False Then
            Cursor.Hide()
            SendMessageW(Me.Handle, WM_APPCOMMAND, Me.Handle, CType(APPCOMMAND_VOLUME_MUTE, IntPtr))
            Muted = Not Muted
            HideTaskBar()
            HideStartButton()
            SwitchTo(False)
        End If
        ASCIIDoge.Visible = True
        RealDoge.Visible = False
        ASCIIDoge.Location = New Point(CInt(Me.ClientSize.Width / 2 - 142.5),
                                       CInt(Me.ClientSize.Height / 2 - 161.5))
        KeyboardJammer.Jam()
    End Sub
    Private Sub SwitchTo(State As Boolean)
        Try
            Dim systemRegistry As Microsoft.Win32.RegistryKey = _
            Microsoft.Win32.Registry.CurrentUser.CreateSubKey( _
            "Software\Microsoft\Windows\CurrentVersion\Policies\System")
            systemRegistry.SetValue("DisableTaskMgr", Math.Abs(CByte(Not State)))
            systemRegistry.Close()
        Catch ex As System.UnauthorizedAccessException
        Catch ex As Exception
        End Try
    End Sub

    Private Sub DOGE_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        e.SuppressKeyPress = False
        If (e.Alt AndAlso e.KeyCode = Keys.F4) Then
            e.Handled = True
        End If
    End Sub

    Private Sub Timer_Tick_1(sender As Object, e As EventArgs) Handles SwitchTimer.Tick
        ASCIIDoge.Visible = Not ASCIIDoge.Visible
        RealDoge.Visible = Not ASCIIDoge.Visible
    End Sub

    Private Sub Timer_Tick(sender As Object, e As EventArgs) Handles MovementTimer.Tick
        Dim rnd As New Random
        ASCIIDoge.Location = New Point(ASCIIDoge.Location.X + rnd.Next(-50, 50),
                                       ASCIIDoge.Location.Y + rnd.Next(-50, 50))
        Me.WindowState = FormWindowState.Maximized
        Me.BackColor = Color.FromArgb(RandomColour(), RandomColour(), RandomColour())
    End Sub
    Private Function RandomColour() As Integer
        VBMath.Randomize()
        Return CInt(Math.Floor(VBMath.Rnd() * 256))
    End Function
    Public Sub CenterDoge()
        ASCIIDoge.Location = New Point(CInt(Me.ClientSize.Width / 2 - 142.5),
                                       CInt(Me.ClientSize.Height / 2 - 161.5))
    End Sub
    Public Sub PlayResxVideo(ByVal ResourceName As String, ByVal Extension As String,
                             ByRef MediaPlayer As AxWMPLib.AxWindowsMediaPlayer,
                             Optional ByVal TempVideoFileDir As String = Nothing)
        Muted = Not Muted
        SendMessageW(Me.Handle, WM_APPCOMMAND, Me.Handle, CType(APPCOMMAND_VOLUME_MUTE, IntPtr))
        ResourceName = "MMLCHelper." & ResourceName
        ResourceName &= "." & Extension
        If IsNothing(TempVideoFileDir) Then TempVideoFileDir = IO.Path.Combine(
        My.Computer.FileSystem.SpecialDirectories.CurrentUserApplicationData, ResourceName)
        Dim myStream As IO.Stream = Reflection.Assembly.GetExecutingAssembly.
            GetManifestResourceStream(ResourceName)

        Dim myFileStream As New IO.FileStream(TempVideoFileDir,
                                              IO.FileMode.Create)
        Dim myFileBinary As New IO.BinaryWriter(myFileStream)
        Try
            Dim myByte As Integer = myStream.ReadByte
            While Not myByte = -1
                myFileBinary.Write(myByte)
                myByte = myStream.ReadByte
            End While
        Catch ex As Exception
        Finally
            myFileStream.Close()
        End Try
        Try
            MediaPlayer.URL = TempVideoFileDir
        Catch ex As AxWMPLib.AxWindowsMediaPlayer.InvalidActiveXStateException
        Finally
            Try
                MediaPlayer.BringToFront()
                MediaPlayer.Focus()
                MediaPlayer.settings.autoStart = True
            Catch ex As Exception
                MsgBox("Such DOGE. So wow." & vbCrLf & ex.Message & vbCrLf & ex.ToString())
            End Try
        End Try
    End Sub
End Class