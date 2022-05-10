Public Class Geometrizer

    Private Target As Bitmap
    Protected Current As Bitmap
    Protected ImageSize As Size
    Private Type As Shape.ShapeType 'Only 1 type per session
    Private Limit As Integer 'maximimum amount of drawings to current
    Private ShapeList As List(Of Shape) 'all shape instances that make up Current

    Sub New(Target As Image, CreationType As Shape.ShapeType, Limit As Integer) 'Optional ImageOutputType {VFX}

        Me.ImageSize = New Size(600, 400) 'temporary for testing

        Me.Target = New Bitmap(Target, Me.ImageSize)  'get photo with OpenFileDialog control

        Me.Current = New Bitmap(Me.ImageSize.Width, Me.ImageSize.Height)
        Me.Type = CreationType
        Me.Limit = Limit

    End Sub
    Public Sub Start() 'make into a recursive algorithm

        Dim SessionStep As Integer = 2 'consistant throughout session

        SetBackground(Me.Current) 'set current to avr background color

        Dim templist As New List(Of Shape)
        AddToList(100, templist)
        RandomiseShapesIn(templist)
        AssignShapeScoresTo(templist, SessionStep)
        SortByScore(templist)

        DrawShapesTo(Me.Current, templist)
    End Sub

    '==SIDE METHODS/FUNCTIONS=====
    Private Sub DrawShapesTo(ByRef bmp As Bitmap, ByVal L As List(Of Shape))
        For Each Shape As Shape In L
            GeoGraphics.DrawShape(bmp, Shape)
        Next
    End Sub
    Private Sub AssignShapeScoresTo(ByRef L As List(Of Shape), stepvalue As Integer)
        For Each Shape As Shape In L
            AssignScoreToShape(Shape, stepvalue)
        Next
    End Sub
    Private Sub AssignScoreToShape(ByRef S As Shape, stepvalue As Integer)
        Using addon As New Bitmap(Me.Current)
            GeoGraphics.DrawShape(addon, S)
            S.SetScore(GeoTech.ScoreOfImage(addon, Target, stepvalue))
        End Using
    End Sub
    Private Sub AddToList(val As Integer, ByRef L As List(Of Shape))
        For i = 0 To val - 1
            L.Add(New Shape(Me.Type))
        Next
    End Sub
    Private Sub RandomiseShapesIn(ByRef L As List(Of Shape))
        For Each Shape As Shape In L
            Shape.Randomize(Me.ImageSize)
        Next
    End Sub
    Private Sub SortByScore(ByRef L As List(Of Shape))
        L.Sort(Function(x, y) y.GetScore.CompareTo(x.GetScore))
    End Sub
    Private Sub SetBackground(ByRef bmp As Bitmap)
        Dim BG As Color = GeoTech.GetAverageColor(Me.Target)
        Using g As Graphics = Graphics.FromImage(bmp)
            g.Clear(BG)
        End Using
    End Sub

    '====GETTERS/SETTERS======
    Public Function GetCurrent() As Bitmap
        Return Me.Current
    End Function
    Public Function GetSize() As Size
        Return Me.ImageSize
    End Function
End Class
