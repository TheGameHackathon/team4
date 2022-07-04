using System;
using thegame.Models.Entities;

namespace thegame.Services
{



    public interface IGamesRepository
    {
        Game Insert(Game game);
        Game FindById(Guid id);
        void Update(Game game);
        void UpdateOrInsert(Game game, out bool isInserted);
        void Delete(Guid id);
    }
}