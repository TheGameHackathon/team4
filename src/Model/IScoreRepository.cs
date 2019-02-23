using System;

namespace thegame.Model
{
    public interface IScoreRepository
    {
        ScoreEntry Insert(ScoreEntry score);
        ScoreEntry FindById(Guid id);
        ScoreEntry GetOrCreateByLogin(string login);
        void Delete(Guid id);
        ScoreEntry[] GetBest(int count);
    }
}