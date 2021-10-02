﻿using System;
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
            board.Write();
            paddle1.Write();
            paddle2.Write();
            ball.Write();
            #endregion
            // Gameplay loop
            while (ball.X != 1 && ball.X != width - 1)
            {
                mainClock = DateTime.Now - startupDate;
                Input();
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
                consoleKey = ConsoleKey.A; //resets the key so it's not pressed permanently
                if (mainClock.TotalMilliseconds > ballSpeed)
                {
                    startupDate = DateTime.Now;
                    if (ball.Physics(paddle1, paddle2, mainClock))
                    {
                        scoreCounter.score++;
                    }
                    ball.Write();
                }
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