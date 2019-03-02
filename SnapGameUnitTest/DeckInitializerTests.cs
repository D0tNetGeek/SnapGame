using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SnapGame.Entities;
using SnapGame.Interfaces;

namespace SnapGameUnitTest
{
    [TestClass]
    public class DeckInitializerTests
    {
        [TestMethod]
        public void InitializeDeck()
        {
            var deckGenerator = new Mock<IDeckGenerator>();

            var a = new List<Card>();
            var b = new List<Card>();

            deckGenerator.Setup(x => x.Generate()).Returns(a);

            var deckShuffler = new Mock<IDeckShuffler>();

            deckShuffler.Setup(x => x.Shuffle(a)).Returns(b);

            var deckInitializer = new DeckInitializer(deckGenerator.Object, deckShuffler.Object);

            var result = deckInitializer.Initialize();

            Assert.AreEqual(b, result);
        }
    }
}
