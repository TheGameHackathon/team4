using Microsoft.VisualBasic.CompilerServices;

namespace thegame.Models.Entities;

public class Position
{
    public Position(int x, int y)
    {
        X = x;
        Y = y;
    }

    public int X { get; set; }
    public int Y { get; set; }
    public static Position operator +(Position p1, Position p2) => new Position(p1.X + p2.X, p1.Y + p2.Y);
}