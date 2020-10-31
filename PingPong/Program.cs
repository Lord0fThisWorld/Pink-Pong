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
            int index = 110;
            while ((index % 10) != 5) // RESOLUTION : SPEED : INDEX
            {
                #region main menu
                // main menu 1:1:0
                if (index == 110 || index == 120)
                {
                    Console.SetWindowSize((int)dimensions.regularWidth + 2, (int)dimensions.regularHeight + 2);
                    Console.SetBufferSize((int)dimensions.regularWidth + 2, (int)dimensions.regularHeight + 2);
                    MainMenu mainMenu = new MainMenu();
                    index = mainMenu.Screen((int)dimensions.regularWidth, (int)dimensions.regularHeight, index);
                }
                // main menu 2:1:0
                else if (index == 210 || index == 220)
                {
                    Console.SetWindowSize((int)dimensions.extendedWidth + 2, (int)dimensions.regularHeight + 2);
                    Console.SetBufferSize((int)dimensions.extendedWidth + 2, (int)dimensions.regularHeight + 2);
                    MainMenu mainMenu = new MainMenu();
                    index = mainMenu.Screen((int)dimensions.extendedWidth, (int)dimensions.regularHeight, index);
                }
                // main menu 3:1:0
                else if (index == 310 || index == 320)
                {
                    Console.SetWindowSize((int)dimensions.regularWidth + 2, (int)dimensions.extendedHeight + 2);
                    Console.SetBufferSize((int)dimensions.regularWidth + 2, (int)dimensions.extendedHeight + 2);
                    MainMenu mainMenu = new MainMenu();
                    index = mainMenu.Screen((int)dimensions.regularWidth, (int)dimensions.extendedHeight, index);
                }
                // main menu 4:1:0
                else if (index == 410 || index == 420)
                {
                    Console.SetWindowSize((int)dimensions.extendedWidth + 2, (int)dimensions.extendedHeight + 2);
                    Console.SetBufferSize((int)dimensions.extendedWidth + 2, (int)dimensions.extendedHeight + 2);
                    MainMenu mainMenu = new MainMenu();
                    index = mainMenu.Screen((int)dimensions.extendedWidth, (int)dimensions.extendedHeight, index);
                }
                #endregion
                #region gameplay
                // gameplay 1:1:1
                else if (index == 111 || index == 121)
                {
                    Console.SetWindowSize((int)dimensions.regularWidth + 2, (int)dimensions.regularHeight + 2);
                    Console.SetBufferSize((int)dimensions.regularWidth + 2, (int)dimensions.regularHeight + 2);
                    Gameplay gameplay = new Gameplay((int)dimensions.regularWidth, (int)dimensions.regularHeight);
                    index = gameplay.Run(index);
                }
                // gameplay 2:1:1
                else if (index == 211 || index == 221)
                {

                    Console.SetWindowSize((int)dimensions.extendedWidth + 2, (int)dimensions.regularHeight + 2);
                    Console.SetBufferSize((int)dimensions.extendedWidth + 2, (int)dimensions.regularHeight + 2);
                    Gameplay gameplay = new Gameplay((int)dimensions.extendedWidth, (int)dimensions.regularHeight);
                    index = gameplay.Run(index);

                }
                // gameplay 3:1:1
                else if (index == 311 || index == 321)
                {

                    Console.SetWindowSize((int)dimensions.regularWidth + 2, (int)dimensions.extendedHeight + 2);
                    Console.SetBufferSize((int)dimensions.regularWidth + 2, (int)dimensions.extendedHeight + 2);
                    Gameplay gameplay = new Gameplay((int)dimensions.regularWidth, (int)dimensions.extendedHeight);
                    index = gameplay.Run(index);

                }
                // gameplay 4:1:1
                else if (index == 411 || index == 421)
                {

                    Console.SetWindowSize((int)dimensions.extendedWidth + 2, (int)dimensions.extendedHeight + 2);
                    Console.SetBufferSize((int)dimensions.extendedWidth + 2, (int)dimensions.extendedHeight + 2);
                    Gameplay gameplay = new Gameplay((int)dimensions.extendedWidth, (int)dimensions.extendedHeight);
                    index = gameplay.Run(index);

                }
                #endregion
                #region how to play
                // how to play 1:1:2
                else if (index == 112 || index == 122)
                {
                    Console.SetWindowSize((int)dimensions.regularWidth + 2, (int)dimensions.regularHeight + 2);
                    Console.SetBufferSize((int)dimensions.regularWidth + 2, (int)dimensions.regularHeight + 2);
                    HowToPlayScreen howToPlayScreen = new HowToPlayScreen();
                    index = howToPlayScreen.Screen((int)dimensions.regularWidth, (int)dimensions.regularHeight, index);
                }
                // how to play 2:1:2
                else if (index == 212 || index == 222)
                {
                    Console.SetWindowSize((int)dimensions.extendedWidth + 2, (int)dimensions.regularHeight + 2);
                    Console.SetBufferSize((int)dimensions.extendedWidth + 2, (int)dimensions.regularHeight + 2);
                    HowToPlayScreen howToPlayScreen = new HowToPlayScreen();
                    index = howToPlayScreen.Screen((int)dimensions.extendedWidth, (int)dimensions.regularHeight, index);
                }
                // how to play 3:1:2
                else if (index == 312 || index == 322)
                {
                    Console.SetWindowSize((int)dimensions.regularWidth + 2, (int)dimensions.extendedHeight + 2);
                    Console.SetBufferSize((int)dimensions.regularWidth + 2, (int)dimensions.extendedHeight + 2);
                    HowToPlayScreen howToPlayScreen = new HowToPlayScreen();
                    index = howToPlayScreen.Screen((int)dimensions.regularWidth, (int)dimensions.extendedHeight, index);
                }
                // how to play 4:1:2
                else if (index == 412 || index == 422)
                {
                    Console.SetWindowSize((int)dimensions.extendedWidth + 2, (int)dimensions.extendedHeight + 2);
                    Console.SetBufferSize((int)dimensions.extendedWidth + 2, (int)dimensions.extendedHeight + 2);
                    HowToPlayScreen howToPlayScreen = new HowToPlayScreen();
                    index = howToPlayScreen.Screen((int)dimensions.extendedWidth, (int)dimensions.extendedHeight, index);
                }
                #endregion
                #region settings
                // settings 1:1:3
                else if (index == 113 || index == 123)
                {
                    Console.SetWindowSize((int)dimensions.regularWidth + 2, (int)dimensions.regularHeight + 2);
                    Console.SetBufferSize((int)dimensions.regularWidth + 2, (int)dimensions.regularHeight + 2);
                    SettingsScreen settingsScreen = new SettingsScreen();
                    index = settingsScreen.Screen((int)dimensions.regularWidth, (int)dimensions.regularHeight, index);
                }
                // settings 2:1:3
                else if (index == 213 || index == 223)
                {
                    Console.SetWindowSize((int)dimensions.extendedWidth + 2, (int)dimensions.regularHeight + 2);
                    Console.SetBufferSize((int)dimensions.extendedWidth + 2, (int)dimensions.regularHeight + 2);
                    SettingsScreen settingsScreen = new SettingsScreen();
                    index = settingsScreen.Screen((int)dimensions.extendedWidth, (int)dimensions.regularHeight, index);
                }
                // settings 3:1:3
                else if (index == 313 || index == 323)
                {
                    Console.SetWindowSize((int)dimensions.regularWidth + 2, (int)dimensions.extendedHeight + 2);
                    Console.SetBufferSize((int)dimensions.regularWidth + 2, (int)dimensions.extendedHeight + 2);
                    SettingsScreen settingsScreen = new SettingsScreen();
                    index = settingsScreen.Screen((int)dimensions.regularWidth, (int)dimensions.extendedHeight, index);
                }
                // settings 4:1:3
                else if (index == 413 || index == 423)
                {
                    Console.SetWindowSize((int)dimensions.extendedWidth + 2, (int)dimensions.extendedHeight + 2);
                    Console.SetBufferSize((int)dimensions.extendedWidth + 2, (int)dimensions.extendedHeight + 2);
                    SettingsScreen settingsScreen = new SettingsScreen();
                    index = settingsScreen.Screen((int)dimensions.extendedWidth, (int)dimensions.extendedHeight, index);
                }
                #endregion
                // EXIT
                else if ((index % 10) == 4)
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
