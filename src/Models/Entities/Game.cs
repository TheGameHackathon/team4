using System;
using thegame.Models.DTO;

namespace thegame.Models.Entities
{
    public class Game
    {
        public Cell[] Cells { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public Guid Id { get; set; }
        public bool IsFinished { get; set; }
        public int Score { get; set; }
        public Position Player { get; set; }
    }
}