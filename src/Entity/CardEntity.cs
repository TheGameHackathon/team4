using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using thegame.Models.Dto;

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
        public int Id { get; set; }

        public CardStatus Status { get; set; }

        public PointDto Position { get; set; }

        public CardEntity(int id, CardStatus status = CardStatus.NotSolved)
        {
            Status = status;
            Id = id;
        }
    }
}