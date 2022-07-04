using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using thegame.Mapping;
using thegame.Models.DTO;
using thegame.Models.Entities;
using thegame.Services;

var builder = WebApplication.CreateBuilder();
builder.Services.AddAutoMapper(typeof(GameProfile));
builder.Services.AddSingleton<IGamesRepository, GamesRepository>();
builder.Services.AddSingleton<IGameService, GameService>();
builder.Services.AddMvc();
builder.Services.AddAutoMapper(cfg =>
{
    cfg.CreateMap<Game, GameDto>().ReverseMap();
    cfg.CreateMap<CellDto, Cell>().ReverseMap();
});

var app = builder.Build();

app.UseDeveloperExceptionPage();
app.UseStaticFiles();
app.UseRouting();
app.UseEndpoints(endpoints => endpoints.MapControllers());
app.Use((context, next) =>
{
    context.Request.Path = "/index.html";
    return next();
});
app.UseStaticFiles();

app.Run();