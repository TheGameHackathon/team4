using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using thegame.Entity;

namespace thegame.DB
{
    public class InMemoryLeaderboardRepository : ILeaderboardRepository
    {
        public UserEntity Insert(UserEntity user)
        {
            throw new NotImplementedException();
        }

        public UserEntity FindById(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Update(UserEntity user)
        {
            throw new NotImplementedException();
        }

        public List<UserEntity> GetLeaderboard()
        {
            throw new NotImplementedException();
        }
    }
}