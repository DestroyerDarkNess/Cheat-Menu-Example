Imports System.Runtime.InteropServices
Imports System.Net.Mail
Imports System.Text
Imports System.Runtime.ConstrainedExecution
Imports System.Security
Imports System.ComponentModel
Imports System.Windows.Forms
Imports System.Drawing

Public Class Overlay : Implements IDisposable

#Region " P/Invokes "

    <DllImport("user32.dll")> _
    Public Shared Function GetWindowRect(ByVal hWnd As IntPtr, ByRef lpRect As RECT) As Boolean
    End Function

    <DllImport("user32.dll", SetLastError:=True)> _
    Private Shared Function GetForegroundWindow() As IntPtr
    End Function

    <DllImport("user32.dll", SetLastError:=True, CharSet:=CharSet.Auto)> _
    Private Shared Function FindWindow( _
     ByVal lpClassName As String, _
     ByVal lpWindowName As String) As IntPtr
    End Function

    <DllImport("user32.dll", SetLastError:=True)> _
    Private Shared Function GetWindowThreadProcessId(ByVal hwnd As IntPtr, _
                          ByRef lpdwProcessId As Integer) As Integer
    End Function

#End Region

#Region " IDisposable Implementation "

    ''' ----------------------------------------------------------------------------------------------------
    ''' <summary>
    ''' Flag to detect redundant calls when disposing.
    ''' </summary>
    ''' ----------------------------------------------------------------------------------------------------
    Private isDisposed As Boolean = False

    ''' ----------------------------------------------------------------------------------------------------
    ''' <summary>
    ''' Releases all the resources used by this instance.
    ''' </summary>
    ''' ----------------------------------------------------------------------------------------------------
    <DebuggerStepThrough>
    Public Sub Dispose() Implements IDisposable.Dispose
        Finalize()
        GC.SuppressFinalize(Me)
    End Sub

    ''' ----------------------------------------------------------------------------------------------------
    ''' <summary>
    ''' Allows an object to try to free resources and perform other cleanup operations before it is reclaimed by garbage collection.
    ''' </summary>
    ''' ----------------------------------------------------------------------------------------------------
    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

#End Region

#Region " Properties "

    Public Property Monitor As Boolean
        Get
            Return TimerShowHideMenu.Enabled
        End Get
        Set(value As Boolean)
            TimerShowHideMenu.Enabled = value
        End Set
    End Property

    Private Shared GameWindowsTitle As String = String.Empty
    Public ReadOnly Property GetWindowsTitle As String
        Get
            Return GameWindowsTitle
        End Get
    End Property

    Private Shared GameLocation As Point = Nothing
    Public ReadOnly Property GetGameLocation As Point
        Get
            Return GameLocation
        End Get
    End Property

    Private Shared GameSize As Size = Nothing
    Public ReadOnly Property GetGameSize As Size
        Get
            Return GameSize
        End Get
    End Property

#End Region

#Region " Structures "

    Public Structure RECT
        Public Left As Integer
        Public Top As Integer
        Public Right As Integer
        Public Bottom As Integer
    End Structure

#End Region

#Region " Declare's "

    Private Shared TimerShowHideMenu As System.Windows.Forms.Timer = New System.Windows.Forms.Timer() With {.Interval = 1}

    Public window_loc As RECT

    Public hWnd As IntPtr = Nothing
    Public processID As Integer = Nothing
    Private ProcessName As String = String.Empty

    Private MyAppProcess As String = Process.GetCurrentProcess().ProcessName
    Private FormManagement As Form = Nothing

#End Region

#Region " Public Methods "

    Public Sub New(ByVal ProcName As String, Optional ByVal FormC As Form = Nothing)
        ProcessName = ProcName
        FormManagement = FormC
        If ProcessName.ToLower.EndsWith(".exe") Then ProcessName = ProcessName.Substring(0, ProcessName.Length - 4)
        StartMonitor()
    End Sub

#End Region

#Region " Private Methods "

    Private Sub StartMonitor()
        AddHandler TimerShowHideMenu.Tick, New System.EventHandler(AddressOf TimerShowHideMenu_Tick)
        Dim proc() As Process = Process.GetProcessesByName(ProcessName)
        If Not proc.Length = 0 Then
            Dim windowname As String = proc(0).MainWindowTitle
            GameWindowsTitle = windowname

            hWnd = FindWindow(vbNullString, windowname)

            GetWindowThreadProcessId(hWnd, processID)

            If hWnd = 0 Then Exit Sub
            TimerShowHideMenu.Enabled = True

        End If
    End Sub

    Private Sub TimerShowHideMenu_Tick(ByVal sender As Object, ByVal e As EventArgs)
        On Error Resume Next

        If IsGameAppFocus() = True Then

            GetWindowRect(hWnd, window_loc)

            GameLocation = New Point((window_loc.Left + 9), (window_loc.Top + 30))

            GameSize = New Point(((window_loc.Right - window_loc.Left) - 17), ((window_loc.Bottom - window_loc.Top) - 38))

            If Not (FormManagement Is Nothing) Then

                If FormManagement.Visible = True Then

                    FormManagement.Location = GameLocation
                    FormManagement.Size = GameSize

                End If

            End If
        Else

            If FormManagement.Visible = True Then

                FormManagement.Hide()

            End If

        End If

    End Sub

    Private Function IsGameAppFocus() As Boolean
        Dim ActiveProcess As Process = GetActiveProcess()
        Dim IsFocusGame As Boolean = False
        If ActiveProcess IsNot Nothing Then
            Dim CurrentProcName As String = ActiveProcess.ProcessName

            If LCase(CurrentProcName) = LCase(MyAppProcess) Then
                IsFocusGame = True
            End If

            If LCase(CurrentProcName) = LCase(ProcessName) Then
                IsFocusGame = True
            End If


            Return IsFocusGame

        End If

        Return IsFocusGame
    End Function

    Private Function GetActiveProcess() As Process
        Dim FocusedWindow As IntPtr = GetForegroundWindow()
        If FocusedWindow = IntPtr.Zero Then Return Nothing

        Dim FocusedWindowProcessId As UInteger = 0
        GetWindowThreadProcessId(FocusedWindow, FocusedWindowProcessId)

        If FocusedWindowProcessId = 0 Then Return Nothing
        Return Process.GetProcessById(CType(FocusedWindowProcessId, Integer))
    End Function

#End Region

End Class
