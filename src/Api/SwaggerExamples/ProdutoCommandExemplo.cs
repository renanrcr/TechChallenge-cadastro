using Application.Commands.Produtos;
using Swashbuckle.AspNetCore.Filters;

namespace API.SwaggerExamples
{
    public class CadastraProdutoCommandExemplo : IMultipleExamplesProvider<CadastraProdutoCommand>
    {
        public IEnumerable<SwaggerExample<CadastraProdutoCommand>> GetExamples()
        {
            yield return SwaggerExample.Create("200 - Sucesso", new CadastraProdutoCommand
            {
                CategoriaProdutoId = new Guid("b9b84b5a-12c0-4b2d-8404-b28de279e61d"),
                Nome = "Hot Dog Tradicional",
                Descricao = "Salsicha, molho e batata palha.",
            });
        }
    }

    public class AtualizaProdutoCommandExemplo : IMultipleExamplesProvider<AtualizaProdutoCommand>
    {
        public IEnumerable<SwaggerExample<AtualizaProdutoCommand>> GetExamples()
        {
            yield return SwaggerExample.Create("200 - Sucesso", new AtualizaProdutoCommand
            {
                CategoriaProdutoId = new Guid("b9b84b5a-12c0-4b2d-8404-b28de279e61d"),
                Nome = "Hot Dog Tradicional",
                Descricao = "2 Salsicha, molho e batata palha.",
            });
        }
    }

    public class DeletaProdutoCommandExemplo : IMultipleExamplesProvider<DeletaProdutoCommand>
    {
        public IEnumerable<SwaggerExample<DeletaProdutoCommand>> GetExamples()
        {
            yield return SwaggerExample.Create("200 - Sucesso", new DeletaProdutoCommand
            {
                Id = new Guid("528e871f-9615-4fab-b387-330fc695405d"),
            });
        }
    }
}
