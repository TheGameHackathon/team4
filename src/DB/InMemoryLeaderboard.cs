using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using thegame.Entity;

namespace thegame.DB
{
    public class InMemoryLeaderboard : IGameDatabase
    {
        public void Insert(GameEntity game)
        {
            throw new NotImplementedException();
        }

        public GameEntity FindById(Guid gameId)
        {
            throw new NotImplementedException();
        }

        public void Update(GameEntity game)
        {
            throw new NotImplementedException();
        }

        public void Delete(GameEntity game)
        {
            throw new NotImplementedException();
        }
    }
}