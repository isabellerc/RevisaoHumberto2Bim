using Revisao.Application.Interfaces;
using Revisao.Application.Services;
using Revisao.Application.ViewModels;
using Revisao.Domain.Interfaces;
using Revisao.Application.Services;
using Revisao.Application.AutoMapper;
using Revisao.Data.Repositories;
using Revisao.Data.Providers.MongoDB.Interfaces;
using Revisao.Data.Providers.MongoDB.Configuration;
using Microsoft.Extensions.Options;
using Revisao.Data.AutoMapper;
using Revisao.Data.Providers.MongoDB;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(typeof(DomainToApplication), typeof(ApplicationToDomain));
builder.Services.AddAutoMapper(typeof(DomaninToCollection), typeof(CollectionToDomain));

builder.Services.Configure<MongoDbSettings>(
builder.Configuration.GetSection("MongoDBSettings"));

builder.Services.AddSingleton<IMongoDbSettings>(serviceProvider =>
serviceProvider.GetRequiredService<IOptions<MongoDbSettings>>().Value);

builder.Services.AddScoped(typeof(IMongoRepository<>), typeof(MongoRepository<>));
//configurando a injeção de dependencia
builder.Services.AddScoped<ICartaService, CartaService>();
builder.Services.AddScoped<ICartaRepository, CartaRepository>();

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

