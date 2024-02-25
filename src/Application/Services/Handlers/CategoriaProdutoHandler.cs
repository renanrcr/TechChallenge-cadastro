using AutoMapper;
using MediatR;
using TechChallenge.Api.DTOs;
using TechChallenge.src.Core.Application.Services;
using TechChallenge.src.Core.Domain.Adapters;
using TechChallenge.src.Core.Domain.Commands.CategoriaProdutos;
using TechChallenge.src.Core.Domain.Entities;

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
            var entidade = await new CategoriaProduto().Cadastrar(request);

            Notificar(entidade.ValidationResult);

            if (entidade.IsValid)
                await _categoriaProdutoRepository.Adicionar(entidade);

            return _mapper.Map<CategoriaProdutoDTO>(entidade);
        }

        public async Task<CategoriaProdutoDTO> Handle(AtualizaCategoriaProdutoCommand request, CancellationToken cancellationToken)
        {
            var entidade = await new CategoriaProduto().Atualizar(request);

            Notificar(entidade.ValidationResult);

            if (entidade.IsValid)
                await _categoriaProdutoRepository.Atualizar(entidade);

            return _mapper.Map<CategoriaProdutoDTO>(entidade);
        }

        public async Task<CategoriaProdutoDTO> Handle(DeletaCategoriaProdutoCommand request, CancellationToken cancellationToken)
        {
            var entidade = await new CategoriaProduto().Deletar(request);

            Notificar(entidade.ValidationResult);

            if (entidade.IsValid)
                await _categoriaProdutoRepository.Atualizar(entidade);

            return _mapper.Map<CategoriaProdutoDTO>(entidade);
        }
    }
}