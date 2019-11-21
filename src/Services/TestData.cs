using System;
using thegame.Models;

namespace thegame.Services
{
    public class TestData
    {
        public static GameDto AGameDto(Vec movingObjectPosition)
        {
            var width = 8;
            var height = 9;
            var testCells = new[]
            {
                new CellDto("0", movingObjectPosition, "player", "", 10),
                new CellDto("1", new Vec(0, 1), "wall", "", 0),
                new CellDto("2", new Vec(1, 1), "wall", "", 0),
                new CellDto("3", new Vec(2, 1), "wall", "", 0),
                new CellDto("4", new Vec(2, 0), "wall", "", 0),
                new CellDto("5", new Vec(3, 0), "wall", "", 0),
                new CellDto("6", new Vec(4, 0), "wall", "", 0),
                new CellDto("7", new Vec(5, 0), "wall", "", 0),
                new CellDto("8", new Vec(6, 0), "wall", "", 0),
                new CellDto("9", new Vec(6, 1), "wall", "", 0),
                new CellDto("10", new Vec(6, 2), "wall", "", 0),
                new CellDto("11", new Vec(6, 3), "wall", "", 0),
                new CellDto("12", new Vec(6, 4), "wall", "", 0),
                new CellDto("13", new Vec(6, 5), "wall", "", 0),
                new CellDto("14", new Vec(7, 5), "wall", "", 0),
                new CellDto("15", new Vec(7, 6), "wall", "", 0),
                new CellDto("16", new Vec(7, 7), "wall", "", 0),
                new CellDto("17", new Vec(7, 8), "wall", "", 0),
                new CellDto("35", new Vec(6, 8), "wall", "", 0),
                new CellDto("18", new Vec(5, 8), "wall", "", 0),
                new CellDto("19", new Vec(4, 8), "wall", "", 0),
                new CellDto("20", new Vec(3, 8), "wall", "", 0),
                new CellDto("21", new Vec(2, 8), "wall", "", 0),
                new CellDto("22", new Vec(1, 8), "wall", "", 0),
                new CellDto("23", new Vec(0, 8), "wall", "", 0),
                new CellDto("24", new Vec(0, 7), "wall", "", 0),
                new CellDto("25", new Vec(0, 6), "wall", "", 0),
                new CellDto("26", new Vec(0, 5), "wall", "", 0),
                new CellDto("27", new Vec(0, 4), "wall", "", 0),
                new CellDto("28", new Vec(0, 3), "wall", "", 0),
                new CellDto("29", new Vec(0, 2), "wall", "", 0),
                new CellDto("30", new Vec(1, 3), "wall", "", 0),
                new CellDto("31", new Vec(2, 3), "wall", "", 0),
                new CellDto("32", new Vec(2, 4), "wall", "", 0),
                new CellDto("33", new Vec(2, 5), "wall", "", 0),
                new CellDto("34", new Vec(3, 4), "wall", "", 0),
            };
            return new GameDto(testCells, true, true, width, height, Guid.NewGuid(), movingObjectPosition.X == 0, movingObjectPosition.Y);
        }
    }
}