
Public Class Form1

    Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load

    End Sub
    Private Sub Form1_Shown(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Shown

        Dim Geometrizer As New Geometrizer(Image.FromFile("C:\Users\sebcl\OneDrive\Pictures\RelatedToCoding\me.jpeg"),
                                           Shape.ShapeType.Ellipse, 500)

        Geometrizer.Start()

        Me.ClientSize = Geometrizer.GetSize

        Me.BackgroundImage = Geometrizer.GetCurrent

    End Sub

End Class
