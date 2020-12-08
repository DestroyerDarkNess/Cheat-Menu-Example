Imports System.IO
Imports CheatMenuSample.Core.Values

Public Class Loader

    Private Sub Loader_Load(sender As Object, e As EventArgs) Handles MyBase.Load
       
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Dim Gproc As Process() = Process.GetProcessesByName(Path.GetFileNameWithoutExtension(ProcessGame))
        If Not Gproc.Count = 0 Then
            Form1.Show()
            Me.Hide()
            Timer1.Enabled = False
        End If
    End Sub

    Private Sub GunaAdvenceButton3_Click(sender As Object, e As EventArgs) Handles GunaAdvenceButton3.Click
        Dim Usertext As String = UserTextbox.Text
        Dim Passtext As String = PasswordTextbox.Text
        If Usertext = "Username" Then
            If Passtext = "Password" Then
                GunaAdvenceButton3.Visible = False
                GunaWinCircleProgressIndicator1.Visible = True
                StatusLabel.Text = "Waiting For Game ..."
                StatusLabel.ForeColor = Color.White
                Timer1.Enabled = True
            Else
                StatusLabel.Text = "User or Password Incorred!"
            End If
        End If
    End Sub

End Class