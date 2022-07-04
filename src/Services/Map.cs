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
            Table = new CellDto[game.Width][];
            for (int i = 0; i < game.Width; i++)
                Table[i] = new CellDto[game.Height];

            foreach (var gameCell in game.Cells)
            {
                var pos = gameCell.Pos;
                if (gameCell.Type is "wall" or "box")
                    Table[pos.X][pos.Y] = gameCell;
                switch (gameCell.Type)
                {
                    case "box":
                        Boxes.Add(gameCell.Pos);
                        break;
                    case "target":
                        Targets.Add(gameCell.Pos);
                        break;
                }
            }
        }

        public CellDto[][] Table { get; }
        public HashSet<VectorDto> Boxes { get; }
        public HashSet<VectorDto> Walls { get; }
        public HashSet<VectorDto> Targets { get; }
    }
}