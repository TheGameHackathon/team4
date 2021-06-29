using System;
using System.Drawing;
using thegame.Models;

namespace thegame.GameObjects
{
    public class Game
    {
        public Game(ICell[] cells, bool monitorKeyboard, bool monitorMouseClicks, Size size, Guid id, bool isFinished, int score)
        {
            Cells = cells;
            MonitorKeyboard = monitorKeyboard;
            MonitorMouseClicks = monitorMouseClicks;
            Width = size.Width;
            Height = size.Height;
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