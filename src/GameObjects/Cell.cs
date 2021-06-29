using thegame.Models;

namespace thegame.GameObjects
{
    public class Cell : ICell
    {
        public Cell(string id, VectorDto pos, CellType type, string content, int zIndex)
        {
            Id = id;
            Pos = pos;
            Type = type;
            Content = content;
            ZIndex = zIndex;
        }

        public string Id { get; set; }
        public VectorDto Pos { get; set; }
        public int ZIndex { get; set; }
        public CellType Type { get; set; }
        public string Content { get; set; }
    }
}