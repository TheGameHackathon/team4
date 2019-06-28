using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using thegame.Entity;

namespace thegame.DB
{
    interface ILeaderboard
    {
        UserEntity Insert(UserEntity user);
        UserEntity FindById(Guid id);
        void Update(UserEntity user);
        List<UserEntity> GetLeaderboard();
    }
}
