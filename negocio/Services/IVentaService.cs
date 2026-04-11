using PruebaTecnica.data.Models;
using PruebaTecnica.data.Models.DTOs;

namespace PruebaTecnica.negocio.Services
{
    public interface IVentaService
    {
        Task<IEnumerable<Venta>> GetAllWithDetailsAsync();
        Task<IEnumerable<VehiculoVendidoDto>> GetVehiculosPorVendedorAsync(string cedula);
        Task DeleteAsync(int id);
    }
}
