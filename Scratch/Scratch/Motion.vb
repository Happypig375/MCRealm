Partial Public Class Sprite
    Partial Public NotInheritable Class Script
        Private _Motion As MotionBlock
        Public ReadOnly Property Motion As MotionBlock
            Get
                Return _Motion
            End Get
        End Property
        <ComponentModel.EditorBrowsable(ComponentModel.EditorBrowsableState.Never)> _
        Public NotInheritable Class MotionBlock
            Friend OuterClass As Sprite
            Friend XPos As Integer
            Friend YPos As Integer
            Friend Dir As Integer
            Friend Const π As Decimal =
                3.1415926535897932384626433833D
            Friend Event PosChanged()
            Friend Event DirChanged()

            Public Sub Move(ByVal Steps As Integer)
                Dim X As Integer
                Dim Y As Integer
                GetNewPos(DegreesToRadians(XPos), DegreesToRadians(YPos), Dir, Steps, X, Y)
                X = RadiansToDegrees(X)
                Y = RadiansToDegrees(Y)
                XPos = X
                YPos = Y
                RaiseEvent PosChanged()
            End Sub
            Public Enum TurnDirection As SByte
                Clockwise = 1
                AntiClockwise = -1
            End Enum
            Public Sub Turn(ByVal Direction As TurnDirection, ByVal Degrees As Integer)
                Degrees = Direction * Degrees
                Dir += Degrees
                RaiseEvent DirChanged()
            End Sub
            Public Enum TowardsDirection As Short
                Right = 90
                Left = -90
                Up = 0
                Down = 180
            End Enum
            Public Sub PointInDirection(ByVal Direction As TowardsDirection)
                Dir = Direction
                RaiseEvent DirChanged()
            End Sub
            Public Sub PointTowards(ByVal Sprite As Sprite)
                Dir = Math.Atan(Math.Max(Sprite.Location.X, XPosition) -
                                Math.Min(Sprite.Location.X, XPosition) /
                                Math.Max(Sprite.Location.Y, YPosition) -
                                Math.Min(Sprite.Location.Y, YPosition)) - 90
                RaiseEvent DirChanged()
            End Sub
            Public Sub [GoTo](ByVal X As Integer, ByVal Y As Integer)
                XPos = X
                YPos = Y
                RaiseEvent PosChanged()
            End Sub
            Public Sub [GoTo](ByVal Sprite As Sprite)
                XPos = Sprite.Location.X
                YPos = Sprite.Location.Y
            End Sub
            Private Sub Difference(ByRef X As Double, ByRef Y As Double)
                X = Math.Max(X, XPosition) - Math.Min(X, XPosition)
                Y = Math.Max(Y, YPosition) - Math.Min(Y, YPosition)
            End Sub
            Public Sub Glide(Secs As Single, ToX As Integer, Y As Integer)
                Dim X As Integer = ToX
                Dim Timer As System.Windows.Forms.Timer = New Windows.Forms.Timer()
                Timer.Interval = 20
                AddHandler Timer.Tick, GlideTick(Secs, X, Y)
                Timer.Enabled = True

            End Sub
            Private Function GlideTick(Secs As Single, X As Integer, Y As Integer) As Object
                Dim Speed As Single = (Math.Sqrt(Math.Pow(
                                       Math.Max(X, XPosition) - Math.Min(X, XPosition), 2) +
                                       Math.Pow(
                                       Math.Max(Y, YPosition) - Math.Min(Y, YPosition),
                                       2))) / Secs
                Dim Dir = Math.Atan(Math.Max(X, XPosition) - Math.Min(X, XPosition) /
                                    Math.Max(Y, YPosition) - Math.Min(Y, YPosition)) - 90
                GetNewPos(DegreesToRadians(XPos), DegreesToRadians(YPos), Dir, Speed, X, Y)
                X = RadiansToDegrees(X)
                Y = RadiansToDegrees(Y)
                Return Nothing
            End Function
            Public Sub ChangeXBy(ByVal Value As Integer)
                XPos += Value
            End Sub
            Public Sub SetXTo(ByVal Value As Integer)
                XPos = Value
            End Sub
            Public Sub ChangeYBy(ByVal Value As Integer)
                YPos += Value
            End Sub
            Public Sub SetYTo(ByVal Value As Integer)
                YPos = Value
            End Sub
            Public ReadOnly Property XPosition As Integer
                Get
                    Return XPos
                End Get
            End Property
            Public ReadOnly Property YPosition As Integer
                Get
                    Return YPos
                End Get
            End Property
            Public ReadOnly Property Direction As Integer
                Get
                    Return Dir
                End Get
            End Property
            Private Sub GetNewPos(ByVal x1 As Integer, ByVal y1 As Integer,
                                  ByVal angleInRadian As Integer, ByVal LineLength As Integer,
                                  ByRef x2 As Integer, ByRef y2 As Integer)
                x2 = LineLength * Math.Cos(angleInRadian) + x1
                y2 = LineLength * Math.Sin(angleInRadian) + y1
            End Sub
            Private Function RadiansToDegrees(ByVal radians As Double) As Double
                Return radians * (180 / π)
            End Function

            Private Function RadiansToDegrees(ByVal radians As Decimal) As Decimal
                Return Convert.ToDecimal(radians * (180 / π))
            End Function

            Private Function DegreesToRadians(ByVal degrees As Double) As Double
                Return degrees / (180 / π)
            End Function

            Private Function DegreesToRadians(ByVal degrees As Decimal) As Decimal
                Return Convert.ToDecimal(degrees / (180 / π))
            End Function
            Friend Sub CallRotate() Handles Me.DirChanged
                System.Threading.Thread.Sleep(1)
                Rotate(OuterClass, OuterClass, Dir)
            End Sub
            Private Sub Rotate(ByVal PicSource As Sprite,
                               ByVal PicDest As Sprite,
                               ByVal Angle As Integer)
                ' Copy the output bitmap from the source image.
                Dim bm_in As New Drawing.Bitmap(PicSource.Image)

                ' Make an array of points defining the
                ' image's corners.
                Dim wid As Single = bm_in.Width
                Dim hgt As Single = bm_in.Height
                Dim corners As Drawing.Point() = { _
                    New Drawing.Point(0, 0), _
                    New Drawing.Point(wid, 0), _
                    New Drawing.Point(0, hgt), _
                    New Drawing.Point(wid, hgt)}

                ' Translate to center the bounding box at the origin.
                Dim cx As Single = wid / 2
                Dim cy As Single = hgt / 2
                Dim i As Long
                For i = 0 To 3
                    corners(i).X -= cx
                    corners(i).Y -= cy
                Next i

                ' Rotate.
                Dim theta As Single = Single.Parse(Angle) * π / 180.0
                Dim sin_theta As Single = Math.Sin(theta)
                Dim cos_theta As Single = Math.Cos(theta)
                Dim X As Single
                Dim Y As Single
                For i = 0 To 3
                    X = corners(i).X
                    Y = corners(i).Y
                    corners(i).X = X * cos_theta + Y * sin_theta
                    corners(i).Y = -X * sin_theta + Y * cos_theta
                Next i

                ' Translate so X >= 0 and Y >=0 for all corners.
                Dim xmin As Single = corners(0).X
                Dim ymin As Single = corners(0).Y
                For i = 1 To 3
                    If xmin > corners(i).X Then xmin = corners(i).X
                    If ymin > corners(i).Y Then ymin = corners(i).Y
                Next i
                For i = 0 To 3
                    corners(i).X -= xmin
                    corners(i).Y -= ymin
                Next i

                ' Create an output Bitmap and Graphics object.
                Dim bm_out As New Drawing.Bitmap(CInt(-2 * xmin), CInt(-2 * ymin))
                Dim gr_out As Drawing.Graphics = Drawing.Graphics.FromImage(bm_out)

                ' Drop the last corner lest we confuse DrawImage, 
                ' which expects an array of three corners.
                ReDim Preserve corners(2)

                ' Draw the result onto the output Bitmap.
                gr_out.DrawImage(bm_in, corners)

                ' Display the result.
                PicDest.Image = bm_out
            End Sub

        End Class
    End Class
End Class