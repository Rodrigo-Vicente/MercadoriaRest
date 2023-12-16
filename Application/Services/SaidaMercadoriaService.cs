using Application.DTOs;
using Application.Interfaces;
using AutoMapper;
using Domain.Entity;
using Domain.Interface;

namespace Application.Services
{
    public class SaidaMercadoriaService : ISaidaMercadoriaService
    {
        private ISaidaMercadoriaRepository _saidaMercadoriaRepository;
        private readonly IMapper _mapper;

        public SaidaMercadoriaService(ISaidaMercadoriaRepository saidaMercadoriaRepository, IMapper mapper)
        {
            _saidaMercadoriaRepository = saidaMercadoriaRepository;
            _mapper = mapper;
        }

        public async Task Add(SaidaMercadoriaDTO saidaMercadoriaDTO)
        {
            var novaSaida = _mapper.Map<SaidaMercadoria>(saidaMercadoriaDTO);
            await _saidaMercadoriaRepository.CreateSaidaMercadoria(novaSaida);
            saidaMercadoriaDTO.id = novaSaida.Id;
        }

        public async Task<IEnumerable<SaidaMercadoriaDTO>> GetSaidas()
        {
            var listaSaidas = await _saidaMercadoriaRepository.GetALL();
            return _mapper.Map<IEnumerable<SaidaMercadoriaDTO>>(listaSaidas);
        }

        public async Task Remove(int? id)
        {
            var mercadoriaSaida = _saidaMercadoriaRepository.GetById(id).Result;
            await _saidaMercadoriaRepository.DeleteSaidaMercadoria(mercadoriaSaida);
        }

        public async Task Update(SaidaMercadoriaDTO saidaMercadoriaDTO)
        {
            var saida = _mapper.Map<SaidaMercadoria>(saidaMercadoriaDTO);
            await _saidaMercadoriaRepository.UpdateSaidaMercadoria(saida);
        }

        public async Task<SaidaMercadoriaDTO> GetById(int id)
        {
            var mercadoria = await _saidaMercadoriaRepository.GetById(id);
            return _mapper.Map<SaidaMercadoriaDTO>(mercadoria);
        }

        public async Task<List<SaidaMercadoriaDTO>> GetByMercadoriaId(int Mercadoriaid)
        {
            var saida = await _saidaMercadoriaRepository.GetByMercadoriaId(Mercadoriaid);
            return _mapper.Map<List<SaidaMercadoriaDTO>>(saida);
        }
    }
}
