using System.Collections.Generic;

namespace Komiwojazer
{
    class Point
    {
        public double x;
        public double y;

        public Point(double x, double y)
        {
            this.x = x;
            this.y = y;
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
    }
}
