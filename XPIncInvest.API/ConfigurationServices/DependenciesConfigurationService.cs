using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Reflection;
using XPIncInvest.Infrastructure.Context;



namespace XPIncInvest.API.ConfigurationServices
{
    public static class DependenciesConfigurationService
    {
        public static IServiceCollection AddMediator(this IServiceCollection services) 
        {
            services.AddMediatR(cf => cf.RegisterServicesFromAssemblies(Assembly.Load("XPIncInvest.Application")));

            return services;
        }

        public static IServiceCollection AddDataContext(this IServiceCollection services)
        {

            return services.AddDbContext<DataContext>
                (options => options.UseNpgsql("Host=localhost;Database=xp;Username=postgres;Password=mysecretpassword", b => b.MigrationsAssembly("XPIncInvest.API")));

        }

        public static IServiceCollection AddSwagger(this IServiceCollection services)
        {
            return services.AddSwaggerGen(option =>
            {
                option.SwaggerDoc("v1", new OpenApiInfo { Title = "Test API", Version = "v1" });
                option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Please enter a valid token",
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    BearerFormat = "JWT",
                    Scheme = "Bearer"
                });
                option.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new string[] { }
                    }
                });
            });
        }
    }
}
