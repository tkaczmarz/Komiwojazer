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
            
            Console.WriteLine("Obliczanie ścieżki dla punktów:");
            Print(points);
            Console.WriteLine();

            List<Point> path = Algorithm(points);

            Console.WriteLine("Ścieżka wynikowa:");
            for (int i = 0; i < path.Count; i++)
            {
                Console.Write(path[i]);
                if (i != path.Count - 1)
                    Console.Write(" -> ");
            }

            //Application.Run(new DrawingForm(path));

            Console.ReadKey();
        }

        private static List<Point> Algorithm(List<Point> points)
        {
            // calculate distances
            Dictionary<Point, double[]> distances = new Dictionary<Point, double[]>();
            for (int i = 0; i < points.Count; i++)
            {
                List<double> dist = new List<double>();
                for (int j = 0; j < points.Count; j++)
                {
                    dist.Add(Point.Distance(points[i], points[j]));
                }
                distances.Add(points[i], dist.ToArray());
            }
            Console.WriteLine("Odległości:");
            foreach (Point p in points)
            {
                Print(distances[p]);
            }
            Console.WriteLine();

            List<Point> B = new List<Point>();
            B.Add(points[0]);
            B.Add(points[1]);

            //double[] B = new double[(int)Math.Pow(points.Count, 2)];
            //B[1] = Point.Distance(points[0], points[1]);

            for (int j = 2; j < points.Count; j++)
            {
                Print(B);
                double min = double.MaxValue;
                double suma = 0;
                for (int i = j - 2; i >= 1; i--)
                {
                    double d = B[i + 1] + Point.Distance(points[i], points[j]) + suma;
                    if (d < min)
                        min = d;
                    suma += Point.Distance(points[i], points[i + 1]);
                }
                B[j] = min;
            }
            Print(B);

            return new List<Point>();
        }

        private static void Print<T>(List<T> list)
        {
            foreach (T p in list)
            {
                Console.Write(p + ", ");
            }
            Console.WriteLine("\b\b  ");
        }

        private static void Print<T>(T[] array)
        {
            if (array.Length > 0)
                Console.Write(array[0]);
            for (int i = 1; i < array.Length; i++)
            {
                Console.Write(", " + array[i]);
            }
            Console.WriteLine();
        }
    }
}
