using Microsoft.VisualStudio.TestTools.UnitTesting;
using SnapGame.Entities;
using SnapGame.Enums;

namespace SnapGameUnitTest
{
    [TestClass]
    public class CardUnitTests
    {
        [TestMethod]
        public void CheckTwoCardsNamesAreEqual()
        {
            Card card = new Card(Suit.Clubs.ToString(), Rank.Ace.ToString());

            Assert.AreEqual(new Card(Suit.Clubs.ToString(), Rank.Ace.ToString()).CardName, card.CardName);
        }

        [TestMethod]
        public void CheckCardMatching()
        {
            Card card1 = new Card(Suit.Clubs.ToString(), Rank.Ace.ToString());
            Card card2 = new Card(Suit.Diamonds.ToString(), Rank.Ace.ToString());

            Assert.IsTrue(card1.Matching(card2));
        }
    }
}