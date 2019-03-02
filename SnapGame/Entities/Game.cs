using System;
using System.Collections.Generic;

using System.Linq;
using SnapGame.Enums;
using SnapGame.Interfaces;

namespace SnapGame.Entities
{
    public class Game : IGame
    {
        private readonly IInputOutputService _inputOutputService;
        private readonly List<IPlayer> _players;
        private readonly List<Card> _deck;
        private readonly List<Card> _cardsOnCenterOfTable = new List<Card>();

        private bool _gameEnded;

        public Game(IInputOutputService inputOutputService,
                    IDeckInitializer deckInitializer,
                    ICardSpreader cardSpreader,
                    string[] playerNames)
        {
            _inputOutputService = inputOutputService;
            _gameEnded = false;
            _players = new List<IPlayer>();

            foreach (var name in playerNames)
            {
                _players.Add(new Player(_inputOutputService, name));
            }

            Console.WriteLine($"\nThe Players are: {(string.Join(", ", playerNames))}\n");

            _deck = deckInitializer.Initialize();
            cardSpreader.SpreadCardToPlayer(_deck, _players);
        }

        /// <summary>
        /// Starts the game.
        /// </summary>
        public void Run()
        {
            while (!IsFinished())
            {
                var playersWithoutCards = new List<IPlayer>();
                List<Card> temp = new List<Card>();

                foreach (var player in _players)
                {
                    if (_players.Count > 1)
                    {
                        _inputOutputService.WriteLine(player.PlayerName + " play your card\n");
                        _inputOutputService.ReadLine();
                    }

                    if (_deck.Count > 0)
                    {
                        if (_cardsOnCenterOfTable.Count > 0 && player.PlayTurn(_cardsOnCenterOfTable[_cardsOnCenterOfTable.Count - 1]))
                        {
                            if (_players.Count > 1)
                            {
                                _inputOutputService.WriteLine("SNAP !!\n");

                                player.CardsList.RemoveAt(player.CardsList.Count - 1);

                                temp = new List<Card>();
                                temp.AddRange(player.CardsList);

                                player.CardsList.Clear();

                                foreach (Card card in _cardsOnCenterOfTable)
                                    player.CardsList.Add(card);

                                player.CardsList.AddRange(temp);

                                temp.Clear();

                                _cardsOnCenterOfTable.Clear();
                            }
                        }
                        else
                        {
                            var cardOnTop = player.CardsList.LastOrDefault();

                            if (cardOnTop != null)
                            {
                                _cardsOnCenterOfTable.Add(new Card(cardOnTop.Rank, cardOnTop.Suit));
                                _inputOutputService.WriteLine(player.PlayerName + " is playing " + cardOnTop.CardName + "\n");
                                player.CardsList.Remove(cardOnTop);
                            }
                        }

                        _inputOutputService.WriteLine(player.PlayerName + " has " + player.CardsList.Count + " card(s) remaining !!\n");

                        if (player.CardsList.Count == 0)
                        {
                            playersWithoutCards.Add(player);
                            break;
                        }
                    }
                }

                foreach (var playerWithoutCards in playersWithoutCards)
                {
                    _inputOutputService.WriteLine(playerWithoutCards.PlayerName + " has lost his cards !!" + "\n");
                    _players.Remove(playerWithoutCards);
                }

                if (_players.Count <= 1)
                {
                    _inputOutputService.WriteLine(((Player)_players[0]).PlayerName + " has WON !!" + "\n");
                    _gameEnded = true;
                    return;
                }
            }
        }

        /// <summary>
        /// Is game is finished.
        /// </summary>
        /// <returns></returns>
        public bool IsFinished()
        {
            return _gameEnded;
        }
    }
}
