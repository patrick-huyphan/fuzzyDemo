using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace FuzzyDemo_DSS_Team_3
{
    public partial class Form1 : Form
    {
        private Random R = new Random();
        private List<System.Drawing.Drawing2D.GraphicsPath> Paths = new List<System.Drawing.Drawing2D.GraphicsPath>();

        fuzzyCore x;
        
        public Form1()
        {
            InitializeComponent();
            //this.Paint += new PaintEventHandler(Form1_Paint);
            x = new fuzzyCore();
            x.setA(100);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            DrawFrame(panel1);
            DrawFrame(panel2);
            DrawFrame(panel3);
            DrawFrame(panel4);
            DrawFrame(panel5);
            //DrawLShapeLine(panel1.CreateGraphics(), 10, 10, 20, 40);
            DrawGraph(panel1.CreateGraphics(), 100, 100, 20, 40);
            
        }

        public void DrawLShapeLine(System.Drawing.Graphics g, int intMarginLeft, int intMarginTop, int intWidth, int intHeight)
        {
            Pen myPen = new Pen(Color.Black);
            myPen.Width = 2;
            // Create array of points that define lines to draw.
            int marginleft = intMarginLeft;
            int marginTop = intMarginTop;
            int width = intWidth;
            int height = intHeight;
            int arrowSize = 3;
            Point[] points =
             {
                new Point(marginleft, marginTop),
                new Point(marginleft, height + marginTop),
                new Point(marginleft + width, marginTop + height),
                // Arrow
                new Point(marginleft + width - arrowSize, marginTop + height - arrowSize),
                new Point(marginleft + width - arrowSize, marginTop + height + arrowSize),
                new Point(marginleft + width, marginTop + height)
             };

            g.DrawLines(myPen, points);
        }
        public void DrawGraph(System.Drawing.Graphics g, int intMarginLeft, int intMarginTop, int intWidth, int intHeight)
        {
            //Pen myPen = new Pen(Color.Black);
            //myPen.Width = 2;
            //// Create array of points that define lines to draw.
            //int marginleft = intMarginLeft;
            //int marginTop = intMarginTop;
            //int width = intWidth;
            //int height = intHeight;
            //int arrowSize = 3;
            //Point[] points =
            // {
            //    new Point(marginleft, marginTop),
            //    new Point(marginleft, height + marginTop),
            //    new Point(marginleft + width, marginTop + height),
            //    // Arrow
            //    new Point(marginleft + width - arrowSize, marginTop + height - arrowSize),
            //    new Point(marginleft + width - arrowSize, marginTop + height + arrowSize),
            //    new Point(marginleft + width, marginTop + height)
            // };

            //g.DrawLines(myPen, points);
        }
        public void DrawFrame(Panel panel)
        {
            System.Drawing.Graphics g = panel.CreateGraphics();
            Pen myPen = new Pen(Color.Cyan);
            myPen.Width = 2;
            //g.DrawRectangle(myPen, new Rectangle(0, 0, 300, 300));
            g.DrawLine(myPen, new Point(10, panel.Height - 10), new Point(panel.Width - 20, panel.Height - 10));
            g.DrawLine(myPen, new Point(10, panel.Height-10), new Point(10, 0));
        }

        //Todo: create draw graph funtion for 4 fuzzy set
        public void DrawLineYfx(System.Drawing.Graphics g, Point start, float k)
        {
            Pen myPen = new Pen(Color.Black);
            myPen.Width = 2;
            myPen.Color = Color.Cyan;
            Rectangle rect = new Rectangle(0, 0, 300, 300);
            g.DrawLine(myPen, start, new Point((int)(start.X +50), (int)(start.X * k)));
        }

        //get input data, convert to fuzzy funtion, 
        //inferen fuzzy, and defuzzy, 
        //show the result, draw graph
        private void button1_Click(object sender, EventArgs e)
        {
            //Point pt1 = new Point(R.Next(this.Width), R.Next(this.Height));
            //Point pt2 = new Point(R.Next(this.Width), R.Next(this.Height));

            Graphics graphics = panel1.CreateGraphics();
            Pen p = new Pen(Color.Red);
            graphics.DrawLine(p, 10, 10, 100, 100);

            DrawFrame(panel1);
            DrawLShapeLine(graphics, 10, 10, 20, 40);
            DrawGraph(graphics, 100, 100, 20, 40);

            //System.Drawing.Drawing2D.GraphicsPath shape = new System.Drawing.Drawing2D.GraphicsPath();
            //shape.AddRectangle(new Rectangle(new Point(Math.Min(pt1.X, pt2.X), Math.Min(pt1.Y, pt2.Y)), new Size(Math.Abs(pt2.X - pt1.X), Math.Abs(pt2.Y - pt1.Y))));
            //Paths.Add(shape);

            panel1.Refresh();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics G = e.Graphics;
            foreach (System.Drawing.Drawing2D.GraphicsPath Path in Paths)
            {
                G.DrawPath(Pens.Black, Path);
            }
        }
    }
}
