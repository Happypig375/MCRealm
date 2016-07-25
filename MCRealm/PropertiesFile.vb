' This document (only) uses an open source code.
Option Strict On
Option Explicit On
Option Infer On
'
' * Copyright 2009-15 Williams Technologies Limited.
' *
' * Licensed under the Apache License, Version 2.0 (the "License");
' * you may not use this file except in compliance with the License.
' * You may obtain a copy of the License at
' *
' *     http://www.apache.org/licenses/LICENSE-2.0
' *
' * Unless required by applicable law or agreed to in writing, software
' * distributed under the License is distributed on an "AS IS" BASIS,
' * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
' * See the License for the specific language governing permissions and
' * limitations under the License.
' *
' * Kajbity is a trademark of Williams Technologies Limited.
' *
' * http://www.kajabity.com
' 
Imports System.IO
Imports System.Collections
Imports System.Text
Imports System.Diagnostics
Imports System.Globalization


''' <summary>
''' Hold Java style properties as key-value pairs and allow them to be loaded from or
''' saved to a ".properties" file. The file is stored with character set ISO-8859-1 which extends US-ASCII
''' (the characters 0-127 are the same) and forms the first part of the Unicode character set.  Within the
''' application <see cref="String"/> are Unicode - but all values outside the basic US-ASCII set are escaped.
''' </summary>
Public Class JavaProperties
    Inherits Hashtable
    Implements IDictionary, ICollection, IEnumerable,
         Runtime.Serialization.ISerializable, Runtime.Serialization.IDeserializationCallback, ICloneable
    ''' <summary>
    ''' Gets a reference to the ISO-8859-1 encoding (code page 28592). This is the Java standard for .properties files.
    ''' </summary>
    Friend Shared ReadOnly Property DefaultEncoding() As Encoding
        Get
            Return Encoding.GetEncoding(28592)
        End Get
    End Property

    ''' <summary>
    ''' A reference to an optional set of default properties - these values are returned
    ''' if the value has not been loaded from a ".properties" file or set programatically.
    ''' </summary>
    Protected defaults As Hashtable

    ''' <summary>
    ''' An empty constructor that doesn't set the defaults.
    ''' </summary>
    Public Sub New()
    End Sub

    ''' <summary>
    ''' Use this constructor to provide a set of default values.  The default values are kept separate
    ''' to the ones in this instant.
    ''' </summary>
    ''' <param name="defaults">A Hashtable that holds a set of defafult key value pairs to
    ''' return when the requested key has not been set.</param>
    Public Sub New(defaults As Hashtable)
        Me.defaults = defaults
    End Sub

    ''' <summary>
    ''' Load Java Properties from a stream expecting the format as described in <see cref="JavaPropertyReader"/>.
    ''' </summary>
    ''' <param name="streamIn">An input stream to read properties from.</param>
    ''' <exception cref="ParseException">If the stream source is invalid.</exception>
    Public Sub Load(streamIn As Stream)
        Dim reader As New JavaPropertyReader(Me)
        reader.Parse(streamIn)
    End Sub

    ''' <summary>
    ''' Load Java Properties from a stream with the specified encoding and 
    ''' expecting the format as described in <see cref="JavaPropertyReader"/>.
    ''' </summary>
    ''' <param name="streamIn">An input stream to read properties from.</param>
    ''' <param name="encoding">The stream's encoding.</param>
    Public Sub Load(streamIn As Stream, encoding As Encoding)
        Dim reader As New JavaPropertyReader(Me)
        reader.Parse(streamIn, encoding)
    End Sub

    ''' <summary>
    ''' Store the contents of this collection of properties to the stream in the format
    ''' used for Java ".properties" files using an instance of <see cref="JavaPropertyWriter"/>.
    ''' The keys and values will be minimally escaped to ensure special characters are read back
    ''' in properly.  Keys are not sorted.  The file will begin with a comment identifying the
    ''' date - and an additional comment may be included before it.
    ''' </summary>
    ''' <param name="streamOut">An output stream to write the properties to.</param>
    ''' <param name="comments">Optional additional comment to include at the head of the output.</param>
    Public Sub Store(streamOut As Stream, comments As String)
        Dim writer As New JavaPropertyWriter(Me)
        writer.Write(streamOut, comments)
    End Sub

    ''' <summary>
    ''' Store the contents of this collection of properties to the stream in the format
    ''' used for Java ".properties" files using an instance of <see cref="JavaPropertyWriter"/>.
    ''' The keys and values will be minimally escaped to ensure special characters are read back
    ''' in properly.  Keys are not sorted.  The file will begin with a comment identifying the
    ''' date - and an additional comment may be included before it.
    ''' </summary>
    ''' <param name="streamOut">An output stream to write the properties to.</param>
    ''' <param name="comments">Optional additional comment to include at the head of the output.</param>
    ''' <param name="datetime">Optional custom file modification timestamp that is placed after the custom comment.</param>
    Public Sub Store(streamOut As Stream, comments As String, datetime As String)
        Dim writer As New JavaPropertyWriter(Me)
        writer.Write(streamOut, comments, datetime)
    End Sub

    ''' <summary>
    ''' Get the value for the specified key value.  If the key is not found, then return the
    ''' default value - and if still not found, return null.
    ''' </summary>
    ''' <param name="key">The key whose value should be returned.</param>
    ''' <returns>The value corresponding to the key - or null if not found.</returns>
    Public Function GetProperty(key As String) As String
        Dim objectValue As [Object] = Me(key)
        If objectValue IsNot Nothing Then
            Return AsString(objectValue)
        ElseIf defaults IsNot Nothing Then
            Return AsString(defaults(key))
        End If

        Return Nothing
    End Function

    ''' <summary>
    ''' Get the value for the specified key value.  If the key is not found, then return the
    ''' default value - and if still not found, return <c>defaultValue</c>.
    ''' </summary>
    ''' <param name="key">The key whose value should be returned.</param>
    ''' <param name="defaultValue">The default value if the key is not found.</param>
    ''' <returns>The value corresponding to the key - or null if not found.</returns>
    Public Function GetProperty(key As String, defaultValue As String) As String
        Dim val As String = GetProperty(key)
        Return If((val Is Nothing), defaultValue, val)
    End Function

    ''' <summary>
    ''' Set the value for a property key.  The old value is returned - if any.
    ''' </summary>
    ''' <param name="key">The key whose value is to be set.</param>
    ''' <param name="newValue">The new value off the key.</param>
    ''' <returns>The original value of the key - as a string.</returns>
    Public Function SetProperty(key As String, newValue As String) As String
        Dim oldValue As String = AsString(Me(key))
        Me(key) = newValue
        Return oldValue
    End Function

    ''' <summary>
    ''' Returns an enumerator of all the properties available in this instance - including the
    ''' defaults.
    ''' </summary>
    ''' <returns>An enumarator for all of the keys including defaults.</returns>
    Public Function PropertyNames() As IEnumerator
        Dim combined As Hashtable
        If defaults IsNot Nothing Then
            combined = New Hashtable(defaults)

            Dim e As IEnumerator = Me.Keys.GetEnumerator()
            While e.MoveNext()
                Dim key As String = AsString(e.Current)
                combined.Add(key, Me(key))
            End While
        Else
            combined = New Hashtable(Me)
        End If

        Return combined.Keys.GetEnumerator()
    End Function

    ''' <summary>
    ''' A utility method to safely convert an <c>Object</c> to a <c>string</c>.
    ''' </summary>
    ''' <param name="o">An Object or null to be returned as a string.</param>
    ''' <returns>string value of the object - or null.</returns>
    Private Function AsString(o As [Object]) As String
        If o Is Nothing Then
            Return Nothing
        End If

        Return o.ToString()
    End Function
End Class
''' <summary>
''' This class reads Java style properties from an input stream.  
''' </summary>
Public Class JavaPropertyReader
    Private Const MATCH_end_of_input As Integer = 1
    Private Const MATCH_terminator As Integer = 2
    Private Const MATCH_whitespace As Integer = 3
    Private Const MATCH_any As Integer = 4

    Private Const ACTION_add_to_key As Integer = 1
    Private Const ACTION_add_to_value As Integer = 2
    Private Const ACTION_store_property As Integer = 3
    Private Const ACTION_escape As Integer = 4
    Private Const ACTION_ignore As Integer = 5

    Private Const STATE_start As Integer = 0
    Private Const STATE_comment As Integer = 1
    Private Const STATE_key As Integer = 2
    Private Const STATE_key_escape As Integer = 3
    Private Const STATE_key_ws As Integer = 4
    Private Const STATE_before_separator As Integer = 5
    Private Const STATE_after_separator As Integer = 6
    Private Const STATE_value As Integer = 7
    Private Const STATE_value_escape As Integer = 8
    Private Const STATE_value_ws As Integer = 9
    Private Const STATE_finish As Integer = 10

    Private Shared stateNames As String() = New String() {"STATE_start", "STATE_comment", "STATE_key", "STATE_key_escape", "STATE_key_ws", "STATE_before_separator",
            "STATE_after_separator", "STATE_value", "STATE_value_escape", "STATE_value_ws", "STATE_finish"}

    'STATE_start
    'STATE_comment
    'STATE_key
    'STATE_key_escape
    'STATE_key_ws
    'STATE_before_separator
    'STATE_after_separator
    'STATE_value
    'STATE_value_escape
    'STATE_value_ws
    Private Shared ReadOnly states As Integer()() = New Integer()() {New Integer() {MATCH_end_of_input, STATE_finish, ACTION_ignore, MATCH_terminator, STATE_start, ACTION_ignore,
            AscW("#"c), STATE_comment, ACTION_ignore, AscW("!"c), STATE_comment, ACTION_ignore,
            MATCH_whitespace, STATE_start, ACTION_ignore, AscW("\"c), STATE_key_escape, ACTION_escape,
            AscW(":"c), STATE_after_separator, ACTION_ignore, AscW("="c), STATE_after_separator, ACTION_ignore,
            MATCH_any, STATE_key, ACTION_add_to_key}, New Integer() {MATCH_end_of_input, STATE_finish, ACTION_ignore, MATCH_terminator, STATE_start, ACTION_ignore,
            MATCH_any, STATE_comment, ACTION_ignore}, New Integer() {MATCH_end_of_input, STATE_finish, ACTION_store_property, MATCH_terminator, STATE_start, ACTION_store_property,
            MATCH_whitespace, STATE_before_separator, ACTION_ignore, AscW("\"c), STATE_key_escape, ACTION_escape,
            AscW(":"c), STATE_after_separator, ACTION_ignore, AscW("="c), STATE_after_separator, ACTION_ignore,
            MATCH_any, STATE_key, ACTION_add_to_key}, New Integer() {MATCH_terminator, STATE_key_ws, ACTION_ignore, MATCH_any, STATE_key, ACTION_add_to_key}, New Integer() {MATCH_end_of_input, STATE_finish, ACTION_store_property, MATCH_terminator, STATE_start, ACTION_store_property,
            MATCH_whitespace, STATE_key_ws, ACTION_ignore, AscW("\"c), STATE_key_escape, ACTION_escape,
            AscW(":"c), STATE_after_separator, ACTION_ignore, AscW("="c), STATE_after_separator, ACTION_ignore,
            MATCH_any, STATE_key, ACTION_add_to_key}, New Integer() {MATCH_end_of_input, STATE_finish, ACTION_store_property, MATCH_terminator, STATE_start, ACTION_store_property,
            MATCH_whitespace, STATE_before_separator, ACTION_ignore, AscW("\"c), STATE_value_escape, ACTION_escape,
            AscW(":"c), STATE_after_separator, ACTION_ignore, AscW("="c), STATE_after_separator, ACTION_ignore,
            MATCH_any, STATE_value, ACTION_add_to_value},
            New Integer() {MATCH_end_of_input, STATE_finish, ACTION_store_property, MATCH_terminator, STATE_start, ACTION_store_property,
            MATCH_whitespace, STATE_after_separator, ACTION_ignore, AscW("\"c), STATE_value_escape, ACTION_escape,
            MATCH_any, STATE_value, ACTION_add_to_value}, New Integer() {MATCH_end_of_input, STATE_finish, ACTION_store_property, MATCH_terminator, STATE_start, ACTION_store_property,
            AscW("\"c), STATE_value_escape, ACTION_escape, MATCH_any, STATE_value, ACTION_add_to_value}, New Integer() {MATCH_terminator, STATE_value_ws, ACTION_ignore, MATCH_any, STATE_value, ACTION_add_to_value}, New Integer() {MATCH_end_of_input, STATE_finish, ACTION_store_property, MATCH_terminator, STATE_start, ACTION_store_property,
            MATCH_whitespace, STATE_value_ws, ACTION_ignore, AscW("\"c), STATE_value_escape, ACTION_escape,
            MATCH_any, STATE_value, ACTION_add_to_value}}

    Private hashtable As Hashtable

    Private Const bufferSize As Integer = 1000

    Private escaped As Boolean = False
    Private keyBuilder As New StringBuilder()
    Private valueBuilder As New StringBuilder()

    ''' <summary>
    ''' Construct a reader passing a reference to a Hashtable (or JavaProperties) instance
    ''' where the keys are to be stored.
    ''' </summary>
    ''' <param name="hashtable">A reference to a hashtable where the key-value pairs can be stored.</param>
    Public Sub New(hashtable As Hashtable)
        Me.hashtable = hashtable
    End Sub

    ''' <summary>
    ''' <para>Load key value pairs (properties) from an input Stream expected to have ISO-8859-1 encoding (code page 28592).  
    ''' The input stream (usually reading from a ".properties" file) consists of a series of lines (terminated 
    ''' by \r, \n or \r\n) each a key value pair, a comment or a blank line.</para>
    ''' 
    ''' <para>Leading whitespace (spaces, tabs, formfeeds) are ignored at the start of any line - and a line that is empty or 
    ''' contains only whitespace is blank and ignored.</para>
    ''' 
    ''' <para>A line with the first non-whitespace character is a '#' or '!' is a comment line and the rest of the line is 
    ''' ignored.</para>
    ''' 
    ''' <para>If the first non-whitespace character is not '#' or '!' then it is the start of a key.  A key is all the
    ''' characters up to the first whitespace or a key/value separator - '=' or ':'.</para>
    ''' 
    ''' <para>The separator is optional.  Any whitespace after the key or after the separator (if present) is ignored.</para>
    ''' 
    ''' <para>The first non-whitespace character after the separator (or after the key if no separator) begins the value.  
    ''' The value may include whitespace, separators, or comment characters.</para>
    ''' 
    ''' <para>Any unicode character may be included in either key or value by using escapes preceded by the escape 
    ''' character '\'.</para>
    ''' 
    ''' <para>The following special cases are defined:</para>
    ''' <code>
    ''' 	'\t' - horizontal tab.
    ''' 	'\f' - form feed.
    ''' 	'\r' - return
    ''' 	'\n' - new line
    ''' 	'\\' - add escape character.
    ''' 
    ''' 	'\ ' - add space in a key or at the start of a value.
    ''' 	'\!', '\#' - add comment markers at the start of a key.
    ''' 	'\=', '\:' - add a separator in a key.
    ''' </code>
    ''' 
    ''' <para>Any unicode character using the following escape:</para>
    ''' <code>
    ''' 	'\uXXXX' - where XXXX represents the unicode character code as 4 hexadecimal digits.
    ''' </code>
    ''' 
    ''' <para>Finally, longer lines can be broken by putting an escape at the very end of the line.  Any leading space
    ''' (unless escaped) is skipped at the beginning of the following line.</para>
    ''' 
    ''' Examples
    ''' <code>
    ''' 	a-key = a-value
    ''' 	a-key : a-value
    ''' 	a-key=a-value
    ''' 	a-key a-value
    ''' </code>
    ''' 
    ''' <para>All the above will result in the same key/value pair - key "a-key" and value "a-value".</para>
    ''' <code>
    ''' 	! comment...
    ''' 	# another comment...
    ''' </code>
    ''' 
    ''' <para>The above are two examples of comments.</para>
    ''' <code>
    ''' 	Honk\ Kong = Near China
    ''' </code>
    ''' 
    ''' <para>The above shows how to embed a space in a key - key is "Hong Kong", value is "Near China".</para>
    ''' <code>
    ''' 	a-longer-key-example = a really long value that is \
    ''' 			split over two lines.
    ''' </code>
    ''' 
    ''' <para>An example of a long line split into two.</para>
    ''' </summary>
    ''' <param name="stream">The input stream that the properties are read from.</param>
    Public Sub Parse(stream As Stream)
        Parse(stream, Nothing)
    End Sub

    ''' <summary>
    ''' <para>Load key value pairs (properties) from an input Stream expected to have ISO-8859-1 encoding (code page 28592).  
    ''' The input stream (usually reading from a ".properties" file) consists of a series of lines (terminated 
    ''' by \r, \n or \r\n) each a key value pair, a comment or a blank line.</para>
    ''' 
    ''' <para>Leading whitespace (spaces, tabs, formfeeds) are ignored at the start of any line - and a line that is empty or 
    ''' contains only whitespace is blank and ignored.</para>
    ''' 
    ''' <para>A line with the first non-whitespace character is a '#' or '!' is a comment line and the rest of the line is 
    ''' ignored.</para>
    ''' 
    ''' <para>If the first non-whitespace character is not '#' or '!' then it is the start of a key.  A key is all the
    ''' characters up to the first whitespace or a key/value separator - '=' or ':'.</para>
    ''' 
    ''' <para>The separator is optional.  Any whitespace after the key or after the separator (if present) is ignored.</para>
    ''' 
    ''' <para>The first non-whitespace character after the separator (or after the key if no separator) begins the value.  
    ''' The value may include whitespace, separators, or comment characters.</para>
    ''' 
    ''' <para>Any unicode character may be included in either key or value by using escapes preceded by the escape 
    ''' character '\'.</para>
    ''' 
    ''' <para>The following special cases are defined:</para>
    ''' <code>
    ''' 	'\t' - horizontal tab.
    ''' 	'\f' - form feed.
    ''' 	'\r' - return
    ''' 	'\n' - new line
    ''' 	'\\' - add escape character.
    ''' 
    ''' 	'\ ' - add space in a key or at the start of a value.
    ''' 	'\!', '\#' - add comment markers at the start of a key.
    ''' 	'\=', '\:' - add a separator in a key.
    ''' </code>
    ''' 
    ''' <para>Any unicode character using the following escape:</para>
    ''' <code>
    ''' 	'\uXXXX' - where XXXX represents the unicode character code as 4 hexadecimal digits.
    ''' </code>
    ''' 
    ''' <para>Finally, longer lines can be broken by putting an escape at the very end of the line.  Any leading space
    ''' (unless escaped) is skipped at the beginning of the following line.</para>
    ''' 
    ''' Examples
    ''' <code>
    ''' 	a-key = a-value
    ''' 	a-key : a-value
    ''' 	a-key=a-value
    ''' 	a-key a-value
    ''' </code>
    ''' 
    ''' <para>All the above will result in the same key/value pair - key "a-key" and value "a-value".</para>
    ''' <code>
    ''' 	! comment...
    ''' 	# another comment...
    ''' </code>
    ''' 
    ''' <para>The above are two examples of comments.</para>
    ''' <code>
    ''' 	Honk\ Kong = Near China
    ''' </code>
    ''' 
    ''' <para>The above shows how to embed a space in a key - key is "Hong Kong", value is "Near China".</para>
    ''' <code>
    ''' 	a-longer-key-example = a really long value that is \
    ''' 			split over two lines.
    ''' </code>
    ''' 
    ''' <para>An example of a long line split into two.</para>
    ''' </summary>
    ''' <param name="stream">The input stream that the properties are read from.</param>
    ''' <param name="encoding">The <see cref="System.Text.Encoding">encoding</see> that is used to read the properies file stream.</param>
    Public Sub Parse(stream As Stream, encoding As Encoding)
        Dim bufferedStream = New BufferedStream(stream, bufferSize)
        ' the default encoding ISO-8859-1 (codepabe 28592) will be used if we do not pass explicitly different encoding
        Dim parserEncoding = If(encoding, JavaProperties.DefaultEncoding)
        reader = New BinaryReader(bufferedStream, parserEncoding)

        Dim state As Integer = STATE_start
        Do
            Dim ch As Integer = nextChar()

            Dim matched As Boolean = False

            For s As Integer = 0 To states(state).Length - 1 Step 3
                If matches(states(state)(s), ch) Then
                    'Debug.WriteLine( stateNames[ state ] + ", " + (s/3) + ", " + ch + (ch>20?" (" + (char) ch + ")" : "") );
                    matched = True
                    doAction(states(state)(s + 2), ch)

                    state = states(state)(s + 1)
                    Exit For
                End If
            Next

            If Not matched Then
                Throw New ParseException("Unexpected character at " & 1 & ": <<<" & ch & ">>>")
            End If
        Loop While state <> STATE_finish
    End Sub

    Private Function matches(match As Integer, ch As Integer) As Boolean
        Select Case match
            Case MATCH_end_of_input
                Return ch = -1

            Case MATCH_terminator
                If ch = AscW(ControlChars.Cr) Then
                    If peekChar() = AscW(ControlChars.Lf) Then
                        saved = False
                    End If
                    Return True
                ElseIf ch = AscW(ControlChars.Lf) Then
                    Return True
                End If
                Return False

            Case MATCH_whitespace
                Return ch = AscW(" "c) OrElse ch = AscW(ControlChars.Tab) OrElse ch = AscW(ControlChars.FormFeed)

            Case MATCH_any
                Return True
            Case Else

                Return ch = match
        End Select
    End Function

    Private Sub doAction(action As Integer, ch As Integer)
        Select Case action
            Case ACTION_add_to_key
                keyBuilder.Append(escapedChar(ch))
                escaped = False
                Exit Select

            Case ACTION_add_to_value
                valueBuilder.Append(escapedChar(ch))
                escaped = False
                Exit Select

            Case ACTION_store_property
                'Debug.WriteLine( keyBuilder.ToString() + "=" + valueBuilder.ToString() );
                ' Corrected to avoid duplicate entry errors - thanks to David Tanner.
                hashtable(keyBuilder.ToString()) = valueBuilder.ToString()
                keyBuilder.Length = 0
                valueBuilder.Length = 0
                escaped = False
                Exit Select

            Case ACTION_escape
                escaped = True
                Exit Select
            Case Else

                'case ACTION_ignore:
                escaped = False
                Exit Select
        End Select
    End Sub

    Private Function escapedChar(ch As Integer) As Char
        If escaped Then
            Select Case ch
                Case AscW("t"c)
                    Return ControlChars.Tab
                Case AscW("b")
                    Return ControlChars.Back
                Case AscW("r"c)
                    Return ControlChars.Cr
                Case AscW("n"c)
                    Return ControlChars.Lf
                Case AscW("f"c)
                    Return ControlChars.FormFeed
                Case AscW("u"c)
                    Dim uch As Integer = 0
                    For i As Integer = 0 To 3
                        ch = nextChar()
                        If ch >= AscW("0"c) AndAlso ch <= AscW("9"c) Then
                            uch = (uch << 4) + ch - AscW("0"c)
                        ElseIf ch >= AscW("a"c) AndAlso ch <= AscW("z"c) Then
                            uch = (uch << 4) + ch - AscW("a"c) + 10
                        ElseIf ch >= AscW("A"c) AndAlso ch <= AscW("Z"c) Then
                            uch = (uch << 4) + ch - AscW("A"c) + 10
                        Else
                            Throw New ParseException("Invalid Unicode character.")
                        End If
                    Next
                    Return ChrW(uch)
            End Select
        End If

        Return ChrW(ch)
    End Function

    ' we now use a BinaryReader, which supports encodings
    Private reader As BinaryReader = Nothing
    Private savedChar As Integer
    Private saved As Boolean = False

    Private Function nextChar() As Integer
        If saved Then
            saved = False
            Return savedChar
        End If

        Return ReadCharSafe()
    End Function

    Private Function peekChar() As Integer
        If saved Then
            Return savedChar
        End If

        saved = True
        Return InlineAssignHelper(savedChar, ReadCharSafe())
    End Function

    ''' <summary>
    ''' A method to substitute calls to <c>stream.ReadByte()</c>.
    ''' The <see cref="JavaPropertyReader" /> now uses a <see cref="BinaryReader"/> to read properties.
    ''' Unlike a plain stream, the <see cref="BinaryReader"/> will not return -1 when the stream end is reached,
    ''' instead an <see cref="IOException" /> is to be thrown. 
    ''' <para>
    ''' In this method we perform a check if the stream is already processed to the end, and return <c>-1</c>.
    ''' </para>
    ''' </summary>
    ''' <returns></returns>
    Private Function ReadCharSafe() As Integer
        If Me.reader.BaseStream.Position = Me.reader.BaseStream.Length Then
            ' We have reached the end of the stream. The reder will throw exception if we call Read any further.
            ' We just return -1 now;
            Return -1
        End If
        ' reader.ReadChar() will take into account the encoding.
        Return AscW(Me.reader.ReadChar())
    End Function
    Private Shared Function InlineAssignHelper(Of T)(ByRef target As T, value As T) As T
        target = value
        Return value
    End Function
End Class
''' <summary>
''' Use this class for writing a set of key value pair strings to an
''' output stream using the Java properties format.
''' </summary>
Public Class JavaPropertyWriter
    Private Shared HEX As Char() = New Char() {"0"c, "1"c, "2"c, "3"c, "4"c, "5"c,
            "6"c, "7"c, "8"c, "9"c, "A"c, "B"c,
            "C"c, "D"c, "E"c, "F"c}

    Private hashtable As Hashtable

    ''' <summary>
    ''' Construct an instance of this class.
    ''' </summary>
    ''' <param name="hashtable">The Hashtable (or JavaProperties) instance
    ''' whose values are to be written.</param>
    Public Sub New(hashtable As Hashtable)
        Me.hashtable = hashtable
    End Sub

    ''' <summary>
    ''' Write the properties to the output stream.
    ''' </summary>
    ''' <param name="stream">The output stream where the properties are written.</param>
    ''' <param name="comments">Optional comments that are placed at the beginning of the output.</param>
    Public Sub Write(stream As Stream, comments As String)
        '  Create a writer to output to an ISO-8859-1 encoding (code page 28592).
        Dim writer As New StreamWriter(stream, System.Text.Encoding.GetEncoding(28592))

        'TODO: Confirm correct codepage:
        '  28592              iso-8859-2                   Central European (ISO)
        '  28591              iso-8859-1                   Western European (ISO)
        '  from http://msdn.microsoft.com/en-us/library/system.text.encodinginfo.getencoding.aspx

        If comments IsNot Nothing Then
            writer.WriteLine(Convert.ToString("# ") & comments)
        End If

        writer.WriteLine("# " + DateTime.Now.ToString())

        Dim e As IEnumerator = hashtable.Keys.GetEnumerator()
        While e.MoveNext()
            Dim key As String = e.Current.ToString()
            Dim val As String = hashtable(key).ToString()

            writer.WriteLine(Convert.ToString(escapeKey(key) & Convert.ToString("=")) & escapeValue(val))
        End While

        writer.Flush()
    End Sub

    ''' <summary>
    ''' Write the properties to the output stream.
    ''' </summary>
    ''' <param name="stream">The output stream where the properties are written.</param>
    ''' <param name="comments">Optional comments that are placed at the beginning of the output.</param>
    ''' <param name="datetime">Optional custom file modification timestamp that is placed after the custom comment.</param>
    Public Sub Write(stream As Stream, comments As String, datetime As String)
        '  Create a writer to output to an ISO-8859-1 encoding (code page 28592).
        Dim writer As New StreamWriter(stream, System.Text.Encoding.GetEncoding(28592))

        'TODO: Confirm correct codepage:
        '  28592              iso-8859-2                   Central European (ISO)
        '  28591              iso-8859-1                   Western European (ISO)
        '  from http://msdn.microsoft.com/en-us/library/system.text.encodinginfo.getencoding.aspx

        If comments IsNot Nothing Then
            writer.WriteLine(Convert.ToString("# ") & comments)
        End If

        writer.WriteLine("# " + datetime)

        Dim e As IEnumerator = hashtable.Keys.GetEnumerator()
        While e.MoveNext()
            Dim key As String = e.Current.ToString()
            Dim val As String = hashtable(key).ToString()

            writer.WriteLine(Convert.ToString(escapeKey(key) & Convert.ToString("=")) & escapeValue(val))
        End While

        writer.Flush()
    End Sub

    ''' <summary>
    ''' Escape the string as a Key with character set ISO-8859-1 -
    ''' the characters 0-127 are US-ASCII and we will escape any others.  The passed string is Unicode which extends
    ''' ISO-8859-1 - so all is well.
    ''' </summary>
    ''' <param name="s"></param>
    ''' <returns></returns>
    Private Function escapeKey(s As String) As String
        Dim buf As New StringBuilder()
        Dim first As Boolean = True

        For Each c As Char In s
            '  Avoid confusing with a comment: '!' (33), '#' (35).
            If first Then
                first = False
                If c = "!"c OrElse c = "#"c Then
                    buf.Append("\"c)
                End If
            End If

            Select Case c
                Case ControlChars.Tab
                    '  =09 U+0009  HORIZONTAL TABULATION   \t
                    buf.Append("\"c).Append("t"c)
                    Exit Select
                Case ControlChars.Back
                    '  =08 U+0008  BACKSPACE               \b
                    buf.Append("\"c).Append("b"c)
                    Exit Select
                Case ControlChars.Lf
                    '  =0A U+000A  LINE FEED               \n
                    buf.Append("\"c).Append("n"c)
                    Exit Select
                Case ControlChars.FormFeed
                    '  =0C U+000C  FORM FEED               \f
                    buf.Append("\"c).Append("f"c)
                    Exit Select
                Case ControlChars.Cr
                    '  =0D U+000D  CARRIAGE RETURN         \r
                    buf.Append("\"c).Append("r"c)
                    Exit Select

                    '  32: ' '
                    '  58: ':'
                    '  61: '='
                Case " "c, ":"c, "="c, "\"c
                    '  92: '\'
                    buf.Append("\"c).Append(c)
                    Exit Select
                Case Else

                    If AscW(c) > 31 AndAlso AscW(c) < 127 Then
                        buf.Append(c)
                    Else
                        buf.Append("\"c).Append("u"c)
                        buf.Append(HEX((AscW(c) >> 12) And &HF))
                        buf.Append(HEX((AscW(c) >> 8) And &HF))
                        buf.Append(HEX((AscW(c) >> 4) And &HF))
                        buf.Append(HEX(AscW(c) And &HF))
                    End If
                    Exit Select
            End Select
        Next

        Return buf.ToString()
    End Function

    Private Function escapeValue(s As String) As String
        Dim buf As New StringBuilder()
        Dim first As Boolean = True

        For Each c As Char In s
            '  Handle value starting with whitespace.
            If first Then
                first = False
                If c = " "c Then
                    buf.Append("\"c).Append(" "c)
                    Continue For
                ElseIf c = ControlChars.Tab Then
                    '  =09 U+0009  HORIZONTAL TABULATION   \t
                    buf.Append("\"c).Append("t"c)
                    Continue For
                End If
            End If

            Select Case c
                Case ControlChars.Tab
                    '  =09 U+0009  HORIZONTAL TABULATION   \t
                    buf.Append(ControlChars.Tab)
                    'OK after first position.
                    Exit Select
                Case ControlChars.Back
                    '  =08 U+0008  BACKSPACE               \b
                    buf.Append("\"c).Append("b"c)
                    Exit Select
                Case ControlChars.Lf
                    '  =0A U+000A  LINE FEED               \n
                    buf.Append("\"c).Append("n"c)
                    Exit Select
                Case ControlChars.FormFeed
                    '  =0C U+000C  FORM FEED               \f
                    buf.Append("\"c).Append("f"c)
                    Exit Select
                Case ControlChars.Cr
                    '  =0D U+000D  CARRIAGE RETURN         \r
                    buf.Append("\"c).Append("r"c)
                    Exit Select
                Case "\"c
                    '  92: '\'
                    buf.Append("\"c).Append(c)
                    Exit Select
                Case Else

                    If AscW(c) > 31 AndAlso AscW(c) < 127 Then
                        buf.Append(c)
                    Else
                        buf.Append("\"c).Append("u"c)
                        buf.Append(HEX((AscW(c) >> 12) And &HF))
                        buf.Append(HEX((AscW(c) >> 8) And &HF))
                        buf.Append(HEX((AscW(c) >> 4) And &HF))
                        buf.Append(HEX(AscW(c) And &HF))
                    End If
                    Exit Select
            End Select
        Next

        Return buf.ToString()
    End Function
End Class
''' <summary>
''' An exception thrown by <see cref="JavaPropertyReader"/> when parsing
''' a properties stream.
''' </summary>
Public Class ParseException
    Inherits System.Exception
    ''' <summary>
    ''' Construct an exception with an error message.
    ''' </summary>
    ''' <param name="message">A descriptive message for the exception</param>
    Public Sub New(message As String)
        MyBase.New(message)
    End Sub
End Class