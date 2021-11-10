using System.Collections.Generic;
using Entity.Produtos.Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entity.Produtos.Data.MapeamentoEntidades
{
    public class CategoriaMapeamento : IEntityTypeConfiguration<Categoria>
    {
        public void Configure(EntityTypeBuilder<Categoria> builder)
        {
            builder.ToTable("categorias");

            builder.HasKey(c => c.Id)
                .HasName("PK_categorias");

            builder.HasIndex(c => c.Id, "IX_PK_categorias");

            builder.Property(c => c.Id)
                .HasColumnName("id")
                .HasColumnType("int");

            builder.Property(c => c.Descricao)
                .HasColumnName("descricao")
                .HasMaxLength(250)
                .IsRequired();

            builder.HasMany(c => c.Produtos)
                .WithOne(p => p.Categoria)
                .HasForeignKey(c => c.CategoriaId)
                .HasConstraintName("FK_produtos_categorias_categoria_id");

            builder.HasData(new List<Categoria>()
            {
                new Categoria 
                {
                    Id = 1,
                    Descricao = "Alimentos"
                },
                new Categoria 
                {
                    Id = 2,
                    Descricao = "Eletrodomésticos"
                }
            });
        }
    }
}