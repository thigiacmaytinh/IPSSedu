Imports Emgu.CV
Imports Emgu.CV.Structure
Imports System.IO

Public Class frmChonWC
    Dim cap0 As Capture
    Dim cap1 As Capture
    Dim cap2 As Capture
    Dim cap3 As Capture

    Dim m_isHaveCap0 As Boolean = False
    Dim m_isHaveCap1 As Boolean = False
    Dim m_isHaveCap2 As Boolean = False
    Dim m_isHaveCap3 As Boolean = False

    Dim m_currentCap As Integer = -1

    Private Sub frmChonWC_FormClosed(ByVal sender As Object, ByVal e As FormClosedEventArgs) Handles Me.FormClosed
        frmChinh8.Show()
    End Sub

    Private Sub frmChonWC_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            cap0 = New Capture(0)
            cbRasau.Items.Add("Camera 1")
            cbRatruoc.Items.Add("Camera 1")
            cbVaosau.Items.Add("Camera 1")
            cbVaotruoc.Items.Add("Camera 1")
            m_isHaveCap0 = True
        Catch ex As Exception
        End Try

        Try
            cap1 = New Capture(1)
            cbRasau.Items.Add("Camera 2")
            cbRatruoc.Items.Add("Camera 2")
            cbVaosau.Items.Add("Camera 2")
            cbVaotruoc.Items.Add("Camera 2")
            m_isHaveCap1 = True
        Catch ex As Exception
        End Try

        Try
            cap2 = New Capture(2)
            cbRasau.Items.Add("Camera 3")
            cbRatruoc.Items.Add("Camera 3")
            cbVaosau.Items.Add("Camera 3")
            cbVaotruoc.Items.Add("Camera 3")
            m_isHaveCap2 = True
        Catch ex As Exception
        End Try

        Try
            cap3 = New Capture(3)
            cbRasau.Items.Add("Camera 4")
            cbRatruoc.Items.Add("Camera 4")
            cbVaosau.Items.Add("Camera 4")
            cbVaotruoc.Items.Add("Camera 4")
            m_isHaveCap3 = True
        Catch ex As Exception
        End Try

        Dim message = "Unable capture from camera: "
        If Not m_isHaveCap0 Then
            message &= "1  "
        End If
        If Not m_isHaveCap1 Then
            message &= "2  "
        End If
        If Not m_isHaveCap2 Then
            message &= "3  "
        End If
        If Not m_isHaveCap3 Then
            message &= "4"
        End If
        If message.Length > 28 Then
            MsgBox(message, MsgBoxStyle.Critical, "Có lỗi xảy ra")
        End If
    End Sub

    Private Sub rdVaotruoc_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdVaotruoc.CheckedChanged
        If rdVaotruoc.Checked Then
            cbVaotruoc.Enabled = True
            cbVaosau.Enabled = False
            cbRasau.Enabled = False
            cbRatruoc.Enabled = False
            m_currentCap = cbVaotruoc.SelectedIndex
        End If
    End Sub

    Private Sub rdVaosau_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdVaosau.CheckedChanged
        If rdVaosau.Checked Then
            cbVaosau.Enabled = True
            cbVaotruoc.Enabled = False
            cbRasau.Enabled = False
            cbRatruoc.Enabled = False
            m_currentCap = cbVaosau.SelectedIndex
        End If
    End Sub

    Private Sub rdRatruoc_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdRatruoc.CheckedChanged
        If rdRatruoc.Checked Then
            cbRatruoc.Enabled = True
            cbVaosau.Enabled = False
            cbVaotruoc.Enabled = False
            cbRasau.Enabled = False
            m_currentCap = cbRatruoc.SelectedIndex
        End If
    End Sub

    Private Sub rdRasau_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdRasau.CheckedChanged
        If rdRasau.Checked Then
            cbRasau.Enabled = True
            cbVaosau.Enabled = False
            cbVaotruoc.Enabled = False
            cbRatruoc.Enabled = False
            m_currentCap = cbRasau.SelectedIndex
        End If
    End Sub

    Private Sub cbVaotruoc_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbVaotruoc.SelectedIndexChanged
        m_currentCap = cbVaotruoc.SelectedIndex
        Timer1.Enabled = True
    End Sub

    Private Sub cbVaosau_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbVaosau.SelectedIndexChanged
        m_currentCap = cbVaosau.SelectedIndex
        Timer1.Enabled = True
    End Sub

    Private Sub cbRatruoc_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbRatruoc.SelectedIndexChanged
        m_currentCap = cbRatruoc.SelectedIndex
        Timer1.Enabled = True
    End Sub

    Private Sub cbRasau_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbRasau.SelectedIndexChanged
        m_currentCap = cbRasau.SelectedIndex
        Timer1.Enabled = True
    End Sub

    Private Sub btnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOk.Click

        If cbRasau.SelectedIndex = -1 Or cbRatruoc.SelectedIndex = -1 Or cbVaosau.SelectedIndex = -1 Or cbVaotruoc.SelectedIndex = -1 Then
            MsgBox("Chưa chọn đủ 4 camera")
        Else
            g_regKey.SetValue("camera0", cbVaosau.SelectedIndex.ToString)
            g_regKey.SetValue("camera1", cbVaotruoc.SelectedIndex.ToString)
            g_regKey.SetValue("camera2", cbRasau.SelectedIndex.ToString)
            g_regKey.SetValue("camera3", cbRatruoc.SelectedIndex.ToString)
            Me.Close()
        End If
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        If m_currentCap = -1 Then
            Timer1.Enabled = False
        End If
        If m_currentCap = 0 Then
            ImageBox1.Image = cap0.QueryFrame
        ElseIf m_currentCap = 1 Then
            ImageBox1.Image = cap1.QueryFrame
        ElseIf m_currentCap = 2 Then
            ImageBox1.Image = cap2.QueryFrame
        ElseIf m_currentCap = 3 Then
            ImageBox1.Image = cap3.QueryFrame
        End If
    End Sub
End Class