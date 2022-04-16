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

        public static void AddOrUpdate(Guid id, GameDto game) => games[id] = game;
    }
}