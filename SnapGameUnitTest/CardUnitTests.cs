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
            Card card = new Card(Rank.King.ToString(), Suit.Hearts.ToString());

            Assert.AreEqual(Rank.King.ToString(), card.Suit);
            Assert.AreEqual(Suit.Hearts.ToString(), card.Rank);

            card = new Card(Rank.Two.ToString(), Suit.Diamonds.ToString());

            Assert.AreEqual(Rank.Two.ToString(), card.Suit);
            Assert.AreEqual(Suit.Diamonds.ToString(), card.Rank);
        }
    }
}