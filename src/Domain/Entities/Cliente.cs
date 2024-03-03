﻿using Domain.Adapters;
using Domain.Validations.Clientes;

namespace Domain.Entities
{
    public class Cliente : EntidadeBase<Guid>
    {
        public string? Nome { get; private set; }
        public string? Email { get; private set; }

        public async Task<Cliente> Cadastrar(IClienteRepository clienteRepository, string? nome, string? email)
        {
            Id = Guid.NewGuid();
            Nome = nome;
            Email = email;
            DataCadastro = DateTime.Now;

            await Validate(this, new CadastraClienteValidation(clienteRepository));

            return this;
        }

        public async Task<Cliente> Atualizar(IClienteRepository clienteRepository, Guid id, string? nome, string? email)
        {
            Id = id;
            Nome = nome;
            Email = email;
            DataAtualizacao = DateTime.Now;

            await Validate(this, new AtualizaClienteValidation(clienteRepository));

            return this;
        }

        public async Task<Cliente> Deletar(IClienteRepository clienteRepository, Guid id)
        {
            Id = id;
            DataExclusao = DateTime.Now;

            await Validate(this, new DeletaClienteValidation(clienteRepository));

            return this;
        }
    }
}