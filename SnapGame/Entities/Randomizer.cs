using System;
using SnapGame.Interfaces;

namespace SnapGame.Entities
{
    public class Randomizer : IRandomizer
    {
        private Random _random = new Random();
        public int Next(int min, int max)
        {
            return _random.Next(min, max);
        }
    }
}
