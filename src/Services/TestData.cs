using System;
using System.Collections.Generic;
using thegame.Models;
using thegame.Models.DTO;

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
                new CellDto("1", new VectorDto(x: 2, y: 4), "wall", "", 0),
                new CellDto("2", new VectorDto(x: 5, y: 4), "color1", "", 0),
                new CellDto("3", new VectorDto(x: 3, y: 1), "color2", "", 20),
                new CellDto("4", new VectorDto(x: 1, y: 0), "color2", "", 20),
                new CellDto("5", movingObjectPosition, "color4", "☺", 10),
            };
            return new GameDto(testCells, true, true, width, height, Guid.Empty, movingObjectPosition.X == 0,
                movingObjectPosition.Y);
        }
        
        public static GameDto FirstLevel()
        {
            var width = 8;
            var height = 9;
            var cells = new List<CellDto>();
            for (int i = 0; i < width; i++)
            {
                cells.Add(
                    new CellDto($"td_{i}_0", new VectorDto(x: i, y: 0), "wall", "", 0)
                );
                cells.Add(
                    new CellDto($"td_{i}_{height - 1}", new VectorDto(x: i, y: height - 1), "wall", "", 0)
                );
            }

            for (int i = 0; i < height; i++)
            {
                cells.Add(
                    new CellDto($"td_0_{i}", new VectorDto(x: 0, y: i), "wall", "", 0)
                );
                cells.Add(
                    new CellDto($"td_{width - 1}_{i}", new VectorDto(x: width - 1, y: i), "wall", "", 0)
                );
            }

            return new GameDto(cells.ToArray(), true, false, width, height, Guid.Empty, false, 0);
        }
    }
}