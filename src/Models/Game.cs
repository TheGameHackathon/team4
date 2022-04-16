using System.Linq;

namespace thegame.Models
{
    public static class GameLogic
    {
        public static void MoveDown(this GameDto gameDto)
        {
            for (var x = 0; x < gameDto.Width; x++)
            {
                var col = gameDto.Cells.GetColumn(x);
                 GetOffset(col, OffsetFor.Y, false);
            }
        }


        public static void MoveUp(this GameDto gameDto)
        {
            for (var x = 0; x < gameDto.Width; x++)
            {
                var col = gameDto.Cells.GetColumn(x);
                GetOffset(col, OffsetFor.Y, true);
            }
        }

        public static void MoveLeft(this GameDto gameDto)
        {
            for (var y = 0; y < gameDto.Height; y++)
            {
                var row = gameDto.Cells.GetRow(y);
                GetOffset(row, OffsetFor.X, true);
            }
        }

        public static void MoveRight(this GameDto gameDto)
        {
            for (var y = 0; y < gameDto.Height; y++)
            {
                var row = gameDto.Cells.GetRow(y);
                GetOffset(row, OffsetFor.X, false);
            }
        }

        private static void GetOffset(CellDto[] cells, OffsetFor offset, bool isNeedReverse)
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
                        (cells[j - 1], cells[j]) = (cells[j], cells[j - 1]);
                    }
                }
            }

            if (isNeedReverse)
            {
                cells = cells.Reverse().ToArray();
            }

            cells.Select((a, i) =>
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