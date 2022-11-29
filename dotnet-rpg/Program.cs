global using dotnet_rpg.Models;
global using dotnet_rpg.Services.CharacterService;
global using AutoMapper;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add AutoMapper Services 
builder.Services.AddAutoMapper(typeof(Program).Assembly);
// add the ICharacterService
// AddTransient - Provides a new instance to every controller and to every service even within the same request
// AddSingleton - Create only one instance that is used for every request 
// AddScoped - 
builder.Services.AddScoped<ICharacterService, CharacterService>();



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
