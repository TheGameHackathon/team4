using System.Collections.Generic;

namespace thegame.Models.Dto
{
    public class FieldStateDto
    {
        public List<CardDto> Solved { get; set; }
        public List<PointDto> Swapped { get; set; }
    }
}