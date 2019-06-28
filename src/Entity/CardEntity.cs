using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace thegame.Entity
{
    public enum CardStatus
    {
        Open,
        Solved,
        NotSolved
    }
    public class CardEntity
    {
        public CardStatus Status { get; set; }
        public int Id { get; set; }
        public CardEntity(int id,CardStatus status = CardStatus.NotSolved)
        {
            Status = status;
            Id = id;
        }

    }
}
