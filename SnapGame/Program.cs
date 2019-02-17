using System;
using SnapGame.Entities;

namespace SnapGame
{
    class Program
    {
        /// <summary>
        /// Respond to the user input -- with requests affecting myGame
        /// </summary>
        /// <param name="snapGame">The game object to update in response to events.</param>
        private static void HandleUserInput(Snap snapGame)
        {
            //do 
            //{
            //    while (!Console.KeyAvailable)
            //        myGame.FlipNextCard();
            //}
            //while (Console.ReadKey(true).Key != ConsoleKey.Spacebar) ;

            //while (true)
            //{
                snapGame.FlipNextCard();
            //}
        }

        /// <summary>
        /// Draws the game to the Window.
        /// </summary>
        /// <param name="snapGame">The details of the game -- mostly top card and scores.</param>
        private static void DrawGame(Snap snapGame)
        {
            // Draw the top card
            Card top = snapGame.TopCard;

            if (top != null)
            {
                Console.WriteLine("Top Card is " + top.ToString());
                Console.WriteLine("Player 1 score: " + snapGame.Score(0));
                Console.WriteLine("Player 2 score: " + snapGame.Score(1));
                Console.WriteLine(top.CardIndex);
            }
            else
            {
                Console.WriteLine("No card played yet...");
            }
        }

        /// <summary>
        /// Updates the game -- it should flip the cards itself once started!
        /// </summary>
        /// <param name="snapGame">The game to be updated...</param>
        private static void UpdateGame(Snap snapGame)
        {
            snapGame.Update(); // just ask the game to do this...
        }

        static void Main(string[] args)
        {
            Snap snapGame = new Snap();

            while (true)
            {
                HandleUserInput(snapGame);
                DrawGame(snapGame);
                UpdateGame(snapGame);

                
            }

            Console.ReadKey();
        }
    }
}
