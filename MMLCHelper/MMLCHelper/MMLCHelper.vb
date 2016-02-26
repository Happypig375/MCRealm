Imports System.IO
Public Class MMLCHelper
    Dim change As Boolean
    Private ShownXClassNotInstalled As Boolean = False
    Private AppDataTemp, InstallDirTemp As String
    Private ITSDOGE As Boolean = True
    Private RestoreSize As New Size
    Public resources As System.ComponentModel.ComponentResourceManager =
        New System.ComponentModel.ComponentResourceManager(GetType(MMLCHelper))
    Private Interfer As Boolean = My.Computer.FileSystem.FileExists("MMLCHelper.dll")
    Sub Restart()
        Dim result As MsgBoxResult = MsgBox("A restart is required to apply these changes." & _
                            Chr(13) & "Restart now?", MsgBoxStyle.YesNo Or MsgBoxStyle.Question)
        If result = MsgBoxResult.No Then
            Warning.Visible = True
            Exit Sub
        End If
        Dim P As New Process
        Dim s As New ProcessStartInfo("shutdown", " -g -m " & My.Computer.Name & "  -f -t 0")
        s.UseShellExecute = False
        s.CreateNoWindow = True
        s.RedirectStandardOutput = True
        s.RedirectStandardError = True
        P = New Process
        P.StartInfo = s
        P.Start()
        P.EnableRaisingEvents = True
    End Sub
    Private Sub KillXClass()
        Dim pList() As System.Diagnostics.Process =
    System.Diagnostics.Process.GetProcessesByName("xstudent")
        For Each proc As System.Diagnostics.Process In pList
            Dim resp As MsgBoxResult = MsgBoxResult.Yes
            'resp = MsgBox("Terminate " & proc.ProcessName & "?" & Chr(13) & "If you do not" &
            ' " terminate it, then we cannot uninstall Minecraft.", MsgBoxStyle.YesNo, "Terminate?")
            If resp = MsgBoxResult.Yes Then
                proc.Kill()
                proc.WaitForExit()
            Else : Exit Sub
            End If
        Next
    End Sub

    Private Sub Toggler_Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs) _
                                                                            Handles Toggler.Scroll
        Select Case Toggler.Value
            Case 0
                Rename("C:\Program Files\Sun-Tech\XCLASS EVO\student\xstudent.exe" & Chr(1), _
                       "C:\Program Files\Sun-Tech\XCLASS EVO\student\xstudent.exe")
                If MethodAlpha.Checked = True Then
                    Restart()
                ElseIf MethodBeta.Checked = True Then
                    System.Diagnostics.Process.Start( _
                        "C:\Program Files\Sun-Tech\XCLASS EVO\student\xstudent.exe")
                Else
                    MsgBox("Please select a method first.", MsgBoxStyle.Information)
                    Toggler.Value = 1
                End If
            Case 1
                Rename("C:\Program Files\Sun-Tech\XCLASS EVO\student\xstudent.exe", _
                       "C:\Program Files\Sun-Tech\XCLASS EVO\student\xstudent.exe" & Chr(1))
                If MethodAlpha.Checked = True Then
                    Restart()
                ElseIf MethodBeta.Checked = True Then
                    KillXClass()
                Else
                    MsgBox("Please select a method first.", MsgBoxStyle.Information)
                    Toggler.Value = 0
                End If
                'Shell("cmd.exe /c ipconfig/renew")
                Shell("NET START DHCP")
                'Shell("cmd.exe /c ipconfig/release")
                'Shell("NET STOP DHCP")
        End Select
    End Sub

    Private Sub XClassToggler_Layout(ByVal sender As System.Object, ByVal e As System.EventArgs) _
                                                                        Handles XClassToggler.Layout
        Dim unchanged As Boolean = Microsoft.VisualBasic.FileIO.FileSystem.FileExists _
                                   ("C:\Program Files\Sun-Tech\XCLASS EVO\student\xstudent.exe")
        Dim changed As Boolean = Microsoft.VisualBasic.FileIO.FileSystem.FileExists _
                        ("C:\Program Files\Sun-Tech\XCLASS EVO\student\xstudent.exe" & Chr(1))
        If Not (unchanged Or changed Or ShownXClassNotInstalled) Then
            MsgBox("XClass Student Client is not installed!", MsgBoxStyle.Critical Or
                                                                    MsgBoxStyle.SystemModal, "Error")
            ' Toggler.Enabled = False
            ' MethodAlpha.Enabled = False
            ' MethodBeta.Enabled = False
            ' ShownXClassNotInstalled = True
            XClassToggler.Enabled = False
            For Each Control As Control _
                In XClassToggler.Controls
                Control.Enabled = False
            Next
        End If
        If unchanged Then
            Toggler.Value = 0
        Else : Toggler.Value = 1
        End If
    End Sub

    Private Sub About_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) _
                                                                            Handles MyBase.Load
        Dim CommandsWriter As System.IO.StreamWriter = My.Computer.FileSystem.OpenTextFileWriter(
            "options.lnk", False, System.Text.UnicodeEncoding.Unicode)
        ' Set the title of the form.
        Dim ApplicationTitle As String
        If My.Application.Info.Title <> "" Then
            ApplicationTitle = My.Application.Info.Title
        Else
            ApplicationTitle = System.IO.Path.GetFileNameWithoutExtension _
                (My.Application.Info.AssemblyName)
        End If
        About.Text = String.Format("About {0}", ApplicationTitle)
        InstallDirFinder.SelectedPath = My.Computer.FileSystem.SpecialDirectories.ProgramFiles & _
                                                                                        "\Minecraft"
        AppDataFinder.SelectedPath = Environment.GetFolderPath(Environment. _
                                                   SpecialFolder.ApplicationData) & "\.minecraft"
        RestoreSize = Me.ClientSize
    End Sub

    Private Sub OKButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
                                                                            Handles OKButton.Click
        Tabs.SelectedIndex -= 1
    End Sub

    Private Sub Autorun_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
                                                                       Handles Autorun.CheckedChanged
        Select Case Autorun.Checked
            Case True
                AutorunBox.Enabled = True
            Case False
                AutorunBox.Enabled = False
        End Select
    End Sub

    Private Sub Options_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _
                                                                                        MyBase.Load
        Tabs.TabPages.Remove(Tasks)
        SwitchForce_CheckedChanged(sender, e)
        SwitchIfEnabled_CheckedChanged(sender, e)
        Autorun_CheckedChanged(sender, e)
    End Sub

    Private Sub About_Layout(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _
                                                                                        About.Layout
        ' Initialize all of the text displayed on the About Box.
        ' TODO: Customize the application's assembly information in the "Application" pane of 
        '    the project properties dialog (under the "Project" menu).
        Me.LabelProductName.Text = My.Application.Info.ProductName
        Me.LabelVersion.Text = String.Format("Version {0}", My.Application.Info.Version.ToString)
        Me.LabelCopyright.Text = My.Application.Info.Copyright
        Me.LabelCompanyName.Text = My.Application.Info.CompanyName
        Me.TextBoxDescription.Text = My.Application.Info.Description
    End Sub

    Private Sub SwitchIfEnabled_CheckedChanged(ByVal sender As System _
                          .Object, ByVal e As System.EventArgs) Handles SwitchIfEnabled.CheckedChanged
        SwitchOptions.Enabled = SwitchIfEnabled.Checked
    End Sub

    Private Sub SwitchForce_CheckedChanged(sender As Object, e As EventArgs) Handles SwitchForce. _
                                                                                        CheckedChanged
        SwitchTimeout.Enabled = Not SwitchForce.Checked
    End Sub

    Private Sub InstallDirButton_Click(sender As Object, e As EventArgs) Handles InstallDirButton.Click
        If InstallDirFinder.ShowDialog() <> DialogResult.OK Then Exit Sub
        InstallDir.Text = InstallDirFinder.SelectedPath
    End Sub

    Private Sub InstallDir_KeyDown(sender As Object, e As EventArgs) Handles InstallDir.TextChanged
        InstallDir.Text = InstallDirFinder.SelectedPath
    End Sub

    Private Sub Install_Click(sender As Object, e As EventArgs) Handles Install.Click
        Try
            My.Computer.FileSystem.CopyDirectory(My.Application.Info.DirectoryPath & "\Minecraft", _
                                                 InstallDirFinder.SelectedPath)
            My.Computer.FileSystem.CopyDirectory(My.Application.Info.DirectoryPath & "\.minecraft", _
                                                 AppDataFinder.SelectedPath)
            MsgBox("Minecraft sucessfully installed!", MsgBoxStyle.Information)
            If MsgBox("Would you like to start Minecraft now?", MsgBoxStyle.Question Or _
                      MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                System.Diagnostics.Process.Start(InstallDirFinder.SelectedPath & "\Minecraft.exe")
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub
    Private Sub CreateZip_Click(sender As Object, e As EventArgs) Handles CreateZip.Click
        MsgBox("This feature was not inplemented." & Chr(13) & "Trolololol ;)")
    End Sub

    Private Sub Minecraft_Layout(sender As Object, e As EventArgs) Handles Minecraft.Layout
        AppData.Checked = True
    End Sub

    Private Sub AppData_CheckedChanged(sender As Object, e As EventArgs) Handles AppData.CheckedChanged
        Select Case AppData.Checked
            Case True
                AppDataPath.Enabled = False
                AppDataButton.Enabled = False
                AppDataTemp = AppDataFinder.SelectedPath
                AppDataFinder.SelectedPath = Environment.GetFolderPath(Environment. _
                                                   SpecialFolder.ApplicationData) & "\.minecraft"
            Case False
                AppDataPath.Enabled = True
                AppDataButton.Enabled = True
                AppDataFinder.SelectedPath = AppDataTemp
        End Select
        AppDataPath_KeyDown(sender, e)
    End Sub

    Private Sub AppDataButton_Click(sender As Object, e As EventArgs) Handles AppDataButton.Click
        If AppDataFinder.ShowDialog() <> DialogResult.OK Then Exit Sub
        AppDataPath.Text = AppDataFinder.SelectedPath
    End Sub

    Private Sub AppDataPath_KeyDown(sender As Object, e As EventArgs) Handles AppDataPath.TextChanged
        AppDataPath.Text = AppDataFinder.SelectedPath
    End Sub

    Private Sub DOGESwitch_Click(sender As Object, e As EventArgs) Handles DOGESwitch.Click
        DOGE1.Visible = Not DOGE1.Visible
        DOGE2.Visible = Not DOGE2.Visible
    End Sub

    Private Sub Uninstall_Click(sender As Object, e As EventArgs) Handles Uninstall.Click
        Try
            Dim pList() As System.Diagnostics.Process =
                System.Diagnostics.Process.GetProcessesByName("javaw")
            For Each proc As System.Diagnostics.Process In pList
                Dim resp As MsgBoxResult
                resp = MsgBox("Terminate " & proc.ProcessName & "?" & Chr(13) & "If you do not" &
                    " terminate it, then we cannot uninstall Minecraft.", MsgBoxStyle.YesNo, "Terminate?")
                If resp = MsgBoxResult.Yes Then
                    proc.Kill()
                    proc.WaitForExit()
                Else : Exit Sub
                End If
            Next
            My.Computer.FileSystem.DeleteDirectory(InstallDirFinder.SelectedPath, FileIO.UIOption _
        .OnlyErrorDialogs, FileIO.RecycleOption.DeletePermanently, FileIO.UICancelOption.DoNothing)
            My.Computer.FileSystem.DeleteDirectory(AppDataFinder.SelectedPath, FileIO. _
                                                   DeleteDirectoryOption.DeleteAllContents)
            MsgBox("Minecraft sucessfully uninstalled!", MsgBoxStyle.Information)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub UpdateMC_Click(sender As Object, e As EventArgs) Handles UpdateMC.Click
        If UpdateMCFinder.ShowDialog() <> Windows.Forms.DialogResult.OK Then Exit Sub
        My.Computer.FileSystem.CopyDirectory(UpdateMCFinder.SelectedPath, AppDataFinder.SelectedPath _
                                                                                      & "\versions")
        MsgBox("Successfully added version " & UpdateMCFinder.SelectedPath &
                                                                    " to the versions folder.")
    End Sub

    Private Sub ProgFiles_CheckedChanged(sender As Object, e As EventArgs) Handles _
                                                                            ProgFiles.CheckedChanged
        Select Case ProgFiles.Checked
            Case True
                InstallDir.Enabled = False
                InstallDirButton.Enabled = False
                InstallDirTemp = AppDataFinder.SelectedPath
                InstallDirFinder.SelectedPath = My.Computer.FileSystem.SpecialDirectories. _
                                                ProgramFiles & "\Minecraft"
            Case False
                InstallDir.Enabled = True
                InstallDirButton.Enabled = True
                InstallDirFinder.SelectedPath = AppDataTemp
        End Select
        InstallDir_KeyDown(sender, e)
    End Sub
#Region "System-wide Hotkeys"
    Enum HotkeyModifier As UShort
        None = &H0
        Alt = &H1 'Alt key
        Control = &H2
        Shift = &H4
        Windows = &H8
        WM_HOTKEY = &H312
        Norepeat = &H4000
    End Enum
    '


    <Runtime.InteropServices.DllImport("User32.dll")> _
    Public Shared Function RegisterHotKey(ByVal hwnd As IntPtr, ByVal id As Integer, _
                                    ByVal fsModifiers As Integer, ByVal vk As Integer) As Integer
    End Function
    Public Enum VirtualKeyCode As UInteger
        '''<summary>Left mouse button</summary>
        VK_LBUTTON = &H1
        '''<summary>Right mouse button</summary>
        VK_RBUTTON = &H2
        '''<summary>Control-break processing</summary>
        VK_CANCEL = &H3
        '''<summary>Middle mouse button (three-button mouse)</summary>
        VK_MBUTTON = &H4
        '''<summary>X1 mouse button</summary>
        VK_XBUTTON1 = &H5
        '''<summary>X2 mouse button</summary>
        VK_XBUTTON2 = &H6
        '''<summary>BACKSPACE key</summary>
        VK_BACK = &H8
        '''<summary>TAB key</summary>
        VK_TAB = &H9
        '''<summary>CLEAR key</summary>
        VK_CLEAR = &HC
        '''<summary>ENTER key</summary>
        VK_RETURN = &HD
        '''<summary>SHIFT key</summary>
        VK_SHIFT = &H10
        '''<summary>CTRL key</summary>
        VK_CONTROL = &H11
        '''<summary>ALT key</summary>
        VK_MENU = &H12
        '''<summary>PAUSE key</summary>
        VK_PAUSE = &H13
        '''<summary>CAPS LOCK key</summary>
        VK_CAPITAL = &H14
        '''<summary>IME Kana mode</summary>
        VK_KANA = &H15
        '''<summary>IME Hanguel mode (maintained for compatibility; use VK_HANGUL)</summary>
        VK_HANGUEL = &H15
        '''<summary>IME Hangul mode</summary>
        VK_HANGUL = &H15
        '''<summary>IME Junja mode</summary>
        VK_JUNJA = &H17
        '''<summary>IME final mode</summary>
        VK_FINAL = &H18
        '''<summary>IME Hanja mode</summary>
        VK_HANJA = &H19
        '''<summary>IME Kanji mode</summary>
        VK_KANJI = &H19
        '''<summary>ESC key</summary>
        VK_ESCAPE = &H1B
        '''<summary>IME convert</summary>
        VK_CONVERT = &H1C
        '''<summary>IME nonconvert</summary>
        VK_NONCONVERT = &H1D
        '''<summary>IME accept</summary>
        VK_ACCEPT = &H1E
        '''<summary>IME mode change request</summary>
        VK_MODECHANGE = &H1F
        '''<summary>SPACEBAR</summary>
        VK_SPACE = &H20
        '''<summary>PAGE UP key</summary>
        VK_PRIOR = &H21
        '''<summary>PAGE DOWN key</summary>
        VK_NEXT = &H22
        '''<summary>END key</summary>
        VK_END = &H23
        '''<summary>HOME key</summary>
        VK_HOME = &H24
        '''<summary>LEFT ARROW key</summary>
        VK_LEFT = &H25
        '''<summary>UP ARROW key</summary>
        VK_UP = &H26
        '''<summary>RIGHT ARROW key</summary>
        VK_RIGHT = &H27
        '''<summary>DOWN ARROW key</summary>
        VK_DOWN = &H28
        '''<summary>SELECT key</summary>
        VK_SELECT = &H29
        '''<summary>PRINT key</summary>
        VK_PRINT = &H2A
        '''<summary>EXECUTE key</summary>
        VK_EXECUTE = &H2B
        '''<summary>PRINT SCREEN key</summary>
        VK_SNAPSHOT = &H2C
        '''<summary>INS key</summary>
        VK_INSERT = &H2D
        '''<summary>DEL key</summary>
        VK_DELETE = &H2E
        '''<summary>HELP key</summary>
        VK_HELP = &H2F
        '''<summary>0 key</summary>
        K_0 = &H30
        '''<summary>1 key</summary>
        K_1 = &H31
        '''<summary>2 key</summary>
        K_2 = &H32
        '''<summary>3 key</summary>
        K_3 = &H33
        '''<summary>4 key</summary>
        K_4 = &H34
        '''<summary>5 key</summary>
        K_5 = &H35
        '''<summary>6 key</summary>
        K_6 = &H36
        '''<summary>7 key</summary>
        K_7 = &H37
        '''<summary>8 key</summary>
        K_8 = &H38
        '''<summary>9 key</summary>
        K_9 = &H39
        '''<summary>A key</summary>
        K_A = &H41
        '''<summary>B key</summary>
        K_B = &H42
        '''<summary>C key</summary>
        K_C = &H43
        '''<summary>D key</summary>
        K_D = &H44
        '''<summary>E key</summary>
        K_E = &H45
        '''<summary>F key</summary>
        K_F = &H46
        '''<summary>G key</summary>
        K_G = &H47
        '''<summary>H key</summary>
        K_H = &H48
        '''<summary>I key</summary>
        K_I = &H49
        '''<summary>J key</summary>
        K_J = &H4A
        '''<summary>K key</summary>
        K_K = &H4B
        '''<summary>L key</summary>
        K_L = &H4C
        '''<summary>M key</summary>
        K_M = &H4D
        '''<summary>N key</summary>
        K_N = &H4E
        '''<summary>O key</summary>
        K_O = &H4F
        '''<summary>P key</summary>
        K_P = &H50
        '''<summary>Q key</summary>
        K_Q = &H51
        '''<summary>R key</summary>
        K_R = &H52
        '''<summary>S key</summary>
        K_S = &H53
        '''<summary>T key</summary>
        K_T = &H54
        '''<summary>U key</summary>
        K_U = &H55
        '''<summary>V key</summary>
        K_V = &H56
        '''<summary>W key</summary>
        K_W = &H57
        '''<summary>X key</summary>
        K_X = &H58
        '''<summary>Y key</summary>
        K_Y = &H59
        '''<summary>Z key</summary>
        K_Z = &H5A
        '''<summary>Left Windows key (Natural keyboard)</summary>
        VK_LWIN = &H5B
        '''<summary>Right Windows key (Natural keyboard)</summary>
        VK_RWIN = &H5C
        '''<summary>Applications key (Natural keyboard)</summary>
        VK_APPS = &H5D
        '''<summary>Computer Sleep key</summary>
        VK_SLEEP = &H5F
        '''<summary>Numeric keypad 0 key</summary>
        VK_NUMPAD0 = &H60
        '''<summary>Numeric keypad 1 key</summary>
        VK_NUMPAD1 = &H61
        '''<summary>Numeric keypad 2 key</summary>
        VK_NUMPAD2 = &H62
        '''<summary>Numeric keypad 3 key</summary>
        VK_NUMPAD3 = &H63
        '''<summary>Numeric keypad 4 key</summary>
        VK_NUMPAD4 = &H64
        '''<summary>Numeric keypad 5 key</summary>
        VK_NUMPAD5 = &H65
        '''<summary>Numeric keypad 6 key</summary>
        VK_NUMPAD6 = &H66
        '''<summary>Numeric keypad 7 key</summary>
        VK_NUMPAD7 = &H67
        '''<summary>Numeric keypad 8 key</summary>
        VK_NUMPAD8 = &H68
        '''<summary>Numeric keypad 9 key</summary>
        VK_NUMPAD9 = &H69
        '''<summary>Multiply key</summary>
        VK_MULTIPLY = &H6A
        '''<summary>Add key</summary>
        VK_ADD = &H6B
        '''<summary>Separator key</summary>
        VK_SEPARATOR = &H6C
        '''<summary>Subtract key</summary>
        VK_SUBTRACT = &H6D
        '''<summary>Decimal key</summary>
        VK_DECIMAL = &H6E
        '''<summary>Divide key</summary>
        VK_DIVIDE = &H6F
        '''<summary>F1 key</summary>
        VK_F1 = &H70
        '''<summary>F2 key</summary>
        VK_F2 = &H71
        '''<summary>F3 key</summary>
        VK_F3 = &H72
        '''<summary>F4 key</summary>
        VK_F4 = &H73
        '''<summary>F5 key</summary>
        VK_F5 = &H74
        '''<summary>F6 key</summary>
        VK_F6 = &H75
        '''<summary>F7 key</summary>
        VK_F7 = &H76
        '''<summary>F8 key</summary>
        VK_F8 = &H77
        '''<summary>F9 key</summary>
        VK_F9 = &H78
        '''<summary>F10 key</summary>
        VK_F10 = &H79
        '''<summary>F11 key</summary>
        VK_F11 = &H7A
        '''<summary>F12 key</summary>
        VK_F12 = &H7B
        '''<summary>F13 key</summary>
        VK_F13 = &H7C
        '''<summary>F14 key</summary>
        VK_F14 = &H7D
        '''<summary>F15 key</summary>
        VK_F15 = &H7E
        '''<summary>F16 key</summary>
        VK_F16 = &H7F
        '''<summary>F17 key</summary>
        VK_F17 = &H80
        '''<summary>F18 key</summary>
        VK_F18 = &H81
        '''<summary>F19 key</summary>
        VK_F19 = &H82
        '''<summary>F20 key</summary>
        VK_F20 = &H83
        '''<summary>F21 key</summary>
        VK_F21 = &H84
        '''<summary>F22 key</summary>
        VK_F22 = &H85
        '''<summary>F23 key</summary>
        VK_F23 = &H86
        '''<summary>F24 key</summary>
        VK_F24 = &H87
        '''<summary>NUM LOCK key</summary>
        VK_NUMLOCK = &H90
        '''<summary>SCROLL LOCK key</summary>
        VK_SCROLL = &H91
        '''<summary>Left SHIFT key</summary>
        VK_LSHIFT = &HA0
        '''<summary>Right SHIFT key</summary>
        VK_RSHIFT = &HA1
        '''<summary>Left CONTROL key</summary>
        VK_LCONTROL = &HA2
        '''<summary>Right CONTROL key</summary>
        VK_RCONTROL = &HA3
        '''<summary>Left MENU key</summary>
        VK_LMENU = &HA4
        '''<summary>Right MENU key</summary>
        VK_RMENU = &HA5
        '''<summary>Browser Back key</summary>
        VK_BROWSER_BACK = &HA6
        '''<summary>Browser Forward key</summary>
        VK_BROWSER_FORWARD = &HA7
        '''<summary>Browser Refresh key</summary>
        VK_BROWSER_REFRESH = &HA8
        '''<summary>Browser Stop key</summary>
        VK_BROWSER_STOP = &HA9
        '''<summary>Browser Search key</summary>
        VK_BROWSER_SEARCH = &HAA
        '''<summary>Browser Favorites key</summary>
        VK_BROWSER_FAVORITES = &HAB
        '''<summary>Browser Start and Home key</summary>
        VK_BROWSER_HOME = &HAC
        '''<summary>Volume Mute key</summary>
        VK_VOLUME_MUTE = &HAD
        '''<summary>Volume Down key</summary>
        VK_VOLUME_DOWN = &HAE
        '''<summary>Volume Up key</summary>
        VK_VOLUME_UP = &HAF
        '''<summary>Next Track key</summary>
        VK_MEDIA_NEXT_TRACK = &HB0
        '''<summary>Previous Track key</summary>
        VK_MEDIA_PREV_TRACK = &HB1
        '''<summary>Stop Media key</summary>
        VK_MEDIA_STOP = &HB2
        '''<summary>Play/Pause Media key</summary>
        VK_MEDIA_PLAY_PAUSE = &HB3
        '''<summary>Start Mail key</summary>
        VK_LAUNCH_MAIL = &HB4
        '''<summary>Select Media key</summary>
        VK_LAUNCH_MEDIA_SELECT = &HB5
        '''<summary>Start Application 1 key</summary>
        VK_LAUNCH_APP1 = &HB6
        '''<summary>Start Application 2 key</summary>
        VK_LAUNCH_APP2 = &HB7
        '''<summary>Used for miscellaneous characters; it can vary by keyboard. For the US standard keyboard, the ';:' key</summary>
        VK_OEM_1 = &HBA
        '''<summary>For any country/region, the '+' key</summary>
        VK_OEM_PLUS = &HBB
        '''<summary>For any country/region, the ',' key</summary>
        VK_OEM_COMMA = &HBC
        '''<summary>For any country/region, the '-' key</summary>
        VK_OEM_MINUS = &HBD
        '''<summary>For any country/region, the '.' key</summary>
        VK_OEM_PERIOD = &HBE
        '''<summary>Used for miscellaneous characters; it can vary by keyboard. For the US standard keyboard, the '/?' key</summary>
        VK_OEM_2 = &HBF
        '''<summary>Used for miscellaneous characters; it can vary by keyboard. For the US standard keyboard, the '`~' key</summary>
        VK_OEM_3 = &HC0
        '''<summary>Used for miscellaneous characters; it can vary by keyboard. For the US standard keyboard, the '[{' key</summary>
        VK_OEM_4 = &HDB
        '''<summary>Used for miscellaneous characters; it can vary by keyboard. For the US standard keyboard, the '\\|' key</summary>
        VK_OEM_5 = &HDC
        '''<summary>Used for miscellaneous characters; it can vary by keyboard. For the US standard keyboard, the ']}' key</summary>
        VK_OEM_6 = &HDD
        '''<summary>Used for miscellaneous characters; it can vary by keyboard. For the US standard keyboard, the 'single-quote/double-quote' key</summary>
        VK_OEM_7 = &HDE
        '''<summary>Used for miscellaneous characters; it can vary by keyboard.</summary>
        VK_OEM_8 = &HDF
        '''<summary>Either the angle bracket key or the backslash key on the RT 102-key keyboard</summary>
        VK_OEM_102 = &HE2
        '''<summary>IME PROCESS key</summary>
        VK_PROCESSKEY = &HE5
        '''<summary>Used to pass Unicode characters as if they were keystrokes. The VK_PACKET key is the low word of a 32-bit Virtual Key value used for non-keyboard input methods. For more information, see Remark in KEYBDINPUT, SendInput, WM_KEYDOWN, and WM_KEYUP</summary>
        VK_PACKET = &HE7
        '''<summary>Attn key</summary>
        VK_ATTN = &HF6
        '''<summary>CrSel key</summary>
        VK_CRSEL = &HF7
        '''<summary>ExSel key</summary>
        VK_EXSEL = &HF8
        '''<summary>Erase EOF key</summary>
        VK_EREOF = &HF9
        '''<summary>Play key</summary>
        VK_PLAY = &HFA
        '''<summary>Zoom key</summary>
        VK_ZOOM = &HFB
        '''<summary>PA1 key</summary>
        VK_PA1 = &HFD
        '''<summary>Clear key</summary>
        VK_OEM_CLEAR = &HFE
    End Enum
    <Runtime.InteropServices.DllImport("User32.dll")> _
    Public Shared Function UnregisterHotKey(ByVal hwnd As IntPtr, ByVal id As Integer) As Integer
    End Function
    <Runtime.InteropServices.DllImport("user32.dll", CharSet:=Runtime.InteropServices.CharSet.Auto, ExactSpelling:=True)>
    Public Shared Function GetAsyncKeyState(ByVal vkey As Integer) As Short
    End Function
    Public Shared ReadOnly Property KeyStatus(ByVal Key As Keys) As Boolean
        Get
            If Key = Keys.LButton AndAlso My.Computer.Mouse.ButtonsSwapped Then
                Key = Keys.RButton
            ElseIf Key = Keys.RButton AndAlso My.Computer.Mouse.ButtonsSwapped Then
                Key = Keys.LButton
            End If
            Return CBool(GetAsyncKeyState(Key) And &H8000US)
        End Get
    End Property
    Friend WithEvents DOGEPlayer As AxWMPLib.AxWindowsMediaPlayer
    Public Song As WhichSong
    Dim Awesome_Face_Song As New Media.SoundPlayer(My.Resources.Awesome_Face_Song__Low_)
    Dim Daydreaming As New Media.SoundPlayer(My.Resources.Happy_music___Daydreaming__Low_)
    Dim Awakening As New Media.SoundPlayer(My.Resources.
                                           Main_Reaktor___Awakening__NCS_Release____Full_HD__)
    Dim Nyan_Cat As New Media.SoundPlayer(My.Resources.Nyan_Cat__original___Low_)
    Dim Smoke_weed_everyday As New Media.SoundPlayer(My.Resources.
                        Snoop_dogg_Smoke_weed_everyday_HD__dubstep_remix___Antoine_Daniel_)
    Dim Illuminati_Theme_Song As New Media.SoundPlayer(My.Resources.
                                                    The_Official_Illuminati_Theme_Song__HD_)
    Dim Troll_Song As New Media.SoundPlayer(My.Resources.Troll_Song__Low_)
    Dim Yee As New Media.SoundPlayer(My.Resources.Yee__Low__360p_)
    Dim Doge_Adventure As New Media.SoundPlayer(My.Resources.
                                      Doge_Adventure__animated_music_video__MrWeebl__Full_HD_)
    Dim Ultimate_MLG_Song As New Media.SoundPlayer(My.Resources.
                                        Ultimate_MLG___Most_annoying_video_ever__Low__360p_)
    Dim EnteringCtrlWinKey As Boolean
    Dim EnteringCtrlWinKeyCode As Integer
    Protected Overrides Sub WndProc(ByRef m As System.Windows.Forms.Message)

        Me.DOGEPlayer = New AxWMPLib.AxWindowsMediaPlayer()
        'DOGEPlayer
        '
        CType(Me.DOGEPlayer, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.DOGEPlayer.Enabled = True
        Me.DOGEPlayer.Location = New System.Drawing.Point(248, 200)
        Me.DOGEPlayer.Name = "DOGEPlayer"
        Me.DOGEPlayer.OcxState = CType(resources.GetObject("DOGEPlayer.OcxState"), 
            System.Windows.Forms.AxHost.State)
        Me.DOGEPlayer.Size = New System.Drawing.Size(75, 23)
        Me.DOGEPlayer.TabIndex = 11
        CType(Me.DOGEPlayer, System.ComponentModel.ISupportInitialize).EndInit()
        If m.Msg = HotkeyModifier.WM_HOTKEY Then
            Dim id As IntPtr = m.WParam
            Select Case (id.ToInt32)
                Case 100
                    MessageBox.Show("You pressed ALT+D key combination")
                Case 101
                    MessageBox.Show("You pressed ???+C key combination")
                Case 200
                    DOGEDisplay.CenterDoge()
                    MsgBox("YES")
                Case 300
                    Select Case ITSDOGE
                        Case False
                            Try
                                ITSDOGE = True
                                MMLCHelper.RegisterHotKey(Me.Handle, 200,
                                                          MMLCHelper.HotkeyModifier.None, Keys.F12)
                                DOGEDisplay.Show()
                            Catch ex As Exception
                                MsgBox(ex.Message & Chr(13) & ex.ToString)
                            End Try
                        Case Else
                            ITSDOGE = False
                            MMLCHelper.UnregisterHotKey(Me.Handle, 200)
                            DOGEDisplay.Close()
                    End Select
                Case 301
                    If Not ITSDOGE Then
                        DOGEDisplay.Show()
                        With DOGEDisplay
                            .BackColor = Color.Black
                            .MovementTimer.Enabled = False
                            .SwitchTimer.Enabled = False
                            .ASCIIDoge.Visible = False
                            .RealDoge.Visible = False
                        End With
                    Else : DOGEDisplay.Close()
                    End If
                    ITSDOGE = Not ITSDOGE
                Case 302
                    If Not ITSDOGE Then
                        DOGEDisplay.Show()
                        With DOGEDisplay
                            .BackColor = Color.Navy
                            .MovementTimer.Enabled = False
                            .SwitchTimer.Enabled = False
                            .ASCIIDoge.Visible = True
                            .ASCIIDoge.BringToFront()
                            .ASCIIDoge.ForeColor = Color.Silver
                            .ASCIIDoge.Location = New Point(0, 0)
                            .ASCIIDoge.TextAlign = ContentAlignment.TopLeft
                            .ASCIIDoge.Font = New Font("Consolas", 9.8!, System.Drawing.FontStyle.
                             Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
                            .ASCIIDoge.Text = resources.GetString("BSoD")
                            .RealDoge.Visible = False
                        End With
                    Else : DOGEDisplay.Close()
                    End If
                    ITSDOGE = Not ITSDOGE
                Case 303
                    If Not ITSDOGE Then
                        DOGEDisplay.Show()
                        With DOGEDisplay
                            .Opacity = 0
                            .Normalise = True
                            .MovementTimer.Enabled = False
                            .SwitchTimer.Enabled = False
                            .ASCIIDoge.Visible = False
                            .RealDoge.Visible = False
                        End With
                    Else : DOGEDisplay.Close()
                    End If
                    ITSDOGE = Not ITSDOGE
                Case 311
#If False Then
                        If Not ITSDOGE Then
                            DOGEDisplay.Show()
                            With DOGEDisplay
                                .MovementTimer.Enabled = False
                                .SwitchTimer.Enabled = False
                                .ASCIIDoge.Visible = False
                                .RealDoge.Visible = False
                                .PlayResxVideo("Troll Song", "mp4", DOGEDisplay.DOGEPlayer0)
                            End With
                            ITSDOGE = Not ITSDOGE
                        End If
#End If
                    If Song = WhichSong.Troll_Song Then
                        Troll_Song.Stop()
                        Song = WhichSong.Nothing
                    Else : Troll_Song.PlayLooping() : End If
                    Song = WhichSong.Troll_Song
                Case 312
                    If Song = WhichSong.Nyan_Cat Then
                        Nyan_Cat.Stop()
                        Song = WhichSong.Nothing
                    Else : Nyan_Cat.PlayLooping() : End If
                    Song = WhichSong.Nyan_Cat
                Case 313
                    If Song = WhichSong.Illuminati_Theme_Song Then
                        Illuminati_Theme_Song.Stop()
                        Song = WhichSong.Nothing
                    Else : Illuminati_Theme_Song.PlayLooping() : End If
                    Song = WhichSong.Illuminati_Theme_Song
                Case 314
                    If Song = WhichSong.Awesome_Face_Song Then
                        Awesome_Face_Song.Stop()
                        Song = WhichSong.Nothing
                    Else : Awesome_Face_Song.PlayLooping() : End If
                    Song = WhichSong.Awesome_Face_Song
                Case 315
                    If Song = WhichSong.Smoke_weed_everyday Then
                        Smoke_weed_everyday.Stop()
                        Song = WhichSong.Nothing
                    Else : Smoke_weed_everyday.PlayLooping() : End If
                    Song = WhichSong.Smoke_weed_everyday
                Case 316
                    If Song = WhichSong.Doge_Adventure Then
                        Doge_Adventure.Stop()
                        Song = WhichSong.Nothing
                    Else : Doge_Adventure.PlayLooping() : End If
                    Song = WhichSong.Doge_Adventure
                Case 317
                    If Song = WhichSong.Yee Then
                        Yee.Stop()
                        Song = WhichSong.Nothing
                    Else : Yee.PlayLooping() : End If
                    Song = WhichSong.Yee
                Case 310
                    If Song = WhichSong.Awakening Then
                        Awakening.Stop()
                        Song = WhichSong.Nothing
                    Else : Awakening.PlayLooping() : End If
                    Song = WhichSong.Awakening
                Case 309
                    If Song = WhichSong.Daydreaming Then
                        Daydreaming.Stop()
                        Song = WhichSong.Nothing
                    Else : Daydreaming.PlayLooping() : End If
                    Song = WhichSong.Daydreaming
                Case 308
                    If Song = WhichSong.Ultimate_MLG_Song Then
                        Ultimate_MLG_Song.Stop()
                        Song = WhichSong.Nothing
                    Else : Ultimate_MLG_Song.PlayLooping() : End If
                    Song = WhichSong.Ultimate_MLG_Song
                Case 400
                    If Not EnteringCtrlWinKey Then
                        RegisterHotKey(Me.Handle, 401, HotkeyModifier.None, Keys.D1)
                        RegisterHotKey(Me.Handle, 402, HotkeyModifier.None, Keys.D2)
                        RegisterHotKey(Me.Handle, 403, HotkeyModifier.None, Keys.D3)
                        RegisterHotKey(Me.Handle, 404, HotkeyModifier.None, Keys.D4)
                        RegisterHotKey(Me.Handle, 405, HotkeyModifier.None, Keys.D5)
                        RegisterHotKey(Me.Handle, 406, HotkeyModifier.None, Keys.D6)
                        RegisterHotKey(Me.Handle, 407, HotkeyModifier.None, Keys.D7)
                        RegisterHotKey(Me.Handle, 408, HotkeyModifier.None, Keys.D8)
                        RegisterHotKey(Me.Handle, 409, HotkeyModifier.None, Keys.D9)
                        RegisterHotKey(Me.Handle, 410, HotkeyModifier.None, Keys.D0)
                        RegisterHotKey(Me.Handle, 411, HotkeyModifier.None, Keys.NumPad1)
                        RegisterHotKey(Me.Handle, 412, HotkeyModifier.None, Keys.NumPad2)
                        RegisterHotKey(Me.Handle, 413, HotkeyModifier.None, Keys.NumPad3)
                        RegisterHotKey(Me.Handle, 414, HotkeyModifier.None, Keys.NumPad4)
                        RegisterHotKey(Me.Handle, 415, HotkeyModifier.None, Keys.NumPad5)
                        RegisterHotKey(Me.Handle, 416, HotkeyModifier.None, Keys.NumPad6)
                        RegisterHotKey(Me.Handle, 417, HotkeyModifier.None, Keys.NumPad7)
                        RegisterHotKey(Me.Handle, 418, HotkeyModifier.None, Keys.NumPad8)
                        RegisterHotKey(Me.Handle, 419, HotkeyModifier.None, Keys.NumPad9)
                        RegisterHotKey(Me.Handle, 420, HotkeyModifier.None, Keys.NumPad0)
                        RegisterHotKey(Me.Handle, 421, HotkeyModifier.None, Keys.Back)
                        RegisterHotKey(Me.Handle, 422, HotkeyModifier.None, Keys.Enter)
                        RegisterHotKey(Me.Handle, 423, HotkeyModifier.None, Keys.Escape)
                        RegisterHotKey(Me.Handle, 424, HotkeyModifier.None, Keys.OemMinus)
                        RegisterHotKey(Me.Handle, 425, HotkeyModifier.None, Keys.Subtract)
                    End If
                    EnteringCtrlWinKey = True
                    EnteringCtrlWinKeyCode = 0
                Case 401 To 409
                    EnteringCtrlWinKeyCode = CInt(Str(EnteringCtrlWinKeyCode) & Str(id.ToInt32 - 400))
                Case 410 To 419
                    EnteringCtrlWinKeyCode = CInt(Str(EnteringCtrlWinKeyCode) & Str(id.ToInt32 - 410))
                Case 420
                    EnteringCtrlWinKeyCode = CInt(Str(EnteringCtrlWinKeyCode) & "0")
                Case 421
                    EnteringCtrlWinKeyCode = CInt(Str(EnteringCtrlWinKeyCode).Reverse.ToString.Remove(0).Reverse.ToString)
                Case 422
                    UnregisterInputHotKey()

                Case 423
                    UnregisterInputHotKey()
                    EnteringCtrlWinKeyCode = 0
                Case 424, 425
                    EnteringCtrlWinKeyCode = -EnteringCtrlWinKeyCode
                Case 399
                    ShowHide()
            End Select
        End If
        MyBase.WndProc(m)

    End Sub
    Friend Sub UnregisterInputHotKey()
        EnteringCtrlWinKey = False
        For i As Integer = 401 To 425
            UnregisterHotKey(Me.Handle, i)
        Next
    End Sub
    Friend Sub ShowHide()
        Me.TopMost = Not Me.TopMost
        If Me.TopMost Then
            Me.Show()
            Me.ClientSize = New Size(Me.RestoreBounds.X, Me.RestoreBounds.Y)
            Me.ClientSize = RestoreSize
        Else : Me.Hide()
        End If
    End Sub
    Public Enum WhichSong As Byte
        [Nothing] = 0
        Awesome_Face_Song = 4
        Daydreaming = 8
        Awakening = 9
        Nyan_Cat = 2
        Smoke_weed_everyday = 5
        Illuminati_Theme_Song = 3
        Troll_Song = 1
        Yee = 7
        Doge_Adventure = 6
        Ultimate_MLG_Song = 10
    End Enum
    Friend Sub CodeProc(Code As Long)
        Select Case Code
            Case 1
#If False Then
                        If Not ITSDOGE Then
                            DOGEDisplay.Show()
                            With DOGEDisplay
                                .MovementTimer.Enabled = False
                                .SwitchTimer.Enabled = False
                                .ASCIIDoge.Visible = False
                                .RealDoge.Visible = False
                                .PlayResxVideo("Troll Song", "mp4", DOGEDisplay.DOGEPlayer0)
                            End With
                            ITSDOGE = Not ITSDOGE
                        End If
#End If
                If Song = WhichSong.Troll_Song Then
                    Troll_Song.Stop()
                    Song = WhichSong.Nothing
                Else : Troll_Song.PlayLooping() : End If
                Song = WhichSong.Troll_Song
            Case 2
                If Song = WhichSong.Nyan_Cat Then
                    Nyan_Cat.Stop()
                    Song = WhichSong.Nothing
                Else : Nyan_Cat.PlayLooping() : End If
                Song = WhichSong.Nyan_Cat
            Case 3
                If Song = WhichSong.Illuminati_Theme_Song Then
                    Illuminati_Theme_Song.Stop()
                    Song = WhichSong.Nothing
                Else : Illuminati_Theme_Song.PlayLooping() : End If
                Song = WhichSong.Illuminati_Theme_Song
            Case 4
                If Song = WhichSong.Awesome_Face_Song Then
                    Awesome_Face_Song.Stop()
                    Song = WhichSong.Nothing
                Else : Awesome_Face_Song.PlayLooping() : End If
                Song = WhichSong.Awesome_Face_Song
            Case 5
                If Song = WhichSong.Smoke_weed_everyday Then
                    Smoke_weed_everyday.Stop()
                    Song = WhichSong.Nothing
                Else : Smoke_weed_everyday.PlayLooping() : End If
                Song = WhichSong.Smoke_weed_everyday
            Case 6
                If Song = WhichSong.Doge_Adventure Then
                    Doge_Adventure.Stop()
                    Song = WhichSong.Nothing
                Else : Doge_Adventure.PlayLooping() : End If
                Song = WhichSong.Doge_Adventure
            Case 7
                If Song = WhichSong.Yee Then
                    Yee.Stop()
                    Song = WhichSong.Nothing
                Else : Yee.PlayLooping() : End If
                Song = WhichSong.Yee
            Case 8
                If Song = WhichSong.Awakening Then
                    Awakening.Stop()
                    Song = WhichSong.Nothing
                Else : Awakening.PlayLooping() : End If
                Song = WhichSong.Awakening
            Case 9
                If Song = WhichSong.Daydreaming Then
                    Daydreaming.Stop()
                    Song = WhichSong.Nothing
                Else : Daydreaming.PlayLooping() : End If
                Song = WhichSong.Daydreaming
            Case 10
                If Song = WhichSong.Ultimate_MLG_Song Then
                    Ultimate_MLG_Song.Stop()
                    Song = WhichSong.Nothing
                Else : Ultimate_MLG_Song.PlayLooping() : End If
                Song = WhichSong.Ultimate_MLG_Song
        End Select
    End Sub

    Private Sub MMLCHelper_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        DOGEDisplay.Dispose()
        Me.Dispose()
    End Sub
    Friend Sub Unregister(ByVal sender As System.Object, ByVal e As System.EventArgs)
        UnregisterHotKey(Me.Handle, 100)
        UnregisterHotKey(Me.Handle, 101)
        UnregisterHotKey(Me.Handle, 300)
        UnregisterHotKey(Me.Handle, 301)
        UnregisterHotKey(Me.Handle, 302)
        UnregisterHotKey(Me.Handle, 303)
        UnregisterHotKey(Me.Handle, 311)
        UnregisterHotKey(Me.Handle, 312)
        UnregisterHotKey(Me.Handle, 313)
        UnregisterHotKey(Me.Handle, 314)
        UnregisterHotKey(Me.Handle, 315)
        UnregisterHotKey(Me.Handle, 316)
        UnregisterHotKey(Me.Handle, 317)
        UnregisterHotKey(Me.Handle, 318)
        UnregisterHotKey(Me.Handle, 319)
        UnregisterHotKey(Me.Handle, 310)
        UnregisterHotKey(Me.Handle, 309)
        UnregisterHotKey(Me.Handle, 308)
        UnregisterHotKey(Me.Handle, 399)
        UnregisterHotKey(Me.Handle, 400)
    End Sub


    Friend Sub Register(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        RegisterHotKey(Me.Handle, 100, HotkeyModifier.Alt, Keys.D)
        RegisterHotKey(Me.Handle, 101, HotkeyModifier.Alt + HotkeyModifier.Control, Keys.C)
        'Experimenter^
        RegisterHotKey(Me.Handle, 300, HotkeyModifier.Control + HotkeyModifier.Shift, Keys.F12)
        RegisterHotKey(Me.Handle, 301, HotkeyModifier.Control, Keys.F12)
        RegisterHotKey(Me.Handle, 302, HotkeyModifier.Control + HotkeyModifier.Alt, Keys.F12)
        RegisterHotKey(Me.Handle, 303, HotkeyModifier.Alt, Keys.F12)
        RegisterHotKey(Me.Handle, 311, HotkeyModifier.Control, Keys.F1)
        RegisterHotKey(Me.Handle, 312, HotkeyModifier.Control, Keys.F2)
        RegisterHotKey(Me.Handle, 313, HotkeyModifier.Control, Keys.F3)
        RegisterHotKey(Me.Handle, 314, HotkeyModifier.Control, Keys.F4)
        RegisterHotKey(Me.Handle, 315, HotkeyModifier.Control, Keys.F5)
        RegisterHotKey(Me.Handle, 316, HotkeyModifier.Control, Keys.F6)
        RegisterHotKey(Me.Handle, 317, HotkeyModifier.Control, Keys.F7)
        RegisterHotKey(Me.Handle, 318, HotkeyModifier.Control, Keys.F8)
        RegisterHotKey(Me.Handle, 319, HotkeyModifier.Control, Keys.F9)
        RegisterHotKey(Me.Handle, 310, HotkeyModifier.Control, Keys.F10)
        RegisterHotKey(Me.Handle, 309, HotkeyModifier.Control, Keys.F11)
        RegisterHotKey(Me.Handle, 308, HotkeyModifier.Alt, Keys.F4)
        RegisterHotKey(Me.Handle, 400, HotkeyModifier.Control Or HotkeyModifier.Windows, Keys.None)
        RegisterHotKey(Me.Handle, 399, HotkeyModifier.Alt, Keys.None)
    End Sub
#End Region
    'Author : Mohamed Shimran
    'Blog : http://www.ultimateprogrammingtutorials.blogspot.com
    Private Sub Process_Shown(ByVal sender As System.Object,
                             ByVal e As System.EventArgs) Handles MyBase.Shown
        If Interfer Then GetProcesses()
    End Sub
    Private Function GetCPUUsage(AppName As String) As Single
        Dim AppCPU As New PerformanceCounter("Process", "% Processor Time", AppName, True)
        Return AppCPU.NextValue
    End Function
    Public Shared Function GetProcessInstanceName(ByVal PID As Integer) As String
        Dim cat As New PerformanceCounterCategory("Process")
        Dim instances() = cat.GetInstanceNames()
        For Each instance In instances
            Using cnt As PerformanceCounter = New PerformanceCounter("Process",
                                                                     "ID Process", instance, True)
                Dim val As Integer = CType(cnt.RawValue, Int32)
                If val = PID Then
                    Return instance
                End If
            End Using
        Next
        Return Nothing
    End Function
    Public Function GetUserName(ByVal ProcessName As String) As String()
        Dim selectQuery As Management.SelectQuery = New Management.SelectQuery("Win32_Process")
        Dim searcher As Management.ManagementObjectSearcher =
            New Management.ManagementObjectSearcher(selectQuery)
        Dim y As System.Management.ManagementObjectCollection
        y = searcher.Get
        For Each proc As Management.ManagementObject In y
            Dim s(1) As String
            proc.InvokeMethod("GetOwner", CType(s, Object()))
            Dim n As String = proc("Name").ToString()
            If n = ProcessName & ".exe" Then
                Return (s)
            End If
        Next
        Return {"", "UNKNOWN"}
    End Function
    Public Sub GetProcesses()
        Do While Interfer
            Processes.Items.Clear()
            For Each p In Process.GetProcesses
                Try
                    Dim str(5) As String
                    Dim item As ListViewItem
                    str(0) = p.ProcessName
                    Dim arr(1) As String
                    arr = GetUserName(p.ProcessName)
                    str(1) = arr(1)
                    str(2) = Format(GetCPUUsage(GetProcessInstanceName(p.Id)), "{00}")
                    str(3) = CStr(p.PrivateMemorySize64)
                    Dim ProcessFile = FileVersionInfo.GetVersionInfo(p.MainModule.FileName)
                    str(4) = ProcessFile.FileDescription
                    item = New ListViewItem(str)
                    Processes.Items.Add(item)
                Catch ex As System.ComponentModel.Win32Exception
                    If ex.Message = "Access is denied" Then
                    Else
                        'error handling
                    End If
                End Try
            Next
        Loop
    End Sub
    Public Sub KillProcess()
        Try
            For Each p In Process.GetProcesses
                If Processes.SelectedItems.Contains(Processes.SelectedItems.Item(p.ProcessName)) Then
                    p.Kill()
                End If
            Next
            GetProcesses()
            MsgBox("Done!", MsgBoxStyle.Information)
        Catch ex As Exception
            MsgBox("The operation could not be completed" & Chr(13) & ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub ProcessEnd_Click(ByVal sender As System.Object,
                                 ByVal e As System.EventArgs) Handles ProcessEnd.Click
        KillProcess()
        GetProcesses()
    End Sub

    Private Sub ProcessRefresh_Click(ByVal sender As System.Object,
                                     ByVal e As System.EventArgs) Handles ProcessRefresh.Click
        GetProcesses()
    End Sub

    Private Sub ProcessAutoRefresh_CheckedChanged(sender As Object, e As EventArgs) _
                                                         Handles ProcessAutoRefresh.CheckedChanged
        ProcessUpdate.Enabled = Not ProcessUpdate.Enabled
    End Sub

    Private Sub ProcessUpdate_Tick(sender As Object, e As EventArgs) Handles ProcessUpdate.Tick
        ProcessRefresh_Click(sender, e)
    End Sub

    Private Sub MiniControlPanel_Click(sender As Object, e As EventArgs) Handles MiniControlPanel.Click
        Dim Dir As String = My.Computer.FileSystem. _
                SpecialDirectories.Desktop & "MiniControlPanel.{ED7BA470-8E54-465E-825C-99712043E01C}"
        If Not My.Computer.FileSystem.DirectoryExists(Dir) _
            Then My.Computer.FileSystem.CreateDirectory(Dir)
        System.Diagnostics.Process.Start(Dir)
    End Sub
    Sub test()

    End Sub
    Private Sub XCTester_Tick(sender As Object, e As EventArgs) Handles XCTester.Tick
        ' Dim Hook As New kbCapture.kbHook
        'If Not XCHookInput.Checked Then Hook.unhook()
    End Sub

    Private Sub MiniControlPanelClear_Click(sender As Object, e As EventArgs) _
                                                                Handles MiniControlPanelClear.Click
        Dim Dir As String = IO.Path.Combine(My.Computer.FileSystem.SpecialDirectories. _
                Desktop & "MiniControlPanel.{ED7BA470-8E54-465E-825C-99712043E01C}")
        If My.Computer.FileSystem.DirectoryExists(Dir) _
        Then My.Computer.FileSystem.DeleteDirectory(Dir, FileIO.UIOption.OnlyErrorDialogs,
                                                         FileIO.RecycleOption.DeletePermanently)
    End Sub

    Private Sub CHY_Layout(sender As Object, e As LayoutEventArgs) Handles CHY.Layout
    End Sub
    Dim 別雲間 As New Media.SoundPlayer(My.Resources._09_334_別雲間)
    Dim 敬酒歌 As New Media.SoundPlayer(My.Resources._21_434敬酒歌___何達)
    Private Sub 別雲間Play_Click(sender As Object, e As EventArgs) Handles 別雲間Play.Click
        If CHYLoop.Checked Then
            別雲間.PlayLooping()
        Else : 別雲間.Play()
        End If
    End Sub

    Private Sub 敬酒歌Play_Click(sender As Object, e As EventArgs) Handles 敬酒歌Play.Click
        'System.AppDomain.CurrentDomain.BaseDirectory
        'My.Computer.Audio.Play(My.Resources._21_434敬酒歌___何達, AudioPlayMode.Background)
        If CHYLoop.Checked Then
            敬酒歌.PlayLooping()
        Else : 敬酒歌.Play()
        End If
    End Sub

    Private Sub 別雲間Stop_Click(sender As Object, e As EventArgs) Handles 別雲間Stop.Click
        別雲間.Stop()
    End Sub

    Private Sub 敬酒歌Stop_Click(sender As Object, e As EventArgs) Handles 敬酒歌Stop.Click
        'My.Computer.Audio.Stop()
        敬酒歌.Stop()
    End Sub

    Private Sub RunCmd_Click(ByVal sender As System.Object,
                             ByVal e As System.EventArgs) Handles RunCmd.Click
        CMD.Main()
    End Sub

    Private Sub RunBatch_Click(sender As Object, e As EventArgs) Handles RunBatch.Click
        Dim Batch As My.MyApplication.MyModes.BatchMode
        Batch.Main()
    End Sub

    Private Sub RunProgramWithParamB_Click(sender As Object,
                                           e As EventArgs) Handles RunProgramWithParamB.Click
        If RunProgramWithParamF.ShowDialog() = Windows.Forms.DialogResult.OK Then _
            RunProgramWithParamR.Text = RunProgramWithParamF.FileName
    End Sub

    Friend WithEvents Program As New Process()
    Private Sub RunProgramWithParam_Click(sender As Object,
                                          e As EventArgs) Handles RunProgramWithParam.Click
        Dim s As New ProcessStartInfo(RunProgramWithParamR.Text,
                                      RunProgramWithParamP.Text)
        s.UseShellExecute = RunProgramWithParamS.Checked
        s.CreateNoWindow = Not RunProgramWithParamW.Checked
        s.RedirectStandardOutput = RunProgramWithParamRO.Checked
        s.RedirectStandardError = RunProgramWithParamRO.Checked
        Program.StartInfo = s
        Program.Start()
        Program.EnableRaisingEvents = RunProgramWithParamE.Checked
    End Sub
    Private Sub Program_Exited(sender As Object, e As EventArgs) Handles Program.Exited,
                                                                         Program.Disposed
        MsgBox(String.Format("The program {0} (ID:{1}) has exited.", Program.ProcessName, Program.Id))
    End Sub
    Private Sub Program_DataReceived(sender As Object, e As DataReceivedEventArgs) _
            Handles Program.OutputDataReceived, Program.ErrorDataReceived
        RunProgramWithParamO.Text &= e.Data
        RunProgramWithParamO.Text &= vbCrLf
    End Sub

    Private Sub Authenticate_Click(sender As Object, e As EventArgs) Handles Authenticate.Click

        My.Forms.Login.ShowDialog()
        ' Check if the user was authenticated.
        If My.User.IsAuthenticated Then
            Me.Authenticated.Text = "Authenticated " & My.User.Name
        Else
            Me.Authenticated.Text = "User not authenticated"
        End If

        If My.User.IsInRole(ApplicationServices.BuiltInRole.Administrator) Then
            Me.Administrator.Text = "User is an Administrator"
        Else
            Me.Administrator.Text = "User is not an Administrator"
        End If
    End Sub

    Private Sub HappyBrowser_Navigated(sender As Object, e As WebBrowserNavigatedEventArgs) Handles HappyBrowser.Navigated
        URL.Text = HappyBrowser.Url.AbsolutePath
    End Sub

    Private Sub URL_TextChanged(sender As Object, e As EventArgs) Handles URL.TextChanged
        HappyBrowser.Url = New Uri(URL.Text)
    End Sub

    Private Sub URL_KeyPress(sender As Object, e As KeyPressEventArgs) Handles URL.KeyPress
        If e.KeyChar = Chr(13) Then
            e.Handled = True
            HappyBrowser.Focus()
        End If
    End Sub

    Private Sub Speak_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Speak.KeyPress

    End Sub

    ' Indicate whether the asynchronous emulate recognition
    ' operation has completed.
    Shared completed As Boolean

    Private Shared Sub Main(args As String())

        ' Initialize an instance of the shared recognizer.
        Using recognizer As New Speech.Recognition.SpeechRecognizer()

            ' Create and load a sample grammar.
            Dim testGrammar As New Speech.Recognition.Grammar(
                New Speech.Recognition.GrammarBuilder("testing testing"))
            testGrammar.Name = "Test Grammar"
            recognizer.LoadGrammar(testGrammar)

            ' Attach event handlers for recognition events.
            AddHandler recognizer.SpeechRecognized, New EventHandler(
                Of Speech.Recognition.SpeechRecognizedEventArgs)(AddressOf SpeechRecognizedHandler)
            AddHandler recognizer.EmulateRecognizeCompleted, New EventHandler(
                Of Speech.Recognition.EmulateRecognizeCompletedEventArgs)(
                AddressOf EmulateRecognizeCompletedHandler)

            completed = False

            ' Start asynchronous emulated recognition. 
            ' This matches the grammar and generates a SpeechRecognized event.
            recognizer.EmulateRecognizeAsync("testing testing")

            ' Wait for the asynchronous operation to complete.
            While Not completed
                Threading.Thread.Sleep(333)
            End While

            completed = False

            ' Start asynchronous emulated recognition.
            ' This does not match the grammar or generate a SpeechRecognized event.
            recognizer.EmulateRecognizeAsync("testing one two three")

            ' Wait for the asynchronous operation to complete.
            While Not completed
                Threading.Thread.Sleep(333)
            End While
        End Using

        Console.WriteLine()
        Console.WriteLine("Press any key to exit...")
        Console.ReadKey()
    End Sub

    ' Handle the SpeechRecognized event.
    Private Shared Sub SpeechRecognizedHandler(sender As Object,
                                               e As Speech.Recognition.SpeechRecognizedEventArgs)
        If e.Result IsNot Nothing Then
            Console.WriteLine("Recognition result = {0}", If(e.Result.Text, "<no text>"))
        Else
            Console.WriteLine("No recognition result")
        End If
    End Sub

    ' Handle the SpeechRecognizeCompleted event.
    Private Shared Sub EmulateRecognizeCompletedHandler(sender As Object,
                    e As Speech.Recognition.EmulateRecognizeCompletedEventArgs)
        If e.Result Is Nothing Then
            Console.WriteLine("No result generated.")
        End If

        ' Indicate the asynchronous operation is complete.
        completed = True
    End Sub
End Class
Public Class TExt
    Shared Operator =(ByVal x As Integer, ByVal text As TExt) As TExt
        Throw New NullReferenceException()
    End Operator
    Shared Operator <>(ByVal x As Integer, ByVal text As TExt) As TExt
        Throw New NullReferenceException()
    End Operator
End Class

'=======================================================
'Service provided by Telerik (www.telerik.com)
'Conversion powered by NRefactory.
'Twitter: @telerik
'Facebook: facebook.com/telerik
'=======================================================