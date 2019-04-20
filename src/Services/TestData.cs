using System;
using thegame.Models;

namespace thegame.Services
{
    public class TestData
    {
        public static GameDto AGameDto(Vec movingObjectPosition)
        {
            var width = 10;
            var height = 8;
            var testCells = new CellDto[width * height];
            var id = 0;
            for (var i = 0; i < width; ++i)
            {
                for (var j = 0; j < height; ++j)
                {
                    testCells[id] = GetRandomCell(id, i, j);
                    id++;
                }
            }
            return new GameDto(testCells, true, true, width, height, Guid.Empty, movingObjectPosition.X == 0, movingObjectPosition.Y);
        }

        private static CellDto GetRandomCell(int id, int x, int y)
        {
            var colors = new[] {"color0", "color1", "color2", "color3", "color4"};
            var color = colors[new Random().Next(colors.Length)];
            return new CellDto(id.ToString(), new Vec(x, y), color, "", 0);
        }
    }
}