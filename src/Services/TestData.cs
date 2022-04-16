using System;
using thegame.Models;

namespace thegame.Services
{
    public class TestData
    {
        private static Random rand = new Random();
        
        public static GameDto AGameDto(VectorDto movingObjectPosition)
        {
            var width = 4;
            var height = 4;
            var testCells = new CellDto[width * height];
            
            for (var i = 0; i < width; i++)
            for (var j = 0; j < height; j++)
                testCells[i * width + j] = GenerateNewCell(i, j);
            
            return new GameDto(testCells, true, true, width, height, Guid.Empty, movingObjectPosition.X == 0, movingObjectPosition.Y);
        }

        private static CellDto GenerateNewCell(int x, int y)
        {
            var perCent = rand.Next(0, 100);
            
            if (perCent > 80)
                return new CellDto($"{x * 4 + y}", new VectorDto(x,y), "tile-4", "4", 0);
            
            if (perCent > 20)
                return new CellDto($"{x * 4 + y}", new VectorDto(x,y), "tile-2", "2", 0);
            
            return new CellDto($"{x * 4 + y}", new VectorDto(x,y), "tile-0", "0", 0);
        }
    }
}