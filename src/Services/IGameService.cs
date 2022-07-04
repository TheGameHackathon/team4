using thegame.Models.DTO;
using thegame.Models.Entities;

namespace thegame.Services
{
    public interface IGameService
    {
        GameDto MakeMove(GameDto game, UserInput userInput);
    }
}
