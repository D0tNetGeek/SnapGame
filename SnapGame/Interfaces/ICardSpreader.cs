using System.Collections.Generic;
using SnapGame.Entities;

namespace SnapGame.Interfaces
{
    public interface ICardSpreader
    {
        void SpreadCardToPlayer(List<Card> cards, List<IPlayer> players);
    }
}
