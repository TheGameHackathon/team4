using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using thegame.Mapping;
using thegame.Services;

var builder = WebApplication.CreateBuilder();
builder.Services.AddAutoMapper(typeof(GameProfile));
builder.Services.AddSingleton<IGamesRepository, GamesRepository>();
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