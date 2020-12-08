Imports System.Runtime.InteropServices
Imports CheatMenuSample.Core.Values
Imports System.IO

Public Class Form1

#Region " Pinvokes "

    <DllImport("user32.dll")> _
    Public Shared Function GetAsyncKeyState(ByVal vKey As System.Windows.Forms.Keys) As Short
    End Function

    <DllImport("user32.dll", CharSet:=CharSet.Auto, ExactSpelling:=True)> _
    Public Shared Function ShowCursor(ByVal bShow As Boolean) As Integer
    End Function

#End Region

#Region " No Windows Focus "

    Protected Overrides ReadOnly Property ShowWithoutActivation As Boolean
        Get
            Return True
        End Get
    End Property

    Private Const WS_EX_TOPMOST As Integer = &H8

    Private Const WS_THICKFRAME As Integer = &H40000
    Private Const WS_CHILD As Integer = &H40000000
    Private Const WS_EX_NOACTIVATE As Integer = &H8000000
    Private Const WS_EX_TOOLWINDOW As Integer = &H80

    Protected Overrides ReadOnly Property CreateParams As CreateParams
        Get
            Dim createParamsA As CreateParams = MyBase.CreateParams
            createParamsA.ExStyle = createParamsA.ExStyle Or WS_EX_TOPMOST Or WS_EX_NOACTIVATE Or WS_EX_TOOLWINDOW
            Return createParamsA
        End Get
    End Property

#End Region

#Region " Declares "

    Private AttachClienGame As New Overlay(ProcessGame, Me)
    Private VisibleMenu As Boolean = False
    Private KeyShowMenu As Keys = Keys.Insert
    Private UserName As String = Environment.UserName

#End Region

    Private Sub Form1_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Me.Hide()
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.LogTextBox.BackColor = Color.FromArgb(40, Color.FromArgb(25, 25, 25))
        ManagementMenu()
        Me.InitializeDrag()
        WriteLog("Cheat Menu Example [Versión 1.0.0]", False)
        WriteLog("Welcome " & UserName & ", I enjoy the Cheat!")
    End Sub

#Region " ToolStripMenu "

    Private Sub UnloadToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UnloadToolStripMenuItem.Click
        End
    End Sub

#End Region

#Region " Show Or Hide Menu "

    Private Shared TimerShowHideMenu As System.Windows.Forms.Timer = New System.Windows.Forms.Timer() With {.Enabled = True, _
                                                                                                            .Interval = 50}

    Private Sub ManagementMenu()
        AddHandler TimerShowHideMenu.Tick, New System.EventHandler(AddressOf TimerShowHideMenu_Tick)
    End Sub

    Private Sub TimerShowHideMenu_Tick(ByVal sender As Object, ByVal e As EventArgs)
        If GetAsyncKeyState(KeyShowMenu) = Int16.MinValue Then
            If VisibleMenu = False Then
                ShowMenu(True)
                Exit Sub
            End If
            If VisibleMenu = True Then
                ShowMenu(False)
                Exit Sub
            End If
        End If
        Dim GameProcess As Process() = Process.GetProcessesByName(Path.GetFileNameWithoutExtension(ProcessGame))
        If GameProcess.Count = 0 Then
            Me.Close()
        End If
    End Sub

    Private Sub ShowMenu(ByVal ShowOrHide As Boolean)
        Me.TopMost = ShowOrHide
        VisibleMenu = ShowOrHide
        ShowCursor(ShowOrHide)
        If ShowOrHide = True Then
            Me.Show()
        Else
            Me.Hide()
        End If
    End Sub

#End Region

#Region " Dragger - Minimize "

    Private Dragger As ControlDragger = ControlDragger.Empty

    Private Sub InitializeDrag()
        '----------------------------------------------------
        'PanelFX1 Moving | Main Cheats
        '----------------------------------------------------
        Me.Dragger = New ControlDragger(PanelFX1)
        Me.Dragger = New ControlDragger(PanelFX2, PanelFX1)
        Me.Dragger = New ControlDragger(GunaLabel1, PanelFX1)
        Me.Dragger = New ControlDragger(GunaPanel2, PanelFX1)
        Me.Dragger = New ControlDragger(GunaSeparator1, PanelFX1)
        Me.Dragger = New ControlDragger(Panel1, PanelFX1)

        '----------------------------------------------------
        'PanelFX2 Moving | LOG
        '----------------------------------------------------
        Me.Dragger = New ControlDragger(PanelFX3)
        Me.Dragger = New ControlDragger(Panel2, PanelFX3)
        Me.Dragger = New ControlDragger(GunaPanel1, PanelFX3)
        Me.Dragger = New ControlDragger(GunaLabel18, PanelFX1)
        Me.Dragger = New ControlDragger(LogTextBox, PanelFX3)




        Me.Dragger.Enabled = True
    End Sub

#End Region

#Region " Log System "

    Public Enum InfoType
        Information
        Exception
        Critical
        None
    End Enum

    Public Sub WriteLog(ByVal Message As String, Optional Prefix As Boolean = True, Optional ByVal InfoType As InfoType = Form1.InfoType.None)

        Dim LocalDate As String = My.Computer.Clock.LocalTime.ToString.Split(" ").First
        Dim LocalTime As String = My.Computer.Clock.LocalTime.ToString.Split(" ").Last
        Dim LogDate As String = " [ " & LocalTime & " ]  "
        Dim MessageType As String = String.Empty

        Select Case InfoType
            Case InfoType.Information : MessageType = "Information: "
            Case InfoType.Exception : MessageType = "Error: "
            Case InfoType.Critical : MessageType = "Critical: "
            Case InfoType.None : MessageType = ""
        End Select

        If Prefix = True Then
            LogTextBox.Text += ".\\" & UserName & ">" & LogDate & MessageType & Message & vbNewLine
        Else
            LogTextBox.Text += MessageType & Message & vbNewLine
        End If

        If (LogTextBox.Text.Split(vbNewLine).Count - 1) >= 12 Then
            LogTextBox.ScrollBars = ScrollBars.Vertical
            LogTextBox.SelectionStart = Val(LogTextBox.Text.Length)
            LogTextBox.ScrollToCaret()
        End If

    End Sub

    Public Sub ClearLog()
        LogTextBox.Text = ""
    End Sub

#End Region

#Region " Cheats "

    Private Sub CrewCheats()






    End Sub

#End Region

End Class
