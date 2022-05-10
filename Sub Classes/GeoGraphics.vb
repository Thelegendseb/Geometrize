Imports System.Drawing.Drawing2D
Public Class GeoGraphics

    Public Shared Sub DrawShape(ByRef bmp As Bitmap, ByVal ShapeIn As Shape)
        Using g As Graphics = Graphics.FromImage(bmp)
            Dim B As New SolidBrush(Color.FromArgb(ShapeIn.GetOpacity, ShapeIn.GetColor))
            Dim rect As Rectangle = ShapeIn.GetBounds
            Using m As New Matrix
                m.RotateAt(ShapeIn.GetRotation, New PointF(ShapeIn.GetX, ShapeIn.GetY))
                g.Transform = m
                Select Case ShapeIn.GetShapeType
                    Case Shape.ShapeType.Rectangle
                        g.FillRectangle(B, rect)
                    Case Shape.ShapeType.Ellipse
                        g.FillEllipse(B, rect)
                    Case Shape.ShapeType.Triangle
                        g.FillPolygon(B, {New Point(rect.X, rect.Y + rect.Height),
                                        New Point(rect.X + rect.Width, rect.Y + rect.Height),
                                         New Point(rect.X + (rect.Width / 2), rect.Y)})
                End Select
                g.ResetTransform()
            End Using
        End Using
    End Sub
    Public Shared Function ColorVarier(ByVal ColorIn As Color, ByVal Varier As Integer) As Color
        Return Color.FromArgb(ARGBCheck(ColorIn.R + Varier),
                              ARGBCheck(ColorIn.G + Varier),
                              ARGBCheck(ColorIn.B + Varier))
    End Function
    Public Shared Function ARGBCheck(ByRef val As Integer) As Integer
        If val > 255 Then val = 255
        If val < 0 Then val = 0
        Return val
    End Function

End Class
