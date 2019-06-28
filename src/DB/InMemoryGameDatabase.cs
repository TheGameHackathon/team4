using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using thegame.Entity;

namespace thegame.DB
{
    public class InMemoryGameDatabase : IGameDatabase
    {
        private Dictionary<Guid, GameEntity> entities = new Dictionary<Guid, GameEntity>();
        public void Insert(GameEntity game)
        {
            if (game.Id == Guid.Empty)
                throw new Exception("Can't add game with empty id to database");
            entities[game.Id] = game;
        }

        public GameEntity FindById(Guid gameId)
        {
            if (entities.ContainsKey(gameId))
                return entities[gameId];
            throw new Exception("No games with that id found");
        }

        public void Update(GameEntity game)
        {
            if (!entities.ContainsKey(game.Id))
                throw new Exception("Can't update, game is not exist");
            entities[game.Id] = game;
        }

        public void Delete(GameEntity game)
        {
            if (!entities.ContainsKey(game.Id))
                throw new Exception("Can't delete, game is not exist");
            entities.Remove(game.Id);
        }
    }
}
