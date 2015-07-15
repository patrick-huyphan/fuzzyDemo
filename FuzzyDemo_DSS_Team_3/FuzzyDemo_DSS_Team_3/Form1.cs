using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using FuzzyFramework.Dimensions;
using FuzzyFramework.Sets;
using FuzzyFramework.Graphics;
using FuzzyFramework;
using FuzzyFramework.Defuzzification;

namespace FuzzyDemo_DSS_Team_3
{
    public partial class Form1 : Form
    {
        #region input set
        ////Definition of dimensions on which we will measure the input values
        //ContinuousDimension height = new ContinuousDimension("Height", "Personal height", "cm", 100, 250);
        //ContinuousDimension weight = new ContinuousDimension("Weight", "Personal weight", "kg", 30, 200);
        protected static IContinuousDimension MACD;
        protected static IContinuousDimension RSI;
        protected static IContinuousDimension SO;
        protected static IContinuousDimension OBV;
        //protected static IDiscreteDimension product;
        //protected static IContinuousDimension price;
        protected static IContinuousDimension action;

        public static ContinuousSet lMACD;
        public static ContinuousSet hMACD;
        public static ContinuousSet lRSI;
        public static ContinuousSet mRSI;
        public static ContinuousSet hRSI;
        public static ContinuousSet lSO;
        public static ContinuousSet mSO;
        public static ContinuousSet hSO;
        public static ContinuousSet lOBV;
        public static ContinuousSet mOBV;
        public static ContinuousSet hOBV;

        //public static ContinuousSet buy;
        //public static ContinuousSet hold;
        //public static ContinuousSet sell;
        //public static DiscreteSet fruits;
        //public static ContinuousSet cheap;
        public static ContinuousSet buyIt;
        public static ContinuousSet SellIt;
        public static ContinuousSet HoldIt;

        #endregion

        #region output set
        ////Definition of dimension for output value
        //ContinuousDimension consequent = new ContinuousDimension("Suitability for basket ball", "0 = not good, 5 = very good", "grade", 0, 5);

        #endregion
        #region merger set
        ////  input sets:
        //FuzzySet tall = new LeftLinearSet(height, "Tall person", 170, 185);
        //FuzzySet weighty = new LeftLinearSet(weight, "Weighty person", 80, 100);
        ////  output set:
        //FuzzySet goodForBasket = new LeftLinearSet(consequent, "Good in basket ball", 0, 5);

        #endregion
        #region Definition of dimensions


        #endregion

        #region Definition of members for discrete fuzzy set
        protected static stockFuzzy apple;
        #endregion

        #region Basic single-dimensional fuzzy sets

        #endregion

        #region Internal properties
        protected string _expression = null;
        protected FuzzyRelation _relation;
        protected DefuzzificationFactory.DefuzzificationMethod _defuzzMethod = DefuzzificationFactory.DefuzzificationMethod.RightOfMaximum;
        protected Defuzzification _defuzzification;
        protected bool _ready = false;
        protected bool _waitingForBuild = false;
        protected bool _building = false;
        #endregion
        private Random R = new Random();
        private List<System.Drawing.Drawing2D.GraphicsPath> Paths = new List<System.Drawing.Drawing2D.GraphicsPath>();
        
        public Form1()
        {
            InitializeComponent();
            //this.Paint += new PaintEventHandler(Form1_Paint);
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


        #region Builiding the overall relation from input values, refresing the form content immediatelly

        protected void buildMACDSet()
        {
            MACD = new ContinuousDimension("MACD index", "MACD index", "unit", 0, 100);

            lMACD = new RightQuadraticSet(MACD, "Low MACD", 10, 15, 20);
            hMACD = new LeftQuadraticSet(MACD, "High MACD", 20, 25, 30);
            
        }

        protected void buildRSISet()
        {
            RSI = new ContinuousDimension("RSI index", "RSI index", "unit", 0, 100);

            lRSI = new RightQuadraticSet(RSI, "Low RSI", 10, 15, 20);
            hRSI = new LeftQuadraticSet(RSI, "High RSI", 20, 25, 30);
            mRSI = new BellSet(RSI, "Correct RSI", 20, 5, 10);
        }

        protected void buildSOSet()
        {
            SO = new ContinuousDimension("SO index", "SO index", "unit", 0, 100);

            lSO = new RightQuadraticSet(SO, "Low SO", 10, 15, 20);
            hSO = new LeftQuadraticSet(SO, "High SO", 20, 25, 30);
            mSO = new BellSet(SO, "Correct SO", 20, 5, 10);
        }

        protected void buildOBVSet()
        {
            OBV = new ContinuousDimension("OBV index", "OBV index", "unit", 0, 100);
            lOBV = new RightQuadraticSet(OBV, "Low OBV", 10, 15, 20);
            hOBV = new LeftQuadraticSet(OBV, "High OBV", 20, 25, 30);
        }

        protected void buildActionSet()
        {
            action = new ContinuousDimension("Action", "Action for stock", "action", 0, 100);
            buyIt = new RightQuadraticSet(action, "buy stock", 0, 50, 50);
            SellIt = new LeftQuadraticSet(action, "sell stock", 0, 50, 50);
            HoldIt = new BellSet(action, "hold stock", 0, 50, 50);

        }

        protected void buildHoldItSet()
        { }

        protected void buildSellItSet()
        { }

        protected void buildBuyItSet()
        {
            action = new ContinuousDimension("Action", "-10 surely don't buy ... +10 surely buy", "", -10, +10);

            //if (trackBarBuyItKernel.Value < -8)
            //    trackBarBuyItKernel.Value = -8;
            //if (trackBarBuyItCrossover.Value < -9)
            //    trackBarBuyItCrossover.Value = -9;

            //if (trackBarBuyItCrossover.Value > trackBarBuyItKernel.Value - 1)
            //    trackBarBuyItCrossover.Value = trackBarBuyItKernel.Value - 1;

            //if (trackBarBuyItSupport.Value > trackBarBuyItCrossover.Value - 1)
            //    trackBarBuyItSupport.Value = trackBarBuyItCrossover.Value - 1;

            //buyIt = new LeftQuadraticSet(action, "Buy it!", trackBarBuyItSupport.Value, trackBarBuyItCrossover.Value, trackBarBuyItKernel.Value);

            //RelationImage imgBuyIt = new RelationImage(buyIt);
            //Bitmap bmpBuyIt = new Bitmap(pictureBoxBuyIt.Width, pictureBoxBuyIt.Height);
            //imgBuyIt.DrawImage(Graphics.FromImage(bmpBuyIt));
            //pictureBoxBuyIt.Image = bmpBuyIt;

        }

        protected void buildRelation()
        {
            //refresh of the treeview and the graphs is time consuming. We will only do it every second. See the timer component.
            _waitingForBuild = true;
        }


        protected void buildRelationNow(bool initial)
        {
            if (!_ready)
                return;

            _waitingForBuild = false;
            _building = true;

            bool _expressionChanged = false;

            //decimal inputProduct = ddlProduct.SelectedIndex + 1;
            //decimal inputPrice = txtPrice.Value;

            #region Realtime expression evaluation by means of C# parser
            //string strExpression = txtExpression.Text;
            //prependFullName(ref strExpression, "cheap");
            //prependFullName(ref strExpression, "fruits");
            //prependFullName(ref strExpression, "buyIt");

            //object obj = Evaluator.Eval(strExpression);
            //
            //if (obj != null)
            //{
            //    if (!(obj is FuzzyRelation))
            //    {
            //        MessageBox.Show(String.Format("ERROR: Object of type FuzzyRelation expected as the result of the expression.\r\nThis object is type {0}.", obj.GetType().FullName),
            //            "Error evaluating expression", MessageBoxButtons.OK,
            //            MessageBoxIcon.Error);
            //    }
            //    else
            //    {
            //        _relation = (FuzzyRelation)obj;
            //        if (_expression != txtExpression.Text)
            //            _expressionChanged = true;
            //        _expression = txtExpression.Text;

            //    }
            //}
            #endregion

            #region Defuzzification
            //DefuzzificationFactory.DefuzzificationMethod method = (DefuzzificationFactory.DefuzzificationMethod)ddlDefuzMethod.SelectedIndex;

            //_defuzzification = DefuzzificationFactory.GetDefuzzification(
            //    _relation,
            //    new Dictionary<IDimension, decimal> {
            //            { product, inputProduct },
            //            { price, inputPrice }
            //    },
            //    method
            //    );

            //_defuzzMethod = method;
            #endregion

            #region Output value
            string unit = ((IContinuousDimension)_defuzzification.OutputDimension).Unit;
            //lblOutput.Text = _defuzzification.CrispValue.ToString("F5") + (string.IsNullOrEmpty(unit) ? "" : " " + unit);
            #endregion

            Cursor.Current = Cursors.WaitCursor;

            #region storing TreeView selection
            //Store information about currenlty selected node. It will become handy
            //when selecting the same node after the refresh (if applicable)
            List<int> selectedNodePath = new List<int>();

            //if (treeViewRelation.SelectedNode != null)
            //{
            //    TreeNode pointer = treeViewRelation.SelectedNode;
            //    while (pointer != null)
            //    {
            //        selectedNodePath.Add(pointer.Index);
            //        pointer = pointer.Parent;
            //    }
            //}
            //else if (initial)
            //{
            //    selectedNodePath.Add(0);
            //}
            #endregion

            TreeSource ts = new TreeSource(_defuzzification);
            ts.DrawImageOnNodeSelect = false;
            //ts.BuildTree(treeViewRelation, pictureBoxGraph, lblGraphCaption);
            //Cursor.Current = Cursors.Default;

            #region restoring TreeView selection
            //if ((!_expressionChanged || initial) && selectedNodePath.Count() > 0 && selectedNodePath[selectedNodePath.Count() - 1] < treeViewRelation.Nodes.Count)
            //{
            //    //We will now try to restore the selection
            //    TreeNode pointer = treeViewRelation.Nodes[selectedNodePath[selectedNodePath.Count() - 1]];

            //    for (int i = selectedNodePath.Count() - 2; i >= 0; i--)
            //    {
            //        if (selectedNodePath[i] >= pointer.Nodes.Count)
            //        {
            //            pointer = null;
            //            break;
            //        }
            //        pointer = pointer.Nodes[selectedNodePath[i]];
            //    }

            //    if (pointer != null)
            //    {
            //        treeViewRelation.SelectedNode = pointer;
            //        ts.DrawDetailImage(pointer);
            //    }
            //}

            Cursor.Current = Cursors.Default;
            ts.DrawImageOnNodeSelect = true;
            #endregion

            _building = false;
        }

        protected Defuzzification deFuzzy(FuzzyRelation relation, decimal inputMACD, decimal inputRSI, decimal inputSO, decimal inputOBV)
        {
            Defuzzification result = new MeanOfMaximum(
                relation,
                new Dictionary<IDimension, decimal>{
                    { MACD, inputMACD },
                    { RSI, inputRSI },
                    { SO, inputSO },
                    { OBV, inputOBV }
                }
            );

            return result;
        }

        #endregion




    }
}
