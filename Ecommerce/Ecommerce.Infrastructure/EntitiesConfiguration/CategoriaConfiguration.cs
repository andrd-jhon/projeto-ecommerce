using Ecommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Catalogo.Infrastructure.EntitiesConfiguration;

public class CategoriaConfiguration : IEntityTypeConfiguration<Categoria>
{
    public void Configure(EntityTypeBuilder<Categoria> builder)
    {
        builder.HasKey(t => t.CategoriaId);
        builder.Property(p => p.CategoriaNome).HasMaxLength(100).IsRequired();
    }
}
