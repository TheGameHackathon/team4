using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace thegame.Models
{
    public class FloodFillGame : GameDto,IFloodFillGame
    {
        private  List<CellDto> currentField = new List<CellDto>();
        public FloodFillGame(CellDto[] cells, bool monitorKeyboard, bool monitorMouseClicks, int width, int height, Guid id, bool isFinished, int score) 
                            : base(cells, monitorKeyboard, monitorMouseClicks, width, height, id, isFinished, score)
        {
            currentField.Add(Cells[0]);
        }

        public void MakeMove(string color)
        {
            FillCurrentField(color);
            ExtendCurrentField();
        }

        private void FillCurrentField(string color)
        {
            foreach (var c in currentField)
            {
                c.Type = color;
            }
        }

        private CellDto[] FindSameColorNeb(CellDto cell)
        {
           return Cells.Where(c => Math.Abs(cell.Pos.X - c.Pos.X) <= 1 && Math.Abs(cell.Pos.X - c.Pos.X) <= 1
                                                                       && Math.Abs(cell.Pos.X - c.Pos.X) != Math.Abs(cell.Pos.Y - c.Pos.Y)
                                                                       && c.Type == cell.Type)
                .ToArray();
        }

        private void ExtendCurrentField()
        {
            CellDto[] currentCells=currentField.ToArray();
            CellDto[] prevCells = new CellDto[0];
            while (currentCells.Length != prevCells.Length)
            {
                prevCells = currentCells;
                currentCells = currentCells.SelectMany(FindSameColorNeb).Union(currentCells).ToArray();
            }
            currentField = currentCells.ToList();
        }
    }
}
