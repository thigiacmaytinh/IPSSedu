<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmChinh8
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmChinh8))
        Me.Timer_vao = New System.Windows.Forms.Timer(Me.components)
        Me.ĐổiMậtKhẩuToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.btnDoclai = New System.Windows.Forms.Button()
        Me.txtBienSoVao = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.picVaoTruoc = New System.Windows.Forms.PictureBox()
        Me.picVaoSau = New System.Windows.Forms.PictureBox()
        Me.cbLoaixevao = New System.Windows.Forms.ComboBox()
        Me.imgVaoSau = New Emgu.CV.UI.ImageBox()
        Me.imgVaoTruoc = New Emgu.CV.UI.ImageBox()
        Me.NgườiDùngToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TìmKiếmToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ChọnCameraToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CôngCụToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BáoMấtThẻToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BáoHưThẻToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ĐổiThưMụcLưuẢnhToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ThốngKêToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.XeTrongBãiToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.btnAdmin = New System.Windows.Forms.ToolStripMenuItem()
        Me.CậpNhậtNhânViênToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CậpNhậtGiáTiềnToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ChấmCôngNhânViênToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.picRaTruoc = New System.Windows.Forms.PictureBox()
        Me.imgRaSau = New Emgu.CV.UI.ImageBox()
        Me.imgRaTruoc = New Emgu.CV.UI.ImageBox()
        Me.ofDigImage = New System.Windows.Forms.OpenFileDialog()
        Me.bwWC = New System.ComponentModel.BackgroundWorker()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.txtBiensora = New System.Windows.Forms.TextBox()
        Me.ProgressBar2 = New System.Windows.Forms.ProgressBar()
        Me.btndoclai2 = New System.Windows.Forms.Button()
        Me.txtBienSoCu = New System.Windows.Forms.TextBox()
        Me.cbLoaixera = New System.Windows.Forms.ComboBox()
        Me.picRaSau = New System.Windows.Forms.PictureBox()
        Me.Timer_ra = New System.Windows.Forms.Timer(Me.components)
        Me.Timer_xoara = New System.Windows.Forms.Timer(Me.components)
        Me.Timer_xoavao = New System.Windows.Forms.Timer(Me.components)
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtNgayra = New System.Windows.Forms.TextBox()
        Me.txtNgayvao = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.lblLuong = New System.Windows.Forms.Label()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.txtGiora = New System.Windows.Forms.TextBox()
        Me.txtGiovao = New System.Windows.Forms.TextBox()
        Me.txtSothe = New System.Windows.Forms.TextBox()
        Me.TimerProgress = New System.Windows.Forms.Timer(Me.components)
        Me.GroupBox1.SuspendLayout()
        CType(Me.picVaoTruoc, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picVaoSau, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.imgVaoSau, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.imgVaoTruoc, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip1.SuspendLayout()
        CType(Me.picRaTruoc, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.imgRaSau, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.imgRaTruoc, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        CType(Me.picRaSau, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox5.SuspendLayout()
        Me.SuspendLayout()
        '
        'Timer_vao
        '
        '
        'ĐổiMậtKhẩuToolStripMenuItem
        '
        Me.ĐổiMậtKhẩuToolStripMenuItem.Name = "ĐổiMậtKhẩuToolStripMenuItem"
        Me.ĐổiMậtKhẩuToolStripMenuItem.Size = New System.Drawing.Size(145, 22)
        Me.ĐổiMậtKhẩuToolStripMenuItem.Text = "Đổi mật khẩ&u"
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.GroupBox1.Controls.Add(Me.ProgressBar1)
        Me.GroupBox1.Controls.Add(Me.btnDoclai)
        Me.GroupBox1.Controls.Add(Me.txtBienSoVao)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.picVaoTruoc)
        Me.GroupBox1.Controls.Add(Me.picVaoSau)
        Me.GroupBox1.Controls.Add(Me.cbLoaixevao)
        Me.GroupBox1.Controls.Add(Me.imgVaoSau)
        Me.GroupBox1.Controls.Add(Me.imgVaoTruoc)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Left
        Me.GroupBox1.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(0, 92)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(670, 613)
        Me.GroupBox1.TabIndex = 47
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Luồng vào"
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(269, 321)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(62, 23)
        Me.ProgressBar1.Style = System.Windows.Forms.ProgressBarStyle.Continuous
        Me.ProgressBar1.TabIndex = 54
        Me.ProgressBar1.Visible = False
        '
        'btnDoclai
        '
        Me.btnDoclai.Location = New System.Drawing.Point(188, 318)
        Me.btnDoclai.Name = "btnDoclai"
        Me.btnDoclai.Size = New System.Drawing.Size(75, 28)
        Me.btnDoclai.TabIndex = 53
        Me.btnDoclai.TabStop = False
        Me.btnDoclai.Text = "Đọc..."
        Me.btnDoclai.UseVisualStyleBackColor = True
        '
        'txtBienSoVao
        '
        Me.txtBienSoVao.BackColor = System.Drawing.Color.Gainsboro
        Me.txtBienSoVao.Font = New System.Drawing.Font("Tahoma", 30.0!)
        Me.txtBienSoVao.ForeColor = System.Drawing.Color.Red
        Me.txtBienSoVao.Location = New System.Drawing.Point(334, 290)
        Me.txtBienSoVao.Name = "txtBienSoVao"
        Me.txtBienSoVao.Size = New System.Drawing.Size(328, 56)
        Me.txtBienSoVao.TabIndex = 52
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(6, 326)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(184, 16)
        Me.Label8.TabIndex = 51
        Me.Label8.Text = "[BẤM XUỐNG ĐỂ ĐỌC/NGƯNG]"
        '
        'picVaoTruoc
        '
        Me.picVaoTruoc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.picVaoTruoc.Location = New System.Drawing.Point(334, 19)
        Me.picVaoTruoc.Name = "picVaoTruoc"
        Me.picVaoTruoc.Size = New System.Drawing.Size(330, 266)
        Me.picVaoTruoc.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picVaoTruoc.TabIndex = 50
        Me.picVaoTruoc.TabStop = False
        '
        'picVaoSau
        '
        Me.picVaoSau.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.picVaoSau.Location = New System.Drawing.Point(332, 347)
        Me.picVaoSau.Name = "picVaoSau"
        Me.picVaoSau.Size = New System.Drawing.Size(330, 262)
        Me.picVaoSau.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picVaoSau.TabIndex = 49
        Me.picVaoSau.TabStop = False
        '
        'cbLoaixevao
        '
        Me.cbLoaixevao.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbLoaixevao.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbLoaixevao.FormattingEnabled = True
        Me.cbLoaixevao.Location = New System.Drawing.Point(188, 290)
        Me.cbLoaixevao.Name = "cbLoaixevao"
        Me.cbLoaixevao.Size = New System.Drawing.Size(122, 27)
        Me.cbLoaixevao.TabIndex = 42
        Me.cbLoaixevao.TabStop = False
        '
        'imgVaoSau
        '
        Me.imgVaoSau.FunctionalMode = Emgu.CV.UI.ImageBox.FunctionalModeOption.Minimum
        Me.imgVaoSau.Location = New System.Drawing.Point(1, 347)
        Me.imgVaoSau.Name = "imgVaoSau"
        Me.imgVaoSau.Size = New System.Drawing.Size(330, 262)
        Me.imgVaoSau.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.imgVaoSau.TabIndex = 4
        Me.imgVaoSau.TabStop = False
        '
        'imgVaoTruoc
        '
        Me.imgVaoTruoc.FunctionalMode = Emgu.CV.UI.ImageBox.FunctionalModeOption.Minimum
        Me.imgVaoTruoc.Location = New System.Drawing.Point(1, 19)
        Me.imgVaoTruoc.Name = "imgVaoTruoc"
        Me.imgVaoTruoc.Size = New System.Drawing.Size(330, 266)
        Me.imgVaoTruoc.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.imgVaoTruoc.TabIndex = 3
        Me.imgVaoTruoc.TabStop = False
        '
        'NgườiDùngToolStripMenuItem
        '
        Me.NgườiDùngToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ĐổiMậtKhẩuToolStripMenuItem})
        Me.NgườiDùngToolStripMenuItem.Name = "NgườiDùngToolStripMenuItem"
        Me.NgườiDùngToolStripMenuItem.Size = New System.Drawing.Size(83, 20)
        Me.NgườiDùngToolStripMenuItem.Text = "&Người dùng"
        '
        'TìmKiếmToolStripMenuItem
        '
        Me.TìmKiếmToolStripMenuItem.Name = "TìmKiếmToolStripMenuItem"
        Me.TìmKiếmToolStripMenuItem.Size = New System.Drawing.Size(183, 22)
        Me.TìmKiếmToolStripMenuItem.Text = "&Tìm kiếm"
        '
        'ChọnCameraToolStripMenuItem
        '
        Me.ChọnCameraToolStripMenuItem.Name = "ChọnCameraToolStripMenuItem"
        Me.ChọnCameraToolStripMenuItem.Size = New System.Drawing.Size(183, 22)
        Me.ChọnCameraToolStripMenuItem.Text = "Chọn c&amera"
        '
        'CôngCụToolStripMenuItem
        '
        Me.CôngCụToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BáoMấtThẻToolStripMenuItem, Me.BáoHưThẻToolStripMenuItem, Me.ĐổiThưMụcLưuẢnhToolStripMenuItem, Me.ChọnCameraToolStripMenuItem, Me.TìmKiếmToolStripMenuItem, Me.ThốngKêToolStripMenuItem, Me.XeTrongBãiToolStripMenuItem})
        Me.CôngCụToolStripMenuItem.Name = "CôngCụToolStripMenuItem"
        Me.CôngCụToolStripMenuItem.Size = New System.Drawing.Size(64, 20)
        Me.CôngCụToolStripMenuItem.Text = "Cô&ng cụ"
        '
        'BáoMấtThẻToolStripMenuItem
        '
        Me.BáoMấtThẻToolStripMenuItem.Name = "BáoMấtThẻToolStripMenuItem"
        Me.BáoMấtThẻToolStripMenuItem.Size = New System.Drawing.Size(183, 22)
        Me.BáoMấtThẻToolStripMenuItem.Text = "Báo &mất thẻ"
        '
        'BáoHưThẻToolStripMenuItem
        '
        Me.BáoHưThẻToolStripMenuItem.Name = "BáoHưThẻToolStripMenuItem"
        Me.BáoHưThẻToolStripMenuItem.Size = New System.Drawing.Size(183, 22)
        Me.BáoHưThẻToolStripMenuItem.Text = "Báo &hư thẻ"
        '
        'ĐổiThưMụcLưuẢnhToolStripMenuItem
        '
        Me.ĐổiThưMụcLưuẢnhToolStripMenuItem.Name = "ĐổiThưMụcLưuẢnhToolStripMenuItem"
        Me.ĐổiThưMụcLưuẢnhToolStripMenuItem.Size = New System.Drawing.Size(183, 22)
        Me.ĐổiThưMụcLưuẢnhToolStripMenuItem.Text = "Đổi &thư mục lưu ảnh"
        '
        'ThốngKêToolStripMenuItem
        '
        Me.ThốngKêToolStripMenuItem.Name = "ThốngKêToolStripMenuItem"
        Me.ThốngKêToolStripMenuItem.Size = New System.Drawing.Size(183, 22)
        Me.ThốngKêToolStripMenuItem.Text = "Thống &kê"
        '
        'XeTrongBãiToolStripMenuItem
        '
        Me.XeTrongBãiToolStripMenuItem.Name = "XeTrongBãiToolStripMenuItem"
        Me.XeTrongBãiToolStripMenuItem.Size = New System.Drawing.Size(183, 22)
        Me.XeTrongBãiToolStripMenuItem.Text = "Xe trong bãi"
        '
        'MenuStrip1
        '
        Me.MenuStrip1.BackColor = System.Drawing.SystemColors.Control
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CôngCụToolStripMenuItem, Me.NgườiDùngToolStripMenuItem, Me.btnAdmin})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1344, 24)
        Me.MenuStrip1.TabIndex = 46
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'btnAdmin
        '
        Me.btnAdmin.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CậpNhậtNhânViênToolStripMenuItem, Me.CậpNhậtGiáTiềnToolStripMenuItem, Me.ChấmCôngNhânViênToolStripMenuItem})
        Me.btnAdmin.Name = "btnAdmin"
        Me.btnAdmin.Size = New System.Drawing.Size(114, 20)
        Me.btnAdmin.Text = "Chức năng admin"
        '
        'CậpNhậtNhânViênToolStripMenuItem
        '
        Me.CậpNhậtNhânViênToolStripMenuItem.Name = "CậpNhậtNhânViênToolStripMenuItem"
        Me.CậpNhậtNhânViênToolStripMenuItem.Size = New System.Drawing.Size(191, 22)
        Me.CậpNhậtNhânViênToolStripMenuItem.Text = "Cập nhật nhân viên"
        '
        'CậpNhậtGiáTiềnToolStripMenuItem
        '
        Me.CậpNhậtGiáTiềnToolStripMenuItem.Name = "CậpNhậtGiáTiềnToolStripMenuItem"
        Me.CậpNhậtGiáTiềnToolStripMenuItem.Size = New System.Drawing.Size(191, 22)
        Me.CậpNhậtGiáTiềnToolStripMenuItem.Text = "Cập nhật giá tiền"
        '
        'ChấmCôngNhânViênToolStripMenuItem
        '
        Me.ChấmCôngNhânViênToolStripMenuItem.Name = "ChấmCôngNhânViênToolStripMenuItem"
        Me.ChấmCôngNhânViênToolStripMenuItem.Size = New System.Drawing.Size(191, 22)
        Me.ChấmCôngNhânViênToolStripMenuItem.Text = "Chấm công nhân viên"
        '
        'picRaTruoc
        '
        Me.picRaTruoc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.picRaTruoc.Location = New System.Drawing.Point(8, 19)
        Me.picRaTruoc.Name = "picRaTruoc"
        Me.picRaTruoc.Size = New System.Drawing.Size(330, 269)
        Me.picRaTruoc.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picRaTruoc.TabIndex = 37
        Me.picRaTruoc.TabStop = False
        '
        'imgRaSau
        '
        Me.imgRaSau.FunctionalMode = Emgu.CV.UI.ImageBox.FunctionalModeOption.Minimum
        Me.imgRaSau.Location = New System.Drawing.Point(341, 347)
        Me.imgRaSau.Name = "imgRaSau"
        Me.imgRaSau.Size = New System.Drawing.Size(330, 262)
        Me.imgRaSau.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.imgRaSau.TabIndex = 11
        Me.imgRaSau.TabStop = False
        '
        'imgRaTruoc
        '
        Me.imgRaTruoc.FunctionalMode = Emgu.CV.UI.ImageBox.FunctionalModeOption.Minimum
        Me.imgRaTruoc.Location = New System.Drawing.Point(341, 19)
        Me.imgRaTruoc.Name = "imgRaTruoc"
        Me.imgRaTruoc.Size = New System.Drawing.Size(330, 265)
        Me.imgRaTruoc.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.imgRaTruoc.TabIndex = 10
        Me.imgRaTruoc.TabStop = False
        '
        'bwWC
        '
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.GroupBox2.Controls.Add(Me.txtBiensora)
        Me.GroupBox2.Controls.Add(Me.ProgressBar2)
        Me.GroupBox2.Controls.Add(Me.btndoclai2)
        Me.GroupBox2.Controls.Add(Me.txtBienSoCu)
        Me.GroupBox2.Controls.Add(Me.cbLoaixera)
        Me.GroupBox2.Controls.Add(Me.picRaSau)
        Me.GroupBox2.Controls.Add(Me.imgRaSau)
        Me.GroupBox2.Controls.Add(Me.imgRaTruoc)
        Me.GroupBox2.Controls.Add(Me.picRaTruoc)
        Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox2.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(670, 92)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(674, 613)
        Me.GroupBox2.TabIndex = 48
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Luồng ra"
        '
        'txtBiensora
        '
        Me.txtBiensora.BackColor = System.Drawing.Color.Gainsboro
        Me.txtBiensora.Font = New System.Drawing.Font("Tahoma", 30.0!)
        Me.txtBiensora.ForeColor = System.Drawing.Color.Blue
        Me.txtBiensora.Location = New System.Drawing.Point(422, 288)
        Me.txtBiensora.Name = "txtBiensora"
        Me.txtBiensora.Size = New System.Drawing.Size(247, 56)
        Me.txtBiensora.TabIndex = 69
        '
        'ProgressBar2
        '
        Me.ProgressBar2.Location = New System.Drawing.Point(350, 321)
        Me.ProgressBar2.Name = "ProgressBar2"
        Me.ProgressBar2.Size = New System.Drawing.Size(67, 23)
        Me.ProgressBar2.Style = System.Windows.Forms.ProgressBarStyle.Continuous
        Me.ProgressBar2.TabIndex = 68
        Me.ProgressBar2.Visible = False
        '
        'btndoclai2
        '
        Me.btndoclai2.Location = New System.Drawing.Point(273, 318)
        Me.btndoclai2.Name = "btndoclai2"
        Me.btndoclai2.Size = New System.Drawing.Size(75, 28)
        Me.btndoclai2.TabIndex = 67
        Me.btndoclai2.TabStop = False
        Me.btndoclai2.Text = "Đọc..."
        Me.btndoclai2.UseVisualStyleBackColor = True
        '
        'txtBienSoCu
        '
        Me.txtBienSoCu.BackColor = System.Drawing.SystemColors.InactiveCaption
        Me.txtBienSoCu.Font = New System.Drawing.Font("Tahoma", 30.0!)
        Me.txtBienSoCu.ForeColor = System.Drawing.Color.Red
        Me.txtBienSoCu.Location = New System.Drawing.Point(8, 290)
        Me.txtBienSoCu.Name = "txtBienSoCu"
        Me.txtBienSoCu.Size = New System.Drawing.Size(264, 56)
        Me.txtBienSoCu.TabIndex = 66
        '
        'cbLoaixera
        '
        Me.cbLoaixera.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbLoaixera.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbLoaixera.FormattingEnabled = True
        Me.cbLoaixera.Location = New System.Drawing.Point(273, 290)
        Me.cbLoaixera.Name = "cbLoaixera"
        Me.cbLoaixera.Size = New System.Drawing.Size(123, 27)
        Me.cbLoaixera.TabIndex = 61
        Me.cbLoaixera.TabStop = False
        '
        'picRaSau
        '
        Me.picRaSau.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.picRaSau.Location = New System.Drawing.Point(8, 348)
        Me.picRaSau.Name = "picRaSau"
        Me.picRaSau.Size = New System.Drawing.Size(330, 261)
        Me.picRaSau.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picRaSau.TabIndex = 38
        Me.picRaSau.TabStop = False
        '
        'Timer_ra
        '
        '
        'Timer_xoara
        '
        Me.Timer_xoara.Interval = 6000
        '
        'Timer_xoavao
        '
        Me.Timer_xoavao.Interval = 6000
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(465, -1)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(56, 16)
        Me.Label1.TabIndex = 15
        Me.Label1.Text = "MÃ THẺ"
        '
        'txtNgayra
        '
        Me.txtNgayra.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.txtNgayra.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNgayra.Location = New System.Drawing.Point(969, 26)
        Me.txtNgayra.Name = "txtNgayra"
        Me.txtNgayra.ReadOnly = True
        Me.txtNgayra.Size = New System.Drawing.Size(185, 40)
        Me.txtNgayra.TabIndex = 63
        Me.txtNgayra.TabStop = False
        '
        'txtNgayvao
        '
        Me.txtNgayvao.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.txtNgayvao.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNgayvao.Location = New System.Drawing.Point(189, 26)
        Me.txtNgayvao.Name = "txtNgayvao"
        Me.txtNgayvao.ReadOnly = True
        Me.txtNgayvao.Size = New System.Drawing.Size(191, 40)
        Me.txtNgayvao.TabIndex = 46
        Me.txtNgayvao.TabStop = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(745, -1)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(80, 16)
        Me.Label3.TabIndex = 65
        Me.Label3.Text = "THÔNG BÁO"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(62, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(63, 16)
        Me.Label4.TabIndex = 66
        Me.Label4.Text = "GIỜ VÀO"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(252, -1)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(75, 16)
        Me.Label5.TabIndex = 51
        Me.Label5.Text = "NGÀY VÀO"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(1023, -1)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(66, 16)
        Me.Label6.TabIndex = 51
        Me.Label6.Text = "NGÀY RA"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(1215, -1)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(54, 16)
        Me.Label7.TabIndex = 67
        Me.Label7.Text = "GIỜ RA"
        '
        'lblLuong
        '
        Me.lblLuong.AutoSize = True
        Me.lblLuong.BackColor = System.Drawing.Color.White
        Me.lblLuong.Font = New System.Drawing.Font("Tahoma", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLuong.ForeColor = System.Drawing.Color.Red
        Me.lblLuong.Location = New System.Drawing.Point(642, 30)
        Me.lblLuong.Name = "lblLuong"
        Me.lblLuong.Size = New System.Drawing.Size(0, 29)
        Me.lblLuong.TabIndex = 17
        '
        'GroupBox5
        '
        Me.GroupBox5.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.GroupBox5.Controls.Add(Me.txtGiora)
        Me.GroupBox5.Controls.Add(Me.txtGiovao)
        Me.GroupBox5.Controls.Add(Me.txtSothe)
        Me.GroupBox5.Controls.Add(Me.lblLuong)
        Me.GroupBox5.Controls.Add(Me.Label7)
        Me.GroupBox5.Controls.Add(Me.Label6)
        Me.GroupBox5.Controls.Add(Me.Label5)
        Me.GroupBox5.Controls.Add(Me.Label4)
        Me.GroupBox5.Controls.Add(Me.Label3)
        Me.GroupBox5.Controls.Add(Me.txtNgayvao)
        Me.GroupBox5.Controls.Add(Me.txtNgayra)
        Me.GroupBox5.Controls.Add(Me.Label1)
        Me.GroupBox5.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox5.Location = New System.Drawing.Point(0, 24)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(1344, 68)
        Me.GroupBox5.TabIndex = 49
        Me.GroupBox5.TabStop = False
        '
        'txtGiora
        '
        Me.txtGiora.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.txtGiora.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!)
        Me.txtGiora.Location = New System.Drawing.Point(1160, 27)
        Me.txtGiora.Name = "txtGiora"
        Me.txtGiora.ReadOnly = True
        Me.txtGiora.Size = New System.Drawing.Size(178, 38)
        Me.txtGiora.TabIndex = 70
        Me.txtGiora.TabStop = False
        '
        'txtGiovao
        '
        Me.txtGiovao.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.txtGiovao.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtGiovao.Location = New System.Drawing.Point(9, 26)
        Me.txtGiovao.Name = "txtGiovao"
        Me.txtGiovao.ReadOnly = True
        Me.txtGiovao.Size = New System.Drawing.Size(177, 40)
        Me.txtGiovao.TabIndex = 55
        Me.txtGiovao.TabStop = False
        '
        'txtSothe
        '
        Me.txtSothe.BackColor = System.Drawing.SystemColors.Info
        Me.txtSothe.Font = New System.Drawing.Font("Tahoma", 20.25!)
        Me.txtSothe.ForeColor = System.Drawing.Color.Red
        Me.txtSothe.Location = New System.Drawing.Point(386, 26)
        Me.txtSothe.Name = "txtSothe"
        Me.txtSothe.Size = New System.Drawing.Size(228, 40)
        Me.txtSothe.TabIndex = 52
        '
        'TimerProgress
        '
        Me.TimerProgress.Enabled = True
        Me.TimerProgress.Interval = 30
        '
        'frmChinh8
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1344, 705)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox5)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmChinh8"
        Me.Text = "HỆ THỐNG HỖ TRỢ GIỮ XE THÔNG MINH"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.picVaoTruoc, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picVaoSau, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.imgVaoSau, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.imgVaoTruoc, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        CType(Me.picRaTruoc, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.imgRaSau, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.imgRaTruoc, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.picRaSau, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Timer_vao As System.Windows.Forms.Timer
    Friend WithEvents ĐổiMậtKhẩuToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents CôngCụToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BáoMấtThẻToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BáoHưThẻToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ĐổiThưMụcLưuẢnhToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ChọnCameraToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TìmKiếmToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ThốngKêToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NgườiDùngToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnAdmin As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents picRaSau As System.Windows.Forms.PictureBox
    Friend WithEvents picRaTruoc As System.Windows.Forms.PictureBox
    Friend WithEvents imgRaSau As Emgu.CV.UI.ImageBox
    Friend WithEvents imgRaTruoc As Emgu.CV.UI.ImageBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents imgVaoSau As Emgu.CV.UI.ImageBox
    Friend WithEvents imgVaoTruoc As Emgu.CV.UI.ImageBox
    Friend WithEvents ofDigImage As System.Windows.Forms.OpenFileDialog
    Friend WithEvents bwWC As System.ComponentModel.BackgroundWorker
    Friend WithEvents Timer_ra As System.Windows.Forms.Timer
    Friend WithEvents picVaoSau As System.Windows.Forms.PictureBox
    Friend WithEvents cbLoaixevao As System.Windows.Forms.ComboBox
    Friend WithEvents cbLoaixera As System.Windows.Forms.ComboBox
    Friend WithEvents Timer_xoara As System.Windows.Forms.Timer
    Friend WithEvents Timer_xoavao As System.Windows.Forms.Timer
    Friend WithEvents XeTrongBãiToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents picVaoTruoc As System.Windows.Forms.PictureBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents lblLuong As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtNgayvao As System.Windows.Forms.TextBox
    Friend WithEvents txtNgayra As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtSothe As System.Windows.Forms.TextBox
    Friend WithEvents txtBienSoCu As System.Windows.Forms.TextBox
    Friend WithEvents txtBienSoVao As System.Windows.Forms.TextBox
    Friend WithEvents btnDoclai As System.Windows.Forms.Button
    Friend WithEvents btndoclai2 As System.Windows.Forms.Button
    Friend WithEvents TimerProgress As System.Windows.Forms.Timer
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
    Friend WithEvents ProgressBar2 As System.Windows.Forms.ProgressBar
    Friend WithEvents txtBiensora As System.Windows.Forms.TextBox
    Friend WithEvents txtGiovao As System.Windows.Forms.TextBox
    Friend WithEvents txtGiora As System.Windows.Forms.TextBox
    Friend WithEvents CậpNhậtNhânViênToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CậpNhậtGiáTiềnToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ChấmCôngNhânViênToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
End Class
