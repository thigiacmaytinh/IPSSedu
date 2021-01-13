Imports Emgu.CV.Structure
Imports Emgu.CV
Imports System.IO
Imports System.Text
Imports SVM
Imports System.Text.RegularExpressions

Class Detector



    Public g_modelNum As Model
    Public g_modelCharNum As Model

    Public g_plateDetector As CascadeClassifier
    Public g_charDetector As CascadeClassifier

    Function DetectPlate(ByVal img As Image(Of Bgr, Byte)) As Image(Of Bgr, Byte)
        'định vị biển số
        Dim grayImg As Image(Of Gray, Byte) = img.Convert(Of Gray, Byte)()
        Dim result As Image(Of Bgr, Byte) = Nothing

        Dim bs = g_plateDetector.DetectMultiScale(grayImg, 1.1, 3, New Size(30, 30), Size.Empty)
        For Each bs1 In bs
            result = img.Copy(bs1).Resize(CInt(bs1.Width * 360 / bs1.Height), 360, CvEnum.Inter.Linear)
            Return result
        Next
        Return Nothing
    End Function

    Function PredictSVM(ByVal binaryStringSVM As String, ByVal model As Model) As Integer
        'sử dụng SVM để nhận dạng ký tự
        Dim kytu As String = ""
        File.WriteAllText("test.test", "0 " & binaryStringSVM)

        Dim test As Problem = Problem.Read("test.test")
        Prediction.Predict(test, "result.out", model, False)

        kytu = File.ReadAllText("result.out")
        Return CInt(kytu.Trim())

    End Function

    Function ImageToSVMToBinaryString(ByVal img As Image(Of Gray, Byte)) As String
        If img.Data.Length = 0 Then
            Return ""
        End If
        Dim result = ""


        Dim dblmucxam = img.GetAverage.Intensity
        Dim index As Integer
        For m As Integer = 0 To img.Height - 1
            For n As Integer = 0 To img.Width - 1
                If img(m, n).Intensity > dblmucxam Then
                    index = m * img.Width + n + 1
                    result &= index & ":1 "
                End If
            Next
        Next

        Return result
    End Function

    Function PredictSVM(ByVal img As Image(Of Gray, Byte), type As String) As String
        If img IsNot Nothing Then
            Dim grayImg As Image(Of Gray, Byte) = img.Convert(Of Gray, Byte)()
            grayImg._Not()

            Dim binaryString = ImageToSVMToBinaryString(grayImg)
            If type = "num" Then
                Return PredictSVM(binaryString, g_modelNum)
            End If
            Return IntToChar(PredictSVM(binaryString, g_modelCharNum))
        End If
        Return "_"
    End Function

    Function DetectChar(ByVal img As Image(Of Bgr, Byte)) As String
        'giai đoạn nhận diện ký tự gồm 3 bước:
        'Bước 1: sắp xếp các ký tự từ trái qua phải
        'Bước 2: chuyển ảnh ký tự thành tập dữ liệu SVM hợp lệ
        'Bước 3: nhận diện các tập dữ liệu và nối thành chuỗi kết quả
        Dim GrayImage As Image(Of Gray, Byte) = img.Convert(Of Gray, Byte)()
        Dim rects = g_charDetector.DetectMultiScale(GrayImage, 1.1, 3, New Size(30, 30), Size.Empty)

        'ảnh các ký tự
        Dim imgkytu As Image(Of Gray, [Byte])() = New Image(Of Gray, [Byte])(9) {}
        Dim Part1 As Image(Of Gray, [Byte]) = Nothing
        Dim Part2 As Image(Of Gray, [Byte]) = Nothing
        Dim Part3 As Image(Of Gray, [Byte]) = Nothing
        Dim Part4 As Image(Of Gray, [Byte]) = Nothing
        Dim p1 As Integer = 0
        'lưu các toạ độ của khung chữ nhật chứa ký tự
        Dim toado As Integer() = New Integer(9) {}
        'sắp xếp các ký tự từ trái qua phải, từ trên xuống dưới
        For Each rect In rects
            If rect.Y < 65 OrElse rect.Y > 165 Then
                If rect.Y > 170 Then
                    imgkytu(p1) = GrayImage.Copy(rect).Resize(20, 48, CvEnum.Inter.Linear)
                    toado(p1) = rect.X
                    For k As Integer = 0 To p1 - 1
                        If toado(p1) < toado(k) Then
                            Dim tempImage As Image(Of Gray, [Byte]) = imgkytu(p1)
                            imgkytu(p1) = imgkytu(k)
                            imgkytu(k) = tempImage
                            Dim temp As Integer = toado(p1)
                            toado(p1) = toado(k)
                            toado(k) = temp
                        End If
                    Next
                    p1 += 1
                Else
                    If rect.X > 50 AndAlso rect.X < 100 Then
                        Part1 = GrayImage.Copy(rect).Resize(20, 48, CvEnum.Inter.Linear)
                    ElseIf rect.X > 100 AndAlso rect.X < GrayImage.Width / 2 Then
                        Part2 = GrayImage.Copy(rect).Resize(20, 48, CvEnum.Inter.Linear)
                    ElseIf rect.X > GrayImage.Width / 2 AndAlso rect.X < 300 Then
                        Part3 = GrayImage.Copy(rect).Resize(20, 48, CvEnum.Inter.Linear)
                    Else
                        Part4 = GrayImage.Copy(rect).Resize(20, 48, CvEnum.Inter.Linear)
                    End If
                End If
            End If
        Next
        Dim temp1 As String = ""
        Dim temp2 As String = ""
        Dim temp3 As String = ""
        Dim temp4 As String = ""
        Dim temp5 As String() = New String(5) {}


        'chuyển thành tập SVM hợp lệ

        If imgkytu IsNot Nothing Then
            For i As Integer = 0 To p1 - 1
                imgkytu(i)._Not()
                temp5(i) &= ImageToSVMToBinaryString(imgkytu(i))
            Next
        End If


        'dự đoán số
        Dim result As String = ""
        result &= PredictSVM(Part1, "num")
        result &= PredictSVM(Part2, "num")
        result &= "-"
        result &= PredictSVM(Part3, "charnum")
        result &= PredictSVM(Part4, "charnum")

        result &= "-"
        For j As Integer = 0 To p1 - 1
            result &= PredictSVM(temp5(j), g_modelNum)
        Next

        Return result.Trim()

    End Function

    Dim chars() As String = {"A", "B", "C", "D", "E", "F", "G", "H", "K", "L", "M", "N", "P", "R", "S", "T", "U", "V", "X", "Y", "Z"}
    '                         10   11  12    13   14   15   16   17   18   19   20    21   22  23   24   25   26   27   28   29  30
    Function IntToChar(ByVal i As Integer) As String
        'chuyển các nhãn được SVM nhận dạng thành ký tự
        If i < 10 Then
            Return i.ToString()
        End If

        Return chars(i - 10)
    End Function

    'Function docbienso(ByVal img As Image(Of Bgr, Byte), ByVal anhtruoc As Image(Of Bgr, Byte), ByVal picTruoc As PictureBox, ByVal picSau As PictureBox) As String
    Function docbienso(ByVal img As Image(Of Bgr, Byte)) As String

        LoadData()

        'hàm trả về ký tự biển số và hiển thị ảnh biển số lên imgbox
        Dim bienso As String = ""
        Dim imgPlate As Image(Of Bgr, Byte) = DetectPlate(img)
        If imgPlate IsNot Nothing Then
            bienso = DetectChar(imgPlate)
            'picTruoc.Image = anhtruoc.Bitmap
            'picSau.Image = imgPlate.ToBitmap
        End If
        Return bienso
    End Function

    Sub LoadData()
        If g_modelCharNum Is Nothing Then
            g_modelCharNum = Model.Read(Application.StartupPath & "\svmCharNum.model")
            g_plateDetector = New CascadeClassifier(Application.StartupPath & "\bienso.xml")
            g_charDetector = New CascadeClassifier(Application.StartupPath & "\kytu.xml")
            g_modelNum = Model.Read(Application.StartupPath & "\svmNum.model")
        End If
    End Sub
End Class
