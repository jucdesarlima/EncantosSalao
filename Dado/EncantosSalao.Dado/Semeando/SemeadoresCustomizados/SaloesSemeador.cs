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
                        Name = "Salão Encantos",
                        CategoryId = 1,
                        CityId = 1,
                        Address = "Rua Paulo Faccini, 250",
                        ImageUrl = ConstantesGlobais.Imagens.EncantosSalao,
                        Rating = 0.0,
                        RatersCount = 0,
                    },
                };

            await dbContext.AddRangeAsync(salons);
        }
    }
}
