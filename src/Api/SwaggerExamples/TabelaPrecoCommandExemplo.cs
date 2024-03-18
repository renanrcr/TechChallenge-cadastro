using Application.Commands.TabelaPrecos;
using Swashbuckle.AspNetCore.Filters;

namespace API.SwaggerExamples
{
    public class CadastraTabelaPrecoCommandExemplo : IMultipleExamplesProvider<CadastraTabelaPrecoCommand>
    {
        public IEnumerable<SwaggerExample<CadastraTabelaPrecoCommand>> GetExamples()
        {
            yield return SwaggerExample.Create("200 - Sucesso", new CadastraTabelaPrecoCommand
            {
                ProdutoId = new Guid("528e871f-9615-4fab-b387-330fc695405d"),
                Preco = 22.90m
            });
        }
    }

    public class AtualizaTabelaPrecoCommandExemplo : IMultipleExamplesProvider<AtualizaTabelaPrecoCommand>
    {
        public IEnumerable<SwaggerExample<AtualizaTabelaPrecoCommand>> GetExamples()
        {
            yield return SwaggerExample.Create("200 - Sucesso", new AtualizaTabelaPrecoCommand
            {
                Id = new Guid("528e871f-9615-4fab-b387-330fc695405d"),
                Preco = 19.90m
            });
        }
    }

    public class DeletaTabelaPrecoCommandExemplo : IMultipleExamplesProvider<DeletaTabelaPrecoCommand>
    {
        public IEnumerable<SwaggerExample<DeletaTabelaPrecoCommand>> GetExamples()
        {
            yield return SwaggerExample.Create("200 - Sucesso", new DeletaTabelaPrecoCommand
            {
                Id = new Guid("528e871f-9615-4fab-b387-330fc695405d"),
            });
        }
    }
}
