using Microsoft.OpenApi.Models;
using Rick_MortyAPI.Models.Domain;
using Rick_MortyAPI.Services;
using RickAndMortyAPI.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "RickAndMortyAPI", Version = "v1" });
});
builder.Services.AddSingleton<IRickAndMortyService, RickAndMortyService>();
builder.Services.AddSingleton<IRickAndMortyMapper, RickAndMortyMapper>();
builder.Services.AddHttpClient<RickAndMortyService>(client =>
{
    client.BaseAddress = new Uri("https://rickandmortyapi.com/api/");
});


var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "RickAndMortyAPI v1");
    
});

app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

app.Run();
