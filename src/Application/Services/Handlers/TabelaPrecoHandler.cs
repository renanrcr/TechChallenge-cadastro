using MediatR;
using Domain.Adapters;
using Domain.Entities;
using Application.Commands.TabelaPrecos;
using Application.DTOs;
using AutoMapper;
using Application.Services;

namespace TechChallenge.src.Handlers
{
    public class TabelaPrecoHandler : BaseService,
        IRequestHandler<CadastraTabelaPrecoCommand, TabelaPrecoDTO>,
        IRequestHandler<AtualizaTabelaPrecoCommand, TabelaPrecoDTO>,
        IRequestHandler<DeletaTabelaPrecoCommand, TabelaPrecoDTO>
    {
        private readonly ITabelaPrecoRepository _tabelaPrecoRepository;
        private readonly IMapper _mapper;

        public TabelaPrecoHandler(INotificador notificador, 
            ITabelaPrecoRepository tabelaPrecoRepository,
            IMapper mapper)
            : base(notificador)
        {
            _tabelaPrecoRepository = tabelaPrecoRepository;
            _mapper = mapper;
        }

        public async Task<TabelaPrecoDTO> Handle(CadastraTabelaPrecoCommand request, CancellationToken cancellationToken)
        {
            var entidade = await new TabelaPreco().Cadastrar(request.ProdutoId, request.Preco);

            Notificar(entidade.ValidationResult);

            if (entidade.IsValid)
                await _tabelaPrecoRepository.Adicionar(entidade);

            return _mapper.Map<TabelaPrecoDTO>(entidade);
        }

        public async Task<TabelaPrecoDTO> Handle(AtualizaTabelaPrecoCommand request, CancellationToken cancellationToken)
        {
            var entidade = await new TabelaPreco().Atualizar(request.Id, request.ProdutoId, request.Preco);

            Notificar(entidade.ValidationResult);

            if (entidade.IsValid)
                await _tabelaPrecoRepository.Atualizar(entidade);

            return _mapper.Map<TabelaPrecoDTO>(entidade);
        }

        public async Task<TabelaPrecoDTO> Handle(DeletaTabelaPrecoCommand request, CancellationToken cancellationToken)
        {
            var entidade = await new TabelaPreco().Deletar(request.Id);

            Notificar(entidade.ValidationResult);

            if (entidade.IsValid)
                await _tabelaPrecoRepository.Atualizar(entidade);

            return _mapper.Map<TabelaPrecoDTO>(entidade);
        }
    }
}