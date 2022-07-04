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
            var walls = new bool[9, 8]
            {
                {false, false, true, true, true, true, true, false},
                {true, true, true, false, false, false, true, false},
                {true, false, false, false, false, false, true, false},
                {true, true, true, false, false, false, true, false},
                {true, false, true, true, false, false, true, false},
                {true, false, true, false, false, false, true, true},
                {true, false, false, false, false, false, false, true},
                {true, false, false, false, false, false, false, true},
                {true, true, true, true, true, true, true, true}
            };
            var cells = new List<CellDto>();
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (walls[i, j])
                    {
                        cells.Add(new CellDto($"wall_{j}_{i}", new VectorDto(){X = j, Y = i}, "wall", "", 10));
                    }
                }
            }
            
            var boxes = new [] {(3, 2), (4, 3), (4, 4), (1, 6), (3, 6), (4, 6), (5, 6)};
            var targets = new[] {(1, 2), (5, 3), (1, 4), (4, 5), (4, 7), (6, 6)};
            foreach (var (x, y) in targets)
            {
                cells.Add(new CellDto($"target_{x}_{y}", new VectorDto(){X = x, Y = y}, "target", "", 0));
            }
            for (int i = 0; i < boxes.Length; i++)
            {
                var (x, y) = boxes[i];
                cells.Add(new CellDto($"box_{i}", new VectorDto(){X = x, Y = y}, "box", "", 11));
            }

            cells.Add(new CellDto($"player", new VectorDto() {X = 2, Y = 2}, "player", "", 10));
            return new GameDto(cells.ToArray(), true, false, width, height, Guid.Empty, false, 0);
        }
    }
}