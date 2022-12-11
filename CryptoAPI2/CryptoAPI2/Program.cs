
using CryptoAPI2.Controllers;
using CryptoAPI2.Models;
using Entities.Services;
using System.Text.Json.Serialization;

var myAllowSpecifcOrigins = "_myAllowSpecifcOrigins";

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: myAllowSpecifcOrigins, policy =>
      {
          policy.WithOrigins("http://localhost:4200");
          policy.AllowAnyMethod();
          policy.AllowAnyHeader();
      });
});

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<BestWalletContext>();

builder.Services.AddTransient<IUsuarioService, UsuarioService>();


//ignoramos los ciclos
builder.Services.AddControllers().AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(myAllowSpecifcOrigins);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
