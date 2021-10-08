using System;

namespace Game
{
    class Ball
    {

        public int X { get; set; }
        public int Y { get; set; }

        int changeX;
        int changeY;

        int boardHeight;
        int boardWidth;

        public int Direction { get; set; }

        public Ball(int x, int y, int boardHeight, int boardWidth)
        {
            X = x;
            Y = y;
            this.boardHeight = boardHeight;
            this.boardWidth = boardWidth;
            changeX = -1;
            changeY = 1;
        }
        /// <summary>
        /// Determines whether the ball was hit by the paddle
        /// </summary>
        /// <param name="paddle1"></param>
        /// <param name="paddle2"></param>
        public bool Physics(Paddle paddle1, Paddle paddle2, TimeSpan mainClock)
        {
            bool hit;

            Console.SetCursorPosition(X, Y);
            Console.Write(" "); //erass ball to avoid "snake" tail

            if (Y <= 1 || Y >= boardHeight)
            {
                changeY *= -1;
            }
            //
            if ((X == 3 || X == boardWidth - 2) && (paddle1.Y - (paddle1.Lenght / 2)) <= Y && (paddle1.Y + (paddle1.Lenght / 2)) >= Y)
            {
                hit = true;
                changeX *= -1;
                if (Y == paddle1.Y)
                {
                    //direct hit stops Y movement
                    Direction = 0;
                }
                else
                {
                    Direction = 1;
                }
            }
            else
            {
                hit = false;
            }
            //moves the ball
            switch (Direction)
            {
                case 0:
                    X += changeX;
                    break;
                case 1:
                    X += changeX;
                    Y += changeY;
                    break;
            }
            return hit;
        }

        public void Write()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.SetCursorPosition(X, Y);
            Console.Write("●");
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
