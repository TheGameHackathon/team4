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
            for (var x = 0; x < Width; x++)
            {
                var col = Cells.GetColumn(x);
                var ofseted = GetOffset(col, OffsetFor.Y, false);
            }

            return this;
        }


        public GameDto MoveUp()
        {
            for (var x = 0; x < Width; x++)
            {
                var col = Cells.GetColumn(x);
                GetOffset(col, OffsetFor.Y, true);
            }
            return this;
        }

        public GameDto MoveLeft()
        {
            for (var y = 0; y < Height; y++)
            {
                var row = Cells.GetRow(y);
                GetOffset(row, OffsetFor.X, true);
            }

            return this;
        }

        public GameDto MoveRight()
        {
            
            for (var y = 0; y < Height; y++)
            {
                var row = Cells.GetRow(y);
                GetOffset(row, OffsetFor.X, false);
            }

            return this;
        }
        public CellDto[] GetOffset(CellDto[] cells, OffsetFor offset, bool isNeedReverse)
        {
            if (isNeedReverse)
            {
                cells = cells.Reverse().ToArray();
            }

            for (var i = cells.Length - 2; i >= 0; i--)
            {
                if (cells[i].Content.Equals("0")) continue;

                for (var j = i + 1; j < cells.Length; j++)
                {
                    if (cells[j].Content.Equals("0"))
                    {
                        (cells[j-1], cells[j]) = (cells[j], cells[j-1]);
                    }
                }
            }

            if (isNeedReverse)
            {
                cells = cells.Reverse().ToArray();
            }

            return cells.Select((a, i) =>
            {
                var pos = offset == OffsetFor.X
                    ? new VectorDto(i, a.Pos.Y)
                    : new VectorDto(a.Pos.X, i);
                a.Pos = pos;
                return a;
            }).ToArray();
        }

       
    }
}