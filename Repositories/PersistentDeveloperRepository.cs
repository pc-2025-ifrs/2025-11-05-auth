using Steam.Data;
using Steam.Models;

namespace Steam.Repositories;

// dependência
public class PersistentDeveloperRepository(SteamDbContext ctx) : IDeveloperRepository
{
    public IEnumerable<Developer> GetAll()
    { // SELECT
        return ctx.Developers.ToList();
    }

    public void Save(Developer dev)
    { // INSERT
        ctx.Developers.Add(dev);
        ctx.SaveChanges();
    }
}