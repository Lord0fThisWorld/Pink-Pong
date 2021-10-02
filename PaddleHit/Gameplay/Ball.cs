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
            //true if hit
            bool hit;

            // sets cursor position to ball coordinates, 1st their passed by constructor
            Console.SetCursorPosition(X, Y);
            // writes null value to where ball is now (to draw it later) (to avoid snake effect)
            Console.Write("\0");
            // if reaches top or base changes Y movement direction
            if (Y <= 1 || Y >= boardHeight)
            {
                changeY *= -1;
            }
            // "hit event" if ball it's hitting the paddle, so it is on X corresponding to paddle and its Y value is in range of paddle size
            if ((X == 3 || X == boardWidth - 2) && (paddle1.Y - (paddle1.Lenght / 2)) <= Y && (paddle1.Y + (paddle1.Lenght / 2)) >= Y)
            {
                hit = true;
                //checking if it's a direct hit, to stop or start Y movement
                changeX *= -1;
                if (Y == paddle1.Y)
                {
                    Direction = 0;
                }
                if ((Y >= (paddle1.Y - (paddle1.Lenght / 2)) && Y < paddle1.Y) || (Y > paddle1.Y && Y <= (paddle1.Y + (paddle1.Lenght / 2))))
                {
                    Direction = 1;
                }
                //performs movement (also turns on and off y movement depending on how paddle was hit - variable Direction)
            }
            else
            {
                hit = false;
            }
            // actual movement is going on here
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
        /// Ball printing
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
