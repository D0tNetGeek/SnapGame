namespace SnapGame.Interfaces
{
    public interface ISnap
    {
        /// <summary>
        /// Start the Snap game playing!
        /// </summary>
        void Start();

        /// <summary>
        /// Flip the next card!
        /// </summary>
        void FlipNextCard();

        /// <summary>
        /// Update the game. This should be called in the Game loop to enable
        /// the game to update its internal state.
        /// </summary>
        void Update();

        /// <summary>
        /// Gets the player's score.
        /// </summary>
        /// <value>The score.</value>
        int Score(int idx);

        /// <summary>
        /// The player hit the top of the cards "snap"! :)
        /// Check if the top two cards' ranks match.
        /// </summary>
        void PlayerHit(int player);
    }
}
