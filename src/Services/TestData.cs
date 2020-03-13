using System;
using thegame.Models;

namespace thegame.Services
{
    public class TestData
    {
        public static GameDto AGameDto(Vec movingObjectPosition)
        {
            var width = 4;
            var height = 4;
            var testCells = new CellDto[16];

            int k = 0;
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    testCells[k] = new CellDto("1", new Vec(i, j), "tile-2 game2048 field td", "2", 20);
                    k++;
                }
            }

            return new GameDto(testCells, true, true, width, height, Guid.Empty, movingObjectPosition.X == 0,
                movingObjectPosition.Y);
        }
    }
}