using MovieApp.Application.Interfaces;
using MovieApp.Application.Services;
using MovieApp.Infrastructure.Providers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
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

app.Run();