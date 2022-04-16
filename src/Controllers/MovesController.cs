using System;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using thegame.Models;
using thegame.Services;

namespace thegame.Controllers
{
    [Route("api/games/{gameId}/moves")]
    public class MovesController : Controller
    {
        [HttpPost]
        public IActionResult Moves(Guid gameId, [FromBody] UserInputDto userInput)
        {
            /*var game = TestData.AGameDto(userInput.ClickedPos ?? new VectorDto(1, 1));
            if (userInput.ClickedPos != null)
                game.Cells.First(c => c.Type == "color4").Pos = userInput.ClickedPos;
            return Ok(game);*/
            GameDto game = null;
            /*if (userInput.KeyPressed == 'W')
            {
                game = TestData.AGameDto(game.Cells.First(c => c.Type == "color4").Pos + new VectorDto(0, -1));
            }
            else if (userInput.KeyPressed == 'a')
            {
                game = TestData.AGameDto(game.Cells.First(c => c.Type == "color4").Pos + new VectorDto(-1, 0));
            }
            else if (userInput.KeyPressed == 'S')
            {
                game = TestData.AGameDto(game.Cells.First(c => c.Type == "color4").Pos + new VectorDto(0, 1));
            }
            else if (userInput.KeyPressed == 'D')
            {
                game = TestData.AGameDto(game.Cells.First(c => c.Type == "color4").Pos + new VectorDto(1, 0));
            }
            else
            {
                game = TestData.AGameDto(new VectorDto(0, 0));
            }*/

            return Ok(TestData.AGameDto(new VectorDto(1, 1)));
        }
    }
}