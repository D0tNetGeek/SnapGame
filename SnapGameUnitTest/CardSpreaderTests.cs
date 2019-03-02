using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SnapGame.Entities;
using SnapGame.Interfaces;

namespace SnapGameUnitTest
{
    [TestClass]
    public class CardSpreaderTests
    {
        [TestMethod]
        public void EvenNumberOfPlayers()
        {
            var inputOutputService = new Mock<IInputOutputService>();

            var cardsPlayersA = new List<Card>();
            var cardsPlayersB = new List<Card>();

            var playerAMock = new Mock<IPlayer>();
            playerAMock.SetupGet(x => x.CardsList).Returns(cardsPlayersA);
            var playerA = playerAMock.Object;
            var playerBMock = new Mock<IPlayer>();
            playerBMock.SetupGet(x => x.CardsList).Returns(cardsPlayersB);
            var playerB = playerBMock.Object;

            var cardA = new Card("1", "1");
            var cardB = new Card("2", "2");
            var cardC = new Card("3", "3");
            var cardD = new Card("4", "4");

            var cardSpreader = new CardSpreader(inputOutputService.Object);

            var cards = new List<Card>
            {
                cardA,
                cardB,
                cardC,
                cardD
            };

            var players = new List<IPlayer>
            {
                playerA,
                playerB
            };

            cardSpreader.SpreadCardToPlayer(cards, players);

            Assert.AreEqual(2, cardsPlayersA.Count);
            Assert.AreEqual(cardA, cardsPlayersA[0]);
            Assert.AreEqual(cardC, cardsPlayersA[1]);
            Assert.AreEqual(2, cardsPlayersB.Count);
            Assert.AreEqual(cardB, cardsPlayersB[0]);
            Assert.AreEqual(cardD, cardsPlayersB[1]);
        }

        [TestMethod]
        public void OddNumberOfPlayers()
        {
            var inputOutputService = new Mock<IInputOutputService>();

            var cardsPlayersA = new List<Card>();
            var cardsPlayersB = new List<Card>();
            var cardsPlayersC = new List<Card>();

            var playerAMock = new Mock<IPlayer>();
            playerAMock.SetupGet(x => x.CardsList).Returns(cardsPlayersA);
            var playerA = playerAMock.Object;

            var playerBMock = new Mock<IPlayer>();
            playerBMock.SetupGet(x => x.CardsList).Returns(cardsPlayersB);
            var playerB = playerBMock.Object;

            var playerCMock = new Mock<IPlayer>();
            playerCMock.SetupGet(x => x.CardsList).Returns(cardsPlayersC);
            var playerC = playerCMock.Object;

            var cardA = new Card("1", "1");
            var cardB = new Card("2", "2");
            var cardC = new Card("3", "3");
            var cardD = new Card("4", "4");

            var cardSpreader = new CardSpreader(inputOutputService.Object);

            var cards = new List<Card>
            {
                cardA,
                cardB,
                cardC,
                cardD
            };

            var players = new List<IPlayer>
            {
                playerA,
                playerB,
                playerC
            };

            cardSpreader.SpreadCardToPlayer(cards, players);

            Assert.AreEqual(1, cardsPlayersA.Count);
            Assert.AreEqual(cardA, cardsPlayersA[0]);
            Assert.AreEqual(1, cardsPlayersB.Count);
            Assert.AreEqual(cardB, cardsPlayersB[0]);
            Assert.AreEqual(1, cardsPlayersB.Count);
            Assert.AreEqual(cardC, cardsPlayersC[0]);
        }
    }
}
