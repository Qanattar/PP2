using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Snake
{
    class Program
    {

        static void Main(string[] args)
        {
            Console.SetCursorPosition(11, 15);
            Console.WriteLine("Your name: ");
            Console.SetCursorPosition(22, 15);
            Console.ReadLine();
            Console.Clear();
            GameState game = new GameState();
            game.Run2();

            while (true)
            {
                ConsoleKeyInfo consoleKeyInfo = Console.ReadKey();
                game.PressedKey(consoleKeyInfo);
            }
        }

    }
}