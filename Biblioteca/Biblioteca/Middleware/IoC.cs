using Biblioteca.Core.Interfaces.Repositories;
using Biblioteca.Core.Interfaces.Services;
using Biblioteca.Core.Services.Implementation;
using Biblioteca.Infrastructure.Repositories;
namespace Biblioteca.Middleware
{
    public static class IoC
    {
        public static IServiceCollection AddDependency(this IServiceCollection services)
        {
            #region Servicios repository
            services.AddScoped<IAutoresRepository, AutoresRepository>();
            services.AddScoped<IAutoresHasLibroRepository, AutoresHasLibroRepository>();
            services.AddScoped<IEditorialesRepository, EditorialesRepository>();
            services.AddScoped<ILibrosRepository, LibrosRepository>();          
            #endregion
            #region Servicios
            services.AddScoped<IAutoresService, AutoresService>();
            services.AddScoped<IAutoresHasLibroService, AutoresHasLibroService>();
            services.AddScoped<IEditorialesService, EditorialesService>();
            services.AddScoped<ILibrosService, LibrosService>();
            #endregion
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            return services;
        }
    }
}
