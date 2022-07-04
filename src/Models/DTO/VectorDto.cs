namespace thegame.Models.DTO
{
    public class VectorDto
    {
        public VectorDto()
        {
        }

        public VectorDto(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int X { get; set; }
        public int Y { get; set; }
        public static VectorDto operator +(VectorDto p1, VectorDto p2) => new VectorDto(p1.X + p2.X, p1.Y + p2.Y);

        public static bool operator ==(VectorDto p1, VectorDto p2) => p1.X == p2.X && p1.Y == p2.Y;

        public static bool operator !=(VectorDto p1, VectorDto p2) => !(p1 == p2);
    }
}