using SnapGame.Entities;

namespace SnapGame.Interfaces
{
    public interface IPlayer
    {
        Card TakeTurnAndMatch(Card topCard);
        bool TakeCard(Card card);
        bool HasWon();
        void RenderHand();
        void RenderPlayed(Card card);
    }
}
