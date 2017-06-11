using System;
using System.Collections.Generic;

namespace LGU.NetStandardTest
{
    public abstract class TestModule
    {
        private static Dictionary<string, TestModule> Resource { get; } = new Dictionary<string, TestModule>();

        public TestModule(string command)
        {
            if (string.IsNullOrWhiteSpace(command))
            {
                throw new ArgumentException("Value cannot be null or white space.", nameof(command));
            }

            if (Resource.ContainsKey(command))
            {
                throw new Exception("Command already used.");
            }

            Command = command;
            Resource.Add(command, this);
        }

        public static void Execute(string command)
        {
            if (string.IsNullOrWhiteSpace(command))
            {
                throw new ArgumentException("Value cannot be null or white space.", nameof(command));
            }

            if (Resource.ContainsKey(command))
            {
                Console.WriteLine();
                Resource[command].Start();
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("No available test module.");
            }
        }

        public string Command { get; }
        public abstract void Start();
    }
}
