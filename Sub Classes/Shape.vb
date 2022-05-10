Public Class Shape

    Protected Bounds As Rectangle
    Protected Type As ShapeType
    Protected Color As Color
    Protected ScaleX As Single
    Protected ScaleY As Single
    Protected Rotation As Double
    Protected Opacity As Integer 'Defualt value is 255
    Protected Score As Integer

    Public Enum ShapeType
        Rectangle
        Ellipse
        Triangle
    End Enum

    Sub New(ShapeType As ShapeType)
        Me.Type = ShapeType

        Me.ScaleX = 1
        Me.ScaleY = 1
        Me.Bounds = New Rectangle(0, 0, 10, 10)
    End Sub

    Public Sub Translate(Vector As Vector)
        Me.Bounds.X += Vector.X
        Me.Bounds.Y += Vector.Y
    End Sub
    Public Sub Rotate(theta As Double)
        Me.Rotation += theta
    End Sub
    Public Sub StretchY(ScaleFactor As Single)
        Me.Bounds.Height *= ScaleFactor
    End Sub
    Public Sub StretchX(ScaleFactor As Single)
        Me.Bounds.Width *= ScaleFactor
    End Sub

    Public Sub Randomize(ByVal BoundingArea As Size)
        Dim Rnd As New Random
        Me.SetColor(Color.FromArgb(Rnd.Next(0, 255), Rnd.Next(0, 255), Rnd.Next(0, 255)))
        Me.SetOpacity(Rnd.Next(0, 200))
        Me.SetRotation(Rnd.Next(0, 360))
        Me.SetX(Rnd.Next(0, BoundingArea.Width))
        Me.SetY(Rnd.Next(0, BoundingArea.Height))
        Me.StretchX(Rnd.Next(0.2, 20))
        Me.StretchY(Rnd.Next(0.2, 20))
    End Sub

    '=========GETTERS/SETTERS===========
    Public Sub SetScore(val As Integer)
        Me.Score = val
    End Sub
    Public Function GetScore() As Integer
        Return Me.Score
    End Function
    Public Sub SetX(ByVal val As Integer)
        Me.Bounds.X = val
    End Sub
    Public Sub SetY(ByVal val As Integer)
        Me.Bounds.Y = val
    End Sub
    Public Sub SetBounds(ByVal Rect As Rectangle)
        Me.Bounds = Rect
    End Sub
    Public Function GetBounds() As Rectangle
        Return Me.Bounds
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
        If lvl > 255 Then lvl = 0
        If lvl < 0 Then lvl = 0
        Me.Opacity = lvl
    End Sub
    Public Function GetOpacity() As Integer
        Return Me.Opacity
    End Function

End Class
