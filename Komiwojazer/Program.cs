using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Komiwojazer
{
    public class Program
    {
        public static float multiplier = 30;
        private static List<Point> points;
        private static double[,] distances;
        private static List<Point> path;

        static void Main(string[] args)
        {
            points = Point.GetPoints(-2, -5, 0, 4, 2, 3, 1, 7);
            
            Console.WriteLine("Obliczanie ścieżki dla punktów:");
            Print(points);
            Console.WriteLine();

            Algorithm(points);

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
        
        private static void Algorithm(List<Point> points)
        {
            // calculate distances
            distances = new double[points.Count, points.Count];
            for (int i = 0; i < points.Count; i++)
            {
                for (int j = 0; j < points.Count; j++)
                {
                    distances[i, j] = Point.Distance(points[i], points[j]);
                }
            }
            Console.WriteLine("Odległości:");
            for (int i = 0; i < points.Count; i++)
            {
                for (int j = 0; j < points.Count; j++)
                {
                    Console.Write(distances[i, j] + ", ");
                }
                Console.WriteLine("\b\b  ");
            }
            Console.WriteLine();

            path = new List<Point>();
            path.Add(points[0]);
            List<int> neighbors = new List<int>();
            for (int i = 1; i < points.Count; i++)
                neighbors.Add(i);
            double c = g(0, neighbors);
            Console.WriteLine("Cost of path = " + c);
        }

        private static double g(int node, List<int> neighbors)
        {
            //Console.Write("Calculating for [" + node + ", {");
            //foreach (int i in neighbors)
            //    Console.Write(i + ", ");
                
            if (neighbors.Count > 0)
            {
                //Console.WriteLine("\b\b}] ");
                double cost = 0;
                List<double> costs = new List<double>();
                double min = double.MaxValue;
                int idx = 0;
                for (int i = 0; i < neighbors.Count; i++)
                {
                    cost = distances[node, neighbors[i]];
                    List<int> S = new List<int>(neighbors);
                    int newNode = S[i];
                    S.RemoveAt(i);
                    costs.Add(cost + g(newNode, S));
                    if (costs[costs.Count - 1] < min)
                    {
                        min = costs[costs.Count - 1];
                        idx = newNode;
                    }
                }

                return Min(costs);
            }
            else
                return distances[node, 0];
        }

        private static double Min(List<double> list)
        {
            double min = double.MaxValue;
            foreach (double d in list)
            {
                if (d < min)
                    min = d;
            }
            return min;
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
