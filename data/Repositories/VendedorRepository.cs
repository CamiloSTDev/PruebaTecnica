using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using PruebaTecnica.data.Context;
using PruebaTecnica.data.Models;

namespace PruebaTecnica.data.Repositories
{
    public class VendedorRepository(AppDbContext dbContext) : IVendedorRepository
    {
        private readonly AppDbContext _dbContext = dbContext;

        public async Task<IEnumerable<Vendedor>> GetAllAsync()
        {
            try
            {
                return await _dbContext.Vendedores.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener los vendedores", ex);
            }
        }

        public async Task<Vendedor> GetByIdAsync(int id)
        {
            try
            {
                return await _dbContext.Vendedores.FindAsync(id);
            }
            catch
            {
                throw new Exception("Error al obtener el vendedor por ID");
            }
        }

        public async Task<Vendedor> GetByCedulaAsync(string cedula)
        {
            try
            {
                return await _dbContext.Vendedores.FirstOrDefaultAsync(v => v.Cedula == cedula);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al buscar el vendedor con cédula {cedula}", ex);
            }
        }

        public async Task UpdateAsync(Vendedor vendedor)
        {
            try
            {
                var local = _dbContext.Vendedores.Local.FirstOrDefault(v => v.Id == vendedor.Id);
                if (local != null)
                {
                    // borra la entidad antigua guardada en cache para evitar conflictos
                    _dbContext.Entry(local).State = EntityState.Detached;
                }

                //actualiza vendedor con los nuevos datos
                _dbContext.Vendedores.Update(vendedor);
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar el vendedor", ex);
            }
        }

    }
}
