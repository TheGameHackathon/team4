using thegame.Models.Entities;

namespace thegame.Services
{
    interface IGameService
    {
        Game MakeMove(Game game, UserInput userInput);
    }
}