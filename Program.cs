using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Teste.Config;
using Teste.Config.Interface;
using Teste.Services;
using Teste.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

var configBuilder = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddEnvironmentVariables()
    .AddCommandLine(args);


// Adiciona a configuração ao builder
builder.Configuration.AddConfiguration(configBuilder.Build());

builder.Services.Configure<ConfigVariable>(builder.Configuration.GetSection(key: ConfigVariable.CONFIG_NAME));
builder.Services.AddHttpClient();

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddScoped<IStoreService, StoreService>();
builder.Services.AddSingleton<IConfigVariable>(provider => provider.GetRequiredService<IOptions<ConfigVariable>>().Value);


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
