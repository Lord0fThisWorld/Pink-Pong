using System;

namespace PingPong
{
    class Program
    {
        static void Main(string[] args)
        {
            #region initial_settings
            // necessary to be able to display graphical symbols in game
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            // sets window size to fit the board
            Console.SetWindowSize(62, 22);
            Console.SetBufferSize(62, 22);
            // just for visual purposes it looks better when console cursor is not visible somewhere during the game
            Console.CursorVisible = false;
            // creates new instance of game objects
            Gameplay gameplay = new Gameplay(60, 20);
            // starts gameplay loop
            #endregion
            gameplay.Run();
        }
    }
}
