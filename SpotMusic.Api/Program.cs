using Microsoft.EntityFrameworkCore;
using SpotMusic.Application.Conta;
using SpotMusic.Application.Conta.Profile;
using SpotMusic.Application.Streaming;
using SpotMusic.Repository;
using SpotMusic.Repository.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<SpotMusicContext>(c =>
{
    c.UseLazyLoadingProxies()
     .UseSqlServer(builder.Configuration.GetConnectionString("SpotMusicConnection"));
});

builder.Services.AddAutoMapper(typeof(UsuarioProfile).Assembly);

// Repository
builder.Services.AddScoped<UsuarioRepository>();
builder.Services.AddScoped<PlanoRepository>();
builder.Services.AddScoped<AutorRepository>();
builder.Services.AddScoped<EstiloMusicalRepository>();
builder.Services.AddScoped<AlbumRepository>();

// Service
builder.Services.AddScoped<UsuarioService>();
builder.Services.AddScoped<AutorService>();
builder.Services.AddScoped<AlbumService>();
builder.Services.AddScoped<CartaoService>();

builder.Services.AddCors(c =>
{
    c.AddDefaultPolicy(builder =>
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

app.MapControllers();

app.Run();
