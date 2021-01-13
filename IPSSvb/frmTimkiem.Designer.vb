<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTimkiem
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmTimkiem))
        Me.Label3 = New System.Windows.Forms.Label()
        Me.picVaosau = New System.Windows.Forms.PictureBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.dgvTimkiem = New System.Windows.Forms.DataGridView()
        Me.picRasau = New System.Windows.Forms.PictureBox()
        Me.picRatruoc = New System.Windows.Forms.PictureBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.chkChinhxac = New System.Windows.Forms.CheckBox()
        Me.lblThongbao = New System.Windows.Forms.Label()
        Me.picVaotruoc = New System.Windows.Forms.PictureBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.chkThoigiantu = New System.Windows.Forms.CheckBox()
        Me.chkBienso = New System.Windows.Forms.CheckBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnTim = New System.Windows.Forms.Button()
        Me.cbNguoitruc = New System.Windows.Forms.ComboBox()
        Me.chkNguoitruc = New System.Windows.Forms.CheckBox()
        Me.cbloaixe = New System.Windows.Forms.ComboBox()
        Me.chkLoaixe = New System.Windows.Forms.CheckBox()
        Me.txtThoigiantu = New System.Windows.Forms.DateTimePicker()
        Me.txtThoigianden = New System.Windows.Forms.DateTimePicker()
        Me.txtBienso = New System.Windows.Forms.TextBox()
        CType(Me.picVaosau, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvTimkiem, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picRasau, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picRatruoc, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picVaotruoc, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(110, 281)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(91, 17)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Ảnh phía sau"
        '
        'picVaosau
        '
        Me.picVaosau.Location = New System.Drawing.Point(9, 303)
        Me.picVaosau.Name = "picVaosau"
        Me.picVaosau.Size = New System.Drawing.Size(301, 227)
        Me.picVaosau.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picVaosau.TabIndex = 1
        Me.picVaosau.TabStop = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(110, 20)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(100, 17)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Ảnh phía trước"
        '
        'dgvTimkiem
        '
        Me.dgvTimkiem.AllowUserToAddRows = False
        Me.dgvTimkiem.AllowUserToDeleteRows = False
        Me.dgvTimkiem.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgvTimkiem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvTimkiem.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvTimkiem.Location = New System.Drawing.Point(0, 109)
        Me.dgvTimkiem.MultiSelect = False
        Me.dgvTimkiem.Name = "dgvTimkiem"
        Me.dgvTimkiem.ReadOnly = True
        Me.dgvTimkiem.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvTimkiem.Size = New System.Drawing.Size(406, 531)
        Me.dgvTimkiem.TabIndex = 6
        '
        'picRasau
        '
        Me.picRasau.Location = New System.Drawing.Point(9, 303)
        Me.picRasau.Name = "picRasau"
        Me.picRasau.Size = New System.Drawing.Size(301, 227)
        Me.picRasau.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picRasau.TabIndex = 1
        Me.picRasau.TabStop = False
        '
        'picRatruoc
        '
        Me.picRatruoc.Location = New System.Drawing.Point(8, 44)
        Me.picRatruoc.Name = "picRatruoc"
        Me.picRatruoc.Size = New System.Drawing.Size(301, 227)
        Me.picRatruoc.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picRatruoc.TabIndex = 0
        Me.picRatruoc.TabStop = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(110, 281)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(91, 17)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Ảnh phía sau"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(110, 20)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(100, 17)
        Me.Label5.TabIndex = 2
        Me.Label5.Text = "Ảnh phía trước"
        '
        'chkChinhxac
        '
        Me.chkChinhxac.AutoSize = True
        Me.chkChinhxac.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkChinhxac.Location = New System.Drawing.Point(357, 24)
        Me.chkChinhxac.Name = "chkChinhxac"
        Me.chkChinhxac.Size = New System.Drawing.Size(131, 17)
        Me.chkChinhxac.TabIndex = 12
        Me.chkChinhxac.Text = "Tìm chính xác biển số"
        Me.chkChinhxac.UseVisualStyleBackColor = True
        '
        'lblThongbao
        '
        Me.lblThongbao.AutoSize = True
        Me.lblThongbao.ForeColor = System.Drawing.Color.Red
        Me.lblThongbao.Location = New System.Drawing.Point(612, 85)
        Me.lblThongbao.Name = "lblThongbao"
        Me.lblThongbao.Size = New System.Drawing.Size(0, 17)
        Me.lblThongbao.TabIndex = 11
        '
        'picVaotruoc
        '
        Me.picVaotruoc.Location = New System.Drawing.Point(9, 44)
        Me.picVaotruoc.Name = "picVaotruoc"
        Me.picVaotruoc.Size = New System.Drawing.Size(301, 227)
        Me.picVaotruoc.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picVaotruoc.TabIndex = 0
        Me.picVaotruoc.TabStop = False
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Label4)
        Me.GroupBox3.Controls.Add(Me.Label5)
        Me.GroupBox3.Controls.Add(Me.picVaosau)
        Me.GroupBox3.Controls.Add(Me.picVaotruoc)
        Me.GroupBox3.Dock = System.Windows.Forms.DockStyle.Right
        Me.GroupBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.Location = New System.Drawing.Point(406, 109)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(319, 531)
        Me.GroupBox3.TabIndex = 8
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Ảnh xe vào"
        '
        'chkThoigiantu
        '
        Me.chkThoigiantu.AutoSize = True
        Me.chkThoigiantu.Location = New System.Drawing.Point(13, 52)
        Me.chkThoigiantu.Name = "chkThoigiantu"
        Me.chkThoigiantu.Size = New System.Drawing.Size(102, 21)
        Me.chkThoigiantu.TabIndex = 9
        Me.chkThoigiantu.Text = "Thời gian từ"
        Me.chkThoigiantu.UseVisualStyleBackColor = True
        '
        'chkBienso
        '
        Me.chkBienso.AutoSize = True
        Me.chkBienso.Location = New System.Drawing.Point(13, 21)
        Me.chkBienso.Name = "chkBienso"
        Me.chkBienso.Size = New System.Drawing.Size(74, 21)
        Me.chkBienso.TabIndex = 8
        Me.chkBienso.Text = "Biển số"
        Me.chkBienso.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(225, 55)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(32, 17)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "đến"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.picRasau)
        Me.GroupBox2.Controls.Add(Me.picRatruoc)
        Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Right
        Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(725, 109)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(319, 531)
        Me.GroupBox2.TabIndex = 7
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Ảnh xe ra"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtBienso)
        Me.GroupBox1.Controls.Add(Me.txtThoigianden)
        Me.GroupBox1.Controls.Add(Me.txtThoigiantu)
        Me.GroupBox1.Controls.Add(Me.btnTim)
        Me.GroupBox1.Controls.Add(Me.cbNguoitruc)
        Me.GroupBox1.Controls.Add(Me.chkNguoitruc)
        Me.GroupBox1.Controls.Add(Me.cbloaixe)
        Me.GroupBox1.Controls.Add(Me.chkLoaixe)
        Me.GroupBox1.Controls.Add(Me.chkChinhxac)
        Me.GroupBox1.Controls.Add(Me.lblThongbao)
        Me.GroupBox1.Controls.Add(Me.chkThoigiantu)
        Me.GroupBox1.Controls.Add(Me.chkBienso)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1044, 109)
        Me.GroupBox1.TabIndex = 5
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Nội dung tìm kiếm"
        '
        'btnTim
        '
        Me.btnTim.Location = New System.Drawing.Point(899, 34)
        Me.btnTim.Name = "btnTim"
        Me.btnTim.Size = New System.Drawing.Size(89, 39)
        Me.btnTim.TabIndex = 17
        Me.btnTim.Text = "Tìm"
        Me.btnTim.UseVisualStyleBackColor = True
        '
        'cbNguoitruc
        '
        Me.cbNguoitruc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbNguoitruc.Enabled = False
        Me.cbNguoitruc.FormattingEnabled = True
        Me.cbNguoitruc.Location = New System.Drawing.Point(606, 55)
        Me.cbNguoitruc.Name = "cbNguoitruc"
        Me.cbNguoitruc.Size = New System.Drawing.Size(224, 24)
        Me.cbNguoitruc.TabIndex = 16
        '
        'chkNguoitruc
        '
        Me.chkNguoitruc.AutoSize = True
        Me.chkNguoitruc.Location = New System.Drawing.Point(505, 54)
        Me.chkNguoitruc.Name = "chkNguoitruc"
        Me.chkNguoitruc.Size = New System.Drawing.Size(92, 21)
        Me.chkNguoitruc.TabIndex = 15
        Me.chkNguoitruc.Text = "Người trực"
        Me.chkNguoitruc.UseVisualStyleBackColor = True
        '
        'cbloaixe
        '
        Me.cbloaixe.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbloaixe.Enabled = False
        Me.cbloaixe.FormattingEnabled = True
        Me.cbloaixe.Location = New System.Drawing.Point(606, 22)
        Me.cbloaixe.Name = "cbloaixe"
        Me.cbloaixe.Size = New System.Drawing.Size(224, 24)
        Me.cbloaixe.TabIndex = 14
        '
        'chkLoaixe
        '
        Me.chkLoaixe.AutoSize = True
        Me.chkLoaixe.Location = New System.Drawing.Point(505, 21)
        Me.chkLoaixe.Name = "chkLoaixe"
        Me.chkLoaixe.Size = New System.Drawing.Size(72, 21)
        Me.chkLoaixe.TabIndex = 13
        Me.chkLoaixe.Text = "Loại xe"
        Me.chkLoaixe.UseVisualStyleBackColor = True
        '
        'txtThoigiantu
        '
        Me.txtThoigiantu.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.txtThoigiantu.Location = New System.Drawing.Point(129, 52)
        Me.txtThoigiantu.Name = "txtThoigiantu"
        Me.txtThoigiantu.Size = New System.Drawing.Size(96, 23)
        Me.txtThoigiantu.TabIndex = 18
        '
        'txtThoigianden
        '
        Me.txtThoigianden.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.txtThoigianden.Location = New System.Drawing.Point(257, 52)
        Me.txtThoigianden.Name = "txtThoigianden"
        Me.txtThoigianden.Size = New System.Drawing.Size(96, 23)
        Me.txtThoigianden.TabIndex = 19
        '
        'txtBienso
        '
        Me.txtBienso.Font = New System.Drawing.Font("Tahoma", 10.0!)
        Me.txtBienso.Location = New System.Drawing.Point(127, 19)
        Me.txtBienso.Name = "txtBienso"
        Me.txtBienso.Size = New System.Drawing.Size(224, 24)
        Me.txtBienso.TabIndex = 20
        '
        'frmTimkiem
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.ClientSize = New System.Drawing.Size(1044, 640)
        Me.Controls.Add(Me.dgvTimkiem)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmTimkiem"
        Me.Text = "Tìm kiếm"
        CType(Me.picVaosau, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvTimkiem, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picRasau, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picRatruoc, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picVaotruoc, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents picVaosau As System.Windows.Forms.PictureBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents dgvTimkiem As System.Windows.Forms.DataGridView
    Friend WithEvents picRasau As System.Windows.Forms.PictureBox
    Friend WithEvents picRatruoc As System.Windows.Forms.PictureBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents chkChinhxac As System.Windows.Forms.CheckBox
    Friend WithEvents lblThongbao As System.Windows.Forms.Label
    Friend WithEvents picVaotruoc As System.Windows.Forms.PictureBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents chkThoigiantu As System.Windows.Forms.CheckBox
    Friend WithEvents chkBienso As System.Windows.Forms.CheckBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents chkLoaixe As System.Windows.Forms.CheckBox
    Friend WithEvents cbloaixe As System.Windows.Forms.ComboBox
    Friend WithEvents cbNguoitruc As System.Windows.Forms.ComboBox
    Friend WithEvents chkNguoitruc As System.Windows.Forms.CheckBox
    Friend WithEvents btnTim As System.Windows.Forms.Button
    Friend WithEvents txtThoigianden As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtThoigiantu As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtBienso As System.Windows.Forms.TextBox
End Class
