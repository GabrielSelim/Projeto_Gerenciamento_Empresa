using Projeto_Gabriel.Bussines.Implementacoes;
using Projeto_Gabriel.Bussines;
using Projeto_Gabriel.Domain.ServiceInterface;
using Projeto_Gabriel.Domain.Service;
using Microsoft.Extensions.DependencyInjection;
using Projeto_Gabriel.Infrastructure.Services.Validation;
using Projeto_Gabriel.Domain.Entity;
using Projeto_Gabriel.Application.BusinessInterface;
using Projeto_Gabriel.Application.Business;
using Projeto_Gabriel.Domain.Entity.Logas;
using Projeto_Gabriel.Domain.Service.Logas;


namespace Projeto_Gabriel.Application.Extensions
{
    public static class CollectionExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddTransient<ITokenService, TokenService>();
            services.AddTransient<IEntityValidationService<Livros>, LivrosValidationService>();
            services.AddTransient<IEntityValidationService<Usuario>, UsuarioValidationService>();
            services.AddTransient<IEntityValidationService<TaxaJuros>, TaxaJurosService>();

            //Logs
            services.AddTransient<IEntityValidationService<LogEntry>, LogsValidationService>();

            return services;
        }

        public static IServiceCollection AddBusinessServices(this IServiceCollection services)
        {

            services.AddScoped<ILivroBussines, LivroBussinesImplementacao>();
            services.AddScoped<ITaxaJurosBussines, TaxaJurosBussinesImplementacao>();

            //Login
            services.AddScoped<ILoginBussines, LoginBussinesImplementation>();
            services.AddScoped<IUsuarioBusiness, UsuarioBusinessImplementacao>();

            return services;
        }
    }
}