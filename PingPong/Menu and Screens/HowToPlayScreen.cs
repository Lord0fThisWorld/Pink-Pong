using System;
using System.Collections.Generic;
using System.Text;

namespace PingPong
{
    class HowToPlayScreen : ScreenBase
    {
        public void Screen(int width, int height)
        {
            startupDate = DateTime.Now;
            while (consoleKey != ConsoleKey.Enter)
            {
                mainClock = DateTime.Now - startupDate;
                OuterFrameDraw(width, height, '▓');
                InnerFrameDraw(3, 2, '▒');
                #region help statements
                Console.SetCursorPosition(8, 4);
                Console.Write("1) Use W/S or up/down arrow keys to move the");
                Console.SetCursorPosition(8, 5);
                Console.Write("   paddles, be aware that game supports only");
                Console.SetCursorPosition(8, 6);
                Console.Write("   clicking, you CAN NOT hold the key");
                Console.SetCursorPosition(8, 8);
                Console.Write("2) Try to hit the ball with the paddle or You");
                Console.SetCursorPosition(8, 9);
                Console.Write("   will loose the game if You miss");
                Console.SetCursorPosition(8, 11);
                Console.Write("3) Central hit grants You straight shoot, that");
                Console.SetCursorPosition(8, 12);
                Console.Write("   means the ball will move perpendicular to");
                Console.SetCursorPosition(8, 13);
                Console.Write("   the paddles");
                Console.SetCursorPosition(8, 15);
                Console.Write("4) Use setting to adjust gameplay to your needs");
                #endregion
                #region Press ENTER
                if (((int)mainClock.TotalSeconds) % 2 == 0)
                {
                    Console.SetCursorPosition(19, 17);
                    Console.Write("Press ENTER to proceed... ");
                }
                else
                {
                    Console.SetCursorPosition(19, 17);
                    Console.Write("                          ");
                }
                #endregion
                #region side lines
                // left from top to bottom
                for (int i = 4; i < 18; i++)
                {
                    Console.SetCursorPosition(6, i);
                    Console.Write("│");
                }
                // right from top to bottom
                for (int i = 4; i < 18; i++)
                {
                    Console.SetCursorPosition(56, i);
                    Console.Write("│");
                }
                #endregion
                Input();
            }
            Console.Clear();
        }
    }
}
