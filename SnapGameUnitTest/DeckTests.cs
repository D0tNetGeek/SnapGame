using Microsoft.VisualStudio.TestTools.UnitTesting;
using SnapGame.Entities;
using SnapGame.Enums;

namespace SnapGameUnitTest
{
    [TestClass]
    public class DeckTests
    {
        [TestMethod]
        public void TestDeckCreation()
        {
            Deck d = new Deck();

            Assert.AreEqual(52, d.CardsRemaining);
        }

        [TestMethod]
        public void TestDraw()
        {
            Deck d = new Deck();

            Assert.AreEqual(52, d.CardsRemaining);

            Card c = d.Draw();

            Assert.AreEqual(51, d.CardsRemaining);
            Assert.AreEqual(Rank.Ace, c.Rank);
            Assert.AreEqual(Suit.Clubs, c.Suit);

            int count = 51;

            // Draw all cards from the deck 
            while (d.CardsRemaining > 0)
            {
                c = d.Draw();
                count--;

                Assert.AreEqual(count, d.CardsRemaining);
            }

        }
    }

}
