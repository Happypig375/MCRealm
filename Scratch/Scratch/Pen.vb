Partial Public Class Sprite
    Partial Public NotInheritable Class Script
        Protected Const MaxValue As Int64 = 4294967296
        Private _Pen As PenBlock
        Public ReadOnly Property Pen As PenBlock
            Get
                Return _Pen
            End Get
        End Property
        <ComponentModel.EditorBrowsable(ComponentModel.EditorBrowsableState.Never)> _
        Public NotInheritable Class PenBlock
            Friend PenState As Boolean
            Friend PenColor As System.Drawing.Color
            Friend PenShade As UInteger
            Friend PenSize As UInteger
            <Obsolete("Work In Progress", True)> _
            Public Sub Clear()

            End Sub
            Public Sub PenDown()
                PenState = True
            End Sub
            Public Sub PenUp()
                PenState = False
            End Sub
            Public Sub SetPenColorTo(ByVal Color As System.Drawing.Color)
                PenColor = Color
            End Sub
            Public Sub SetPenColorTo(ByVal Red As Byte, ByVal Green As Byte, ByVal Blue As Byte)
                Dim Color As System.Drawing.Color = System.Drawing.Color.FromArgb(Red, Green, Blue)
                PenColor = Color
            End Sub
            Public Sub SetPenColorTo(ByVal Alpha As Byte, ByVal Red As Byte, ByVal Green As Byte, ByVal Blue As Byte)
                Dim Color As System.Drawing.Color = System.Drawing.Color.FromArgb(Alpha, Red, Green, Blue)
                PenColor = Color
            End Sub
            Public Sub ChangePenColorBy(ByVal Value As UInteger)
                Dim CurrentColor As Long =
                    16777216 * PenColor.A + 65536 * PenColor.R + 256 * PenColor.G + PenColor.B
                CurrentColor += Value
                If System.Math.Sign(CurrentColor) = -1 Then
                    CurrentColor += MaxValue
                End If
                If CurrentColor >= MaxValue Then
                    CurrentColor -= MaxValue
                End If
                PenColor = System.Drawing.Color.FromArgb(CurrentColor)
            End Sub
            Public Sub ChangePenShadeBy(ByVal Value As Integer)
                Dim CurrentShade As Long = PenShade
                CurrentShade += PenShade
                If System.Math.Sign(CurrentShade) = -1 Then
                    CurrentShade += MaxValue
                End If
                If CurrentShade >= MaxValue Then
                    CurrentShade -= MaxValue
                End If
                PenShade = CurrentShade
            End Sub
            Public Sub SetPenShadeTo(ByVal Value As UInteger)
                PenShade = Value
            End Sub
            Public Sub ChangePenSizeBy(ByVal Value As Integer)
                Dim CurrentSize As Long = PenSize
                CurrentSize += PenSize
                If System.Math.Sign(CurrentSize) = -1 Then
                    CurrentSize += MaxValue
                End If
                If CurrentSize >= MaxValue Then
                    CurrentSize -= MaxValue
                End If
                PenSize = CurrentSize
            End Sub
            Public Sub SetPenSizeTo(ByVal Value As UInteger)
                PenSize = Value
            End Sub
            <Obsolete("Work In Progress", True)> _
            Public Sub Stamp()

            End Sub
        End Class
    End Class
End Class
