using Domain.Entity;

namespace Domain.Interface
{
    public interface IEntradaMercadoriaRepository
    {
        Task<IEnumerable<EntradaMercadoria>> GetALL();
        Task<EntradaMercadoria> GetById(int? id);
        Task<EntradaMercadoria> CreateEntradaMercadoria(EntradaMercadoria entradaMercadoria);
        Task<EntradaMercadoria> UpdateEntradaMercadoria(EntradaMercadoria entradaMercadoria);
        Task<EntradaMercadoria> DeleteEntradaMercadoria(EntradaMercadoria entradaMercadoria);
    }
}
