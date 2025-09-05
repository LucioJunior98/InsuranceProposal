using Insurance.CrossCutting.IoC;
using Insurance.Infrastructure.Repository.Context;
using Microsoft.EntityFrameworkCore;

var builder = Host.CreateApplicationBuilder(args);
builder.Services.AddApplicationDI();
builder.Services.AddApplicationRepository();

builder.Services.AddDbContext<AppDbContext>(options =>
                        options.UseSqlServer(builder.Configuration.GetConnectionString("InsuranceApi.con")));

var host = builder.Build();
host.Run();
