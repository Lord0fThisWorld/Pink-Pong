using System;
using System.Collections.Generic;
using System.Text;

namespace TEST
{
    class Base
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
