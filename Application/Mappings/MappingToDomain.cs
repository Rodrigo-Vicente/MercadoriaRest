using Application.DTOs;
using AutoMapper;
using Domain.Entity;

namespace Application.Mappings
{
    public class MappingToDomain : Profile
    {
       public MappingToDomain()
        {
            CreateMap<Mercadoria, MercadoriaDTO>().ReverseMap();
            CreateMap<EntradaMercadoria, EntradaMercadoriaDTO>().ReverseMap();
            CreateMap<SaidaMercadoria, SaidaMercadoriaDTO>().ReverseMap();
        }
    }
}
