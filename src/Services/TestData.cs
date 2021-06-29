using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using thegame.Models;

namespace thegame.Services
{
    public class TestData
    {
        public static GameDto AGameDto(VectorDto movingObjectPosition)
        {
            string path = Directory.GetCurrentDirectory() + "/Fields/level0.txt";
            var gameField = GetField(path);

            return new GameDto(gameField.cells, true, true,gameField.size, Guid.Empty, movingObjectPosition.X == 0,
                movingObjectPosition.Y);
        }

        private static (CellDto[] cells, Size size) GetField(string path)
        {
            var sr = new StreamReader(path);
            var field = sr.ReadToEnd();
            var rows = field.Split("\r\n");
            var result = new List<CellDto>();
            var fieldSize = new Size(rows[0].Length, rows.Length);
            
            for (var i = 0; i < rows.Length; i++)
            {
                for (var j = 0; j < rows[i].Length; j++)
                {
                    if (rows[i][j] != ' ')
                        result.Add(new CellDto($"{rows[i].Length * i + j}",
                            new VectorDto(j, i), (CellType) int.Parse(rows[i][j].ToString()), "", 20));
                }
            }

            return (result.ToArray(), fieldSize);
        }
    }
}