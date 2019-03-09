using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class Program
    {
      
        static void Main(string[] args)
        {

            Console.SetCursorPosition(40, 16);
            Console.Write("Your Name: ");
            string playerName = Console.ReadLine();
            using (StreamWriter sw = new StreamWriter(@"C:\kokosnew\GameSnake\Name.txt"))
            {
                sw.WriteLine(playerName);
            }
            Console.Clear();
            GameState game = new GameState();
            while (true)
            {
                game.Draw();

                ConsoleKeyInfo consoleKeyInfo = Console.ReadKey();
                game.Button(consoleKeyInfo);
           
            }
        }
    }
}
