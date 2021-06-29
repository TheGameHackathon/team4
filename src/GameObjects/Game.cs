using System;
using thegame.Models;

namespace thegame.GameObjects
{
    public class Game
    {
        public Game(ICell[] cells, bool monitorKeyboard, bool monitorMouseClicks, int width, int height, Guid id, bool isFinished, int score)
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

        public ICell[] Cells { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public bool MonitorKeyboard { get; set; }
        public bool MonitorMouseClicks { get; set; }
        public Guid Id { get; set; }
        public bool IsFinished { get; set; }
        public int Score { get; set; }
    }
}