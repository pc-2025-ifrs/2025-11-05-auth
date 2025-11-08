using Steam.Models;

namespace Steam.Repositories;

// ABSTRAÇÃO, CONTRATO
public interface IDeveloperRepository
{
    // É possível salvar devs, como? Não é definido aqui.
    public void Save(Developer dev);

    public IEnumerable<Developer> GetAll();
}