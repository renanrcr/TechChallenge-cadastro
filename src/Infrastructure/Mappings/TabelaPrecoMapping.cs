using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using TechChallenge.src.Core.Domain.Entities;
using System.Reflection.Emit;

namespace TechChallenge.src.Adapters.Driven.Infra.Mappings
{
    public class TabelaPrecoMapping : IEntityTypeConfiguration<TabelaPreco>
    {
        public void Configure(EntityTypeBuilder<TabelaPreco> builder)
        {
            builder.HasKey(p => p.Id);

            // 1 : 1 => TabelaPreco : Produto
            builder.HasOne(f => f.Produto)
                .WithOne(e => e.TabelaPreco);

            builder.Property(p => p.Preco)
                .IsRequired()
                .HasColumnType("decimal(18,4)");

            builder.ToTable("TabelaPreco");
        }
    }
}