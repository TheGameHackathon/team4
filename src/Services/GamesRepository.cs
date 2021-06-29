using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using thegame.Models;

namespace thegame.Services
{
    public class GamesRepo : IGamesRepo
    {
        private readonly Dictionary<Guid, GameDto> games;

        public GamesRepo()
        {
            games = new Dictionary<Guid, GameDto>();
        }

        public void AddGame(GameDto gameDto)
        {
            games[gameDto.Id] = gameDto;
        }

        public GameDto GetGameById(Guid gameId)
        {
            return games[gameId];
        }
    }
}