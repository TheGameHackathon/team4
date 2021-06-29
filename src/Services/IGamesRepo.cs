using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using thegame.GameObjects;
using thegame.Models;

namespace thegame.Services
{
    public interface IGamesRepo
    {
        public void AddGame(Game gameDto);
        public Game GetGameById(Guid id);
    }
}