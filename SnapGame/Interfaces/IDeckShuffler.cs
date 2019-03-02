using System.Collections.Generic;
using SnapGame.Entities;

namespace SnapGame.Interfaces
{
    public interface IDeckShuffler
    {
        List<Card> Shuffle(IEnumerable<Card> inputCards);
    }
}
