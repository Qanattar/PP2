using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class Point
    {
        int x;
        int y;

        int Filter (int k)
        {
            if (k < 0) k = 39;
            else if (k >= 40) k = 0;
            return k;
        }

        public int X
        {
            get { return x; }
            set { x = Filter(value); }
        }
        public int Y
        {
            set { y = Filter(value); }
            get { return y; }
        }


        public Point()
        {
           
        }
    }
}
