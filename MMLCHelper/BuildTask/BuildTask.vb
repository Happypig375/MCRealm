Imports System
Imports Microsoft.Build.Framework
Imports Microsoft.Build.Utilities

Namespace BuildTasks
    Public Class IncrementBuildNumber
        Inherits Task
        Public DEBUG As Boolean
        Dim m_AssemblyFileLocation As String
        ' This is the Assembly file
        ' that has the version info.

        Public Overrides Function _
               Execute() As Boolean
            Try
                Return IncrementVersion()
            Catch ex As Exception
                Log.LogError(ex.Message)
                Return False
            End Try
        End Function 'Execute 

        <Required()> Public Property _
                AssemblyFileLocation() As String
            Get
                Return m_AssemblyFileLocation
            End Get
            Set(ByVal value As String)
                m_AssemblyFileLocation = value
            End Set
        End Property


        Private m_ResetRevisionNumber As Boolean
        Public Property ResetRevisionNumber() As Boolean
            Get
                Return m_ResetRevisionNumber
            End Get
            Set(ByVal value As Boolean)
                m_ResetRevisionNumber = value
            End Set
        End Property


        Private Function IncrementVersion() As Boolean

            Dim i As Integer
            Dim FileData() As String
            Dim s As String
            Dim Version As String
            Dim v() As String
            Dim ResetRevision As Boolean = m_ResetRevisionNumber

            ' All the commented msgbox
            ' lines are for debugging.
            ' you don't need them.
            If DEBUG Then
                If MsgBox("IncrementVersion Run on file " & _
                            m_AssemblyFileLocation & _
                                vbNewLine & _
                                vbNewLine & _
                                "Copy path to clipboard?", _
                                MsgBoxStyle.YesNo) = _
                                MsgBoxResult.Yes Then
                    My.Computer.Clipboard.Clear()
                    My.Computer.Clipboard.
                        SetText(m_AssemblyFileLocation)
                End If
            End If

            ' Ok, we have the assembly file, try to open it.
            If IO.File.Exists(m_AssemblyFileLocation) Then

                Try
                    FileData = _
                      IO.File.ReadAllLines(m_AssemblyFileLocation)
                    If DEBUG Then
                        MsgBox("Read " & FileData.Length & _
                                " lines from " & m_AssemblyFileLocation)
                    End If

                    If FileData.Length = 0 Then Return False
                    ' loop through each line
                    's and look for the version lines.
                    For i = 0 To FileData.Length - 1
                        s = FileData(i)
                        If s.Length > 2 Then
                            ' Look to see if it contains
                            ' one of the 2 version lines we want.
                            ' (Not the AssemblyVersion!)
                            'VB: <Assembly: AssemblyVersion("0.0.0.0")> 
                            'VB: <Assembly: AssemblyFileVersion("0.0.0.0")> 
                            'C#: [assembly: AssemblyFileVersion("1.0.0.0")]
                            'C#: [assembly: AssemblyVersion("1.0.0.0")]
                            If Not s.Substring(0, 1) = "'" _
                              And Not s.Substring(0, 2) = "//" Then

                                If s.Contains("AssemblyFileVersion") Then
                                    ' Or s.Contains("AssemblyVersion") Then

                                    If DEBUG Then MsgBox("Target line " & s _
                                       & " found, parsing now.")

                                    ' Get the version from the line.
                                    ' we do this by getting the first
                                    ' " and losing everything before it.
                                    ' do the same after the next "
                                    ' everything left should be version info.
                                    Version = _
                                        Microsoft.VisualBasic.Right(s, _
                                        s.Length - s.IndexOf(Chr(34)) - 1)
                                    Version = _
                                        Microsoft.VisualBasic.Left(Version, _
                                        Version.IndexOf(Chr(34)))

                                    If DEBUG Then MsgBox("Version found = " & Version)

                                    ' Set build number to the number
                                    ' of days that have passed since Jan 1 2000
                                    ' If you want to modifiy what
                                    ' the build number means or does,
                                    ' here is the place.
                                    Dim Major As Byte = 1
                                    Dim Minor As Byte = 0
#If False Then
                                    ' The original method.
                                    Dim BuildNumber As UShort = _
(Math.Abs(DateDiff(DateInterval.Day, Now.Date, CType("JAN/01/2000", Date))))
                                    If DEBUG Then MsgBox("New build number = " & BuildNumber)
#Else
                                    Dim BuildNumber As UShort = 0
#End If
                                    Dim Revision As UShort = 0
                                    v = Version.Split("."c)
                                    If v.Length >= 0 Then _
                                        Major = CByte(Val(v(0)))
                                    If v.Length >= 1 Then _
                                        Minor = CByte(Val(v(1)))
                                    If v.Length >= 2 Then _
                                        BuildNumber = CUShort(Val(v(2)))
#If False Then
                                    ' Yea, the original method.
                                    ResetRevision = _
                                      (BuildNumber <> Val(v(2)))
#End If
                                    If v.Length >= 3 Then _
                                        Revision = CUShort(Val(v(3)) + 1)

                                    ' ok, now that we have
                                    ' the version numbers in their variables
                                    ' it's time to update
                                    ' the build, if needed.
                                    If ResetRevision Then _
                                        Revision = 1
                                    If DEBUG Then _
                                    MsgBox("Replacing version with " _
                                    & Major & "." & Minor & "." & _
                                    BuildNumber & "." & Revision)

                                    ' ok, update the original
                                    ' line from the array.
                                    FileData(i) = _
                                      FileData(i).Replace(Version, _
                                      Major & "." & Minor & "." & _
                                      BuildNumber & "." & Revision)

                                    If DEBUG Then _
                                        MsgBox("Filedata(" & i _
                                     & ") = " & FileData(i))
                                ElseIf s.Contains("AssemblyInformationalVersion") Then
                                    ' Or s.Contains("AssemblyVersion") Then

                                    If DEBUG Then MsgBox("[Info]Target line " & s _
                                       & " found, parsing now.")

                                    ' Get the version from the line.
                                    ' we do this by getting the first
                                    ' " and losing everything before it.
                                    ' do the same after the next "
                                    ' everything left should be version info.
                                    Version = _
                                        Microsoft.VisualBasic.Right(s, _
                                        s.Length - s.IndexOf(Chr(34)) - 1)
                                    Version = _
                                        Microsoft.VisualBasic.Left(Version, _
                                        Version.IndexOf(Chr(34)))

                                    If DEBUG Then MsgBox("[Info]Version found = " & Version)

                                    ' Set build number to the number
                                    ' of days that have passed since Jan 1 2000
                                    ' If you want to modifiy what
                                    ' the build number means or does,
                                    ' here is the place.
                                    Dim Major As Byte = 1
                                    Dim Minor As Byte = 0
#If False Then
                                    ' The original method.
                                    Dim BuildNumber As UShort = _
(Math.Abs(DateDiff(DateInterval.Day, Now.Date, CType("JAN/01/2000", Date))))
                                    If DEBUG Then MsgBox("New build number = " & BuildNumber)
#Else
                                    Dim BuildNumber As UShort = 0
#End If
                                    Dim Revision As UShort = 0
                                    v = Version.Split("."c)
                                    Try

                                        If v.Length >= 0 Then _
                                            Major = CByte(Val(v(0)))
                                        If v.Length = 1 Then Exit Try
                                        If v.Length >= 1 Then _
                                            Minor = CByte(Val(v(1)))
                                        If v.Length = 2 Then Exit Try
                                        If v.Length >= 2 Then _
                                            BuildNumber = CUShort(Val(v(2)))
                                    Finally
                                        v = v.Last.Split(" "c)
                                    End Try

                                    ' ok, now that we have
                                    ' the version numbers in their variables
                                    ' it's time to update
                                    ' the build, if needed.
                                    If ResetRevision Then _
                                        Revision = 1
                                    If DEBUG Then _
                                    MsgBox("[Info]Replacing version with " _
                                    & Major & "." & Minor & "." & _
                                    BuildNumber & "." & Revision)

                                    ' ok, update the original
                                    ' line from the array.
                                    FileData(i) = _
                                      FileData(i).Replace(Version, _
                                      Major & "." & Minor & "." & _
                                      BuildNumber & "." & Revision)

                                    If DEBUG Then _
                                        MsgBox("[Info]Filedata(" & i _
                                     & ") = " & FileData(i))
                                End If
                            End If
                        End If
                    Next

                    ' ok, rewrite the assembly info back
                    ' into the file, and let's home
                    ' the compiler picks it up
                    If DEBUG Then MsgBox("writing all data back to file")
                    IO.File.WriteAllLines(m_AssemblyFileLocation, _
                                                        FileData)


                Catch ex As Exception
                    ' hrm. Error. Fail please.
                    MsgBox("ERROR! " & ex.Message, MsgBoxStyle.Critical, "Build Tasks")
                    Log.LogError(ex.Message)
                    Return False
                End Try
            End If

            ' return success
            Return True
        End Function

    End Class
End Namespace