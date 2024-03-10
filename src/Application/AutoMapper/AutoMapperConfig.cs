using AutoMapper;
using Domain.Entities;
using Application.DTOs;

namespace Application.AutoMapper
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<ClienteDTO, Cliente>().ReverseMap();
            CreateMap<CategoriaProdutoDTO, CategoriaProduto>().ReverseMap();
            CreateMap<ProdutoDTO, Produto>().ReverseMap();
            CreateMap<TabelaPrecoDTO, TabelaPreco>().ReverseMap();
        }
    }
}