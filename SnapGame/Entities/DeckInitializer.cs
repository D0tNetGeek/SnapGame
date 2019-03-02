using System.Collections.Generic;
using SnapGame.Interfaces;

namespace SnapGame.Entities
{
    public class DeckInitializer : IDeckInitializer
    {
        private readonly IDeckGenerator _deckGenerator;
        private readonly IDeckShuffler _deckShuffler;

        public DeckInitializer(IDeckGenerator deckGenerator,
            IDeckShuffler deckShuffler)
        {
            _deckGenerator = deckGenerator;
            _deckShuffler = deckShuffler;
        }

        public List<Card> Initialize()
        {
            var cards = _deckGenerator.Generate();
            cards = _deckShuffler.Shuffle(cards);
            return cards;
        }
    }
}
