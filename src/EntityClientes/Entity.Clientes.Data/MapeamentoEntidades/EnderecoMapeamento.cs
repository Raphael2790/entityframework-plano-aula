using System.Collections.Generic;
using Entity.Clientes.Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entity.Clientes.Data.MapeamentoEntidades
{
    public class EnderecoMapeamento : IEntityTypeConfiguration<Endereco>
    {
        public void Configure(EntityTypeBuilder<Endereco> builder)
        {
            builder.ToTable("enderecos");

            builder.HasKey(e => e.Id)
                .HasName("PK_clientes");

            builder.HasIndex(e => e.Id, "IX_PK_enderecoid");

            builder.Property(e => e.Id)
                .HasColumnName("id")
                .HasColumnType("int");

            builder.Property(e => e.Cep)
                .HasColumnName("cep")
                .HasMaxLength(10)
                .IsRequired();

            builder.Property(e => e.Logradouro)
                .HasColumnName("logradouro")
                .HasColumnType("varchar(255)")
                .IsRequired();

            
            builder.Property(e => e.Bairro)
                .HasColumnName("bairro")
                .HasColumnType("varchar(150)")
                .IsRequired();

            builder.Property(e => e.Numero)
                .HasColumnName("numero")
                .HasColumnType("varchar(30)")
                .IsRequired();

            builder.Property(e => e.Complemento)
                .HasColumnType("varchar(255)")
                .HasColumnName("complemento")
                .IsRequired();

            builder.Property(e => e.Cidade)
               .HasColumnType("varchar(150)")
               .HasColumnName("cidade")
               .IsRequired();

            builder.Property(e => e.Estado)
                .HasColumnType("varchar(150)")
                .HasColumnName("estado")
                .IsRequired();

            //Definição opicional uma vez que feita na classe Cliente
            builder.HasMany(e => e.Clientes)
                .WithOne(c => c.Endereco)
                .HasForeignKey(c => c.EnderecoId);

            builder.HasData(new List<Endereco>(){
                 new Endereco
                    {
                        Id = 1,
                        Logradouro = "Rua Antonia Aparecida",
                        Bairro = "Santa Clara",
                        Cidade = "São Paulo",
                        Cep = "019187-091",
                        Complemento = "Casa 10",
                        Estado = "SP",
                        Numero = "345"
                    }
            });
        }
    }
}