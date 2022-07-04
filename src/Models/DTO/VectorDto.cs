namespace thegame.Models.DTO
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
        public static VectorDto operator +(VectorDto p1, VectorDto p2) => new VectorDto(p1.X + p2.X, p1.Y + p2.Y);
    }
}