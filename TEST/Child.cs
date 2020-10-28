using System;
using System.Collections.Generic;
using System.Text;

namespace TEST
{
    class Child : Base
    {
        public void Run()
        {
            while(consoleKey != ConsoleKey.Enter)
            {
                consoleKey = ConsoleKey.A;
                Input();
            }
        }
    }
}
