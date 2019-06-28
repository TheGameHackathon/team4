using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace thegame.Entity
{
    public class GameEntity
    {
        public Guid Id { get; set; }
        public CardEntity[,] Cards { get; set; }
        public DateTime StarTime { get; set; }
    }
}
