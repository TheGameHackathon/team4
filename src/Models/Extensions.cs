using System;
using System.Collections.Generic;
using System.Linq;

namespace thegame.Models
{
    public static class Extensions
    {
        public static CellDto[] GetRow(this CellDto[] cells, int rowIndex)
        {
            return cells
                .Where(cell => cell.Pos.Y == rowIndex)
                .OrderBy(cell => cell.Pos.Y)
                .ToArray();
        }

        public static CellDto[] GetColumn(this CellDto[] cells, int colIndex)
        {
            return cells
                .Where(cell => cell.Pos.X == colIndex)
                .OrderBy(cell => cell.Pos.X)
                .ToArray();
        }

        public static void SetCells(this CellDto[] cells, IEnumerable<CellDto> newCells)
        {
            foreach (var newCell in newCells)
            {
                var oldCell = cells.First(cell => cell.Pos.Equals(newCell.Pos));
                cells[Array.IndexOf(cells, oldCell)] = newCell;
            }
        }
    }
}
