using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Paint
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            pen = new Pen(Color.Black, 1);
        }
        Color CurrentColor = Color.Black;
        Pen pen;
        Pen eraser = new Pen(Color.White, 20);
        Bitmap bitmap;
        Graphics gBitmap;
        bool mouseClicked;
        Point prevPoint, curPoint;

        enum Tool
            {
            Pen,
            Rectangle,
            Eraser,
            Line,
            Ellipse,
            Fill
            }
        Tool tool;

        private void Form1_Load(object sender, EventArgs e)
        {
            bitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            gBitmap = Graphics.FromImage(bitmap);
            pictureBox1.Image = bitmap;
            mouseClicked = false;
            tool = Tool.Pen;
        }


        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            mouseClicked = true;
            prevPoint = e.Location;
        
        }
        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            mouseClicked = false;
            if (tool == Tool.Rectangle)
            {
                DrawRectangle(gBitmap);
            }
            if (tool == Tool.Ellipse)
            {
                DrawEllipse(gBitmap);
            }
            if( tool == Tool.Line)
            {
                DrawLine(gBitmap);
            }
            if (tool == Tool.Fill)
            {
                DummyFill dummyFill = new DummyFill();
                dummyFill.Fill(bitmap, e.Location, pen.Color);
            }

        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseClicked == true)
            { 
                if (tool == Tool.Pen)
                {
                    
                    curPoint = e.Location;
                    gBitmap.DrawLine(pen, prevPoint, curPoint);
                    prevPoint = curPoint;
                }
                else
                    if (tool == Tool.Rectangle || tool == Tool.Ellipse || tool == Tool.Line)
                    {
                    curPoint = e.Location;
                    }
                if (tool == Tool.Eraser)
                {
                    curPoint = e.Location;
                    gBitmap.DrawLine(eraser, prevPoint, curPoint);
                    prevPoint = curPoint;
                }
            
                pictureBox1.Refresh();
            }
        }



        private void Pen_Click(object sender, EventArgs e)
        {
            tool = Tool.Pen;
        }

        private void Rectangle_Click(object sender, EventArgs e)
        {
            tool = Tool.Rectangle;
        }

        private void Ellipse_Click(object sender, EventArgs e)
        {
            tool = Tool.Ellipse;
        }

        private void Stirashka_Click(object sender, EventArgs e)
        {
            tool = Tool.Eraser;
        }

        private void Line_Click(object sender, EventArgs e)
        {
            tool = Tool.Line;
        }

        private void buttonFill_Click(object sender, EventArgs e)
        {
            tool = Tool.Fill;
        }
        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            if (tool == Tool.Rectangle) { DrawRectangle(e.Graphics); }
            
            if (tool == Tool.Ellipse)  { DrawEllipse(e.Graphics); }

            if (tool == Tool.Line) { DrawLine(e.Graphics); }
            
        }


        public void DrawRectangle(Graphics g)
        {
            int maxX = Math.Max(prevPoint.X, curPoint.X);
            int maxY = Math.Max(prevPoint.Y, curPoint.Y);
            int minX = Math.Min(prevPoint.X, curPoint.X);
            int minY = Math.Min(prevPoint.Y, curPoint.Y);
     
            g.DrawRectangle(pen, minX, minY, maxX - minX, maxY - minY);
        }

        public void DrawEllipse(Graphics f)
        { 
            f.DrawEllipse(pen, prevPoint.X, prevPoint.Y, curPoint.X - prevPoint.X, curPoint.Y - prevPoint.Y);
        }

        private void DrawLine(Graphics k)
        {
            k.DrawLine(pen, prevPoint.X, prevPoint.Y, curPoint.X, curPoint.Y);
        }

        private void buttonColor_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            pen.Color = b.BackColor;
        }


        private void ChooseColor(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                pen.Color = colorDialog1.Color;
            }
        }

        private void buttoтClear_Click(object sender, EventArgs e)
        {
            gBitmap.Clear(Color.White);
            pictureBox1.Refresh();
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            pen.Width = trackBar1.Value;
        }
    }
}
