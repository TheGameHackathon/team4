using AutoMapper;
using thegame.Models;
using thegame.Models.DTO;
using thegame.Models.Entities;

namespace thegame.Mapping
{
    public class GameProfile : Profile
    {
        public GameProfile()
        {
            CreateMap<GameDto, Game>().ReverseMap();
            CreateMap<UserInput, UserInputDto>().ReverseMap();
        }
    }
}