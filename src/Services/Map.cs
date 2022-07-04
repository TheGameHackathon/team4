using System;
using thegame.Models.DTO;

namespace thegame.Services;

// public enum CellType
// {
//     Wall,
//     Box,
// }

public class Map
{
    public Map(GameDto game)
    {
        Table = new string[game.Width][];
        for (int i = 0; i < game.Width; i++)
            Table[i] = new string[game.Height];

        foreach (var gameCell in game.Cells)
        {
            var pos = gameCell.Pos;
            Table[pos.X][pos.Y] = gameCell.Type;
        }
    }

    public string[][] Table { get; }
}