using System;
using System.Collections.Generic;
using System.Text;

namespace Game
{
    class GameOverScreen : ScreenBase
    {
        public void Screen(int width, int height, int score)
        {
            // necessary for relative content positioning
            int xStart = ((width + 2) - 57) / 2;
            int yStart = ((height + 2) - 18) / 2;
            // necessary for calculating time span for other methods
            startupDate = DateTime.Now;
            // main loop
            while (consoleKey != ConsoleKey.Enter)
            {
                // time passed from method invoke
                mainClock = DateTime.Now - startupDate;
                // outer frame takes whole space avaliable
                OuterFrameDraw(width, height, '▓');
                // inner frame is fixed size and it is positioned relatively to outer frame
                InnerFrameDraw(xStart, yStart, '▒');
                // time dependant color changing text
                #region GAME OVER
                switch (((int)mainClock.TotalSeconds) % 4)
                {
                    case 0:
                        Console.ForegroundColor = ConsoleColor.Green;
                        break;
                    case 1:
                        Console.ForegroundColor = ConsoleColor.Blue;
                        break;
                    case 2:
                        Console.ForegroundColor = ConsoleColor.Red;
                        break;
                    case 3:
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        break;
                }
                Console.SetCursorPosition(xStart + 40, yStart + 3);
                Console.Write("GAME OVER");
                Console.ForegroundColor = ConsoleColor.Gray;
                #endregion
                // prints user score
                Console.SetCursorPosition(xStart + 38, yStart + 5);
                Console.Write("Your score: " + score);
                // time dependant blinking text prompt
                #region Press ENTER
                if ((((int)mainClock.TotalSeconds) % 2) == 0)
                {
                    Console.SetCursorPosition(xStart + 38,yStart + 7);
                    Console.Write("Press ENTER...");
                }
                else
                {
                    Console.SetCursorPosition(xStart + 38,yStart + 7);
                    Console.Write("              ");
                }
                #endregion
                // time dependant eye blinking alien ascii image
                #region Alien
                if (((((((int)mainClock.TotalSeconds) % 9) == 0) || (((int)mainClock.TotalSeconds) % 9) == 1))
                    && (((int)mainClock.TotalSeconds) > 8))
                {
                    AlienSpaceshipDrawBlink(xStart + 4,yStart + 1);
                }
                else
                {
                    AlienSpaceshipDraw(xStart + 4,yStart + 1);
                }
                #endregion
                Input();
            }
            Console.Clear();
        }
    }
}
