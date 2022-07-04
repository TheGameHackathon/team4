using System;
using System.Collections.Generic;
using thegame.Models.DTO;

namespace thegame.Services
{

    public class MapRepository
    {
        private readonly Dictionary<Guid, Map> GameMaps = new Dictionary<Guid, Map>();

        public void Insert(GameDto gameDto) =>
            GameMaps.Add(gameDto.Id, new Map(gameDto));

        public Map GetMapByGameId(Guid id)
        {
            return GameMaps.TryGetValue(id, out var map) ? map : null;
        }
    }
}