using Domain.Entity;
using Domain.Interface;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositoires
{
    public class EntradaMercadoriaRepository : IEntradaMercadoriaRepository
    {
        private ApplicationContext _context;

        public EntradaMercadoriaRepository(ApplicationContext context)
        {
            _context = context;
        }
        public async Task<EntradaMercadoria> CreateEntradaMercadoria(EntradaMercadoria entradaMercadoria)
        {
            _context.Add(entradaMercadoria);
            await _context.SaveChangesAsync();
            return entradaMercadoria;
        }

        public async Task<EntradaMercadoria> DeleteEntradaMercadoria(EntradaMercadoria entradaMercadoria)
        {
            _context.Remove(entradaMercadoria);
            await _context.SaveChangesAsync();
            return entradaMercadoria;
        }

        public async Task<IEnumerable<EntradaMercadoria>> GetALL()
        {
            return await _context.EntradaMercadorias.OrderBy(c => c.DataHora).ToListAsync();
        }

        public async Task<EntradaMercadoria> GetById(int? id)
        {
            var mercadoria = await _context.EntradaMercadorias.FindAsync(id);
            return mercadoria;
        }

        public async Task<EntradaMercadoria> UpdateEntradaMercadoria(EntradaMercadoria entradaMercadoria)
        {
            _context.Update(entradaMercadoria);
            await _context.SaveChangesAsync();
            return entradaMercadoria;
        }
    }
}
