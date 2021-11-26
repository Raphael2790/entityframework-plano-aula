using Microsoft.EntityFrameworkCore;
using Entity.Produtos.Domain.Entidades;
using Entity.Produtos.Domain.Repositories;
using System.Threading.Tasks;

namespace Entity.Produtos.Data.Contexto
{
    public partial class ProdutosDbContexto : DbContext, IUnitOfWork
    {
        public ProdutosDbContexto()
        {
        }

        public ProdutosDbContexto(DbContextOptions<ProdutosDbContexto> options)
            : base(options)
        {
        }

        public virtual DbSet<Produto> Produtos { get; set; }
        public virtual DbSet<Categoria> Categorias {get;set;}
        public virtual DbSet<Endereco> Enderecos {get;set;}
        public virtual DbSet<Fornecedor> Fornecedores {get;set;}

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
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ProdutosDbContexto).Assembly);

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

        public async Task<bool> Commit() => await base.SaveChangesAsync() > 0;
    }
}