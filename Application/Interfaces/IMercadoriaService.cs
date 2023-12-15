using Application.DTOs;

namespace Application.Interfaces
{
    public interface IMercadoriaService
    {
        Task<IEnumerable<MercadoriaDTO>> GetMercadoria();
        Task<MercadoriaDTO> GetById(int id);
        Task Add(MercadoriaDTO mercadoriaDTO);
        Task Update(MercadoriaDTO mercadoriaDTO);
        Task Remove(int? id);
    }
}
