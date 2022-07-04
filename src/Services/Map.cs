using System;
using System.Collections.Generic;
using thegame.Models.DTO;

namespace thegame.Services
{

    public class Map
    {
        public Map(GameDto game)
        {
            Boxes = new HashSet<VectorDto>();
            Targets = new HashSet<VectorDto>();
            Table = new string[game.Width][];
            for (var i = 0; i < game.Width; i++)
                Table[i] = new string[game.Height];

            foreach (var gameCell in game.Cells)
            {
                var pos = gameCell.Pos;
                Table[pos.X][pos.Y] = gameCell.Type;
                if (gameCell.Type == "box")
                    Boxes.Add(gameCell.Pos);
                else if (gameCell.Type == "target")
                    Targets.Add(gameCell.Pos);
            }
        }

        public string[][] Table { get; }
        public HashSet<VectorDto> Boxes { get; }
        public HashSet<VectorDto> Targets { get; }
    }
}