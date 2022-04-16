using System;
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
            gameDto.Cells.GenerateCeil();

        }


        public static void MoveUp(this GameDto gameDto)
        {
            for (var x = 0; x < gameDto.Width; x++)
            {
                var col = gameDto.Cells.GetColumn(x);
                GetOffset(col, OffsetFor.Y, true);
            }
            gameDto.Cells.GenerateCeil();

        }

        public static void MoveLeft(this GameDto gameDto)
        {
            for (var y = 0; y < gameDto.Height; y++)
            {
                var row = gameDto.Cells.GetRow(y);
                GetOffset(row, OffsetFor.X, true);
            }
            gameDto.Cells.GenerateCeil();

        }

        public static void MoveRight(this GameDto gameDto)
        {
            for (var y = 0; y < gameDto.Height; y++)
            {
                var row = gameDto.Cells.GetRow(y);
                GetOffset(row, OffsetFor.X, false);
            }
            gameDto.Cells.GenerateCeil();
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
                    else
                    {
                        var first = int.Parse(cells[j - 1].Content);
                        var second = int.Parse(cells[j].Content);
                        if (first == second)
                        {
                            cells[j - 1].Content = "0";
                            cells[j].Content = (first + second).ToString();
                        }
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

        private static void GenerateCeil(this CellDto[] res)
        {
            var emptyCeils = res.Where(c => c.Content.Equals("0")).ToArray();
            var index = new Random().Next(0, emptyCeils.Length - 1);
            emptyCeils[index].Content = GetRandomNum();
        }

        private static string GetRandomNum()
        {
            var rndInt = new Random().Next(0, 100);
            if (rndInt <= 20) return "4";

            return "2";
        }
    }
}