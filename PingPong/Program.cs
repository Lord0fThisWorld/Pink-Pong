using System;
using System.Threading;

namespace PingPong
{
    class Program
    {
        // 4 avaliable app resolutions
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
                // main menu 0 0
                if (index == 0)
                {
                    MainMenu mainMenu = new MainMenu();
                    index = mainMenu.Screen((int)dimensions.regularWidth,(int)dimensions.regularHeight);
                }
                // gameplay 0 0
                else if (index == 1)
                {
                    Gameplay gameplay = new Gameplay((int)dimensions.regularWidth, (int)dimensions.regularHeight);
                    gameplay.Run();
                    index = 0;
                }
                // how to play 0 0
                else if (index == 2)
                {
                    HowToPlayScreen howToPlayScreen = new HowToPlayScreen();
                    howToPlayScreen.Screen((int)dimensions.regularWidth, (int)dimensions.regularHeight);
                    index = 0;
                }
                // settings 0 0
                else if (index == 3)
                {
                    SettingsScreen settingsScreen = new SettingsScreen(1,1);
                    settingsScreen.Screen((int)dimensions.regularWidth, (int)dimensions.regularHeight);
                    index = 0;
                }
                // EXIT
                else if (index == 4)
                {
                    // quit screen has its own dimensions, different from every other
                    QuitScreen quitScreen = new QuitScreen();
                    quitScreen.Screen();
                    index = 5;
                }
            }
            Console.Clear();
        }
    }
}
