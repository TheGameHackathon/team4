using System;
using Microsoft.VisualBasic.CompilerServices;

namespace thegame.Models
{
    public class VectorDto : IEquatable<VectorDto>
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

        public bool Equals(VectorDto other)
        {
            if (ReferenceEquals(null, other))
                return false;
            if (ReferenceEquals(this, other))
                return true;
            return X == other.X && Y == other.Y;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
                return false;
            if (ReferenceEquals(this, obj))
                return true;
            if (obj.GetType() != this.GetType())
                return false;
            return Equals((VectorDto)obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(X, Y);
        }
    }
}