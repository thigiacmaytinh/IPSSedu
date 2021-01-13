Imports System.IO
Imports System.Data.SqlClient

Public Class frmDatabase
    Dim isConnectSuccess As Boolean = False

    Function kthople() As Boolean
        If grpChuoiketnoi.Visible = True Then
            If txtChuoiketnoi.Text = "" Then
                ErrorProvider1.SetError(txtChuoiKetNoi, "Chưa nhập chuỗi kết nối")
                Return False
            End If
        Else
            If txtServer.Text = "" Then
                ErrorProvider1.SetError(txtServer, "Chưa nhập server")
                Return False
            ElseIf txtUsername.Text = "" Then
                ErrorProvider1.SetError(txtUsername, "Chưa nhập username")
                Return False
            ElseIf txtPassword.Text = "" Then
                txtPassword.Text = "Chưa nhập password"
                Return False
            ElseIf txtDatabase.Text = "" Then
                ErrorProvider1.SetError(txtDatabase, "Chưa nhập databse")
                Return False
            End If
        End If
        Return True
    End Function

    Private Sub cbPhuongthuc_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbPhuongthuc.SelectedIndexChanged
        If cbPhuongthuc.SelectedIndex = 0 Then
            grpThucong.Visible = True
            grpChuoiketnoi.Visible = False
        Else
            grpThucong.Visible = False
            grpChuoiketnoi.Visible = True
            grpChuoiketnoi.Dock = DockStyle.Top
        End If
        If cbPhuongthuc.SelectedIndex = 1 Then
            'Nhập chuỗi kết nối
            txtChuoiketnoi.Text = "Data Source=;User ID=;Password=;Database=;"
        ElseIf cbPhuongthuc.SelectedIndex = 2 Then
            'Windows Authentication
            txtChuoiketnoi.Text = "Data Source=localhost;Database=xxxxxxxxxxxx;Integrated Security=True"
        End If
    End Sub

    Private Sub frmDatabase_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        If isConnectSuccess Then
            frmDangnhap.Show()
            frmDangnhap.ShowInTaskbar = True
        Else
            frmDangnhap.Close()
        End If
    End Sub

    Private Sub frmDatabase_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        cbPhuongthuc.SelectedIndex = 0
    End Sub

    Private Sub bwKetnoi_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bwKetnoi.DoWork
        isConnectSuccess = IsConnected()
    End Sub

    Private Sub bwKetnoi_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bwKetnoi.RunWorkerCompleted
        Timer1.Enabled = False
        ProgressBar1.Value = ProgressBar1.Minimum
        lblKetnoi.Visible = False
        btnKetnoi.Enabled = True
        If isConnectSuccess = True Then
            MsgBox("Kết nối thành công")
            Me.Close()
        Else
            MsgBox("Kết nối thất bại")
        End If
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        ProgressBar1.Value += 1
        If ProgressBar1.Value >= ProgressBar1.Maximum Then
            ProgressBar1.Value = ProgressBar1.Minimum
        End If
    End Sub

    Private Sub btnKetnoi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnKetnoi.Click
        If Not kthople() Then
            Return
        End If
        Dim chuoiketnoi As String
        If grpChuoiketnoi.Visible = True Then
            chuoiketnoi = txtChuoiKetNoi.Text
            If cbPhuongthuc.SelectedIndex = 3 Then
                chuoiketnoi = "Data Source=.\SQLEXPRESS;AttachDbFilename=" & txtChuoiKetNoi.Text & ";Integrated Security=True;"
            End If
            chuoiketnoi = mahoachuoiketnoi(chuoiketnoi)
        Else 'nhập thủ công 4 trường
            chuoiketnoi = "Data Source=" & txtServer.Text & ";User ID=" & txtUsername.Text & ";Password=" & AES_Encrypt(txtPassword.Text, "zxcvbnm")
            chuoiketnoi &= ";Initial Catalog=" & txtDatabase.Text & ";"
        End If
        g_regKey.SetValue("ConnectionString", chuoiketnoi)
        g_strConnect = GetConnectionString()

        bwKetnoi.RunWorkerAsync()
        Timer1.Enabled = True
        lblKetnoi.Visible = True
        btnKetnoi.Enabled = False
    End Sub


    Private Sub txtChuoiKetNoi_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtChuoiKetNoi.KeyUp
        If e.Control AndAlso e.KeyCode = Keys.A Then
            txtChuoiKetNoi.SelectAll()
        End If
    End Sub
End Class