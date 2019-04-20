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
            var vec = obj as Vec;
            if (vec!=null)
            {
                return vec.X == this.X && vec.Y == this.Y;
            }

            return false;
        }
    }
}