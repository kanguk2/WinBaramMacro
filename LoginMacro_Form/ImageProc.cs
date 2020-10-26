using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using Tesseract;

namespace LoginMacro_Form
{    
    class ImageProc
    {
 
        private static List<Rectangle> List_Rect = new List<Rectangle>();
        public static string m_strFilePath = "d:\\ImageCompare\\";
        public static string m_strIDInfo = m_strFilePath + "IDInfo\\";
        public static string m_strLogin = m_strFilePath + "Login\\";

        static ImageProc()
        {
            List_Rect.Add(new Rectangle(new System.Drawing.Point(495, 400), new System.Drawing.Size(85, 15)));
            List_Rect.Add(new Rectangle(new System.Drawing.Point(538, 428), new System.Drawing.Size(90, 12)));
            List_Rect.Add(new Rectangle(new System.Drawing.Point(538, 441), new System.Drawing.Size(90, 12)));
            List_Rect.Add(new Rectangle(new System.Drawing.Point(538, 480), new System.Drawing.Size(90, 15)));
            List_Rect.Add(new Rectangle(new System.Drawing.Point(420, 265), new System.Drawing.Size(160, 90)));
        }

        public static Image ImageCrop(int nPID, eImagetype type)
        {
            int nType = (int)type;
            Image img = null;
            try
            {
                Process process = new Process();
                ProcessControl.FindProcess(ref process, nPID);

                ScreenCapture sc = new ScreenCapture();

                if (type != eImagetype.total)
                    img = sc.CaptureWindow(process.MainWindowHandle, List_Rect[nType]);
                else
                    img = sc.CaptureWindow(process.MainWindowHandle);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                img = null;
            }
            finally
            {
                if(img != null)
                    img.Save(m_strFilePath + "temp.bmp", System.Drawing.Imaging.ImageFormat.Bmp);
            }
            return img;
        }

        public void ImageCrop(Image img)
        {
            var ocr = new TesseractEngine("./tessdata", "kor", EngineMode.Default);

            Bitmap real = new Bitmap(img);
            Rectangle rect = new Rectangle(0, 0, real.Width, real.Height);
            Bitmap cap = real.Clone(rect, System.Drawing.Imaging.PixelFormat.Format24bppRgb); // 캡쳐뜬 이미지에서 위의 Rect 만큼 자르기 
            cap = new Bitmap(cap, new System.Drawing.Size(real.Width*2, real.Height*2));
            
            var texts = ocr.Process(cap);
            MessageBox.Show(texts.GetText());
        }

        public static bool ImageCompare(string strOrgPath, string strComparePath)
        {
            bool bRet = true;

            if (System.IO.File.Exists(strOrgPath) == false)
                return false;

            bRet = ImageCompare(strOrgPath, new Bitmap(strComparePath));

            return bRet;
        }

        public static bool ImageCompare(string strOrgPath, Bitmap img_compare)
        {
            bool bRet = true;
            Mat screen = null, find = null, res = null;

            try
            {
                if (System.IO.File.Exists(strOrgPath) == false)
                    throw new Exception("File이 존재하지 않습니다.");

                Bitmap Orgimg = new Bitmap(strOrgPath);

                screen = OpenCvSharp.Extensions.BitmapConverter.ToMat(Orgimg);
                find = OpenCvSharp.Extensions.BitmapConverter.ToMat(img_compare);

                res = screen.MatchTemplate(find, TemplateMatchModes.CCoeffNormed);

                double min, max = 0;
                Cv2.MinMaxLoc(res, out min, out max);
                bRet = (max > 0.9) ? true : false;
            }
            catch (Exception e)
            {
                bRet = false;
            }
            finally
            {
                if(screen != null) screen.Dispose();
                if(find != null) find.Dispose();
                if(res != null) res.Dispose();
            }

            return bRet;
        }

        public void ImageCrop(Bitmap img)
        {
            var ocr = new TesseractEngine("./tessdata", "eng", EngineMode.TesseractOnly);

            var texts = ocr.Process(img);
            MessageBox.Show(texts.GetText());
        }

        public void ImageCrop(Pix pix)
        {
            var ocr = new TesseractEngine("./tessdata", "kor", EngineMode.Default);

            var texts = ocr.Process(pix);
            MessageBox.Show(texts.GetText());
        }

        public Pix ImageConverter(Bitmap screen, Rectangle rect)
        {
            Bitmap cap = screen.Clone(rect, System.Drawing.Imaging.PixelFormat.Format32bppArgb); // 캡쳐뜬 이미지에서 위의 Rect 만큼 자르기 

            cap = new Bitmap(cap, new System.Drawing.Size(screen.Width, screen.Height)); // 인식률을 높이기위해 두배크기로 리사이즈 

            return PixConverter.ToPix(screen);
        }

        public Bitmap ThresholdImage(Bitmap image, Rectangle rect)
        {
            int R, G, B = 0;

            int nThreshold = ConvertStringtoInt("0");//text_thresholdvalue.ToString());

            for (int i = 0; i < image.Width; i++)
            {
                for (int j = 0; j < image.Height; j++)
                {
                    Color c = image.GetPixel(i, j);
                    R = c.R;
                    G = c.G;
                    B = c.B;

                    if (R > nThreshold && G > nThreshold && B > nThreshold)
                    {
                        image.SetPixel(i, j, Color.White);
                    }
                    else
                    {
                        image.SetPixel(i, j, Color.Black);
                    }

                }
            }

            //image = ResizeImage(image, rect.Width, rect.Height);

            return image;
        }
        public Bitmap ThresholdImage_Name(Bitmap image, Rectangle rect)
        {
            int R, G, B = 0;

            int nThreshold = ConvertStringtoInt("0");// text_thresholdvalue.ToString());

            for (int i = 0; i < image.Width; i++)
            {
                for (int j = 0; j < image.Height; j++)
                {
                    Color c = image.GetPixel(i, j);
                    R = c.R;
                    G = c.G;
                    B = c.B;

                    if (R==255 && G==255 && B == 255)
                    {
                        image.SetPixel(i, j, Color.Black);
                    }
                    else
                    {
                        image.SetPixel(i, j, Color.White);
                    }

                }
            }

            //image = ResizeImage(image, rect.Width, rect.Height);

            return image;
        }

        private int ConvertStringtoInt(string str)
        {
            int nLen = str.Length;
            int nRet = 0;
            for(int i=0;i<nLen;i++)
            {
                nLen += (str[nLen - 1] - '0') * (int)Math.Pow((double)10, (double)nLen - 1);
            }
            return nRet;
        }
    }
}
