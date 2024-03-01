using API_WEB.Data;
using Microsoft.EntityFrameworkCore;
using MySql.EntityFrameworkCore.Extensions;
using MySqlConnector;
using System.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//builder.Services.AddDbContext<DBContext>(options =>
//  options.UseMySQL(builder.Configuration.GetConnectionString("MangaDbConnectionString"))
//  );
builder.Services.AddMySqlDataSource(builder.Configuration.GetConnectionString("MangaDbConnectionString")!);




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
