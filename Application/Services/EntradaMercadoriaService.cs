using Application.DTOs;
using Application.Interfaces;
using AutoMapper;
using Domain.Entity;
using Domain.Interface;

namespace Application.Services
{
    public class EntradaMercadoriaService : IEntradaMercadoriaService
    {
        private IEntradaMercadoriaRepository _entradaMercadoriaRepository;
        private readonly IMapper _mapper;
        public EntradaMercadoriaService(IEntradaMercadoriaRepository entradaMercadoriaRepository, IMapper mapper)
        {
            _entradaMercadoriaRepository = entradaMercadoriaRepository;
            _mapper = mapper;
        }
        public async Task Add(EntradaMercadoriaDTO entradaMercadoriaDTO)
        {
            var novaEntrada = _mapper.Map<EntradaMercadoria>(entradaMercadoriaDTO);
            await _entradaMercadoriaRepository.CreateEntradaMercadoria(novaEntrada);
            entradaMercadoriaDTO.id = novaEntrada.Id;
        }

        public async Task<IEnumerable<EntradaMercadoriaDTO>> GetEntradas()
        {
            var mercadoriaEntrada = await _entradaMercadoriaRepository.GetALL();
            return _mapper.Map<IEnumerable<EntradaMercadoriaDTO>>(mercadoriaEntrada);
        }

        public async Task Remove(int? id)
        {
            var entrada = _entradaMercadoriaRepository.GetById(id).Result;
            await _entradaMercadoriaRepository.DeleteEntradaMercadoria(entrada);
        }

        public async Task Update(EntradaMercadoriaDTO entradaMercadoriaDTO)
        {
            var entrada = _mapper.Map<EntradaMercadoria>(entradaMercadoriaDTO);
            await _entradaMercadoriaRepository.UpdateEntradaMercadoria(entrada);
        }

        public async Task<EntradaMercadoriaDTO> GetById(int id)
        {
            var entrada = await _entradaMercadoriaRepository.GetById(id);
            return _mapper.Map<EntradaMercadoriaDTO>(entrada);
        }

        public async Task<List<EntradaMercadoriaDTO>> GetByMercadoriaId(int Mercadoriaid)
        {
            var entrada = await _entradaMercadoriaRepository.GetByMercadoriaId(Mercadoriaid);
            return _mapper.Map<List<EntradaMercadoriaDTO>>(entrada);
        }
    }
}
