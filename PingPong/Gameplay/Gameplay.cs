using System;
using System.Threading;

namespace PingPong
{
    /// <summary>
    /// General class that creates and manipulates other game objects
    /// </summary>
    class Gameplay : UserInputReader
    {
        ScoreCounter scoreCounter;
        // variables that holds dimensions to the time when board is created (they are passed to boards creator)
        int width, height;
        // board variable
        Board board;
        // paddle variables
        Paddle paddle1, paddle2;
        Ball ball;
        /// <summary>
        /// Constructor (needs to get width and height to configure other properties)
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public Gameplay(int width, int height)
        {
            // writes (dimensions passed to PingPong constructor) to PingPong variables
            this.width = width;
            this.height = height;
            //creates board instance
            board = new Board(height, width);
            //creates new ball instance
            ball = new Ball(width / 2, height / 2, height, width);
        }
        /// <summary>
        /// Mehtod responsible for configuring paddles up on the board
        /// </summary>
        public void Setup()
        {
            paddle1 = new Paddle(2, height, width);
            paddle2 = new Paddle(width - 1, height, width);
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
        public void Run()
        {
            Console.Clear();
            Setup();
            board.Write();
            paddle1.Write();
            paddle2.Write();
            ball.Write();
            //GAME LOOP - runs until ball missed the paddle - end of a round
            while (ball.X != 1 && ball.X != width - 1)
            {
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
                // method responsible for propper ball movement
                if (ball.Physics(paddle1, paddle2))
                {
                    scoreCounter.score++;
                }
                // method responsible for printing the ball graphical interpretations
                ball.Write();
                // prints score counter in the middle of the screen
                scoreCounter.Write(width);
                // determines time intervals in which ball is moving by stopping whole program for a while, also prevents blinking of the whole content
                Thread.Sleep(100);
            }
            Console.Clear();
            GameOverScreen gameOverScreen = new GameOverScreen();
            gameOverScreen.Screen(width, height, scoreCounter.score);
        }
    }
}
