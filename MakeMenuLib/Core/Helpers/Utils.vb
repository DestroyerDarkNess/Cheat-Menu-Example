Imports System.Drawing

Namespace Core.Helpers

    Public Class Utils

        Public Function Resize_Image(ByVal img As Image, ByVal Width As Int32, ByVal Height As Int32) As Bitmap
            Dim Bitmap_Source As New Bitmap(img)
            Dim Bitmap_Dest As New Bitmap(CInt(Width), CInt(Height))
            Dim Graphic As Graphics = Graphics.FromImage(Bitmap_Dest)
            Graphic.DrawImage(Bitmap_Source, 0, 0, Bitmap_Dest.Width + 1, Bitmap_Dest.Height + 1)
            Return Bitmap_Dest
        End Function

    End Class

End Namespace

