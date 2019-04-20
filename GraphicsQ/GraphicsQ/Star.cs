using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;

namespace GraphicsQ
{
    class Star
    {
        int x, y;
        public GraphicsPath gp1;
        public GraphicsPath gp2;
        public Star(int x, int y)
        {
            this.x = x;
            this.y = y;
           gp1 = new GraphicsPath();
            gp2 = new GraphicsPath();

        }
        public void DrawT()
        {
            Point[] firstT =
         {
                new Point (x,y),
                new Point (x+20,y+30),
                new Point(x-20,y+30)
            };
            
            gp1.AddPolygon(firstT);
            Point[] secondT =
          {
                new Point (x-20,y+10),
                new Point (x+20,y+10),
                new Point(x,y+40)
            };
            gp2.AddPolygon(secondT);
        }
        


        public void Move()
        {
            x+= 10;
           y =100+ 20 * Convert.ToInt32(Math.Sin(x / 10));
            if (x > 707) x = 0;
            gp1.Reset();
            gp2.Reset();
        }
        
    }
}
