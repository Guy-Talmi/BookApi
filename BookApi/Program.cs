using BookApi.Models;
using BookApi.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var databasePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "books.db");
builder.Services.AddDbContext<BookContext>(o => o.UseSqlite($"Data source={databasePath}"));

//builder.Services.AddDbContext<BookContext>(o => o.UseSqlite("Data source=books.db"));
builder.Services.AddScoped<IBookRepository, BookRepository>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
