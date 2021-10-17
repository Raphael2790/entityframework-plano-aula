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

            builder.HasKey(c => c.Id);

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
                .HasColumnName("endereco_id");

            builder.HasOne(c => c.Endereco)
                .WithMany(e => e.Clientes)
                .HasForeignKey(c => c.EnderecoId);
        }
    }
}