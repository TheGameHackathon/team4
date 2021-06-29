namespace thegame.Models
{
    public class CellDto
    {
        public string Id { get; set; }
        public VectorDto Pos { get; set; }
        public int ZIndex { get; set; }
        public string Type { get; set; }
        public string Content { get; set; }
    }
}