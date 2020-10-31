using System;
using System.Threading;

namespace PingPong
{
    class MainMenu : ScreenBase
    {
        // necessary for menu navigation
        protected int index = 1;
        public int Screen(int width, int height,int temp)
        {
            // necessary for relative content positioning
            int xStart = ((width + 2) - 57) / 2;
            int yStart = ((height + 2) - 18) / 2;
            // outer frame takes whole space avaliable
            OuterFrameDraw(width, height, '▓');
            // inner frame is fixed size and it is positioned relatively to outer frame
            InnerFrameDraw(xStart, yStart, '▒');
            // time-static text instructions
            Console.SetCursorPosition(xStart + 9,yStart + 2);
            Console.Write("use: WS or up/down arrow keys to browse");
            Console.SetCursorPosition(xStart + 18,yStart + 4);
            Console.Write("press ENTER to select");
            // main loop
            while (consoleKey != ConsoleKey.Enter)
            {
                // selection dependant text display
                #region START GAME
                if (index == 1)
                {
                    Console.SetCursorPosition(xStart + 22,yStart + 8);
                    Console.Write("             ");
                    Console.BackgroundColor = ConsoleColor.Gray;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.SetCursorPosition(xStart + 24,yStart + 8);
                    Console.Write("START GAME");
                    Console.ResetColor();
                }
                else
                {
                    Console.SetCursorPosition(xStart + 22,yStart + 8);
                    Console.Write("             ");
                    Console.SetCursorPosition(xStart + 23,yStart + 8);
                    Console.Write("START GAME");
                }
                #endregion
                #region HOW TO PLAY
                if (index == 2)
                {
                    Console.SetCursorPosition(xStart + 22,yStart + 10);
                    Console.Write("             ");
                    Console.BackgroundColor = ConsoleColor.Gray;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.SetCursorPosition(xStart + 24,yStart + 10);
                    Console.Write("HOW TO PLAY");
                    Console.ResetColor();
                }
                else
                {
                    Console.SetCursorPosition(xStart + 22,yStart + 10);
                    Console.Write("             ");
                    Console.SetCursorPosition(xStart + 23,yStart + 10);
                    Console.Write("HOW TO PLAY");
                }
                #endregion
                #region SETTINGS
                if (index ==3)
                {
                    Console.SetCursorPosition(xStart + 22,yStart + 12);
                    Console.Write("             ");
                    Console.BackgroundColor = ConsoleColor.Gray;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.SetCursorPosition(xStart + 24,yStart + 12);
                    Console.Write("SETTINGS");
                    Console.ResetColor();
                }
                else
                {
                    Console.SetCursorPosition(xStart + 22,yStart + 12);
                    Console.Write("             ");
                    Console.SetCursorPosition(xStart + 23,yStart + 12);
                    Console.Write("SETTINGS");
                }
                #endregion
                #region QUIT
                if (index == 4)
                {
                    Console.SetCursorPosition(xStart + 22,yStart + 14);
                    Console.Write("             ");
                    Console.BackgroundColor = ConsoleColor.Gray;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.SetCursorPosition(xStart + 24,yStart + 14);
                    Console.Write("QUIT");
                    Console.ResetColor();
                }
                else
                {
                    Console.SetCursorPosition(xStart + 22,yStart + 14);
                    Console.Write("             ");
                    Console.SetCursorPosition(xStart + 23,yStart + 14);
                    Console.Write("QUIT");
                }
                #endregion
                // ascii images 
                ScientistLeftDraw(xStart + 2,yStart + 4);
                ScientistRightDraw(xStart + 39,yStart + 4);
                // menu navigation logic
                if (consoleKey == ConsoleKey.UpArrow || consoleKey == ConsoleKey.W)
                {
                    Up();
                }
                else if (consoleKey == ConsoleKey.DownArrow || consoleKey == ConsoleKey.S)
                {
                    Down();
                }
                // resets consoleKey information
                consoleKey = ConsoleKey.A;
                // prevents blinking
                Thread.Sleep(50);
                Input();
            }
            consoleKey = ConsoleKey.A;
            Console.Clear();
            return ((temp/10)*10)+index;
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
