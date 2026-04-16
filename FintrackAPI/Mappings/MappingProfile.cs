using AutoMapper;
using FintrackAPI.DTOs.Categoria;
using FintrackAPI.DTOs.TipoTransacao;
using FintrackAPI.DTOs.Transacao;
using FintrackAPI.Models;

namespace FintrackAPI.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        // Categoria
        CreateMap<Categoria, CategoriaResponseDTO>();
        CreateMap<CategoriaRequestDTO, Categoria>();

        // TipoTransacao
        CreateMap<TipoTransacao, TipoTransacaoResponseDTO>();
        CreateMap<TipoTransacaoRequestDTO, TipoTransacao>();

        // Transacao
        CreateMap<Transacao, TransacaoResponseDTO>()
            .ForMember(dest => dest.CategoriaNome, opt => opt.MapFrom(src => src.Categoria!.Nome))
            .ForMember(dest => dest.TipoTransacaoNome, opt => opt.MapFrom(src => src.TipoTransacao!.Nome));
        CreateMap<TransacaoRequestDTO, Transacao>();
    }
}