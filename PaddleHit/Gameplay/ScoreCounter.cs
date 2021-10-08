using System;
using System.Collections.Generic;
using System.Text;

namespace Game
{
    class ScoreCounter
    {
        // Counts paddle hits
        public int Score { get; set; }

        public ScoreCounter() => Score = 0;

        public void Write(int width)
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.SetCursorPosition(width/2 -3, 1);
            Console.Write("Score: "+ Score);
        }
    }
}
