using MAS;
using MAS.Services.Interfaces;
using MAS.Services.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<MasContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ConnString")));

builder.Services.AddScoped<ICarService, CarService>();
builder.Services.AddScoped<IElementService, ElementService>();
builder.Services.AddScoped<IPartService, PartService>();
builder.Services.AddScoped<IJobService, JobService>();
builder.Services.AddScoped<IServicemanService, ServicemanService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(options =>
{
    options.AllowAnyHeader();
    options.AllowAnyMethod();
    options.AllowAnyOrigin();
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
