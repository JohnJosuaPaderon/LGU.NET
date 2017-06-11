using LGU.NetStandardTest.TestModules;
using System;

namespace LGU.NetStandardTest
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleColorManager.Default();
            Heading();
            InitializeTestModules();
            ReadUserInput();
        }

        static void Heading()
        {
            Console.WriteLine("LGU.NET.1.0.0");
            Console.WriteLine("Copyright (c) 2017 John Josua R. Paderon");
            Console.WriteLine("----------------------------------------");
        }

        static void InitializeTestModules()
        {
            var coreMACAddress = new CoreMACAddress();
        }

        static void ReadUserInput()
        {
            ConsoleColorManager.InputHeader();
            Console.Write("LGU.NET:: ");
            ConsoleColorManager.Input();
            var input = Console.ReadLine();
            ConsoleColorManager.Default();

            if (string.IsNullOrWhiteSpace(input))
            {
                ConsoleColorManager.Error();
                Console.WriteLine("[INVALID_COMMAND]");
                ConsoleColorManager.Default();
                ReadUserInput();
            }
            else if (input == "--exit")
            {
                return;
            }
            else if (input == "--clear")
            {
                Console.Clear();
                ReadUserInput();
            }
            else
            {
                TestModule.Execute(input);
                ReadUserInput();
            }
        }

    }
}
