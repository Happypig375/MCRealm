
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class Sprite
    Inherits System.Windows.Forms.PictureBox
#Region "Designer.vb"
    'Control overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Control Designer
    Private components As System.ComponentModel.IContainer

    ' NOTE: The following procedure is required by the Component Designer
    ' It can be modified using the Component Designer.  Do not modify it
    ' using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        components = New System.ComponentModel.Container()
    End Sub

#End Region
#Region "Constructor"
    Public ReadOnly InstanceID As Integer
    Private Shared NextInstanceID As Integer = 0
    Private Shared ClassInstanceCount As Long = 0

#End Region
Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)
    MyBase.OnPaint(e)

    'Add your custom paint code here
End Sub
#Region "New"
    Public Sub New(ByVal CostumePath As String)
        MyClass.New()
        InitializeComponent()
        Me.Image = New System.Drawing.Bitmap(CostumePath)
    End Sub
    Public Sub New(ByVal Costume As System.Drawing.Bitmap)
        MyClass.New()
        InitializeComponent()
        Me.Image = Costume
    End Sub
    Public Sub New(ByVal Size As System.Drawing.Size)
        MyClass.New()
        InitializeComponent()
        Me.Size = Size
    End Sub
    Public Sub New(ByVal CostumePath As String, ByVal Size As System.Drawing.Size,
                   Optional ByVal Zoom As System.Windows.Forms.PictureBoxSizeMode =
                   Windows.Forms.PictureBoxSizeMode.Normal)
        MyClass.New()
        InitializeComponent()
        Me.Image = New System.Drawing.Bitmap(CostumePath)
        Me.Size = Size
        Me.SizeMode = Zoom
    End Sub
    <System.Diagnostics.DebuggerNonUserCode()> _
    Public Sub New(ByVal container As System.ComponentModel.IContainer)
        MyClass.New()
        'Required for Windows.Forms Class Composition Designer support
        If (container IsNot Nothing) Then
            container.Add(Me)
        End If
    End Sub
    <System.Diagnostics.DebuggerNonUserCode()> _
    Public Sub New()
        MyClass.New(Nothing, Nothing, Nothing, Nothing, Nothing)
        'This call is required by the Component Designer.
        InitializeComponent()
    End Sub
    Protected Overrides Sub Finalize()
        ClassInstanceCount -= 1
        MyBase.Finalize()
    End Sub
    Private Sub New(ByVal lol As Object, ByVal gay As Object, ByVal fart As Object,
                    ByVal Sprited As Object, ByVal [Nothing] As Sprite)
        MyBase.New()
        If Not IsNothing([Nothing]) Then Throw New ArgumentOutOfRangeException
        InitializeComponent()
        InstanceID = NextInstanceID
        NextInstanceID += 1
        ClassInstanceCount += 1
    End Sub
#End Region
#Region "MainProperties"
Private _Script As Script
Public ReadOnly Property Scripts As Script
    Get
        Return _Script
    End Get
End Property
<ComponentModel.EditorBrowsable(ComponentModel.EditorBrowsableState.Never)> _
Partial Public NotInheritable Class Script

End Class
Private _Costume As Costume
Public ReadOnly Property Costumes As Costume
    Get
        Return _Costume
    End Get
End Property
<ComponentModel.EditorBrowsable(ComponentModel.EditorBrowsableState.Never)> _
Partial Public NotInheritable Class Costume

End Class
Private _Sound As Sound
Public ReadOnly Property Sounds As Sound
    Get
        Return _Sound
    End Get
End Property

<ComponentModel.EditorBrowsable(ComponentModel.EditorBrowsableState.Never)> _
Partial Public NotInheritable Class Sound

End Class
#End Region
Private Sub Me_LocationChanged() Handles Me.LocationChanged
    Me.Scripts.Motion.XPos = Me.Location.X
    Me.Scripts.Motion.YPos = Me.Location.Y
End Sub
Private Sub Me_Load() Handles Me.LoadCompleted
    AddHandler Scripts.Motion.DirChanged, This()
    AddHandler Scripts.Motion.PosChanged, Me_PosChanged()
End Sub
Friend Function Me_PosChanged() As Scratch.Sprite.Script.MotionBlock.PosChangedEventHandler
    Me.Location = New System.Drawing.Point(
        Me.Scripts.Motion.XPos, Me.Scripts.Motion.YPos)
    Return Nothing
End Function
Friend Sub This(<Runtime.InteropServices.Out> [Return] As Sprite)
    [Return] = Me
End Sub
Friend Function This() As Scratch.Sprite.Script.MotionBlock.DirChangedEventHandler
    Me.Scripts.Motion.OuterClass = Me
    Return Nothing
End Function
End Class
