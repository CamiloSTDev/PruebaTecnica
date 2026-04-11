using Microsoft.EntityFrameworkCore;
using PruebaTecnica.data.Context;
using PruebaTecnica.data.Models;

namespace PruebaTecnica.data.Repositories
{
    public class MarcaRepository(AppDbContext dbContext) : IMarcaRepository
    {
        private readonly AppDbContext _dbContext = dbContext;

        public async Task AddAsync(Marca marca)
        {
            try
            {
                await _dbContext.Marcas.AddAsync(marca);
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al crear la marca", ex);
            }
        }
    }
}
