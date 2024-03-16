namespace Domain.ValueObjects
{
    public static class MensagemRetorno
    {
        public const string CategoriaInformeUmaDescricao = "Informe uma descrição para a categoria.";
        public const string CategoriaJaExiste = "A descrição informada já existe na base de dados.";


        public const string ProdutoInformeUmNome = "Informe um nome para o produto.";
        public const string ProdutoInformeUmaDescricao = "Informe uma descrição para o produto.";

        public const string TabelaPrecoInformeUmProduto = "Informe um Id de produto válido.";
        public const string TabelaPrecoInformeUmPreco = "Informe um preço.";
        public const string TabelaPrecoNaoEncontrada = "A tabela de preço informada não foi encontrada.";
    }
}
