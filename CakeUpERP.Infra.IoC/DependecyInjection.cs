using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using CakeUpERP.Infra.Data.Context;
using CakeUpERP.Infra.Data.Repository;
using CakeUpERP.Domain.Interfaces.Repositorys;
using Microsoft.Extensions.Configuration;
using MediatR;
using CakeUpERP.Application.Interfaces;
using CakeUpERP.Application.Service;
using AutoMapper;
using System.Reflection;
using Microsoft.Extensions.Hosting;

namespace CakeUpERP.Infra.IoC
{
    public static class DependecyInjection
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            string connectionString = configuration.GetConnectionString("DefaultConnection");
            var serverVersion = ServerVersion.AutoDetect(connectionString);
            services.AddDbContext<DataContext>(
                dbContextOptions => dbContextOptions
                    .UseMySql(connectionString, serverVersion)
                    .EnableSensitiveDataLogging()
                    .EnableDetailedErrors()
            );

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            var myhandlers = AppDomain.CurrentDomain.Load("CakeUpERP.Application");
            services.AddMediatR(myhandlers);

            services.AddTransient<ITokenService, TokenService>();
            services.AddTransient<IUsuarioService, UsuarioService>();
            services.AddTransient<ICompanhiaService, CompanhiaService>();

            services.AddTransient<ITokenService, TokenService>();
            services.AddTransient<IUsuarioRepository, UsuarioRepository>();
            services.AddTransient<ICompanhiaRepository, CompanhiaRepository>();

        }

        public static void RunMigrations()
        {
            var host = Host.CreateDefaultBuilder().Build();

            using (var scope = host.Services.CreateScope())
            {
                var db = scope.ServiceProvider.GetRequiredService<DataContext>();
                db.Database.Migrate();
            }

            host.Run();
        }
    }
}
