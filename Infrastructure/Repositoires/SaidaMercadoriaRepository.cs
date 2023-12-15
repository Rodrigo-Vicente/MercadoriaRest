using Domain.Entity;
using Domain.Interface;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositoires
{
    public class SaidaMercadoriaRepository : ISaidaMercadoriaRepository
    {
        private ApplicationContext _context;

        public SaidaMercadoriaRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<SaidaMercadoria> CreateSaidaMercadoria(SaidaMercadoria saidaMercadoria)
        {
            _context.Add(saidaMercadoria);
            await _context.SaveChangesAsync();
            return saidaMercadoria;
        }

        public async Task<SaidaMercadoria> DeleteSaidaMercadoria(SaidaMercadoria saidaMercadoria)
        {
            _context.Remove(saidaMercadoria);
            await _context.SaveChangesAsync();
            return saidaMercadoria;
        }

        public async Task<IEnumerable<SaidaMercadoria>> GetALL()
        {
            return await _context.SaidaMercadorias.OrderBy(c => c.DataHora).ToListAsync();
        }

        public async Task<SaidaMercadoria> GetById(int? id)
        {
            var mercadoria = await _context.SaidaMercadorias.FindAsync(id);
            return mercadoria;
        }

        public async Task<SaidaMercadoria> UpdateSaidaMercadoria(SaidaMercadoria saidaMercadoria)
        {
            _context.Update(saidaMercadoria);
            await _context.SaveChangesAsync();
            return saidaMercadoria;
        }
    }
}
