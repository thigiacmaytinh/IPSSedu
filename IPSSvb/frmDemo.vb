Imports Emgu.CV
Imports Emgu.CV.Structure

Public Class frmDemo

    Dim detector As New Detector()
    Private Sub frmDemo_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btnDetect_Click(sender As Object, e As EventArgs) Handles btnDetect.Click
        If txtPath.Text = "" Then
            Return
        End If

        Dim bmp As Bitmap = New Bitmap(txtPath.Text)

        Dim img As New Image(Of Bgr, Byte)(bmp)

        Text = detector.docbienso(img)
    End Sub
End Class