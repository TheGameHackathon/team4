using Microsoft.VisualBasic.CompilerServices;

namespace thegame.Models
{
    public class VectorDto
    {
        public VectorDto(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int X { get; set; }
        public int Y { get; set; }

        public static VectorDto operator +(VectorDto f, VectorDto a)
        {
            return new VectorDto(f.X + a.X, f.Y + a.Y);
        }
    }
}