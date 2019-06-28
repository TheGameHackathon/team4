using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using thegame.Entity;

namespace thegame.DB
{
    interface IGameDatabase
    {
        GameEntity Insert(GameEntity game);
        GameEntity FindById(Guid gameId);
        void Update(GameEntity game);
    }
}
