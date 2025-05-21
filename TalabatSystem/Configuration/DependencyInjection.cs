using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Talabat.Application.xtentions;
using Talabat.Infrastructure.Data;

namespace TalabatSystem.Api.Configuration
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddSwagerservices(this IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version= "v1",
                    Title= "Talabat",
                    Description = "This system is for food delivery",
                    TermsOfService = new Uri("http://www.example.com/terms"),
                    Contact= new OpenApiContact()
                    {
                        Email ="RehamZaky36@gmail.com",
                        Name ="Reham Zaky",
                        Url= new Uri( "https://www.website.com")
                    },
                    License = new OpenApiLicense() { 
                        Name = "Use under XYZ",
                       Url = new Uri("http://www.example.com/license"),
                    }

                });

                // optional add authorization support
                
            });
                return services;
        }

        public static IServiceCollection AddApiServices(this IServiceCollection services,IConfiguration configuration)
        {

            services.AddDbContext<ApplicationDBContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });

            services.Configure<Jwt>(configuration.GetSection("Jwt"));

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDBContext>()
                .AddDefaultTokenProviders();

            return services;
        }
    }
}
