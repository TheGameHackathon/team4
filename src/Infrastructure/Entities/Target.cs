using thegame.Models;

namespace thegame.Infrastructure.Entities
{
    public class Target : CellDto
    {
        public Target(string id, Vec pos, string type, string content, int zIndex) : base(id, pos, type, content,
            zIndex)
        {
        }
    }
}