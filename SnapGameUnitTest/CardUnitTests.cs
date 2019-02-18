using Microsoft.VisualStudio.TestTools.UnitTesting;
using SnapGame.Entities;
using SnapGame.Enums;

namespace SnapGameUnitTest
{
    [TestClass]
    public class CardUnitTests
    {
        [TestMethod]
        public void TestCardCreation()
        {
            Card card = new Card(Rank.King, Suit.Hearts);

            card.TurnOver();

            Assert.AreEqual(Rank.King, card.Rank);
            Assert.AreEqual(Suit.Hearts, card.Suit);

            card = new Card(Rank.Two, Suit.Diamonds);
            card.TurnOver();

            Assert.AreEqual(Rank.Two, card.Rank);
            Assert.AreEqual(Suit.Diamonds, card.Suit);
        }

        [TestMethod]
        public void TestCardIndex()
        {
            Card card = new Card(Rank.Ace, Suit.Spades);
            
            Assert.AreEqual(52, card.CardIndex);

            card.TurnOver();
            
            Assert.AreEqual(0, card.CardIndex);

            card  = new Card(Rank.King, Suit.Clubs);

            Assert.AreEqual(52, card.CardIndex);

            card.TurnOver();

            Assert.AreEqual(51, card.CardIndex);
        }

        [TestMethod]
        public void TestCardToString()
        {
            Card c = new Card(Rank.Ace, Suit.Spades);
            c.TurnOver();
            Assert.AreEqual("AS", c.ToString());

            c = new Card(Rank.Ten, Suit.Clubs);
            c.TurnOver();
            Assert.AreEqual("TC", c.ToString());

            c = new Card(Rank.Three, Suit.Diamonds);
            c.TurnOver();
            Assert.AreEqual("3D", c.ToString());

            c = new Card(Rank.Jack, Suit.Hearts);
            c.TurnOver();
            Assert.AreEqual("JH", c.ToString());
        }

        [TestMethod]
        public void TestCardTurnOver()
        {
            Card c = new Card(Rank.Ace, Suit.Diamonds);
            Assert.AreEqual("**", c.ToString());
            c.TurnOver();
            Assert.AreEqual("AD", c.ToString());
            c.TurnOver();
            Assert.AreEqual("**", c.ToString());

            c = new Card(Rank.Four, Suit.Hearts);
            Assert.AreEqual("**", c.ToString());
            c.TurnOver();
            Assert.AreEqual("4H", c.ToString());
        }
    }
}