namespace thegame.Models
{
    public class Vec
    {
        public Vec(int x, int y)
        {
            X = x;
            Y = y;
        }

        public readonly int X, Y;

        public bool Equals(Vec secondVec)
        {
            return this.X == secondVec.X && this.Y == secondVec.Y;
        }
    }
}