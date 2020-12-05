using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Test.Figure ; 


namespace Test 
{
    public interface IFigure
    {
        Point startPoint { get; set; }
        Point secondPoint { get; set; }
        bool started { get; set; }
        Point[] GetPoints();



    }
}
