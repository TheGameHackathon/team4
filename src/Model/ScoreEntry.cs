using System;
using MongoDB.Bson.Serialization.Attributes;

namespace thegame.Model
{
    public class ScoreEntry
    {
        [BsonId]
        public Guid Id { get; set; }
        
        [BsonElement]
        public string UserLogin { get; set; }
        
        [BsonElement]
        public int Score { get; set; }
        
        [BsonElement]
        public int Fails { get; set; }
    }
}