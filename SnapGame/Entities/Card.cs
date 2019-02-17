using System;
using SnapGame.Enums;
using SnapGame.Interfaces;

namespace SnapGame.Entities
{
    /// <summary>
    /// Each Card has a Rank and a Suit, and can be either face up or face down.
    /// </summary>
    public class Card : ICard
    {
        private readonly Rank _rank;
        private readonly Suit _suit;
        private bool _faceUp;

        /// <summary>
        /// Create a new card with the indicated rank and suit.
        /// By default the card will be face down.
        /// </summary>
        /// <param name="r">The rank value for the card.</param>
        /// <param name="s">The suit value for the card.</param>
        public Card(Rank r, Suit s)
        {
            _rank = r;
            _suit = s;
            _faceUp = false;
        }

        /// <summary>
        /// Create and return a new card with randomised Rank and Suit.
        /// </summary>
        public Card RandomCard()
        {
            Random rand = new Random();

            Rank randomRank = (Rank)(rand.Next((int)Rank.King) + 1);
            Suit randomSuit = (Suit)(rand.Next((int)Suit.Spades + 1));

            Card randomCard = new Card(randomRank, randomSuit);

            return randomCard;
        }

        /// <summary>
        /// Allows you to read the value of the Card's rank.
        /// </summary>
        /// <value>The rank.</value>
        public Rank Rank
        {
            get { return _rank; }
        }

        /// <summary>
        /// Allows you to read the value of the Card's suit.
        /// </summary>
        /// <value>The suit.</value>
        public Suit Suit
        {
            get { return _suit; }
        }

        /// <summary>
        /// Allows you to check if the card is fact up, or face down.
        /// </summary>
        /// <value><c>true</c> if the card is face up; otherwise, <c>false</c> to indicate face down.</value>
        public bool FaceUp
        {
            get { return _faceUp; }
        }

        /// <summary>
        /// Turns the card over, a face up card will become face down whereas a face down card will become
        /// face up.
        /// </summary>
        public void TurnOver()
        {
            _faceUp = !_faceUp;
        }

        /// <summary>
        /// Returns the index of the card when laid out in sequence from Ace Spades, to the Kind of Clubs.
        /// Suits are in the order Spades, Hearts, Diamonds, then Clubs. Cards are then ordered within the
        /// suit by rank from Ace to King. Where the card is face down, this will return the 52 (the 53rd card)
        /// which can be used to represent the back of the cards.
        /// </summary>
        /// <value>The index of the card.</value>
        public int CardIndex
        {
            get
            {
                if (_faceUp)
                {
                    switch (_suit)
                    {
                        case Suit.Spades:
                            return (int)_rank - 1; // Ace = 1, but Ace Spades should be 0
                        case Suit.Hearts:
                            return 12 + (int)_rank;
                        case Suit.Diamonds:
                            return 25 + (int)_rank;
                        case Suit.Clubs:
                            return 38 + (int)_rank;
                        default:
                            return 52;
                    }
                }
                else
                    return 52;

            }
        }

        /// <summary>
        /// Returns a <see cref="System.String"/> that represents the current <see cref="Card"/>. This will have
        /// the first character representing the rank (using T for 10), and then a symbol for the suit. For example, QS is
        /// the Queen of Spades, 8H is Eight Hearts, TD is Ten Diamonds, and 2C is 2 of Clubs. Where the card is face down
        /// this will return the value <c>"**"</c>.
        /// </summary>
        /// <returns>A <see cref="System.String"/> that represents the current <see cref="Card"/>.</returns>
        public override string ToString()
        {
            if (_faceUp)
            {
                String result = "";

                switch (_rank)
                {
                    case Rank.Jack:
                        result += "J";
                        break;
                    case Rank.Queen:
                        result += "Q";
                        break;
                    case Rank.King:
                        result += "K";
                        break;
                    case Rank.Ace:
                        result += "A";
                        break;
                    case Rank.Ten:
                        result += "T";
                        break;
                    default:
                        result += (int)_rank;
                        break;
                }

                switch (_suit)
                {
                    case Suit.Clubs:
                        result += "C";
                        break;
                    case Suit.Spades:
                        result += "S";
                        break;
                    case Suit.Hearts:
                        result += "H";
                        break;
                    case Suit.Diamonds:
                        result += "D";
                        break;
                    default:
                        result += "?";
                        break;
                }

                return result;
            }
            else
            {
                return "**";
            }
        }

    }
}
