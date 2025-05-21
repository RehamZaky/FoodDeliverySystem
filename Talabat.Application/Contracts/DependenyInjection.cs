using Microsoft.Extensions.DependencyInjection;
using Talabat.Application.Contracts.Interfaces;
using Talabat.Application.Services;

namespace Talabat.Application.Contracts
{
    public static class DependenyInjection
    {
        public static IServiceCollection AddApplicationService(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();

            return services;
        }
    }
}
