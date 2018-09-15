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
    public partial class frmImage : Form
    {
        public class ClickLogger
        {
            public ClickLogger()
            {
                clicks = new List<Point>();
            }
            public List<Point> clicks { get; set; }
            public bool IsRectangle
            {
                get
                {
                    if (clicks.Count == 2)
                         { return true; }
                    else
                        { return false; }
                }                
            }
            public Rectangle GetRectangle()
            {
                //clicks.Sort();
                Rectangle r =   new Rectangle(new Point(clicks[0].X, clicks[0].Y), new Size(Math.Abs((clicks[1].X - clicks[0].X)), Math.Abs(clicks[1].Y - clicks[0].Y)));
                clicks.Clear();
                return r;
            }
            public void AddPoint(Point point)
            {
                clicks.Add(point);
            }
        }
        TransparentForm tForm;
        public ClickLogger log;

        public Rectangle currentRect;
        System.Drawing.Graphics currentGraphic;
        System.Drawing.SolidBrush currentBrush;  // 
        System.Drawing.Pen currentPen; //

        public frmImage()
        {
            InitializeComponent();
            log = new ClickLogger();
            currentRect = new Rectangle(0, 0, 0, 0);
            currentBrush = new System.Drawing.SolidBrush(System.Drawing.Color.DarkOrchid);
            currentPen  = new System.Drawing.Pen(currentBrush);
        }

        public void LoadImageFromFile(string filePath)
        {
            picImage.Image = Image.FromFile(filePath);
        }

        private void frmImage_Load(object sender, EventArgs e)
        {
   
        }
        public void DoOverlay()
        {
            if (tForm == null)
            {
                tForm = new TransparentForm();
            }
            tForm.MdiParent = this.MdiParent;
            if (!tForm.Visible)
            {
                tForm.Overlay(picImage, .25);
                tForm.Show();
                tForm.BringToFront();
            }
            else
            {
             
                tForm.Hide();
                tForm.SendToBack();
            }
        }

        public Rectangle StartNewRect()
        {
            currentRect = new Rectangle();
            this.Cursor = System.Windows.Forms.Cursors.Cross;
            return currentRect;

        }

        private void picImage_Click(object sender, EventArgs e)
        {
            MouseEventArgs me = e as MouseEventArgs;
            MouseButtons buttonPushed = me.Button;
            int xPos = me.X;
            int yPos = me.Y;

            currentRect.X = xPos;
            currentRect.Y = yPos;
            currentRect.Height = 200;
            currentRect.Width = 200;

            NewRect(currentRect);

            //log.AddPoint(new Point(xPos, yPos));
            //string TitleBar;
            //TitleBar = "log.clicks.Count = " + log.clicks.Count.ToString() + "  IsRect = " + log.IsRectangle.ToString() ;
            //this.Text = TitleBar;
            //if (log.IsRectangle)
            //{         
            //    DoOverlay();
            //    tForm.NewRect(log.GetRectangle());
            //}

            
        }

        public void NewRect(Rectangle thisRect)
        {

            currentGraphic = picImage.CreateGraphics();
            currentGraphic.DrawRectangle(currentPen, currentRect);          

        }
        public void RedrawRect()
        {
            currentGraphic.Dispose();
            currentGraphic = picImage.CreateGraphics();
            currentGraphic.DrawRectangle(currentPen, currentRect);
        }
        public void RectUp(int distance, bool isUpperLeft)
        {
            if (isUpperLeft)
            {
                currentRect.X = currentRect.X - distance;
            }
            else
            {
                currentRect.Height = currentRect.Height - distance;
            }
            RedrawRect();
        }
        public void RectDown(int distance, bool isUpperLeft)
        {
            if (isUpperLeft)
            {
                currentRect.X = currentRect.X + distance;
            }
            else
            {
                currentRect.Height = currentRect.Height + distance;
            }
            RedrawRect();
        }
        public void RectLeft(int distance, bool isUpperLeft)
        {
            if (isUpperLeft)
            {
                currentRect.Y = currentRect.Y - distance;
            }
            else
            {
                currentRect.Width = currentRect.Width - distance;
            }
            RedrawRect();

        }
        public void RectRight(int distance, bool isUpperLeft)
        {
            if (isUpperLeft)
            {
                currentRect.Y = currentRect.Y + distance;
            }
            else
            {
                currentRect.Width = currentRect.Width + distance;
            }
            RedrawRect();

        }


    }
}
