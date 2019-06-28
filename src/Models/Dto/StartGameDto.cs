using System.ComponentModel.DataAnnotations;

namespace thegame.Models.Dto
{
    public class StartGameDto
    {
        [Required]
        public string UserName { get; set; }
    }
}