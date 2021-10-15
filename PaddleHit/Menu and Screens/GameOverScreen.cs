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

            startupDate = DateTime.Now;
            // main loop
            while (consoleKey != ConsoleKey.Enter)
            {
                // time passed from method invoke
                mainClock = DateTime.Now - startupDate;

                OuterFrameDraw(width, height, '▓');
                InnerFrameDraw(xStart, yStart, '▒');

                #region GAME OVER BLINKING TEXT
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

                Console.SetCursorPosition(xStart + 38, yStart + 5);
                Console.Write("Your score: " + score);

                #region Press ENTER BLINKING TEXT
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

                #region Alien BLINKING TEXT
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
                CheckIfKeyIsPressed();
            }
            Console.Clear();
        }
    }
}
