using System;
using System.Threading;

namespace Game
{
    /// <summary>
    /// General class that creates and manipulates other game objects
    /// </summary>
    class GameplayScreen : ScreenBase
    {
        #region variables
        ScoreCounter scoreCounter;
        int width, height;
        Board board;
        Paddle paddle1, paddle2;
        Ball ball;
        int ballSpeed;
        #endregion

        public GameplayScreen(int width, int height)
        {
            this.width = width;
            this.height = height;
            board = new Board(height, width);
            ball = new Ball(width / 2, height / 2, height, width);
            startupDate = DateTime.Now;
        }

        public void Setup()
        {
            paddle1 = new Paddle(2, height, width, 6);
            paddle2 = new Paddle(width - 1, height, width, 6);
            keyInfo = new ConsoleKeyInfo();
            consoleKey = new ConsoleKey();
            ball.X = width / 2;
            ball.Y = height / 2;
            ball.Direction = 0;
            scoreCounter = new ScoreCounter();
        }
        /// <summary>
        /// Main loop responsible for the whole setup and gameplay
        /// </summary>
        public int Run(int temp)
        {
            #region initialization
            if ((temp % 100) < 20)
            {
                ballSpeed = 100;
            }
            else
            {
                ballSpeed = 50;
            }
            Console.Clear();
            Setup();
            board.PrintTheBoardToConsole();
            paddle1.PrintThePaddleToConsole();
            paddle2.PrintThePaddleToConsole();
            ball.Write();
            #endregion
            // Gameplay loop
            while (ball.X != 1 && ball.X != width - 1)
            {
                mainClock = DateTime.Now - startupDate;
                CheckIfKeyIsPressed();
                switch (consoleKey)
                {
                    case ConsoleKey.W:
                        paddle1.MoveUp();
                        paddle2.MoveUp();
                        break;
                    case ConsoleKey.UpArrow:
                        paddle1.MoveUp();
                        paddle2.MoveUp();
                        break;
                    case ConsoleKey.S:
                        paddle1.MoveDown();
                        paddle2.MoveDown();
                        break;
                    case ConsoleKey.DownArrow:
                        paddle1.MoveDown();
                        paddle2.MoveDown();
                        break;
                }
                consoleKey = ConsoleKey.A; //resets the key so it's not pressed permanently
                if (mainClock.TotalMilliseconds > ballSpeed)
                {
                    startupDate = DateTime.Now;
                    if (ball.Physics(paddle1))
                    {
                        scoreCounter.Score++;
                    }
                    ball.Write();
                }
                scoreCounter.Write(width);
                #region diagnosticClock
                //Console.SetCursorPosition(width / 2 - 3, 3);
                //Console.Write("clock: " + (mainClock.Milliseconds == 999));
                #endregion
            }
            Console.Clear();
            GameOverScreen gameOverScreen = new GameOverScreen();
            gameOverScreen.Screen(width, height, scoreCounter.Score);
            return ((temp / 10) * 10);
        }
    }
}
