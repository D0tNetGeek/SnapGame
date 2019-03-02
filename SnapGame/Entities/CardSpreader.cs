using System.Collections.Generic;
using SnapGame.Interfaces;

namespace SnapGame.Entities
{
    public class CardSpreader : ICardSpreader
    {
        private readonly IInputOutputService _inputOutputService;

        public CardSpreader(IInputOutputService inputOutputService)
        {
            _inputOutputService = inputOutputService;
        }

        public void SpreadCardToPlayer(List<Card> cards, List<IPlayer> players)
        {
            int c = 0;

            for (int i = cards.Count; i > 0; i--)
            {
                if (i % players.Count == 0)
                {
                    c = i;
                    break;
                }
            }

            var pos = 0;
            for (int i = 0; i < c; i++)
            {
                if (pos == players.Count)
                    pos = 0;

                players[pos].CardsList.Add(cards[i]);

                pos++;
            }

            foreach (var player in players)
                player.ShowCards();
        }
    }
}
