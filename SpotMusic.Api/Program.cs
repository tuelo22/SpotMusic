using IdentityModel;
using IdentityServer4.AccessTokenValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
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

builder.Services.AddSwaggerGen(c =>
{
    c.AddSecurityDefinition("Bearer", new Microsoft.OpenApi.Models.OpenApiSecurityScheme()
    {
        In = Microsoft.OpenApi.Models.ParameterLocation.Header,
        Name = "Authorization",
        Type = Microsoft.OpenApi.Models.SecuritySchemeType.ApiKey,
        Description = "Adicione o token JWT para fazer as requisições na APIs",
        Scheme = "Bearer"
    });

    c.AddSecurityRequirement(new Microsoft.OpenApi.Models.OpenApiSecurityRequirement()
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            Array.Empty<string>()
        }
    });

});
builder.Services.AddDbContext<SpotMusicContext>(c =>
{
    c.UseLazyLoadingProxies()
     .UseSqlServer(builder.Configuration.GetConnectionString("SpotMusicConnection"));
});

builder.Services.AddAutoMapper(typeof(UsuarioProfile).Assembly);

builder.Services.AddAuthentication(IdentityServerAuthenticationDefaults.AuthenticationScheme)
    .AddIdentityServerAuthentication(options =>
    {
        options.Authority = "https://spotmusic-sts.azurewebsites.net";
        options.ApiName = "SpotMusic";
        options.ApiSecret = "SpotMusic";
        options.RequireHttpsMetadata = true;
    });
builder.Services.AddAuthorization(optons =>
{
    optons.AddPolicy("SpotMusic", p =>
    {
        p.RequireClaim("role", "SpotMusicScope");

    });
});

// Repository
builder.Services.AddScoped<UsuarioRepository>();
builder.Services.AddScoped<PlanoRepository>();
builder.Services.AddScoped<AutorRepository>();
builder.Services.AddScoped<EstiloMusicalRepository>();
builder.Services.AddScoped<AlbumRepository>();
builder.Services.AddScoped<MusicaRepository>();

// Service
builder.Services.AddScoped<UsuarioService>();
builder.Services.AddScoped<AutorService>();
builder.Services.AddScoped<AlbumService>();
builder.Services.AddScoped<CartaoService>();
builder.Services.AddScoped<MusicaService>();
builder.Services.AddScoped<EstiloMusicalService>();

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
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//} 

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();


app.MapControllers();

app.Run();