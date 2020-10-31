using System;
using System.Threading;

namespace PingPong
{
    class SettingsScreen : ScreenBase
    {
        protected int index = 1;
        protected int resolution = 1;
        protected int gameSpeed = 1;
        public void Screen(int width, int height)
        {
            startupDate = DateTime.Now;
            OuterFrameDraw(width, height, '▓');
            InnerFrameDraw(3, 2, '▒');
            // settings page grapghical theme
            BookDraw(13, 3);
            consoleKey = ConsoleKey.A;
            while (consoleKey != ConsoleKey.Enter || index < 3)
            {
                mainClock = DateTime.Now - startupDate;
                // highlighting logic, depending on variables values prints content highlighted when selected or normal when not selected
                #region RESOLUTION
                if (index == 1)
                {
                    Console.SetCursorPosition(18, 6);
                    Console.Write("          ");
                    Console.BackgroundColor = ConsoleColor.Gray;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.SetCursorPosition(18, 6);
                    Console.Write("RESOLUTION");
                    Console.ResetColor();
                }
                else
                {
                    Console.SetCursorPosition(18, 6);
                    Console.Write("          ");
                    Console.SetCursorPosition(18, 6);
                    Console.Write("RESOLUTION");
                }
                if (resolution == 1)
                {
                    Console.SetCursorPosition(37, 6);
                    Console.Write("      ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.SetCursorPosition(37, 6);
                    Console.Write("NORMAL");
                    Console.ResetColor();
                }
                else
                {
                    Console.SetCursorPosition(37, 6);
                    Console.Write("      ");
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.SetCursorPosition(37, 6);
                    Console.Write("normal");
                    Console.ResetColor();
                }
                if (resolution == 2)
                {
                    Console.SetCursorPosition(37, 7);
                    Console.Write("    ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.SetCursorPosition(37, 7);
                    Console.Write("WIDE");
                    Console.ResetColor();
                }
                else
                {
                    Console.SetCursorPosition(37, 7);
                    Console.Write("    ");
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.SetCursorPosition(37, 7);
                    Console.Write("wide");
                    Console.ResetColor();
                }
                if (resolution == 3)
                {
                    Console.SetCursorPosition(37, 8);
                    Console.Write("    ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.SetCursorPosition(37, 8);
                    Console.Write("HIGH");
                    Console.ResetColor();
                }
                else
                {
                    Console.SetCursorPosition(37, 8);
                    Console.Write("    ");
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.SetCursorPosition(37, 8);
                    Console.Write("high");
                    Console.ResetColor();
                }
                if (resolution == 4)
                {
                    Console.SetCursorPosition(37, 9);
                    Console.Write("   ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.SetCursorPosition(37, 9);
                    Console.Write("BIG");
                    Console.ResetColor();
                }
                else
                {
                    Console.SetCursorPosition(37, 9);
                    Console.Write("   ");
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.SetCursorPosition(37, 9);
                    Console.Write("big");
                    Console.ResetColor();
                }
                #endregion
                #region GAME SPEED
                if (index == 2)
                {
                    Console.SetCursorPosition(18, 11);
                    Console.Write("          ");
                    Console.BackgroundColor = ConsoleColor.Gray;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.SetCursorPosition(18, 11);
                    Console.Write("GAME SPEED");
                    Console.ResetColor();
                }
                else
                {
                    Console.SetCursorPosition(18, 11);
                    Console.Write("          ");
                    Console.SetCursorPosition(18, 11);
                    Console.Write("GAME SPEED");
                }
                if (gameSpeed == 1)
                {
                    Console.SetCursorPosition(37, 11);
                    Console.Write("      ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.SetCursorPosition(37, 11);
                    Console.Write("NORMAL");
                    Console.ResetColor();
                }
                else
                {
                    Console.SetCursorPosition(37, 11);
                    Console.Write("      ");
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.SetCursorPosition(37, 11);
                    Console.Write("normal");
                    Console.ResetColor();
                }
                if (gameSpeed == 2)
                {
                    Console.SetCursorPosition(37, 12);
                    Console.Write("    ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.SetCursorPosition(37, 12);
                    Console.Write("FAST");
                    Console.ResetColor();
                }
                else
                {
                    Console.SetCursorPosition(37, 12);
                    Console.Write("    ");
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.SetCursorPosition(37, 12);
                    Console.Write("fast");
                    Console.ResetColor();
                }
                #endregion
                #region EXIT
                if (index == 3)
                {
                    Console.SetCursorPosition(21, 14);
                    Console.Write("    ");
                    Console.BackgroundColor = ConsoleColor.Gray;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.SetCursorPosition(21, 14);
                    Console.Write("EXIT");
                    Console.ResetColor();
                }
                else
                {
                    Console.SetCursorPosition(21, 14);
                    Console.Write("    ");
                    Console.SetCursorPosition(21, 14);
                    Console.Write("EXIT");
                }
                #endregion
                // resolution switching logic
                if (index == 1 && consoleKey == ConsoleKey.Enter)
                {
                    if( resolution < 4)
                    {
                        resolution++;
                    }
                    else
                    {
                        resolution = 1;
                    }
                }
                // gamespeed switching logic
                if (index == 2 && consoleKey == ConsoleKey.Enter)
                {
                    if (gameSpeed < 2)
                    {
                        gameSpeed++;
                    }
                    else
                    {
                        gameSpeed = 1;
                    }
                }
                // menu navigation logic
                if (consoleKey == ConsoleKey.UpArrow || consoleKey == ConsoleKey.W)
                {
                    Up();
                }
                else if (consoleKey == ConsoleKey.DownArrow || consoleKey == ConsoleKey.S)
                {
                    Down();
                }
                // resets console key not to run as if was pressed infiniely
                consoleKey = ConsoleKey.A;
                // prevents blinking
                Thread.Sleep(50);
                // listens for pressed keys
                Input();
            }
            // screen must be cleaned before other screens/gameplay
            Console.Clear();
        }
        // navigation logic
        protected void Up()
        {
            if (index > 1)
            {
                index--;
            }
        }
        protected void Down()
        {
            if (index < 3)
            {
                index++;
            }
        }
    }
}
