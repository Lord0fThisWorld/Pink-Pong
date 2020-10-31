using System;
using System.Collections.Generic;
using System.Text;

namespace PingPong
{
    class ScreenBase : UserInputReader
    {
        protected DateTime startupDate;
        protected TimeSpan mainClock;
        #region frames drawing
        protected void OuterFrameDraw(int width, int height, char font)
        {
            #region horizontal lines
            // Up from left to right
            for (int i = 0; i <= width; i++)
            {
                Console.SetCursorPosition(i, 0);
                Console.Write(font);
            }
            // Down from left to right
            for (int i = 1; i <= width; i++)
            {
                Console.SetCursorPosition(i, (height + 1));
                Console.Write(font);
            }
            #endregion
            #region vertical lines
            // Left from top to bottom
            for (int i = 0; i <= height + 1; i++)
            {
                Console.SetCursorPosition(0, i);
                Console.Write(font);
            }
            // Right from top to bottom
            for (int i = 0; i <= height + 1; i++)
            {
                Console.SetCursorPosition((width + 1), i);
                Console.Write(font);
            }
            #endregion
        }
        /// <summary>
        /// Width 57 Height 18 with frame (inside space without frame -2)
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="font"></param>
        protected void InnerFrameDraw(int x, int y, char font)
        {
            #region horizontal Lines
            // Up from left to right
            for (int i = x + 1; i < x + 56; i++)
            {
                Console.SetCursorPosition(i, y);
                Console.Write(font);
            }
            // Down from left to right
            for (int i = x + 1; i < x + 56; i++)
            {
                Console.SetCursorPosition(i, y + 17);
                Console.Write(font);
            }
            #endregion
            #region vertical Lines
            // Left from top to bottom
            for (int i = y; i < y + 18; i++)
            {
                Console.SetCursorPosition(x, i);
                Console.Write(font);
            }
            // Right from top to bottom
            for (int i = y; i < y + 18; i++)
            {
                Console.SetCursorPosition(x + 56, i);
                Console.Write(font);
            }
            #endregion
        }
        #endregion
        #region word drawing from letters
        /// <summary>
        /// Letters avaliable to print: W,L,E,M,O,C
        /// </summary>
        /// <param name="x">top-leftmost x-coordinate</param>
        /// <param name="y">top-leftmost y-coordinate</param>
        /// <param name="word">only lowercase</param>       
        protected void WordDraw(int x, int y, string word)
        {
            // each letter takes 5 characters of space, and after each should me 2 letter of space, so next letter should have x value equal x+7
            char[] wordToPrint = word.ToCharArray();
            for (int i = 0; i < wordToPrint.Length; i++)
            {
                switch (wordToPrint[i])
                {
                    case 'w':
                        W_Letter_Write(x + (i * 7), y, '░');
                        break;
                    case 'e':
                        E_Letter_Write(x + (i * 7), y, '░');
                        break;
                    case 'l':
                        L_Letter_Write(x + (i * 7), y, '░');
                        break;
                    case 'c':
                        C_Letter_Write(x + (i * 7), y, '░');
                        break;
                    case 'o':
                        O_Letter_Write(x + (i * 7), y, '░');
                        break;
                    case 'm':
                        M_Letter_Write(x + (i * 7), y, '░');
                        break;
                }
            }
        }
        protected void WordDraw(int x, int y, string word, char font)
        {
            // each letter takes 5 characters of space, and after each should me 2 letter of space, so next letter should have x value equal x+7
            char[] wordToPrint = word.ToCharArray();
            for (int i = 0; i < wordToPrint.Length; i++)
            {
                switch (wordToPrint[i])
                {
                    case 'w':
                        W_Letter_Write(x + (i * 7), y, font);
                        break;
                    case 'e':
                        E_Letter_Write(x + (i * 7), y, font);
                        break;
                    case 'l':
                        L_Letter_Write(x + (i * 7), y, font);
                        break;
                    case 'c':
                        C_Letter_Write(x + (i * 7), y, font);
                        break;
                    case 'o':
                        O_Letter_Write(x + (i * 7), y, font);
                        break;
                    case 'm':
                        M_Letter_Write(x + (i * 7), y, font);
                        break;
                }
            }
        }
        #endregion
        #region letters drawing
        // Whole letter takes 5x5 downleft to the initial coordinates
        protected void W_Letter_Write(int x, int y, char font)
        {
            #region vertical lines
            // left line from top to bottom
            for (int i = y; i < y + 5; i++)
            {
                Console.SetCursorPosition(x, i);
                Console.Write(font);
            }
            // right line from top to bottom
            for (int i = y; i < y + 5; i++)
            {
                Console.SetCursorPosition(x + 4, i);
                Console.Write(font);
            }
            #endregion
            #region vertical lines
            // downmost line from left to right
            for (int i = x; i < x + 5; i++)
            {
                Console.SetCursorPosition(i, y + 4);
                Console.Write(font);
            }
            #endregion
            // central point
            Console.SetCursorPosition(x + 2, y + 3);
            Console.Write(font);
        }
        protected void E_Letter_Write(int x, int y, char font)
        {
            #region vertical lines
            // left line from top to bottom
            for (int i = y; i < y + 5; i++)
            {
                Console.SetCursorPosition(x, i);
                Console.Write(font);
            }
            #endregion
            #region horizontal lines
            // uppermost line from left to right
            for (int i = x + 1; i < x + 5; i++)
            {
                Console.SetCursorPosition(i, y);
                Console.Write(font);
            }
            // middle line from left to right
            for (int i = x + 1; i < x + 3; i++)
            {
                Console.SetCursorPosition(i, y + 2);
                Console.Write(font);
            }
            // downmost line from left to right
            for (int i = x + 1; i < x + 5; i++)
            {
                Console.SetCursorPosition(i, y + 4);
                Console.Write(font);
            }
            #endregion
        }
        protected void L_Letter_Write(int x, int y, char font)
        {
            #region vertical lines
            // left line from top to bottom
            for (int i = y; i < y + 5; i++)
            {
                Console.SetCursorPosition(x, i);
                Console.Write(font);
            }
            #endregion
            #region horizontal lines
            // downmost line from left to right
            for (int i = x + 1; i < x + 5; i++)
            {
                Console.SetCursorPosition(i, y + 4);
                Console.Write(font);
            }
            #endregion
        }
        protected void C_Letter_Write(int x, int y, char font)
        {
            #region vertical lines
            // left line from top to bottom
            for (int i = y; i < y + 5; i++)
            {
                Console.SetCursorPosition(x, i);
                Console.Write(font);
            }
            #endregion
            #region horizontal lines
            // uppermost line from left to right
            for (int i = x + 1; i < x + 5; i++)
            {
                Console.SetCursorPosition(i, y);
                Console.Write(font);
            }
            // downmost line from left to right
            for (int i = x + 1; i < x + 5; i++)
            {
                Console.SetCursorPosition(i, y + 4);
                Console.Write(font);
            }
            #endregion
        }
        protected void O_Letter_Write(int x, int y, char font)
        {
            #region vertical lines
            // left line from top to bottom
            for (int i = y; i < y + 5; i++)
            {
                Console.SetCursorPosition(x, i);
                Console.Write(font);
            }
            // right line from top to bottom
            for (int i = y; i < y + 5; i++)
            {
                Console.SetCursorPosition(x + 4, i);
                Console.Write(font);
            }
            #endregion
            #region horizontal lines
            // uppermost line from left to right
            for (int i = x + 1; i < x + 5; i++)
            {
                Console.SetCursorPosition(i, y);
                Console.Write(font);
            }
            // downmost line from left to right
            for (int i = x + 1; i < x + 5; i++)
            {
                Console.SetCursorPosition(i, y + 4);
                Console.Write(font);
            }
            #endregion
        }
        protected void M_Letter_Write(int x, int y, char font)
        {
            #region vertical lines
            // left line from top to bottom
            for (int i = y; i < y + 5; i++)
            {
                Console.SetCursorPosition(x, i);
                Console.Write(font);
            }
            // right line from top to bottom
            for (int i = y; i < y + 5; i++)
            {
                Console.SetCursorPosition(x + 4, i);
                Console.Write(font);
            }
            #endregion
            #region horizontal lines
            // uppermost line from left to right
            for (int i = x; i < x + 5; i++)
            {
                Console.SetCursorPosition(i, y);
                Console.Write(font);
            }
            #endregion
            // central point
            Console.SetCursorPosition(x + 2, y + 1);
            Console.Write(font);
        }
        #endregion
        protected void AlienSpaceshipDraw(int x,int y)
        {
            string[] alienSpaceship = { "                _____",
                                        "             ,-\"     \"-.",
                                        "            / o       o \\",
                                        "           /   \\     /   \\",
                                        "          /     )-\"-(     \\",
                                        "         /     ( 6 6 )     \\",
                                        "        /       \\ \" /       \\",
                                        "       /         )=(         \\",
                                        "      /   o   .--\"-\"--.   o   \\",
                                        "     /    I  /  -   -  \\  I    \\",
                                        " .--(    (_}y/\\       /\\y{_)    )--.",
                                        "(    \".___l\\/__\\_____/__\\/l___,\"    )",
                                        " \\                                 /",
                                        "  \"-._      o O o O o O o      _,-\"",
                                        "      `--Y--.___________.--Y--'"};
            for (int i = 0; i < alienSpaceship.Length; i++)
            {
                Console.SetCursorPosition(x, y + i);
                Console.Write(alienSpaceship[i]);
            }

            
        }
        protected void AlienSpaceshipDrawBlink(int x, int y)
        {
            string[] alienSpaceship = { "                _____",
                                        "             ,-\"     \"-.",
                                        "            / o       o \\",
                                        "           /   \\     /   \\",
                                        "          /     )-\"-(     \\",
                                        "         /     ( 6 - )     \\",
                                        "        /       \\ \" /       \\",
                                        "       /         )=(         \\",
                                        "      /   o   .--\"-\"--.   o   \\",
                                        "     /    I  /  -   -  \\  I    \\",
                                        " .--(    (_}y/\\       /\\y{_)    )--.",
                                        "(    \".___l\\/__\\_____/__\\/l___,\"    )",
                                        " \\                                 /",
                                        "  \"-._      o O o O o O o      _,-\"",
                                        "      `--Y--.___________.--Y--'"};
            for (int i = 0; i < alienSpaceship.Length; i++)
            {
                Console.SetCursorPosition(x, y + i);
                Console.Write(alienSpaceship[i]);
            }


        }
        protected void FaceDraw(int x, int y)
        {
            string[] face = {   "@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@",
                                "@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@&@@@@@@&@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@",
                                "@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@&/*,,,,,,,,.,,*,,,,..,*,,,*(&@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@",
                                "@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@%*,,,................,.,.....,,,,,*%@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@",
                                "@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@&,,,,...................,,,,,,,,,,....,/@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@",
                                "@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@#*,,............,,......,...      .,....,,%@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@",
                                "@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@%*,...    ..........    .....,................,(@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@",
                                "@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@(*......   ..,.....,.,.,,,..,,,*************,,,,,*&@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@",
                                "@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@/,,,...........,,,,,,,,,****////(((((((((((((//***,*/@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@",
                                "@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@%*,.,....   ...,,,**,*/////(((((((##((((((((((((///****(@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@",
                                "@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@/.,.... ....,,**///((((((((((####(((((((#(#((((((//***,*/@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@",
                                "@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@*,,,,....,*///((((((###(#(###((((((((#####(((((((///*****(@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@",
                                "@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@*,,,,.,,*///((((((#####((###((#(((######((((((((/////****/@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@",
                                "@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@/,,,,,,*////(((((##########(#######(##((((((((/((////*,,,*%@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@",
                                "@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@(*,,,,**////(((((((((((((#######((((///*,,,,*****/////*,,*%@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@",
                                "@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@%,,,,**////*****,,,,,,**//(((((((//*,,,*///(/////**///*,,*@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@",
                                "@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@*,,,*////**//(((((///****//(((((/*****/(((((/**///////**/@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@",
                                "@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@/,,,*///*///**//,  .,***////(#((/*///*(.. .*,,****////**#@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@",
                                "@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@(,**////**,..*/,*//////////((((///////(/////////////(*//*/@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@",
                                "@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@(///**(///////////(//((((////((((///((((((((((((((((//////**@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@",
                                "@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@*//(//(//////(((((((((((/////((((////(((((((((((((((////((*/@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@",
                                "@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@//((/*/////((((((((((((/////(((((/////((((((((((((((///(*(*#@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@",
                                "@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@((//*(////((((((((((((//////(((((////*//((((((((((((////*/#@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@",
                                "@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@((/*(////(((((((((///*////(##(#/////**//((((((((//////(#@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@",
                                "@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@((/////((((((((//////*,,*///**,*****/////((////////((@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@",
                                "@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@%(((//////////////////////****//////(//(/////////%@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@",
                                "@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@&////////////////(((((((((((((///////////*///@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@",
                                "@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@&/////////***,,,,*,**,,,*******///*////////%@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@",
                                "@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@////////////////////(////////////////*///(@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@",
                                "@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@//////**//////////////////////////**////(@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@",
                                "@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@////////***///////((((((////////////////(@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@",
                                "@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@/////////////////((((((((((//////////////@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@",
                                "@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@//////////////////(((/(///////**/////////@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@",
                                "@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@//////(////////////////////***///////////@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@",
                                "@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@//////(//////////*********///////////////#@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@",
                                "@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@&&(*////(///////(/((//////*//////////////////#@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@",
                                "@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@&&&&//////(((((/////((((((((((((((////////////////*&&@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@",
                                "@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@&&&&&&&&/(//////(((((///////((((((////////*////(///////&&&&&@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@",
                                "@@@@@@@@@@@@@@@@@@@@@@@@@@&&&&&&&&&&&&&((/((((((((((//(/(//////////////((((((/(/////(&&&&&&&&&@@@@@@@@@@@@@@@@@@@@@@@@@@@",
                                "@@@@@@@@@@@@@@@@@@@@@@@&&&&&&&&&@@@@@&&&((((((((((((((/(//////////////((((((((((((/#&&&&&&&&&&&&&&@@@@@@@@@@@@@@@@@@@@@@@",
                                "@@@@@@@@@@@@@@@@@@&@&&&@&&&&&&@@@@@@@@&&@(((((((((((((((((((((((((/(((((((((((((((@&&&@@&&&&@&&@@&&&&&@@@@@@@@@@@@@@@@@@@",
                                "@@@@@@@@@@@@@@&&&&&&&&@&&&&&&@@@@@@@@@@&&&@(((((((((((((((((((///((((((((((((((#@&&&@@@&&&&&@@&&@@&&&&&@&@@@@@@@@@@@@@@@@",
                                "@@@@@@@@@&&&&&&&&&&&@@&&@&&&@@@@@@@@@@@@@&&&&&((((((((((((((((((((((((((((((&&&&&@@@@@@@&&&&&&&&@@@@@&&&&@@@@@@@@@@@@@@@@",
                                "@@@&&&&&@&&&&&&&&&&@@&&&&&&&@&@@@@@@@@@@@@@&&&&&@%(((((((((((((((((((((#&&&&&&@@@@@&@@@&&&&&&@@&&@@@&@&&@&&@@@&&@@@@@@@@@",
                                "&&&&&&&&&&&&&&&&&&@&&&@&&&&@@@@@@@@@@@@@@@@@@@&&&&&&&&&&@@&&&&&&&@@&&&&&&&@@@@@@@@&@@@@&&&&&@@&&&&@@@&@&&@@&&@@@&&&&@@@@@",
                                "&&&&&&&&&&&&&&@&&&&&@@&&&&@@&&@@@@@@@@@@@@@@@@@@@@@@&&&&&&&&&&&&&&&&&@@&@@@@@@@@@@@@@@@@@@@&&@@&&&@@@@&@&&@@&&@@@@&&&&&@@",
                                "@&&&&&&&&&&&&@&%&&&@@&&&&&@&@@@@@@@@@@@@@@@@@@&@@&&&&@@@@@@@&&@@@@@&&&&@@@@@@@@@@@@@@@@@@@@&@@@@&&@@@@&&@&&@@@&&@@@&&&&&&",
                                "&&&&&&&&&&&&&&%&@@@@&&&&&@&&&&@@@@@@@@@@@@@@@@@@@@@@@@&&&&&&&&&&@&@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@&@@@@@&&@&@@@@&&@@@&&&&"};
            for (int i = 0; i < face.Length; i++)
            {
                Console.SetCursorPosition(x, y + i);
                Console.Write(face[i]);
            }
        }
        protected void ScientistLeftDraw(int x, int y)
        {
            string[] scientistLeft = {  "      ____ ",
                                        "     /  __\\",
                                        "     \\( oo",
                                        "     _\\_o/",
                                        "    / \\|/ \\___",
                                        "   \\ \\|   |__/_)",
                                        "    \\/_)  |",
                                        "     ||___|",
                                        "     | | |",
                                        "     | | |",
                                        "     |_|_|",
                                        "     [__)_)"};
            for (int i = 0; i < scientistLeft.Length; i++)
            {
                Console.SetCursorPosition(x, y + i);
                Console.Write(scientistLeft[i]);
            }
        }
        protected void ScientistRightDraw(int x, int y)
        {
            string[] scientistRight = { "     ____",
                                        "    (___ \\",
                                        "     oo~)/",
                                        "    _\\-_/_",
                                        "   / \\|/  \\",
                                        "  / / .- \\ \\",
                                        "  \\ \\ .  /_/",
                                        "   \\/___(_/",
                                        "    | |  |",
                                        "    | |  |",
                                        "    |_|__|",
                                        "   (_(___]"};
            for (int i = 0; i < scientistRight.Length; i++)
            {
                Console.SetCursorPosition(x, y + i);
                Console.Write(scientistRight[i]);
            }
        }
        protected void BookDraw(int x, int y)
        {
            string[] book = {   "        _________   _________",
                                "   ____/ SETTING \\ /  STATE  \\____",
                                " /| ------------- |  ------------ |\\",
                                "||| ------------- | ------------- |||",
                                "||| ------------- | ------------- |||",
                                "||| ------------- | ------------- |||",
                                "||| ------------- | ------------- |||",
                                "||| ------------- | ------------- |||",
                                "||| ------------- | ------------- |||",
                                "||| ------------- | ------------- |||",
                                "||| ------------- | ------------- |||",
                                "||| ------------- | ------------- |||",
                                "||| ------------- | ------------- |||",
                                "|||_____________  |  _____________|||",
                                " \\_____/--------\\\\_//--------\\_____/"};
            for (int i = 0; i < book.Length; i++)
            {
                Console.SetCursorPosition(x, y + i);
                Console.Write(book[i]);
            }
        }
    }
}
