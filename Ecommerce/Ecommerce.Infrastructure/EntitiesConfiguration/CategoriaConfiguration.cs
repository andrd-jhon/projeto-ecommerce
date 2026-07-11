using Ecommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Catalogo.Infrastructure.EntitiesConfiguration;

public class CategoriaConfiguration : IEntityTypeConfiguration<Categoria>
{
    public void Configure(EntityTypeBuilder<Categoria> builder)
    {
        //Chave primária
        builder.HasKey(c => c.Id);

        //Propriedades
        builder.Property(c => c.Nome)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(c => c.Ativo)
            .HasDefaultValue(true)
            .IsRequired();

        builder.Property(c => c.DataCriacao)
            .IsRequired();

        builder.Property(c => c.DataAtualizacao)
            .IsRequired(false);

        //relacionamento já definido em -->ProdutoConfiguration<--
    }
}
