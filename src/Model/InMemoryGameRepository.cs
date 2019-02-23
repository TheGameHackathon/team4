using System;
using System.Collections.Generic;

namespace thegame.Model
{
    public class InMemoryGameRepository : IGameRepository
    {
        private readonly Dictionary<Guid,Game> entities = new Dictionary<Guid, Game>();
        
        public Game Insert(Game game)
        {
            game.Id = Guid.NewGuid();
            entities.Add(game.Id,game);
            return game;
        }

        public Game FindById(Guid id)
        {
            return entities[id];
        }

        public void Delete(Guid id)
        {
            entities.Remove(id);
        }
    }
}