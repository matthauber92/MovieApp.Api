using MovieApp.Application.Interfaces;
using MovieApp.Application.Services;
using MovieApp.Infrastructure.Providers;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddHttpClient<ITmdbProvider, TmdbProvider>(client =>
{
    client.BaseAddress = new Uri("https://api.themoviedb.org/3/");
});


builder.Services.AddScoped<IMovieCatalogService, MovieCatalogService>();
builder.Services.AddScoped<ITvCatalogService, TvCatalogService>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("LocalDev", policy =>
    {
        policy
            .WithOrigins(
                "http://localhost:3000",
                "http://localhost:5173" // Vite default
            )
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "VP AI API V1");
    });
}

app.UseHttpsRedirection();
app.MapControllers();
app.UseCors("LocalDev");

app.Run();