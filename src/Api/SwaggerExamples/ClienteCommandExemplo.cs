using Application.Commands.Clientes;
using Swashbuckle.AspNetCore.Filters;

namespace API.SwaggerExamples
{
    public class CadastraClienteCommandExemplo : IMultipleExamplesProvider<CadastraClienteCommand>
    {
        public IEnumerable<SwaggerExample<CadastraClienteCommand>> GetExamples()
        {
            yield return SwaggerExample.Create("200 - Sucesso", new CadastraClienteCommand
            {
                Nome = "TechChallenge",
                Email = "cliente@mail.com.br",
            });
        }
    }

    public class AtualizaClienteCommandExemplo : IMultipleExamplesProvider<AtualizaClienteCommand>
    {
        public IEnumerable<SwaggerExample<AtualizaClienteCommand>> GetExamples()
        {
            yield return SwaggerExample.Create("200 - Sucesso", new AtualizaClienteCommand
            {
                Id = new Guid("13dfb2a8-868a-4587-a1df-82288210c54c"),
                Nome = "TechChallenge",
                Email = "techChallenge@mail.com.br",
            });
        }
    }

    public class DeletaClienteCommandExemplo : IMultipleExamplesProvider<DeletaClienteCommand>
    {
        public IEnumerable<SwaggerExample<DeletaClienteCommand>> GetExamples()
        {
            yield return SwaggerExample.Create("200 - Sucesso", new DeletaClienteCommand
            {
                Id = new Guid("13dfb2a8-868a-4587-a1df-82288210c54c"),
            });
        }
    }
}
