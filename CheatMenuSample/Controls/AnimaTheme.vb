Imports System.Threading

Friend Module Helpers

    Private Size As SizeF

    Public Function MiddlePoint(G As Graphics, TargetText As String, TargetFont As Font, Rect As Rectangle) As Point
        Size = G.MeasureString(TargetText, TargetFont)
        Return New Point(Rect.Width / 2 - Size.Width / 2, Rect.Height / 2 - Size.Height / 2)
    End Function

End Module

Public Class AnimaExperimentalListView
    Inherits Control

    Public Property Columns As String()

    Public Property Items As ListViewItem()

    Public Property ColumnWidth As Integer = 120

    Public Property SelectedIndex As Integer = -1

    Public Property SelectedIndexes As New List(Of Integer)

    Public Property Multiselect As Boolean

    Public Property Highlight As Integer = -1

    Public Property HandleItemsForeColor As Boolean

    Public Property Grid As Boolean

    Public Property ItemSize As Integer = 16

    Public ReadOnly Property SelectedCount As Integer
        Get
            Return SelectedIndexes.Count
        End Get
    End Property

    Public ReadOnly Property FocusedItem As ListViewItem
        Get
            If IsNothing(SelectedIndexes) Then
                Return New ListViewItem
            End If

            Return Items(SelectedIndexes(0))
        End Get
    End Property

    Public Sub Add(Item As ListViewItem)
        Dim ItemsList As List(Of ListViewItem) = Items.ToList
        ItemsList.Add(Item)
        Items = ItemsList.ToArray
        Invalidate()
    End Sub

    Public Sub Clear()
        Dim ItemsList As List(Of ListViewItem) = Items.ToList
        ItemsList.Clear()
        Items = ItemsList.ToArray
        Invalidate()
    End Sub

    Public Sub RemoveItem(ByVal Item As Integer)
        Dim ItemsList As List(Of ListViewItem) = Items.ToList
        ItemsList.Remove(ItemsList(Item))
        Items = ItemsList.ToArray
        Invalidate()
    End Sub

    Private BorderIndex As Integer = -1

    Public Event SelectedIndexChanged(Sender As Object, Index As Integer)

    Sub New()
        DoubleBuffered = True
        ForeColor = Color.FromArgb(200, 200, 200)
        Font = New Font("Segoe UI", 9)
        SetStyle(ControlStyles.OptimizedDoubleBuffer Or ControlStyles.AllPaintingInWmPaint, True)
    End Sub

    Private Function ReturnForeFromItem(I As Integer, Item As ListViewItem) As SolidBrush
        If SelectedIndexes.Contains(I) Then
            Return New SolidBrush(Color.FromArgb(10, 10, 10))
        End If
        If HandleItemsForeColor Then
            Return New SolidBrush(Item.ForeColor)
        Else
            Return New SolidBrush(ForeColor)
        End If
    End Function

    Private Function ReturnForeFromSubItem(I As Integer, Item As ListViewItem.ListViewSubItem) As SolidBrush
        If SelectedIndexes.Contains(I) Then
            Return New SolidBrush(Color.FromArgb(10, 10, 10))
        End If
        If HandleItemsForeColor Then
            Return New SolidBrush(Item.ForeColor)
        Else
            Return New SolidBrush(ForeColor)
        End If
    End Function

    Protected Overrides Sub OnPaint(e As PaintEventArgs)
        On Error Resume Next
        e.Graphics.Clear(Color.FromArgb(50, 50, 53))

        Using Background As New SolidBrush(Color.FromArgb(55, 55, 58))
            e.Graphics.FillRectangle(Background, New Rectangle(1, 1, Width - 2, 26))
        End Using

        Using Border As New Pen(Color.FromArgb(42, 42, 45)), Shadow As New Pen(Color.FromArgb(65, 65, 68))
            e.Graphics.DrawRectangle(Border, New Rectangle(0, 0, Width - 1, Height - 1))
            e.Graphics.DrawRectangle(Border, New Rectangle(0, 0, Width - 1, 26))
            e.Graphics.DrawLine(Shadow, 1, 1, Width - 2, 1)
        End Using

        If Not IsNothing(Columns) Then

            For I = 0 To Columns.Count - 1

                If Not I = 0 Then

                    Using Separator As New SolidBrush(Color.FromArgb(42, 42, 45)), Shadow As New SolidBrush(Color.FromArgb(65, 65, 68))
                        e.Graphics.FillRectangle(Separator, New Rectangle(ColumnWidth * I, 1, 1, 26))
                        e.Graphics.FillRectangle(Shadow, New Rectangle(ColumnWidth * I - 1, 1, 1, 25))

                        If Grid AndAlso Not IsNothing(Items) Then
                            e.Graphics.FillRectangle(Separator, New Rectangle(ColumnWidth * I, 1, 1, 26 + (Items.Count * ItemSize)))
                            e.Graphics.FillRectangle(Shadow, New Rectangle(ColumnWidth * I - 1, 1, 1, 25 + (Items.Count * ItemSize)))
                        End If

                    End Using

                End If

                Using Fore As New SolidBrush(ForeColor)
                    e.Graphics.DrawString(Columns(I), Font, Fore, New Point((ColumnWidth * I) + 6, 4))
                End Using

            Next

        End If

        If Not IsNothing(Items) Then

            If Not Highlight = -1 Then

                Using Background As New SolidBrush(Color.FromArgb(66, 66, 69)), Line As New Pen(Color.FromArgb(45, 45, 48))
                    e.Graphics.FillRectangle(Background, New Rectangle(1, 26 + Highlight * ItemSize, Width - 2, ItemSize))
                    e.Graphics.DrawRectangle(Line, New Rectangle(1, 26 + Highlight * ItemSize, Width - 2, ItemSize))
                End Using

            End If

            Using Selection As New SolidBrush(Color.FromArgb(41, 130, 232)), Line As New Pen(Color.FromArgb(40, 40, 40))

                If Multiselect AndAlso Not SelectedIndexes.Count = 0 Then

                    For Each Selected As Integer In SelectedIndexes
                        e.Graphics.FillRectangle(Selection, New Rectangle(1, 26 + Selected * ItemSize, Width - 2, ItemSize))

                        If Selected = 0 AndAlso SelectedIndexes.Count = 1 Then
                            e.Graphics.DrawLine(Line, 1, 26 + ItemSize, Width - 2, 26 + ItemSize)

                        ElseIf SelectedIndexes.Count = 1 Then
                            e.Graphics.DrawLine(Line, 1, 26 + ItemSize + Selected * ItemSize, Width - 2, 26 + ItemSize + Selected * ItemSize)
                        End If

                    Next

                ElseIf Not SelectedIndexes.Count = 0 Then
                    e.Graphics.FillRectangle(Selection, New Rectangle(1, 26 + SelectedIndex * ItemSize, Width - 2, ItemSize))
                End If


            End Using

            If SelectedIndexes.Count > 0 Then
                BorderIndex = SelectedIndexes.Max
            End If

            For I = 0 To Items.Count - 1

                e.Graphics.DrawString(Items(I).Text, Font, ReturnForeFromItem(I, Items(I)), New Point(6, 26 + I * ItemSize + 2))

                If Not IsNothing(Items(I).SubItems) Then

                    For X = 0 To Items(I).SubItems.Count - 1

                        If Not Items(I).SubItems(X).Text = Items(I).Text Then
                            e.Graphics.DrawString(Items(I).SubItems(X).Text, Font, ReturnForeFromSubItem(I, Items(I).SubItems(X)), New Rectangle((ColumnWidth * X) + 6, 26 + I * ItemSize + 2, ColumnWidth - 8, 16))
                        End If
                    Next

                End If

            Next

            If SelectedIndexes.Contains(BorderIndex) Then

                Using Line As New Pen(Color.FromArgb(40, 40, 40))
                    e.Graphics.DrawLine(Line, 1, 26 + ItemSize + BorderIndex * ItemSize, Width - 2, 26 + ItemSize + BorderIndex * ItemSize)
                End Using

            End If

        End If

        MyBase.OnPaint(e)
    End Sub

    Protected Overrides Sub OnMouseUp(e As MouseEventArgs)

        Dim Selection As Integer = GetSelectedFromLocation(e.Location)

        If Selection = -1 OrElse Not e.Button = MouseButtons.Left Then
            Return
        End If

        If Multiselect AndAlso My.Computer.Keyboard.CtrlKeyDown Then

            If Not SelectedIndexes.Contains(Selection) Then
                SelectedIndexes.Add(Selection)
            Else
                SelectedIndexes.Remove(Selection)
            End If

        ElseIf Multiselect AndAlso Not My.Computer.Keyboard.CtrlKeyDown Then
            SelectedIndexes = New List(Of Integer) From {
                Selection
            }

        Else
            SelectedIndexes = New List(Of Integer) From {
                Selection
            }
            SelectedIndex = Selection
        End If

        If Selection = -1 Then
            SelectedIndexes = New List(Of Integer)
        End If

        Invalidate()

        RaiseEvent SelectedIndexChanged(Me, Selection)
        MyBase.OnMouseUp(e)
    End Sub

    Private Function GetSelectedFromLocation(P As Point) As Integer

        If Not IsNothing(Items) Then

            For I = 0 To Items.Count - 1
                If New Rectangle(1, 26 + I * ItemSize, Width - 2, ItemSize).Contains(P) Then
                    Return I
                End If
            Next

        End If

        Return -1

    End Function

End Class

Public Class AnimaTextBox
    Inherits Control

    Private G As Graphics
    Private WithEvents T As TextBox

    Private AnimatingT As Thread
    Private AnimatingT2 As Thread

    Private RGB() As Integer = {45, 45, 48}
    Private RGB1 As Integer = 45
    Private Block As Boolean

    Public Property Dark As Boolean

    Public Property Numeric As Boolean

    Public Shadows Property Text As String
        Get
            Return T.Text
        End Get
        Set(value As String)
            MyBase.Text = Value
            T.Text = Value
            Invalidate()
        End Set
    End Property

    Public Property MaxLength As Integer
        Get
            Return T.MaxLength
        End Get
        Set(value As Integer)
            T.MaxLength = Value
            Invalidate()
        End Set
    End Property

    Public Property UseSystemPasswordChar As Boolean
        Get
            Return T.UseSystemPasswordChar
        End Get
        Set(value As Boolean)
            T.UseSystemPasswordChar = Value
            Invalidate()
        End Set
    End Property

    Public Property MultiLine As Boolean
        Get
            Return T.Multiline
        End Get
        Set(value As Boolean)
            T.Multiline = Value
            Size = New Size(T.Width + 2, T.Height + 2)
            Invalidate()
        End Set
    End Property

    Public Shadows Property [ReadOnly] As Boolean
        Get
            Return T.ReadOnly
        End Get
        Set(value As Boolean)
            T.ReadOnly = Value
            Invalidate()
        End Set
    End Property

    Sub New()
        DoubleBuffered = True

        T = New TextBox With {
            .BorderStyle = BorderStyle.None,
            .ForeColor = Color.FromArgb(200, 200, 200),
            .BackColor = Color.FromArgb(55, 55, 58),
            .Location = New Point(6, 5),
            .Multiline = False}

        Controls.Add(T)
    End Sub

    Protected Overrides Sub CreateHandle()
        If Dark Then
            RGB = {42, 42, 45}
            RGB1 = 45
            T.BackColor = Color.FromArgb(45, 45, 48)
        Else
            RGB = {70, 70, 70}
            RGB1 = 70
            T.BackColor = Color.FromArgb(55, 55, 58)
        End If
        MyBase.CreateHandle()
    End Sub

    Protected Overrides Sub OnEnter(e As EventArgs)
        T.Select()
        MyBase.OnEnter(e)
    End Sub

    Protected Overrides Sub OnPaint(e As PaintEventArgs)

        G = e.Graphics

        If Enabled Then

            If Dark Then
                G.Clear(Color.FromArgb(45, 45, 48))

                Using Border As New Pen(Color.FromArgb(RGB(0), RGB(1), RGB(2)))
                    G.DrawRectangle(Border, New Rectangle(0, 0, Width - 1, Height - 1))
                End Using

            Else
                G.Clear(Color.FromArgb(55, 55, 58))

                Using Shadow As New Pen(Color.FromArgb(42, 42, 45)), Border As New Pen(Color.FromArgb(RGB(0), RGB(1), RGB(2)))
                    G.DrawRectangle(Border, New Rectangle(1, 1, Width - 3, Height - 3))
                    G.DrawRectangle(Shadow, New Rectangle(0, 0, Width - 1, Height - 1))
                End Using

            End If

        Else

            G.Clear(Color.FromArgb(50, 50, 53))
            T.BackColor = Color.FromArgb(50, 50, 53)

            Using Border As New Pen(Color.FromArgb(42, 42, 45)), Shadow As New Pen(Color.FromArgb(66, 66, 69))
                e.Graphics.DrawRectangle(Border, New Rectangle(0, 0, Width - 1, Height - 1))
                e.Graphics.DrawRectangle(Shadow, New Rectangle(1, 1, Width - 3, Height - 3))
            End Using

        End If

        MyBase.OnPaint(e)

    End Sub

    Private Sub TEnter() Handles T.Enter

        If Not Block Then
            AnimatingT = New Thread(AddressOf DoAnimation) With {
                .IsBackground = True}
            AnimatingT.Start()
        End If

    End Sub

    Private Sub TKeyPress(sender As Object, e As KeyPressEventArgs) Handles T.KeyPress

        If Numeric Then

            If Asc(e.KeyChar) <> 8 Then
                If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                    e.Handled = True
                End If
            End If

        End If

    End Sub

    Private Sub TLeave() Handles T.Leave
        AnimatingT2 = New Thread(AddressOf UndoAnimation) With {
                .IsBackground = True}
        AnimatingT2.Start()
    End Sub

    Protected Overrides Sub OnResize(e As EventArgs)
        If MultiLine Then
            T.Size = New Size(Width - 7, Height - 7) : Invalidate()
        Else
            T.Size = New Size(Width - 8, Height - 15) : Invalidate()
        End If
        MyBase.OnResize(e)
    End Sub

    Private Sub TTextChanged() Handles T.TextChanged
        OnTextChanged(EventArgs.Empty)
    End Sub

    Private Sub DoAnimation()

        While RGB(2) < 204 AndAlso Not Block

            RGB(1) += 1
            RGB(2) += 2

            Invalidate()
            Thread.Sleep(5)

        End While

    End Sub

    Private Sub UndoAnimation()

        Block = True

        While RGB(2) > RGB1

            RGB(1) -= 1
            RGB(2) -= 2

            Invalidate()
            Thread.Sleep(5)

        End While

        Block = False

    End Sub

End Class

Public Class AnimaProgressBar
    Inherits ProgressBar

    Private G As Graphics

    Dim _backColor As Color = Color.FromArgb(35, 35, 38)
    Public Overrides Property BackColor As Color
        Get
            Return _backColor
        End Get
        Set(ByVal value As Color)
            _backColor = value
            Invalidate()
        End Set
    End Property

    Dim _BorderColor As Color = Color.FromArgb(35, 35, 38)
    Public Property BorderColors As Color
        Get
            Return _BorderColor
        End Get
        Set(ByVal value As Color)
            _BorderColor = value
            Invalidate()
        End Set
    End Property

    Sub New()
        SetStyle(ControlStyles.UserPaint Or ControlStyles.OptimizedDoubleBuffer Or ControlStyles.AllPaintingInWmPaint, True)
    End Sub

    Protected Overrides Sub OnPaint(e As PaintEventArgs)

        G = e.Graphics

        MyBase.OnPaint(e)

        G.Clear(Color.FromArgb(37, 37, 40))

        Using Border As New Pen(_BorderColor)
            G.DrawRectangle(Border, New Rectangle(0, 0, Width - 1, Height - 1))
        End Using

        Using Background As New SolidBrush(_backColor)
            G.FillRectangle(Background, New Rectangle(0, 0, Value / Maximum * Width - 1, Height - 1))
        End Using

    End Sub

End Class

Public Class AnimaCheckBox
    Inherits CheckBox

    Private G As Graphics

    Private AnimatingT As Thread
    Private AnimatingT2 As Thread

    Private RGB() As Integer = {36, 36, 39}

    Private Block As Boolean

    Public Property Radio As Boolean

    Public Property Caution As Boolean

    Private Const CheckedIcon As String = "iVBORw0KGgoAAAANSUhEUgAAAAsAAAAKCAMAAABVLlSxAAAASFBMVEUlJSYuLi8oKCmlpaXx8fGioqJoaGjOzs8+Pj/k5OTu7u5LS0zIyMiBgYKFhYXo6OhUVFWVlZW7u7t+fn7h4eE5OTlfX1+YmJn8uq7eAAAAA3RSTlMAAAD6dsTeAAAACXBIWXMAAABIAAAASABGyWs+AAAAO0lEQVQI12NgwAKYWVhhTDYWdkYok4OTixvCYGDiYeEFM/n4BQRZhCDywiz8XCKiDDAOixjcPGFxDCsASakBdDYGvzAAAAAldEVYdGRhdGU6Y3JlYXRlADIwMTYtMTItMTRUMTI6MDM6MjktMDY6MDB4J65tAAAAJXRFWHRkYXRlOm1vZGlmeQAyMDE2LTEyLTE0VDEyOjAzOjI5LTA2OjAwCXoW0QAAAABJRU5ErkJggg=="

    Sub New()
        DoubleBuffered = True
        Font = New Font("Segoe UI", 9)
        ForeColor = Color.FromArgb(200, 200, 200)
        SetStyle(ControlStyles.UserPaint Or ControlStyles.OptimizedDoubleBuffer Or ControlStyles.AllPaintingInWmPaint, True)
    End Sub

    Protected Overrides Sub OnPaint(e As PaintEventArgs)

        G = e.Graphics
        G.InterpolationMode = Drawing2D.InterpolationMode.HighQualityBicubic

        G.Clear(BackColor)

        Using Background As New SolidBrush(Color.FromArgb(38, 38, 41))
            G.FillRectangle(Background, New Rectangle(0, 0, 16, 16))
        End Using

        Using Border As New Pen(Color.FromArgb(RGB(0), RGB(1), RGB(2)))
            G.DrawRectangle(Border, New Rectangle(0, 0, 16, 16))
        End Using

        Using Fore As New SolidBrush(ForeColor)
            G.DrawString(Text, Font, Fore, New Point(22, 0))
        End Using

        If Checked Then

            Using Mark As Image = Image.FromStream(New IO.MemoryStream(Convert.FromBase64String(CheckedIcon)))
                G.DrawImage(Mark, New Point(2, 3))
            End Using

        End If

    End Sub

    Protected Overrides Sub OnMouseEnter(e As EventArgs)

        If Not Block Then
            AnimatingT = New Thread(AddressOf DoAnimation) With {
                .IsBackground = True}
            AnimatingT.Start()
        End If

        MyBase.OnMouseEnter(e)
    End Sub

    Protected Overrides Sub OnMouseLeave(e As EventArgs)
        AnimatingT2 = New Thread(AddressOf UndoAnimation) With {
                .IsBackground = True}
        AnimatingT2.Start()

        MyBase.OnMouseLeave(e)
    End Sub

    Protected Overrides Sub OnMouseUp(e As MouseEventArgs)
        If Radio Then
            For Each C As AnimaCheckBox In Parent.Controls.OfType(Of AnimaCheckBox)()
                If C.Radio Then
                    C.Checked = False
                End If
            Next
        End If

        MyBase.OnMouseUp(e)
    End Sub

    Private Sub DoAnimation()

        If Caution Then

            While RGB(2) < 130 AndAlso Not Block

                RGB(1) += 1
                RGB(2) += 1

                Invalidate()
                Thread.Sleep(4)

            End While

        Else

            While RGB(2) < 204 AndAlso Not Block

                RGB(1) += 1
                RGB(2) += 2

                Invalidate()
                Thread.Sleep(4)

            End While

        End If

    End Sub

    Private Sub UndoAnimation()

        Block = True

        If Caution Then

            While RGB(2) > 42

                RGB(1) -= 1
                RGB(2) -= 1

                Invalidate()
                Thread.Sleep(4)

            End While

        Else

            While RGB(2) > 42

                RGB(1) -= 1
                RGB(2) -= 2

                Invalidate()
                Thread.Sleep(4)

            End While

        End If

        Block = False

    End Sub

End Class

Public Class AnimaHeader
    Inherits Control

    Private G As Graphics

    Sub New()
        DoubleBuffered = True
        Font = New Font("Segoe UI", 9)
        Location = New Point(1, 1)
        Size = New Size(Width - 2, 36)
        ForeColor = Color.FromArgb(200, 200, 200)
    End Sub

    Protected Overrides Sub OnPaint(e As PaintEventArgs)

        G = e.Graphics

        Using Background As New SolidBrush(Color.FromArgb(55, 55, 58))
            G.FillRectangle(Background, New Rectangle(0, 0, Width - 1, Height - 1))
        End Using

        Using Line As New Pen(Color.FromArgb(43, 43, 46))
            G.DrawLine(Line, 0, Height - 1, Width - 1, Height - 1)
        End Using

        Using Fore As New SolidBrush(ForeColor)
            G.DrawString(Text, Font, Fore, New Point(6, 6))
        End Using

        MyBase.OnPaint(e)
    End Sub

End Class

Public Class AnimaForm
    Inherits ContainerControl

    Private G As Graphics

    Sub New()
        BackColor = Color.FromArgb(45, 45, 48)
        DoubleBuffered = True
        Font = New Font("Segoe UI", 9)
        Dock = DockStyle.Fill
        ForeColor = Color.FromArgb(200, 200, 200)
    End Sub

    Protected Overrides Sub OnCreateControl()
        ParentForm.FormBorderStyle = FormBorderStyle.None
        MyBase.OnCreateControl()
    End Sub

    Protected Overrides Sub OnPaint(e As PaintEventArgs)

        G = e.Graphics

        Using Background As New SolidBrush(Color.FromArgb(50, 50, 50))
            G.FillRectangle(Background, New Rectangle(0, 0, Width - 1, 36))
        End Using

        Using Line As New Pen(Color.FromArgb(43, 43, 46))
            G.DrawLine(Line, 0, 36, Width - 1, 36)
        End Using

        Using Fore As New SolidBrush(ForeColor)
            G.DrawString(Text, Font, Fore, New Point(10, 10))
        End Using

        Using Border As New Pen(Color.FromArgb(35, 35, 38))
            e.Graphics.DrawRectangle(Border, New Rectangle(0, 0, Width - 1, Height - 1))
        End Using

        MyBase.OnPaint(e)
    End Sub

    Private Drag As Boolean
    Private MousePoint, Temporary As New Point

    Protected Overrides Sub OnMouseDown(e As MouseEventArgs)

        If e.Button = MouseButtons.Left AndAlso e.Y < 36 Then
            Drag = True
            MousePoint.X = e.X
            MousePoint.Y = e.Y
        End If

        MyBase.OnMouseDown(e)
    End Sub

    Protected Overrides Sub OnMouseUp(e As MouseEventArgs)
        If e.Button = MouseButtons.Left Then
            Drag = False
        End If

        MyBase.OnMouseUp(e)
    End Sub

    Protected Overrides Sub OnMouseMove(e As MouseEventArgs)

        If Drag Then
            Temporary.X = Parent.Location.X + (e.X - MousePoint.X)
            Temporary.Y = Parent.Location.Y + (e.Y - MousePoint.Y)
            Parent.Location = Temporary
            Temporary = Nothing
        End If

        MyBase.OnMouseMove(e)
    End Sub
End Class

Public Class AnimaButton
    Inherits Button

    Private G As Graphics

    Private HoverAnim, CHoverAnim, DownAnimationT As Thread

    Private RGB() As Integer = {42, 42, 45}

    Private Loc As New Point()
    Private RSize As New Size()

    Private Block As Boolean

    Private Animate As Boolean

    Public Property ImageLocation As Point = New Point(Width / 2 - 7, 6)

    Public Property ImageSize As Size = New Size(14, 14)

    Sub New()
        DoubleBuffered = True
        Font = New Font("Segoe UI", 9)
        ForeColor = Color.FromArgb(200, 200, 200)
        SetStyle(ControlStyles.UserPaint Or ControlStyles.AllPaintingInWmPaint Or ControlStyles.OptimizedDoubleBuffer, True)
    End Sub

    Protected Overrides Sub OnPaint(e As PaintEventArgs)

        G = e.Graphics

        G.Clear(BackColor)

        Using Background As New SolidBrush(Color.FromArgb(55, 55, 58))
            G.FillRectangle(Background, New Rectangle(0, 0, Width - 1, Height - 1))
        End Using

        If Animate Then

            Using Background As New SolidBrush(Color.FromArgb(66, 66, 69))
                G.FillEllipse(Background, New Rectangle(Loc.X, -30, RSize.Width, 80))
            End Using

        End If

        Using Border As New Pen(Color.FromArgb(RGB(0), RGB(1), RGB(2)))
            G.DrawRectangle(Border, New Rectangle(0, 0, Width - 1, Height - 1))
        End Using

        If Not IsNothing(Image) Then
            G.DrawImage(Image, New Rectangle(ImageLocation, ImageSize))
        Else
            Using Fore As New SolidBrush(ForeColor)
                G.DrawString(Text, Font, Fore, MiddlePoint(G, Text, Font, New Rectangle(0, 0, Width - 1, Height - 1)))
            End Using
        End If

    End Sub

    Protected Overrides Sub OnMouseEnter(e As EventArgs)

        If Not Block Then
            HoverAnim = New Thread(AddressOf DoAnimation) With {
                .IsBackground = True}
            HoverAnim.Start()
        End If

        MyBase.OnMouseEnter(e)
    End Sub

    Protected Overrides Sub OnMouseLeave(e As EventArgs)
        CHoverAnim = New Thread(AddressOf UndoAnimation) With {
                .IsBackground = True}
        CHoverAnim.Start()

        MyBase.OnMouseLeave(e)
    End Sub

    Protected Overrides Sub OnMouseDown(e As MouseEventArgs)

        DownAnimationT = New Thread(Sub() DoBackAnimation(e.Location)) With {
             .IsBackground = True}
        DownAnimationT.Start()

        MyBase.OnMouseDown(e)
    End Sub

    Private Sub DoBackAnimation(P As Point)

        Loc = P
        RSize = New Size()

        Animate = True : Invalidate()

        While RSize.Width < Width * 3
            Loc.X -= 1
            RSize.Width += 2
            Thread.Sleep(4)
            Invalidate()
        End While

        Animate = False : Invalidate()

    End Sub

    Private Sub DoAnimation()


        While RGB(2) < 204 AndAlso Not Block

            RGB(1) += 1
            RGB(2) += 2

            Invalidate()
            Thread.Sleep(5)

        End While

    End Sub

    Private Sub UndoAnimation()

        Block = True

        While RGB(2) > 45

            RGB(1) -= 1
            RGB(2) -= 2

            Invalidate()
            Thread.Sleep(5)

        End While

        Block = False

    End Sub

End Class

Public Class Renderer
    Inherits ToolStripRenderer

    Public Event PaintMenuBackground(sender As Object, e As ToolStripRenderEventArgs)
    Public Event PaintMenuBorder(sender As Object, e As ToolStripRenderEventArgs)
    Public Event PaintMenuImageMargin(sender As Object, e As ToolStripRenderEventArgs)
    Public Event PaintItemCheck(sender As Object, e As ToolStripItemImageRenderEventArgs)
    Public Event PaintItemImage(sender As Object, e As ToolStripItemImageRenderEventArgs)
    Public Event PaintItemText(sender As Object, e As ToolStripItemTextRenderEventArgs)
    Public Event PaintItemBackground(sender As Object, e As ToolStripItemRenderEventArgs)
    Public Event PaintItemArrow(sender As Object, e As ToolStripArrowRenderEventArgs)
    Public Event PaintSeparator(sender As Object, e As ToolStripSeparatorRenderEventArgs)

    Protected Overrides Sub OnRenderToolStripBackground(e As ToolStripRenderEventArgs)
        RaiseEvent PaintMenuBackground(Me, e)
    End Sub

    Protected Overrides Sub OnRenderImageMargin(e As ToolStripRenderEventArgs)
        RaiseEvent PaintMenuImageMargin(Me, e)
    End Sub

    Protected Overrides Sub OnRenderToolStripBorder(e As ToolStripRenderEventArgs)
        RaiseEvent PaintMenuBorder(Me, e)
    End Sub

    Protected Overrides Sub OnRenderItemCheck(e As ToolStripItemImageRenderEventArgs)
        RaiseEvent PaintItemCheck(Me, e)
    End Sub

    Protected Overrides Sub OnRenderItemImage(e As ToolStripItemImageRenderEventArgs)
        RaiseEvent PaintItemImage(Me, e)
    End Sub

    Protected Overrides Sub OnRenderItemText(e As ToolStripItemTextRenderEventArgs)
        RaiseEvent PaintItemText(Me, e)
    End Sub

    Protected Overrides Sub OnRenderMenuItemBackground(e As ToolStripItemRenderEventArgs)
        RaiseEvent PaintItemBackground(Me, e)
    End Sub

    Protected Overrides Sub OnRenderArrow(e As ToolStripArrowRenderEventArgs)
        RaiseEvent PaintItemArrow(Me, e)
    End Sub

    Protected Overrides Sub OnRenderSeparator(e As ToolStripSeparatorRenderEventArgs)
        RaiseEvent PaintSeparator(Me, e)
    End Sub

End Class

Public Class AnimaContextMenuStrip
    Inherits ContextMenuStrip

    Private G As Graphics
    Private Rect As Rectangle

    Sub New()
        Font = New Font("Segoe UI", 9)
        ForeColor = Color.FromArgb(200, 200, 200)
        Dim Render As New Renderer()
        AddHandler Render.PaintMenuBackground, AddressOf Renderer_PaintMenuBackground
        AddHandler Render.PaintMenuBorder, AddressOf Renderer_PaintMenuBorder
        AddHandler Render.PaintItemImage, AddressOf Renderer_PaintItemImage
        AddHandler Render.PaintItemText, AddressOf Renderer_PaintItemText
        AddHandler Render.PaintItemBackground, AddressOf Renderer_PaintItemBackground
        AddHandler Render.PaintItemArrow, AddressOf Rendered_PaintItemArrow

        Renderer = Render
    End Sub

    Private Sub Rendered_PaintItemArrow(sender As Object, e As ToolStripArrowRenderEventArgs)
        G = e.Graphics

        Using F As New Font("Marlett", 10), Fore As New SolidBrush(Color.FromArgb(130, 130, 130))
            G.DrawString("4", F, Fore, New Point(e.ArrowRectangle.X, e.ArrowRectangle.Y + 2))
        End Using

    End Sub

    Private Sub Renderer_PaintMenuBackground(sender As Object, e As ToolStripRenderEventArgs)
        G = e.Graphics

        G.Clear(Color.FromArgb(55, 55, 58))
    End Sub

    Private Sub Renderer_PaintMenuBorder(sender As Object, e As ToolStripRenderEventArgs)

        G = e.Graphics

        Using Border As New Pen(Color.FromArgb(35, 35, 38))
            G.DrawRectangle(Border, New Rectangle(e.AffectedBounds.X, e.AffectedBounds.Y, e.AffectedBounds.Width - 1, e.AffectedBounds.Height - 1))
        End Using

    End Sub

    Private Sub Renderer_PaintItemImage(sender As Object, e As ToolStripItemImageRenderEventArgs)

        G = e.Graphics

        G.DrawImage(e.Image, New Point(10, 1))

    End Sub

    Private Sub Renderer_PaintItemText(sender As Object, e As ToolStripItemTextRenderEventArgs)

        G = e.Graphics

        Using Fore As New SolidBrush(e.TextColor)
            G.DrawString(e.Text, Font, Fore, New Point(e.TextRectangle.X, e.TextRectangle.Y - 1))
        End Using

    End Sub

    Private Sub Renderer_PaintItemBackground(sender As Object, e As ToolStripItemRenderEventArgs)

        G = e.Graphics

        Rect = e.Item.ContentRectangle

        If e.Item.Selected Then

            Using Background As New SolidBrush(Color.FromArgb(85, 85, 85))
                G.FillRectangle(Background, New Rectangle(Rect.X - 4, Rect.Y - 1, Rect.Width + 4, Rect.Height - 1))
            End Using

        End If

    End Sub

End Class

Public Class AnimaStatusBar
    Inherits Control

    Private G As Graphics

    Private Body As Color = Color.FromArgb(0, 122, 204)
    Private Outline As Color = Color.FromArgb(0, 126, 204)

    Public Property Type As Types

    Public Enum Types As Byte
        Basic = 0
        Warning = 1
        Wrong = 2
        Success = 3
    End Enum

    Sub New()
        DoubleBuffered = True
    End Sub

    Protected Overrides Sub OnPaint(e As PaintEventArgs)

        G = e.Graphics

        Select Case Type

            Case Types.Basic

                Body = Color.FromArgb(0, 122, 204)
                Outline = Color.FromArgb(0, 126, 204)

            Case Types.Warning

                Body = Color.FromArgb(210, 143, 75)
                Outline = Color.FromArgb(214, 147, 75)

            Case Types.Wrong

                Body = Color.FromArgb(212, 110, 110)
                Outline = Color.FromArgb(216, 114, 114)

            Case Else

                Body = Color.FromArgb(45, 193, 90)
                Outline = Color.FromArgb(45, 197, 90)

        End Select

        Using Background As New SolidBrush(Body), Line As New Pen(Outline)
            G.FillRectangle(Background, New Rectangle(0, 0, Width - 1, Height - 1))
            G.DrawLine(Line, 0, 0, Width - 2, 0)
        End Using

        Using Fore As New SolidBrush(Color.FromArgb(255, 255, 255)), Font As New Font("Segoe UI semibold", 8)
            G.DrawString(Text, Font, Fore, New Point(4, 2))
        End Using

        MyBase.OnPaint(e)
    End Sub

    Protected Overrides Sub OnTextChanged(e As EventArgs)
        Invalidate()
        MyBase.OnTextChanged(e)
    End Sub

End Class

Public Class AnimaTabControl
    Inherits TabControl

    Private G As Graphics
    Private Rect As Rectangle

    Protected Overrides Sub OnControlAdded(e As ControlEventArgs)
        e.Control.BackColor = Color.FromArgb(45, 45, 48)
        e.Control.ForeColor = Color.FromArgb(200, 200, 200)
        e.Control.Font = New Font("Segoe UI", 9)
        MyBase.OnControlAdded(e)
    End Sub

    Sub New()
        DoubleBuffered = True
        Font = New Font("Segoe UI", 9)
        ForeColor = Color.FromArgb(200, 200, 200)
        ItemSize = New Size(18, 18)
        SizeMode = TabSizeMode.Fixed
        Alignment = TabAlignment.Top
        SetStyle(ControlStyles.UserPaint Or ControlStyles.AllPaintingInWmPaint Or ControlStyles.Opaque Or ControlStyles.OptimizedDoubleBuffer, True)
    End Sub

    Protected Overrides Sub OnPaint(e As PaintEventArgs)

        G = e.Graphics

        G.Clear(Parent.BackColor)

        For I = 0 To TabPages.Count - 1

            Rect = GetTabRect(I)

            If SelectedIndex = I Then

                Using Background As New SolidBrush(Color.FromArgb(41, 130, 232)), Border As New Pen(Color.FromArgb(38, 127, 229))
                    G.FillRectangle(Background, New Rectangle(Rect.X + 5, Rect.Y + 2, 12, 12))
                    G.DrawRectangle(Border, New Rectangle(Rect.X + 5, Rect.Y + 2, 12, 12))
                End Using

            Else

                Using Background As New SolidBrush(Color.FromArgb(70, 70, 73)), Border As New Pen(Color.FromArgb(42, 42, 45))
                    G.FillRectangle(Background, New Rectangle(Rect.X + 5, Rect.Y + 2, 12, 12))
                    G.DrawRectangle(Border, New Rectangle(Rect.X + 5, Rect.Y + 2, 12, 12))
                End Using

            End If

        Next

        MyBase.OnPaint(e)
    End Sub

End Class

Public Class AnimaGroupBox
    Inherits Control

    Sub New()
        DoubleBuffered = True
        ForeColor = Color.FromArgb(200, 200, 200)
        BackColor = Color.FromArgb(50, 50, 53)
    End Sub

    Protected Overrides Sub OnPaint(e As PaintEventArgs)

        e.Graphics.Clear(BackColor)

        Using Border As New Pen(Color.FromArgb(42, 42, 45)), HBackground As New SolidBrush(Color.FromArgb(60, 60, 63)), Shadow As New Pen(Color.FromArgb(66, 66, 69))
            e.Graphics.FillRectangle(HBackground, New Rectangle(1, 0, Width - 2, 26))
            e.Graphics.DrawRectangle(Border, New Rectangle(0, 0, Width - 1, 26))
            e.Graphics.DrawLine(Shadow, 1, 25, Width - 2, 25)
            e.Graphics.DrawRectangle(Border, New Rectangle(0, 0, Width - 1, Height - 1))
        End Using

        Using Fore As New SolidBrush(ForeColor)
            e.Graphics.DrawString(Text, Font, Fore, New Point(4, 4))
        End Using

        MyBase.OnPaint(e)

    End Sub

End Class

Public Class AnimaExperimentalControlBox
    Inherits Control

    Public Property TextHeight As Integer = 4

    Public Property ComboHeight As Integer = 24

    Public Property Items As String()

    Public Property SelectedIndex As Integer = 0

    Public Property ItemSize As Integer = 24

    Public Property SelectedItem As String

    Public Property AnimaGroupBoxContainer As AnimaGroupBox

    Public Property CurrentLocation As Point

    Public Event SelectedIndexChanged()

    Private Open As Boolean
    Private ItemsHeight As Integer = 0
    Private Hover As Integer = -1

    Sub New()
        DoubleBuffered = True
        Font = New Font("Segoe UI", 9)
        ForeColor = Color.FromArgb(200, 200, 200)
    End Sub

    Protected Overrides Sub OnPaint(e As PaintEventArgs)

        e.Graphics.Clear(Parent.BackColor)

        If Enabled Then

            If Not IsNothing(Items) Then
                ItemsHeight = Items.Count * ItemSize
            End If

            If Not DesignMode Then
                If Open Then
                    Height = ItemsHeight + ComboHeight + 5
                Else
                    Height = ComboHeight + 1
                End If
            End If

            Using Background As New SolidBrush(Color.FromArgb(55, 55, 58)), Border As New Pen(Color.FromArgb(42, 42, 45)), Shadow As New Pen(Color.FromArgb(66, 66, 69))
                e.Graphics.FillRectangle(Background, New Rectangle(0, 0, Width - 1, ComboHeight - 1))
                e.Graphics.DrawRectangle(Border, New Rectangle(0, 0, Width - 1, ComboHeight - 1))
                e.Graphics.DrawRectangle(Shadow, New Rectangle(1, 1, Width - 3, ComboHeight - 3))
            End Using

            If IsNothing(Items) Then
                SelectedIndex = -1

            ElseIf Not SelectedIndex = -1 Then

                Using Fore As New SolidBrush(ForeColor)
                    e.Graphics.DrawString(Items(SelectedIndex), Font, Fore, New Point(4, 4))
                End Using

            End If

            If Open Then

                Using Background As New SolidBrush(Color.FromArgb(60, 60, 63)), Border As New Pen(Color.FromArgb(41, 130, 232))
                    e.Graphics.FillRectangle(Background, New Rectangle(1, ComboHeight, Width - 3, ItemsHeight))
                    e.Graphics.DrawRectangle(Border, New Rectangle(1, ComboHeight, Width - 3, ItemsHeight))
                End Using

                If Not Hover = -1 Then

                    Using Background As New SolidBrush(Color.FromArgb(41, 130, 232)), Border As New Pen(Color.FromArgb(40, 40, 40))
                        e.Graphics.FillRectangle(Background, New Rectangle(1, ComboHeight + Hover * ItemSize, Width - 2, ItemSize))
                        e.Graphics.DrawLine(Border, 1, ComboHeight + Hover * ItemSize + ItemSize, Width - 2, ComboHeight + Hover * ItemSize + ItemSize)
                    End Using

                End If

                For I = 0 To Items.Count - 1

                    If Hover = I Then

                        Using Fore As New SolidBrush(Color.FromArgb(15, 15, 15))
                            e.Graphics.DrawString(Items(I), Font, Fore, New Point(4, ComboHeight + TextHeight + I * ItemSize))
                        End Using

                    Else

                        Using Fore As New SolidBrush(ForeColor)
                            e.Graphics.DrawString(Items(I), Font, Fore, New Point(4, ComboHeight + TextHeight + I * ItemSize))
                        End Using

                    End If

                Next

            End If

        Else
            Using Background As New SolidBrush(Color.FromArgb(50, 50, 53)), Border As New Pen(Color.FromArgb(42, 42, 45)), Shadow As New Pen(Color.FromArgb(66, 66, 69))
                e.Graphics.FillRectangle(Background, New Rectangle(0, 0, Width - 1, ComboHeight - 1))
                e.Graphics.DrawRectangle(Border, New Rectangle(0, 0, Width - 1, ComboHeight - 1))
                e.Graphics.DrawRectangle(Shadow, New Rectangle(1, 1, Width - 3, ComboHeight - 3))
            End Using

            If Not IsNothing(Items) AndAlso Not SelectedIndex = -1 Then

                Using Fore As New SolidBrush(Color.FromArgb(140, 140, 140))
                    e.Graphics.DrawString(Items(SelectedIndex), Font, Fore, New Point(4, 4))
                End Using

            End If

        End If

        MyBase.OnPaint(e)
    End Sub

    Protected Overrides Sub OnLostFocus(e As EventArgs)
        Open = False : Invalidate()
        MyBase.OnLostFocus(e)
    End Sub

    Protected Overrides Sub OnMouseDown(e As MouseEventArgs)

        '  If Not Open Then Main.BTab1.SendToBack() : Else : BringToFront()

        If Open AndAlso Not ItemsHeight = 0 Then

            For I = 0 To Items.Count - 1

                If New Rectangle(0, ComboHeight + I * ItemSize, Width - 1, ItemSize).Contains(e.Location) Then
                    SelectedIndex = I : Invalidate()
                    SelectedItem = Items(SelectedIndex)
                    Exit For
                End If

            Next

        End If

        If Not New Rectangle(0, 0, Width - 1, ComboHeight + 4).Contains(e.Location) Then
            If Open AndAlso Not SelectedIndex = -1 Then RaiseEvent SelectedIndexChanged()
        End If

        Open = Not Open : Invalidate()
        Me.Select()
        MyBase.OnMouseDown(e)
    End Sub

    Protected Overrides Sub OnMouseMove(e As MouseEventArgs)

        If Open AndAlso Not ItemsHeight = 0 Then

            For I = 0 To Items.Count - 1

                If New Rectangle(0, ComboHeight + I * ItemSize, Width - 1, ItemSize).Contains(e.Location) Then
                    Hover = I : Invalidate()
                    Exit For
                End If

            Next

        End If

        MyBase.OnMouseMove(e)
    End Sub

End Class