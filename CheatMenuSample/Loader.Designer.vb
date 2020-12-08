<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Loader
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Loader))
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.StatusLabel = New Guna.UI.WinForms.GunaLabel()
        Me.GunaLabel3 = New Guna.UI.WinForms.GunaLabel()
        Me.GunaAdvenceButton3 = New Guna.UI.WinForms.GunaAdvenceButton()
        Me.PasswordTextbox = New Guna.UI.WinForms.GunaTextBox()
        Me.UserTextbox = New Guna.UI.WinForms.GunaTextBox()
        Me.GunaLabel5 = New Guna.UI.WinForms.GunaLabel()
        Me.GunaLabel6 = New Guna.UI.WinForms.GunaLabel()
        Me.GunaPanel1 = New Guna.UI.WinForms.GunaPanel()
        Me.GunaLabel18 = New Guna.UI.WinForms.GunaLabel()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.GunaDragControl1 = New Guna.UI.WinForms.GunaDragControl(Me.components)
        Me.GunaDragControl2 = New Guna.UI.WinForms.GunaDragControl(Me.components)
        Me.GunaDragControl3 = New Guna.UI.WinForms.GunaDragControl(Me.components)
        Me.GunaWinCircleProgressIndicator1 = New Guna.UI.WinForms.GunaWinCircleProgressIndicator()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.GunaPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(14, Byte), Integer), CType(CType(14, Byte), Integer), CType(CType(14, Byte), Integer))
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.Panel3)
        Me.Panel2.Controls.Add(Me.GunaPanel1)
        Me.Panel2.Location = New System.Drawing.Point(9, 11)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(364, 193)
        Me.Panel2.TabIndex = 4
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.GunaWinCircleProgressIndicator1)
        Me.Panel3.Controls.Add(Me.StatusLabel)
        Me.Panel3.Controls.Add(Me.GunaLabel3)
        Me.Panel3.Controls.Add(Me.GunaAdvenceButton3)
        Me.Panel3.Controls.Add(Me.PasswordTextbox)
        Me.Panel3.Controls.Add(Me.UserTextbox)
        Me.Panel3.Controls.Add(Me.GunaLabel5)
        Me.Panel3.Controls.Add(Me.GunaLabel6)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(0, 19)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(362, 172)
        Me.Panel3.TabIndex = 4
        '
        'StatusLabel
        '
        Me.StatusLabel.AutoSize = True
        Me.StatusLabel.BackColor = System.Drawing.Color.Transparent
        Me.StatusLabel.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.StatusLabel.ForeColor = System.Drawing.Color.DarkGray
        Me.StatusLabel.Location = New System.Drawing.Point(73, 144)
        Me.StatusLabel.Name = "StatusLabel"
        Me.StatusLabel.Size = New System.Drawing.Size(119, 13)
        Me.StatusLabel.TabIndex = 34
        Me.StatusLabel.Text = "Waiting For Loggin ..."
        '
        'GunaLabel3
        '
        Me.GunaLabel3.AutoSize = True
        Me.GunaLabel3.BackColor = System.Drawing.Color.Transparent
        Me.GunaLabel3.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaLabel3.ForeColor = System.Drawing.Color.White
        Me.GunaLabel3.Location = New System.Drawing.Point(14, 144)
        Me.GunaLabel3.Name = "GunaLabel3"
        Me.GunaLabel3.Size = New System.Drawing.Size(42, 13)
        Me.GunaLabel3.TabIndex = 33
        Me.GunaLabel3.Text = "Status:"
        '
        'GunaAdvenceButton3
        '
        Me.GunaAdvenceButton3.AnimationHoverSpeed = 0.07!
        Me.GunaAdvenceButton3.AnimationSpeed = 0.03!
        Me.GunaAdvenceButton3.BaseColor = System.Drawing.Color.Red
        Me.GunaAdvenceButton3.BorderColor = System.Drawing.Color.Black
        Me.GunaAdvenceButton3.CheckedBaseColor = System.Drawing.Color.Gray
        Me.GunaAdvenceButton3.CheckedBorderColor = System.Drawing.Color.Black
        Me.GunaAdvenceButton3.CheckedForeColor = System.Drawing.Color.White
        Me.GunaAdvenceButton3.CheckedImage = CType(resources.GetObject("GunaAdvenceButton3.CheckedImage"), System.Drawing.Image)
        Me.GunaAdvenceButton3.CheckedLineColor = System.Drawing.Color.DimGray
        Me.GunaAdvenceButton3.DialogResult = System.Windows.Forms.DialogResult.None
        Me.GunaAdvenceButton3.FocusedColor = System.Drawing.Color.Empty
        Me.GunaAdvenceButton3.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaAdvenceButton3.ForeColor = System.Drawing.Color.White
        Me.GunaAdvenceButton3.Image = Nothing
        Me.GunaAdvenceButton3.ImageAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.GunaAdvenceButton3.ImageSize = New System.Drawing.Size(20, 20)
        Me.GunaAdvenceButton3.LineColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(100, Byte), Integer))
        Me.GunaAdvenceButton3.Location = New System.Drawing.Point(176, 95)
        Me.GunaAdvenceButton3.Name = "GunaAdvenceButton3"
        Me.GunaAdvenceButton3.OnHoverBaseColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.GunaAdvenceButton3.OnHoverBorderColor = System.Drawing.Color.Black
        Me.GunaAdvenceButton3.OnHoverForeColor = System.Drawing.Color.White
        Me.GunaAdvenceButton3.OnHoverImage = Nothing
        Me.GunaAdvenceButton3.OnHoverLineColor = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(58, Byte), Integer), CType(CType(170, Byte), Integer))
        Me.GunaAdvenceButton3.OnPressedColor = System.Drawing.Color.Black
        Me.GunaAdvenceButton3.Size = New System.Drawing.Size(144, 33)
        Me.GunaAdvenceButton3.TabIndex = 34
        Me.GunaAdvenceButton3.Text = "Log In"
        Me.GunaAdvenceButton3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'PasswordTextbox
        '
        Me.PasswordTextbox.BaseColor = System.Drawing.Color.FromArgb(CType(CType(14, Byte), Integer), CType(CType(14, Byte), Integer), CType(CType(14, Byte), Integer))
        Me.PasswordTextbox.BorderColor = System.Drawing.Color.Red
        Me.PasswordTextbox.BorderSize = 1
        Me.PasswordTextbox.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.PasswordTextbox.FocusedBaseColor = System.Drawing.Color.FromArgb(CType(CType(14, Byte), Integer), CType(CType(14, Byte), Integer), CType(CType(14, Byte), Integer))
        Me.PasswordTextbox.FocusedBorderColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(100, Byte), Integer))
        Me.PasswordTextbox.FocusedForeColor = System.Drawing.Color.White
        Me.PasswordTextbox.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.PasswordTextbox.ForeColor = System.Drawing.Color.White
        Me.PasswordTextbox.Location = New System.Drawing.Point(89, 54)
        Me.PasswordTextbox.Name = "PasswordTextbox"
        Me.PasswordTextbox.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.PasswordTextbox.Size = New System.Drawing.Size(231, 26)
        Me.PasswordTextbox.TabIndex = 33
        Me.PasswordTextbox.Text = "Password"
        Me.PasswordTextbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'UserTextbox
        '
        Me.UserTextbox.BaseColor = System.Drawing.Color.FromArgb(CType(CType(14, Byte), Integer), CType(CType(14, Byte), Integer), CType(CType(14, Byte), Integer))
        Me.UserTextbox.BorderColor = System.Drawing.Color.Red
        Me.UserTextbox.BorderSize = 1
        Me.UserTextbox.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.UserTextbox.FocusedBaseColor = System.Drawing.Color.FromArgb(CType(CType(14, Byte), Integer), CType(CType(14, Byte), Integer), CType(CType(14, Byte), Integer))
        Me.UserTextbox.FocusedBorderColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(100, Byte), Integer))
        Me.UserTextbox.FocusedForeColor = System.Drawing.Color.White
        Me.UserTextbox.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.UserTextbox.ForeColor = System.Drawing.Color.White
        Me.UserTextbox.Location = New System.Drawing.Point(89, 20)
        Me.UserTextbox.Name = "UserTextbox"
        Me.UserTextbox.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.UserTextbox.Size = New System.Drawing.Size(231, 26)
        Me.UserTextbox.TabIndex = 32
        Me.UserTextbox.Text = "Username"
        Me.UserTextbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'GunaLabel5
        '
        Me.GunaLabel5.AutoSize = True
        Me.GunaLabel5.BackColor = System.Drawing.Color.Transparent
        Me.GunaLabel5.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaLabel5.ForeColor = System.Drawing.Color.White
        Me.GunaLabel5.Location = New System.Drawing.Point(16, 58)
        Me.GunaLabel5.Name = "GunaLabel5"
        Me.GunaLabel5.Size = New System.Drawing.Size(64, 17)
        Me.GunaLabel5.TabIndex = 31
        Me.GunaLabel5.Text = "Password"
        '
        'GunaLabel6
        '
        Me.GunaLabel6.AutoSize = True
        Me.GunaLabel6.BackColor = System.Drawing.Color.Transparent
        Me.GunaLabel6.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaLabel6.ForeColor = System.Drawing.Color.White
        Me.GunaLabel6.Location = New System.Drawing.Point(16, 24)
        Me.GunaLabel6.Name = "GunaLabel6"
        Me.GunaLabel6.Size = New System.Drawing.Size(67, 17)
        Me.GunaLabel6.TabIndex = 30
        Me.GunaLabel6.Text = "Username"
        '
        'GunaPanel1
        '
        Me.GunaPanel1.BackColor = System.Drawing.Color.Red
        Me.GunaPanel1.Controls.Add(Me.GunaLabel18)
        Me.GunaPanel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GunaPanel1.Location = New System.Drawing.Point(0, 0)
        Me.GunaPanel1.Name = "GunaPanel1"
        Me.GunaPanel1.Size = New System.Drawing.Size(362, 19)
        Me.GunaPanel1.TabIndex = 0
        '
        'GunaLabel18
        '
        Me.GunaLabel18.AutoSize = True
        Me.GunaLabel18.BackColor = System.Drawing.Color.Transparent
        Me.GunaLabel18.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaLabel18.ForeColor = System.Drawing.Color.White
        Me.GunaLabel18.Location = New System.Drawing.Point(2, 3)
        Me.GunaLabel18.Name = "GunaLabel18"
        Me.GunaLabel18.Size = New System.Drawing.Size(146, 13)
        Me.GunaLabel18.TabIndex = 1
        Me.GunaLabel18.Text = "Cheat Menu [ Loader - VIP ]"
        '
        'Timer1
        '
        '
        'GunaDragControl1
        '
        Me.GunaDragControl1.TargetControl = Me.GunaPanel1
        '
        'GunaDragControl2
        '
        Me.GunaDragControl2.TargetControl = Me.Panel3
        '
        'GunaDragControl3
        '
        Me.GunaDragControl3.TargetControl = Me.GunaLabel18
        '
        'GunaWinCircleProgressIndicator1
        '
        Me.GunaWinCircleProgressIndicator1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.GunaWinCircleProgressIndicator1.Location = New System.Drawing.Point(198, 140)
        Me.GunaWinCircleProgressIndicator1.Name = "GunaWinCircleProgressIndicator1"
        Me.GunaWinCircleProgressIndicator1.ProgressColor = System.Drawing.Color.Red
        Me.GunaWinCircleProgressIndicator1.Size = New System.Drawing.Size(25, 24)
        Me.GunaWinCircleProgressIndicator1.TabIndex = 35
        Me.GunaWinCircleProgressIndicator1.Visible = False
        '
        'Loader
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(385, 215)
        Me.Controls.Add(Me.Panel2)
        Me.ForeColor = System.Drawing.Color.White
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "Loader"
        Me.Text = "Loader"
        Me.TransparencyKey = System.Drawing.Color.Black
        Me.Panel2.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.GunaPanel1.ResumeLayout(False)
        Me.GunaPanel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents StatusLabel As Guna.UI.WinForms.GunaLabel
    Friend WithEvents GunaLabel3 As Guna.UI.WinForms.GunaLabel
    Friend WithEvents GunaAdvenceButton3 As Guna.UI.WinForms.GunaAdvenceButton
    Friend WithEvents PasswordTextbox As Guna.UI.WinForms.GunaTextBox
    Friend WithEvents UserTextbox As Guna.UI.WinForms.GunaTextBox
    Friend WithEvents GunaLabel5 As Guna.UI.WinForms.GunaLabel
    Friend WithEvents GunaLabel6 As Guna.UI.WinForms.GunaLabel
    Friend WithEvents GunaPanel1 As Guna.UI.WinForms.GunaPanel
    Friend WithEvents GunaLabel18 As Guna.UI.WinForms.GunaLabel
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents GunaDragControl1 As Guna.UI.WinForms.GunaDragControl
    Friend WithEvents GunaDragControl2 As Guna.UI.WinForms.GunaDragControl
    Friend WithEvents GunaDragControl3 As Guna.UI.WinForms.GunaDragControl
    Friend WithEvents GunaWinCircleProgressIndicator1 As Guna.UI.WinForms.GunaWinCircleProgressIndicator
End Class
