using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Komiwojazer
{
    public partial class DrawingForm : Form
    {
        private Pen linePen;
        private Color red;
        private List<Line> lines = new List<Line>();
        private List<Point> points = new List<Point>();
        private int height = 250;
        private int leftMargin = 100;

        public DrawingForm()
        {
            InitializeComponent();
        }

        public DrawingForm(List<Line> lines)
        {
            InitializeComponent();

            linePen = new Pen(Color.Black, 2);
            this.lines = lines;
            red = Color.FromArgb(255, 0, 0);
        }

        public DrawingForm(List<Point> points)
        {
            InitializeComponent();

            linePen = new Pen(Color.Black, 2);
            this.points = points;
            red = Color.FromArgb(255, 0, 0);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            foreach (Line line in lines)
            {
                PointF A = GetPoint(line.A.X, line.A.Y);
                PointF B = GetPoint(line.B.X, line.B.Y);

                g.DrawLine(linePen, A, B);

                DrawPoint(new PointF(A.X - 2, A.Y - 2), g, red);
                DrawPoint(new PointF(B.X - 2, B.Y - 2), g, red);
            }

            if (points.Count > 0)
                g.DrawLines(linePen, PointsToPointFs());
            foreach (Point point in points)
            {
                PointF p = GetPoint(point.xPos, point.yPos);
                DrawPoint(new PointF(p.X - 2, p.Y - 2), g, red);
            }
            if (points.Count > 1)
            {
                PointF p1 = GetPoint(points[points.Count - 1].xPos, points[points.Count - 1].yPos);
                PointF p2 = GetPoint(points[0].xPos, points[0].yPos);
                g.DrawLine(linePen, p1, p2);
            }
        }

        private void DrawPoint(PointF point, Graphics g, Color color)
        {
            int x = (int)point.X;
            int y = (int)point.Y;
            Brush brush = new SolidBrush(color);
            g.FillRectangle(brush, new RectangleF(x, y, 5, 5));
        }

        private PointF GetPoint(float x, float y)
        {
            return new PointF(x + leftMargin, height - y);
        }

        private PointF[] PointsToPointFs()
        {
            List<PointF> p = new List<PointF>();
            foreach (Point point in points)
            {
                p.Add(GetPoint(point.xPos, point.yPos));
            }
            return p.ToArray();
        }
    }
}
