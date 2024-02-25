using MediatR;
using Domain.Adapters;
using Domain.Entities;
using Application.Commands.TabelaPrecos;

namespace TechChallenge.src.Handlers
{
    public class TabelaPrecoHandler : IRequestHandler<CadastraTabelaPrecoCommand, TabelaPreco>,
        IRequestHandler<AtualizaTabelaPrecoCommand, TabelaPreco>,
        IRequestHandler<DeletaTabelaPrecoCommand, TabelaPreco>
    {
        private readonly ITabelaPrecoRepository _tabelaPrecoRepository;

        public TabelaPrecoHandler(ITabelaPrecoRepository tabelaPrecoRepository)
        {
            _tabelaPrecoRepository = tabelaPrecoRepository;
        }

        public async Task<TabelaPreco> Handle(CadastraTabelaPrecoCommand request, CancellationToken cancellationToken)
        {
            var entidade = await new TabelaPreco().Cadastrar(request.ProdutoId, request.Preco);

            if (entidade.IsValid)
                await _tabelaPrecoRepository.Adicionar(entidade);

            return entidade;
        }

        public async Task<TabelaPreco> Handle(AtualizaTabelaPrecoCommand request, CancellationToken cancellationToken)
        {
            var entidade = await new TabelaPreco().Atualizar(request.Id, request.ProdutoId, request.Preco);

            if (entidade.IsValid)
                await _tabelaPrecoRepository.Atualizar(entidade);

            return entidade;
        }

        public async Task<TabelaPreco> Handle(DeletaTabelaPrecoCommand request, CancellationToken cancellationToken)
        {
            var entidade = await new TabelaPreco().Deletar(request.Id);

            if (entidade.IsValid)
                await _tabelaPrecoRepository.Atualizar(entidade);

            return entidade;
        }
    }
}