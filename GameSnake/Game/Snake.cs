using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class Snake : GameObject
    {
        int score = 0;
        public Snake(char sign) : base(sign)
        {
            body.Add(new Point { X = 20, Y = 20 });
        }
        public void Move(int dx, int dy)
        {
            Clear();

            for (int i = body.Count - 1; i > 0; --i)
            {
                body[i].X = body[i - 1].X;
                body[i].Y = body[i - 1].Y;
            }

            body[0].X += dx;
            body[0].Y += dy;
        }
        public void Clear()
        {
            foreach (Point p in body)
            {
                Console.SetCursorPosition(p.X, p.Y);
                Console.Write(' ');
            }
        }

        public bool CheckIntersection(List<Point> otherBody)
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



        public void Eat(List<Point> foodBody)
        {
            body.Add(new Point { X = foodBody[0].X, Y = foodBody[0].Y });

            score++;                                                                        
            
            using (StreamWriter sw = new StreamWriter(@"C:\kokosnew\GameSnake\Score.txt"))
            {
                sw.WriteLine(score);
            }
            Console.SetCursorPosition(12, 42);
            Console.Write(score);                                                              
        
        }
        public void GameOver()
        {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(17, 17);
            Console.WriteLine("GAME OVER");
            using (StreamWriter sw = new StreamWriter(@"C:\kokosnew\GameSnake\Score.txt"))
            {
                sw.WriteLine("0");
            }

        }

    }
}
