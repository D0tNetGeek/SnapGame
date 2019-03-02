using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SnapGame.Entities;
using SnapGame.Interfaces;

namespace SnapGameUnitTest
{
    [TestClass]
    public class DeckShufflerTests
    {
        [TestMethod]
        public void SameOrder()
        {
            var randomizer = new Mock<IRandomizer>();
            randomizer.Setup(x => x.Next(0, 2)).Returns(0);
            randomizer.Setup(x => x.Next(0, 1)).Returns(0);
            var deckShuffler = new DeckShuffler(randomizer.Object);
            var a = new Card(null, null);
            var b = new Card(null, null);
            var results = deckShuffler.Shuffle(new[] { a, b });
            Assert.AreEqual(a, results[0]);
            Assert.AreEqual(b, results[1]);
        }

        [TestMethod]
        public void Shuffled()
        {
            var randomizer = new Mock<IRandomizer>();
            randomizer.Setup(x => x.Next(0, 2)).Returns(1);
            randomizer.Setup(x => x.Next(0, 1)).Returns(0);
            var deckShuffler = new DeckShuffler(randomizer.Object);
            var a = new Card(null, null);
            var b = new Card(null, null);
            var results = deckShuffler.Shuffle(new[] { a, b });
            Assert.AreEqual(b, results[0]);
            Assert.AreEqual(a, results[1]);
        }

        [TestMethod]
        public void Null()
        {
            var randomizer = new Mock<IRandomizer>();
            var deckShuffler = new DeckShuffler(randomizer.Object);
            var results = deckShuffler.Shuffle(null);
            Assert.IsNotNull(results);
            Assert.AreEqual(0, results.Count);
        }
    }
}
