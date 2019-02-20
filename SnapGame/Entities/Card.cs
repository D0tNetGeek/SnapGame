using System;
using SnapGame.Interfaces;

namespace SnapGame.Entities
{
    public class Card : ICard
    {
        protected string _suit;
        protected string _rank;

        public Card(string suit, string rank)
        {
            _suit = suit;
            _rank = rank;
        }

        public string Rank => _rank;

        public string Suit => _suit;

        public string GetCardName => _rank + " of " + _suit;

        public bool Matches(Card card)
        {
            var match = _rank == card._rank; //_suit == card._suit || 

            return match;
        }

        public Card GetCard()
        {
            return new Card(_suit, _rank);
        }
    }
}