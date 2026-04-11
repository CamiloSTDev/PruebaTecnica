using PruebaTecnica.data.Models;

namespace PruebaTecnica.negocio.Services
{
    public interface IMarcaService
    {
        Task AddAsync(Marca marca);
    }
}
