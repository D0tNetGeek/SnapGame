namespace SnapGame.Interfaces
{
    public interface IGame
    {
        void Initialize();
        void Shuffle();
        void Deal();
        void Run();
        bool AllSkipped();
    }
}
