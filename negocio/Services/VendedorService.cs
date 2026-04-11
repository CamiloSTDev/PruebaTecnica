using PruebaTecnica.data.Models;
using PruebaTecnica.data.Repositories;

namespace PruebaTecnica.negocio.Services
{
    public class VendedorService(IVendedorRepository vendedorRepository) : IVendedorService
    {
        private readonly IVendedorRepository _vendedorRepository = vendedorRepository;

        public async Task<IEnumerable<Vendedor>> GetAllAsync()
        {
            try
            {
                return await _vendedorRepository.GetAllAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error en el servicio al obtener vendedores", ex);
            }
        }

        public async Task<Vendedor> GetByIdAsync(int id)
        {
            try
            {
                var vendedor = await _vendedorRepository.GetByIdAsync(id);
                if (vendedor == null)
                    throw new Exception($"No se encontró un vendedor con Id {id}");

                return vendedor;
            }
            catch (Exception ex)
            {
                throw new Exception("Error en el servicio al obtener el vendedor", ex);
            }
        }

        public async Task<Vendedor> GetByCedulaAsync(string cedula)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(cedula))
                    throw new Exception("La cédula no puede estar vacía");

                var vendedor = await _vendedorRepository.GetByCedulaAsync(cedula);
                if (vendedor == null)
                    throw new Exception($"No se encontró un vendedor con cédula {cedula}");

                return vendedor;
            }
            catch (Exception ex)
            {
                throw new Exception("Error en el servicio al buscar el vendedor", ex);
            }
        }

        public async Task UpdateAsync(Vendedor vendedor)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(vendedor.Nombre))
                    throw new Exception("El nombre del vendedor no puede estar vacío");

                if (string.IsNullOrWhiteSpace(vendedor.Cedula))
                    throw new Exception("La cédula del vendedor no puede estar vacía");

                var existente = await _vendedorRepository.GetByIdAsync(vendedor.Id);
                if (existente == null)
                    throw new Exception("El vendedor que intenta actualizar no existe");

                await _vendedorRepository.UpdateAsync(vendedor);
            }
            catch (Exception ex)
            {
                throw new Exception("Error en el servicio al actualizar el vendedor", ex);
            }
        }
    }
}
