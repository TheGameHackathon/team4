using System.Collections.Generic;

namespace thegame.Models.Dto
{
    public class FieldStateDto
    {
        public List<CardDto> Solved { get; set; } = new List<CardDto>();
        public List<PointDto> Swapped { get; set; } = new List<PointDto>();
    }
}