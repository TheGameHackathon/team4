using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using thegame.GameObjects;
using thegame.Models;

namespace thegame.Services
{
    public class GamesRepo : IGamesRepo
    {
        private readonly Dictionary<Guid, Game> games;

        public GamesRepo()
        {
            games = new Dictionary<Guid, Game>();
        }

        public void AddGame(Game gameDto)
        {
            games[gameDto.Id] = gameDto;
        }

        public Game GetGameById(Guid gameId)
        {
            return games[gameId];
        }
    }
}