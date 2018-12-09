Imports System.Data.SqlClient
Imports System.IO
Imports System.Security.Cryptography

Public Class frmAdmin
    Public tgdangnhap As DateTime

#Region "commonFunction"
    Sub hiendsnhanvien(ByVal dieukien As String)
        Dim sql = "select manv,nhomnguoidung.manhom + ';' + tennhom,mathenv,hoten,ngaysinh,gioitinh,diachi,sdt,email from nhanvien,nhomnguoidung where nhanvien.manhom=nhomnguoidung.manhom"
        If dieukien <> "" Then
            sql &= " and " & dieukien
        End If
        hiendgv(sql, dgvNhanvien)
        dgvNhanvien.Columns(0).HeaderText = "Mã nhân viên"
        dgvNhanvien.Columns(1).HeaderText = "Mã nhóm"
        dgvNhanvien.Columns(2).HeaderText = "Mã thẻ"
        dgvNhanvien.Columns(3).HeaderText = "Họ tên"
        dgvNhanvien.Columns(4).HeaderText = "Ngày sinh"
        dgvNhanvien.Columns(5).HeaderText = "Nam"
        dgvNhanvien.Columns(6).HeaderText = "Địa chỉ"
        dgvNhanvien.Columns(7).HeaderText = "Số điện thoại"
        dgvNhanvien.Columns(8).HeaderText = "Email"
    End Sub

    Sub loaditem()
        'load nội dung của dòng đang chọn lên các control
        If dgvNhanvien.CurrentRow.Index <> dgvNhanvien.Rows.Count Then
            With dgvNhanvien.CurrentRow
                txtHoten.Text = .Cells(0).Value.ToString()
                txtNgaysinh.Value = CDate(.Cells(4).Value)
                If CBool(.Cells(5).Value) = True Then
                    rdNam.Checked = True
                Else
                    rdNu.Checked = True
                End If
                txtDiachi.Text = .Cells(6).Value.ToString()
                txtDienthoai.Text = .Cells(7).Value.ToString()
                cbNhom.SelectedItem = .Cells(1).Value.ToString()
                txtMathe.Text = .Cells(2).Value.ToString()
                txtManv.Text = .Cells(0).Value.ToString()
                txtEmail.Text = .Cells(8).Value.ToString()
            End With
        End If
    End Sub
    Sub clearctrl()
        Dim ctrl() As Control = {txtHoten, txtNgaysinh, txtDiachi, txtDienthoai, cbNhom, txtMathe, txtManv, txtEmail}
        For Each i In ctrl
            i.Text = ""
        Next
    End Sub
    Function ktnhanvien() As Boolean
        If txtHoten.Text = "" Then
            ErrorProvider2.SetError(txtHoten, "Chưa nhập họ tên")
            Return False
        ElseIf txtNgaysinh.Text = "" Then
            ErrorProvider2.SetError(txtNgaysinh, "Chưa nhập ngày sinh")
            Return False
        ElseIf cbNhom.SelectedIndex = -1 Then
            ErrorProvider2.SetError(cbNhom, "Chưa chọn nhóm")
            Return False
        ElseIf txtMathe.Text = "" Then
            ErrorProvider2.SetError(txtMathe, "Chưa nhập mã thẻ")
            Return False
        ElseIf txtManv.Text = "" Then
            ErrorProvider2.SetError(txtManv, "Chưa nhập tên đăng nhập")
            Return False
        ElseIf txtEmail.Text = "" Then
            ErrorProvider2.SetError(txtEmail, "Chưa nhập email")
            Return False
        ElseIf CInt(tim("select count(*) from nhanvien where manv='" & txtManv.Text & "'")) = 1 Then
            ErrorProvider2.SetError(txtManv, "Đã có tài khoản này")
            Return False
        End If
        Return True
    End Function

#End Region
#Region "tabnhanvien"
    Private Sub cbDieukienTim_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        If cbDieukienTim.SelectedIndex = 0 Then
            'Mã nhân viên
            hiencb("select manv from nhanvien", cbTim)
        ElseIf cbDieukienTim.SelectedIndex = 1 Then
            'Họ tên
            hiencb("select hoten from nhanvien", cbTim)
        Else
            'Email
            hiencb("select email from nhanvien", cbTim)
        End If
    End Sub

    Private Sub dgvNhanvien_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)
        loaditem()
        btnSua.Enabled = True
        btnXoa.Enabled = True
    End Sub

#End Region

#Region "tabGiatien"

    Private Sub txtGiatien_EditValueChanged(ByVal sender As Object, ByVal e As System.EventArgs)
      
    End Sub

    Private Sub cbLoaixe_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

#End Region

#Region "form"
    Private Sub frmAdmin_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        frmChinh8.Show()
    End Sub
    Private Sub frmAdmin_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        hiendsnhanvien("")
        hiencb("select manhom + ';' + tennhom  from nhomnguoidung", cbNhom)



    End Sub

#End Region

#Region "In thẻ nhân viên"
    Function sothenhanvien(ByVal so As Integer) As String
        'trả về chuỗi có 4 ký tự
        If so < 10 Then
            Return "000" & so.ToString
            Exit Function
        ElseIf so < 100 Then
            Return "00" & so
            Exit Function
        ElseIf so < 1000 Then
            Return "0" & so
            Exit Function
        Else
            Return so.ToString()
            Exit Function
        End If
    End Function

    Private Sub txtPath_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs)
        e.Handled = True
    End Sub

#End Region

    Private Sub btnTim_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If cbDieukienTim.SelectedIndex = -1 Then
            ErrorProvider2.SetError(cbDieukienTim, "Chưa chọn điều kiện tìm")
        Else
            Dim sql = "select * from nhanvien where "
            If chkChinhxac.Checked Then
                If cbDieukienTim.SelectedItem.ToString = "Mã nhân viên" Then
                    hiendsnhanvien("manv='" & cbTim.Text & "'")
                ElseIf cbDieukienTim.SelectedItem.ToString = "Họ tên" Then
                    hiendsnhanvien("hoten=N'" & cbTim.Text & "'")
                ElseIf cbDieukienTim.SelectedItem.ToString = "Email" Then
                    hiendsnhanvien("email='" & cbTim.Text & "'")
                End If
            Else
                If cbDieukienTim.SelectedItem.ToString = "Mã nhân viên" Then
                    hiendsnhanvien("manv like '%" & cbTim.Text & "%'")
                ElseIf cbDieukienTim.SelectedItem.ToString = "Họ tên" Then
                    hiendsnhanvien("hoten like N'%" & cbTim.Text & "%'")
                ElseIf cbDieukienTim.SelectedItem.ToString = "Email" Then
                    hiendsnhanvien("email like '%" & cbTim.Text & "%'")
                End If
            End If

        End If
    End Sub

    Private Sub btnThem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If ktnhanvien() Then
            Dim sql = "insert into nhanvien(hoten,ngaysinh,gioitinh,diachi,sdt,manhom,mathenv,manv,email,matkhau) values(N'"
            sql &= txtHoten.Text & "','"
            sql &= txtNgaysinh.Value & "',"
            If rdNam.Checked Then
                sql &= "1,N'"
            Else
                sql &= "0,N'"
            End If
            sql &= txtDiachi.Text & "','"
            sql &= txtDienthoai.Text & "','"
            sql &= Split(cbNhom.SelectedItem.ToString(), ";")(0) & "','"
            sql &= txtMathe.Text & "','"
            sql &= txtManv.Text & "','"
            sql &= txtEmail.Text & "','"
            sql &= mahoamd5("0000") & "')"
            runsql(sql)
            MsgBox("Tạo tài khoản thành công với mật khẩu 0000 - Vui lòng thay đổi mật khẩu trong lần đăng nhập sau.")
            clearctrl()
            hiendsnhanvien("")
        End If
    End Sub

    Private Sub btnSua_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Dim sql = "update nhanvien set "
            sql &= "hoten=N'" & txtHoten.Text & "',"
            sql &= "ngaysinh='" & txtNgaysinh.Value & "',"
            If rdNam.Checked Then
                sql &= "gioitinh=1,"
            Else
                sql &= "gioitinh=0,"
            End If
            sql &= "diachi=N'" & txtDiachi.Text & "',"
            sql &= "sdt='" & txtDienthoai.Text & "',"
            sql &= "manhom='" & Split(cbNhom.SelectedItem.ToString(), ";")(0) & "',"
            sql &= "mathenv='" & txtMathe.Text & "',"
            sql &= "manv='" & txtManv.Text & "',"
            sql &= "email='" & txtEmail.Text & "',"
            sql &= "matkhau='" & mahoamd5("") & "'"
            sql &= " where manv='" & dgvNhanvien.CurrentRow.Cells(0).Value.ToString() & "'"
            runsql(sql)
            clearctrl()
            hiendsnhanvien("")
        Catch ex As Exception
            MsgBox("Có lỗi: " & ex.ToString)
        End Try
        btnSua.Enabled = False
    End Sub

    Private Sub btnXoa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If dgvNhanvien.CurrentRow.Index <> dgvNhanvien.Rows.Count Then
            If MessageBox.Show("Bạn có chắc chắn xoá?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = Windows.Forms.DialogResult.Yes Then
                Dim sql = "delete from nhanvien where manv='" & dgvNhanvien.CurrentRow.Cells(0).Value.ToString() & "'"
                runsql(sql)
                hiendsnhanvien("")
                btnXoa.Enabled = False
            End If
        End If
    End Sub

End Class