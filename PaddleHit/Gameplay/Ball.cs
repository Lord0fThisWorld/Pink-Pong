using System;

namespace Game
{
    class Ball
    {
        #region variables
        // ball coordinates
        public int X { get; set; }
        public int Y { get; set; }
        // used to determine movement in each direction
        int changeX;
        int changeY;
        // informs ball about board dimensions (important for ball physics)
        int boardHeight;
        int boardWidth;
        // determines Y movement (important for central hits)
        public int Direction { get; set; }
        #endregion
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
            Console.Write("\0"); //erass ball to avoid "snake" tail

            if (Y <= 1 || Y >= boardHeight)
            {
                changeY *= -1;
            }
            // "hit event" if ball it's hitting the paddle, so it is on X corresponding to paddle and its Y value is in range of paddle size
            if ((X == 3 || X == boardWidth - 2) && (paddle1.Y - (paddle1.Lenght / 2)) <= Y && (paddle1.Y + (paddle1.Lenght / 2)) >= Y)
            {
                hit = true;
                changeX *= -1;
                if (Y == paddle1.Y)
                {
                    Direction = 0; //direct hit stops Y movement
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
            //ball movement
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
        /// <summary>
        /// Prints ball
        /// </summary>
        public void Write()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.SetCursorPosition(X, Y);
            Console.Write("●");
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
