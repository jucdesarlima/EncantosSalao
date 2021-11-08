namespace EncantosSalao.Web
{
    using System.Reflection;

    using EncantosSalao.Dado;
    using EncantosSalao.Dado.Comum;
    using EncantosSalao.Dado.Comum.Repositorios;
    using EncantosSalao.Dado.Modelos;
    using EncantosSalao.Dado.Repositorios;
    using EncantosSalao.Dado.Semeando;
    using EncantosSalao.Servicos.Dado.Agendamentos;
    using EncantosSalao.Servicos.Dado.Categorias;
    using EncantosSalao.Servicos.Dado.Cidades;
    using EncantosSalao.Servicos.Dado.NoticiasBlog;
    using EncantosSalao.Servicos.Dado.Saloes;
    using EncantosSalao.Servicos.Dado.Servicos;
    using EncantosSalao.Servicos.Dado.ServicosSalaoServico;
    using EncantosSalao.Servicos.DateTimeParser;
    using EncantosSalao.Servicos.Mapeamento;
    using EncantosSalao.Servicos.Memsagens;
    using EncantosSalao.Web.VisaoModelos;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Http;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;

    public class Startup
    {
        private readonly IConfiguration configuration;

        public Startup(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(
                options => options.UseSqlServer(this.configuration.GetConnectionString("DefaultConnection")));

            services.AddDefaultIdentity<ApplicationUser>(IdentityOptionsProvider.GetIdentityOptions)
                .AddRoles<ApplicationRole>().AddEntityFrameworkStores<ApplicationDbContext>();

            services.Configure<CookiePolicyOptions>(
                options =>
                    {
                        options.CheckConsentNeeded = context => true;
                        options.MinimumSameSitePolicy = SameSiteMode.None;
                    });

            services.AddControllersWithViews();
            services.AddRazorPages();

            services.AddSingleton(this.configuration);

            // Data repositories
            services.AddScoped(typeof(IRepositorioEntidadeDeletavel<>), typeof(EfRepositorioEntidadeDeletavel<>));
            services.AddScoped(typeof(IRepositorio<>), typeof(EfRepositorio<>));
            services.AddScoped<IDbExecutorConsulta, DbExecutorConsulta>();


            // Application services
            services.AddTransient<IEmailSender, NullMessageSender>();
            services.AddTransient<INoticiasBlogServico, NoticiasBlogServico>();
            services.AddTransient<ICategoriasServico, CategoriasServico>();
            services.AddTransient<IServicosServico, ServicosServico>();
            services.AddTransient<ICidadesServico, CidadesServico>();
            services.AddTransient<ISaloesServico, SaloesServico>();
            services.AddTransient<ISalaoServicosServico, SalaoServicosServico>();
            services.AddTransient<IAgendamentosServico, AgendamentosServico>();
            services.AddTransient<IDateTimeParserService, DateTimeParserService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            AutoMapperConfig.RegisterMappings(typeof(ErroVisaoModelo).GetTypeInfo().Assembly);

            // Seed data on application startup
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                var dbContext = serviceScope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

                if (env.IsDevelopment())
                {
                    dbContext.Database.Migrate();
                }

                new AplicacaoDbContextoSemeador().SeedAsync(dbContext, serviceScope.ServiceProvider).GetAwaiter().GetResult();
            }

            if (env.IsDevelopment())
            {
                app.UseStatusCodePagesWithReExecute("/Principal/Error/{0}");
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseStatusCodePagesWithReExecute("/Principal/Error/{0}");
                app.UseExceptionHandler("/Principal/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseCookiePolicy();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(
                endpoints =>
                    {
                        endpoints.MapControllerRoute("areaRoute", "{area:exists}/{controller=Principal}/{action=Index}/{id?}");
                        endpoints.MapControllerRoute("default", "{controller=Principal}/{action=Index}/{id?}");
                        endpoints.MapRazorPages();
                    });
        }
    }
}
