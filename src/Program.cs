using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using thegame.Models.DTO;
using thegame.Models.Entities;
using thegame.Services;

var builder = WebApplication.CreateBuilder();
builder.Services.AddSingleton<IGamesRepository, GamesRepository>();
builder.Services.AddSingleton<IGameService, GameService>();
builder.Services.AddMvc();

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