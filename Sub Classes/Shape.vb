Public Class Shape

    Protected X, Y, Width, Height As Integer
    Protected Type As ShapeType
    Protected Color As Color
    Protected ScaleX As Single
    Protected ScaleY As Single
    Protected Rotation As Double
    Protected Opacity As Integer 'Defualt value is 255
    Protected Score As Integer
    Protected ScoreAssignedForGen As Boolean

    Public Enum ShapeType
        Rectangle
        Ellipse
        Triangle
    End Enum

    Sub New(ShapeType As ShapeType)
        Me.Type = ShapeType

        Me.ScaleX = 1
        Me.ScaleY = 1
        Me.X = 0
        Me.Y = 0
        Me.Width = 10
        Me.Height = 10
    End Sub

    Public Sub Translate(Vector As Vector)
        Me.X += Vector.X
        Me.Y += Vector.Y
    End Sub
    Public Sub Rotate(theta As Double)
        Me.Rotation += theta
    End Sub
    Public Sub StretchY(ScaleFactor As Single)
        Me.Height *= ScaleFactor
    End Sub
    Public Sub StretchX(ScaleFactor As Single)
        Me.Width *= ScaleFactor
    End Sub

    Public Sub Randomize(ByVal BoundingArea As Size)
        Dim Rnd As New Random
        Me.SetColor(Color.FromArgb(Rnd.Next(0, 255), Rnd.Next(0, 255), Rnd.Next(0, 255)))
        Me.SetOpacity(Rnd.Next(20, 200))
        Me.SetRotation(Rnd.Next(0, 360))
        Me.SetX(Rnd.Next(0, BoundingArea.Width))
        Me.SetY(Rnd.Next(0, BoundingArea.Height))
        Me.StretchX(Rnd.Next(0.2, 40))
        Me.StretchY(Rnd.Next(0.2, 40))
    End Sub
    Public Function GetChild() As Shape
        Dim R As New Shape(Me.Type)
        R = Match(R)
        Dim Rnd As New Random
        R.SetColor(GeoGraphics.ColorVarier(R.GetColor, Rnd.Next(-40, 40)))

        R.SetOpacity(GeoGraphics.ARGBCheck(R.GetOpacity + Rnd.Next(-30, 30)))
        R.Rotate(Rnd.Next(-30, 30))
        R.SetX(R.GetX + Rnd.Next(-30, 30))
        R.SetY(R.GetY + Rnd.Next(-30, 30))
        R.StretchX(Rnd.Next(0, 2))
        R.StretchY(Rnd.Next(0, 2))
        Return R
    End Function

    '========SIDE METHODS/FUNCTIONS=====
    Private Function Match(ByVal Child As Shape) As Shape
        Child.SetColor(Me.Color)
        Child.SetOpacity(Me.Opacity)
        Child.SetRotation(Me.Rotation)
        Child.SetX(Me.GetX)
        Child.SetY(Me.GetY)
        Child.SetScaleIn("X", Me.ScaleX)
        Child.SetScaleIn("Y", Me.ScaleY)
        Return Child
    End Function

    '=========GETTERS/SETTERS===========
    Public Function GetBounds() As Rectangle
        Return New Rectangle(Me.X - (Me.Width / 2), Me.Y - (Me.Height / 2), Me.Width, Me.Height)
    End Function
    Public Sub SetScore(val As Integer)
        Me.Score = val
    End Sub
    Public Function GetScore() As Integer
        Return Me.Score
    End Function
    Public Sub SetX(ByVal val As Integer)
        Me.X = val
    End Sub
    Public Function GetX() As Integer
        Return Me.X
    End Function
    Public Sub SetY(ByVal val As Integer)
        Me.Y = val
    End Sub
    Public Function GetY() As Integer
        Return Me.Y
    End Function
    Public Sub SetWidth(val As Integer)
        Me.Width = val
    End Sub
    Public Function GetWidth() As Integer
        Return Me.Width
    End Function
    Public Sub SetHeight(val As Integer)
        Me.Height = val
    End Sub
    Public Function GetHeight() As Integer
        Return Me.Height
    End Function
    Public Sub SetShapeType(Type As ShapeType)
        Me.Type = Type
    End Sub
    Public Function GetShapeType() As ShapeType
        Return Me.Type
    End Function
    Public Sub SetColor(Col As Color)
        Me.Color = Col
    End Sub
    Public Function GetColor() As Color
        Return Me.Color
    End Function
    Public Sub SetScaleIn(Axis As Char, value As Single)
        Select Case UCase(Axis)
            Case "X"
                Me.ScaleX = value
            Case "Y"
                Me.ScaleY = value
            Case Else
                Throw New Exception("Incorrect axis set for scaling of shape.")
        End Select
    End Sub
    Public Function GetScaleIn(Axis As Char) As Single
        Select Case UCase(Axis)
            Case "X"
                Return Me.ScaleX
            Case "Y"
                Return Me.ScaleY
            Case Else
                Throw New Exception("Incorrect axis set for scaling of shape.")
        End Select
    End Function
    Public Sub SetRotation(theta As Double)
        Me.Rotation = theta
    End Sub
    Public Function GetRotation() As Double
        Return Me.Rotation
    End Function
    Public Sub SetOpacity(ByVal lvl As Integer)
        lvl = GeoGraphics.ARGBCheck(lvl)
        Me.Opacity = lvl
    End Sub
    Public Function GetOpacity() As Integer
        Return Me.Opacity
    End Function
    Public Sub SetScoreAssignedForGen(val As Boolean)
        Me.ScoreAssignedForGen = val
    End Sub
    Public Function GetScoreAssignedForGen() As Boolean
        Return Me.ScoreAssignedForGen
    End Function

End Class
