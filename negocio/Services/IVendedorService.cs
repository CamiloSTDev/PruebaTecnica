using PruebaTecnica.data.Models;


namespace PruebaTecnica.negocio.Services
{
    public interface IVendedorService
    {
        Task<IEnumerable<Vendedor>> GetAllAsync();
        Task<Vendedor> GetByIdAsync(int id);
        Task<Vendedor> GetByCedulaAsync(string cedula);
        Task UpdateAsync(Vendedor vendedor);
    }
}
