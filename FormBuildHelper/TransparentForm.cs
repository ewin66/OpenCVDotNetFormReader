using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FormBuildHelper
{

    public partial class TransparentForm : Form
    {
        int titleHeight = 0;
        Rectangle screenRectangle = new Rectangle(0,0,0,0);
        System.Drawing.Graphics myGraphics;
        List<Rectangle> allGraphics;

        public enum SplitterPanelPlacement : int
        { NoSplitter = 0, PanelTop = 1, PanelBottom = 2, PanelLeft = 3, PanelRight = 4 };
        public TransparentForm()
        {
            InitializeComponent();
            allGraphics = new List<Rectangle>();
        }

        private void TransparentForm_Load(object sender, EventArgs e)
        {

        }
        public void Overlay( Control control, double opacity)
        {

            PictureBox pb = (PictureBox)control;
            Form form = control.FindForm();
         


            pb.SizeMode = PictureBoxSizeMode.Normal;

        
            this.Size = pb.Image.PhysicalDimension.ToSize();
            pb.Size = pb.Image.PhysicalDimension.ToSize();
            this.Top = form.Top;
            this.Left = form.Left;
            //this.Top = pb.Top + GetTitleBarHeight(form) + form.Top;
            //this.Left = form.Left + control.Left;
            this.Opacity = .1;  //opacity;
            this.BringToFront();
            
        }
        public int GetTitleBarHeight(Form form)
        {
            if (screenRectangle.Height == 0 && screenRectangle.Width == 0)
            {
                screenRectangle = RectangleToScreen(form.ClientRectangle);
                titleHeight =  screenRectangle.Top - form.Top;
            }
            return titleHeight;

        }
        public void NewPanel(Control parent, Point location, Size size,  SplitterPanelPlacement splitterEnum)
        {
            if (splitterEnum != SplitterPanelPlacement.NoSplitter)
            {
                SplitContainer splitContainer = new SplitContainer();
                parent.Controls.Add(splitContainer);

                if (splitterEnum == SplitterPanelPlacement.PanelTop)
                {

                    splitContainer.Orientation = Orientation.Vertical;
                    splitContainer.Panel1.Size = size;
                    splitContainer.Location = location;

                }
                if (splitterEnum == SplitterPanelPlacement.PanelBottom)
                {
                    splitContainer.Orientation = Orientation.Vertical;
                    splitContainer.Panel2.Size = size;
                    splitContainer.Location = location;

                }
                if (splitterEnum == SplitterPanelPlacement.PanelLeft)
                {
                    splitContainer.Orientation = Orientation.Horizontal;
                    splitContainer.Panel1.Size = size;
                    splitContainer.Location = location;
                }
                if (splitterEnum == SplitterPanelPlacement.PanelRight)
                {              
                    splitContainer.Orientation = Orientation.Horizontal;
                    splitContainer.Panel2.Size = size;
                    splitContainer.Location = location;

                }
            }
            else
            {
                Panel panel = new Panel();
                parent.Controls.Add(panel);
                panel.Location = location;
                panel.Size = size;                
            }

        }
        public void DrawRect(Rectangle rectangle)
        {
            System.Drawing.SolidBrush myBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Red);
            System.Drawing.Pen myPen = new System.Drawing.Pen(myBrush);
            
            System.Drawing.Graphics pnlGraphics;
            myPen.Width = myPen.Width * 4;

            pnlGraphics = mainPnl.CreateGraphics();

            //pnlGraphics.FillRectangle(myBrush, new Rectangle(x, y, 40, 40));
            pnlGraphics.DrawRectangle(myPen, rectangle);

            myBrush.Dispose();
            pnlGraphics.Dispose();
        }

        public void NewRect(Rectangle rectangle)
        {
            System.Drawing.SolidBrush myBrush = new System.Drawing.SolidBrush(System.Drawing.Color.DarkOrchid);
            System.Drawing.Pen myPen = new System.Drawing.Pen(myBrush);
            myPen.Width = myPen.Width * 12;
            myGraphics = mainPnl.CreateGraphics();
            myGraphics.DrawRectangle(myPen, rectangle);
            allGraphics.Add(rectangle);

            myBrush.Dispose();
            myPen.Dispose();

        }

        private void mainPnl_Paint(object sender, PaintEventArgs e)
        {

        }

        private void mainPnl_DoubleClick(object sender, EventArgs e)
        {
            MouseEventArgs ea = (MouseEventArgs)e;
            if (ea.Button == MouseButtons.Left)
            {
                System.Drawing.SolidBrush myBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Fuchsia);
                System.Drawing.Pen myPen = new System.Drawing.Pen(myBrush);
                myPen.Width = myPen.Width * 12;
                myGraphics = mainPnl.CreateGraphics();
                myGraphics.DrawRectangles(myPen, allGraphics.ToArray());
            }
            else
            {
                this.Hide();
                this.SendToBack();
            }
        }
    }
}
