using System;

namespace Game
{
    /// <summary>
    /// Class holding info about the board that game is going on
    /// </summary>
    class Board
    {
        // buffer properties, that hold the value passe from the constructor to later pass them into Write method
        public int Height { get; set; }
        public int Width { get; set; }
        /// <summary>
        /// Default constructor
        /// </summary>
        public Board()
        {
            Height = 20;
            Width = 60;
        }
        /// <summary>
        /// Custom constructor allowing to set the board size by passing dimensions
        /// </summary>
        /// <param name="height">board height</param>
        /// <param name="width">board width</param>
        public Board(int height, int width)
        {
            Height = height;
            Width = width;
        }
        /// <summary>
        /// Method responsible for printing the board graphics
        /// </summary>
        public void Write()
        {
            // prints board edges
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
            #region edges
            // draws board edges
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
