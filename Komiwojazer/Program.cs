using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Komiwojazer
{
    public class Program
    {
        public static float multiplier = 30;

        static void Main(string[] args)
        {
            List<Point> points = Point.GetPoints(-2, -5, 0, 4, 2, 3, 1, 7);
            
            Application.Run(new DrawingForm(points));

            Console.ReadKey();
        }
    }
}
