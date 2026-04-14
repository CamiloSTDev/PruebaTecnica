using PruebaTecnica.data.Models;

namespace PruebaTecnica.negocio.Services
{
    public interface IMarcaService
    {
        Task<IEnumerable<Marca>> GetAllAsync();
        Task AddAsync(Marca marca);
    }
}
