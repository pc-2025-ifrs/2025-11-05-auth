using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Steam.Data;
using Steam.Repositories;
using WebSteam.Auth;

var builder = WebApplication.CreateBuilder(args);


// Add Authentication and Authorization
builder.Services.AddScoped<SessionStoreService>();
builder.Services.AddAuthorization();
builder.Services.AddAuthentication().AddScheme<AuthenticationSchemeOptions, SimpleBearerAuthenticationHandler>("SimpleBearer", options => { });



// Add DataBase Context
builder.Services.AddDbContext<SteamDbContext>(options =>
{
    options.UseSqlite(builder.Configuration.GetConnectionString("sqlite"));
});

// Add services to the container.
builder.Services.AddControllers();

// Add repositories (diz que a aplicação tem repositórios)
// builder.Services.AddSingleton<IDeveloperRepository, InMemoryDeveloperRepository>();

builder.Services.AddScoped<IDeveloperRepository, PersistentDeveloperRepository>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// ativar autenticação e autorização
app.UseAuthentication();
app.UseAuthorization();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
