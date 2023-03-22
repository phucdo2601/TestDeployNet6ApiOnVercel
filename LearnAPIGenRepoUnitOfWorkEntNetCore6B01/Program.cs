using LearnAPIGenRepoUnitOfWorkEntNetCore6B01.Interfaces;
using LearnAPIGenRepoUnitOfWorkEntNetCore6B01.Models;
using LearnAPIGenRepoUnitOfWorkEntNetCore6B01.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Add DbContext to connect the database
builder.Services.AddDbContext<LearnUOfWorkVPSCSharpContext>(option => option.UseSqlServer(
    builder.Configuration.GetConnectionString("DbConnect")));

// Add UnitOfWork for using repositiory of app
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

//open CORS
builder.Services.AddCors();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//use CORS
app.UseCors(c => c.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());

app.UseAuthorization();

app.MapControllers();

app.Run();
