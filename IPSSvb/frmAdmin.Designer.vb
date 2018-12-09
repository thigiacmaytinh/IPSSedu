<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAdmin
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAdmin))
        Me.ErrorProvider2 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.dgvNhanvien = New System.Windows.Forms.DataGridView()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtNgaysinh = New System.Windows.Forms.DateTimePicker()
        Me.btnXoa = New System.Windows.Forms.Button()
        Me.btnSua = New System.Windows.Forms.Button()
        Me.btnThem = New System.Windows.Forms.Button()
        Me.txtEmail = New System.Windows.Forms.TextBox()
        Me.txtManv = New System.Windows.Forms.TextBox()
        Me.txtMathe = New System.Windows.Forms.TextBox()
        Me.txtDienthoai = New System.Windows.Forms.TextBox()
        Me.txtDiachi = New System.Windows.Forms.TextBox()
        Me.txtHoten = New System.Windows.Forms.TextBox()
        Me.cbNhom = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.rdNu = New System.Windows.Forms.RadioButton()
        Me.rdNam = New System.Windows.Forms.RadioButton()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.btnTim = New System.Windows.Forms.Button()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.chkChinhxac = New System.Windows.Forms.CheckBox()
        Me.cbTim = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cbDieukienTim = New System.Windows.Forms.ComboBox()
        CType(Me.ErrorProvider2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvNhanvien, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'ErrorProvider2
        '
        Me.ErrorProvider2.ContainerControl = Me
        '
        'dgvNhanvien
        '
        Me.dgvNhanvien.AllowUserToAddRows = False
        Me.dgvNhanvien.AllowUserToDeleteRows = False
        Me.dgvNhanvien.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgvNhanvien.BackgroundColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.dgvNhanvien.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(53, Byte), Integer))
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvNhanvien.DefaultCellStyle = DataGridViewCellStyle1
        Me.dgvNhanvien.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvNhanvien.Location = New System.Drawing.Point(0, 240)
        Me.dgvNhanvien.MultiSelect = False
        Me.dgvNhanvien.Name = "dgvNhanvien"
        Me.dgvNhanvien.ReadOnly = True
        Me.dgvNhanvien.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvNhanvien.Size = New System.Drawing.Size(944, 422)
        Me.dgvNhanvien.StandardTab = True
        Me.dgvNhanvien.TabIndex = 19
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.GroupBox1.Controls.Add(Me.txtNgaysinh)
        Me.GroupBox1.Controls.Add(Me.btnXoa)
        Me.GroupBox1.Controls.Add(Me.btnSua)
        Me.GroupBox1.Controls.Add(Me.btnThem)
        Me.GroupBox1.Controls.Add(Me.txtEmail)
        Me.GroupBox1.Controls.Add(Me.txtManv)
        Me.GroupBox1.Controls.Add(Me.txtMathe)
        Me.GroupBox1.Controls.Add(Me.txtDienthoai)
        Me.GroupBox1.Controls.Add(Me.txtDiachi)
        Me.GroupBox1.Controls.Add(Me.txtHoten)
        Me.GroupBox1.Controls.Add(Me.cbNhom)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.rdNu)
        Me.GroupBox1.Controls.Add(Me.rdNam)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox1.Location = New System.Drawing.Point(0, 75)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(944, 165)
        Me.GroupBox1.TabIndex = 20
        Me.GroupBox1.TabStop = False
        '
        'txtNgaysinh
        '
        Me.txtNgaysinh.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.txtNgaysinh.Location = New System.Drawing.Point(119, 56)
        Me.txtNgaysinh.Name = "txtNgaysinh"
        Me.txtNgaysinh.Size = New System.Drawing.Size(189, 20)
        Me.txtNgaysinh.TabIndex = 41
        '
        'btnXoa
        '
        Me.btnXoa.Font = New System.Drawing.Font("Tahoma", 10.0!)
        Me.btnXoa.Location = New System.Drawing.Point(708, 130)
        Me.btnXoa.Name = "btnXoa"
        Me.btnXoa.Size = New System.Drawing.Size(75, 28)
        Me.btnXoa.TabIndex = 40
        Me.btnXoa.Text = "Xoá"
        Me.btnXoa.UseVisualStyleBackColor = True
        '
        'btnSua
        '
        Me.btnSua.Font = New System.Drawing.Font("Tahoma", 10.0!)
        Me.btnSua.Location = New System.Drawing.Point(611, 130)
        Me.btnSua.Name = "btnSua"
        Me.btnSua.Size = New System.Drawing.Size(75, 28)
        Me.btnSua.TabIndex = 39
        Me.btnSua.Text = "Sửa"
        Me.btnSua.UseVisualStyleBackColor = True
        '
        'btnThem
        '
        Me.btnThem.Font = New System.Drawing.Font("Tahoma", 10.0!)
        Me.btnThem.Location = New System.Drawing.Point(510, 130)
        Me.btnThem.Name = "btnThem"
        Me.btnThem.Size = New System.Drawing.Size(75, 28)
        Me.btnThem.TabIndex = 38
        Me.btnThem.Text = "Thêm"
        Me.btnThem.UseVisualStyleBackColor = True
        '
        'txtEmail
        '
        Me.txtEmail.Location = New System.Drawing.Point(541, 101)
        Me.txtEmail.Name = "txtEmail"
        Me.txtEmail.Size = New System.Drawing.Size(217, 20)
        Me.txtEmail.TabIndex = 37
        '
        'txtManv
        '
        Me.txtManv.Location = New System.Drawing.Point(541, 72)
        Me.txtManv.Name = "txtManv"
        Me.txtManv.Size = New System.Drawing.Size(217, 20)
        Me.txtManv.TabIndex = 36
        '
        'txtMathe
        '
        Me.txtMathe.Location = New System.Drawing.Point(541, 43)
        Me.txtMathe.Name = "txtMathe"
        Me.txtMathe.Size = New System.Drawing.Size(217, 20)
        Me.txtMathe.TabIndex = 35
        '
        'txtDienthoai
        '
        Me.txtDienthoai.Location = New System.Drawing.Point(116, 136)
        Me.txtDienthoai.Name = "txtDienthoai"
        Me.txtDienthoai.Size = New System.Drawing.Size(189, 20)
        Me.txtDienthoai.TabIndex = 34
        '
        'txtDiachi
        '
        Me.txtDiachi.Location = New System.Drawing.Point(116, 108)
        Me.txtDiachi.Name = "txtDiachi"
        Me.txtDiachi.Size = New System.Drawing.Size(189, 20)
        Me.txtDiachi.TabIndex = 33
        '
        'txtHoten
        '
        Me.txtHoten.Location = New System.Drawing.Point(119, 25)
        Me.txtHoten.Name = "txtHoten"
        Me.txtHoten.Size = New System.Drawing.Size(189, 20)
        Me.txtHoten.TabIndex = 32
        '
        'cbNhom
        '
        Me.cbNhom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbNhom.FormattingEnabled = True
        Me.cbNhom.Location = New System.Drawing.Point(541, 14)
        Me.cbNhom.Name = "cbNhom"
        Me.cbNhom.Size = New System.Drawing.Size(217, 21)
        Me.cbNhom.TabIndex = 7
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Blue
        Me.Label8.Location = New System.Drawing.Point(397, 100)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(39, 17)
        Me.Label8.TabIndex = 31
        Me.Label8.Text = "Email"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Blue
        Me.Label9.Location = New System.Drawing.Point(397, 72)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(101, 17)
        Me.Label9.TabIndex = 30
        Me.Label9.Text = "Tên đăng nhập"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Blue
        Me.Label10.Location = New System.Drawing.Point(397, 43)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(49, 17)
        Me.Label10.TabIndex = 29
        Me.Label10.Text = "Mã thẻ"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.Blue
        Me.Label11.Location = New System.Drawing.Point(397, 15)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(120, 17)
        Me.Label11.TabIndex = 28
        Me.Label11.Text = "Nhóm người dùng"
        '
        'rdNu
        '
        Me.rdNu.AutoSize = True
        Me.rdNu.Location = New System.Drawing.Point(214, 84)
        Me.rdNu.Name = "rdNu"
        Me.rdNu.Size = New System.Drawing.Size(39, 17)
        Me.rdNu.TabIndex = 4
        Me.rdNu.TabStop = True
        Me.rdNu.Text = "Nữ"
        Me.rdNu.UseVisualStyleBackColor = True
        '
        'rdNam
        '
        Me.rdNam.AutoSize = True
        Me.rdNam.Checked = True
        Me.rdNam.Location = New System.Drawing.Point(119, 82)
        Me.rdNam.Name = "rdNam"
        Me.rdNam.Size = New System.Drawing.Size(47, 17)
        Me.rdNam.TabIndex = 3
        Me.rdNam.TabStop = True
        Me.rdNam.Text = "Nam"
        Me.rdNam.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Blue
        Me.Label6.Location = New System.Drawing.Point(38, 139)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(69, 17)
        Me.Label6.TabIndex = 21
        Me.Label6.Text = "Điện thoại"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Blue
        Me.Label5.Location = New System.Drawing.Point(38, 112)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(48, 17)
        Me.Label5.TabIndex = 20
        Me.Label5.Text = "Địa chỉ"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Blue
        Me.Label4.Location = New System.Drawing.Point(38, 84)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(56, 17)
        Me.Label4.TabIndex = 19
        Me.Label4.Text = "Giới tính"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Blue
        Me.Label3.Location = New System.Drawing.Point(38, 56)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(68, 17)
        Me.Label3.TabIndex = 18
        Me.Label3.Text = "Ngày sinh"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Blue
        Me.Label2.Location = New System.Drawing.Point(38, 28)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(49, 17)
        Me.Label2.TabIndex = 17
        Me.Label2.Text = "Họ tên"
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.GroupBox2.Controls.Add(Me.btnTim)
        Me.GroupBox2.Controls.Add(Me.Label21)
        Me.GroupBox2.Controls.Add(Me.chkChinhxac)
        Me.GroupBox2.Controls.Add(Me.cbTim)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.cbDieukienTim)
        Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox2.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(944, 75)
        Me.GroupBox2.TabIndex = 21
        Me.GroupBox2.TabStop = False
        '
        'btnTim
        '
        Me.btnTim.Font = New System.Drawing.Font("Tahoma", 10.0!)
        Me.btnTim.Location = New System.Drawing.Point(756, 22)
        Me.btnTim.Name = "btnTim"
        Me.btnTim.Size = New System.Drawing.Size(75, 28)
        Me.btnTim.TabIndex = 40
        Me.btnTim.Text = "Tìm kiếm"
        Me.btnTim.UseVisualStyleBackColor = True
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.ForeColor = System.Drawing.Color.Blue
        Me.Label21.Location = New System.Drawing.Point(311, 22)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(74, 17)
        Me.Label21.TabIndex = 8
        Me.Label21.Text = "Từ cần tim"
        '
        'chkChinhxac
        '
        Me.chkChinhxac.AutoSize = True
        Me.chkChinhxac.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkChinhxac.ForeColor = System.Drawing.Color.Blue
        Me.chkChinhxac.Location = New System.Drawing.Point(745, 49)
        Me.chkChinhxac.Name = "chkChinhxac"
        Me.chkChinhxac.Size = New System.Drawing.Size(113, 21)
        Me.chkChinhxac.TabIndex = 3
        Me.chkChinhxac.Text = "Tìm chính xác"
        Me.chkChinhxac.UseVisualStyleBackColor = True
        '
        'cbTim
        '
        Me.cbTim.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cbTim.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cbTim.FormattingEnabled = True
        Me.cbTim.Location = New System.Drawing.Point(400, 17)
        Me.cbTim.Name = "cbTim"
        Me.cbTim.Size = New System.Drawing.Size(170, 21)
        Me.cbTim.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Blue
        Me.Label1.Location = New System.Drawing.Point(11, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(99, 17)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "Tìm kiếm theo:"
        '
        'cbDieukienTim
        '
        Me.cbDieukienTim.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbDieukienTim.FormattingEnabled = True
        Me.cbDieukienTim.Items.AddRange(New Object() {"Mã nhân viên", "Họ tên", "Email"})
        Me.cbDieukienTim.Location = New System.Drawing.Point(116, 17)
        Me.cbDieukienTim.Name = "cbDieukienTim"
        Me.cbDieukienTim.Size = New System.Drawing.Size(147, 21)
        Me.cbDieukienTim.TabIndex = 1
        '
        'frmAdmin
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(944, 662)
        Me.Controls.Add(Me.dgvNhanvien)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmAdmin"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Bảng điều khiển Admin"
        CType(Me.ErrorProvider2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvNhanvien, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ErrorProvider2 As System.Windows.Forms.ErrorProvider
    Friend WithEvents dgvNhanvien As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtNgaysinh As System.Windows.Forms.DateTimePicker
    Friend WithEvents btnXoa As System.Windows.Forms.Button
    Friend WithEvents btnSua As System.Windows.Forms.Button
    Friend WithEvents btnThem As System.Windows.Forms.Button
    Friend WithEvents txtEmail As System.Windows.Forms.TextBox
    Friend WithEvents txtManv As System.Windows.Forms.TextBox
    Friend WithEvents txtMathe As System.Windows.Forms.TextBox
    Friend WithEvents txtDienthoai As System.Windows.Forms.TextBox
    Friend WithEvents txtDiachi As System.Windows.Forms.TextBox
    Friend WithEvents txtHoten As System.Windows.Forms.TextBox
    Friend WithEvents cbNhom As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents rdNu As System.Windows.Forms.RadioButton
    Friend WithEvents rdNam As System.Windows.Forms.RadioButton
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents btnTim As System.Windows.Forms.Button
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents chkChinhxac As System.Windows.Forms.CheckBox
    Friend WithEvents cbTim As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cbDieukienTim As System.Windows.Forms.ComboBox
End Class
