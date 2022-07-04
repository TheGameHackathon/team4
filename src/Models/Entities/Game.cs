using System;
using thegame.Models.DTO;

namespace thegame.Models.Entities
{
    public class Game
    {
        public Game(CellDto[] cells, int width, int height, Guid id, bool isFinished, int score)
        {
            Cells = cells;
            Width = width;
            Height = height;
            Id = id;
            IsFinished = isFinished;
            Score = score;
        }

        public CellDto[] Cells { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public Guid Id { get; set; }
        public bool IsFinished { get; set; }
        public int Score { get; set; }
    }
}