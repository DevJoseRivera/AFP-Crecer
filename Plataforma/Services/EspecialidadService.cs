using Domain.Core;
using Domain.Core.MedicalCenter.Models;
using Microsoft.EntityFrameworkCore;
using Services.MedicalCenter.Contracts;

namespace Services
{
    public class EspecialidadService : IGenericService<Especialidad>
    {
        private readonly AfpCrecerDbContext _ctx;

        public EspecialidadService(AfpCrecerDbContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<IEnumerable<Especialidad>> GetItemsAsync()
            => await _ctx.Especialidad.ToListAsync();

        public async Task<Especialidad?> GetItemAsync(int id)
            => await _ctx.Especialidad.FirstOrDefaultAsync(item => item.Id == id);

        public async Task<Especialidad> SaveItemAsync(Especialidad entity)
        {
            var item = _ctx.Especialidad.Add(entity);

            await _ctx.SaveChangesAsync();

            return item.Entity;
        }

        public async Task UpdateItemAsync(Especialidad entity)
        {
            _ctx.Especialidad.Update(entity);

            await _ctx.SaveChangesAsync();
        }

        public async Task DeleteItemAsync(int id)
        {
            var item = await GetItemAsync(id);

            if (item is null)
                throw new InvalidOperationException("Not Found");

            _ctx.Especialidad.Remove(item);

            await _ctx.SaveChangesAsync();
        }
    }
}
