using Domain.Entity;

namespace Domain.Interface
{
    public interface ISaidaMercadoriaRepository
    {
        Task<IEnumerable<SaidaMercadoria>> GetALL();
        Task<SaidaMercadoria> GetById(int? id);
        Task<SaidaMercadoria> CreateSaidaMercadoria(SaidaMercadoria saidaMercadoria);
        Task<SaidaMercadoria> UpdateSaidaMercadoria(SaidaMercadoria saidaMercadoria);
        Task<SaidaMercadoria> DeleteSaidaMercadoria(SaidaMercadoria saidaMercadoria);
    }
}
