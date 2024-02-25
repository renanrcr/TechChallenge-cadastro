using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using TechChallenge.src.Core.Domain.Entities;

namespace TechChallenge.src.Adapters.Driven.Infra.Mappings
{
    public class ProdutoMapping : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Nome)
                .IsRequired()
                .HasColumnType("varchar(50)");

            builder.Property(p => p.Descricao)
                .IsRequired()
                .HasColumnType("varchar(200)");

            // 1 : 1 => Produto : CategoriaProduto
            builder.HasOne(f => f.CategoriaProduto)
                .WithOne(e => e.Produto);

            // 1 : 1 => Produto : TabelaPreco
            builder.HasOne(f => f.TabelaPreco)
                .WithOne(e => e.Produto);

            builder.ToTable("Produto");
        }
    }
}
