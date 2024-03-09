using Application.Commands.CategoriaProdutos;
using Swashbuckle.AspNetCore.Filters;

namespace API.SwaggerExamples
{
    public class CadastraCategoriaProdutoCommandExemplo : IMultipleExamplesProvider<CadastraCategoriaProdutoCommand>
    {
        public IEnumerable<SwaggerExample<CadastraCategoriaProdutoCommand>> GetExamples()
        {
            yield return SwaggerExample.Create("200 - Sucesso", new CadastraCategoriaProdutoCommand
            {
                Descricao = "Lanche",
            });
        }
    }

    public class AtualizaCategoriaProdutoCommandExemplo : IMultipleExamplesProvider<AtualizaCategoriaProdutoCommand>
    {
        public IEnumerable<SwaggerExample<AtualizaCategoriaProdutoCommand>> GetExamples()
        {
            yield return SwaggerExample.Create("200 - Sucesso", new AtualizaCategoriaProdutoCommand
            {
                Id = new Guid("b9b84b5a-12c0-4b2d-8404-b28de279e61d"),
                Descricao = "Lanche",
            });
        }
    }

    public class DeletaCategoriaProdutoCommandExemplo : IMultipleExamplesProvider<DeletaCategoriaProdutoCommand>
    {
        public IEnumerable<SwaggerExample<DeletaCategoriaProdutoCommand>> GetExamples()
        {
            yield return SwaggerExample.Create("200 - Sucesso", new DeletaCategoriaProdutoCommand
            {
                Id = new Guid("b9b84b5a-12c0-4b2d-8404-b28de279e61d"),
            });
        }
    }
}
