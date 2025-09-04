using Insurance.Application.Services;
using Insurance.Domain.Interfaces.Application;
using Insurance.Domain.Interfaces.Infrastructure.Repository;
using Insurance.Infrastructure.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace Insurance.CrossCutting.IoC
{
    public static class PipelineExtensions
    {
        public static void AddApplicationDI(this IServiceCollection services)
        {
            services.AddScoped<IInsurancesService, InsurancesService>();
        }

        public static void AddApplicationRepository(this IServiceCollection services)
        {
            services.AddScoped<IInsurancesRepository, InsuranceRepository>();
        }
    }
}
