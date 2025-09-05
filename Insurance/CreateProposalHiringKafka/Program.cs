using CreateProposalHiringKafka;
using CreateProposalHiringKafka.Interfaces;
using CreateProposalHiringKafka.Transaction;
using Insurance.CrossCutting.IoC;
using Insurance.Infrastructure.Repository.Context;
using Microsoft.EntityFrameworkCore; // já existe, mas precisa garantir que está presente

// ...restante do código permanece igual


var builder = Host.CreateApplicationBuilder(args);
builder.Services.AddDbContext<AppDbContext>(options =>
                       options.UseSqlServer(builder.Configuration.GetConnectionString("InsuranceApi.con")));

builder.Services.AddApplicationDI();
builder.Services.AddApplicationRepository();

builder.Services.AddScoped<IExecuteTRA, ExecuteTRA>();
builder.Services.AddHostedService<Worker>();

var host = builder.Build();
host.Run();
