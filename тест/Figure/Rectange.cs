using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;


namespace Test.Figure
{
    public class Rectange : IFigure
    {
        public Point startPoint { get; set; }
        public  Point secondPoint { get; set; }
        public  bool started { get; set; }

        public Rectange()
        {
            started = false;
        }


        public Point[] GetPoints()
        {
            Point[] points = new Point[3];

            points[0] = startPoint;
            points[1] = secondPoint;
            points[2].X = startPoint.X;
            points[2].Y = secondPoint.Y;
            return points;
        }
    }
}
