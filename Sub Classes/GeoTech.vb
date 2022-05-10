
Public Class GeoTech
    Public Shared Function GetAverageColor(ByVal bmp As Bitmap) As Color
        'write the code for this function
        Dim totalRed As Integer = 0
        Dim totalGreen As Integer = 0
        Dim totalBlue As Integer = 0
        Dim totalPixels As Integer = bmp.Width * bmp.Height
        Dim currentcol As Color
        For x As Integer = 0 To bmp.Width - 1
            For y As Integer = 0 To bmp.Height - 1
                currentcol = bmp.GetPixel(x, y)
                totalRed += currentcol.R
                totalGreen += currentcol.G
                totalBlue += currentcol.B
            Next
        Next
        Return Color.FromArgb(totalRed / totalPixels, totalGreen / totalPixels, totalBlue / totalPixels)
    End Function

    'the function will return an integer that represents the difference between the two bitmaps
    'this difference is calculated by comparing ech pixel in the two bitmaps, and calculating their difference in color.
    'the lower the difference, the score becomes higher
    'assume both bitmaps are the same size
    'return the score

    Public Shared Function ScoreOfImage(ByVal Current As Bitmap, ByVal Target As Bitmap, stepvalue As Integer) As Integer
        'higher step = less quality
        If Current.Size <> Target.Size Then Throw New Exception("Bitmaps are not the same size")
        If stepvalue < 1 Then Throw New Exception("Step value must be greater than 0")

        Dim score As Integer = 0
        Dim diff As Integer = 0

        For x As Integer = 0 To Current.Width - 1 Step stepvalue
            For y As Integer = 0 To Current.Height - 1 Step stepvalue
                diff = ColorDifference(Current.GetPixel(x, y), Target.GetPixel(x, y))
                score += diff
            Next
        Next
        Return score
    End Function
    Private Shared Function ColorDifference(ByVal c1 As Color, ByVal c2 As Color) As Integer
        Dim R As Integer = CInt(c1.R) - CInt(c2.R)
        Dim G As Integer = CInt(c1.G) - CInt(c2.G)
        Dim B As Integer = CInt(c1.B) - CInt(c2.B)
        Return R + G + B
    End Function

End Class
