using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SnapGame.Entities;
using SnapGame.Interfaces;

namespace SnapGameUnitTest
{
    [TestClass]
    public class PlayerTests
    {
        [TestMethod]
        public void ShowCards()
        {
            var service = new Mock<IInputOutputService>();

            var player = new Player(service.Object, "a");

            player.CardsList.Add(new Card("a", "a"));
            player.CardsList.Add(new Card("b", "b"));

            player.ShowCards();

            service.Verify(
                x => x.WriteLine($"a has [{player.CardsList[0].CardName}, {player.CardsList[1].CardName}]\n"),
                Times.Once());
        }
    }
}