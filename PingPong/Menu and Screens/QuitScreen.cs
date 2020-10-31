using System;
using System.Collections.Generic;
using System.Text;

namespace PingPong
{
    class QuitScreen : ScreenBase
    {
        public void Screen()
        {
            // necessary for calculating time span for other methods
            startupDate = DateTime.Now;
            // main loop
            while (consoleKey != ConsoleKey.Enter)
            {
                // time passed from method invoke
                mainClock = DateTime.Now - startupDate;
                // closes the screen (and whole app) after passing 7 seconds
                if (mainClock.TotalSeconds > 7)
                {
                    consoleKey = ConsoleKey.Enter;
                }
                // its own custom size, to fit the ascii art
                Console.WindowHeight = 49;
                Console.WindowWidth = 120;
                Console.BufferHeight = Console.WindowHeight;
                Console.BufferWidth = Console.WindowWidth;
                // color change for estetic purposes
                Console.ForegroundColor = ConsoleColor.DarkGray;
                // draws actual ascii image
                FaceDraw(0, 0);
                // listens for user input keys
                Input();
                // bootommost author credits
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
