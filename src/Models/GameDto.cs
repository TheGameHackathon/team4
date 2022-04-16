using System;

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

        public CellDto[] Cells { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public bool MonitorKeyboard { get; set; }
        public bool MonitorMouseClicks { get; set; }
        public Guid Id { get; set; }
        public bool IsFinished { get; set; }
        public int Score { get; set; }

        public GameDto MoveDown()
        {
            var cells = new CellDto[Width, Height];
            foreach (var cell in Cells)
            {
                cells[cell.Pos.X, cell.Pos.Y] = cell;
            }


            for (var x = 0; x < Width; x++)
            {
                for (var y = Height - 2; y >= 0; y--)
                {
                    for (var i = y; i < Height - 1 && cells[x, i - 1].Content.Equals("0"); i++)
                    {
                        (cells[x, i], cells[x, i - 1]) = (cells[x, i - 1], cells[x, i]);
                    }
                }
            }

            return this;
        }


        public GameDto MoveUp() => throw new NotImplementedException();
        public GameDto MoveLeft() => throw new NotImplementedException();
        public GameDto MoveRight() => throw new NotImplementedException();
    }
}