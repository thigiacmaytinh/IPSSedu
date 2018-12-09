Imports System.Data.SqlClient
Imports System.IO
Imports System.Security.Cryptography

Public Class frmDoimatkhau
    Public manv As String
    Dim mnv As String = frmDangnhap.Hname
    Dim mnhom As String = frmDangnhap.Hnhom
    Function kthople() As Boolean
        If txtPass.Text = "" Then
            ErrorProvider1.SetError(txtPass, "Chưa nhập mật khẩu cũ")
            Return False
        ElseIf txtPass1.Text = "" Then
            ErrorProvider1.SetError(txtPass1, "Chưa nhập mật khẩu mới")
            Return False
        ElseIf txtPass2.Text = "" Then
            ErrorProvider1.SetError(txtPass2, "Chưa nhập mật khẩu mới")
            Return False
        ElseIf txtPass1.Text <> txtPass2.Text Then
            ErrorProvider1.SetError(txtPass2, "2 ô mật khẩu không giống nhau")
            Return False
        ElseIf CInt(tim("select count(*) from nhanvien where manv='" & mnv & "' and matkhau='" & mahoamd5(txtPass.Text) & "'")) = 0 Then
            ErrorProvider1.SetError(txtPass, "Mật khẩu cũ sai")
            Return False
        End If
        Return True
    End Function

    Private Sub frmDoimatkhau_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        'thay đổi theo yêu cầu của thầy
        If mnhom = "MN001" Then
            frmChinh8.btnAdmin.Enabled = False
            frmChinh8.Show()
        Else
            frmChinh8.btnAdmin.Enabled = True
            frmChinh8.Show()
        End If
    End Sub

    Private Sub btnDoimatkhau_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDoimatkhau.Click
        If kthople() Then
            runsql("Update nhanvien set matkhau='" & mahoamd5(txtPass1.Text) & "' where manv='" & mnv & "'")
            MsgBox("Đổi mật khẩu thành công")
            Me.Close()
        End If
    End Sub
End Class