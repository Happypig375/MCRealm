Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.Collections
Imports System.Diagnostics
Imports System.IO
Imports System.Runtime.InteropServices
Imports System.Text.RegularExpressions
Imports System.Windows.Forms
Public Class IniFile
    ' Methods
    Public Function AddSection(ByVal sSection As String) As IniSection
        If Invalidate() Then Return Nothing
        Dim section2 As IniSection = Nothing
        sSection = sSection.Trim
        If Me.m_sections.ContainsKey(sSection) Then
            Return DirectCast(Me.m_sections.Item(sSection), IniSection)
        End If
        section2 = New IniSection(Me, sSection)
        Me.m_sections.Item(sSection) = section2
        Return section2
    End Function
    <Obsolete("Not supported.", True)>
    Public Sub Close(ThrowExceptionWhenAccessed As Boolean)
        If Invalidate() Then Return
        Me.Closed = True
    End Sub

    Public Function GetKeyValue(ByVal sSection As String, ByVal sKey As String) As String
        If Invalidate() Then Return Nothing
        Dim section As IniSection = Me.GetSection(sSection)
        If (Not section Is Nothing) Then
            Dim key As IniSection.IniKey = section.GetKey(sKey)
            If (Not key Is Nothing) Then
                Return key.Value
            End If
        End If
        Return String.Empty
    End Function

    Public Function GetSection(ByVal sSection As String) As IniSection
        If Invalidate() Then Return Nothing
        sSection = sSection.Trim
        If Me.m_sections.ContainsKey(sSection) Then
            Return DirectCast(Me.m_sections.Item(sSection), IniSection)
        End If
        Return Nothing
    End Function

    Public Sub Load(ByVal sFileName As String, Optional ByVal bMerge As Boolean = False,
                    Optional ByVal bThrowException As Boolean = False)
        If Invalidate() Then Return
        If Not bMerge Then
            Me.RemoveAllSections()
        End If
        Dim section As IniSection = Nothing
        If Not File.Exists(sFileName) Then
            If bThrowException Then Throw New IO.FileNotFoundException(
                ("File Not Found:" & Environment.NewLine & sFileName))
            Interaction.MsgBox(("File Not Found:" & Environment.NewLine & sFileName),
                               MsgBoxStyle.ApplicationModal, Nothing)
            Application.Exit()
        Else
            Dim reader As New StreamReader(sFileName)
            Dim regex As New Regex("^([\s]*#.*)", (RegexOptions.Singleline Or
                                                   RegexOptions.IgnoreCase))
            Dim regex3 As New Regex("^[\s]*\[[\s]*([^\[\s].*[^\s\]])[\s]*\][\s]*$", (
                                    RegexOptions.Singleline Or RegexOptions.IgnoreCase))
            Dim regex2 As New Regex("^\s*([^=\s]*)[^=]*=(.*)", (
                                    RegexOptions.Singleline Or RegexOptions.IgnoreCase))
            Do While Not reader.EndOfStream
                Dim input As String = reader.ReadLine
                If (input <> String.Empty) Then
                    Dim match As Match = Nothing
                    If regex.Match(input).Success Then
                        match = regex.Match(input)
                        Trace.WriteLine(String.Format("Skipping Comment: {0}",
                                                      match.Groups.Item(0).Value))
                    Else
                        If regex3.Match(input).Success Then
                            match = regex3.Match(input)
                            Trace.WriteLine(String.Format("Adding section [{0}]",
                                                          match.Groups.Item(1).Value))
                            section = Me.AddSection(match.Groups.Item(1).Value)
                            Continue Do
                        End If
                        If (regex2.Match(input).Success AndAlso (Not section Is Nothing)) Then
                            match = regex2.Match(input)
                            Trace.WriteLine(String.Format("Adding Key [{0}]=[{1}]",
                                        match.Groups.Item(1).Value, match.Groups.Item(2).Value))
                            section.AddKey(match.Groups.Item(1).Value).Value =
                                match.Groups.Item(2).Value
                            Continue Do
                        End If
                        If (Not section Is Nothing) Then
                            Trace.WriteLine(String.Format("Adding Key [{0}]", input))
                            section.AddKey(input)
                            Continue Do
                        End If
                        Trace.WriteLine(String.Format("Skipping unknown type of data: {0}", input))
                    End If
                End If
            Loop
            reader.Close()
        End If
    End Sub

    Public Function RemoveAllSections() As Boolean
        If Invalidate() Then Return Nothing
        Me.m_sections.Clear()
        Return (Me.m_sections.Count = 0)
    End Function

    Public Function RemoveKey(ByVal sSection As String, ByVal sKey As String) As Boolean
        If Invalidate() Then Return Nothing
        Dim section As IniSection = Me.GetSection(sSection)
        Return ((Not section Is Nothing) AndAlso section.RemoveKey(sKey))
    End Function

    Public Function RemoveSection(ByVal Section As IniSection) As Boolean
        If Invalidate() Then Return Nothing
        If (Not Section Is Nothing) Then
            Try
                Me.m_sections.Remove(Section.Name)
                Return True
            Catch exception1 As Exception
                ProjectData.SetProjectError(exception1)
                Dim exception As Exception = exception1
                Trace.WriteLine(exception.Message)
                ProjectData.ClearProjectError()
            End Try
        End If
        Return False
    End Function

    Public Function RemoveSection(ByVal sSection As String) As Boolean
        If Invalidate() Then Return Nothing
        sSection = sSection.Trim
        Return Me.RemoveSection(Me.GetSection(sSection))
    End Function

    Public Function RenameKey(ByVal sSection As String, ByVal sKey As String,
                              ByVal sNewKey As String) As Boolean
        If Invalidate() Then Return Nothing
        Dim section As IniSection = Me.GetSection(sSection)
        If (Not section Is Nothing) Then
            Dim key As IniSection.IniKey = section.GetKey(sKey)
            If (Not key Is Nothing) Then
                Return key.SetName(sNewKey)
            End If
        End If
        Return False
    End Function

    Public Function RenameSection(ByVal sSection As String, ByVal sNewSection As String) As Boolean
        If Invalidate() Then Return Nothing
        Dim flag As Boolean = False
        Dim section As IniSection = Me.GetSection(sSection)
        If (Not section Is Nothing) Then
            flag = section.SetName(sNewSection)
        End If
        Return flag
    End Function

    Public Sub Save(ByVal sFileName As String)
        If Invalidate() Then Return
        Dim enumerator As IEnumerator
        Dim writer As New StreamWriter(sFileName, False)
        Try
            enumerator = Me.Sections.GetEnumerator
            Do While enumerator.MoveNext
                Dim enumerator2 As IEnumerator
                Dim current As IniSection = DirectCast(enumerator.Current, IniSection)
                Trace.WriteLine(String.Format("Writing Section: [{0}]", current.Name))
                writer.WriteLine(String.Format("[{0}]", current.Name))
                Try
                    enumerator2 = current.Keys.GetEnumerator
                    Do While enumerator2.MoveNext
                        Dim key As IniSection.IniKey = DirectCast(
                            enumerator2.Current, IniSection.IniKey)
                        If (key.Value <> String.Empty) Then
                            Trace.WriteLine(String.Format("Writing Key: {0}={1}",
                                                          key.Name, key.Value))
                            writer.WriteLine(String.Format("{0}={1}", key.Name, key.Value))
                        Else
                            Trace.WriteLine(String.Format("Writing Key: {0}", key.Name))
                            writer.WriteLine(String.Format("{0}", key.Name))
                        End If
                    Loop
                    Continue Do
                Finally
                    If TypeOf enumerator2 Is IDisposable Then
                        TryCast(enumerator2, IDisposable).Dispose()
                    End If
                End Try
            Loop
        Finally
            If TypeOf enumerator Is IDisposable Then
                TryCast(enumerator, IDisposable).Dispose()
            End If
        End Try
        writer.Close()
    End Sub

    Public Function SetKeyValue(ByVal sSection As String, ByVal sKey As String,
                                ByVal sValue As String) As Boolean
        If Invalidate() Then Return Nothing
        Dim section As IniSection = Me.AddSection(sSection)
        If (Not section Is Nothing) Then
            Dim key As IniSection.IniKey = section.AddKey(sKey)
            If (Not key Is Nothing) Then
                key.Value = sValue
                Return True
            End If
        End If
        Return False
    End Function

    Private Function Invalidate() As Boolean
        If Closed Then
            If Exception Then Throw New ObjectDisposedException("IniFile")
            Return True
        End If
        Return False
    End Function

    ' Properties
    Public ReadOnly Property Sections As ICollection
        Get
            If Invalidate() Then Return Nothing
            Return Me.m_sections.Values
        End Get
    End Property

    ' Fields
    Private m_sections As Hashtable = New Hashtable(StringComparer.InvariantCultureIgnoreCase)
    Private Closed As Boolean
    Private Exception As Boolean

    ' Nested Types
    Public Class IniSection
        ' Methods
        Protected Friend Sub New(ByVal parent As IniFile, ByVal sSection As String)
            Me.m_pIniFile = parent
            Me.m_sSection = sSection
            Me.m_keys = New Hashtable(StringComparer.InvariantCultureIgnoreCase)
        End Sub

        Public Function AddKey(ByVal sKey As String) As IniKey
            sKey = sKey.Trim
            Dim key2 As IniKey = Nothing
            If (sKey.Length <> 0) Then
                If Me.m_keys.ContainsKey(sKey) Then
                    Return DirectCast(Me.m_keys.Item(sKey), IniKey)
                End If
                key2 = New IniKey(Me, sKey)
                Me.m_keys.Item(sKey) = key2
            End If
            Return key2
        End Function

        Public Function GetKey(ByVal sKey As String) As IniKey
            sKey = sKey.Trim
            If Me.m_keys.ContainsKey(sKey) Then
                Return DirectCast(Me.m_keys.Item(sKey), IniKey)
            End If
            Return Nothing
        End Function

        Public Function GetName() As String
            Return Me.m_sSection
        End Function

        Public Function RemoveAllKeys() As Boolean
            Me.m_keys.Clear()
            Return (Me.m_keys.Count = 0)
        End Function

        Public Function RemoveKey(ByVal Key As IniKey) As Boolean
            If (Not Key Is Nothing) Then
                Try
                    Me.m_keys.Remove(Key.Name)
                    Return True
                Catch exception1 As Exception
                    ProjectData.SetProjectError(exception1)
                    Dim exception As Exception = exception1
                    Trace.WriteLine(exception.Message)
                    ProjectData.ClearProjectError()
                End Try
            End If
            Return False
        End Function

        Public Function RemoveKey(ByVal sKey As String) As Boolean
            Return Me.RemoveKey(Me.GetKey(sKey))
        End Function

        Public Function SetName(ByVal sSection As String) As Boolean
            sSection = sSection.Trim
            If (sSection.Length <> 0) Then
                Dim section As IniSection = Me.m_pIniFile.GetSection(sSection)
                If ((Not section Is Me) AndAlso (Not section Is Nothing)) Then
                    Return False
                End If
                Try
                    Me.m_pIniFile.m_sections.Remove(Me.m_sSection)
                    Me.m_pIniFile.m_sections.Item(sSection) = Me
                    Me.m_sSection = sSection
                    Return True
                Catch exception1 As Exception
                    ProjectData.SetProjectError(exception1)
                    Dim exception As Exception = exception1
                    Trace.WriteLine(exception.Message)
                    ProjectData.ClearProjectError()
                End Try
            End If
            Return False
        End Function


        ' Properties
        Public ReadOnly Property Keys As ICollection
            Get
                Return Me.m_keys.Values
            End Get
        End Property

        Public ReadOnly Property Name As String
            Get
                Return Me.m_sSection
            End Get
        End Property


        ' Fields
        Private m_keys As Hashtable
        Private m_pIniFile As IniFile
        Private m_sSection As String

        ' Nested Types
        Public Class IniKey
            ' Methods
            Protected Friend Sub New(ByVal parent As IniSection, ByVal sKey As String)
                Me.m_section = parent
                Me.m_sKey = sKey
            End Sub

            Public Function GetName() As String
                Return Me.m_sKey
            End Function

            Public Function GetValue() As String
                Return Me.m_sValue
            End Function

            Public Function SetName(ByVal sKey As String) As Boolean
                sKey = sKey.Trim
                If (sKey.Length <> 0) Then
                    Dim key As IniKey = Me.m_section.GetKey(sKey)
                    If ((Not key Is Me) AndAlso (Not key Is Nothing)) Then
                        Return False
                    End If
                    Try
                        Me.m_section.m_keys.Remove(Me.m_sKey)
                        Me.m_section.m_keys.Item(sKey) = Me
                        Me.m_sKey = sKey
                        Return True
                    Catch exception1 As Exception
                        ProjectData.SetProjectError(exception1)
                        Dim exception As Exception = exception1
                        Trace.WriteLine(exception.Message)
                        ProjectData.ClearProjectError()
                    End Try
                End If
                Return False
            End Function

            Public Sub SetValue(ByVal sValue As String)
                Me.m_sValue = sValue
            End Sub


            ' Properties
            Public ReadOnly Property Name As String
                Get
                    Return Me.m_sKey
                End Get
            End Property

            Public Property Value As String
                Get
                    Return Me.m_sValue
                End Get
                Set(ByVal value As String)
                    Me.m_sValue = value
                End Set
            End Property


            ' Fields
            Private m_section As IniSection
            Private m_sKey As String
            Private m_sValue As String
        End Class
    End Class
End Class