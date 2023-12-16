using Application.Interfaces;
using Application.Mappings;
using Application.Services;
using Domain.Account;
using Domain.Interface;
using Infrastructure.Context;
using Infrastructure.Identity;
using Infrastructure.Repositoires;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossCutting
{
    public static class DependencyInjectionAPI
    {
        public static IServiceCollection AddInfrastructureAPI(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<ApplicationContext>(options =>
             options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"
            ), b => b.MigrationsAssembly(typeof(ApplicationContext).Assembly.FullName)));

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationContext>()
                .AddDefaultTokenProviders();

            services.AddScoped<IMercadoriaRepository, MercadoriaRepository>();
            services.AddScoped<IEntradaMercadoriaRepository, EntradaMercadoriaRepository>();
            services.AddScoped<ISaidaMercadoriaRepository, SaidaMercadoriaRepository>();

            services.AddScoped<IMercadoriaService, MercadoriaService>();
            services.AddScoped<IEntradaMercadoriaService, EntradaMercadoriaService>();
            services.AddScoped<ISaidaMercadoriaService, SaidaMercadoriaService>();

            services.AddScoped<IAuthenticate, AuthenticateService>();

            services.AddAutoMapper(typeof(MappingToDomain));

            return services;
        }
    }
}
