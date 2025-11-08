namespace Steam.Repositories;

using Steam.Models;

// CONCRETO (herança de interface), implementação do vvvvv
public class InMemoryDeveloperRepository : IDeveloperRepository
{

    private readonly Dictionary<Guid, Developer> _memory = [];

    public void Save(Developer dev)
    {
        // novo id
        var id = Guid.NewGuid();
        // atribui o id ao dev
        dev.Id = id;
        // coloca o dev no dicionário
        _memory[id] = dev;
        
    }

    public IEnumerable<Developer> GetAll() => _memory.Values;
    
}