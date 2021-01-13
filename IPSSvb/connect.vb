Imports System.IO
Imports Emgu.CV
Imports System.Data.SqlClient
Imports System.Drawing.Imaging
Imports System.Security
Imports System.Security.Cryptography
Imports System.Text
Imports System.Net.Mail
Imports System.Net
Imports Microsoft.Win32

Module connect
    Public g_strConnect As String = ""
    Public g_conn As SqlConnection
    Public g_savedir As String = ""
    Public g_regKey As RegistryKey = Registry.CurrentUser.OpenSubKey("Software\IPSS", True)

    Sub hiendgv(ByVal sql As String, ByVal dgv As DataGridView)
        dgv.Columns.Clear()
        Dim ds As New DataTable
        Dim da As New SqlDataAdapter(sql, g_conn)
        da.Fill(ds) 'Đổ dữ liệu vào bảng mới tạo
        dgv.DataSource = ds
        ngatketnoi()
    End Sub

    Function retrieveTable(ByVal sql As String) As DataTable
        Dim da As New SqlDataAdapter(sql, g_conn)
        Dim dt As New DataTable
        da.Fill(dt)
        Return dt
    End Function

    Sub hiencb(ByVal sql As String, ByRef cb As System.Windows.Forms.ComboBox)
        cb.Items.Clear()
        Dim comm As New SqlCommand(sql, g_conn)
        ketnoi()
        Dim dr As SqlDataReader = comm.ExecuteReader()
        Do While dr.Read
            For i = 0 To dr.FieldCount - 1
                cb.Items.Add(dr.GetValue(i))
            Next
        Loop
        ngatketnoi()
    End Sub

    Function tim(ByVal sql As String) As Object
        Dim comm As New SqlCommand(sql, g_conn)
        ketnoi()
        Return comm.ExecuteScalar()
    End Function

    Function GetConnectionString() As String
        'trả về chuỗi kết nối lưu trong registry
        Dim chuoi As String = g_regKey.GetValue("ConnectionString").ToString
        If chuoi = "" Then
            Return ""
        Else
            Dim tam = Split(chuoi, ";")
            For i = 0 To tam.Length - 1
                If tam(i).Contains("Password=") Then
                    Dim matkhau = tam(i).Substring(9, tam(i).Length - 9) 'không lấy dấu ;
                    'tam(i) = "Password=" & AES_Decrypt(matkhau, passAES)
                    tam(i) = "Password=" & AES_Decrypt(matkhau, "zxcvbnm")
                    Exit For
                End If
            Next
            Return Join(tam, ";")
        End If
    End Function

    Sub ketnoi()
        If g_strConnect <> "" AndAlso g_conn.State <> ConnectionState.Open Then
            g_conn.Open()
        End If
    End Sub

    Sub ngatketnoi()
        If g_strConnect <> "" AndAlso g_conn.State <> ConnectionState.Closed Then
            g_conn.Close()
        End If
    End Sub

    Function runsql(ByVal sql As String) As String
        Dim comm As New SqlCommand(sql, g_conn)
        Try
            ketnoi()
            comm.ExecuteNonQuery()
            ngatketnoi()
            Return "Thành công"
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Có lỗi xảy ra")
            Return "Thất bại"
        End Try

    End Function

    Function GetSaveDir() As String
        'chỉ ra nơi lưu ảnh biển số
        Try

            Dim dir As String = g_regKey.GetValue("SaveDir").ToString
            If dir = "" OrElse Not New DirectoryInfo(dir).Exists Then
                Directory.CreateDirectory(Application.StartupPath & "\anh\")
                Return Application.StartupPath & "\anh\"
            Else
                Return dir
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Có lỗi xảy ra")
            Return ""
        End Try
    End Function

    Function mahoachuoiketnoi(ByVal str As String) As String
        If str = "" Then
            Return ""
        End If
        Dim tam() = Split(str, ";")
        'mã hoá password
        For i = 0 To tam.Length - 1
            If InStr(tam(i), "Password=") <> 0 Then
                Dim matkhau = tam(i).Substring(9, tam(i).Length - 9) 'không lấy dấu ;
                tam(i) = "Password=" & AES_Encrypt(matkhau, "zxcvbnm")
                Exit For
            End If
        Next
        Return Join(tam, ";")
    End Function

    Sub luuxedisk(ByVal sql As String, ByVal anhtruoc As Image, ByVal anhsau As Image, ByVal thoigian As String)

        If sql.Contains("xevodisk") Then
            'xe vô
            'lưu ảnh phía trước 
            SaveJpeg(g_savedir & thoigian & "-vaotruoc.jpg", anhtruoc)
            'lưu ảnh phía sau
            SaveJpeg(g_savedir & thoigian & "-vaosau.jpg", anhsau)
        Else
            'lưu ảnh phía trước 
            SaveJpeg(g_savedir & thoigian & "-ratruoc.jpg", anhtruoc)
            'lưu ảnh phía sau
            SaveJpeg(g_savedir & thoigian & "-rasau.jpg", anhsau)
        End If
#If DATA Then
        'lưu vào database
        Dim cmd As New SqlCommand(sql, g_conn)
        ketnoi()
        cmd.ExecuteNonQuery()
        ngatketnoi()
#End If
    End Sub

    Sub luuxedisk(ByVal sql As String, ByVal anhsau As Image, ByVal thoigian As String)
        Dim cmd As New SqlCommand(sql, g_conn)
        If InStr(sql, "xevodisk") <> 0 Then
            'anhsau.Save(g_savedir & thoigian & "-vaosau.jpg")
            SaveJpeg(g_savedir & thoigian & "-vaosau.jpg", anhsau)
        Else
            'anhsau.Save(g_savedir & thoigian & "-rasau.jpg")
            SaveJpeg(g_savedir & thoigian & "-rasau.jpg", anhsau)
        End If
        'lưu vào database
        ketnoi()
        cmd.ExecuteNonQuery()
        ngatketnoi()
    End Sub

    Sub SaveJpeg(ByVal path As String, ByVal img As Image)
        ' Encoder parameter for image quality
        Dim qualityParam As New EncoderParameter(System.Drawing.Imaging.Encoder.Quality, 20)
        ' Jpeg image codec 
        Dim jpegCodec As ImageCodecInfo = GetEncoderInfo("image/jpeg")
        Dim encoderParams As New EncoderParameters(1)
        encoderParams.Param(0) = qualityParam
        img.Save(path, jpegCodec, encoderParams)
    End Sub

    Sub luuxeTrain(ByVal anhTruoc As Image, ByVal anhsau As Image, ByVal thoigian As String)
        'lưu ảnh phía trước 
        SaveJpegKhongNen(g_savedir & thoigian & "-vaotruoc-train.jpg", anhTruoc)
        'lưu ảnh phía sau
        SaveJpegKhongNen(g_savedir & thoigian & "-vaosau-train.jpg", anhsau)
    End Sub

    Sub SaveJpegKhongNen(ByVal path As String, ByVal img As Image)
        'lưu ảnh ko nén để train
        ' Encoder parameter for image quality
        Dim qualityParam As New EncoderParameter(System.Drawing.Imaging.Encoder.Quality, 100)
        ' Jpeg image codec 
        Dim jpegCodec As ImageCodecInfo = GetEncoderInfo("image/jpeg")
        Dim encoderParams As New EncoderParameters(1)
        encoderParams.Param(0) = qualityParam
        img.Save(path, jpegCodec, encoderParams)
    End Sub

    Function GetEncoderInfo(ByVal mimeType As String) As ImageCodecInfo
        ' Get image codecs for all image formats 
        Dim codecs As ImageCodecInfo() = ImageCodecInfo.GetImageEncoders()
        ' Find the correct image codec 
        For i As Integer = 0 To codecs.Length - 1
            If (codecs(i).MimeType = mimeType) Then
                Return codecs(i)
                Exit Function
            End If
        Next i
        Return Nothing
    End Function

    Function IsConnected() As Boolean
        'kiểm tra kết nối có thành công hay không 
        If g_strConnect = "" Then
            Return False
        End If
        Try
            If g_conn Is Nothing Then
                g_conn = New SqlConnection(g_strConnect)
            End If
            g_conn.Open()
            If g_conn.State = ConnectionState.Open Then
                g_conn.Close()
                Return True
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Có lỗi xảy ra")
        End Try
        Return False
    End Function

    Sub chamcong(ByVal tgdangnhap As DateTime, ByVal manv As String, ByVal tgdangxuat As DateTime)
        Dim sql = "insert into bangchamcong(thoigiandangnhap,manv,thoigiandangxuat) values('"
        sql &= tgdangnhap.ToString("yyyy-MM-dd hh:mm:ss tt") & "','"
        sql &= manv & "','"
        sql &= tgdangxuat.ToString("yyyy-MM-dd hh:mm:ss tt") & "')"
        runsql(sql)
    End Sub

    Public Function AES_Decrypt(ByVal input As String, ByVal pass As String) As String
        Dim AES As New System.Security.Cryptography.RijndaelManaged
        Dim Hash_AES As New System.Security.Cryptography.MD5CryptoServiceProvider
        Dim decrypted As String = ""
        Try
            Dim hash(31) As Byte
            Dim temp As Byte() = Hash_AES.ComputeHash(System.Text.ASCIIEncoding.ASCII.GetBytes(pass))
            Array.Copy(temp, 0, hash, 0, 16)
            Array.Copy(temp, 0, hash, 15, 16)
            AES.Key = hash
            AES.Mode = Cryptography.CipherMode.ECB
            Dim DESDecrypter As System.Security.Cryptography.ICryptoTransform = AES.CreateDecryptor
            Dim Buffer As Byte() = Convert.FromBase64String(input)
            decrypted = System.Text.ASCIIEncoding.ASCII.GetString(DESDecrypter.TransformFinalBlock(Buffer, 0, Buffer.Length))
            Return decrypted
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Có lỗi xảy ra")
            Return ""
        End Try
    End Function

    Public Function AES_Encrypt(ByVal input As String, ByVal pass As String) As String
        Dim AES As New System.Security.Cryptography.RijndaelManaged
        Dim Hash_AES As New System.Security.Cryptography.MD5CryptoServiceProvider
        Dim encrypted As String = ""
        Try
            Dim hash(31) As Byte
            Dim temp As Byte() = Hash_AES.ComputeHash(System.Text.ASCIIEncoding.ASCII.GetBytes(pass))
            Array.Copy(temp, 0, hash, 0, 16)
            Array.Copy(temp, 0, hash, 15, 16)
            AES.Key = hash
            AES.Mode = Cryptography.CipherMode.ECB
            Dim DESEncrypter As System.Security.Cryptography.ICryptoTransform = AES.CreateEncryptor
            Dim Buffer As Byte() = System.Text.ASCIIEncoding.ASCII.GetBytes(input)
            encrypted = Convert.ToBase64String(DESEncrypter.TransformFinalBlock(Buffer, 0, Buffer.Length))
            Return encrypted
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Có lỗi xảy ra")
            Return ""
        End Try
    End Function

    Function chuoingaunhien() As String
        Dim s As String = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789"
        Dim r As New Random
        Dim sb As New StringBuilder 'sb là mật khẩu chưa mã hoá
        For i As Integer = 1 To 10
            Dim idx As Integer = r.Next(0, 61)
            sb.Append(s(idx))
        Next
        Return sb.ToString
    End Function

    Sub sendmail(ByVal toemail As String, ByVal tieude As String, ByVal noidung As String)
        Dim fromemail As String = "vochiquang@gmail.com"
        Dim password As String = "taolavi2"
        Dim m As New MailMessage(fromemail, toemail, tieude, noidung)
        Dim smtp As New SmtpClient("smtp.gmail.com")
        smtp.Credentials = New NetworkCredential(fromemail, password)
        smtp.EnableSsl = True
        Try
            smtp.Send(m)
            MsgBox("Đã gửi mật khẩu vào email, vui lòng kiểm tra email")
        Catch ex As Exception
            MsgBox("Email không gửi được, vui lòng kiểm tra lại internet")
        End Try
    End Sub

    Function mahoamd5(ByVal str As String) As String
        Dim md5 As New MD5CryptoServiceProvider
        Dim mang As Byte() = md5.ComputeHash(System.Text.Encoding.ASCII.GetBytes(str))
        Dim kq As String = ""
        For i = 0 To mang.Length - 1
            kq &= mang(i).ToString
        Next
        Return kq
    End Function
    Function docso(ByVal number As String) As String
        Return docso(CDec(number))
    End Function
    Function docso(ByVal number As Decimal) As String
        Dim str As String = ""
        Dim s As String = number.ToString()
        Dim so() As String = {"không", "một", "hai", "ba", "bốn", "năm", "sáu", "bảy", "tám", "chín"}
        Dim hang() As String = {"", "ngàn", "triệu", "tỉ"}
        Dim i, j, donvi, chuc, tram As Integer
        Dim booAm As Boolean = False
        Dim decS As Decimal = 0
        Try
            decS = Convert.ToDecimal(s.ToString())
        Catch ex As Exception
        End Try
        If (decS < 0) Then
            decS = -decS
            s = decS.ToString()
            booAm = True
        End If
        i = s.Length 'chiều dài dãy số
        If (i = 0) Then
            str = so(0) & str
        Else
            j = 0
            While (i > 0)
                donvi = Convert.ToInt32(s.Substring(i - 1, 1))
                i -= 1
                If (i > 0) Then
                    chuc = Convert.ToInt32(s.Substring(i - 1, 1))
                Else
                    chuc = -1
                End If
                i -= 1
                If (i > 0) Then
                    tram = Convert.ToInt32(s.Substring(i - 1, 1))
                Else
                    tram = -1
                End If
                i -= 1
                If ((donvi > 0) Or (chuc > 0) Or (tram > 0) Or (j = 3)) Then
                    str = hang(j) & str
                End If
                j += 1
                If (j > 3) Then
                    j = 1
                End If
                If ((donvi = 1) And (chuc > 1)) Then
                    str = "một " & str
                Else
                    If ((donvi = 5) And (chuc > 0)) Then
                        str = "lăm " & str
                    ElseIf (donvi > 0) Then
                        str = so(donvi) & " " & str
                    End If
                End If
                If (chuc < 0) Then
                    Continue While
                Else
                    If ((chuc = 0) And (donvi > 0)) Then
                        str = "lẻ " & str
                    End If
                    If (chuc = 1) Then
                        str = "mười " & str
                    End If
                    If (chuc > 1) Then
                        str = so(chuc) & " mươi " & str
                    End If
                End If
                If (tram < 0) Then
                    Exit While
                Else
                    If ((tram > 0) Or (chuc > 0) Or (donvi > 0)) Then
                        str = so(tram) & " trăm " & str
                    End If
                End If
                str = " " & str
            End While
        End If
        If booAm = True Then
            str = "Âm " & str
        End If
        str = StrConv(str(0), VbStrConv.Uppercase) & str.Substring(1, str.Length - 1) & "đồng"
        Return str
    End Function
End Module
