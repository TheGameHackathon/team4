using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using thegame.Models;
using thegame.Models.Entities;

var builder = WebApplication.CreateBuilder();

builder.Services.AddMvc();
builder.Services.AddAutoMapper(cfg =>
    cfg.CreateMap<CellDto, Cell>()
);

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