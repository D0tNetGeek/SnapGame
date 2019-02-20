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
             * If the two top cards on the pile match in numeric value (e.g. 9 == 9), the last player
             * to place a card takes all the cards in the pile.
             *
             * The game continues until one player is out of cards.
             */


            //Game game = new Game();
            //game.AddPlayer(new Player("Player1"));
            //game.AddPlayer(new Player("Player2"));

            //Deck.DealCards(game.GetPlayers());

            //game.Play();
            //var messages = game.GetMessages();

            //messages.ForEach(message => Console.WriteLine(message));

            Game game = new Game(new List<string>{"Player1", "Player2"});

            game.Initialize();
            game.Run();

            Console.Read();
        }
        ///// <summary>
        ///// Respond to the user input -- with requests affecting myGame
        ///// </summary>
        ///// <param name="snapGame">The game object to update in response to events.</param>
        //private static void HandleUserInput(Snap snapGame)
        //{
        //    Deck deck = new Deck();

        //    deck.Shuffle();

        //    do
        //    {
        //        while (!Console.KeyAvailable)
        //            deck.Draw();
        //        //snapGame.FlipNextCard();
        //    }
        //    while (Console.ReadKey(true).Key != ConsoleKey.Spacebar);
        //}

        ///// <summary>
        ///// Draws the game to the Window.
        ///// </summary>
        ///// <param name="snapGame">The details of the game -- mostly top card and scores.</param>
        //private static void DrawGame(Snap snapGame)
        //{
        //    // Draw the top card
        //    Card top = snapGame.TopCard;

        //    if (top != null)
        //    {
        //        Console.WriteLine("Top Card is " + top.ToString());
        //        Console.WriteLine("Player 1 score: " + snapGame.Score(0));
        //        Console.WriteLine("Player 2 score: " + snapGame.Score(1));
        //        Console.WriteLine(top.CardIndex);
        //    }
        //    else
        //    {
        //        Console.WriteLine("No card played yet...");
        //    }
        //}

        ///// <summary>
        ///// Updates the game -- it should flip the cards itself once started!
        ///// </summary>
        ///// <param name="snapGame">The game to be updated...</param>
        //private static void UpdateGame(Snap snapGame)
        //{
        //    snapGame.Update(); // just ask the game to do this...
        //}

        //static void Main(string[] args)
        //{
        //    Snap snapGame = new Snap();

        //    while (true)
        //    {
        //        HandleUserInput(snapGame);
        //        DrawGame(snapGame);
        //        UpdateGame(snapGame);

                
        //    }

        //    Console.ReadKey();
        //}
    }
}
