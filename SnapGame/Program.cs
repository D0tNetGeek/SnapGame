using System;
using SnapGame.Entities;

namespace SnapGame
{
    class Program
    {
        static void Main(string[] args)
        {
            /**
             * Here are the rules of the game:
             * Two players are dealt the same number of cards from a shuffled deck.
             * Each player takes it in turns to place their next card on a pile between them.
             * If the two top cards on the pile match in numeric value (e.g. Queen == Queen), the last player
             * to place a card takes all the cards in the pile.
             *
             * The game continues until one player is out of cards.
             */

            Console.Write("How many players are there : ");
            int numberOfPlayers = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
            string[] namesOfPlayers = new string[numberOfPlayers];

            for (int i = 0; i < numberOfPlayers; i++)
            {
                Console.Write("\nEnter Player" + (i + 1) + " Name: ");
                namesOfPlayers[i] = Console.ReadLine();
            }

            Console.Write("\nShuffling Cards\n");

            var consoleService = new ConsoleService();
            Game game = new Game(consoleService,
                new DeckInitializer(new DeckGenerator(), new DeckShuffler(new Randomizer())),
                new CardSpreader(consoleService),
                namesOfPlayers);

            game.Run();

            Console.ReadKey();
        }
    }
}
