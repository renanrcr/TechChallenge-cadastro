namespace Application.DTOs
{
    public class ProdutoDTO
    {
        public Guid Id { get; set; }
        public Guid CategoriaProdutoId { get; set; }
        public string? Nome { get; set; }
        public string? Descricao { get; set; }
    }
}