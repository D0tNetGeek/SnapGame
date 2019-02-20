using SnapGame.Entities;

namespace SnapGame.Interfaces
{
    public interface ICard
    {
        bool Matches(Card card);
        Card GetCard();
    }
}
