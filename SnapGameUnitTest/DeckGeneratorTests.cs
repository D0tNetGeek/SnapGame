using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SnapGame.Entities;

namespace SnapGameUnitTest
{
    [TestClass]
    public class DeckGeneratorTests
    {
        [TestMethod]
        public void Generate()
        {
            var deckGenerator = new DeckGenerator();

            var cards = deckGenerator.Generate();

            Assert.AreEqual(4, cards.Select(x => x.Suit).Distinct().Count());
            Assert.AreEqual(13, cards.Where(x => x.Suit == "Clubs").Select(x => x.Rank).Distinct().Count());
            Assert.AreEqual(13, cards.Where(x => x.Suit == "Diamonds").Select(x => x.Rank).Distinct().Count());
            Assert.AreEqual(13, cards.Where(x => x.Suit == "Hearts").Select(x => x.Rank).Distinct().Count());
            Assert.AreEqual(13, cards.Where(x => x.Suit == "Spades").Select(x => x.Rank).Distinct().Count());
        }
    }
}
