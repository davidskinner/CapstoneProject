using System;
using System.Drawing;
using System.Drawing.Imaging;

namespace ShortestPathTest
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            string path = $"/Users/davidskinner/Documents/Repositories/CapstoneProject/ShortestPathTesting/ShortestPathTest/";
            Bitmap bitmap = new Bitmap($"{path}map1.png");
            Color clr = bitmap.GetPixel(50, 50);
            Color clr2 = Color.FromName("Blue");
            Color red = Color.Red;
            bitmap.SetPixel(2, 2, clr2);
            bitmap.SetPixel(3, 2, red);
            Console.WriteLine($"This is the road: {bitmap.GetPixel(4,2)}");


            // generate the final png
            bitmap.Save($"{path}final.png", ImageFormat.Png);
            
        }
    }
}
