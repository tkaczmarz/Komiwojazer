using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Komiwojazer
{
    public class Line
    {
        public PointF A { get { return a; } }
        public PointF B { get { return b; } }
        public Point DPointA;
        public Point DPointB;

        private PointF a;
        private PointF b;

        public Line(Point A, Point B)
        {
            DPointA = A;
            DPointB = B;
            a = new PointF((float)A.x * Program.multiplier, (float)A.y * Program.multiplier);
            b = new PointF((float)B.x * Program.multiplier, (float)B.y * Program.multiplier);
        }

        public static List<Line> GetLines(params Point[] points)
        {
            if (points.Length % 2 != 0)
                return null;

            List<Line> lines = new List<Line>();
            for (int i = 0; i < points.Length - 1; i += 2)
            {
                lines.Add(new Line(points[i], points[i + 1]));
            }
            return lines;
        }
    }
}
