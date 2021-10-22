using System;
using System.Threading;

namespace Game
{
    class WelcomeScreen : ScreenBase
    {

        int initialWidth = 61;
        int initialHeight = 20;

        public WelcomeScreen()
        {
            Console.SetWindowSize(63, 22);
            Console.SetBufferSize(63, 22);
            startupDate = DateTime.Now;
        }

        public void Screen()
        {
            OuterFrameDraw(initialWidth, initialHeight, '▓');
            InnerFrameDraw(3, 2, '▒');
            while (consoleKey != ConsoleKey.Enter)
            {

                mainClock = DateTime.Now - startupDate;

                DisplayContent(mainClock);
                
                Thread.Sleep(1); // prevents blinking of items due to high refresh rate

                //DevClock(mainClock);

                CheckIfKeyIsPressed();
            }
            Console.Clear();
            consoleKey = ConsoleKey.A;
        }

        private void DisplayContent(TimeSpan mainClock)
        {
            WordDraw(8, 5, "welcome");
            Console.SetCursorPosition(23, 12);
            Console.Write("To ");

            #region welcome message
            if ((int)mainClock.TotalSeconds > 5 && ((((int)mainClock.TotalSeconds) % 10 == 0) ||
                (((int)mainClock.TotalSeconds - 1) % 10 == 0) ||
                (((int)mainClock.TotalSeconds - 2) % 10 == 0) ||
                (((int)mainClock.TotalSeconds - 3) % 10 == 0)))
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.Write("PaddleHit 2020");
                Console.ResetColor();
            }
            else
            {
                Console.SetCursorPosition(26, 12);
                Console.Write("PaddleHit 2020");
            }
            #endregion

            Console.SetCursorPosition(21, 14);
            Console.Write("A Console Arcade Game");

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
        }

        private void DevClock(TimeSpan mainClock)
        {
            Console.SetCursorPosition(24, 14);
            Console.Write("                   ");
            Console.SetCursorPosition(24, 14);
            Console.Write("Main Clock: " + (int)mainClock.TotalSeconds);
        }
    }
}
