<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmThongke
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmThongke))
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.btnThongke = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cbDieukienthongke = New System.Windows.Forms.ComboBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.ListView1 = New System.Windows.Forms.ListView()
        Me.cl1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.cl2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.PrintPreviewDialog1 = New System.Windows.Forms.PrintPreviewDialog()
        Me.txtNgaythongkedau = New System.Windows.Forms.DateTimePicker()
        Me.txtNgaythongkecuoi = New System.Windows.Forms.DateTimePicker()
        Me.GroupBox4.SuspendLayout()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox4
        '
        Me.GroupBox4.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.GroupBox4.Controls.Add(Me.txtNgaythongkecuoi)
        Me.GroupBox4.Controls.Add(Me.txtNgaythongkedau)
        Me.GroupBox4.Controls.Add(Me.btnThongke)
        Me.GroupBox4.Controls.Add(Me.Label1)
        Me.GroupBox4.Controls.Add(Me.cbDieukienthongke)
        Me.GroupBox4.Controls.Add(Me.Label20)
        Me.GroupBox4.Controls.Add(Me.Label13)
        Me.GroupBox4.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox4.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox4.ForeColor = System.Drawing.Color.Blue
        Me.GroupBox4.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(602, 99)
        Me.GroupBox4.TabIndex = 2
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Chọn khoảng thời gian"
        '
        'btnThongke
        '
        Me.btnThongke.Font = New System.Drawing.Font("Tahoma", 8.2!)
        Me.btnThongke.Location = New System.Drawing.Point(360, 56)
        Me.btnThongke.Name = "btnThongke"
        Me.btnThongke.Size = New System.Drawing.Size(86, 30)
        Me.btnThongke.TabIndex = 18
        Me.btnThongke.Text = "Thống kê"
        Me.btnThongke.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Blue
        Me.Label1.Location = New System.Drawing.Point(12, 26)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(65, 17)
        Me.Label1.TabIndex = 17
        Me.Label1.Text = "Từ ngày:"
        '
        'cbDieukienthongke
        '
        Me.cbDieukienthongke.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbDieukienthongke.FormattingEnabled = True
        Me.cbDieukienthongke.Items.AddRange(New Object() {"Doanh thu (đồng)", "Số lượng xe (chiếc)", "Thời gian trực (phút)"})
        Me.cbDieukienthongke.Location = New System.Drawing.Point(126, 60)
        Me.cbDieukienthongke.Name = "cbDieukienthongke"
        Me.cbDieukienthongke.Size = New System.Drawing.Size(199, 24)
        Me.cbDieukienthongke.TabIndex = 14
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.ForeColor = System.Drawing.Color.Blue
        Me.Label20.Location = New System.Drawing.Point(15, 63)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(103, 17)
        Me.Label20.TabIndex = 13
        Me.Label20.Text = "Thống kê theo:"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.Blue
        Me.Label13.Location = New System.Drawing.Point(214, 26)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(73, 17)
        Me.Label13.TabIndex = 10
        Me.Label13.Text = "Đến ngày:"
        '
        'ListView1
        '
        Me.ListView1.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.cl1, Me.cl2})
        Me.ListView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ListView1.FullRowSelect = True
        Me.ListView1.Location = New System.Drawing.Point(0, 99)
        Me.ListView1.Name = "ListView1"
        Me.ListView1.Size = New System.Drawing.Size(602, 195)
        Me.ListView1.TabIndex = 15
        Me.ListView1.UseCompatibleStateImageBehavior = False
        Me.ListView1.View = System.Windows.Forms.View.Details
        '
        'cl1
        '
        Me.cl1.Text = ""
        Me.cl1.Width = 215
        '
        'cl2
        '
        Me.cl2.Text = ""
        Me.cl2.Width = 165
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'PrintPreviewDialog1
        '
        Me.PrintPreviewDialog1.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.PrintPreviewDialog1.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.PrintPreviewDialog1.ClientSize = New System.Drawing.Size(400, 300)
        Me.PrintPreviewDialog1.Enabled = True
        Me.PrintPreviewDialog1.Icon = CType(resources.GetObject("PrintPreviewDialog1.Icon"), System.Drawing.Icon)
        Me.PrintPreviewDialog1.Name = "PrintPreviewDialog1"
        Me.PrintPreviewDialog1.Visible = False
        '
        'txtNgaythongkedau
        '
        Me.txtNgaythongkedau.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.txtNgaythongkedau.Location = New System.Drawing.Point(92, 23)
        Me.txtNgaythongkedau.Name = "txtNgaythongkedau"
        Me.txtNgaythongkedau.Size = New System.Drawing.Size(107, 24)
        Me.txtNgaythongkedau.TabIndex = 19
        '
        'txtNgaythongkecuoi
        '
        Me.txtNgaythongkecuoi.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.txtNgaythongkecuoi.Location = New System.Drawing.Point(326, 23)
        Me.txtNgaythongkecuoi.Name = "txtNgaythongkecuoi"
        Me.txtNgaythongkecuoi.Size = New System.Drawing.Size(107, 24)
        Me.txtNgaythongkecuoi.TabIndex = 20
        '
        'frmThongke
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(602, 294)
        Me.Controls.Add(Me.ListView1)
        Me.Controls.Add(Me.GroupBox4)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmThongke"
        Me.Text = "Thống kê"
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents cbDieukienthongke As System.Windows.Forms.ComboBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents ListView1 As System.Windows.Forms.ListView
    Friend WithEvents cl1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents cl2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents PrintPreviewDialog1 As System.Windows.Forms.PrintPreviewDialog
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnThongke As System.Windows.Forms.Button
    Friend WithEvents txtNgaythongkecuoi As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtNgaythongkedau As System.Windows.Forms.DateTimePicker
End Class
