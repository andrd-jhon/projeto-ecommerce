using Ecommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Infrastructure.EntitiesConfiguration
{
    public class ProdutoConfiguration : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.ToTable("Produtos");

            builder.HasKey(t => t.Id);

            builder.Property(p => p.Ativo)
                .IsRequired();

            builder.Property(p => p.Nome)
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(p => p.Preco)
                .HasPrecision(18, 2)
                .IsRequired();

            builder.Property(p => p.DataCriacao)
                .IsRequired();

            builder.Property(p => p.DataAtualizacao);

            builder.Property(p => p.CategoriaId)
                .IsRequired();

            builder.HasOne(e => e.Categoria).WithMany(e => e.Produtos).HasForeignKey(e => e.CategoriaId);
        }
    }
}
