using System;
using System.Collections.Generic;
using System.Linq;
using SnapGame.Interfaces;

namespace SnapGame.Entities
{
    public class Player : IPlayer
    {
        protected string _name;

        private List<Card> _hand;

        private bool _skipped;

        public Player(string name)
        {
            _name = name;
            _hand = new List<Card>();
            _skipped = false;
        }

        public bool Skipped => _skipped;

        public List<Card> Hand => _hand;

        public string PlayerName => _name;

        /// <summary>
        /// Take a turn and try to match with given card
        /// </summary>
        /// <param name="topCard"></param>
        /// <returns></returns>
        public Card TakeTurnAndMatch(Card topCard)
        {
            for(int i = _hand.Count - 1; i > 0; i--)
            {
                var card = _hand[i];

                if (card.Matches(topCard))
                {
                    _hand.RemoveAt(i);
                    _skipped = false;

                    RenderPlayed(card);

                    return card;
                }
            }

            return null;
        }

        /// <summary>
        /// Take a card from the rest stack if no match found
        /// </summary>
        /// <param name="card"></param>
        /// <returns></returns>
        public bool TakeCard(Card card)
        {
            if (card == null)
            {
                Console.WriteLine(_name + " has to skip a turn");

                _skipped = true;

                return false;
            }

            _hand.Add(card);

            Console.WriteLine(_name + " does not have suitable card, taking from deck: " + card.GetCardName + "\n\n");

            return true;
        }

        /// <summary>
        /// Check if the player has won, i.e has no more cards left.
        /// </summary>
        /// <returns></returns>
        public bool HasWon()
        {
            if (_hand.Count == 0)
            {
                Console.WriteLine(_name + " has won!!");

                return true;
            }

            return false;
        }

        /// <summary>
        /// Output players cards in hand
        /// </summary>
        public void RenderHand()
        {
            var cards = new List<Card>();

            foreach (var card in _hand)
            {
                cards.Add(card.GetCard());
            }

            Console.WriteLine(_name + " has been dealt: " + string.Join(", ", cards.Select(x=>x.GetCardName)) + "\n\n");
        }

        /// <summary>
        /// Output played card in this turn.
        /// </summary>
        /// <param name="card"></param>
        public void RenderPlayed(Card card)
        {
            Console.WriteLine(_name + " playes : " + card.GetCardName + "\n\n");

            if (_hand.Count == 1) 
            {
                Console.WriteLine(_name + " has 1 card remaining !");
            }
        }
       
    }
}