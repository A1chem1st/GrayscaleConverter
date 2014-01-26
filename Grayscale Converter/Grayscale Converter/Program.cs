using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;

namespace Grayscale_Converter
{
    class Program
    {
        static void Main(string[] args)
        {
            var image = new Bitmap(@"D:\DiplomaProject\test.jpg");
            ConvertAverage(ref image).Save(@"D:\DiplomaProject\average.jpg");
            ConvertLightness(image).Save(@"D:\DiplomaProject\light.jpg");
            ConvertLuminosity(image).Save(@"D:\DiplomaProject\lum.jpg");
        }

        public static Bitmap ConvertAverage(ref Bitmap image)
        {
            for (int x = 0; x < image.Width; x++)
            {
                for (int y = 0; y < image.Height; y++)
                {
                    var color = image.GetPixel(x, y);
                    var average = Convert.ToInt32((color.R + color.G + color.B) / 3);
                    var newColor = Color.FromArgb(average, average, average);
                    image.SetPixel(x, y, newColor);
                }
            }
            return image;
        }

        public static Bitmap ConvertLightness(Bitmap image)
        {
            for (int x = 0; x < image.Width; x++)
            {
                for (int y = 0; y < image.Height; y++)
                {
                    var color = image.GetPixel(x, y);
                    var light = Convert.ToInt32((GetMax(color.R, color.G, color.B) + GetMin(color.R, color.G, color.B)) / 2);
                    var newColor = Color.FromArgb(light, light, light);
                    image.SetPixel(x, y, newColor);
                }
            }
            return image;
        }

        public static Bitmap ConvertLuminosity(Bitmap image)
        {
            for (int x = 0; x < image.Width; x++)
            {
                for (int y = 0; y < image.Height; y++)
                {
                    var color = image.GetPixel(x, y);
                    var lum = Convert.ToInt32(color.R * 0.21 + color.G * 0.71 + color.B * 0.07);
                    var newColor = Color.FromArgb(lum, lum, lum);
                    image.SetPixel(x, y, newColor);
                }
            }
            return image;
        }

        public static int GetMax(int a, int b, int c)
        {
            return Math.Max(a, Math.Max(b, c));
        }

        public static int GetMin(int a, int b, int c)
        {
            return Math.Min(a, Math.Min(b, c));
        }
    }
}
