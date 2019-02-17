using SnapGame.Enums;
using SnapGame.Interfaces;

namespace SnapGame.Entities
{
    /// <summary>
    /// A Deck of 52 cards from which cards can be drawn.
    /// </summary>
    public class Deck : IDeck
    {
        private readonly Card[] _cards = new Card[52];
        private int _topCard;

        /// <summary>
        /// Creates a new Deck with 52 Cards. The first card
        /// will be the top of the Deck.
        /// </summary>
        public Deck()
        {
            int i = 0;

            for (Suit s = Suit.Clubs; s <= Suit.Spades; s++)
            {
                for (Rank r = Rank.Ace; r <= Rank.King; r++)
                {
                    Card c = new Card(r, s);
                    _cards[i] = c;
                    i++;
                }
            }

            _topCard = 0;
        }

        /// <summary>
        /// Indicates how many Cards remain in the Deck.
        /// </summary>
        /// <value>The number of cards remaining.</value>
        public int CardsRemaining
        {
            get
            {
                return 52 - _topCard;
            }
        }

        /// <summary>
        /// Takes a card from the top of the Deck. This will return
        /// <c>null</c> when there are no cards remaining in the Deck.
        /// </summary>
        public Card Draw()
        {
            if (_topCard < 52)
            {
                Card result = _cards[_topCard];
                _topCard++;
                return result;
            }
            else
            {
                return null;
            }

        }

        /// <summary>
		/// Returns all of the cards to the Deck, and shuffles their order.
		/// All cards are turned so that they are face down.
		/// </summary>
		public void Shuffle()
        {
            //TODO: implement shuffle!
        }
    }
}
