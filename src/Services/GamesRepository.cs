using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using thegame.Models;

namespace thegame.Services
{
    public static class GamesRepo
    {
        private static IDictionary<Guid, GameDto> games = new ConcurrentDictionary<Guid, GameDto>();

        public static GameDto GetGame(Guid id) => games[id];

        public static GameDto GetOrCreate(Guid id)
        {
            if (games.TryGetValue(id, out var game))
            {
                return game;
            }
            else
            {
                var game1 = TestData.AGameDto(new VectorDto(1, 1));
                games[id] = game1;
                return game1;
            }
        }
        public static void AddOrUpdate(Guid id, GameDto game) => games[id] = game;
    }
}