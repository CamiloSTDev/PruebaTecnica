using PruebaTecnica.data.Models;

namespace PruebaTecnica.data.Repositories
{
    public interface IMarcaRepository
    {
        Task AddAsync(Marca marca);
    }
}
