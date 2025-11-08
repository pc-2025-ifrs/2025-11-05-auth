using Microsoft.EntityFrameworkCore;
using Steam.Models;
using WebSteam.Models;

namespace Steam.Data;

public class SteamDbContext : DbContext
{
    // construtor
    public SteamDbContext(DbContextOptions<SteamDbContext> options) : base(options)
    {
        // Database.EnsureDeleted();
        Database.EnsureCreated();
    }
    // Declarando uma Tabela <-> Classe
    public DbSet<Developer> Developers { get; set; }

    public DbSet<Session> Sessions { get; set; }

    protected override void OnModelCreating(ModelBuilder model)
    {
        model.Entity<Session>().HasData([
            new Session { Token = "test-token", User = "test-user", ExpiresAt = DateTime.UtcNow.AddDays(30) }
        ]);
    }

}