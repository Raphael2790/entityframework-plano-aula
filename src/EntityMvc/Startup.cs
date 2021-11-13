using Entity.Clientes.Data.Contexto;
using Entity.Clientes.Data.Queries;
using Entity.Clientes.Data.Repositories;
using Entity.Clientes.Domain.Interfaces;
using Entity.Clientes.Domain.Interfaces.Repositories;
using Entity.Pedidos.Data.Contexto;
using Entity.Produtos.Data.Contexto;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace entity_framework
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var connetionString = Configuration.GetConnectionString("DefaultConnection");
            //services.AddDbContext<DbContexto>(options => options.UseMySql(connetionString, ServerVersion.AutoDetect(connetionString)));
            services.AddDbContext<ProdutosDbContexto>(options => options.UseMySql(connetionString, ServerVersion.AutoDetect(connetionString)));
            services.AddDbContext<PedidosDbContexto>(options => options.UseMySql(connetionString, ServerVersion.AutoDetect(connetionString)));
            services.AddDbContext<ClienteDbContexto>(options => options.UseMySql(connetionString, ServerVersion.AutoDetect(connetionString)));
            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<IClientesQuery, ClientesConsultas>();
            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
