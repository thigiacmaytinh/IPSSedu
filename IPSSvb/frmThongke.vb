Public Class frmThongke
    Sub thongkeSoluongxe(ByVal fromTime As DateTime, ByVal toTime As DateTime)
        'lấy danh sách các loại xe đã gửi
        Dim dtLoaixe = retrieveTable("select distinct loaixe from xevodisk")
        Dim minrange As DateTime = Now
        Dim maxrange As DateTime = Now
        For i = 0 To dtLoaixe.Rows.Count - 1
            'lấy dữ liệu các ngày  đối với từng loại xe
            Dim sqlDulieu = "select CONVERT(date,xevodisk.ngaygioxevo) as ngay,count(loaixe) as soluong "
            sqlDulieu &= "from xevodisk, xeradisk "
            sqlDulieu &= "where xevodisk.ngaygioxevo = xeradisk.ngaygioxevo And loaixe = N'" & dtLoaixe.Rows(i).Item(0).ToString & "' "
            sqlDulieu &= "and xevodisk.ngaygioxevo between '" & fromTime.AddDays(-1).ToString("yyyy-MM-dd") & "' and '" & toTime.AddDays(1).ToString("yyyy-MM-dd") & "' "
            sqlDulieu &= "group by convert(date,xevodisk.ngaygioxevo)"
            Dim dtValue = retrieveTable(sqlDulieu)
            'tính tổng dữ liệu đưa ra listview
            ListView1.Columns(0).Text = "Loại xe"
            ListView1.Columns(1).Text = "Số lượng (chiếc)"
            Dim lstItem As New ListViewItem(dtLoaixe.Rows(i).Item(0).ToString)
            Dim tong As Integer = 0
            For j = 0 To dtValue.Rows.Count - 1
                tong += CInt(dtValue.Rows(j).Item(1))
            Next
            lstItem.SubItems.Add(tong)
            ListView1.Items.Add(lstItem)
           
        Next
        'tính tổng dữ liệu trong listview
        Dim lstItem2 As New ListViewItem("Tổng")
        Dim tong2 As Integer = 0
        For i = 0 To ListView1.Items.Count - 1
            tong2 += CInt(ListView1.Items(i).SubItems(1).Text)
        Next
        lstItem2.SubItems.Add(tong2)
        ListView1.Items.Add(lstItem2)
        
    End Sub
    Sub thongkeDoanhthu(ByVal fromTime As DateTime, ByVal toTime As DateTime)
        Dim minrange As DateTime = Now
        Dim maxrange As DateTime = Now
        'lấy danh sách các loại xe đã gửi
        Dim dtLoaixe = retrieveTable("select distinct loaixe from xevodisk")
        For i = 0 To dtLoaixe.Rows.Count - 1
            'lấy dữ liệu các ngày  đối với từng loại xe
            Dim sqlDulieu = "select CONVERT(date,xevodisk.ngaygioxevo) as ngay,sum(giatien) as giatien "
            sqlDulieu &= "from xevodisk, xeradisk "
            sqlDulieu &= "where xevodisk.ngaygioxevo = xeradisk.ngaygioxevo And loaixe = N'" & dtLoaixe.Rows(i).Item(0).ToString & "' "
            sqlDulieu &= "and xevodisk.ngaygioxevo between '" & fromTime.AddDays(-1).ToString("yyyy-MM-dd") & "' and '" & toTime.AddDays(1).ToString("yyyy-MM-dd") & "' "
            sqlDulieu &= "group by convert(date,xevodisk.ngaygioxevo)"
            Dim dtValue = retrieveTable(sqlDulieu)
            'tính tổng dữ liệu đưa ra listview
            ListView1.Columns(0).Text = "Loại xe"
            ListView1.Columns(1).Text = "Số tiền (đồng)"
            Dim lstItem As New ListViewItem(dtLoaixe.Rows(i).Item(0).ToString)
            Dim tong As Integer = 0
            For j = 0 To dtValue.Rows.Count - 1
                tong += CInt(dtValue.Rows(j).Item(1))
            Next
            lstItem.SubItems.Add(tong)
            ListView1.Items.Add(lstItem)
           
        Next
        'tính tổng dữ liệu trong listview
        Dim lstItem2 As New ListViewItem("Tổng")
        Dim tong2 As Integer = 0
        For i = 0 To ListView1.Items.Count - 1
            tong2 += CInt(ListView1.Items(i).SubItems(1).Text)
        Next
        lstItem2.SubItems.Add(tong2)
        ListView1.Items.Add(lstItem2)

    End Sub
    Sub thongkeLichtruc(ByVal fromTime As DateTime, ByVal toTime As DateTime)
        'lấy danh sách các nhân có trực
        Dim dtManv = retrieveTable("select distinct manv from BangChamCong")
        Dim minrange As DateTime = Now
        Dim maxrange As DateTime = Now
        For i = 0 To dtManv.Rows.Count - 1
            'lấy dữ liệu các ngày đối với từng nhân viên

            Dim sqlDulieu = "select convert(date,ThoiGianDangNhap),sum(DATEDIFF(minute,ThoiGianDangnhap,ThoiGianDangxuat)) "
            sqlDulieu &= "from BangChamCong "
            sqlDulieu &= "where MaNV = N'" & dtManv.Rows(i).Item(0).ToString() & "' "
            sqlDulieu &= "and ThoiGianDangNhap between '" & fromTime.AddDays(-1).ToString("yyyy-MM-dd") & "' and '" & toTime.AddDays(1).ToString("yyyy-MM-dd") & "' "
            sqlDulieu &= "group by convert(date,ThoiGianDangNhap)"
            Dim dtValue = retrieveTable(sqlDulieu)
            'tính tổng dữ liệu đưa ra listview
            ListView1.Columns(0).Text = "Nhân viên"
            ListView1.Columns(1).Text = "Thời gian (phút)"
            Dim lstItem As New ListViewItem(dtManv.Rows(i).Item(0).ToString)
            Dim tong As Integer = 0
            For j = 0 To dtValue.Rows.Count - 1
                tong += CInt(dtValue.Rows(j).Item(1))
            Next
            lstItem.SubItems.Add(tong)
            ListView1.Items.Add(lstItem)

        Next
        'tính tổng dữ liệu trong listview
        Dim lstItem2 As New ListViewItem("Tổng")
        Dim tong2 As Integer = 0
        For i = 0 To ListView1.Items.Count - 1
            tong2 += CInt(ListView1.Items(i).SubItems(1).Text)
        Next
        lstItem2.SubItems.Add(tong2)
        ListView1.Items.Add(lstItem2)

    End Sub

    Private Sub btnThongke_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnThongke.Click

        If txtNgaythongkedau.Text = "" Then
            ErrorProvider1.SetError(txtNgaythongkedau, "Chưa chọn ngày bắt đầu")
        ElseIf txtNgaythongkecuoi.Text = "" Then
            ErrorProvider1.SetError(txtNgaythongkecuoi, "Chưa chọn ngày kết thúc")
        ElseIf cbDieukienthongke.SelectedIndex = -1 Then
            ErrorProvider1.SetError(cbDieukienthongke, "Chưa chọn điều kiện thống kê")
        ElseIf txtNgaythongkedau.Value >= txtNgaythongkecuoi.Value Then
            ErrorProvider1.SetError(txtNgaythongkedau, "Ngày bắt đầu phải nhỏ hơn ngày kết thúc")
        Else
            ListView1.Items.Clear()
            If cbDieukienthongke.SelectedIndex = 0 Then
                'Các điều kiện thoả mãn
                ErrorProvider1.Clear()
                thongkeDoanhthu(txtNgaythongkedau.Value, txtNgaythongkecuoi.Value)
            ElseIf cbDieukienthongke.SelectedIndex = 1 Then
                ErrorProvider1.Clear()
                thongkeSoluongxe(txtNgaythongkedau.Value, txtNgaythongkecuoi.Value)
            ElseIf cbDieukienthongke.SelectedIndex = 2 Then
                ErrorProvider1.Clear()
                thongkeLichtruc(txtNgaythongkedau.Value, txtNgaythongkecuoi.Value)
            End If
        End If
    End Sub
End Class