using thegame.Models;

namespace thegame.GameObjects
{
    public class Cell : ICell
    {
        /// <summary>
        /// Frontend animate transition of the cell from old to new state.
        /// </summary>
        /// <param name="id">Id is used to identificate cell to apply right animation</param>
        /// <param name="pos">Logical position of the cell in the game grid. Upper left corner is `new Vec(0, 0)`</param>
        /// <param name="type">Frontend apply images and other styling to the cell according to this type</param>
        /// <param name="content">Frontend can put this text in the cell</param>
        public Cell(string id, VectorDto pos, CellType type, string content)
        {
            Id = id;
            Pos = pos;
            Type = type;
            Content = content;
            ZIndex = GetZIndex(type);
        }

        private int GetZIndex(CellType type)
        {
            return type switch
            {
                CellType.Box => 5,
                CellType.Player => 10,
                CellType.Target => 1,
                CellType.Wall => 15,
                CellType.BoxOnTarget => 5,
                _ => 0
            };
        }

        public string Id { get; set; }
        public VectorDto Pos { get; set; }
        public int ZIndex { get; set; }
        public CellType Type { get; set; }
        public string Content { get; set; }
    }
}