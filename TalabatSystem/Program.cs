using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Talabat.Application.Contracts.Interfaces;
using Talabat.Application.Services;
using Talabat.Infrastructure.Configurations;
using Talabat.Infrastructure.Data;
using TalabatSystem.Api.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddInfrastructureService();
builder.Services.AddApiServices(builder.Configuration);
builder.Services.AddScoped<IUserService, UserService>();


//builder.Services.AddIdentity<IdentityUser,IdentityRole>()
//    .AddEntityFrameworkStores<ApplicationDBContext>().AddDefaultTokenProviders();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
