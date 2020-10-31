using System;
using System.Collections.Generic;
using System.Text;

namespace PingPong
{
    class GameOverScreen : ScreenBase
    {
        public void Screen(int width, int height, int score)
        {
            startupDate = DateTime.Now;
            while(consoleKey != ConsoleKey.Enter)
            {
                mainClock = DateTime.Now - startupDate;
                OuterFrameDraw(width, height, '▓');
                InnerFrameDraw(3, 2, '▒');
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
                Console.SetCursorPosition(43, 5);
                Console.Write("GAME OVER");
                Console.ForegroundColor = ConsoleColor.Gray;
                #endregion
                Console.SetCursorPosition(41, 7);
                Console.Write("Your score: " + score);
                #region Press ENTER
                if ((((int)mainClock.TotalSeconds) % 2) == 0 )
                {
                    Console.SetCursorPosition(41, 9);
                    Console.Write("Press ENTER...");
                }
                else
                {
                    Console.SetCursorPosition(41, 9);
                    Console.Write("              ");
                }
                #endregion
                #region Alien
                if (( ( ((((int)mainClock.TotalSeconds) % 9) == 0) || (((int)mainClock.TotalSeconds) % 9) == 1) )
                    && ( ((int)mainClock.TotalSeconds)>8) )
                {
                    AlienSpaceshipDrawBlink(7, 3);
                }
                else
                {
                    AlienSpaceshipDraw(7, 3);
                }
                #endregion
                Input();
            }
            Console.Clear();
        }
    }
}
