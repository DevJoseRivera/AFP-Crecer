using Domain.Core;
using Domain.Core.MedicalCenter.Models;
using Microsoft.EntityFrameworkCore;
using Services;
using Services.MedicalCenter.Contracts;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AfpCrecerDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("AFP-Crecer"));
});

builder.Services.AddTransient<IGenericService<Especialidad>, EspecialidadService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();

app.Run();
