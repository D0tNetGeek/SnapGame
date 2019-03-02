using System;
using System.Collections.Generic;
using System.Linq;
using SnapGame.Enums;
using SnapGame.Interfaces;

namespace SnapGame.Entities
{
    public class DeckGenerator : IDeckGenerator
    {
        public List<Card> Generate()
        {
            var deck = new List<Card>();

            foreach (var suit in Enum.GetValues(typeof(Suit)).Cast<Suit>())
            {
                foreach (var rank in Enum.GetValues(typeof(Rank)).Cast<Rank>())
                {
                    deck.Add(new Card(suit.ToString(), rank.ToString()));
                }
            }

            return deck;
        }
    }
}
