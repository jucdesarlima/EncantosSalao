namespace EncantosSalao.Dado.Semeando
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using EncantosSalao.Dado.Modelos;

    public class CidadesSemeador : ISemeador
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Cidades.Any())
            {
                return;
            }

            var cidades = new Cidade[]
                {
                    new Cidade // Id = 1
                    {
                        Nome = "Guarulhos",
                    },
                    new Cidade // Id = 2
                    {
                        Nome = "São Paulo",
                    },
                };

            // Need them in particular order
            foreach (var cidade in cidades)
            {
                await dbContext.AddAsync(cidade);
                await dbContext.SaveChangesAsync();
            }
        }
    }
}
