using System;
using System.Collections.Generic;

namespace Komiwojazer
{
    public class Point
    {
        public double x;
        public double y;
        public float xPos;
        public float yPos;

        public Point(double x, double y)
        {
            this.x = x;
            this.y = y;
            xPos = (float)x * Program.multiplier;
            yPos = (float)y * Program.multiplier;
        }

        public static List<Point> GetPoints(params double[] coords)
        {
            List<Point> points = new List<Point>();
            for (int i = 0; i < coords.Length - 1; i += 2)
            {
                points.Add(new Point(coords[i], coords[i + 1]));
            }
            return points;
        }

        public override string ToString()
        {
            return string.Format("({0}, {1})", x, y);
        }

        public static double Distance(Point a, Point b)
        {
            return (Math.Sqrt(Math.Pow(a.x - b.x, 2) + Math.Pow(a.y - b.y, 2)));
        }
    }
}
