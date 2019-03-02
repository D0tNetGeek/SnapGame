using System;
using SnapGame.Interfaces;

namespace SnapGame.Entities
{
    public class ConsoleService : IInputOutputService
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }

        public void WriteLine(string v)
        {
            Console.WriteLine(v);
        }
    }
}
