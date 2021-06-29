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
        public static Dictionary<int, string> levels = new();
        public static int selectedLevel;

        static TestData()
        {
            levels.Add(0, "00000\n01  0\n0 2 0\n0 3 0\n00000\n");
            levels.Add(1, "000000\n01 230\n0  2 0\n0  3 0\n000000\n");
        }

        public static Game AGame(VectorDto movingObjectPosition, int level = 0, int score = 0)
        {
            var gameField = GetField(level);

            return new Game(gameField.cells, true, false, gameField.size, Guid.NewGuid(), movingObjectPosition.X == 0, score);
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