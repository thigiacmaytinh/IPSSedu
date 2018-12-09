<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDangnhap
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmDangnhap))
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtPass = New System.Windows.Forms.TextBox()
        Me.txtUser = New System.Windows.Forms.TextBox()
        Me.btnQuenmatkhau = New System.Windows.Forms.Button()
        Me.btnChonDB = New System.Windows.Forms.Button()
        Me.btnDangnhap = New System.Windows.Forms.Button()
        Me.lbl_ktketnoi = New System.Windows.Forms.Label()
        Me.bwGuimail = New System.ComponentModel.BackgroundWorker()
        Me.bwKTthongso = New System.ComponentModel.BackgroundWorker()
        Me.bwInitModel = New System.ComponentModel.BackgroundWorker()
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.btnGuipass = New System.Windows.Forms.Button()
        Me.txtEmail = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.ProgressBar2 = New System.Windows.Forms.ProgressBar()
        Me.lblEmail = New System.Windows.Forms.Label()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.GroupBox2.SuspendLayout()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.ProgressBar1)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.txtPass)
        Me.GroupBox2.Controls.Add(Me.txtUser)
        Me.GroupBox2.Controls.Add(Me.btnQuenmatkhau)
        Me.GroupBox2.Controls.Add(Me.btnChonDB)
        Me.GroupBox2.Controls.Add(Me.btnDangnhap)
        Me.GroupBox2.Controls.Add(Me.lbl_ktketnoi)
        Me.GroupBox2.Location = New System.Drawing.Point(9, 7)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(427, 167)
        Me.GroupBox2.TabIndex = 15
        Me.GroupBox2.TabStop = False
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(17, 132)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(124, 23)
        Me.ProgressBar1.Style = System.Windows.Forms.ProgressBarStyle.Continuous
        Me.ProgressBar1.TabIndex = 24
        Me.ProgressBar1.Visible = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Blue
        Me.Label2.Location = New System.Drawing.Point(50, 61)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(73, 19)
        Me.Label2.TabIndex = 20
        Me.Label2.Text = "Mật khẩu"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Blue
        Me.Label1.Location = New System.Drawing.Point(48, 29)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(116, 19)
        Me.Label1.TabIndex = 19
        Me.Label1.Text = "Tên đăng nhập"
        '
        'txtPass
        '
        Me.txtPass.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPass.Location = New System.Drawing.Point(204, 61)
        Me.txtPass.Name = "txtPass"
        Me.txtPass.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPass.Size = New System.Drawing.Size(151, 23)
        Me.txtPass.TabIndex = 18
        '
        'txtUser
        '
        Me.txtUser.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUser.Location = New System.Drawing.Point(204, 29)
        Me.txtUser.Name = "txtUser"
        Me.txtUser.Size = New System.Drawing.Size(151, 23)
        Me.txtUser.TabIndex = 17
        '
        'btnQuenmatkhau
        '
        Me.btnQuenmatkhau.Enabled = False
        Me.btnQuenmatkhau.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnQuenmatkhau.ForeColor = System.Drawing.Color.Blue
        Me.btnQuenmatkhau.Location = New System.Drawing.Point(278, 87)
        Me.btnQuenmatkhau.Name = "btnQuenmatkhau"
        Me.btnQuenmatkhau.Size = New System.Drawing.Size(127, 34)
        Me.btnQuenmatkhau.TabIndex = 16
        Me.btnQuenmatkhau.Text = "Quên mật khẩu"
        Me.btnQuenmatkhau.UseVisualStyleBackColor = True
        '
        'btnChonDB
        '
        Me.btnChonDB.Enabled = False
        Me.btnChonDB.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnChonDB.ForeColor = System.Drawing.Color.Blue
        Me.btnChonDB.Location = New System.Drawing.Point(17, 87)
        Me.btnChonDB.Name = "btnChonDB"
        Me.btnChonDB.Size = New System.Drawing.Size(111, 34)
        Me.btnChonDB.TabIndex = 15
        Me.btnChonDB.Text = "Chọn CSDL"
        Me.btnChonDB.UseVisualStyleBackColor = True
        '
        'btnDangnhap
        '
        Me.btnDangnhap.Enabled = False
        Me.btnDangnhap.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDangnhap.ForeColor = System.Drawing.Color.Blue
        Me.btnDangnhap.Location = New System.Drawing.Point(148, 87)
        Me.btnDangnhap.Name = "btnDangnhap"
        Me.btnDangnhap.Size = New System.Drawing.Size(111, 34)
        Me.btnDangnhap.TabIndex = 14
        Me.btnDangnhap.Text = "Đăng nhập"
        Me.btnDangnhap.UseVisualStyleBackColor = True
        '
        'lbl_ktketnoi
        '
        Me.lbl_ktketnoi.AutoSize = True
        Me.lbl_ktketnoi.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_ktketnoi.ForeColor = System.Drawing.Color.Red
        Me.lbl_ktketnoi.Location = New System.Drawing.Point(173, 138)
        Me.lbl_ktketnoi.Name = "lbl_ktketnoi"
        Me.lbl_ktketnoi.Size = New System.Drawing.Size(0, 17)
        Me.lbl_ktketnoi.TabIndex = 13
        '
        'bwGuimail
        '
        '
        'bwKTthongso
        '
        '
        'bwInitModel
        '
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'btnGuipass
        '
        Me.btnGuipass.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGuipass.ForeColor = System.Drawing.Color.Blue
        Me.btnGuipass.Location = New System.Drawing.Point(130, 44)
        Me.btnGuipass.Name = "btnGuipass"
        Me.btnGuipass.Size = New System.Drawing.Size(166, 34)
        Me.btnGuipass.TabIndex = 16
        Me.btnGuipass.Text = "Phục hồi mật khẩu"
        Me.btnGuipass.UseVisualStyleBackColor = True
        '
        'txtEmail
        '
        Me.txtEmail.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEmail.Location = New System.Drawing.Point(130, 18)
        Me.txtEmail.Name = "txtEmail"
        Me.txtEmail.Size = New System.Drawing.Size(225, 23)
        Me.txtEmail.TabIndex = 19
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Blue
        Me.Label3.Location = New System.Drawing.Point(13, 22)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(89, 19)
        Me.Label3.TabIndex = 21
        Me.Label3.Text = "Nhập email"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.ProgressBar2)
        Me.GroupBox1.Controls.Add(Me.lblEmail)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.txtEmail)
        Me.GroupBox1.Controls.Add(Me.btnGuipass)
        Me.GroupBox1.Location = New System.Drawing.Point(9, 179)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(427, 117)
        Me.GroupBox1.TabIndex = 14
        Me.GroupBox1.TabStop = False
        '
        'ProgressBar2
        '
        Me.ProgressBar2.Location = New System.Drawing.Point(17, 84)
        Me.ProgressBar2.Name = "ProgressBar2"
        Me.ProgressBar2.Size = New System.Drawing.Size(124, 23)
        Me.ProgressBar2.TabIndex = 23
        Me.ProgressBar2.Visible = False
        '
        'lblEmail
        '
        Me.lblEmail.AutoSize = True
        Me.lblEmail.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEmail.ForeColor = System.Drawing.Color.Red
        Me.lblEmail.Location = New System.Drawing.Point(158, 90)
        Me.lblEmail.Name = "lblEmail"
        Me.lblEmail.Size = New System.Drawing.Size(0, 19)
        Me.lblEmail.TabIndex = 22
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        Me.Timer1.Interval = 30
        '
        'frmDangnhap
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.ClientSize = New System.Drawing.Size(444, 177)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximumSize = New System.Drawing.Size(460, 342)
        Me.MinimumSize = New System.Drawing.Size(460, 215)
        Me.Name = "frmDangnhap"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Đăng nhập"
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents bwGuimail As System.ComponentModel.BackgroundWorker
    Friend WithEvents bwKTthongso As System.ComponentModel.BackgroundWorker
    Friend WithEvents lbl_ktketnoi As System.Windows.Forms.Label
    Friend WithEvents bwInitModel As System.ComponentModel.BackgroundWorker
    Friend WithEvents btnQuenmatkhau As System.Windows.Forms.Button
    Friend WithEvents btnChonDB As System.Windows.Forms.Button
    Friend WithEvents btnDangnhap As System.Windows.Forms.Button
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents txtPass As System.Windows.Forms.TextBox
    Friend WithEvents txtUser As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtEmail As System.Windows.Forms.TextBox
    Friend WithEvents btnGuipass As System.Windows.Forms.Button
    Friend WithEvents lblEmail As System.Windows.Forms.Label
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
    Friend WithEvents ProgressBar2 As System.Windows.Forms.ProgressBar

End Class
