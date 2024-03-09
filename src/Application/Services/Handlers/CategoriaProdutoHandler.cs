using AutoMapper;
using MediatR;
using Application.Services;
using Domain.Adapters;
using Domain.Entities;
using Application.DTOs;
using Application.Commands.CategoriaProdutos;

namespace TechChallenge.src.Handlers
{
    public class CategoriaProdutoHandler : BaseService,
        IRequestHandler<CadastraCategoriaProdutoCommand, CategoriaProdutoDTO>,
        IRequestHandler<AtualizaCategoriaProdutoCommand, CategoriaProdutoDTO>,
        IRequestHandler<DeletaCategoriaProdutoCommand, CategoriaProdutoDTO>
    {
        private readonly ICategoriaProdutoRepository _categoriaProdutoRepository;
        private readonly IMapper _mapper;

        public CategoriaProdutoHandler(INotificador notificador,
            ICategoriaProdutoRepository categoriaProdutoRepository,
            IMapper mapper)
            : base(notificador)
        {
            _categoriaProdutoRepository = categoriaProdutoRepository;
            _mapper = mapper;
        }

        public async Task<CategoriaProdutoDTO> Handle(CadastraCategoriaProdutoCommand request, CancellationToken cancellationToken)
        {
            var entidade = await new CategoriaProduto().Cadastrar(_categoriaProdutoRepository, request.Descricao);

            Notificar(entidade.ValidationResult);

            if (entidade.IsValid)
                await _categoriaProdutoRepository.Adicionar(entidade);

            return _mapper.Map<CategoriaProdutoDTO>(entidade);
        }

        public async Task<CategoriaProdutoDTO> Handle(AtualizaCategoriaProdutoCommand request, CancellationToken cancellationToken)
        {
            var entidade = await new CategoriaProduto().Atualizar(_categoriaProdutoRepository, request.Id, request.Descricao);

            Notificar(entidade.ValidationResult);

            if (entidade.IsValid)
                await _categoriaProdutoRepository.Atualizar(entidade);

            return _mapper.Map<CategoriaProdutoDTO>(entidade);
        }

        public async Task<CategoriaProdutoDTO> Handle(DeletaCategoriaProdutoCommand request, CancellationToken cancellationToken)
        {
            var entidade = await new CategoriaProduto().Deletar(_categoriaProdutoRepository, request.Id);

            Notificar(entidade.ValidationResult);

            if (entidade.IsValid)
                await _categoriaProdutoRepository.Atualizar(entidade);

            return _mapper.Map<CategoriaProdutoDTO>(entidade);
        }
    }
}