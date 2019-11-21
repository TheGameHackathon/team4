using System;
using System.IO;
using System.Linq;
using thegame.Models;

namespace thegame.Infrastructure
{
    public class Level
    {
        public readonly CellDto[] Map;

        public readonly int Width;
        public readonly int Height;

        public Level(CellDto[] map, int width, int height)
        {
            Map = map;
            Width = width;
            Height = height;
        }

        public static Level FromFile(string path) => FromSource(File.ReadAllLines(path));

        public Vec GetPlayerPosition()
        {
            var pastVec = Map.First(x => x.Type == "player").Pos;
            return new Vec(pastVec.X, pastVec.Y);
        }

        public static Level FromSource(string[] lines)
        {
            var map = Enumerable
                .Range(0, 9)
                .Select(i => new CellDto(i.ToString(), new Vec(i % 3, i / 3), "wall", "", 1))
                .ToArray();

            map[4].Type = "";

            return new Level(map, 8,9);
        }
    }
}