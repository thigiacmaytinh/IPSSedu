using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SVM;
using System.Drawing;
using System.IO;
using OpenCVDotNet;

namespace PlateDetector
{
    public partial class Detector
    {
        Model g_modelNum;
        Model g_modelCharNum;

        public Detector()
        {
            InitModelSVM();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////////////

        ~Detector()
        {

        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////////////

        Bitmap DetectPlate(Bitmap bmp)        
        {
            CVImage img = new CVImage(bmp);
            return img.DetectPlate(true);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////////////

        void InitModelSVM()
        {
            g_modelNum = Model.Read("svmNum.model");
            g_modelCharNum = Model.Read("svmCharNum.model");
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////////////

        int PredictSVM(String binaryStringSVM, Model model)
        {
            //sử dụng SVM để nhận dạng ký tự
            String kytu = "";
            string temp = Path.GetTempFileName();
            File.WriteAllText(temp, "0 " + binaryStringSVM);

            Problem test = Problem.Read(temp);

            Prediction.Predict(test, temp, model, false);

            kytu = File.ReadAllText(temp);
            return int.Parse(kytu.Trim());
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////////////

        double GetMediumIntensity(Bitmap bmp)
        {
            double intensity = 0;
            for (int i = 0; i < bmp.Height; i++)
            {
                for (int j = 0; j < bmp.Width; j++)
                {
                    intensity += (bmp.GetPixel(j, i).G + bmp.GetPixel(j, i).R + bmp.GetPixel(j, i).B) / 3;
                }
            }
            return intensity / (bmp.Height * bmp.Width);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////////////

        String ImageToSVMToBinaryString(Bitmap bmp)
        {
            if (bmp == null)
                return "";

            string result = "";


            double dblmucxam = GetMediumIntensity(bmp);
            int index;
            for (int m = 0; m < bmp.Height; m++)
                for (int n = 0; n < bmp.Width; n++)
                {
                    int intensity = (bmp.GetPixel(n, m).G + bmp.GetPixel(n, m).R + bmp.GetPixel(n, m).B) / 3;
                    if (intensity < dblmucxam)
                    {
                        index = m * bmp.Width + n + 1;
                        result += index.ToString() + ":1 ";
                    }
                }

            return result;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public string PredictSVM(Bitmap bmp, string type)
        {
            if (g_modelNum == null || g_modelCharNum == null)
                InitModelSVM();

            if (bmp != null)
            {
                dynamic binaryString = ImageToSVMToBinaryString(bmp);
                if (type == "num")
                {
                    int i = PredictSVM(binaryString, g_modelNum);
                    return i.ToString();
                }
                else
                {
                    string str = IntToChar(PredictSVM(binaryString, g_modelCharNum));
                    if (str == null)
                        return "";
                    return str;
                }
            }
            return "_";
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////////////

        Bitmap Crop(Bitmap bmp, Rectangle rect)
        {
            Bitmap target = new Bitmap(rect.Width, rect.Height);

            using (Graphics g = Graphics.FromImage(target))
            {
                g.DrawImage(bmp, new Rectangle(0, 0, target.Width, target.Height), rect, GraphicsUnit.Pixel);
            }
            return target;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////////////

        Bitmap Resize(Bitmap bmp, Size size)
        {
            return (Bitmap)(new Bitmap(bmp, size));
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public string DetectChar(Bitmap bmp)
        {
            //giai đoạn nhận diện ký tự gồm 3 bước:
            //Bước 1: sắp xếp các ký tự từ trái qua phải
            //Bước 2: chuyển ảnh ký tự thành tập dữ liệu SVM hợp lệ
            //Bước 3: nhận diện các tập dữ liệu và nối thành chuỗi kết quả


            CVImage img = new CVImage(bmp);
            string chars = img.DetectChar();

            int nRects = (chars.Length - chars.Replace("_", "").Length + 1) / 4;
            if (nRects == 0)
                return "";

            List<Rectangle> rects = new List<Rectangle>(nRects);
            string[] points = chars.Split(new char[] { '_' });
            for (int i = 0; i < nRects; i += 1)
            {
                Rectangle rect = new Rectangle(int.Parse(points[i * 4 + 0]), int.Parse(points[i * 4 + 1]), int.Parse(points[i * 4 + 2]), int.Parse(points[i * 4 + 3]));
                rects.Add(rect);
            }


            //ảnh các ký tự
            List<Bitmap> imgkytu = new List<Bitmap>(9);
            Bitmap Part1 = null;
            Bitmap Part2 = null;
            Bitmap Part3 = null;
            Bitmap Part4 = null;
            int p1 = 0;
            //lưu các toạ độ của khung chữ nhật chứa ký tự
            int[] toado = new int[10];

            //sắp xếp các ký tự từ trái qua phải, từ trên xuống dưới
            for (int i = 0; i < nRects; i++)
            {
                Rectangle rect = rects[i];
                if (rect.Y < 65 || rect.Y > 165)
                {
                    if (rect.Y > 170)
                    {
                        imgkytu.Add(Resize(Crop(bmp, rect), new Size(20, 48)));
                        toado[p1] = rect.X;
                        for (int k = 0; k <= p1 - 1; k++)
                        {
                            if (toado[p1] < toado[k])
                            {
                                Bitmap tempImage = imgkytu[p1];
                                imgkytu[p1] = imgkytu[k];
                                imgkytu[k] = tempImage;
                                int temp = toado[p1];
                                toado[p1] = toado[k];
                                toado[k] = temp;
                            }
                        }
                        p1 += 1;
                    }
                    else
                    {
                        if (rect.X > 50 && rect.X < 100)
                            Part1 = Resize(Crop(bmp, rect), new Size(20, 48));
                        else if (rect.X > 100 && rect.X < bmp.Width / 2)
                            Part2 = Resize(Crop(bmp, rect), new Size(20, 48));
                        else if (rect.X > bmp.Width / 2 && rect.X < 300)
                            Part3 = Resize(Crop(bmp, rect), new Size(20, 48));
                        else
                            Part4 = Resize(Crop(bmp, rect), new Size(20, 48));
                    }
                }
            }

            string[] temp5 = new string[6];


            //chuyển thành tập SVM hợp lệ

            if (imgkytu != null)
            {
                for (int i = 0; i <= p1 - 1; i++)
                {
                    temp5[i] += ImageToSVMToBinaryString(imgkytu[i]);
                }
            }


            //dự đoán số
            string result = "";
            result += PredictSVM(Part1, "num");
            result += PredictSVM(Part2, "num");
            result += "-";
            result += PredictSVM(Part3, "charnum");
            result += PredictSVM(Part4, "charnum");

            result += "-";
            for (int j = 0; j <= p1 - 1; j++)
            {
                result += PredictSVM(temp5[j], g_modelNum);
            }

            return result.Trim();

        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////////////

        string[] chars = { "A", "B", "C", "D", "E", "F", "G", "H", "K", "L", "M", "N", "P", "R", "S", "T", "U", "V", "X", "Y", "Z" };
        //                  10  11  12   13  14  15  16  17  18  19  20  21  22  23  24  25  26  27  28  29  30
        public string IntToChar(int i)
        {
            //chuyển các nhãn được SVM nhận dạng thành ký tự
            if (i < 10)
            {
                return i.ToString();
            }

            return chars[i - 10];
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////////////

        Bitmap Test(Bitmap bmp)
        {
            return bmp;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public string GetLicensePlate(Bitmap bmp)
        {
            //hàm trả về ký tự biển số và hiển thị ảnh biển số lên imgbox
            string bienso = "Not found";
            Bitmap imgPlate = DetectPlate(bmp);
            if (imgPlate != null)
            {
                bienso = DetectChar(imgPlate);
            }
            return bienso;
        }
    }
}
