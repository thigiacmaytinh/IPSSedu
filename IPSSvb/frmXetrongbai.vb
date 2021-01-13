Public Class frmXetrongbai
    Sub headerDgvTimkiem()
        With dgvTimkiem
            .Columns(0).HeaderText = "Số thẻ"
            .Columns(1).HeaderText = "Giờ xe vào"
            .Columns(2).HeaderText = "Biển số vào"
            .Columns(3).HeaderText = "Loại xe"
            .Columns(4).HeaderText = "Ảnh vào phía trước"
            .Columns(5).HeaderText = "Ảnh vào phía sau"
            .Columns(6).HeaderText = "Nhân viên"
        End With
    End Sub
    Private Sub frmXetrongbai_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dgvTimkiem.Columns.Clear()

        Dim sql = "select the.sothe,ngaygioxevo,biensoxevo,loaixe,phiatruoc,phiasau,manv "
        sql &= "from xevodisk, the "
        sql &= "where xevodisk.sothe=the.sothe and giaochokhach=1 and ngaygioxevo not in(select ngaygioxevo from xeradisk) "
        sql &= "order by ngaygioxevo"
        hiendgv(sql, dgvTimkiem)
        headerDgvTimkiem()
    End Sub

    Private Sub dgvTimkiem_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvTimkiem.CellClick
        Try
            picVaotruoc.Image = Image.FromFile(g_savedir & dgvTimkiem.CurrentRow.Cells(4).Value.ToString())
            picVaosau.Image = Image.FromFile(g_savedir & dgvTimkiem.CurrentRow.Cells(5).Value.ToString())
        Catch ex As Exception
            MsgBox("Không tìm thấy ảnh")
        End Try
    End Sub
End Class