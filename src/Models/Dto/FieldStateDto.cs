using System.Collections.Generic;

namespace thegame.Models.Dto
{
    public class FieldStateDto
    {
        public List<PointDto> Solved { get; set; } = new List<PointDto>();
        public List<PointDto> Swapped { get; set; } = new List<PointDto>();
        public List<CardDto> Opened { get; set; } = new List<CardDto>();
    }
}