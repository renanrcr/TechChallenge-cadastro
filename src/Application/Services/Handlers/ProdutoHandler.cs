using AutoMapper;
using MediatR;
using Application.Services;
using Domain.Adapters;
using Domain.Entities;
using Application.DTOs;
using Application.Commands.Produtos;

namespace TechChallenge.src.Handlers
{
    public class ProdutoHandler : BaseService,
        IRequestHandler<CadastraProdutoCommand, ProdutoDTO>,
        IRequestHandler<AtualizaProdutoCommand, ProdutoDTO>,
        IRequestHandler<DeletaProdutoCommand, ProdutoDTO>
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly IMapper _mapper;

        public ProdutoHandler(INotificador notificador, 
            IProdutoRepository produtoRepository,
            IMapper mapper)
            : base(notificador)
        {
            _produtoRepository = produtoRepository;
            _mapper = mapper;
        }

        public async Task<ProdutoDTO> Handle(CadastraProdutoCommand request, CancellationToken cancellationToken)
        {
            var entidade = await new Produto().Cadastrar(request.CategoriaProdutoId, request.Nome, request.Descricao);

            Notificar(entidade.ValidationResult);

            if (entidade.IsValid)
                await _produtoRepository.Adicionar(entidade);

            return _mapper.Map<ProdutoDTO>(entidade);
        }

        public async Task<ProdutoDTO> Handle(AtualizaProdutoCommand request, CancellationToken cancellationToken)
        {
            var entidade = await _produtoRepository.ObterPorId(request.Id);
            await entidade.Atualizar(request.Id, request.CategoriaProdutoId, request.Nome, request.Descricao);

            Notificar(entidade.ValidationResult);

            if (entidade.IsValid)
                await _produtoRepository.Atualizar(entidade);

            return _mapper.Map<ProdutoDTO>(entidade);
        }

        public async Task<ProdutoDTO> Handle(DeletaProdutoCommand request, CancellationToken cancellationToken)
        {
            var entidade = await new Produto().Deletar(request.Id);

            Notificar(entidade.ValidationResult);

            if (entidade.IsValid)
                await _produtoRepository.Remover(entidade);

            return _mapper.Map<ProdutoDTO>(entidade);
        }
    }
}