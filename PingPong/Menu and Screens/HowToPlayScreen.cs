using System;
using System.Collections.Generic;
using System.Text;

namespace PingPong
{
    class HowToPlayScreen : ScreenBase
    {
        public int Screen(int width, int height,int temp)
        {
            // necessary for relative content positioning
            int xStart = ((width + 2) - 57) / 2;
            int yStart = ((height + 2) - 18) / 2;
            // necessary for calculating time span for time dependant events
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
                // content display
                #region help statements
                Console.SetCursorPosition(xStart + 5,yStart + 2);
                Console.Write("1) Use W/S or up/down arrow keys to move the");
                Console.SetCursorPosition(xStart + 5,yStart + 3);
                Console.Write("   paddles, be aware that game supports only");
                Console.SetCursorPosition(xStart + 5, yStart + 4);
                Console.Write("   clicking, you CAN NOT hold the key");
                Console.SetCursorPosition(xStart + 5, yStart + 6);
                Console.Write("2) Try to hit the ball with the paddle or You");
                Console.SetCursorPosition(xStart + 5, yStart + 7);
                Console.Write("   will lose the game if You miss");
                Console.SetCursorPosition(xStart + 5, yStart + 9);
                Console.Write("3) Central hit grants You straight shoot, that");
                Console.SetCursorPosition(xStart + 5, yStart + 10);
                Console.Write("   means the ball will move perpendicular to");
                Console.SetCursorPosition(xStart + 5, yStart + 11);
                Console.Write("   the paddles");
                Console.SetCursorPosition(xStart + 5, yStart + 13);
                Console.Write("4) Use setting to adjust gameplay to your needs");
                #endregion
                // blinking text prompt
                #region Press ENTER
                if (((int)mainClock.TotalSeconds) % 2 == 0)
                {
                    Console.SetCursorPosition(xStart + 16,yStart + 15);
                    Console.Write("Press ENTER to proceed... ");
                }
                else
                {
                    Console.SetCursorPosition(xStart + 16,yStart + 15);
                    Console.Write("                          ");
                }
                #endregion
                #region side lines
                // left from top to bottom
                for (int i = yStart + 2; i < yStart + 15; i++)
                {
                    Console.SetCursorPosition(xStart + 3, i);
                    Console.Write("│");
                }
                // right from top to bottom
                for (int i = yStart + 2; i < yStart + 15; i++)
                {
                    Console.SetCursorPosition(xStart + 53, i);
                    Console.Write("│");
                }
                #endregion
                Input();
            }
            Console.Clear();
            return ((temp / 10) * 10);
        }
    }
}
