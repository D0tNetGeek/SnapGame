using SnapGame.Entities;

namespace SnapGame.Interfaces
{
    public interface IDeck
    {
        /// <summary>
        /// Returns all of the cards to the Deck, and shuffles their order.
        /// All cards are turned so that they are face down.
        /// </summary>
        void Shuffle();

        /// <summary>
        /// Takes a card from the top of the Deck. This will return
        /// <c>null</c> when there are no cards remaining in the Deck.
        /// </summary>
        Card Draw();
    }
}
