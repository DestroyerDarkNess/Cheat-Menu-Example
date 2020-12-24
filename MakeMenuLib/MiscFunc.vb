Imports System.Windows.Forms

Public Class MiscFunc


    Private Shared Dragger As ControlDragger = ControlDragger.Empty

    Public Shared Sub InitializeDrag(ByVal ControlEx As Control, ByVal cParentControl As Control)
        '----------------------------------------------------
        'PanelFX1 Moving | Main Cheats
        '----------------------------------------------------
        Dragger = New ControlDragger(cParentControl)
        Dragger = New ControlDragger(ControlEx, cParentControl)

        Dragger.Enabled = True
    End Sub

    Public Shared Function GetLocalDate() As String
        Return My.Computer.Clock.LocalTime.ToString.Split(" ").First
    End Function

    Public Shared Function GetLocalTime() As String
        Return My.Computer.Clock.LocalTime.ToString.Split(" ").Last
    End Function

End Class
