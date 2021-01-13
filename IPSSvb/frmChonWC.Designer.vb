<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmChonWC
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmChonWC))
        Me.btnOk = New System.Windows.Forms.Button()
        Me.cbRasau = New System.Windows.Forms.ComboBox()
        Me.cbRatruoc = New System.Windows.Forms.ComboBox()
        Me.cbVaosau = New System.Windows.Forms.ComboBox()
        Me.rdRasau = New System.Windows.Forms.RadioButton()
        Me.ImageBox1 = New Emgu.CV.UI.ImageBox()
        Me.rdRatruoc = New System.Windows.Forms.RadioButton()
        Me.rdVaosau = New System.Windows.Forms.RadioButton()
        Me.rdVaotruoc = New System.Windows.Forms.RadioButton()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cbVaotruoc = New System.Windows.Forms.ComboBox()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        CType(Me.ImageBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnOk
        '
        Me.btnOk.Location = New System.Drawing.Point(91, 161)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.Size = New System.Drawing.Size(75, 23)
        Me.btnOk.TabIndex = 16
        Me.btnOk.Text = "OK"
        Me.btnOk.UseVisualStyleBackColor = True
        '
        'cbRasau
        '
        Me.cbRasau.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbRasau.Enabled = False
        Me.cbRasau.FormattingEnabled = True
        Me.cbRasau.Location = New System.Drawing.Point(193, 101)
        Me.cbRasau.Name = "cbRasau"
        Me.cbRasau.Size = New System.Drawing.Size(121, 21)
        Me.cbRasau.TabIndex = 15
        '
        'cbRatruoc
        '
        Me.cbRatruoc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbRatruoc.Enabled = False
        Me.cbRatruoc.FormattingEnabled = True
        Me.cbRatruoc.Location = New System.Drawing.Point(193, 74)
        Me.cbRatruoc.Name = "cbRatruoc"
        Me.cbRatruoc.Size = New System.Drawing.Size(121, 21)
        Me.cbRatruoc.TabIndex = 14
        '
        'cbVaosau
        '
        Me.cbVaosau.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbVaosau.Enabled = False
        Me.cbVaosau.FormattingEnabled = True
        Me.cbVaosau.Location = New System.Drawing.Point(193, 47)
        Me.cbVaosau.Name = "cbVaosau"
        Me.cbVaosau.Size = New System.Drawing.Size(121, 21)
        Me.cbVaosau.TabIndex = 13
        '
        'rdRasau
        '
        Me.rdRasau.AutoSize = True
        Me.rdRasau.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdRasau.Location = New System.Drawing.Point(16, 100)
        Me.rdRasau.Name = "rdRasau"
        Me.rdRasau.Size = New System.Drawing.Size(141, 21)
        Me.rdRasau.TabIndex = 12
        Me.rdRasau.TabStop = True
        Me.rdRasau.Text = "Luồng ra phía sau"
        Me.rdRasau.UseVisualStyleBackColor = True
        '
        'ImageBox1
        '
        Me.ImageBox1.Location = New System.Drawing.Point(12, 11)
        Me.ImageBox1.Name = "ImageBox1"
        Me.ImageBox1.Size = New System.Drawing.Size(260, 214)
        Me.ImageBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.ImageBox1.TabIndex = 4
        Me.ImageBox1.TabStop = False
        '
        'rdRatruoc
        '
        Me.rdRatruoc.AutoSize = True
        Me.rdRatruoc.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdRatruoc.Location = New System.Drawing.Point(16, 73)
        Me.rdRatruoc.Name = "rdRatruoc"
        Me.rdRatruoc.Size = New System.Drawing.Size(150, 21)
        Me.rdRatruoc.TabIndex = 11
        Me.rdRatruoc.TabStop = True
        Me.rdRatruoc.Text = "Luồng ra phía trước"
        Me.rdRatruoc.UseVisualStyleBackColor = True
        '
        'rdVaosau
        '
        Me.rdVaosau.AutoSize = True
        Me.rdVaosau.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdVaosau.Location = New System.Drawing.Point(16, 46)
        Me.rdVaosau.Name = "rdVaosau"
        Me.rdVaosau.Size = New System.Drawing.Size(151, 21)
        Me.rdVaosau.TabIndex = 10
        Me.rdVaosau.TabStop = True
        Me.rdVaosau.Text = "Luồng vào phía sau"
        Me.rdVaosau.UseVisualStyleBackColor = True
        '
        'rdVaotruoc
        '
        Me.rdVaotruoc.AutoSize = True
        Me.rdVaotruoc.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdVaotruoc.Location = New System.Drawing.Point(16, 19)
        Me.rdVaotruoc.Name = "rdVaotruoc"
        Me.rdVaotruoc.Size = New System.Drawing.Size(160, 21)
        Me.rdVaotruoc.TabIndex = 9
        Me.rdVaotruoc.TabStop = True
        Me.rdVaotruoc.Text = "Luồng vào phía trước"
        Me.rdVaotruoc.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnOk)
        Me.GroupBox1.Controls.Add(Me.cbRasau)
        Me.GroupBox1.Controls.Add(Me.cbRatruoc)
        Me.GroupBox1.Controls.Add(Me.cbVaosau)
        Me.GroupBox1.Controls.Add(Me.rdRasau)
        Me.GroupBox1.Controls.Add(Me.rdRatruoc)
        Me.GroupBox1.Controls.Add(Me.rdVaosau)
        Me.GroupBox1.Controls.Add(Me.rdVaotruoc)
        Me.GroupBox1.Controls.Add(Me.cbVaotruoc)
        Me.GroupBox1.Location = New System.Drawing.Point(278, 11)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(343, 213)
        Me.GroupBox1.TabIndex = 5
        Me.GroupBox1.TabStop = False
        '
        'cbVaotruoc
        '
        Me.cbVaotruoc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbVaotruoc.Enabled = False
        Me.cbVaotruoc.FormattingEnabled = True
        Me.cbVaotruoc.Location = New System.Drawing.Point(193, 20)
        Me.cbVaotruoc.Name = "cbVaotruoc"
        Me.cbVaotruoc.Size = New System.Drawing.Size(121, 21)
        Me.cbVaotruoc.TabIndex = 4
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        Me.Timer1.Interval = 35
        '
        'frmChonWC
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.ClientSize = New System.Drawing.Size(633, 237)
        Me.Controls.Add(Me.ImageBox1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmChonWC"
        Me.Text = "Chọn Camera"
        CType(Me.ImageBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnOk As System.Windows.Forms.Button
    Friend WithEvents cbRasau As System.Windows.Forms.ComboBox
    Friend WithEvents cbRatruoc As System.Windows.Forms.ComboBox
    Friend WithEvents cbVaosau As System.Windows.Forms.ComboBox
    Friend WithEvents rdRasau As System.Windows.Forms.RadioButton
    Friend WithEvents ImageBox1 As Emgu.CV.UI.ImageBox
    Friend WithEvents rdRatruoc As System.Windows.Forms.RadioButton
    Friend WithEvents rdVaosau As System.Windows.Forms.RadioButton
    Friend WithEvents rdVaotruoc As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cbVaotruoc As System.Windows.Forms.ComboBox
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
End Class
