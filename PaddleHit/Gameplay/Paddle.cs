using System;

namespace Game
{
    class Paddle
    {

        public int X { get; set; }
        public int Y { get; set; }

        public int Lenght { get; set; }

        int boardHeight,boardWidth;

        public Paddle(int x, int boardHeight, int boardWidth,int paddleLength)
        {
            this.boardHeight = boardHeight;
            this.boardWidth = boardWidth;
            X = x;
            Y = boardHeight / 2;
            Lenght = paddleLength;
        }

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
