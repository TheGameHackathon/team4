using System;
using System.Collections.Generic;
using System.Linq;

namespace thegame.Models
{
    public class GameDto
    {
        public GameDto(CellDto[] cells, bool monitorKeyboard, bool monitorMouseClicks, int width, int height, Guid id,
            bool isFinished, int score)
        {
            Cells = cells;
            MonitorKeyboard = monitorKeyboard;
            MonitorMouseClicks = monitorMouseClicks;
            Width = width;
            Height = height;
            Id = id;
            IsFinished = isFinished;
            Score = score;
        }

        public CellDto[] Cells { get; }
        public int Width { get; }
        public int Height { get; }
        public bool MonitorKeyboard { get; set; }
        public bool MonitorMouseClicks { get; set; }
        public Guid Id { get; set; }
        public bool IsFinished { get; set; }
        public int Score { get; set; }
    }
}