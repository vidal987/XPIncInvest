using System.Reflection;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Scrutor;
using XPIncInvest.BuildingBlocks.Extensions.Interfaces;

namespace XPIncInvest.BuildingBlocks.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddScannedIoC(this IServiceCollection service)
        {
            return service.Scan(scan =>
                scan.AddCustomClasses()
            );
        }

        public static IServiceCollection AddScannedIoC(this IServiceCollection service, Func<Assembly, bool> predicate)
        {
            return service.Scan(scan =>
                scan.FromApplicationDependencies(predicate)
                    .AddCustomClasses()
            );
        }

        private static void AddCustomClasses(this IAssemblySelector selector)
        {
            selector.FromApplicationDependencies(c => !c.ManifestModule.Name.Contains("FluentValidation"))
                .AddClasses(classes => classes.AssignableTo(typeof(IValidator<>)))
                .AsImplementedInterfaces()
                .WithScopedLifetime()
                .AddClasses(classes => classes.AssignableTo<ISingletonService>())
                .AsImplementedInterfaces()
                .WithSingletonLifetime()
                .AddClasses(classes => classes.AssignableTo<ITransientService>())
                .AsImplementedInterfaces()
                .WithTransientLifetime()
                .AddClasses(classes => classes.AssignableTo<IScopedService>())
                .AsImplementedInterfaces()
                .WithScopedLifetime();
        }
    }
}
