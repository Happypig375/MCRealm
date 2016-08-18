
Imports System.Collections.Generic
Imports System.Web.Script.Serialization
#If False Then
Public Class NameTypePair
    Public Property OBJECT_NAME() As String
        Get
            Return m_OBJECT_NAME
        End Get
        Set
            m_OBJECT_NAME = Value
        End Set
    End Property
    Private m_OBJECT_NAME As String
    Public Property OBJECT_TYPE() As String
        Get
            Return m_OBJECT_TYPE
        End Get
        Set
            m_OBJECT_TYPE = Value
        End Set
    End Property
    Private m_OBJECT_TYPE As String
End Class
Public Enum PositionType
    none
    point
End Enum
Public Class Ref
    Public Property id() As Integer
        Get
            Return m_id
        End Get
        Set
            m_id = Value
        End Set
    End Property
    Private m_id As Integer
End Class
Public Class SubObject
    Public Property attributes() As NameTypePair
        Get
            Return m_attributes
        End Get
        Set
            m_attributes = Value
        End Set
    End Property
    Private m_attributes As NameTypePair
    Public Property position() As Position
        Get
            Return m_position
        End Get
        Set
            m_position = Value
        End Set
    End Property
    Private m_position As Position
End Class
Public Class Position
    Public Property x() As Integer
        Get
            Return m_x
        End Get
        Set
            m_x = Value
        End Set
    End Property
    Private m_x As Integer
    Public Property y() As Integer
        Get
            Return m_y
        End Get
        Set
            m_y = Value
        End Set
    End Property
    Private m_y As Integer
End Class
Public Class Foo
    Public Sub New()
        'objects = New List(Of SubObject)()
    End Sub
    Public Property displayFieldName() As String
        Get
            Return m_displayFieldName
        End Get
        Set
            m_displayFieldName = Value
        End Set
    End Property
    Private m_displayFieldName As String
    Public Property fieldAliases() As NameTypePair
        Get
            Return m_fieldAliases
        End Get
        Set
            m_fieldAliases = Value
        End Set
    End Property
    Private m_fieldAliases As NameTypePair
    Public Property positionType() As PositionType
        Get
            Return m_positionType
        End Get
        Set
            m_positionType = Value
        End Set
    End Property
    Private m_positionType As PositionType
    Public Property reference() As Ref
        Get
            Return m_reference
        End Get
        Set
            m_reference = Value
        End Set
    End Property
    Private m_reference As Ref
    Public Property objects() As List(Of SubObject)
        Get
            Return m_objects
        End Get
        Set
            m_objects = Value
        End Set
    End Property
    Private m_objects As New List(Of SubObject)
End Class
    Const json As String =
"{
  ""displayFieldName"" : ""OBJECT_NAME"", 
  ""fieldAliases"" : {
    ""OBJECT_NAME"" : ""OBJECT_NAME"", 
    ""OBJECT_TYPE"" : ""OBJECT_TYPE""
  }, 
  ""positionType"" : ""point"", 
  ""reference"" : {
    ""id"" : 1111
  }, 
  ""objects"" : [
    {
      ""attributes"" : {
        ""OBJECT_NAME"" : ""test name"", 
        ""OBJECT_TYPE"" : ""test type""
      }, 
      ""position"" : 
      {
        ""x"" : 5, 
        ""y"" : 7
      }
    }
  ]
}"
#End If
Friend NotInheritable Class BanList
    Friend Class BannedPlayer
        Public Sub New()
            'objects = New List(Of SubObject)()
        End Sub
        Public Property uuid() As String
        Public Property name() As String
        Public Property created() As Date
        Public Property source() As String
        Public Property expires() As Date
        Public Property reason() As String
    End Class
    Private ReadOnly ser As New JavaScriptSerializer()
    Friend Sub New()
        Dim List As BannedPlayer() = ser.Deserialize(Of BannedPlayer())(json)
        MsgBox(ser.Serialize(List))
    End Sub

    Const json As String =
"[
  {
    ""uuid"": ""3c00b58d-a066-4F52-a2b7-615641Dcbe00"",
    ""name"": ""Server"",
    ""created"": ""2015-09-14 21:30:21 +0800"",
    ""source"": ""Server"",
    ""expires"": ""2015-09-15 20:00:21 +0800"",
    ""reason"": ""Banned by an operator.""
  }
]"

    Friend Shared Sub Main()
        Dim List As New BanList

    End Sub


End Class
