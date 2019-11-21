using System;
using System.IO;
using System.Linq;
using System.Reflection;
using thegame.Infrastructure.Common;
using thegame.Models;

namespace thegame.Infrastructure
{
    public class Level
    {
        public readonly string File;
        public readonly CellDto[] Map;

        public readonly int Width;
        public readonly int Height;

        public Level(CellDto[] map, int width, int height, string file = null)
        {
            Map = map;
            Width = width;
            Height = height;
            File = file;
        }

        public static string[] All() => Assembly.GetExecutingAssembly().GetManifestResourceNames();

        public static Level First() => FromFile(All().First());

        public static Level FromFile(string name) => FromStream(Assembly.GetExecutingAssembly().GetManifestResourceStream(name), name);
        
        static Level FromStream(Stream stream, string file) => FromSource(stream.ReadAllLines().ToArray(), file);
        
        static Level FromSource(string[] lines, string file)
        {
            foreach (var singleLine in lines)
            {
                foreach (var symbol in singleLine.ToCharArray())
                {

                    
                }

                
            }

            var map = Enumerable
                .Range(0, 9)
                .Select(i => new CellDto(i.ToString(), new Vec(i % 3, i / 3), "wall", "", 1))
                .ToArray();

            map[4].Type = "";

            return new Level(map, 8,9, file);
        }
        
        public Vec GetPlayerPosition()
        {
            var pastVec = Map.First(x => x.Type == "player").Pos;
            return new Vec(pastVec.X, pastVec.Y);
        }
    }
}