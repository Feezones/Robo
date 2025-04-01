using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Robo.Services;
using Robo.DataAccess;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<RoboService>();

// L� a string de conex�o do appsettings.json
var configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .Build();

string connectionString = configuration.GetConnectionString("DefaultConnection");

// Registra a DataAccess no cont�iner de depend�ncias
builder.Services.AddSingleton(new RoboDataAccess(connectionString));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configura o CORS para permitir qualquer requisi��o
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

// Aplica a pol�tica de CORS
app.UseCors("AllowAll");

app.MapControllers();

app.Run();
