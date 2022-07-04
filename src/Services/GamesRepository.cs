using System;
using System.Collections.Generic;
using thegame.Models.DTO;
using thegame.Models.Entities;

namespace thegame.Services
{
    public class GamesRepository : IGamesRepository
    {
        private readonly Dictionary<Guid, GameDto> _entities = new Dictionary<Guid, GameDto>();

        public GameDto Insert(GameDto game)
        {
            var id = Guid.NewGuid();
            _entities.Add(id, game);
            game.Id = id;
            return game;
        }

        public GameDto FindById(Guid id)
        {
            return _entities.TryGetValue(id, out var entity) ? entity : null;
        }

        public void Update(GameDto game)
        {
            if (!_entities.ContainsKey(game.Id))
                return;

            _entities[game.Id] = game;
        }

        public void UpdateOrInsert(GameDto game, out bool isInserted)
        {
            if (game.Id == Guid.Empty)
                throw new InvalidOperationException();

            var id = game.Id;
            if (_entities.ContainsKey(id))
            {
                _entities[id] = game;
                isInserted = false;
                return;
            }

            var entity = game;
            _entities[id] = entity;
            isInserted = true;
        }

        public void Delete(Guid id)
        {
            _entities.Remove(id);
        }
    }
}