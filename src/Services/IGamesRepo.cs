using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using thegame.Models;

namespace thegame.Services
{
    public interface IGamesRepo
    {
        public void AddGame(GameDto gameDto);
        public GameDto GetGameById(Guid id);
    }
}