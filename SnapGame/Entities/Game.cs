using System;
using System.Collections.Generic;
using System.Linq;
using SnapGame.Enums;
using SnapGame.Interfaces;

namespace SnapGame.Entities
{
    public class Game : IGame
    {
        protected List<Player> _players;
        protected List<Card> _deck;
        protected Card _topCard;

        private Random randNum = new Random();

        public Game(List<string> names)
        {
            Console.WriteLine("Starting game with " + String.Join(", ", names.ToArray())+ "\n\n");

            _players = new List<Player>();

            foreach (var name in names)
            {
                _players.Add(new Player(name));
            }
        }

        public void Initialize()
        {
            _deck = new List<Card>();

            foreach (Suit suit in (Suit[]) Enum.GetValues(typeof(Suit)))
            {
                foreach (Rank rank in (Rank[])Enum.GetValues(typeof(Rank)))
                {
                   _deck.Add(new Card(suit.ToString(), rank.ToString()));
                }
            }

            Shuffle();
            Deal();

            _topCard = _deck.LastOrDefault();

            Console.WriteLine("Top card is : " + _topCard.GetCardName + "\n\n");
        }

        /// <summary>
        /// Shuffle pack of cards
        /// </summary>
        public void Shuffle()
        {
            Console.WriteLine("Shuffling Deck...\n\n");

            int deckLength = _deck.Count;

            while(deckLength > 0 )
            {
                int i = randNum.Next(deckLength);
                var temp = _deck[deckLength-1];

                _deck[deckLength-1] = _deck[i];
                _deck[i] = temp;

                deckLength--;
            }
        }

        /// <summary>
        /// Deal each player seven cards
        /// </summary>
        public void Deal()
        {
            foreach (var player in _players)
            {
                int numCards = _deck.Count / _players.Count;

                while(numCards-- > 0)
                {
                    player.Hand.Add(_deck[randNum.Next(_deck.Count)]);
                }

                player.RenderHand();
            }
        }

        /// <summary>
        /// Run the game until we have winner
        /// </summary>
        public void Run()
        {
            int deckLength = _deck.Count;

            while (deckLength > 0)
            {
                int numPlayers = _players.Count;

                for (int i = 0; i < numPlayers; i++)
                {
                    var player = _players[i];
                    var match = player.TakeTurnAndMatch(_topCard);

                    if (match != null)
                    {
                        if (player.HasWon())
                        {
                            return;
                        }

                        _topCard = match;

                        Console.WriteLine(player.PlayerName + " SNAP !! \n\n");
                    }
                    else
                    {
                        var card = player.TakeCard(_deck.Last());

                        if (!card && AllSkipped())
                        {
                            Console.WriteLine("No winner this time...");
                            return;
                        }
                    }
                }
                deckLength--;
            }
        }

        public bool AllSkipped()
        {
            foreach (var player in _players)
            {
                if (!player.Skipped)
                {
                    return false;
                }            
            }
            return false;
        }
    }
}
