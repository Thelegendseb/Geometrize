
Public Class Form1

    Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
    End Sub
    Private Sub Form1_Shown(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Shown

        Dim Geometrizer As New Geometrizer(Image.FromFile("C:\Users\sebcl\OneDrive\Pictures\RelatedToCoding\GeoTest.jpg"),
                                           Shape.ShapeType.Ellipse, 100)

        Me.ClientSize = Geometrizer.GetSize

        Geometrizer.Start()

        ImgTest(Geometrizer)

    End Sub
    Public Sub ImgTest(Geometrizer As Geometrizer)
        Me.BackgroundImage = Geometrizer.GetCurrent
        Application.DoEvents()
    End Sub

End Class
