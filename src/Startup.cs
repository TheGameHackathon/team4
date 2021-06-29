using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using AutoMapper;
using thegame.GameObjects;
using thegame.Models;
using thegame.Services;

namespace thegame
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            services.AddSingleton<IGamesRepo>(new GamesRepo());

            services.AddAutoMapper(cfg =>
            {
                cfg.CreateMap<ICell, CellDto>()
                    .ForMember(dest => dest.Type,
                        opt => opt.MapFrom(src => src.Type.ToString()));

                cfg.CreateMap<Game, GameDto>();
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app)
        {
            app.UseDeveloperExceptionPage();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}");
            });
            app.Use((context, next) =>
            {
                context.Request.Path = "/index.html";
                return next();
            });
            app.UseStaticFiles();
        }
    }
}