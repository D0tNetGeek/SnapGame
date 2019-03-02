using System;
using System.Collections.Generic;
using System.Linq;
using SnapGame.Interfaces;

namespace SnapGame.Entities
{
    public class Player : IPlayer
    {
        private readonly IInputOutputService _inputOutputService;

        protected string _playerName;

        public string PlayerName
        {
            get => _playerName;
        }

        private List<Card> _cardsList;

        public List<Card> CardsList
        {
            get => _cardsList;
        }

        public Player(IInputOutputService inputOutputService, string playerName)
        {
            _inputOutputService = inputOutputService;
            _playerName = playerName;
            _cardsList = new List<Card>();
        }

        /// <summary>
        /// Plays the turn.
        /// </summary>
        /// <param name="topCard"></param>
        /// <returns></returns>
        public bool PlayTurn(Card topCard)
        {
            if (_cardsList.Count > 0 && _cardsList[_cardsList.Count - 1].Matching(topCard))
            {
                Console.WriteLine(_playerName + " is playing : " + _cardsList[_cardsList.Count - 1].CardName + "\n");

                return true;
            }

            return false;
        }

        /// <summary>
        /// Shows the cards.
        /// </summary>
        public void ShowCards()
        {
            _inputOutputService.WriteLine($"{_playerName} has [{(string.Join(", ", _cardsList.Select(x => x.CardName)))}]\n");
        }
    }
}