using PruebaTecnica.data.Models;
using PruebaTecnica.data.Models.DTOs;
using PruebaTecnica.data.Repositories;

namespace PruebaTecnica.negocio.Services
{
    public class VentaService(IVentaRepository ventaRepository) : IVentaService
    {
        private readonly IVentaRepository _ventaRepository = ventaRepository;

        public async Task<IEnumerable<Venta>> GetAllWithDetailsAsync()
        {
            try
            {
                return await _ventaRepository.GetAllWithDetailsAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error en el servicio al obtener las ventas", ex);
            }
        }

        public async Task<IEnumerable<VehiculoVendidoDto>> GetVehiculosPorVendedorAsync(string cedula)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(cedula))
                    throw new Exception("La cédula no puede estar vacía");

                return await _ventaRepository.GetVehiculosPorVendedorAsync(cedula);
            }
            catch (Exception ex)
            {
                throw new Exception("Error en el servicio al consultar ventas por vendedor", ex);
            }
        }

        public async Task DeleteAsync(int id)
        {
            try
            {
                if (id <= 0)
                    throw new Exception("El Id de la venta no es válido");

                await _ventaRepository.DeleteAsync(id);
            }
            catch (Exception ex)
            {
                throw new Exception("Error en el servicio al eliminar la venta", ex);
            }
        }
    }
}
