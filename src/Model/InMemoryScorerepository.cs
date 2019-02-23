using System;
using System.Collections.Generic;
using System.Linq;

namespace thegame.Model
{
    public class InMemoryScorerepository: IScoreRepository
    {
        private Dictionary<Guid, ScoreEntry> scores;
        
        public InMemoryScorerepository()
        {
            scores = new Dictionary<Guid, ScoreEntry>();
            for (int i = 0; i < 10; i++)
                Insert(new ScoreEntry {UserLogin = "Anonim " + (10 - i).ToString(), Fails = (10 - i), Score = i * 1000});
        }
        
        public ScoreEntry Insert(ScoreEntry score)
        {
            score.Id = Guid.NewGuid();
            scores.Add(score.Id, score);
            return score;
        }

        public ScoreEntry FindById(Guid id)
        {
            throw new NotImplementedException();
        }

        public ScoreEntry GetOrCreateByLogin(string login)
        {
            throw new NotImplementedException();
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public ScoreEntry[] GetBest(int count)
        {
            return scores.Values.OrderBy(s => s.Score).Take(10).ToArray();
        }
    }
}