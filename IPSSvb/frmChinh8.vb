Imports Emgu.CV.Structure
Imports Emgu.CV
Imports System.IO
Imports System.Data.SqlClient

Public Class frmChinh8
    'Dim frm As Image(Of Bgr, Byte)
    Dim cap0 As Capture
    Dim cap1 As Capture
    Dim cap2 As Capture
    Dim cap3 As Capture
    Dim cmr0 As Byte
    Dim cmr1 As Byte
    Dim cmr2 As Byte
    Dim cmr3 As Byte
    Public manv As String = "admin" 'ghi nhật ký làm việc của nhân viên
    Dim giatien As DataTable
    'Dim bienso As String
    Dim regex As New System.Text.RegularExpressions.Regex("\d\d-[A-Z][0-9A-Z]-\d{4,5}")
    Dim anhVaoTruoc As Image(Of Bgr, Byte)
    Dim anhVaoSau As Image(Of Bgr, Byte)
    Dim anhRaTruoc As Image(Of Bgr, Byte)
    Dim anhRaSau As Image(Of Bgr, Byte)

#Region "commonFunction"

    Sub startTimbiensoVao()
        txtBienSoVao.Text = ""
        Timer_vao.Enabled = True
        ProgressBar1.Visible = True
        btnDoclai.Text = "Ngưng đọc"
    End Sub
    Sub stopTimbiensoVao()
        Timer_vao.Enabled = False
        ProgressBar1.Visible = False
        btnDoclai.Text = "Đọc..."
    End Sub
    Sub startTimbiensoRa()
        txtBiensora.Text = ""
        Timer_ra.Enabled = True
        ProgressBar2.Visible = True
        btndoclai2.Text = "Ngưng đọc"
    End Sub
    Sub stopTimbiensoRa()
        Timer_ra.Enabled = False
        ProgressBar2.Visible = False
        btndoclai2.Text = "Đọc..."
    End Sub
    Sub captureWC()
        'đọc wc
        If g_regKey.GetValue("camera0").ToString() <> "" Then
            Try
                cmr0 = CByte(g_regKey.GetValue("camera0"))
                cap0 = New Capture(cmr0)
                AddHandler cap0.ImageGrabbed, AddressOf wc0
                cap0.Start()
            Catch ex As Exception
                MsgBox("Không tìm thấy Webcam vào sau")
            End Try
        End If

        'If g_regKey.GetValue("camera1").ToString() <> "" Then
        '    Try
        '        cmr1 = CByte(g_regKey.GetValue("camera1"))
        '        cap1 = New Capture(cmr1)
        '        AddHandler cap1.ImageGrabbed, AddressOf wc1
        '        cap1.Start()
        '    Catch ex As Exception
        '        MsgBox("Không tìm thấy Webcam vào trước")
        '    End Try

        'End If
        'If g_regKey.GetValue("camera2").ToString() <> "" Then
        '    Try
        '        cmr2 = CByte(g_regKey.GetValue("camera2"))
        '        cap2 = New Capture(cmr2)
        '        AddHandler cap2.ImageGrabbed, AddressOf wc2
        '        cap2.Start()
        '    Catch ex As Exception
        '        MsgBox("Không tìm thấy Webcam ra sau")
        '    End Try
        'End If

        'If g_regKey.GetValue("camera3").ToString() <> "" Then
        '    Try
        '        cmr3 = CByte(g_regKey.GetValue("camera3"))
        '        cap3 = New Capture(cmr3)
        '        AddHandler cap3.ImageGrabbed, AddressOf wc3
        '        cap3.Start()
        '    Catch ex As Exception
        '        MsgBox("Không tìm thấy Webcam ra trước")
        '    End Try
        'End If
    End Sub
    Private Sub wc0(sender As Object, arg As EventArgs)
        'imgVaoSau.Image = cap0.QueryFrame()
        Dim frame = New Mat()
        cap0.Retrieve(frame)
        imgVaoSau.Image = frame
    End Sub
    Private Sub wc1()
        imgVaoTruoc.Image = cap1.QueryFrame()
    End Sub
    Private Sub wc2()
        imgRaSau.Image = cap2.QueryFrame()
    End Sub
    Private Sub wc3()
        imgRaTruoc.Image = cap3.QueryFrame()
    End Sub
    Function giatienxe(ByVal loaixe As String) As Integer
        Dim dr() As DataRow = giatien.Select("loaixe = '" & loaixe & "'")
        Return CInt(dr(0).Item(2))
    End Function

    Sub HideForm()
        stopTimbiensoVao()
        stopTimbiensoRa()
        Me.Hide()
    End Sub
#End Region
#Region "xeVoRa"
    Sub xevodisk()

        Dim anhtruoc As New Image(Of Bgr, Byte)(picVaoTruoc.Image)
        Dim anhsau As New Image(Of Bgr, Byte)(picVaoSau.Image)
        Dim hientai = Now
        Dim thoigian As String = hientai.ToString("yyyy-MM-dd-hh-mm-ss")
        'thêm dữ liệu xe vô
        Dim sql = "insert into xevodisk(sothe,ngaygioxevo,manv,loaixe,phiatruoc,phiasau,biensoxevo) values("
        sql &= txtSothe.Text & ",'"
        sql &= hientai.ToString("yyyy-MM-dd hh:mm:ss") & "','"
        sql &= manv & "',N'"
        sql &= cbLoaixevao.SelectedItem.ToString & "','"
        sql &= thoigian & "-vaotruoc.jpg','"
        sql &= thoigian & "-vaosau.jpg','"
        sql &= txtBiensovao.Text & "')"
        'lưu hình ảnh
        luuxedisk(sql, anhtruoc.Bitmap, anhsau.Bitmap, thoigian)
        'lưu hình ảnh để train
        'luuxeTrain(anhtruoc.Bitmap, anhsau.Bitmap, thoigian)
        'cập nhật trạng thái thẻ
#If DATA Then
        runsql("update the set giaochokhach=1 where sothe=" & txtSothe.Text)
#End If
        'thông báo trạng thái luồng
        lblLuong.Text = ""
        lblLuong.ForeColor = Color.Red
        lblLuong.BackColor = Color.Transparent
        lblLuong.Text = "MỜI XE VÀO"
        'xoá hết dữ liệu trong các control

        Timer_xoavao.Enabled = True
    End Sub
    Sub xeradisk()
        Dim anhtruoc As New Image(Of Bgr, Byte)(picRaTruoc.Image)
        Dim anhsau As New Image(Of Bgr, Byte)(picRaSau.Image)
        'Timer_vao.Enabled = False
        'hiện ảnh đã lưu lúc xe vào
        Try
            picRaTruoc.Image = Image.FromFile(g_savedir & tim("select top 1 phiatruoc from xevodisk where sothe=" & txtSothe.Text & " order by ngaygioxevo desc").ToString())
        Catch ex As Exception
            lblLuong.Text = "Không tìm thấy ảnh vào phía trước"
        End Try
        Try
            picRaSau.Image = Image.FromFile(g_savedir & tim("select top 1 phiasau from xevodisk where sothe=" & txtSothe.Text & " order by ngaygioxevo desc").ToString())
        Catch ex As Exception
            lblLuong.Text = "Không tìm thấy ảnh vào phía sau"
        End Try
        Try
            txtBienSoCu.Text = tim("select top 1 biensoxevo from xevodisk where sothe=" & txtSothe.Text & "order by ngaygioxevo desc").ToString()
        Catch ex As Exception
            txtBiensovao.Text = ""
        End Try
        'hiện dữ liệu đã lưu lúc xe vào
        'nếu xe vào là xe đạp
        ketnoi()
        Dim thoigianxevo As Date
        If cbLoaixevao.SelectedIndex > -1 AndAlso cbLoaixevao.SelectedItem.ToString = "Xe đạp" Then
            Dim comm As New SqlCommand("select top 1 ngaygioxevo,loaixe from xevodisk where sothe=" & txtSothe.Text & " order by ngaygioxevo desc", g_conn)
            Dim dr As SqlDataReader = comm.ExecuteReader()

            Do While dr.Read
                txtNgayvao.Text = CDate(dr.GetValue(0)).ToString("dd/MM/yyyy")
                thoigianxevo = CDate(dr.GetValue(0))
                txtGiovao.Text = CDate(dr.GetValue(0)).ToString("hh:mm:ss")
            Loop
        Else
            Dim comm As New SqlCommand("select top 1 ngaygioxevo,loaixe,biensoxevo from xevodisk where sothe=" & txtSothe.Text & " order by ngaygioxevo desc", g_conn)
            ketnoi()
            Dim dr As SqlDataReader = comm.ExecuteReader()
            Do While dr.Read
                txtNgayvao.Text = CDate(dr.GetValue(0)).ToString("dd/MM/yyyy")
                thoigianxevo = CDate(dr.GetValue(0))
                txtGiovao.Text = CDate(dr.GetValue(0)).ToString("hh:mm:ss")
                cbLoaixevao.SelectedItem = dr.GetValue(1).ToString
                'txtBiensovao.Text = dr.GetValue(2).ToString
            Loop
        End If
        ngatketnoi()

        'biến hiện tại có tác dụng lưu thời gian CSDL và ảnh giống nhau
        Dim hientai As Date = Now
        Dim thoigian As String = hientai.ToString("yyyy-MM-dd-hh-mm-ss")
        'thêm dữ liệu xe vô
        Dim sql = "insert into xeradisk(sothe,ngaygioxevo,manv,ngaygioxera,phiatruoc,phiasau,biensoxera,giatien) values("
        sql &= txtSothe.Text & ",'"
        sql &= thoigianxevo.ToString("yyyy-MM-dd hh:mm:ss") & "',N'"
        sql &= manv & "','"
        sql &= hientai.ToString("yyyy-MM-dd hh:mm:ss") & "','"
        sql &= thoigian & "-ratruoc.jpg','"
        sql &= thoigian & "-rasau.jpg','"
        sql &= txtBiensora.Text & "',"
        sql &= giatienxe(cbLoaixevao.SelectedItem.ToString()) & ")"
        'kiểm tra thông tin xe vào - ra có giống nhau không 
        If cbLoaixevao.SelectedItem.ToString() = "Xe máy" Then
            If txtBiensora.Text <> "" AndAlso txtBiensora.Text <> txtBienSoVao.Text Then
                lblLuong.Text = "Biển số không giống nhau"
            ElseIf txtBiensora.Text <> "" AndAlso txtBiensora.Text = txtBienSoVao.Text Then
                lblLuong.ForeColor = Color.Blue
                lblLuong.BackColor = Color.Transparent
                lblLuong.Text = ""
                lblLuong.Text = "MỜI XE RA"
                If picRaTruoc.Image Is Nothing Then
                    luuxedisk(sql, anhsau.Bitmap, thoigian)
                Else
                    luuxedisk(sql, anhtruoc.Bitmap, anhsau.Bitmap, thoigian)
                    'lưu hình ảnh để train
                    'luuxeTrain(anhtruoc.Bitmap, anhsau.Bitmap, thoigian)
                End If
                runsql("update the set giaochokhach=0 where sothe=" & txtSothe.Text)
            End If
            'loại xe là xe đạp
        Else
            lblLuong.Text = ""
            lblLuong.BackColor = Color.Transparent
            lblLuong.ForeColor = Color.Blue
            lblLuong.Text = "MỜI XE RA"
            If imgRaTruoc.Image Is Nothing Then
                luuxedisk(sql, anhsau.Bitmap, hientai.ToString())
            Else
                luuxedisk(sql, anhtruoc.Bitmap, anhsau.Bitmap, thoigian)
                'lưu hình ảnh để train
                'luuxeTrain(anhtruoc.Bitmap, anhsau.Bitmap, thoigian)
            End If
            runsql("update the set giaochokhach=0 where sothe=" & txtSothe.Text)
        End If
        'khi xe ra thì tiếp tục đọc biển số xe
        Timer_xoara.Enabled = True
    End Sub
    Sub xevaora()
        lblLuong.Text = ""
#If DATA Then
        Dim giaochokhach = tim("select giaochokhach from the where sothe=" & txtSothe.Text & " and chuamat=1")
        If giaochokhach Is Nothing Then
            lblLuong.Text = "Thẻ không tồn tại"
            'nếu thẻ đã giao cho khách thì luồng ra
        End If
#Else
        Dim giaochokhach = False
#End If
        If CBool(giaochokhach) = True Then
            If cbLoaixera.SelectedIndex > -1 AndAlso cbLoaixera.SelectedItem.ToString = "Xe đạp" Then
                picRaTruoc.Image = imgRaTruoc.Image.Bitmap
                picRaSau.Image = imgRaSau.Image.Bitmap

                btndoclai2.Text = "Đọc..."
                ProgressBar2.Visible = False
                txtNgayra.Text = Now.ToString("dd/MM/yyyy")
                txtGiora.Text = Now.ToString("hh:mm:ss")

                xeradisk()
            Else
                If txtNgayra.Text <> "" AndAlso txtGiora.Text <> "" AndAlso txtBiensora.Text <> "" AndAlso cbLoaixera.SelectedIndex <> -1 Then
                    xeradisk()
                Else
                    lblLuong.Text = "Chưa đủ thông tin xe ra"
                End If
            End If

        ElseIf CBool(giaochokhach) = False Then
            If cbLoaixevao.SelectedIndex > -1 AndAlso cbLoaixevao.SelectedItem.ToString = "Xe đạp" Then
                picVaoTruoc.Image = imgVaoTruoc.Image.Bitmap
                picVaoSau.Image = imgVaoSau.Image.Bitmap

                btnDoclai.Text = "Đọc..."
                ProgressBar1.Visible = False
                txtNgayvao.Text = Now.ToString("dd/MM/yyyy")
                txtGiovao.Text = Now.ToString("hh:mm:ss")

                xevodisk()
            Else
                If txtNgayvao.Text <> "" AndAlso txtGiovao.Text <> "" AndAlso txtBienSoVao.Text <> "" AndAlso cbLoaixevao.SelectedIndex <> -1 Then
                    xevodisk()
                Else
                    lblLuong.Text = "Chưa đủ thông tin xe vào"
                End If
            End If
        End If
    End Sub
#End Region

#Region "timer"
    Private Sub Timer_vao_Tick(ByVal sender As Object, ByVal e As EventArgs) Handles Timer_vao.Tick
        'cứ 100 mili giây đọc biển số xe vào 1 lần cho đến khi đúng định dạng biển số thì ngưng
        'Dim anhBiensoxevao = New Image(Of Bgr, Byte)(imgVaoSau.Image.Bitmap)
        'Dim anhNguoivao As New Image(Of Bgr, Byte)(imgVaoTruoc.Image.Bitmap)
        ''Dim bienso = docbienso(anhBiensoxevao, anhNguoivao, picVaoTruoc, picVaoSau)
        'Dim bienso = docbienso(anhBiensoxevao)
        'If regex.IsMatch(bienso) Then
        '    Timer_vao.Enabled = False

        '    txtBiensovao.Text = bienso
        '    btnDoclai.Text = "Đọc..."
        '    ProgressBar1.Visible = False
        '    cbLoaixevao.SelectedItem = "Xe máy"
        '    txtNgayvao.Text = Now.ToString("dd/MM/yyyy")
        '    txtGiovao.Text = Now.ToString("hh:mm:ss")
        '    Beep()
        'Else
        '    cbLoaixevao.SelectedItem = "Xe đạp"
        'End If
    End Sub

    Private Sub Timer_ra_Tick(ByVal sender As Object, ByVal e As EventArgs) Handles Timer_ra.Tick
        'Dim anhBiensoxera = New Image(Of Bgr, Byte)(imgRaSau.Image.Bitmap)
        'Dim anhNguoira As New Image(Of Bgr, Byte)(imgRaTruoc.Image.Bitmap)
        ''Dim bienso = docbienso(anhBiensoxera, anhNguoira, picRaTruoc, picRaSau)
        'Dim bienso = docbienso(anhBiensoxera)
        'If regex.IsMatch(bienso) Then
        '    Timer_ra.Enabled = False

        '    txtBiensora.Text = bienso
        '    btndoclai2.Text = "Đọc..."
        '    ProgressBar2.Visible = False
        '    cbLoaixera.SelectedItem = "Xe máy"
        '    txtNgayra.Text = Now.ToString("dd/MM/yyyy")
        '    txtGiora.Text = Now.ToString("hh:mm:ss")
        '    Beep()
        'Else
        '    cbLoaixera.SelectedItem = "Xe đạp"
        'End If
    End Sub
    Private Sub Timer_xoara_Tick(ByVal sender As Object, ByVal e As EventArgs) Handles Timer_xoara.Tick
        ' khi xe ra xoá hết thông tin xe vào và ra
        Timer_xoara.Enabled = False
        txtSothe.Text = ""
        lblLuong.Text = ""
        'xoá thông tin xe vào
        txtNgayvao.Text = ""
        txtGiovao.Text = ""
        'txtBiensovao.Text = ""

        'xoá thông tin xe ra
        txtNgayra.Text = ""
        txtGiora.Text = ""
        txtBiensora.Text = ""

        'bắt đầu đọc biển số xe ra
        startTimbiensoRa()
    End Sub

    Private Sub Timer_xoavao_Tick(ByVal sender As Object, ByVal e As EventArgs) Handles Timer_xoavao.Tick
        ' khi xe vào xoá thông tin xe vào để đón lượt kế tiếp
        Timer_xoavao.Enabled = False

        txtSothe.Text = ""
        lblLuong.Text = ""

        txtNgayvao.Text = ""
        txtGiovao.Text = ""
        txtBiensovao.Text = ""

        'bắt đầu đọc biển số xe vào
        startTimbiensoVao()
    End Sub


#End Region
#Region "form"
    Private Sub frmChinh8_FormClosed(ByVal sender As Object, ByVal e As FormClosedEventArgs) Handles Me.FormClosed
        frmDangnhap.thoigiandangxuat = Now
        frmDangnhap.Close()
    End Sub

    Private Sub frmChinh8_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles Me.KeyDown
        'ấn nút space sẽ ngưng 2 timer khi có 1 timer trở lên hoạt động
        If e.KeyCode = Keys.Space Then

            'nút up sẽ đọc luồng ra
        ElseIf e.KeyCode = Keys.Up Then
            If Timer_ra.Enabled = False Then
                startTimbiensoRa()
            Else
                stopTimbiensoRa()
            End If
            'nút down sẽ đọc luồng vào
        ElseIf e.KeyCode = Keys.Down Then
            If Timer_vao.Enabled = False Then
                startTimbiensoVao()
            Else
                stopTimbiensoVao()
            End If
        ElseIf e.KeyCode = Keys.Enter Then
            txtSothe.Focus()
        ElseIf Keys.Control And e.KeyCode = Keys.F Then
            HideForm()
            frmTimkiem.Show()
        End If
    End Sub

    Private Sub frmChinh8_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        bwWC.RunWorkerAsync()

        Me.WindowState = FormWindowState.Maximized
        Me.KeyPreview = True
        txtSothe.Focus()
#If DATA Then
        'hiển thị các loại xe
        Try
            hiencb("select loaixe from loaixe", cbLoaixevao)
            hiencb("select loaixe from loaixe", cbLoaixera)
            giatien = retrieveTable("select * from loaixe")
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Có lỗi xảy ra")
        End Try
#Else
        cbLoaixevao.Items.AddRange(New String() {"Xe đạp", "Xe máy"})
        cbLoaixera.Items.AddRange(New String() {"Xe đạp", "Xe máy"})
#End If
        Try
            Timer_xoara.Interval = CInt(g_regKey.GetValue("stoptime"))
            Timer_xoavao.Interval = CInt(g_regKey.GetValue("stoptime"))
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Có lỗi xảy ra")
        End Try
    End Sub
#End Region
#Region "buttonClick"
    Private Sub BáoMấtThẻToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BáoMấtThẻToolStripMenuItem.Click
        Dim sothe As String
        Try
            sothe = InputBox("Chỉ được nhập số", "Nhập số thẻ")
            If CInt(tim("select count(*) from the where sothe=" & sothe)) = 1 Then
                runsql("update the set chuamat=0 where sothe=" & sothe)
                MsgBox("Báo mất thẻ thành công")
            Else
                MsgBox("Thẻ không tồn tại")
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Có lỗi xảy ra")
        End Try
    End Sub

    Private Sub BáoHưThẻToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BáoHưThẻToolStripMenuItem.Click
        Dim sothe As String
        Try
            sothe = InputBox("Chỉ được nhập số", "Nhập số thẻ")
            If CInt(tim("select count(*) from the where sothe=" & sothe)) = 1 Then
                runsql("update the set chuahu=0 where sothe=" & sothe)
                MsgBox("Báo hư thẻ thành công")
            Else
                MsgBox("Thẻ không tồn tại")
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Có lỗi xảy ra")
        End Try
    End Sub

    Private Sub ĐổiThưMụcLưuẢnhToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ĐổiThưMụcLưuẢnhToolStripMenuItem.Click
        Dim dir = InputBox("Không có dấu \ cuối cùng, ví dụ E:\picture", "Nhập thư mục lưu ảnh biển số")
        If dir <> "" Then
            Dim svdir As New DirectoryInfo(dir)
            If Not svdir.Exists Then
                MsgBox("Thư mục không tồn tại")
            Else
                'thêm dấu \ cuối chuỗi
                Dim tam = svdir.ToString
                If tam(tam.Length - 1) <> "\" Then
                    tam = tam & "\"
                End If
                g_savedir = tam
                g_regKey.SetValue("savedir", tam)
                MsgBox("Đổi thư mục thành công")
            End If
        End If
    End Sub

    Private Sub ChọnCameraToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ChọnCameraToolStripMenuItem.Click
        HideForm()
        frmChonWC.Show()
    End Sub

    Private Sub TìmKiếmToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TìmKiếmToolStripMenuItem.Click
        HideForm()
        frmTimkiem.Show()
    End Sub

    Private Sub ThốngKêToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ThốngKêToolStripMenuItem.Click
        HideForm()
        frmThongke.Show()
    End Sub

    Private Sub ĐổiMậtKhẩuToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ĐổiMậtKhẩuToolStripMenuItem.Click
        HideForm()
        frmDoimatkhau.manv = manv
        frmDoimatkhau.Show()
    End Sub

    Private Sub XeTrongBãiToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles XeTrongBãiToolStripMenuItem.Click
        HideForm()
        frmXetrongbai.Show()
    End Sub

#End Region
    Private Sub bwWC_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles bwWC.DoWork
        captureWC()
    End Sub

    Private Sub btnDoclai_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDoclai.Click
        If Timer_vao.Enabled = False Then
            Timer_vao.Enabled = True
            btnDoclai.Text = "Ngưng đọc"
            ProgressBar1.Visible = True
            picVaoSau.Image = Nothing
        Else
            Timer_vao.Enabled = False
            btnDoclai.Text = "Đọc..."
            ProgressBar1.Visible = False
            picVaoSau.Image = Nothing
        End If
    End Sub

    Private Sub btndoclai2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btndoclai2.Click
        'khi wc nhận diện đủ biển số xe nhưng không chính xác
        If Timer_ra.Enabled = False Then
            Timer_ra.Enabled = True
            btndoclai2.Text = "Ngưng đọc"
            ProgressBar2.Visible = True
            picRaSau.Image = Nothing
        Else
            Timer_ra.Enabled = False
            btndoclai2.Text = "Đọc..."
            ProgressBar2.Visible = False
            picRaSau.Image = Nothing
        End If
    End Sub

    Private Sub TimerProgress_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TimerProgress.Tick
        If ProgressBar1.Visible Then
            ProgressBar1.Value += 1
            If ProgressBar1.Value >= ProgressBar1.Maximum Then
                ProgressBar1.Value = ProgressBar1.Minimum
            End If
        End If

        If ProgressBar2.Visible Then
            ProgressBar2.Value += 1
            If ProgressBar2.Value >= ProgressBar2.Maximum Then
                ProgressBar2.Value = ProgressBar2.Minimum
            End If
        End If
    End Sub

    Private Sub CậpNhậtNhânViênToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CậpNhậtNhânViênToolStripMenuItem.Click
        HideForm()
        frmAdmin.Show()
    End Sub

    Private Sub CậpNhậtGiáTiềnToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CậpNhậtGiáTiềnToolStripMenuItem.Click
        HideForm()
        frmGiatien.Show()
    End Sub

    Private Sub ChấmCôngNhânViênToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChấmCôngNhânViênToolStripMenuItem.Click
        HideForm()
        frmChamCong.Show()
    End Sub

    Private Sub txtSothe_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSothe.KeyDown
        'khi nhập mã thẻ thì bắt đầu kiểm tra xe ra hay xe vào
        If txtSothe.Text <> "" AndAlso e.KeyCode = Keys.Enter Then
            xevaora()
        End If
    End Sub

    Private Sub txtBienSoVao_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtBienSoVao.KeyDown
        'khi wc không nhận ra biển số xe vào thì người dùng nhập thủ công
        If e.KeyCode = Keys.Delete Then
            Timer_vao.Enabled = False
            btnDoclai.Text = "Đọc..."
            ProgressBar1.Visible = False
        End If
    End Sub

    Private Sub txtBiensora_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtBiensora.KeyDown
        'khi wc không nhận ra biển số xe ra thì người dùng nhập thủ công
        If e.KeyCode = Keys.Delete Then
            Timer_ra.Enabled = False
            btndoclai2.Text = "Đọc..."
            ProgressBar2.Visible = False
        End If
    End Sub
End Class