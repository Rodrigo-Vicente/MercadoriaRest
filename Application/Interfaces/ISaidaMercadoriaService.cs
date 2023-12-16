using Application.DTOs;

namespace Application.Interfaces
{
    public interface ISaidaMercadoriaService
    {
        Task<IEnumerable<SaidaMercadoriaDTO>> GetSaidas();
        Task<SaidaMercadoriaDTO> GetById(int id);
        Task Add(SaidaMercadoriaDTO saidaMercadoriaDTO);
        Task Update(SaidaMercadoriaDTO saidaMercadoriaDTO);
        Task Remove(int? id);
        Task<List<SaidaMercadoriaDTO>> GetByMercadoriaId(int Mercadoriaid);
    }
}
