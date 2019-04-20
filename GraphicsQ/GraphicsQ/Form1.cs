using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GraphicsQ
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public Graphics gr;
        
        Star s1 = new Star(100, 200);
        Star s2 = new Star(400, 200);
        Pen pen = new Pen(Color.Black,3);
        private void Form1_Load(object sender, EventArgs e)
        {
            this.Width = 800;
            this.Height = 600;

        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            this.BackColor = Color.Black;
            SolidBrush blue = new SolidBrush(Color.Blue);
            e.Graphics.FillRectangle(blue, 10, 10, 760, 520);

            SolidBrush white = new SolidBrush(Color.White);
            e.Graphics.FillEllipse(white, 100, 100, 40, 40);

            int y = 200, x = 300;
            Point[] spaceship =
            {
                new Point(x,y),
                new Point(x+40,y+20),
                new Point(x+40,y+50),
                new Point(x,y+70),
                new Point(x-40,y+50),
                new Point(x-40,y+20)
            };
            SolidBrush yellow = new SolidBrush(Color.Yellow);
            e.Graphics.FillPolygon(yellow, spaceship);
            SolidBrush red = new SolidBrush(Color.Red);
            s1.DrawT();
            s2.DrawT();
            e.Graphics.FillPath(red, s1.gp1);
            e.Graphics.FillPath(red, s1.gp2);
            e.Graphics.FillPath(red, s2.gp1);
            e.Graphics.FillPath(red, s2.gp2);

            x = 260; y = 300;
            
            Point[] newstar =
            {
                    new Point(x,y),
                    new Point(x+5,y+25),
                    new Point(x+20,y+30),
                    new Point(x+5,y+35),
                    new Point(x,y+60),

                    new Point(x-5,y+35),
                    new Point(x-20,y+30),
                    new Point(x-5,y+25),
                    
            };
            e.Graphics.FillClosedCurve(yellow, newstar);
            x = 100; y = 100;

            Point[] newstar2 =
            {
                    new Point(x,y),
                    new Point(x+5,y+25),
                    new Point(x+20,y+30),
                    new Point(x+5,y+35),
                    new Point(x,y+60),

                    new Point(x-5,y+35),
                    new Point(x-20,y+30),
                    new Point(x-5,y+25),

            };
            e.Graphics.FillClosedCurve(yellow, newstar); x = 260; y = 300;
            x = 200; y = 150;
            Point[] newstar3 =
            {
                    new Point(x,y),
                    new Point(x+5,y+25),
                    new Point(x+20,y+30),
                    new Point(x+5,y+35),
                    new Point(x,y+60),

                    new Point(x-5,y+35),
                    new Point(x-20,y+30),
                    new Point(x-5,y+25),

            };
            e.Graphics.FillClosedCurve(yellow, newstar);
            e.Graphics.FillClosedCurve(yellow, newstar2);
            e.Graphics.FillClosedCurve(yellow, newstar3);
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            
            SolidBrush white = new SolidBrush(Color.White);
           // gr.FillEllipse(white, x, y, 40, 40);
           // gr.DrawLine(pen, x+20, y+20, 120, 150);
            //x+=10;
            s1.Move();
           s2.Move();
            Refresh();
        }
    }
}
