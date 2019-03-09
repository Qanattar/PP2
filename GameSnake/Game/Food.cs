using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class Food : GameObject
    {
        public Food (char sign) : base(sign)
        {
            Generate();
        }

        public void Generate()
        {
            body.Clear();
            Random random = new Random(DateTime.Now.Second);
            body.Add(new Point
            {
                X = random.Next(0, 39),
                Y = random.Next(0, 39)
            });

        }

        public bool WrongPlace(List<Point> otherBody)
        {
            bool res = false;

            foreach (Point otherPoint in otherBody)
            {
                foreach (Point point in body)
                {
                    if (otherPoint.X == body[0].X &&
                        otherPoint.Y == body[0].Y)
                    {
                        res = true;
                        break;
                    }
                }
                if (res == true)
                    break;
            }

            return res;
        }
    }
}
