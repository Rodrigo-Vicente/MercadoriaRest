using Application.DTOs;
using Application.Interfaces;
using AutoMapper;
using Domain.Entity;
using Domain.Interface;

namespace Application.Services
{
    public class MercadoriaService : IMercadoriaService
    {
        private IMercadoriaRepository _mercadoriaRepository;
        private readonly IMapper _mapper;

        public MercadoriaService(IMercadoriaRepository mercadoriaRepository, IMapper mapper)
        {
            _mercadoriaRepository = mercadoriaRepository;
            _mapper = mapper;
        }

        public async Task Add(MercadoriaDTO mercadoriaDTO)
        {
            var novaMercadoria = _mapper.Map<Mercadoria>(mercadoriaDTO);
            await _mercadoriaRepository.CreateMercadoria(novaMercadoria);
            mercadoriaDTO.Id = novaMercadoria.Id;
        }

        public async Task<IEnumerable<MercadoriaDTO>> GetMercadoria()
        {
            var mercadorias = await _mercadoriaRepository.GetALL();
            return _mapper.Map<IEnumerable<MercadoriaDTO>>(mercadorias);
        }

        public async Task Remove(int? id)
        {
            var mercadoria = _mercadoriaRepository.GetById(id).Result;
            await _mercadoriaRepository.DeleteMercadoria(mercadoria);
        }

        public async Task Update(MercadoriaDTO mercadoriaDTO)
        {
            var mercadoria = _mapper.Map<Mercadoria>(mercadoriaDTO);
            await _mercadoriaRepository.UpdateMercadoria(mercadoria);
        }

        public async Task<MercadoriaDTO> GetById(int id)
        {
            var mercadoria = await _mercadoriaRepository.GetById(id);
            return _mapper.Map<MercadoriaDTO>(mercadoria);
        }
    }
}
