using PruebaTecnica.data.Models;
using PruebaTecnica.data.Models.DTOs;

namespace PruebaTecnica.data.Repositories
{
    public interface IVentaRepository
    {
        Task<IEnumerable<Venta>> GetAllWithDetailsAsync();
        Task<IEnumerable<VehiculoVendidoDto>> GetVehiculosPorVendedorAsync(string cedula);
        Task DeleteAsync(int id);
    }
}
