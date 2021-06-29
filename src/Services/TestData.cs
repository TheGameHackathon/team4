using System;
using thegame.Models;

namespace thegame.Services
{
    public class TestData
    {
        public static GameDto AGameDto(VectorDto movingObjectPosition)
        {
            var width = 10;
            var height = 8;
            var testCells = new[]
            {
                new CellDto("1", new VectorDto(0, 0), "wall", "", 20),
                new CellDto("2", new VectorDto(1, 0), "wall", "", 20),
                new CellDto("3", new VectorDto(2, 0), "wall", "", 20),
                new CellDto("4", new VectorDto(3, 0), "wall", "", 20),
                new CellDto("6", new VectorDto(4, 0), "wall", "", 20),
                new CellDto("7", new VectorDto(4, 1), "wall", "", 20),
                new CellDto("8", new VectorDto(4, 2), "wall", "", 20),
                new CellDto("9", new VectorDto(4, 3), "wall", "", 20),
                new CellDto("10", new VectorDto(4, 4), "wall", "", 20),
                new CellDto("11", new VectorDto(0,4),  "wall", "", 20),
                new CellDto("12", new VectorDto(1,4),  "wall", "", 20),
                new CellDto("13", new VectorDto(2,4),  "wall", "", 20),
                new CellDto("14", new VectorDto(3,4),  "wall", "", 20),
                new CellDto("15", new VectorDto(4,4),  "wall", "", 20),
                new CellDto("16", new VectorDto(0, 0), "wall", "", 20),
                new CellDto("17", new VectorDto(0, 1), "wall", "", 20),
                new CellDto("18", new VectorDto(0, 2), "wall", "", 20),
                new CellDto("19", new VectorDto(0, 3), "wall", "", 20),
                new CellDto("20", new VectorDto(0, 4), "wall", "", 20),
                
                new CellDto("5", movingObjectPosition, "player", "", 10),
            };
            return new GameDto(testCells, true, false, width, height, Guid.Empty, movingObjectPosition.X == 0, movingObjectPosition.Y);
        }
    }
}