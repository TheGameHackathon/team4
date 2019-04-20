using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace thegame.Models
{
    public class FloodFillGame : GameDto,IFloodFillGame
    {
        private  List<CellDto> currentField = new List<CellDto>();
        public FloodFillGame(CellDto[] cells, bool monitorKeyboard, bool monitorMouseClicks, int width, int height, Guid id, bool isFinished, int score) 
                            : base(cells, monitorKeyboard, monitorMouseClicks, width, height, id, isFinished, score)
        {
            currentField.Add(Cells[0]);
            ExtendCurrentField();
        }

        public void MakeMove(string color)
        {
            if (!IsFinished)
            {
                 FillCurrentField(color);
                 ExtendCurrentField();
                 Score++;
            }
            if (currentField.Count==(Height*Width))
            {
                IsFinished = true;
            }
        }

        public void MakeBestMove()
        {
            var colors = new Dictionary<string, int>()
            {
                ["color0"] = 0,
                ["color1"] = 0,
                ["color2"] = 0,
                ["color3"] = 0,
                ["color4"] = 0
            };
            var currentColor = currentField[0].Type;
            foreach (var cell in currentField)
            {
                foreach (var neighbour in GetAllNeighbours(cell))
                {
                    if (neighbour.Type != currentColor)
                    {
                        colors[neighbour.Type]++;
                    }
                }
            }

            var bestColor = colors.Aggregate((l, r) => l.Value > r.Value ? l : r).Key;
            MakeMove(bestColor);
        }

        private CellDto[] GetAllNeighbours(CellDto cell) =>
            Cells.Where(c =>
                Math.Abs(cell.Pos.X - c.Pos.X) <= 1
                && Math.Abs(cell.Pos.Y - c.Pos.Y) <= 1
                && Math.Abs(cell.Pos.X - c.Pos.X) !=
                Math.Abs(cell.Pos.Y - c.Pos.Y)).ToArray();

        private void FillCurrentField(string color)
        {
            foreach (var c in currentField)
            {
                c.Type = color;
            }
        }

        private CellDto[] GetAllSameColorNeighbours(CellDto cell)
            => GetAllNeighbours(cell).Where(c => c.Type == cell.Type)
                .ToArray();

        private void ExtendCurrentField()
        {
            CellDto[] currentCells=currentField.ToArray();
            CellDto[] prevCells = new CellDto[0];
            while (currentCells.Length != prevCells.Length)
            {
                prevCells = currentCells;
                currentCells = currentCells.SelectMany(GetAllSameColorNeighbours).Union(currentCells).ToArray();
            }
            currentField = currentCells.ToList();
        }
    }
}
