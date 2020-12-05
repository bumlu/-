using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;



namespace Test.Figure
{
    public class Line : IFigure
    {
        public Point startPoint { get; set; }
        public Point secondPoint { get; set; }
        public bool started { get; set; }

        public Line ()
        {
            started = false;

        }

       public Point[] GetPoints()
        {
            Point [] points = new Point[2];
            points[0] = startPoint;
            points[1] = secondPoint;
            return points;
        }




    }
}

