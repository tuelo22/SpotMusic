using IdentityServer4.Models;
using Microsoft.Extensions.DependencyInjection;
using SpotMusic.STS;
using SpotMusic.STS.Data;
using SpotMusic.STS.GrantType;
using SpotMusic.STS.ProfileService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.Configure<DataBaseOption>(builder.Configuration.GetSection("ConnectionStrings"));
builder.Services.AddScoped<IIdentityRepository, IdentityRepository>();

builder.Services.AddIdentityServer()
                .AddDeveloperSigningCredential()
                .AddInMemoryIdentityResources(IdentityServerConfiguration.GetIdentityResource())
                .AddInMemoryApiResources(IdentityServerConfiguration.GetApiResource())
                .AddInMemoryApiScopes(IdentityServerConfiguration.GetApiScopes())
                .AddInMemoryClients(IdentityServerConfiguration.GetClients())
                .AddProfileService<ProfileService>()
                .AddResourceOwnerValidator<ResourceOwnerPasswordValidator>();

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
    app.UseSwagger();
    app.UseSwaggerUI();
//}

app.UseHttpsRedirection();

app.UseIdentityServer();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();