using Domain.Entity;
using Domain.Interface;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositoires
{
    public class MercadoriaRepository : IMercadoriaRepository
    {
        private ApplicationContext _context;
        public MercadoriaRepository(ApplicationContext context)
        {
            _context = context;
        }
        public async Task<Mercadoria> CreateMercadoria(Mercadoria mercadoria)
        {
            _context.Add(mercadoria);
            await _context.SaveChangesAsync();
            return mercadoria;
        }

        public async Task<Mercadoria> DeleteMercadoria(Mercadoria mercadoria)
        {
            _context.Remove(mercadoria);
            await _context.SaveChangesAsync();
            return mercadoria;
        }

        public async Task<IEnumerable<Mercadoria>> GetALL()
        {
            return await _context.Mercadorias.OrderBy(c => c.Nome).ToListAsync();
        }

        public async Task<Mercadoria> GetById(int? id)
        {
            var mercadoria = await _context.Mercadorias.FindAsync(id);
            return mercadoria;
        }

        public async Task<Mercadoria> UpdateMercadoria(Mercadoria mercadoria)
        {
            _context.Update(mercadoria);
            await _context.SaveChangesAsync();
            return mercadoria;
        }
    }
}
