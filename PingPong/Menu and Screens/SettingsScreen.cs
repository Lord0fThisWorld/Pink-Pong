using System;
using System.Threading;

namespace PingPong
{
    class SettingsScreen : ScreenBase
    {
        // screen navigation variable
        protected int index = 1;
        // settings properties variables
        protected int resolution = 1;
        protected int gameSpeed = 1;
        public int Screen(int width, int height,int temp)
        {
            resolution = temp / 100;
            gameSpeed = (temp - (temp / 100) * 100) / 10;
            // necessary for relative content positioning
            int xStart = ((width + 2) - 57) / 2;
            int yStart = ((height + 2) - 18) / 2;
            // necessary for calculating time span for other methods
            startupDate = DateTime.Now;
            // outer frame takes whole space avaliable
            OuterFrameDraw(width, height, '▓');
            // inner frame is fixed size and it is positioned relatively to outer frame
            InnerFrameDraw(xStart, yStart, '▒');
            // drawing settings page grapghical theme
            BookDraw(xStart + 10,yStart + 1);
            consoleKey = ConsoleKey.A;
            while (consoleKey != ConsoleKey.Enter || index < 3)
            {
                mainClock = DateTime.Now - startupDate;
                // highlighting logic, depending on variables values prints content highlighted when selected or normal when not selected
                #region RESOLUTION
                if (index == 1)
                {
                    Console.SetCursorPosition(xStart + 15,yStart  + 4);
                    Console.Write("          ");
                    Console.BackgroundColor = ConsoleColor.Gray;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.SetCursorPosition(xStart + 15,yStart + 4);
                    Console.Write("RESOLUTION");
                    Console.ResetColor();
                }
                else
                {
                    Console.SetCursorPosition(xStart + 15,yStart + 4);
                    Console.Write("          ");
                    Console.SetCursorPosition(xStart + 15,yStart + 4);
                    Console.Write("RESOLUTION");
                }
                if (resolution == 1)
                {
                    Console.SetCursorPosition(xStart + 34,yStart + 4);
                    Console.Write("      ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.SetCursorPosition(xStart + 34,yStart + 4);
                    Console.Write("NORMAL");
                    Console.ResetColor();
                }
                else
                {
                    Console.SetCursorPosition(xStart + 34,yStart + 4);
                    Console.Write("      ");
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.SetCursorPosition(xStart + 34,yStart + 4);
                    Console.Write("normal");
                    Console.ResetColor();
                }
                if (resolution == 2)
                {
                    Console.SetCursorPosition(xStart + 34,yStart + 5);
                    Console.Write("    ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.SetCursorPosition(xStart + 34,yStart + 5);
                    Console.Write("WIDE");
                    Console.ResetColor();
                }
                else
                {
                    Console.SetCursorPosition(xStart + 34,yStart + 5);
                    Console.Write("    ");
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.SetCursorPosition(xStart + 34,yStart + 5);
                    Console.Write("wide");
                    Console.ResetColor();
                }
                if (resolution == 3)
                {
                    Console.SetCursorPosition(xStart + 34,yStart + 6);
                    Console.Write("    ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.SetCursorPosition(xStart + 34,yStart + 6);
                    Console.Write("HIGH");
                    Console.ResetColor();
                }
                else
                {
                    Console.SetCursorPosition(xStart + 34,yStart + 6);
                    Console.Write("    ");
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.SetCursorPosition(xStart + 34,yStart + 6);
                    Console.Write("high");
                    Console.ResetColor();
                }
                if (resolution == 4)
                {
                    Console.SetCursorPosition(xStart + 34,yStart + 7);
                    Console.Write("   ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.SetCursorPosition(xStart + 34,yStart + 7);
                    Console.Write("BIG");
                    Console.ResetColor();
                }
                else
                {
                    Console.SetCursorPosition(xStart + 34,yStart + 7);
                    Console.Write("   ");
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.SetCursorPosition(xStart + 34,yStart + 7);
                    Console.Write("big");
                    Console.ResetColor();
                }
                #endregion
                #region GAME SPEED
                if (index == 2)
                {
                    Console.SetCursorPosition(xStart + 15,yStart + 9);
                    Console.Write("          ");
                    Console.BackgroundColor = ConsoleColor.Gray;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.SetCursorPosition(xStart + 15,yStart + 9);
                    Console.Write("GAME SPEED");
                    Console.ResetColor();
                }
                else
                {
                    Console.SetCursorPosition(xStart + 15,yStart + 9);
                    Console.Write("          ");
                    Console.SetCursorPosition(xStart + 15,yStart + 9);
                    Console.Write("GAME SPEED");
                }
                if (gameSpeed == 1)
                {
                    Console.SetCursorPosition(xStart + 34,yStart + 9);
                    Console.Write("      ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.SetCursorPosition(xStart + 34,yStart + 9);
                    Console.Write("NORMAL");
                    Console.ResetColor();
                }
                else
                {
                    Console.SetCursorPosition(xStart + 34,yStart + 9);
                    Console.Write("      ");
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.SetCursorPosition(xStart + 34,yStart + 9);
                    Console.Write("normal");
                    Console.ResetColor();
                }
                if (gameSpeed == 2)
                {
                    Console.SetCursorPosition(xStart + 34,yStart + 10);
                    Console.Write("    ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.SetCursorPosition(xStart + 34,yStart + 10);
                    Console.Write("FAST");
                    Console.ResetColor();
                }
                else
                {
                    Console.SetCursorPosition(xStart + 34,yStart + 10);
                    Console.Write("    ");
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.SetCursorPosition(xStart + 34,yStart + 10);
                    Console.Write("fast");
                    Console.ResetColor();
                }
                #endregion
                #region EXIT
                if (index == 3)
                {
                    Console.SetCursorPosition(xStart + 15,yStart + 12);
                    Console.Write("           ");
                    Console.BackgroundColor = ConsoleColor.Gray;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.SetCursorPosition(xStart + 15,yStart + 12);
                    Console.Write("SAVE & EXIT");
                    Console.ResetColor();
                }
                else
                {
                    Console.SetCursorPosition(xStart + 15,yStart + 12);
                    Console.Write("           ");
                    Console.SetCursorPosition(xStart + 15,yStart + 12);
                    Console.Write("SAVE & EXIT");
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
            return ((resolution * 10) + gameSpeed)*10;
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
