Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.ComponentModel
Imports System.Diagnostics
Imports System.Drawing
Imports System.IO
Imports System.Runtime.CompilerServices
Imports System.Windows.Forms

Namespace ApplicationMon_Student
    <DesignerGenerated> _
    Public Class Form2
        Inherits Form
        ' Methods
        Public Sub New()
            AddHandler MyBase.Shown, New EventHandler(AddressOf Me.Form1_Shown)
            AddHandler MyBase.Load, New EventHandler(AddressOf Me.Form1_Load)
            Me.msg = New sMessager
            Me.proc = New vStudProcess
            Me.InitializeComponent()
        End Sub

        Private Sub CheckInstanceOfApp()
            If (Process.GetProcessesByName(Path.GetFileNameWithoutExtension(Process.GetCurrentProcess.MainModule.ModuleName)).Length > 1) Then
                Process.GetCurrentProcess.Kill()
            End If
        End Sub

        <DebuggerNonUserCode> _
        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            Try
                If (disposing AndAlso (Not Me.components Is Nothing)) Then
                    Me.components.Dispose()
                End If
            Finally
                MyBase.Dispose(disposing)
            End Try
        End Sub


        ' Properties
        Friend Overridable Property Timer1 As Timer
            <DebuggerNonUserCode> _
            Get
                Return Me._Timer1
            End Get
            <MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode> _
            Set(ByVal WithEventsValue As Timer)
                If (Not Me._Timer1 Is Nothing) Then
                    RemoveHandler Me._Timer1.Tick, New EventHandler(AddressOf Me.Timer1_Tick)
                End If
                Me._Timer1 = WithEventsValue
                If (Not Me._Timer1 Is Nothing) Then
                    AddHandler Me._Timer1.Tick, New EventHandler(AddressOf Me.Timer1_Tick)
                End If
            End Set
        End Property
        Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs)
            Me.CheckInstanceOfApp()
            Me.Timer1.Interval = &HBB8
            Me.Timer1.Enabled = True
            Me.msg.StartListen()
        End Sub

        Private Sub Form1_Shown(ByVal sender As Object, ByVal e As EventArgs)
            Me.Visible = False
        End Sub

        <DebuggerStepThrough> _
        Private Sub InitializeComponent()
            Me.components = New Container
            Dim manager As New ComponentResourceManager(GetType(Form2))
            MyClass.Timer1 = New Timer(Me.components)
            Me.SuspendLayout()
            Dim ef As New SizeF(6.0!, 13.0!)
            Me.AutoScaleDimensions = ef
            Me.AutoScaleMode = AutoScaleMode.Font
            Dim size As New Size(&H74, &H21)
            Me.ClientSize = size
            '  Me.Icon = DirectCast(manager.GetObject("$this.Icon"), Icon)
            Me.MaximizeBox = False
            Me.MinimizeBox = False
            Me.Name = "Form1"
            Me.ShowInTaskbar = False
            Me.Text = "Form1"
            Me.WindowState = FormWindowState.Minimized
            Me.ResumeLayout(False)
        End Sub

        Private Sub Timer1_Tick(ByVal sender As Object, ByVal e As EventArgs)
            If Not Me.proc.GetEnableRun Then
                Me.proc.DisableProcessRun()
            End If
        End Sub
        ' Fields
        <AccessedThroughProperty("Timer1")> _
        Private _Timer1 As Timer
        Private components As IContainer
        Public msg As sMessager
        Public proc As vStudProcess
    End Class
End Namespace

