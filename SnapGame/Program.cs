using System;
using System.Collections.Generic;
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

            Game game = new Game(new List<string>{"Player1", "Player2"});

            game.Initialize();
            game.Run();

            Console.Read();
        }
    }
}
