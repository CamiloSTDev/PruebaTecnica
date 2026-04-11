using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using PruebaTecnica.data.Context;
using PruebaTecnica.data.Models;
using PruebaTecnica.data.Models.DTOs;

namespace PruebaTecnica.data.Repositories
{
    public class VentaRepository(AppDbContext dbContext) : IVentaRepository
    {
        private readonly AppDbContext _dbContext = dbContext;

        public async Task<IEnumerable<Venta>> GetAllWithDetailsAsync()
        {
            try
            {
                return await _dbContext.Ventas
                    .Include(v => v.Vendedor)
                    .Include(v => v.Vehiculo)
                    .ThenInclude(vh => vh.Marca)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener las ventas", ex);
            }
        }

        public async Task<IEnumerable<VehiculoVendidoDto>> GetVehiculosPorVendedorAsync(string cedula)
        {
            try
            {
                var param = new SqlParameter("@Cedula", cedula);
                return await _dbContext.VehiculosVendidos
                    .FromSqlRaw("EXEC SP_VehiculosPorVendedor @Cedula", param)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al obtener vehículos del vendedor con cédula {cedula}", ex);
            }
        }

        public async Task DeleteAsync(int id)
        {
            try
            {
                var venta = await _dbContext.Ventas.FindAsync(id);
                if (venta != null)
                {
                    _dbContext.Ventas.Remove(venta);
                    await _dbContext.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al eliminar la venta con Id {id}", ex);
            }
        }

        Task<IEnumerable<VehiculoVendidoDto>> IVentaRepository.GetVehiculosPorVendedorAsync(string cedula)
        {
            throw new NotImplementedException();
        }
    }
}
