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
        private readonly IClienteRepository _clienteRepository;

        public AutoMapperConfigTests()
        {
            var config = new MapperConfiguration(cfg => cfg.AddProfile<AutoMapperConfig>());
            _mapper = config.CreateMapper();
            _produtoRepository = IProdutoRepositoryMock.GetMock();
            _clienteRepository = IClienteRepositoryMock.GetMock();
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

        [Fact]
        public async Task MapearClienteParaClienteDto_DeveRetornarVerdadeiro()
        {
            // Arrange
            Cliente? cliente = await new Cliente().Cadastrar(_clienteRepository, "Cliente I", "cliente@mail.com");

            // Act
            ClienteDTO clienteDTO = _mapper.Map<ClienteDTO>(cliente);

            // Assert
            Assert.Equal(cliente.Nome, clienteDTO.Nome);
        }

        [Fact]
        public async Task MapearCategoriaProdutoParaCategoriaProdutoDto_DeveRetornarVerdadeiro()
        {
            // Arrange
            CategoriaProduto? categoria = await new CategoriaProduto().Cadastrar("Categoria Lanche");

            // Act
            CategoriaProdutoDTO categoriaProdutoDTO = _mapper.Map<CategoriaProdutoDTO>(categoria);

            // Assert
            Assert.Equal(categoria.Descricao, categoriaProdutoDTO.Descricao);
        }
    }
}
