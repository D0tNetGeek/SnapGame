using SnapGame.Interfaces;

namespace SnapGame.Entities
{
    public class Card : ICard
    {
        private readonly string _suit;
        private readonly string _rank;

        public string CardName => _rank + " of " + _suit;

        public string Rank => _rank;

        public string Suit => _suit;


        public Card(string suit, string rank)
        {
            _suit = suit;
            _rank = rank;
        }

        /// <summary>
        /// Returns matching card.
        /// </summary>
        /// <param name="card"></param>
        /// <returns></returns>
        public bool Matching(Card card)
        {
            var match = _rank == card._rank;

            return match;
        }
    }
}