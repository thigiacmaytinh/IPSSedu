<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDatabase
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmDatabase))
        Me.grpChuoiketnoi = New System.Windows.Forms.GroupBox()
        Me.txtChuoiKetNoi = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cbPhuongthuc = New System.Windows.Forms.ComboBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.grpThucong = New System.Windows.Forms.GroupBox()
        Me.txtDatabase = New System.Windows.Forms.TextBox()
        Me.txtPassword = New System.Windows.Forms.TextBox()
        Me.txtUsername = New System.Windows.Forms.TextBox()
        Me.txtServer = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.HelpProvider1 = New System.Windows.Forms.HelpProvider()
        Me.bwKetnoi = New System.ComponentModel.BackgroundWorker()
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.lblKetnoi = New System.Windows.Forms.Label()
        Me.btnKetnoi = New System.Windows.Forms.Button()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.grpChuoiketnoi.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.grpThucong.SuspendLayout()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grpChuoiketnoi
        '
        Me.grpChuoiketnoi.Controls.Add(Me.txtChuoiKetNoi)
        Me.grpChuoiketnoi.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpChuoiketnoi.Location = New System.Drawing.Point(0, 270)
        Me.grpChuoiketnoi.Name = "grpChuoiketnoi"
        Me.grpChuoiketnoi.Size = New System.Drawing.Size(336, 149)
        Me.grpChuoiketnoi.TabIndex = 17
        Me.grpChuoiketnoi.TabStop = False
        '
        'txtChuoiKetNoi
        '
        Me.txtChuoiKetNoi.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtChuoiKetNoi.Location = New System.Drawing.Point(3, 19)
        Me.txtChuoiKetNoi.Multiline = True
        Me.txtChuoiKetNoi.Name = "txtChuoiKetNoi"
        Me.txtChuoiKetNoi.Size = New System.Drawing.Size(330, 127)
        Me.txtChuoiKetNoi.TabIndex = 28
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(10, 117)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(65, 17)
        Me.Label4.TabIndex = 17
        Me.Label4.Text = "Database"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(7, 84)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(66, 17)
        Me.Label3.TabIndex = 14
        Me.Label3.Text = "Password"
        '
        'cbPhuongthuc
        '
        Me.cbPhuongthuc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbPhuongthuc.FormattingEnabled = True
        Me.HelpProvider1.SetHelpKeyword(Me.cbPhuongthuc, "Chọn phương thức kết nối phù hợp")
        Me.cbPhuongthuc.Items.AddRange(New Object() {"Nhập thủ công", "Nhập chuỗi kết nối", "Windows Authentication"})
        Me.cbPhuongthuc.Location = New System.Drawing.Point(21, 24)
        Me.cbPhuongthuc.Name = "cbPhuongthuc"
        Me.HelpProvider1.SetShowHelp(Me.cbPhuongthuc, True)
        Me.cbPhuongthuc.Size = New System.Drawing.Size(192, 24)
        Me.cbPhuongthuc.TabIndex = 0
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.cbPhuongthuc)
        Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(336, 60)
        Me.GroupBox2.TabIndex = 16
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Phương thức kết nối"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(7, 52)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(69, 17)
        Me.Label2.TabIndex = 13
        Me.Label2.Text = "Username"
        '
        'grpThucong
        '
        Me.grpThucong.Controls.Add(Me.txtDatabase)
        Me.grpThucong.Controls.Add(Me.txtPassword)
        Me.grpThucong.Controls.Add(Me.txtUsername)
        Me.grpThucong.Controls.Add(Me.txtServer)
        Me.grpThucong.Controls.Add(Me.Label4)
        Me.grpThucong.Controls.Add(Me.Label3)
        Me.grpThucong.Controls.Add(Me.Label2)
        Me.grpThucong.Controls.Add(Me.Label1)
        Me.grpThucong.Dock = System.Windows.Forms.DockStyle.Top
        Me.grpThucong.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpThucong.Location = New System.Drawing.Point(0, 60)
        Me.grpThucong.Name = "grpThucong"
        Me.grpThucong.Size = New System.Drawing.Size(336, 154)
        Me.grpThucong.TabIndex = 15
        Me.grpThucong.TabStop = False
        Me.grpThucong.Text = "Nhập thủ công"
        '
        'txtDatabase
        '
        Me.txtDatabase.Location = New System.Drawing.Point(129, 114)
        Me.txtDatabase.Name = "txtDatabase"
        Me.txtDatabase.Size = New System.Drawing.Size(185, 23)
        Me.txtDatabase.TabIndex = 22
        '
        'txtPassword
        '
        Me.txtPassword.Location = New System.Drawing.Point(129, 81)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.Size = New System.Drawing.Size(185, 23)
        Me.txtPassword.TabIndex = 21
        '
        'txtUsername
        '
        Me.txtUsername.Location = New System.Drawing.Point(129, 49)
        Me.txtUsername.Name = "txtUsername"
        Me.txtUsername.Size = New System.Drawing.Size(185, 23)
        Me.txtUsername.TabIndex = 20
        '
        'txtServer
        '
        Me.txtServer.Location = New System.Drawing.Point(129, 18)
        Me.txtServer.Name = "txtServer"
        Me.txtServer.Size = New System.Drawing.Size(185, 23)
        Me.txtServer.TabIndex = 19
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(7, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(83, 17)
        Me.Label1.TabIndex = 11
        Me.Label1.Text = "Chọn server"
        '
        'bwKetnoi
        '
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'Timer1
        '
        Me.Timer1.Interval = 30
        '
        'lblKetnoi
        '
        Me.lblKetnoi.AutoSize = True
        Me.lblKetnoi.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblKetnoi.ForeColor = System.Drawing.Color.Red
        Me.lblKetnoi.Location = New System.Drawing.Point(9, 231)
        Me.lblKetnoi.Name = "lblKetnoi"
        Me.lblKetnoi.Size = New System.Drawing.Size(86, 17)
        Me.lblKetnoi.TabIndex = 25
        Me.lblKetnoi.Text = "Đang kết nối"
        Me.lblKetnoi.Visible = False
        '
        'btnKetnoi
        '
        Me.btnKetnoi.Location = New System.Drawing.Point(108, 221)
        Me.btnKetnoi.Name = "btnKetnoi"
        Me.btnKetnoi.Size = New System.Drawing.Size(93, 36)
        Me.btnKetnoi.TabIndex = 26
        Me.btnKetnoi.Text = "Kết nối"
        Me.btnKetnoi.UseVisualStyleBackColor = True
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(214, 231)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(100, 23)
        Me.ProgressBar1.Style = System.Windows.Forms.ProgressBarStyle.Continuous
        Me.ProgressBar1.TabIndex = 27
        '
        'frmDatabase
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.ClientSize = New System.Drawing.Size(336, 263)
        Me.Controls.Add(Me.grpChuoiketnoi)
        Me.Controls.Add(Me.ProgressBar1)
        Me.Controls.Add(Me.lblKetnoi)
        Me.Controls.Add(Me.btnKetnoi)
        Me.Controls.Add(Me.grpThucong)
        Me.Controls.Add(Me.GroupBox2)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(352, 407)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(352, 301)
        Me.Name = "frmDatabase"
        Me.Text = "Chọn CSDL"
        Me.grpChuoiketnoi.ResumeLayout(False)
        Me.grpChuoiketnoi.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.grpThucong.ResumeLayout(False)
        Me.grpThucong.PerformLayout()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents grpChuoiketnoi As System.Windows.Forms.GroupBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents cbPhuongthuc As System.Windows.Forms.ComboBox
    Friend WithEvents HelpProvider1 As System.Windows.Forms.HelpProvider
    Friend WithEvents grpThucong As System.Windows.Forms.GroupBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents bwKetnoi As System.ComponentModel.BackgroundWorker
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents txtDatabase As System.Windows.Forms.TextBox
    Friend WithEvents txtPassword As System.Windows.Forms.TextBox
    Friend WithEvents txtUsername As System.Windows.Forms.TextBox
    Friend WithEvents txtServer As System.Windows.Forms.TextBox
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents lblKetnoi As System.Windows.Forms.Label
    Friend WithEvents btnKetnoi As System.Windows.Forms.Button
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
    Friend WithEvents txtChuoiKetNoi As System.Windows.Forms.TextBox
End Class
