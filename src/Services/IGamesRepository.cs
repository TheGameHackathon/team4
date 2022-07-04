using System;
using thegame.Models.DTO;
using thegame.Models.Entities;

namespace thegame.Services
{
    public interface IGamesRepository
    {
        GameDto Insert(GameDto game);
        GameDto FindById(Guid id);
        void Update(GameDto game);
        void UpdateOrInsert(GameDto game, out bool isInserted);
        void Delete(Guid id);
    }
}