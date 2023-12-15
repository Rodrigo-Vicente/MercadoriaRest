using Domain.Entity;

namespace Domain.Interface
{
    public interface IMercadoriaRepository
    {
        Task<IEnumerable<Mercadoria>> GetALL();
        Task<Mercadoria> GetById(int? id);
        Task<Mercadoria> CreateMercadoria(Mercadoria mercadoria);
        Task<Mercadoria> UpdateMercadoria(Mercadoria mercadoria);
        Task<Mercadoria> DeleteMercadoria(Mercadoria mercadoria);
    }
}
