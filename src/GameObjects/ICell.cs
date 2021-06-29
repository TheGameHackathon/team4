using thegame.Models;

namespace thegame.GameObjects
{
    public interface ICell
    {
        public string Id { get; set; }
        public VectorDto Pos { get; set; }
        public int ZIndex { get; set; }
        public CellType Type { get; set; }
        public string Content { get; set; }
    }
}