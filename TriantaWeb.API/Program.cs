using Microsoft.EntityFrameworkCore;
using TriantaWeb.API.Data;
using TriantaWeb.API.Mappings;
using TriantaWeb.API.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//DI Depedency Injection
builder.Services.AddDbContext<TriantaDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("TriantaConnectionString")));
builder.Services.AddAutoMapper(typeof(AutomapperProfiles));
builder.Services.AddScoped<IRegionRepository, SqlRegionRepository>();
builder.Services.AddScoped<IWalkRepository, SqlWalkRepository>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
