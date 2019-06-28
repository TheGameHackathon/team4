using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using thegame.Entity;

namespace thegame.DB
{
    public interface IGameRepository
    {
        void Insert(GameEntity game);
        GameEntity FindById(Guid gameId);
        void Update(GameEntity game);
        void Delete(GameEntity game);
    }
}