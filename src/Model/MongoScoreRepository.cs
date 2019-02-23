using System;
using MongoDB.Driver;

namespace thegame.Model
{
    public class MongoScoreRepository : IScoreRepository
    {
        private readonly IMongoCollection<ScoreEntry> scoreCollection;
        public const string CollectionName = "users";

        public MongoScoreRepository(IMongoDatabase database)
        {
            scoreCollection = database.GetCollection<ScoreEntry>(CollectionName);
            for (int i = 0; i < 10; i++)
                Insert(new ScoreEntry {UserLogin = "Anonim " + (10 - i).ToString(), Fails = (10 - i), Score = i * 1000});
        }
        
        public ScoreEntry Insert(ScoreEntry score)
        {
            scoreCollection.InsertOne(score);
            return score;
            throw new NotImplementedException();
        }

        public ScoreEntry FindById(Guid id)
        {
            return scoreCollection.Find(s => s.Id == id).FirstOrDefault();
        }

        public ScoreEntry GetOrCreateByLogin(string login)
        {
            var score = scoreCollection.Find(s => s.UserLogin == login).FirstOrDefault();
            return score ?? Insert(new ScoreEntry{UserLogin=login});
        }

        public void Delete(Guid id)
        {
            scoreCollection.DeleteOne(s => s.Id == id);
        }

        public ScoreEntry[] GetBest(int count)
        {
            return scoreCollection.Find(s => true).SortBy(s => s.UserLogin).Limit(count).ToList().ToArray();
        }
    }
}