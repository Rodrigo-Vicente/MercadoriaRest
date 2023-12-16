using Application.DTOs;

namespace Application.Interfaces
{
    public interface IEntradaMercadoriaService
    {
        Task<IEnumerable<EntradaMercadoriaDTO>> GetEntradas();
        Task<EntradaMercadoriaDTO> GetById(int id);
        Task Add(EntradaMercadoriaDTO entradaMercadoriaDTO);
        Task Update(EntradaMercadoriaDTO entradaMercadoriaDTO);
        Task Remove(int? id);
        Task<List<EntradaMercadoriaDTO>> GetByMercadoriaId(int Mercadoriaid);
    }
}
