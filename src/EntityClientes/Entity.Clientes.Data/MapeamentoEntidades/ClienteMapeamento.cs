using System.Collections.Generic;
using Entity.Clientes.Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entity.Clientes.Data.MapeamentoEntidades
{
    public class ClienteMapeamento : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable("clientes");

            builder.HasIndex(e => e.EnderecoId, "IX_clientes_endereco_id");

            builder.HasKey(c => c.Id).HasName("PK_clientes");

            builder.Property(c => c.Id)
                .HasColumnName("id");

            builder.Property(c => c.Nome)
                .HasColumnName("nome")
                .HasColumnType("varchar(150)")
                .HasMaxLength(150);

            builder.Property(c => c.Observacao)
                .HasColumnName("observacao")
                .HasColumnType("text");

            builder.Property(c => c.EnderecoId)
                .HasColumnName("endereco_id")
                .IsRequired();

            builder.Property(c => c.DataCadastro)
                .HasColumnName("data_cadastro")
                .HasColumnType("datetime(6)");

            builder.HasOne(c => c.Endereco)
                .WithMany(e => e.Clientes)
                .HasForeignKey(c => c.EnderecoId)
                .HasConstraintName("FK_clientes_enderecos_endereco_id");

            builder.HasData(new List<Cliente>(){
                new Cliente
                {
                    Id = 1,
                    Nome = "Raphael",
                    Observacao = "Pedidos devem ser entregues em determinado local",
                    EnderecoId = 1
                }
            });
        }
    }
}