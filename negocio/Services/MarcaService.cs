using PruebaTecnica.data.Models;
using PruebaTecnica.data.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace PruebaTecnica.negocio.Services
{
    public class MarcaService(IMarcaRepository marcaRepository) : IMarcaService
    {
        private readonly IMarcaRepository _marcaRepository = marcaRepository;

        public async Task<IEnumerable<Marca>> GetAllAsync()
        {
            try
            {
                return await _marcaRepository.GetAllAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error en el servicio al obtener las marcas", ex);
            }
        }

        public async Task AddAsync(Marca marca)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(marca.Nombre))
                    throw new Exception("El nombre de la marca no puede estar vacío");

                await _marcaRepository.AddAsync(marca);
            }
            catch (Exception ex)
            {
                throw new Exception("Error en el servicio al crear la marca", ex);
            }
        }
    }
}
