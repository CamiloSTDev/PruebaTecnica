using PruebaTecnica.data.Models;

namespace PruebaTecnica.data.Repositories
{
    public interface IVendedorRepository
    {
        Task<IEnumerable<Vendedor>> GetAllAsync();
        Task<Vendedor> GetByIdAsync(int id);
        Task<Vendedor> GetByCedulaAsync(string cedula);
        Task UpdateAsync(Vendedor vendedor);
    }
}
