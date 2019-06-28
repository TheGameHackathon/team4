using Microsoft.Extensions.DependencyInjection;
using thegame.DB;

namespace thegame.Extensions
{
    public static class ContainerExtensions
    {
        public static void RegisterDIContainer(this IServiceCollection services)
        {
            services.AddSingleton<IGameRepository, InMemoryGameRepository>();
            services.AddSingleton<Generator.FieldGenerator>();
        }
    }
}