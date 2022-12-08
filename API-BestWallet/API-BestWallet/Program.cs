//using API_BestWallet.Models;
using API_BestWallet.Services;
using Entities;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//builder.Services.AddEntityFrameworkSqlServer().
//AddDbContext<BestWalletContext>(options => 
//options.UseSqlServer(builder.Configuration.GetConnectionString("ConexionDatabase")));
builder.Services.AddDbContext<BestWalletContext>(opt =>
    opt.UseSqlServer(builder.Configuration.GetConnectionString("ConexionDatabase")));

builder.Services.AddTransient<IUsuarioService, UsuarioService>();

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
