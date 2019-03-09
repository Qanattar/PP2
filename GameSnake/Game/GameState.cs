using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class GameState
    {

        Snake snake = new Snake('O');
        Food food = new Food('*');
        Wall wall =  new Wall('W');
      
        
        public GameState()
        {
            Console.CursorVisible = false;
            Console.SetWindowSize(40, 50);
            Console.SetBufferSize(40, 50);
            Console.SetCursorPosition(0, 41);
            string playerName;
            using (StreamReader sr = new StreamReader(@"C:\kokosnew\GameSnake\Name.txt"))
            {
                playerName =sr.ReadLine();
            }
            Console.Write("Your Name: ");
            Console.WriteLine(playerName);
            Console.WriteLine("Your Score: ");

            
        }

        public void Button(ConsoleKeyInfo consoleKeyInfo)
        {
            switch (consoleKeyInfo.Key)
            {
                case ConsoleKey.UpArrow:
                    snake.Move(0, -1);
                    break;
                case ConsoleKey.DownArrow:
                    snake.Move(0, 1);
                    break;
                case ConsoleKey.LeftArrow:
                    snake.Move(-1, 0);
                    break;
                case ConsoleKey.RightArrow:
                    snake.Move(1, 0);
                    break;
            }
            CheckCollision();
        }

        void CheckCollision()
        {
            if (snake.CheckIntersection(food.body) == true)
            {
                snake.Eat(food.body);
                food.Generate();

            }
            if (snake.CheckIntersection(wall.body) == true)
            {
                snake.GameOver();
                wall.body.Clear();
                food.body.Clear();
                snake.body.Clear();
            }
            if (food.WrongPlace(wall.body)==true )
            {
                food.body.Clear();
                food.Generate();
            }
            if (food.WrongPlace(snake.body) == true)
            {
                food.body.Clear();
                food.Generate();
            }

        }

        public void Draw()
        {
            snake.Draw();
            food.Draw();
            wall.Draw();
        }
    }
}
