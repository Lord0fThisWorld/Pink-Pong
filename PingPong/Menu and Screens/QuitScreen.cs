using System;
using System.Collections.Generic;
using System.Text;

namespace PingPong
{
    class QuitScreen : ScreenBase
    {
        public void Screen()
        {
            startupDate = DateTime.Now;
            while (consoleKey != ConsoleKey.Enter)
            {
                mainClock = DateTime.Now - startupDate;
                if (mainClock.TotalSeconds > 7)
                {
                    consoleKey = ConsoleKey.Enter;
                }
                Console.WindowHeight = 49;
                Console.WindowWidth = 120;
                Console.BufferHeight = Console.WindowHeight;
                Console.BufferWidth = Console.WindowWidth;
                Console.ForegroundColor = ConsoleColor.DarkGray;
                FaceDraw(0, 0);
                Input();
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.SetCursorPosition(0, 48);
                string credits = "Ping Pong Console Game 2020 brought to life by {Tomasz Zdeb} => https://github.com/Lord0fThisWorld";
                int rest = 120 - credits.Length;
                for (int i = 0; i < rest/2; i++)
                {
                    Console.Write("-");
                }
                Console.Write(credits);
                for (int i = 0; i < rest/2; i++)
                {
                    Console.Write("-");
                }
                Console.ResetColor();
            }
            Console.Clear();
        }
    }
}
