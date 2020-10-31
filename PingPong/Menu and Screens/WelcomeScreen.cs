using System;
using System.Threading;

namespace PingPong
{
    class WelcomeScreen : ScreenBase
    {
        //Startup dimensions
        int initialWidth = 61;
        int initialHeight = 20;
        /// <summary>
        /// Sets propper window size and gets creation DateTime
        /// </summary>
        public WelcomeScreen()
        {
            // when app starts, the initial screen will be the same all the time, later in menu size will be changeable
            Console.SetWindowSize(63, 22);
            Console.SetBufferSize(63, 22);
            startupDate = DateTime.Now;
        }
        /// <summary>
        /// Actual screen (requires settup provided by constructor)
        /// </summary>
        public void Screen()
        {
            OuterFrameDraw(initialWidth, initialHeight, '▓');
            InnerFrameDraw(3, 2, '▒');
            while (consoleKey != ConsoleKey.Enter)
            {
                // difference between startup date (set in constructor) and now, gives timespan of how long the screen is running
                // thanks to that some time dependent events cann occur like, blinking and color change
                mainClock = DateTime.Now - startupDate;
                // procedurally generated word, drawed by squares (single characters)
                WordDraw(8, 5, "welcome");
                //Some time dependent text
                #region welcome to ping-pong 2020
                if ((int)mainClock.TotalSeconds > 5 && ((((int)mainClock.TotalSeconds) % 10 == 0) ||
                    (((int)mainClock.TotalSeconds - 1) % 10 == 0) ||
                    (((int)mainClock.TotalSeconds - 2) % 10 == 0) ||
                    (((int)mainClock.TotalSeconds - 3) % 10 == 0)))
                {
                    Console.SetCursorPosition(23, 12);
                    Console.Write("TO ");
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.Write("PINK");
                    Console.ResetColor();
                    Console.Write("-PONG 2020");
                }
                else
                {
                    Console.SetCursorPosition(23, 12);
                    Console.Write("TO PINK-PONG 2020");
                }
                #endregion
                Console.SetCursorPosition(21, 14);
                Console.Write("A TZ-games production");
                #region press enter to proceed
                // 2 seconds of display 1 seccond of blank space
                if ((((int)mainClock.TotalSeconds) % 3 == 0) || (((int)mainClock.TotalSeconds) % 3 == 1))
                {
                    Console.SetCursorPosition(20, 16);
                    Console.Write("Press ENTER to proceed... ");
                }
                else
                {
                    Console.SetCursorPosition(20, 16);
                    Console.Write("                          ");
                }
                #endregion
                // prevents blinking of items with high refresh rate
                Thread.Sleep(1);
                // helps to check if time dependent events occur right
                //#region clock display (for development)
                //Console.SetCursorPosition(24, 14);
                //Console.Write("                   ");
                //Console.SetCursorPosition(24, 14);
                //Console.Write("Main Clock: " + (int)mainClock.TotalSeconds);
                //#endregion
                // listens for user input
                Input();
            }
            Console.Clear();
            consoleKey = ConsoleKey.A;
        }

    }
}
