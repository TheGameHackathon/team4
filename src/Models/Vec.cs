using thegame.Infrastructure.Common;

namespace thegame.Models
{
    public class Vec
    {
        public Vec(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int X, Y;

        public Vec GetNextPosition(Direction direction)
        {
            Vec vec = new Vec(X, Y);
            switch (direction)
            {
                case Direction.Up:
                    vec.Y -= 1;
                    break;
                case Direction.Left:
                    vec.X -= 1;
                    break;
                case Direction.Right:
                    vec.X += 1;
                    break;
                case Direction.Down:
                    vec.Y += 1;
                    break;
            }
            return vec;
        }


        public override bool Equals(object obj)
        {
            return Equals(obj as Vec);
        }

        bool Equals(Vec secondVec)
        {
            return this.X == secondVec.X && this.Y == secondVec.Y;
        }
    }
}