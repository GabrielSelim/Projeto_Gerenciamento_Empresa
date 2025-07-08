using Microsoft.Extensions.DependencyInjection;
using Projeto_Gabriel.Domain.RepositoryInterface;
using Projeto_Gabriel.Infrastructure.Repositorys;

namespace Projeto_Gabriel.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddInfrastructureRepositories(this IServiceCollection services)
        {
            services.AddScoped<ILivroRepository, LivroRepository>();

            return services;
        }
    }
}