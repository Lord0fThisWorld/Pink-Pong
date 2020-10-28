using System;
using System.Threading;

namespace PingPong
{
    class WelcomeScreen
    {
        //required for input method
        ConsoleKeyInfo keyInfo = new ConsoleKeyInfo();
        ConsoleKey consoleKey = new ConsoleKey();
        //Clock Beginning
        DateTime startupDate;
        TimeSpan mainClock;
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
            InnerFrameDraw(initialWidth, initialHeight, 3, 2, '▒');
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
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("-PONG 2020");
                }
                else
                {
                    Console.SetCursorPosition(23, 12);
                    Console.Write("TO PINK-PONG 2020");
                }
                #endregion
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
                #region clock display (for development)
                Console.SetCursorPosition(24, 14);
                Console.Write("                   ");
                Console.SetCursorPosition(24, 14);
                Console.Write("Main Clock: " + (int)mainClock.TotalSeconds);
                #endregion
                // listens for user input
                Input();
            }
            Console.Clear();
            consoleKey = ConsoleKey.A;
        }
        // local private methods, used by Screen Method to generate content
        #region word drawing from letters
        /// <summary>
        /// Letters avaliable to print: W,L,E,M,O,C
        /// </summary>
        /// <param name="x">top-leftmost x-coordinate</param>
        /// <param name="y">top-leftmost y-coordinate</param>
        /// <param name="word">only lowercase</param>       
        private void WordDraw(int x, int y, string word)
        {
            // each letter takes 5 characters of space, and after each should me 2 letter of space, so next letter should have x value equal x+7
            char[] wordToPrint = word.ToCharArray();
            for (int i = 0; i < wordToPrint.Length; i++)
            {
                switch (wordToPrint[i])
                {
                    case 'w':
                        W_Letter_Write(x + (i * 7), y, '░');
                        break;
                    case 'e':
                        E_Letter_Write(x + (i * 7), y, '░');
                        break;
                    case 'l':
                        L_Letter_Write(x + (i * 7), y, '░');
                        break;
                    case 'c':
                        C_Letter_Write(x + (i * 7), y, '░');
                        break;
                    case 'o':
                        O_Letter_Write(x + (i * 7), y, '░');
                        break;
                    case 'm':
                        M_Letter_Write(x + (i * 7), y, '░');
                        break;
                }
            }
        }
        private void WordDraw(int x, int y, string word, char font)
        {
            // each letter takes 5 characters of space, and after each should me 2 letter of space, so next letter should have x value equal x+7
            char[] wordToPrint = word.ToCharArray();
            for (int i = 0; i < wordToPrint.Length; i++)
            {
                switch (wordToPrint[i])
                {
                    case 'w':
                        W_Letter_Write(x + (i * 7), y, font);
                        break;
                    case 'e':
                        E_Letter_Write(x + (i * 7), y, font);
                        break;
                    case 'l':
                        L_Letter_Write(x + (i * 7), y, font);
                        break;
                    case 'c':
                        C_Letter_Write(x + (i * 7), y, font);
                        break;
                    case 'o':
                        O_Letter_Write(x + (i * 7), y, font);
                        break;
                    case 'm':
                        M_Letter_Write(x + (i * 7), y, font);
                        break;
                }
            }
        }
        #endregion
        #region frames drawing
        private void OuterFrameDraw(int width, int height, char font)
        {
            #region horizontal lines
            // Up from left to right
            for (int i = 0; i <= width; i++)
            {
                Console.SetCursorPosition(i, 0);
                Console.Write(font);
            }
            // Down from left to right
            for (int i = 1; i <= width; i++)
            {
                Console.SetCursorPosition(i, (height + 1));
                Console.Write(font);
            }
            #endregion
            #region vertical lines
            // Left from top to bottom
            for (int i = 0; i <= height + 1; i++)
            {
                Console.SetCursorPosition(0, i);
                Console.Write(font);
            }
            // Right from top to bottom
            for (int i = 0; i <= height + 1; i++)
            {
                Console.SetCursorPosition((width + 1), i);
                Console.Write(font);
            }
            #endregion
        }
        private void InnerFrameDraw(int width, int height, int x, int y, char font)
        {
            #region horizontal Lines
            // Up from left to right (frame width is 55)(inside 53)
            for (int i = x + 1; i < x + 56; i++)
            {
                Console.SetCursorPosition(i, y);
                Console.Write(font);
            }
            // Down from left to right
            for (int i = x + 1; i < x + 56; i++)
            {
                Console.SetCursorPosition(i, y + 17);
                Console.Write(font);
            }
            #endregion
            #region vertical Lines
            // Left from top to bottom
            for (int i = y; i < y + 18; i++)
            {
                Console.SetCursorPosition(x, i);
                Console.Write(font);
            }
            // Right from top to bottom
            for (int i = y; i < y + 18; i++)
            {
                Console.SetCursorPosition(x + 56, i);
                Console.Write(font);
            }
            #endregion
        }
        #endregion
        #region letters drawing
        // Whole letter takes 5x5 downleft to the initial coordinates
        private void W_Letter_Write(int x, int y, char font)
        {
            #region vertical lines
            // left line from top to bottom
            for (int i = y; i < y + 5; i++)
            {
                Console.SetCursorPosition(x, i);
                Console.Write(font);
            }
            // right line from top to bottom
            for (int i = y; i < y + 5; i++)
            {
                Console.SetCursorPosition(x + 4, i);
                Console.Write(font);
            }
            #endregion
            #region vertical lines
            // downmost line from left to right
            for (int i = x; i < x + 5; i++)
            {
                Console.SetCursorPosition(i, y + 4);
                Console.Write(font);
            }
            #endregion
            // central point
            Console.SetCursorPosition(x + 2, y + 3);
            Console.Write(font);
        }
        private void E_Letter_Write(int x, int y, char font)
        {
            #region vertical lines
            // left line from top to bottom
            for (int i = y; i < y + 5; i++)
            {
                Console.SetCursorPosition(x, i);
                Console.Write(font);
            }
            #endregion
            #region horizontal lines
            // uppermost line from left to right
            for (int i = x + 1; i < x + 5; i++)
            {
                Console.SetCursorPosition(i, y);
                Console.Write(font);
            }
            // middle line from left to right
            for (int i = x + 1; i < x + 3; i++)
            {
                Console.SetCursorPosition(i, y + 2);
                Console.Write(font);
            }
            // downmost line from left to right
            for (int i = x + 1; i < x + 5; i++)
            {
                Console.SetCursorPosition(i, y + 4);
                Console.Write(font);
            }
            #endregion
        }
        private void L_Letter_Write(int x, int y, char font)
        {
            #region vertical lines
            // left line from top to bottom
            for (int i = y; i < y + 5; i++)
            {
                Console.SetCursorPosition(x, i);
                Console.Write(font);
            }
            #endregion
            #region horizontal lines
            // downmost line from left to right
            for (int i = x + 1; i < x + 5; i++)
            {
                Console.SetCursorPosition(i, y + 4);
                Console.Write(font);
            }
            #endregion
        }
        private void C_Letter_Write(int x, int y, char font)
        {
            #region vertical lines
            // left line from top to bottom
            for (int i = y; i < y + 5; i++)
            {
                Console.SetCursorPosition(x, i);
                Console.Write(font);
            }
            #endregion
            #region horizontal lines
            // uppermost line from left to right
            for (int i = x + 1; i < x + 5; i++)
            {
                Console.SetCursorPosition(i, y);
                Console.Write(font);
            }
            // downmost line from left to right
            for (int i = x + 1; i < x + 5; i++)
            {
                Console.SetCursorPosition(i, y + 4);
                Console.Write(font);
            }
            #endregion
        }
        private void O_Letter_Write(int x, int y, char font)
        {
            #region vertical lines
            // left line from top to bottom
            for (int i = y; i < y + 5; i++)
            {
                Console.SetCursorPosition(x, i);
                Console.Write(font);
            }
            // right line from top to bottom
            for (int i = y; i < y + 5; i++)
            {
                Console.SetCursorPosition(x + 4, i);
                Console.Write(font);
            }
            #endregion
            #region horizontal lines
            // uppermost line from left to right
            for (int i = x + 1; i < x + 5; i++)
            {
                Console.SetCursorPosition(i, y);
                Console.Write(font);
            }
            // downmost line from left to right
            for (int i = x + 1; i < x + 5; i++)
            {
                Console.SetCursorPosition(i, y + 4);
                Console.Write(font);
            }
            #endregion
        }
        private void M_Letter_Write(int x, int y, char font)
        {
            #region vertical lines
            // left line from top to bottom
            for (int i = y; i < y + 5; i++)
            {
                Console.SetCursorPosition(x, i);
                Console.Write(font);
            }
            // right line from top to bottom
            for (int i = y; i < y + 5; i++)
            {
                Console.SetCursorPosition(x + 4, i);
                Console.Write(font);
            }
            #endregion
            #region horizontal lines
            // uppermost line from left to right
            for (int i = x; i < x + 5; i++)
            {
                Console.SetCursorPosition(i, y);
                Console.Write(font);
            }
            #endregion
            // central point
            Console.SetCursorPosition(x + 2, y + 1);
            Console.Write(font);
        }
        #endregion
        private void Input()
        {
            if (Console.KeyAvailable)
            {
                keyInfo = Console.ReadKey(true);
                consoleKey = keyInfo.Key;
            }
        }
    }
}
