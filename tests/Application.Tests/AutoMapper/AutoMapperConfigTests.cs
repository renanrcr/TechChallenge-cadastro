using Application.AutoMapper;
using Application.DTOs;
using AutoMapper;
using Domain.Adapters;
using Domain.Entities;
using Infrastructure.Tests.Adapters;

namespace Application.Tests.AutoMapper
{
    public class AutoMapperConfigTests
    {
        private readonly IMapper _mapper;
        private readonly IProdutoRepository _produtoRepository;

        public AutoMapperConfigTests()
        {
            var config = new MapperConfiguration(cfg => cfg.AddProfile<AutoMapperConfig>());
            _mapper = config.CreateMapper();
            _produtoRepository = IProdutoRepositoryMock.GetMock();
        }

        [Fact]
        public async Task MapearProdutoParaProdutoDto_DeveRetornarVerdadeiro()
        {
            // Arrange
            var categoria = await new CategoriaProduto().Cadastrar("Categoria Lanche");
            Produto? produto = await new Produto().Cadastrar(categoria.Id, "Lanche", "Cadastro do primeiro Lanche");

            // Act
            ProdutoDTO produtoDTO = _mapper.Map<ProdutoDTO>(produto);

            // Assert
            Assert.Equal(produto.Nome, produtoDTO.Nome);
        }
    }
}
