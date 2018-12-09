Imports System.Data.SqlClient
Imports System.IO
Imports Emgu.CV.Structure
Imports Emgu.CV

Public Class frmTimkiem
   
    Sub headerDgvTimkiem()
        With dgvTimkiem
            .Columns(0).HeaderText = "Số thẻ"
            .Columns(1).HeaderText = "Giờ xe vào"
            .Columns(2).HeaderText = "Giờ xe ra"
            .Columns(3).HeaderText = "Biển số vào"
            .Columns(4).HeaderText = "Biển số ra"
            .Columns(5).HeaderText = "Loại xe"
            .Columns(6).HeaderText = "Giá tiền"
            .Columns(7).HeaderText = "Ảnh vào phía trước"
            .Columns(8).HeaderText = "Ảnh vào phía sau"
            .Columns(9).HeaderText = "Ảnh ra phía trước"
            .Columns(10).HeaderText = "Ảnh ra phía sau"
            .Columns(11).HeaderText = "Nhân viên"
        End With
    End Sub
    Private Sub frmTimkiem_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtThoigianden.Value = Now
        txtThoigianden.Value = Now
        hiencb("select loaixe from loaixe", cbloaixe)
        hiencb("select manv from nhanvien", cbNguoitruc)
    End Sub

    Private Sub chkBienso_ClientSizeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkBienso.ClientSizeChanged
        If chkBienso.Checked Then
            txtBienso.Enabled = True
            chkChinhxac.Enabled = True
        Else
            txtBienso.Enabled = False
            chkChinhxac.Checked = False
            chkChinhxac.Enabled = False
        End If
    End Sub
    Private Sub chkThoigiantu_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkThoigiantu.CheckedChanged
        If chkThoigiantu.Checked Then
            txtThoigiantu.Enabled = True
            txtThoigianden.Enabled = True
        Else
            txtThoigiantu.Enabled = False
            txtThoigianden.Enabled = False
        End If
    End Sub

    Private Sub dgvTimkiem_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvTimkiem.CellClick
        Try
            picVaotruoc.Image = Image.FromFile(g_savedir & dgvTimkiem.CurrentRow.Cells(7).Value.ToString)
            picVaosau.Image = Image.FromFile(g_savedir & dgvTimkiem.CurrentRow.Cells(8).Value.ToString)
            picRatruoc.Image = Image.FromFile(g_savedir & dgvTimkiem.CurrentRow.Cells(9).Value.ToString)
            picRasau.Image = Image.FromFile(g_savedir & dgvTimkiem.CurrentRow.Cells(10).Value.ToString)
        Catch ex As Exception
            MsgBox("Không tìm thấy ảnh")
        End Try
    End Sub

    Private Sub chkBienso_CheckedChanged(sender As Object, e As EventArgs) Handles chkBienso.CheckedChanged
        If chkBienso.Checked Then
            txtBienso.Enabled = True
            chkChinhxac.Enabled = True
            chkChinhxac.Checked = False
        Else
            txtBienso.Enabled = False
            chkChinhxac.Enabled = False
            chkChinhxac.Checked = False
        End If
    End Sub

   
    Private Sub chkNguoitruc_CheckedChanged(sender As Object, e As EventArgs) Handles chkNguoitruc.CheckedChanged
        If chkNguoitruc.Checked Then
            cbNguoitruc.Enabled = True
        Else
            cbNguoitruc.Enabled = False
        End If
    End Sub

    Private Sub chkLoaixe_CheckedChanged(sender As Object, e As EventArgs) Handles chkLoaixe.CheckedChanged
        cbloaixe.Enabled = True
    End Sub

    Private Sub btnTim_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTim.Click
        dgvTimkiem.Columns.Clear()
        lblThongbao.Text = ""
        Dim sql = "select xevodisk.sothe,"
        sql &= "xevodisk.ngaygioxevo,"
        sql &= "ngaygioxera,"
        sql &= "biensoxevo,biensoxera,"
        sql &= "loaixe,"
        sql &= "giatien,"
        sql &= "xevodisk.phiatruoc as vaotruoc,"
        sql &= "xevodisk.phiasau as vaosau,"
        sql &= "xeradisk.phiatruoc as ratruoc,"
        sql &= "xeradisk.phiasau as rasau,"
        sql &= "xevodisk.manv"
        sql &= " from xevodisk,xeradisk where xevodisk.ngaygioxevo=xeradisk.ngaygioxevo "
        'tìm biển số
        If chkBienso.Checked Then
            If chkChinhxac.Checked Then
                sql &= "and xevodisk.biensoxevo='" & txtBienso.Text & "' "
            Else
                sql &= "and xevodisk.biensoxevo like '%" & txtBienso.Text & "%' "
            End If
        End If
        'tìm theo thời gian
        If chkThoigiantu.Checked Then
            If txtThoigiantu.Text = "" OrElse txtThoigianden.Text = "" Then
                lblThongbao.Text = "Chưa nhập thời gian tìm"
                Exit Sub
            Else
                sql &= "and xevodisk.ngaygioxevo >= '" & txtThoigiantu.Value.AddDays(-1).ToString("yyyy-MM-dd hh:mm:ss") & "' "
                sql &= "and xevodisk.ngaygioxevo <= '" & txtThoigianden.Value.AddDays(1).ToString("yyyy-MM-dd hh:mm:ss") & "' "
            End If
        End If
        'tìm theo loại xe
        If chkLoaixe.Checked Then
            If cbloaixe.SelectedIndex = -1 Then
                lblThongbao.Text = "Chưa chọn loại xe"
                Exit Sub
            Else
                sql &= "and loaixe=N'" & cbloaixe.SelectedItem.ToString & "' "
            End If
        End If
        'tìm theo người trực
        If chkNguoitruc.Checked Then
            If cbNguoitruc.SelectedIndex = -1 Then
                lblThongbao.Text = "Chưa chọn người trực"
            Else
                sql &= "and (xevodisk.manv=N'" & cbNguoitruc.SelectedItem.ToString & "' or xeradisk.manv=N'" & cbNguoitruc.SelectedItem.ToString & "') "
            End If
        End If
        sql &= "order by ngaygioxevo"
        hiendgv(sql, dgvTimkiem)
        headerDgvTimkiem()
    End Sub
End Class