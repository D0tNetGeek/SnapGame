using System.Collections.Generic;
using System.Linq;
using SnapGame.Interfaces;

namespace SnapGame.Entities
{
    public class DeckShuffler : IDeckShuffler
    {
        private readonly IRandomizer _randomizer;

        public DeckShuffler(IRandomizer randomizer)
        {
            _randomizer = randomizer;
        }

        public List<Card> Shuffle(IEnumerable<Card> inputCards)
        {
            if (inputCards == null)
            {
                return new List<Card>();
            }

            var inputCopy = inputCards.ToList();
            var shuffledCards = new List<Card>();
            int pos;

            while (inputCopy.Count > 0)
            {
                pos = _randomizer.Next(0, inputCopy.Count);
                shuffledCards.Add(inputCopy[pos]);

                inputCopy.RemoveAt(pos);
            }

            return shuffledCards;
        }
    }
}
