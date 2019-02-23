using System;

namespace thegame.Model
{
    public interface IGameRepository
    {
        Game Insert(Game game);
        Game FindById(Guid id);
        void Delete(Guid id);
    }
}