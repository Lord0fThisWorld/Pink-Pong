using System;
using System.Threading;

namespace PingPong
{
    class Program
    {
        enum dimensions
        {
            regularWidth = 61,
            extendedWidth = 121,
            regularHeight = 20,
            extendedHeight = 40
        }
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
            // switches to the right method depending on index value which is set by different methods
            int index = 0;
            while(index != 5)
            {
                if (index == 0)
                {
                    MainMenu mainMenu = new MainMenu();
                    index = mainMenu.Screen((int)dimensions.regularWidth,(int)dimensions.regularHeight);
                }
                else if (index == 1)
                {
                    Gameplay gameplay = new Gameplay(61, 20);
                    gameplay.Run();
                    index = 0;
                }
                else if (index == 2)
                {
                    HowToPlayScreen howToPlayScreen = new HowToPlayScreen();
                    howToPlayScreen.Screen(61,20);
                    index = 0;
                }
                else if (index == 3)
                {
                    SettingsScreen settingsScreen = new SettingsScreen();
                    settingsScreen.Screen(61,20);
                    index = 0;
                }
                else if (index == 4)
                {
                    QuitScreen quitScreen = new QuitScreen();
                    quitScreen.Screen();
                    index = 5;
                }
            }
            Console.Clear();

        }
    }
}
