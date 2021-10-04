using System;

namespace Game
{
    class Board
    {
        public int Height { get; set; }
        public int Width { get; set; }

        public Board()
        {
            Height = 20;
            Width = 60;
        }

        public Board(int height, int width)
        {
            Height = height;
            Width = width;
        }
        /// <summary>
        /// Method responsible for printing the board
        /// </summary>
        public void Write()
        {
            #region horizontal lines
            // up from left to right
            for (int i = 0; i <= Width; i++)
            {
                Console.SetCursorPosition(i, 0);
                Console.Write("─");
            }
            // down from left to right
            for (int i = 0; i <= Width; i++)
            {
                Console.SetCursorPosition(i, (Height + 1));
                Console.Write("─");
            }
            #endregion
            #region vertical lines
            // left from top to bottom
            for (int i = 0; i <= Height; i++)
            {
                Console.SetCursorPosition(0, i);
                Console.Write("│");
            }
            // right from top to bottom
            for (int i = 0; i <= Height; i++)
            {
                Console.SetCursorPosition((Width + 1), i);
                Console.Write("│");
            }
            #endregion
            #region corners
            Console.SetCursorPosition(0, 0);
            Console.Write("┌");
            Console.SetCursorPosition(Width + 1, 0);
            Console.Write("┐");
            Console.SetCursorPosition(0, Height + 1);
            Console.Write("└");
            Console.SetCursorPosition(Width + 1, Height + 1);
            Console.Write("┘");
            #endregion
        }
    }
}
