using System.Collections.Generic;
using SnapGame.Entities;

namespace SnapGame.Interfaces
{
    public interface IDeckGenerator
    {
        List<Card> Generate();
    }
}
