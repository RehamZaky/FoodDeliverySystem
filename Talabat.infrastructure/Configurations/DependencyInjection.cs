using Microsoft.Extensions.DependencyInjection;
using Talabat.Application.Repository.Interfaces;
using Talabat.Infrastructure.Mapper;
using Talabat.Infrastructure.Presistence.Repository;

namespace Talabat.Infrastructure.Configurations
{
    public static class DependencyInjection
    {
        //scope unit of work
        // all using transit
        public static IServiceCollection AddInfrastructureService(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
          //  services.AddTransient<IUserService, UserService>();

            services.AddAutoMapper(typeof(UserProfile));
            return services;
        }
        
    }
}
