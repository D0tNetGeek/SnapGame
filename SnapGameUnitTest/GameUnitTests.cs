using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SnapGame.Entities;
using SnapGame.Interfaces;

namespace SnapGameUnitTest
{
    [TestClass]
    public class GameUnitTests
    {
        [TestMethod]
        public void NoSnap()
        {
            var inputService = new Mock<IInputOutputService>();

            inputService.Setup(x => x.ReadLine()).Returns("");

            var deckInitializer = new Mock<IDeckInitializer>();

            var cards = new List<Card>
                           {
                               new Card("a", "a"),
                               new Card("b", "b"),
                               new Card("c", "c"),
                               new Card("d", "d"),
                           };

            deckInitializer.Setup(x => x.Initialize())
                           .Returns(cards);

            var cardSpreader = new Mock<ICardSpreader>();

            cardSpreader.Setup(x => x.SpreadCardToPlayer(cards, It.IsAny<List<IPlayer>>()))
                        .Callback<List<Card>, List<IPlayer>>((c, p) =>
                        {
                            p[0].CardsList.Add(cards[0]);
                            p[0].CardsList.Add(cards[2]);
                            p[1].CardsList.Add(cards[1]);
                            p[1].CardsList.Add(cards[3]);
                        });

            var playerNames = new[] { "a", "b" };

            var game = new Game(inputService.Object,
                                deckInitializer.Object,
                                cardSpreader.Object,
                                playerNames);

            game.Run();

            inputService.Verify(x => x.WriteLine("SNAP !!\n"), Times.Never());
            inputService.Verify(x => x.WriteLine("b has WON !!\n"), Times.Once());
            inputService.Verify(x => x.WriteLine("a has WON !!\n"), Times.Never());
        }

        [TestMethod]
        public void Snap()
        {
            var inputService = new Mock<IInputOutputService>();

            inputService.Setup(x => x.ReadLine()).Returns("");

            var deckInitializer = new Mock<IDeckInitializer>();

            var cards = new List<Card>
                           {
                               new Card("a", "d"),
                               new Card("b", "b"),
                               new Card("c", "c"),
                               new Card("d", "d"),
                           };

            deckInitializer.Setup(x => x.Initialize())
                           .Returns(cards);

            var cardSpreader = new Mock<ICardSpreader>();

            cardSpreader.Setup(x => x.SpreadCardToPlayer(cards, It.IsAny<List<IPlayer>>()))
                        .Callback<List<Card>, List<IPlayer>>((c, p) =>
                        {
                            p[0].CardsList.Add(cards[0]);
                            p[0].CardsList.Add(cards[2]);
                            p[1].CardsList.Add(cards[1]);
                            p[1].CardsList.Add(cards[3]);
                        });

            var playerNames = new[] { "a", "b" };

            var game = new Game(inputService.Object,
                                deckInitializer.Object,
                                cardSpreader.Object,
                                playerNames);

            game.Run();

            inputService.Verify(x => x.WriteLine("SNAP !!\n"), Times.Once());
            inputService.Verify(x => x.WriteLine("a has WON !!\n"), Times.Once());
            inputService.Verify(x => x.WriteLine("b has WON !!\n"), Times.Never());
        }
    }
}
