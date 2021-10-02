using System;

namespace Game
{
    /// <summary>
    /// Class holding info about the paddles used to play pingpong
    /// </summary>
    class Paddle
    {
        // paddle coordinates
        public int X { get; set; }
        public int Y { get; set; }
        // paddle Lenght
        public int Lenght { get; set; }
        // variable holding info about boardHeight (it depends on what is passed by constructor)
        int boardHeight,boardWidth;
        /// <summary>
        /// constructor (sets initial paddle position)
        /// </summary>
        /// <param name="x">X distance from the edge</param>
        /// <param name="boardHeight"></param>
        public Paddle(int x, int boardHeight, int boardWidth,int paddleLength)
        {
            this.boardHeight = boardHeight;
            this.boardWidth = boardWidth;
            X = x;
            Y = boardHeight / 2;
            Lenght = paddleLength;
        }
        /// <summary>
        /// method responsible for moving tha paddle up and stopping it when it reaches the limit
        /// </summary>
        public void Up()
        {
            if ((Y - 1 - (Lenght / 2)) != 0)
            {
                #region tail_cancell
                Console.SetCursorPosition(X, (Y + (Lenght / 2)));
                Console.Write(" ");
                //central rear part of the paddle
                if (X > boardWidth / 2)
                { //Right paddle
                    Console.SetCursorPosition(X + 1, Y);
                    Console.Write(" ");
                }
                else
                { //Left paddle
                    Console.SetCursorPosition(X - 1, Y);
                    Console.Write(" ");
                }
                #endregion
                Y--;
                Write();
            }
        }
        /// <summary>
        /// method responsible for moving tha paddle down and stopping it when it reaches the limit
        /// </summary>
        public void Down()
        {
            if ((Y + 1 + (Lenght / 2)) != boardHeight + 1)
            {
                #region tail_cancell
                Console.SetCursorPosition(X, (Y - (Lenght / 2)));
                Console.Write(" ");
                //main rear part of the paddle
                if (X > boardWidth / 2)
                { //Right paddle
                    Console.SetCursorPosition(X + 1, Y);
                    Console.Write(" ");
                }
                else
                { //Left paddle
                    Console.SetCursorPosition(X - 1, Y);
                    Console.Write(" ");
                }
                #endregion
                Y++;
                Write();
            }
        }
        /// <summary>
        /// method responsible for printing that specific paddle
        /// </summary>
        public void Write()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            for (int i = (Y - (Lenght / 2)); i <= (Y + (Lenght / 2)); i++)
            {
                Console.SetCursorPosition(X, i);
                Console.Write("█");
            }
            if (X > boardWidth/2)
            { //Right paddle
                Console.SetCursorPosition(X + 1, Y);
                Console.Write("-");
            }
            else
            { //Left paddle
                Console.SetCursorPosition(X - 1, Y);
                Console.Write("-");
            }
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
