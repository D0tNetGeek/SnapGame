using System.Collections.Generic;
using SnapGame.Entities;

namespace SnapGame.Interfaces
{
    public interface IDeckInitializer
    {
        List<Card> Initialize();
    }
}
