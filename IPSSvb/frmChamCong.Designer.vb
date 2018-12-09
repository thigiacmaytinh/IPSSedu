<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmChamCong
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
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.txtThoigiandangxuat = New System.Windows.Forms.DateTimePicker()
        Me.txtThoigiandangnhap = New System.Windows.Forms.DateTimePicker()
        Me.btnTimkiem = New System.Windows.Forms.Button()
        Me.lblChamcong = New System.Windows.Forms.Label()
        Me.cbNhanvien = New System.Windows.Forms.ComboBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.dgvChamcong = New System.Windows.Forms.DataGridView()
        Me.GroupBox3.SuspendLayout()
        CType(Me.dgvChamcong, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox3
        '
        Me.GroupBox3.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.GroupBox3.Controls.Add(Me.txtThoigiandangxuat)
        Me.GroupBox3.Controls.Add(Me.txtThoigiandangnhap)
        Me.GroupBox3.Controls.Add(Me.btnTimkiem)
        Me.GroupBox3.Controls.Add(Me.lblChamcong)
        Me.GroupBox3.Controls.Add(Me.cbNhanvien)
        Me.GroupBox3.Controls.Add(Me.Label19)
        Me.GroupBox3.Controls.Add(Me.Label12)
        Me.GroupBox3.Controls.Add(Me.Label7)
        Me.GroupBox3.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox3.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.ForeColor = System.Drawing.Color.Blue
        Me.GroupBox3.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(944, 104)
        Me.GroupBox3.TabIndex = 1
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Chọn khoảng thời gian"
        '
        'txtThoigiandangxuat
        '
        Me.txtThoigiandangxuat.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.txtThoigiandangxuat.Location = New System.Drawing.Point(637, 30)
        Me.txtThoigiandangxuat.Name = "txtThoigiandangxuat"
        Me.txtThoigiandangxuat.Size = New System.Drawing.Size(119, 24)
        Me.txtThoigiandangxuat.TabIndex = 19
        '
        'txtThoigiandangnhap
        '
        Me.txtThoigiandangnhap.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.txtThoigiandangnhap.Location = New System.Drawing.Point(423, 30)
        Me.txtThoigiandangnhap.Name = "txtThoigiandangnhap"
        Me.txtThoigiandangnhap.Size = New System.Drawing.Size(119, 24)
        Me.txtThoigiandangnhap.TabIndex = 18
        '
        'btnTimkiem
        '
        Me.btnTimkiem.Location = New System.Drawing.Point(767, 24)
        Me.btnTimkiem.Name = "btnTimkiem"
        Me.btnTimkiem.Size = New System.Drawing.Size(86, 30)
        Me.btnTimkiem.TabIndex = 17
        Me.btnTimkiem.Text = "Tìm kiếm"
        Me.btnTimkiem.UseVisualStyleBackColor = True
        '
        'lblChamcong
        '
        Me.lblChamcong.AutoSize = True
        Me.lblChamcong.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblChamcong.ForeColor = System.Drawing.Color.Blue
        Me.lblChamcong.Location = New System.Drawing.Point(129, 71)
        Me.lblChamcong.Name = "lblChamcong"
        Me.lblChamcong.Size = New System.Drawing.Size(0, 17)
        Me.lblChamcong.TabIndex = 16
        '
        'cbNhanvien
        '
        Me.cbNhanvien.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbNhanvien.FormattingEnabled = True
        Me.cbNhanvien.Location = New System.Drawing.Point(122, 24)
        Me.cbNhanvien.Name = "cbNhanvien"
        Me.cbNhanvien.Size = New System.Drawing.Size(210, 24)
        Me.cbNhanvien.TabIndex = 15
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.ForeColor = System.Drawing.Color.Blue
        Me.Label19.Location = New System.Drawing.Point(11, 26)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(105, 17)
        Me.Label19.TabIndex = 14
        Me.Label19.Text = "Chọn nhân viên"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.Blue
        Me.Label12.Location = New System.Drawing.Point(558, 30)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(73, 17)
        Me.Label12.TabIndex = 10
        Me.Label12.Text = "Đến ngày:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Blue
        Me.Label7.Location = New System.Drawing.Point(352, 30)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(65, 17)
        Me.Label7.TabIndex = 8
        Me.Label7.Text = "Từ ngày:"
        '
        'dgvChamcong
        '
        Me.dgvChamcong.AllowUserToAddRows = False
        Me.dgvChamcong.AllowUserToDeleteRows = False
        Me.dgvChamcong.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgvChamcong.BackgroundColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.dgvChamcong.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(53, Byte), Integer))
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvChamcong.DefaultCellStyle = DataGridViewCellStyle4
        Me.dgvChamcong.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvChamcong.Location = New System.Drawing.Point(0, 104)
        Me.dgvChamcong.Name = "dgvChamcong"
        Me.dgvChamcong.ReadOnly = True
        Me.dgvChamcong.Size = New System.Drawing.Size(944, 558)
        Me.dgvChamcong.TabIndex = 2
        '
        'frmChamCong
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(944, 662)
        Me.Controls.Add(Me.dgvChamcong)
        Me.Controls.Add(Me.GroupBox3)
        Me.Name = "frmChamCong"
        Me.Text = "Chấm công nhân viên"
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.dgvChamcong, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents txtThoigiandangxuat As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtThoigiandangnhap As System.Windows.Forms.DateTimePicker
    Friend WithEvents btnTimkiem As System.Windows.Forms.Button
    Friend WithEvents lblChamcong As System.Windows.Forms.Label
    Friend WithEvents cbNhanvien As System.Windows.Forms.ComboBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents dgvChamcong As System.Windows.Forms.DataGridView
End Class
