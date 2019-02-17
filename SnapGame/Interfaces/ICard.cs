using SnapGame.Entities;

namespace SnapGame.Interfaces
{
    public interface ICard
    {
        Card RandomCard();
        void TurnOver();
    }
}
