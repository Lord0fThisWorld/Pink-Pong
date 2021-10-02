using System;
using System.Threading;

namespace Game
{
    /// <summary>
    /// General class that creates and manipulates other game objects
    /// </summary>
    class Gameplay : ScreenBase
    {
        #region variables
        ScoreCounter scoreCounter;
        // variables that holds dimensions to the time when board is created (they are passed to boards creator)
        int width, height;
        // board variable
        Board board;
        // paddle variables
        Paddle paddle1, paddle2;
        Ball ball;
        int ballSpeed;
        #endregion
        public Gameplay(int width, int height)
        {
            // writes (dimensions passed to PingPong constructor) to PingPong variables
            this.width = width;
            this.height = height;
            //creates board instance
            board = new Board(height, width);
            //creates new ball instance
            ball = new Ball(width / 2, height / 2, height, width);
            // necessary for calculating time span for time dependant events
            startupDate = DateTime.Now;
        }
        /// <summary>
        /// initial gameplay setup
        /// </summary>
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
        /// Main loop responsible for the gameplay sentence (reading input, coputing and printing output in the right sequence)
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
            board.Write();
            paddle1.Write();
            paddle2.Write();
            ball.Write();
            #endregion
            //GAME LOOP - runs until ball missed the paddle - end of a round
            while (ball.X != 1 && ball.X != width - 1)
            {
                // clock, responsible for time dependant events
                mainClock = DateTime.Now - startupDate;
                // reads input key
                Input();
                //depending on key value performs a specific action
                switch (consoleKey)
                {
                    case ConsoleKey.W:
                        paddle1.Up();
                        paddle2.Up();
                        break;
                    case ConsoleKey.UpArrow:
                        paddle1.Up();
                        paddle2.Up();
                        break;
                    case ConsoleKey.S:
                        paddle1.Down();
                        paddle2.Down();
                        break;
                    case ConsoleKey.DownArrow:
                        paddle1.Down();
                        paddle2.Down();
                        break;
                }
                // resets consoleKey variable value so pressing W or S does not make it go up the way up or down but only makes one move
                consoleKey = ConsoleKey.A;
                if (mainClock.TotalMilliseconds > ballSpeed)
                {
                    startupDate = DateTime.Now;
                    // method responsible for propper ball movement
                    if (ball.Physics(paddle1, paddle2, mainClock))
                    {
                        scoreCounter.score++;
                    }
                    // method responsible for printing the ball graphical interpretations
                    ball.Write();
                }
                
                // prints score counter in the middle of the screen
                scoreCounter.Write(width);
                //Console.SetCursorPosition(width / 2 - 3, 3);
                //Console.Write("clock: " + (mainClock.Milliseconds == 999));
            }
            Console.Clear();
            GameOverScreen gameOverScreen = new GameOverScreen();
            gameOverScreen.Screen(width, height, scoreCounter.score);
            return ((temp / 10) * 10);
        }
    }
}
