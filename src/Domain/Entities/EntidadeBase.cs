using FluentValidation;
using FluentValidation.Results;
using System.ComponentModel.DataAnnotations.Schema;

namespace TechChallenge.src.Core.Domain.Entities
{
    public abstract class EntidadeBase<TId>
    {
        public EntidadeBase()
        {
            ValidationResult = new ValidationResult();
        }

        public TId? Id { get; protected set; }

        public DateTime DataCadastro { get; protected set; } = DateTime.Now;

        public DateTime DataAtualizacao { get; protected set; }

        public DateTime DataExclusao { get; protected set; }

        [NotMapped]
        public bool IsValid => ValidationResult != null && ValidationResult.IsValid;

        [NotMapped]
        public ValidationResult ValidationResult { get; set; }

        public async Task Validate<TModel>(TModel model, AbstractValidator<TModel> validator)
        {
            ValidationResult = await validator.ValidateAsync(model);
        }
    }
}