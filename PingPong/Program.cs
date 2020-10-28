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
            // just for visual purposes it looks better when console cursor is not visible somewhere during the game
            Console.CursorVisible = false;
            #endregion
            // creates new instance of welcome screen
            WelcomeScreen welcomeScreen = new WelcomeScreen();
            // runs welcome screen as a first visible user screen
            welcomeScreen.Screen();
            // creates new instance of game objects
            Gameplay gameplay = new Gameplay(61, 20);
            // starts gameplay loop
            gameplay.Run();
        }
    }
}
