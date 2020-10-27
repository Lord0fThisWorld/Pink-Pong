using System;
using System.Threading;

namespace ConsoleApp1
{
    class Program
    {   
        //required for input method
        static ConsoleKeyInfo keyInfo = new ConsoleKeyInfo();
        static ConsoleKey consoleKey = new ConsoleKey();
        //Clock Beginning
        static DateTime mainClock;
        static void Main(string[] args)
        {
            mainClock = DateTime.Now;
            EntryScreen(61, 20);
            Console.ReadKey();
        }
        public static void EntryScreen(int width, int height)
        {
            Setup(width, height);
            FirstScreen(width, height);
        }

        private static void FirstScreen(int width, int height)
        {
            while (consoleKey != ConsoleKey.Enter)
            {
            Input();
            OuterFrameDraw(width, height, '▓');
            InnerFrameDraw(width, height, 3, 2, '▒');
            WordDraw(8, 5, "welcome");
                if ((mainClock.Second - DateTime.Now.Second)%2 == 0)
                {
                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                }
            #region write welcome to pink-pong 2020
            Console.SetCursorPosition(23, 12);
            Console.Write("TO ");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("PINK");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("-PONG 2020");
            #endregion
            Console.SetCursorPosition(20, 16);
            Console.Write("Press ENTER to proceed... ");
            Console.ForegroundColor = ConsoleColor.White;
            Thread.Sleep(1);
            }
            Console.Clear();
            Thread.Sleep(1000);
            consoleKey = ConsoleKey.A;
        }
        #region word drawing from letters
        /// <summary>
        /// Letters avaliable to print: W,L,E,M,O,C
        /// </summary>
        /// <param name="x">top-leftmost x-coordinate</param>
        /// <param name="y">top-leftmost y-coordinate</param>
        /// <param name="word">only lowercase</param>       
        private static void WordDraw(int x, int y, string word)
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
        private static void WordDraw(int x, int y, string word, char font)
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
        private static void OuterFrameDraw(int width, int height, char font)
        {
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
        }
        private static void InnerFrameDraw(int width, int height, int x, int y, char font)
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
        private static void W_Letter_Write(int x, int y, char font)
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
        private static void E_Letter_Write(int x, int y, char font)
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
        private static void L_Letter_Write(int x, int y, char font)
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
        private static void C_Letter_Write(int x, int y, char font)
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
        private static void O_Letter_Write(int x, int y, char font)
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
        private static void M_Letter_Write(int x, int y, char font)
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
        static void Input()
        {
            if (Console.KeyAvailable)
            {
                keyInfo = Console.ReadKey(true);
                consoleKey = keyInfo.Key;
            }
        }
        // JUST FOR DEVELOPMENT SETS: 1)window size 2)buffer size 3)cursor visible = false
        static void Setup(int width,int height)
        {
            Console.SetWindowSize(width + 2, height + 2);
            Console.SetBufferSize(width + 2, height + 2);
            Console.CursorVisible = false;
        }
    }
}
