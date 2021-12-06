using Entity.Clientes.Application.Handlers;
using Entity.Clientes.Data.Contexto;
using Entity.Clientes.Data.Queries;
using Entity.Clientes.Data.Repositories;
using Entity.Clientes.Domain.Interfaces;
using Entity.Clientes.Domain.Interfaces.Repositories;
using Entity.Core.Mediator;
using Entity.Pedidos.Application.Handlers;
using Entity.Pedidos.Application.Queries;
using Entity.Pedidos.Data.Contexto;
using Entity.Pedidos.Data.Repositories;
using Entity.Pedidos.Domain.Repositories;
using Entity.Produtos.Application.Handlers;
using Entity.Produtos.Data.Contexto;
using Entity.Produtos.Data.Repositories;
using Entity.Produtos.Domain.Repositories;
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

            //Cotextos para injeção scoped
            services.AddScoped<ProdutosDbContexto>();
            services.AddScoped<PedidosDbContexto>();
            services.AddScoped<ClienteDbContexto>();

            //Repositories
            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<IProdutosRepository, ProdutosRepository>();
            services.AddScoped<IFornecedoresRepository, FornecedoresRepository>();
            services.AddScoped<IPedidosRepository, PedidosRepository>();
            services.AddScoped<IClientesQuery, ClientesConsultas>();
            services.AddScoped<IPedidosQueries, PedidoQueries>();

            services.AddSingleton<IMediatorHandler, MediatorHandler>((provider) => 
            {
                var service = new MediatorHandler();
                service.RegistrarEventHandler(new ClienteEventoHandler());
                service.RegistrarEventHandler(new ProdutosPedidosEventoHandler());
                service.RegistrarEventHandler(new ProdutosEstoqueBaixoHandler());
                service.RegistrarCommandHandler(new AtualizarPedidoHandler(provider.GetRequiredService<IPedidosRepository>()));
                service.RegistrarCommandHandler(new RemoverPedidoHandler(provider.GetRequiredService<IPedidosRepository>()));
                service.RegistrarCommandHandler(new NovoPedidoHandler(provider.GetRequiredService<IPedidosRepository>()));
                return service;
            });

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
