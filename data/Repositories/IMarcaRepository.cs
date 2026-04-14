using PruebaTecnica.data.Models;

namespace PruebaTecnica.data.Repositories
{
    public interface IMarcaRepository
    {
        Task<IEnumerable<Marca>> GetAllAsync();
        Task AddAsync(Marca marca);
    }
}
