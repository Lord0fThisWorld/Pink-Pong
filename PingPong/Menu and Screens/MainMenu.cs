using System;
using System.Threading;

namespace PingPong
{
    class MainMenu : ScreenBase
    {
        protected int index = 1;
        public int Screen(int width, int height)
        {
            //27+1 is inner frame center size, frame starts at x = 2, inner frame width = 55
            OuterFrameDraw(width, height, '▓');
            InnerFrameDraw(3, 2, '▒');              //coordinates needs modification for resizing
            Console.SetCursorPosition(12, 4);   //coordinates needs modification for resizing
            Console.Write("use: WS or up/down arrow keys to browse");
            Console.SetCursorPosition(21, 6);
            Console.Write("press ENTER to select");
            while (consoleKey != ConsoleKey.Enter)
            {
                #region START GAME
                if (index == 1)
                {
                    Console.SetCursorPosition(25, 10);
                    Console.Write("             ");
                    Console.BackgroundColor = ConsoleColor.Gray;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.SetCursorPosition(27, 10);
                    Console.Write("START GAME");
                    Console.ResetColor();
                }
                else
                {
                    Console.SetCursorPosition(25, 10);
                    Console.Write("             ");
                    Console.SetCursorPosition(26, 10);
                    Console.Write("START GAME");
                }
                #endregion
                #region HOW TO PLAY
                if (index == 2)
                {
                    Console.SetCursorPosition(25, 12);
                    Console.Write("             ");
                    Console.BackgroundColor = ConsoleColor.Gray;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.SetCursorPosition(27, 12);
                    Console.Write("HOW TO PLAY");
                    Console.ResetColor();
                }
                else
                {
                    Console.SetCursorPosition(25, 12);
                    Console.Write("             ");
                    Console.SetCursorPosition(26, 12);
                    Console.Write("HOW TO PLAY");
                }
                #endregion
                #region SETTINGS
                if (index ==3)
                {
                    Console.SetCursorPosition(25, 14);
                    Console.Write("             ");
                    Console.BackgroundColor = ConsoleColor.Gray;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.SetCursorPosition(27, 14);
                    Console.Write("SETTINGS");
                    Console.ResetColor();
                }
                else
                {
                    Console.SetCursorPosition(25, 14);
                    Console.Write("             ");
                    Console.SetCursorPosition(26, 14);
                    Console.Write("SETTINGS");
                }
                #endregion
                #region QUIT
                if (index == 4)
                {
                    Console.SetCursorPosition(25, 16);
                    Console.Write("             ");
                    Console.BackgroundColor = ConsoleColor.Gray;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.SetCursorPosition(27, 16);
                    Console.Write("QUIT");
                    Console.ResetColor();
                }
                else
                {
                    Console.SetCursorPosition(25, 16);
                    Console.Write("             ");
                    Console.SetCursorPosition(26, 16);
                    Console.Write("QUIT");
                }
                #endregion
                ScientistLeftDraw(5,6);
                ScientistRightDraw(42,6);
                if (consoleKey == ConsoleKey.UpArrow || consoleKey == ConsoleKey.W)
                {
                    Up();
                }
                else if (consoleKey == ConsoleKey.DownArrow || consoleKey == ConsoleKey.S)
                {
                    Down();
                }
                consoleKey = ConsoleKey.A;
                Thread.Sleep(50);
                Input();
            }
            consoleKey = ConsoleKey.A;
            Console.Clear();
            return index;
        }
        protected void Up()
        {
            if (index > 1)
            {
                index--;
            }
        }
        protected void Down()
        {
            if (index < 4)
            {
                index++;
            }
        }
    }
}
