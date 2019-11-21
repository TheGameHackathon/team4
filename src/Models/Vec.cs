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