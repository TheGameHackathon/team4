using System.ComponentModel.DataAnnotations;

namespace thegame.Models.Dto
{
    public class PointDto
    {
        [Required] public int X { get; set; }
        [Required] public int Y { get; set; }
    }
}