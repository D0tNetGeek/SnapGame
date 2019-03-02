using System.Collections.Generic;
using SnapGame.Entities;

namespace SnapGame.Interfaces
{
    public interface IPlayer
    {
        List<Card> CardsList { get; }
        string PlayerName { get; }

        bool PlayTurn(Card topCard);
        void ShowCards();
    }
}
