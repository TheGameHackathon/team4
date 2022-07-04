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
                new CellDto("1", new VectorDto {X = 2, Y = 4}, "wall", "", 0),
                new CellDto("2", new VectorDto {X = 5, Y = 4}, "color1", "", 0),
                new CellDto("3", new VectorDto {X = 3, Y = 1}, "color2", "", 20),
                new CellDto("4", new VectorDto {X = 1, Y = 0}, "color2", "", 20),
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
                    new CellDto($"td_{i}_0", new VectorDto {X = i, Y = 0}, "wall", "", 0)
                );
                cells.Add(
                    new CellDto($"td_{i}_{height - 1}", new VectorDto {X = i, Y = height - 1}, "wall", "", 0)
                );
            }

            for (int i = 0; i < height; i++)
            {
                cells.Add(
                    new CellDto($"td_0_{i}", new VectorDto {X = 0, Y = i}, "wall", "", 0)
                );
                cells.Add(
                    new CellDto($"td_{width - 1}_{i}", new VectorDto {X = width - 1, Y = i}, "wall", "", 0)
                );
            }

            return new GameDto(cells.ToArray(), true, false, width, height, Guid.Empty, false, 0);
        }
    }
}