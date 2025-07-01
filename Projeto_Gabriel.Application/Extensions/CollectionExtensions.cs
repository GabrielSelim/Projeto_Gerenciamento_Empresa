using Projeto_Gabriel.Bussines.Implementacoes;
using Projeto_Gabriel.Bussines;
using Projeto_Gabriel.Domain.ServiceInterface;
using Projeto_Gabriel.Domain.Service;
using Microsoft.Extensions.DependencyInjection;
using Projeto_Gabriel.Infrastructure.Services.Validation;
using Projeto_Gabriel.Application.BusinessInterface.Logas;


namespace Projeto_Gabriel.Application.Extensions
{
    public static class CollectionExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddTransient<ITokenService, TokenService>();
            services.AddTransient<IEntityValidationService<Livros>, LivrosValidationService>();

            return services;
        }

        public static IServiceCollection AddBusinessServices(this IServiceCollection services)
        {
            //Curso
            services.AddScoped<ILivroBussines, LivroBussinesImplementacao>();

            return services;
        }
    }
}