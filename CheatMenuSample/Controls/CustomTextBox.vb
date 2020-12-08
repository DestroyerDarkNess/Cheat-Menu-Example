Public Class CustomTextBox
    Inherits TextBox

    Public Sub New()
        SetStyle(ControlStyles.SupportsTransparentBackColor, True) ' Or ControlStyles.OptimizedDoubleBuffer Or ControlStyles.AllPaintingInWmPaint Or ControlStyles.ResizeRedraw Or ControlStyles.UserPaint
    End Sub

End Class