namespace EncantosSalao.Dado.Semeando
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using EncantosSalao.Comum;
    using EncantosSalao.Dado.Modelos;

    public class SaloesSemeador : ISemeador
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Saloes.Any())
            {
                return;
            }

            var salons = new Salao[]
                {
                    // 1. Salao de cabeleireiro 
                    new Salao
                    {
                        Id = "semeado" + Guid.NewGuid().ToString(),
                        Nome = "Salão Encantos",
                        IdCategoria = 1,
                        IdCidade = 1,
                        Endereco = "Rua Paulo Faccini, 250",
                        UrlImagem = ConstantesGlobais.Imagens.EncantosSalao,
                        Avaliacao = 0.0,
                        ContarAvaliadores = 0,
                    },
                };

            await dbContext.AddRangeAsync(salons);
        }
    }
}
