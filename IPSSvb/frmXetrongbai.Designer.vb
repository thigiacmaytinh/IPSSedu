<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmXetrongbai
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
        Me.dgvTimkiem = New System.Windows.Forms.DataGridView()
        Me.picVaotruoc = New System.Windows.Forms.PictureBox()
        Me.picVaosau = New System.Windows.Forms.PictureBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        CType(Me.dgvTimkiem, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picVaotruoc, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picVaosau, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgvTimkiem
        '
        Me.dgvTimkiem.AllowUserToAddRows = False
        Me.dgvTimkiem.AllowUserToDeleteRows = False
        Me.dgvTimkiem.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgvTimkiem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvTimkiem.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvTimkiem.Location = New System.Drawing.Point(0, 0)
        Me.dgvTimkiem.MultiSelect = False
        Me.dgvTimkiem.Name = "dgvTimkiem"
        Me.dgvTimkiem.ReadOnly = True
        Me.dgvTimkiem.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvTimkiem.Size = New System.Drawing.Size(654, 640)
        Me.dgvTimkiem.TabIndex = 10
        '
        'picVaotruoc
        '
        Me.picVaotruoc.Location = New System.Drawing.Point(9, 37)
        Me.picVaotruoc.Name = "picVaotruoc"
        Me.picVaotruoc.Size = New System.Drawing.Size(374, 276)
        Me.picVaotruoc.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picVaotruoc.TabIndex = 0
        Me.picVaotruoc.TabStop = False
        '
        'picVaosau
        '
        Me.picVaosau.Location = New System.Drawing.Point(9, 336)
        Me.picVaosau.Name = "picVaosau"
        Me.picVaosau.Size = New System.Drawing.Size(374, 298)
        Me.picVaosau.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.picVaosau.TabIndex = 1
        Me.picVaosau.TabStop = False
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
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(110, 316)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(91, 17)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Ảnh phía sau"
        '
        'GroupBox3
        '
        Me.GroupBox3.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.GroupBox3.Controls.Add(Me.Label4)
        Me.GroupBox3.Controls.Add(Me.Label5)
        Me.GroupBox3.Controls.Add(Me.picVaosau)
        Me.GroupBox3.Controls.Add(Me.picVaotruoc)
        Me.GroupBox3.Dock = System.Windows.Forms.DockStyle.Right
        Me.GroupBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.Location = New System.Drawing.Point(654, 0)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(390, 640)
        Me.GroupBox3.TabIndex = 12
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Ảnh xe vào"
        '
        'frmXetrongbai
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1044, 640)
        Me.Controls.Add(Me.dgvTimkiem)
        Me.Controls.Add(Me.GroupBox3)
        Me.Name = "frmXetrongbai"
        Me.Text = "Xe hiện có trong bãi"
        CType(Me.dgvTimkiem, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picVaotruoc, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picVaosau, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dgvTimkiem As System.Windows.Forms.DataGridView
    Friend WithEvents picVaotruoc As System.Windows.Forms.PictureBox
    Friend WithEvents picVaosau As System.Windows.Forms.PictureBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
End Class
