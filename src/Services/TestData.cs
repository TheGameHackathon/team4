using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using thegame.GameObjects;
using thegame.Models;

namespace thegame.Services
{
    public class TestData
    {
        private static Dictionary<int, string> levels = new();

        static TestData()
        {
            levels.Add(1, "0400000\n00    0\n03 0  0\n02  1 0\n0000000\n");
        }

        public static Game AGame(VectorDto movingObjectPosition)
        {
            var gameField = GetField(1);

            return new Game(gameField.cells, true, false, gameField.size, Guid.NewGuid(), movingObjectPosition.X == 0,
                movingObjectPosition.Y);
        }


        private static (ICell[] cells, Size size) GetField(int level)
        {
            var field = levels[level];
            var rows = field.Split("\n");

            var result = new List<ICell>();

            var fieldSize = new Size(rows[0].Length, rows.Length);
            
            for (var i = 0; i < rows.Length; i++)
            {
                for (var j = 0; j < rows[i].Length; j++)
                {
                    if (rows[i][j] != ' ')
                        result.Add(new Cell($"{rows[i].Length * i + j}",
                            new VectorDto(j, i), (CellType) int.Parse(rows[i][j].ToString()), "", 20));
                }
            }

            return (result.ToArray(), fieldSize);
        }
    }
}