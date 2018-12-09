Public Class frmGiatien

    Sub hiendgvLoaixe()
        hiendgv("select * from loaixe", dgvLoaixe)
        dgvLoaixe.Columns(0).HeaderText = "Mã loại"
        dgvLoaixe.Columns(1).HeaderText = "Loại xe"
        dgvLoaixe.Columns(2).HeaderText = "Giá tiền"
    End Sub

    Private Sub btnThemgiatien_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnThemgiatien.Click
        If txtLoaixe.Text = "" Then
            ErrorProvider1.SetError(txtLoaixe, "Chưa nhập loại xe")
        ElseIf txtGiatien.Text = "" Then
            ErrorProvider1.SetError(txtGiatien, "Chưa nhập giá tiền")
        ElseIf tim("select count(*) from loaixe where loaixe='" & txtLoaixe.Text & "'") = 1 Then
            ErrorProvider1.SetError(txtLoaixe, "Đã có loại xe này")
        Else
            runsql("insert into loaixe(loaixe,giatien) values(N'" & txtLoaixe.Text & "'," & txtGiatien.Text & ")")
            txtLoaixe.Text = ""
            txtGiatien.Text = ""
            MsgBox("Thêm loại xe thành công")
            hiencb("select loaixe from loaixe", cbLoaixe)
            hiendgvLoaixe()
        End If
    End Sub

    Private Sub btnSuagiatien_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSuagiatien.Click
        If cbLoaixe.SelectedIndex = -1 Then
            ErrorProvider1.SetError(cbLoaixe, "Chưa chọn loại xe")
        ElseIf txtGiatien2.Text = "" Then
            ErrorProvider1.SetError(txtGiatien2, "Chưa nhập giá tiền")
        Else
            runsql("update loaixe set giatien=" & txtGiatien2.Text & " where loaixe=N'" & cbLoaixe.SelectedItem.ToString() & "'")
            MsgBox("Đã sửa giá của " & cbLoaixe.SelectedItem.ToString())
            cbLoaixe.SelectedIndex = -1
            hiendgvLoaixe()
        End If
    End Sub

    Private Sub txtGiatien_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtGiatien.ValueChanged
        If txtGiatien.Text <> "" Then
            lblGiatien.Text = docso(txtGiatien.Text)
        End If
    End Sub

    Private Sub txtGiatien2_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtGiatien2.ValueChanged
        If txtGiatien2.Text <> "" Then
            lblGiatien2.Text = docso(txtGiatien2.Text)
        End If
    End Sub

    Private Sub cbLoaixe_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbLoaixe.SelectedIndexChanged
        txtGiatien2.Text = tim("select giatien from loaixe where loaixe=N'" & cbLoaixe.SelectedItem.ToString() & "'").ToString()
    End Sub

    Private Sub frmGiatien_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        hiendgvLoaixe()
        hiencb("select loaixe from loaixe", cbLoaixe)
    End Sub

    Private Sub frmGiatien_QueryContinueDrag(ByVal sender As Object, ByVal e As System.Windows.Forms.QueryContinueDragEventArgs) Handles Me.QueryContinueDrag
        frmChinh8.Show()
    End Sub
End Class