<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmGiatien
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
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.group = New System.Windows.Forms.GroupBox()
        Me.btnThemgiatien = New System.Windows.Forms.Button()
        Me.txtGiatien = New System.Windows.Forms.NumericUpDown()
        Me.txtLoaixe = New System.Windows.Forms.TextBox()
        Me.lblGiatien = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.btnSuagiatien = New System.Windows.Forms.Button()
        Me.txtGiatien2 = New System.Windows.Forms.NumericUpDown()
        Me.cbLoaixe = New System.Windows.Forms.ComboBox()
        Me.lblGiatien2 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.dgvLoaixe = New System.Windows.Forms.DataGridView()
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.group.SuspendLayout()
        CType(Me.txtGiatien, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox6.SuspendLayout()
        CType(Me.txtGiatien2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvLoaixe, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'group
        '
        Me.group.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.group.Controls.Add(Me.btnThemgiatien)
        Me.group.Controls.Add(Me.txtGiatien)
        Me.group.Controls.Add(Me.txtLoaixe)
        Me.group.Controls.Add(Me.lblGiatien)
        Me.group.Controls.Add(Me.Label16)
        Me.group.Controls.Add(Me.Label15)
        Me.group.Dock = System.Windows.Forms.DockStyle.Top
        Me.group.Location = New System.Drawing.Point(0, 0)
        Me.group.Name = "group"
        Me.group.Size = New System.Drawing.Size(734, 59)
        Me.group.TabIndex = 1
        Me.group.TabStop = False
        Me.group.Text = "Thêm loại xe mới"
        '
        'btnThemgiatien
        '
        Me.btnThemgiatien.Location = New System.Drawing.Point(517, 12)
        Me.btnThemgiatien.Name = "btnThemgiatien"
        Me.btnThemgiatien.Size = New System.Drawing.Size(111, 37)
        Me.btnThemgiatien.TabIndex = 15
        Me.btnThemgiatien.Text = "Thêm giá tiền"
        Me.btnThemgiatien.UseVisualStyleBackColor = True
        '
        'txtGiatien
        '
        Me.txtGiatien.Location = New System.Drawing.Point(363, 20)
        Me.txtGiatien.Name = "txtGiatien"
        Me.txtGiatien.Size = New System.Drawing.Size(120, 20)
        Me.txtGiatien.TabIndex = 14
        '
        'txtLoaixe
        '
        Me.txtLoaixe.Font = New System.Drawing.Font("Tahoma", 10.0!)
        Me.txtLoaixe.Location = New System.Drawing.Point(81, 19)
        Me.txtLoaixe.Name = "txtLoaixe"
        Me.txtLoaixe.Size = New System.Drawing.Size(183, 24)
        Me.txtLoaixe.TabIndex = 13
        '
        'lblGiatien
        '
        Me.lblGiatien.AutoSize = True
        Me.lblGiatien.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGiatien.ForeColor = System.Drawing.Color.Blue
        Me.lblGiatien.Location = New System.Drawing.Point(305, 66)
        Me.lblGiatien.Name = "lblGiatien"
        Me.lblGiatien.Size = New System.Drawing.Size(0, 17)
        Me.lblGiatien.TabIndex = 11
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.Blue
        Me.Label16.Location = New System.Drawing.Point(304, 22)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(52, 17)
        Me.Label16.TabIndex = 9
        Me.Label16.Text = "Giá tiền"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.Blue
        Me.Label15.Location = New System.Drawing.Point(22, 22)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(51, 17)
        Me.Label15.TabIndex = 8
        Me.Label15.Text = "Loại xe"
        '
        'GroupBox6
        '
        Me.GroupBox6.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.GroupBox6.Controls.Add(Me.btnSuagiatien)
        Me.GroupBox6.Controls.Add(Me.txtGiatien2)
        Me.GroupBox6.Controls.Add(Me.cbLoaixe)
        Me.GroupBox6.Controls.Add(Me.lblGiatien2)
        Me.GroupBox6.Controls.Add(Me.Label18)
        Me.GroupBox6.Controls.Add(Me.Label17)
        Me.GroupBox6.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox6.Location = New System.Drawing.Point(0, 59)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(734, 66)
        Me.GroupBox6.TabIndex = 2
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "Sửa giá tiền gửi xe"
        '
        'btnSuagiatien
        '
        Me.btnSuagiatien.Location = New System.Drawing.Point(517, 19)
        Me.btnSuagiatien.Name = "btnSuagiatien"
        Me.btnSuagiatien.Size = New System.Drawing.Size(111, 37)
        Me.btnSuagiatien.TabIndex = 16
        Me.btnSuagiatien.Text = "Sửa giá tiền"
        Me.btnSuagiatien.UseVisualStyleBackColor = True
        '
        'txtGiatien2
        '
        Me.txtGiatien2.Location = New System.Drawing.Point(363, 25)
        Me.txtGiatien2.Name = "txtGiatien2"
        Me.txtGiatien2.Size = New System.Drawing.Size(120, 20)
        Me.txtGiatien2.TabIndex = 15
        '
        'cbLoaixe
        '
        Me.cbLoaixe.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbLoaixe.FormattingEnabled = True
        Me.cbLoaixe.Location = New System.Drawing.Point(81, 25)
        Me.cbLoaixe.Name = "cbLoaixe"
        Me.cbLoaixe.Size = New System.Drawing.Size(183, 21)
        Me.cbLoaixe.TabIndex = 14
        '
        'lblGiatien2
        '
        Me.lblGiatien2.AutoSize = True
        Me.lblGiatien2.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGiatien2.ForeColor = System.Drawing.Color.Blue
        Me.lblGiatien2.Location = New System.Drawing.Point(320, 86)
        Me.lblGiatien2.Name = "lblGiatien2"
        Me.lblGiatien2.Size = New System.Drawing.Size(0, 17)
        Me.lblGiatien2.TabIndex = 12
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.ForeColor = System.Drawing.Color.Blue
        Me.Label18.Location = New System.Drawing.Point(305, 27)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(52, 17)
        Me.Label18.TabIndex = 10
        Me.Label18.Text = "Giá tiền"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.ForeColor = System.Drawing.Color.Blue
        Me.Label17.Location = New System.Drawing.Point(22, 25)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(51, 17)
        Me.Label17.TabIndex = 9
        Me.Label17.Text = "Loại xe"
        '
        'dgvLoaixe
        '
        Me.dgvLoaixe.BackgroundColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.dgvLoaixe.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle8.ForeColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(53, Byte), Integer))
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvLoaixe.DefaultCellStyle = DataGridViewCellStyle8
        Me.dgvLoaixe.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvLoaixe.Location = New System.Drawing.Point(0, 125)
        Me.dgvLoaixe.Name = "dgvLoaixe"
        Me.dgvLoaixe.Size = New System.Drawing.Size(734, 267)
        Me.dgvLoaixe.TabIndex = 3
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'frmGiatien
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(734, 392)
        Me.Controls.Add(Me.dgvLoaixe)
        Me.Controls.Add(Me.GroupBox6)
        Me.Controls.Add(Me.group)
        Me.Name = "frmGiatien"
        Me.Text = "frmGiatien"
        Me.group.ResumeLayout(False)
        Me.group.PerformLayout()
        CType(Me.txtGiatien, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox6.PerformLayout()
        CType(Me.txtGiatien2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvLoaixe, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents group As System.Windows.Forms.GroupBox
    Friend WithEvents btnThemgiatien As System.Windows.Forms.Button
    Friend WithEvents txtGiatien As System.Windows.Forms.NumericUpDown
    Friend WithEvents txtLoaixe As System.Windows.Forms.TextBox
    Friend WithEvents lblGiatien As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents btnSuagiatien As System.Windows.Forms.Button
    Friend WithEvents txtGiatien2 As System.Windows.Forms.NumericUpDown
    Friend WithEvents cbLoaixe As System.Windows.Forms.ComboBox
    Friend WithEvents lblGiatien2 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents dgvLoaixe As System.Windows.Forms.DataGridView
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
End Class
