using Microsoft.VisualStudio.TestTools.UnitTesting;
using SnapGame.Entities;

namespace SnapGameUnitTest
{
    [TestClass]
    public class SnapTests
    {
        [TestMethod]
        public void TestSnapCreation()
        {
            Snap s = new Snap();

            Assert.IsTrue(s.CardsRemain);
            Assert.IsNull(s.TopCard);
        }

        [TestMethod]
        public void TestFlipNextCard()
        {
            Snap s = new Snap();

            Assert.IsTrue(s.CardsRemain);
            Assert.IsNull(s.TopCard);

            s.FlipNextCard();

            Assert.IsNotNull(s.TopCard);
        }
    }
}
