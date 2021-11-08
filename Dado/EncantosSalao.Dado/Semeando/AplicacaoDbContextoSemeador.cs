namespace EncantosSalao.Dado.Semeando
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Logging;

    public class AplicacaoDbContextoSemeador : ISemeador
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext == null)
            {
                throw new ArgumentNullException(nameof(dbContext));
            }

            if (serviceProvider == null)
            {
                throw new ArgumentNullException(nameof(serviceProvider));
            }

            var logger = serviceProvider.GetService<ILoggerFactory>().CreateLogger(typeof(AplicacaoDbContextoSemeador));

            var seeders = new List<ISemeador>
                          {
                              new PapeisSemeador(),
                              new ContasSemeador(),
                              new NoticiasBlogSemeador(),
                              new CategoriasSemeador(),
                              new ServicosSemeador(),
                              new CidadesSemeador(),
                              new SaloesSemeador(),
                              new ServicosSalaoSemeador(),
                              new AgendamentosSemeador(),
                          };

            foreach (var seeder in seeders)
            {
                await seeder.SeedAsync(dbContext, serviceProvider);
                await dbContext.SaveChangesAsync();
                logger.LogInformation($"Seeder {seeder.GetType().Name} done.");
            }
        }
    }
}
