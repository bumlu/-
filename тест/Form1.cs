using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Test.Figure;

namespace Test
{
    public partial class Form1 : Form
    {
        Bitmap mainBitmap;
        Graphics graphics;
        Pen pen = new Pen(Color.Red, 6);
        bool mouseDown = false;
        bool mouseMove = false;
        bool mouseUp = false;
        Point startpoint = new Point(1,1);
        Point secondpoint = new Point(7,10);
        Bitmap tmpBitmap;
        IFigure _figure;
        String Mode;
        List <Point> pointList;
        Point mouseTracker;
        int i = 0;
        
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            mainBitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            graphics = Graphics.FromImage(mainBitmap);
            pictureBox1.Image = mainBitmap;
            pen = new Pen(Color.Black, 5);
            pointList = new List<Point> ();
        }
        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            mouseMove = true;
            tmpBitmap = (Bitmap)mainBitmap.Clone();
            graphics = Graphics.FromImage(tmpBitmap);


            switch (Mode)
            {
                case "Draw":
                    if (mouseDown == true)
                    {
                        graphics.DrawLine(pen, pointList[0], e.Location);
                        pictureBox1.Image = tmpBitmap;
                    }
                    else if (mouseUp == true)
                    {
                    }
                    break;
                case "Stop":
                    {
                    if ((e.Location.X - secondpoint.X) / (startpoint.X - secondpoint.X) == (e.Location.Y - secondpoint.Y) / (startpoint.Y - secondpoint.Y))
                        if (mouseDown == true)
                        {

                            Point delta;

                            if (i != 0)
                            {
                                delta = new Point(e.Location.X - mouseTracker.X, e.Location.Y - mouseTracker.Y);
                                mouseTracker = e.Location;

                                pointList[0] = new Point(pointList[0].X - delta.X, pointList[0].Y - delta.Y);
                                pointList[1] = new Point(pointList[1].X - delta.X, pointList[1].Y - delta.Y);


                                graphics.DrawLine(pen, pointList[0], pointList[1]);

                                pictureBox1.Image = tmpBitmap;

                            }
                            i++;
                        }
                        else
                        {
                            this.UseWaitCursor = false;
                        }

                        break;
                    }
                    GC.Collect();

            }
        }

        private void MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            mouseUp = false;
            switch (Mode)
            {
                case "Draw":
                    startpoint = e.Location;
                    pointList.Add(startpoint);
                    break;

                case "Stop":
                    mouseTracker = e.Location;
                    break;
            }
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            mouseUp = true;
            mouseDown = false;
            switch (Mode)
            {
                case "Draw":
                        pointList.Add(e.Location);
            mainBitmap =  tmpBitmap;
                    break;
                case "Stop":
                    break;

            }
        }

        private void Draw_Click(object sender, EventArgs e)
        {
            Mode = "Draw";
        }

        private void Stop_Click(object sender, EventArgs e)
        {
            Mode = "Stop";
        }
        




        //public Bitmap DrawIt(Point, Pen pen)
        //{
        //    _graphics = Graphics.FromImage(Bitmap);
        //    figure.Painter.DrawFigure(pen, _graphics, figure.GetPoints());
        //    return;

        //}

       

    }
}
