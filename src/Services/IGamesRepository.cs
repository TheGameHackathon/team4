using System;
using thegame.Models.Entities;

namespace thegame.Services
{
    public interface IGamesRepository
    {
        Game Insert(Game user);
        Game FindById(Guid id);
        void Update(Game user);
        void UpdateOrInsert(Game user, out bool isInserted);
        void Delete(Guid id);
    }
}