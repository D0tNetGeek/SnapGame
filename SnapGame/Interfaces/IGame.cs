﻿using System.Collections.Generic;
using SnapGame.Entities;

namespace SnapGame.Interfaces
{
    public interface IGame
    {
        void Run();
        bool IsFinished();
    }
}
