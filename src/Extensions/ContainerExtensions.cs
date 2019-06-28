using Microsoft.Extensions.DependencyInjection;
using thegame.DB;

namespace thegame.Extensions
{
    public static class ContainerExtensions
    {
        public static void RegisterDIContainer(this IServiceCollection services)
        {
            services.AddSingleton<IGameDatabase, InMemoryGameDatabase>();
            services.AddSingleton<Generator.FieldGenerator>();
        }
    }
}