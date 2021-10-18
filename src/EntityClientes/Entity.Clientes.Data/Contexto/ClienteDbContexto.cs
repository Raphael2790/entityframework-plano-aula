﻿using Microsoft.EntityFrameworkCore;
using Entity.Clientes.Domain.Entidades;
using Entity.Clientes.Data.MapeamentoEntidades;

#nullable disable

namespace Entity.Clientes.Data.Contexto
{
    public partial class ClienteDbContexto : DbContext
    {
        public ClienteDbContexto()
        {
        }

        public ClienteDbContexto(DbContextOptions<ClienteDbContexto> options)
            : base(options)
        {
        }

        public virtual DbSet<Cliente> Clientes { get; set; }
        public virtual DbSet<Endereco> Enderecos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql("server=localhost;database=EntityFrameworkComunidade;user=root;password=root", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.26-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_0900_ai_ci");

            modelBuilder.ApplyConfiguration<Cliente>(new ClienteMapeamento());

            modelBuilder.ApplyConfiguration<Endereco>(new EnderecoMapeamento());

            //modelBuilder.ApplyConfigurationsFromAssembly(typeof(ClienteDbContexto).Assembly);

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
