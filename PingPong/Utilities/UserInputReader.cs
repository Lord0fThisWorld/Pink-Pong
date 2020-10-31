using System;

namespace PingPong
{
    class UserInputReader
    {
        protected ConsoleKeyInfo keyInfo = new ConsoleKeyInfo();
        protected ConsoleKey consoleKey = new ConsoleKey();
        // listens for user input
        protected void Input()
        {
            if (Console.KeyAvailable)
            {
                keyInfo = Console.ReadKey(true);
                consoleKey = keyInfo.Key;
            }
        }
    }
}
