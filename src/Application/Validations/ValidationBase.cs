using FluentValidation;
using TechChallenge.src.Core.Domain.Entities;

namespace TechChallenge.src.Core.Application.Validations
{
    public class ValidationBase<T> : AbstractValidator<T> where T : EntidadeBase<Guid>
    {
        public void ValidarId()
        {
            RuleFor(x => x.Id).NotNull().NotEmpty().WithMessage("Informe um Id válido.");
        }

        public void ValidarDataCadastro()
        {
            RuleFor(x => x.DataCadastro)
                .NotNull()
                .GreaterThanOrEqualTo(DateTime.MinValue)
                .LessThanOrEqualTo(DateTime.MaxValue)
                .WithMessage("Informe uma Data de Cadastro válida.");
        }

        public void ValidarDataAtualizacao()
        {
            RuleFor(x => x.DataAtualizacao)
                .NotNull()
                .GreaterThanOrEqualTo(DateTime.MinValue)
                .LessThanOrEqualTo(DateTime.MaxValue)
                .WithMessage("Informe uma Data de Atualização válida.");
        }

        public void ValidarDataExclusao()
        {
            RuleFor(x => x.DataExclusao)
                .NotNull()
                .GreaterThanOrEqualTo(DateTime.MinValue)
                .LessThanOrEqualTo(DateTime.MaxValue)
                .WithMessage("Informe uma Data de Exclusão válida.");
        }
    }
}