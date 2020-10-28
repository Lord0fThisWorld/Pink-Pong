using System;

namespace PingPong
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
            #region normal_board
            for (int i = 0; i <= Width; i++)
            {
                Console.SetCursorPosition(i, 0);
                Console.Write("─");
            }
            for (int i = 0; i <= Width; i++)
            {
                Console.SetCursorPosition(i, (Height + 1));
                Console.Write("─");
            }
            for (int i = 0; i <= Height; i++)
            {
                Console.SetCursorPosition(0, i);
                Console.Write("│");
            }
            for (int i = 0; i <= Height; i++)
            {
                Console.SetCursorPosition((Width + 1), i);
                Console.Write("│");
            }

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
