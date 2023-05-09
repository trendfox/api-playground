using ApiPlayground.P02.PersonApi.Models;
using Dto = ApiPlayground.P02.PersonApi.Models.DTOs;
using ApiPlayground.P02.PersonApi.Services;
using ApiPlayground.P02.PersonApi.Services.Interfaces;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSingleton<IStore<Person>, MemoryDictionaryStore<Person>>();
builder.Services.AddSingleton<IMapper<Person, Dto.Person>, PersonMapper>();

builder.Services.AddControllers()
    .AddJsonOptions(x =>
    {
        // Use string converter for enums instead of ints
        x.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    });

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
