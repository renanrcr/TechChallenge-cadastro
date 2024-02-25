using AutoMapper;
using TechChallenge.Api.DTOs;
using TechChallenge.src.Core.Domain.Entities;

namespace TechChallenge.src.Core.Domain.AutoMapper
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<ClienteDTO, Cliente>().ReverseMap();
            CreateMap<CategoriaProdutoDTO, CategoriaProduto>().ReverseMap();
            CreateMap<ProdutoDTO, Produto>().ReverseMap();
        }
    }
}