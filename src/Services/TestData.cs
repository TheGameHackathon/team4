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
            
            var map = new string[9, 8]
            {
                {"w", "w", "w", "w", "w", "w", "w", "w"},
                {"w", "w", "w", "e", "e", "e", "w", "w"},
                {"w", "t", "p", "b", "e", "e", "w", "w"},
                {"w", "w", "w", "e", "b", "t", "w", "w"},
                {"w", "t", "w", "w", "b", "e", "w", "w"},
                {"w", "e", "w", "e", "t", "e", "w", "w"},
                {"w", "b", "e", "e", "b", "b", "t", "w"},
                {"w", "e", "e", "e", "t", "e", "e", "w"},
                {"w", "w", "w", "w", "w", "w", "w", "w"}
            };
            
            return CreateNewLevel(width, height, map);
        }
        
        public static GameDto SecondLevel()
        {
            var width = 8;
            var height = 9;
            
            var map = new string[9, 8]
            {
                {"w", "w", "w", "w", "w", "w", "w", "w"},
                {"w", "e", "e", "e", "e", "e", "e", "w"},
                {"w", "e", "p", "e", "e", "e", "e", "w"},
                {"w", "e", "e", "e", "e", "e", "e", "w"},
                {"w", "e", "e", "e", "b", "e", "e", "w"},
                {"w", "e", "e", "e", "e", "e", "e", "w"},
                {"w", "e", "e", "e", "e", "e", "e", "w"},
                {"w", "e", "e", "e", "t", "e", "e", "w"},
                {"w", "w", "w", "w", "w", "w", "w", "w"}
            };
            
            return CreateNewLevel(width, height, map);
        }

        private static GameDto CreateNewLevel(int width, int height, string[,] map)
        {
            var cells = GetListDto(width, height, map);
            return new GameDto(cells.ToArray(), true, false, width, height, Guid.Empty, false, 0);
        }

        private static List<CellDto> GetListDto(int width, int height, string[,] map)
        {
            var cells = new List<CellDto>();
            var id = 0;
            for (var i = 0; i < height; i++)
            {
                for (var j = 0; j < width; j++)
                {
                    switch (map[i, j])
                    {
                        case "w":
                            cells.Add(new CellDto($"wall_{j}_{i}", new VectorDto(){X = j, Y = i}, "wall", "", 10));
                            break;
                        case "b":
                            cells.Add(new CellDto($"box_{id}", new VectorDto(){X = j, Y = i}, "box", "", 10));
                            id++;
                            break;
                        case "t":
                            cells.Add(new CellDto($"target_{j}_{i}", new VectorDto(){X = j, Y = i}, "target", "", 0));
                            break;
                        case "p":
                            cells.Add(new CellDto($"player", new VectorDto() {X = j, Y = i}, "player", "", 10));
                            break;
                    }
                }
            }

            return cells;
        }
    }
}