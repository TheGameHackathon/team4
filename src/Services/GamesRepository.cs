using System;
using System.Collections.Generic;
using thegame.Models.Entities;

namespace thegame.Services
{
    public class GamesRepository : IGamesRepository
    {
        private readonly Dictionary<Guid, Game> _entities = new Dictionary<Guid, Game>();

        public Game Insert(Game game)
        {
            if (game.Id != Guid.Empty)
                throw new InvalidOperationException();

            var id = Guid.NewGuid();
            _entities[id] = game;
            return game;
        }

        public Game FindById(Guid id)
        {
            return _entities.TryGetValue(id, out var entity) ? entity : null;
        }

        public void Update(Game game)
        {
            if (!_entities.ContainsKey(game.Id))
                return;

            _entities[game.Id] = game;
        }

        public void UpdateOrInsert(Game game, out bool isInserted)
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