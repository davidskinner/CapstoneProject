using System;
using System.Drawing;
using System.Drawing.Imaging;

namespace ShortestPathTest
{

    class Node
    {
        public int CurrentValue { get; set; }

    }
    class MainClass
    {
        // road color Color [A=255, R=234, G=217, B=176]
        public static void Main(string[] args)
        {
            string path = $"/Users/davidskinner/Documents/Repositories/CapstoneProject/ShortestPathTesting/ShortestPathTest/";
            Bitmap bitmap = new Bitmap($"{path}map1.png");
            Color clr2 = Color.Blue;
            Color red = Color.Red;
            bitmap.SetPixel(2, 2, clr2);
            bitmap.SetPixel(3, 2, red);
            Console.WriteLine($"This is the road: {bitmap.GetPixel(4,2)}");


            //int[,] array = new int[bitmap.Height, bitmap.Width];

        // generate the final png
        bitmap.Save($"{path}final.png", ImageFormat.Png);
            
        }
    }
}
