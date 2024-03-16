using Caelum.Stella.CSharp.Validation;

namespace Domain.ValueObjects
{
    public class CPF
    {
        public string? Numero { get; private set; }

        public CPF(string? numero)
        {
            Numero = numero;
        }

        // Para o EF
        protected CPF()
        { }

        public bool IsValidado => new CPFValidator().IsValid(Numero);
    }
}