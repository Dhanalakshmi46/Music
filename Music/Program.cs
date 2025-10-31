using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Music.Data;
using Music.Profiles;
using Music.Repositories;
using Music.Services;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Read from appsettings.json
var useInMemory = builder.Configuration.GetValue<bool>("UseInMemoryDatabase");
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

if (useInMemory)
{
    builder.Services.AddDbContext<MusicDbContext>(opt =>
        opt.UseInMemoryDatabase("MusicDB"));
}
else
{
    builder.Services.AddDbContext<MusicDbContext>(opt =>
        opt.UseSqlServer(connectionString));
}

// AutoMapper
builder.Services.AddAutoMapper(typeof(MappingProfile));

// Repositories
builder.Services.AddScoped<ISongRepository, SongRepository>();
builder.Services.AddScoped<IMovieRepository, MovieRepository>();
builder.Services.AddScoped<ISingerRepository, SingerRepository>();

// Services
builder.Services.AddScoped<ISongService, SongService>();
builder.Services.AddScoped<IMovieService, MovieService>();
builder.Services.AddScoped<ISingerService, SingerService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();
app.Run();
