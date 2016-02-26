Private Declare Sub keybd_event Lib "user32.dll" (ByVal bVk As Byte, ByVal bScan As Byte, ByVal dwFlags As Integer, ByVal dwExtraInfo As Integer)
Private Declare Function MapVirtualKey Lib "user32" Alias "MapVirtualKeyA" (ByVal wCode As Integer, ByVal wMapType As Integer) As Integer
Private Declare Function SystemParametersInfo Lib "user32" Alias "SystemParametersInfoA" (ByVal uAction As Integer, ByVal uParam As Integer, ByRef lpvParam As Integer, ByVal fuWinIni As Integer) As Integer
Private Sub LetKeyGo(ByVal key As Byte)

    Const SPI_GETKEYBOARDDELAY = 22
    Const SPI_GETKEYBOARDSPEED = 10

    Dim kb_delay As Integer
    Dim kb_speed As Integer


    SystemParametersInfo(SPI_GETKEYBOARDDELAY, 0, kb_delay, 0)
    SystemParametersInfo(SPI_GETKEYBOARDSPEED, 0, kb_speed, 0)



    keybd_event(key, MapVirtualKey(key, 0), 2, 0)

End Sub
Private Sub HoldKeyDown(ByVal key As Byte)

    Dim kb_delay As Integer
    Dim kb_speed As Integer


    SystemParametersInfo(SPI_GETKEYBOARDDELAY, 0, kb_delay, 0)
    SystemParametersInfo(SPI_GETKEYBOARDSPEED, 0, kb_speed, 0)



    keybd_event(key, MapVirtualKey(key, 0), 0, 0)
End Sub