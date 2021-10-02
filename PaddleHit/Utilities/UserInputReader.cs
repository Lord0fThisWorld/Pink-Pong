using System;

namespace Game
{
    class UserInputReader
    {
        protected ConsoleKeyInfo keyInfo = new ConsoleKeyInfo();
        protected ConsoleKey consoleKey = new ConsoleKey();

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
