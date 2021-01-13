Public Class frmChamCong

    Sub tongthoigian()
        Dim tongthoigian As Double = 0
        If dgvChamcong.Rows.Count > 0 Then
            For Each i As DataGridViewRow In dgvChamcong.Rows
                Dim span = CDate(i.Cells(2).Value) - CDate(i.Cells(1).Value)
                tongthoigian += span.TotalMinutes
            Next
        End If
        lblChamcong.Text = "Thời gian trực: " & CInt(tongthoigian) & " phút"
    End Sub

    Private Sub frmChamCong_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        frmChinh8.Show()
    End Sub

    Private Sub frmChamCong_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        hiencb("select manv from nhanvien", cbNhanvien)
    End Sub

    Private Sub btnTimkiem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTimkiem.Click
        If txtThoigiandangnhap.Text <> "" And txtThoigiandangxuat.Text <> "" Then
            Dim sql As String = "select manv,thoigiandangnhap,thoigiandangxuat from bangchamcong where thoigiandangnhap >='" & txtThoigiandangnhap.Value.AddDays(-1).ToString("yyyy-MM-dd") & "' and thoigiandangxuat <='" & txtThoigiandangxuat.Value.AddDays(1).ToString("yyyy-MM-dd") & "'"
            If cbNhanvien.SelectedIndex <> -1 Then
                sql &= " and manv='" & cbNhanvien.SelectedItem.ToString() & "'"
            End If
            hiendgv(sql, dgvChamcong)
            dgvChamcong.Columns(0).HeaderText = "Nhân viên"
            dgvChamcong.Columns(1).HeaderText = "Thời gian đăng nhập"
            dgvChamcong.Columns(2).HeaderText = "Thời gian đăng xuất"
        End If
        tongthoigian()
    End Sub

    Private Sub cbNhanvien_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbNhanvien.SelectedIndexChanged
        hiendgv("select manv,thoigiandangnhap,thoigiandangxuat from bangchamcong where manv='" & cbNhanvien.SelectedItem.ToString() & "'", dgvChamcong)
        dgvChamcong.Columns(0).HeaderText = "Mã nhân viên"
        dgvChamcong.Columns(1).HeaderText = "Thời gian đăng nhập"
        dgvChamcong.Columns(2).HeaderText = "Thời gian đăng xuất"
        tongthoigian()
    End Sub
End Class