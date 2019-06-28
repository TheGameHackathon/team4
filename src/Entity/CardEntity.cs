using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace thegame.Entity
{
    public enum CardStatus
    {
        Open,
        Closed,
        Solved,
        NotSolved
    }
    public class CardEntity
    {
        public CardStatus Status { get; set; }
        public CardEntity(CardStatus status)
        {
            Status = status;
        }

    }
}
