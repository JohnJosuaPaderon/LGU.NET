using System;

namespace LGU.NetStandardTest
{
    public class ConsoleColorManager
    {
        public static void InputHeader()
        {
            Console.ForegroundColor = ConsoleColor.Green;
        }

        public static void Input()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
        }

        public static void Error()
        {
            Console.ForegroundColor = ConsoleColor.Red;
        }

        public static void Default()
        {
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
