using System;
using System.Linq;
using thegame.Models;

namespace thegame.Services
{
    public class GameService
    {
        private static CellDto GetRandomCell(int id, int x, int y, int colorsCount)
        {
            var colors = new[] {"color0", "color1", "color2", "color3", "color4"}.Take(colorsCount).ToArray();
            var color = colors[new Random().Next(colors.Length)];
            return new CellDto(id.ToString(), new Vec(x, y), color, "", 0);
        }

        public static CellDto[] GetCells(int level)
        {
            var width = 5 * level;
            var height = 3 * level;
            
            var testCells = new CellDto[width * height];
            var id = 0;
            for (var i = 0; i < width; ++i)
            {
                for (var j = 0; j < height; ++j)
                {
                    testCells[id] = GetRandomCell(id, i, j, level + 1);
                    id++;
                }
            }
            return testCells;
        }
    }
}