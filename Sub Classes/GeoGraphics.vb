Imports System.Drawing.Drawing2D
Public Class GeoGraphics

    Public Shared Sub DrawShape(ByRef bmp As Bitmap, ByVal ShapeIn As Shape)
        Using g As Graphics = Graphics.FromImage(bmp)
            Dim B As New SolidBrush(Color.FromArgb(ShapeIn.GetOpacity, ShapeIn.GetColor))
            Dim rect As Rectangle = ShapeIn.GetBounds
            Using m As New Matrix
                m.RotateAt(ShapeIn.GetRotation, New PointF(rect.X + rect.Width / 2, rect.Y + rect.Height / 2))
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

End Class
