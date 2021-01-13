Imports System.Data.SqlClient
Imports System.IO
Imports System.Security.Cryptography
Imports System.Text
Imports Microsoft.Win32
Imports SVM
Imports Emgu.CV

Public Class frmDangnhap

    Dim m_isConnectSuccess As Boolean
    Dim m_manhom As String
    Dim thoigiandangnhap As DateTime = Now
    Public thoigiandangxuat As DateTime = Nothing
    Public manv As String
    Public Hname, Hnhom As String

#Region "commonFunction"
    Sub CheckRegistry()
        g_regKey = Registry.CurrentUser.OpenSubKey("Software\IPSS", True)
        If g_regKey Is Nothing Then
            Registry.CurrentUser.OpenSubKey("SOFTWARE", True).CreateSubKey("IPSS")
            g_regKey = Registry.CurrentUser.OpenSubKey("Software\IPSS", True)
        End If
        'location to save image
        If g_regKey.GetValue("Savedir") Is Nothing Then
            g_regKey.SetValue("Savedir", "\anh\")
        End If
        'camera ID
        If g_regKey.GetValue("Camera0") Is Nothing Then
            g_regKey.SetValue("Camera0", "0")
        End If
        If g_regKey.GetValue("Camera1") Is Nothing Then
            g_regKey.SetValue("Camera1", "0")
        End If
        If g_regKey.GetValue("Camera2") Is Nothing Then
            g_regKey.SetValue("Camera2", "0")
        End If
        If g_regKey.GetValue("Camera3") Is Nothing Then
            g_regKey.SetValue("Camera3", "0")
        End If
        'connection string
        If g_regKey.GetValue("ConnectionString") Is Nothing Then
            g_regKey.SetValue("ConnectionString", "")
        End If
        'stop time
        If g_regKey.GetValue("stoptime") Is Nothing Then
            g_regKey.SetValue("stoptime", "4000")
        End If
        'frame
        If g_regKey.GetValue("frame") Is Nothing Then
            g_regKey.SetValue("frame", "8")
        End If

    End Sub

    Sub InitModel()
        'g_plateDetector = New CascadeClassifier(Application.StartupPath & "\bienso.xml")
        'g_charDetector = New CascadeClassifier(Application.StartupPath & "\kytu.xml")
        'g_modelNum = Model.Read(Application.StartupPath & "\svmNum.model")
    End Sub

    Sub Login()

        If txtUser.Text = "" Then
            ErrorProvider1.SetError(txtUser, "Chưa nhập tài khoản")
            Return
        End If

        If txtPass.Text = "" Then
            ErrorProvider1.SetError(txtPass, "Chưa nhập mật khẩu")
            Return
        End If
#If DATA Then
        Dim sql As String = "select manhom from nhanvien where (manv=N'" & txtUser.Text & "' and matkhau='" & mahoamd5(txtPass.Text) & "') "
        sql &= "or (mathenv='" & txtUser.Text & "' and matkhau='" & mahoamd5(txtPass.Text) & "')"
        Try
            m_manhom = tim(sql).ToString
            If m_manhom Is Nothing Then
                ErrorProvider1.SetError(txtUser, "Sai tài khoản hoặc mật khẩu")
                Return
            End If
        Catch ex As Exception
            MsgBox("Thông tin đăng nhập sai !!!", MsgBoxStyle.OkOnly, "Lỗi login")
            txtUser.Focus()
            txtUser.Text = ""
            txtPass.Text = ""
            Return
        End Try
#End If

        'đăng nhập thành công
        manv = txtUser.Text.Trim()
        Hname = txtUser.Text.Trim()
        Dim settingForm As Integer = CInt(g_regKey.GetValue("frame"))

        Dim frm As New frmChinh8
        If m_manhom = "MN001" Then
            frm.btnAdmin.Visible = False
            Hnhom = m_manhom
        ElseIf m_manhom = "MV002" Then
            frm.btnAdmin.Enabled = True
            Hnhom = m_manhom
        End If
        frm.Show()

        Timer1.Enabled = False
        Me.Hide()

    End Sub
    Sub guimail()
        If CInt(tim("select count(*) from nhanvien where email='" & txtEmail.Text & "'")) = 1 Then
            Dim MKmoi As String = chuoingaunhien()
            runsql("update nhanvien set matkhau='" & mahoamd5(MKmoi) & "' where email='" & txtEmail.Text & "'")
            Dim manv As String = "Đây là mật khẩu mới của tài khoản: "
            manv &= CInt(tim("select manv from nhanvien where email='" & txtEmail.Text & "'"))
            sendmail(txtEmail.Text, "Mật khẩu chương trình quản lý gửi xe", manv & vbNewLine & MKmoi)

        Else
            If txtEmail.InvokeRequired Then
                txtEmail.Invoke(New Action(AddressOf guimail))
            Else
                ErrorProvider1.SetError(txtEmail, "Email không tồn tại")
            End If
        End If
    End Sub

#End Region

    Private Sub frmDangnhap_FormClosed(ByVal sender As Object, ByVal e As FormClosedEventArgs) Handles Me.FormClosed
#If DATA Then
        If thoigiandangxuat <> Nothing Then
            chamcong(thoigiandangnhap, manv, thoigiandangxuat)
        End If
#End If
    End Sub
    Private Sub frmDangnhap_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Control.CheckForIllegalCrossThreadCalls = False
#If DEBUG Then
        txtUser.Text = "admin"
        txtPass.Text = "admin"
#End If
        CheckRegistry()

#If DATA Then
        btnChonDB.Enabled = True
        btnQuenmatkhau.Enabled = True
        g_strConnect = GetConnectionString()
#End If

        lbl_ktketnoi.Text = "Đang kiểm tra kết nối tới CSDL"
        ProgressBar1.Visible = True

        g_savedir = GetSaveDir()
        bwKTthongso.RunWorkerAsync()
        bwInitModel.RunWorkerAsync()
        txtUser.Focus()
    End Sub

#Region "Quen mat khau"

    Sub ForgetPassword()
        ProgressBar2.Visible = True
        lblEmail.Text = "Đang gửi email"
        bwGuimail.RunWorkerAsync()
    End Sub

    Private Sub bwGuimail_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bwGuimail.DoWork
        guimail()
    End Sub

    Private Sub bwGuimail_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bwGuimail.RunWorkerCompleted
        ProgressBar2.Visible = False
        lblEmail.Text = ""
    End Sub

    Private Sub txtEmail_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs)
        If e.KeyCode = Keys.Enter Then
            ForgetPassword()
        End If
    End Sub
#End Region

    Private Sub txtPass_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.Enter Then
            Login()
        End If
    End Sub

    Private Sub txtUser_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.Enter Then
            Login()
        End If
    End Sub

    Private Sub bwKTthongso_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bwKTthongso.DoWork
#If DATA Then
        lbl_ktketnoi.Text = "Đang kiểm tra kết nối tới CSDL"
        ProgressBar1.Visible = True
        m_isConnectSuccess = IsConnected()
#End If
        'g_modelCharNum = Model.Read(Application.StartupPath & "\svmCharNum.model")
        btnDangnhap.Enabled = True
    End Sub

    Private Sub bwKTthongso_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bwKTthongso.RunWorkerCompleted
        lbl_ktketnoi.Visible = False
        ProgressBar1.Visible = False
#If DATA Then
        If Not m_isConnectSuccess Then
            Me.Hide()
            Me.ShowInTaskbar = False
            frmDatabase.Show()
        End If
#End If
    End Sub


    Private Sub bwInitModel_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bwInitModel.DoWork
        InitModel()
    End Sub

    Private Sub btnDangnhap_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDangnhap.Click
        Login()
    End Sub

    Private Sub btnChonDB_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnChonDB.Click
        Me.Hide()
        frmDatabase.Show()
    End Sub

    Private Sub btnQuenmatkhau_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnQuenmatkhau.Click
        If Me.Size = MaximumSize Then
            Me.Size = MinimumSize
            txtUser.Focus()
        Else
            Me.Size = MaximumSize
            txtEmail.Focus()
        End If
    End Sub

    Private Sub btnGuipass_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuipass.Click
        ForgetPassword()
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
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

    Private Sub txtPass_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPass.KeyUp
        If e.KeyCode = Keys.Enter Then
            Login()
        End If
    End Sub

    Private Sub txtUser_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtUser.KeyUp
        If e.KeyCode = Keys.Enter Then
            Login()
        End If
    End Sub
End Class

