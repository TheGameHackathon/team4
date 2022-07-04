using System;
using thegame.Models.Entities;

namespace thegame.Services
{

    public class GamesRepository : IGamesRepository
    {
        public Game Insert(Game user)
        {
            throw new NotImplementedException();
        }

        public Game FindById(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Update(Game user)
        {
            throw new NotImplementedException();
        }

        public void UpdateOrInsert(Game user, out bool isInserted)
        {
            throw new NotImplementedException();
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}