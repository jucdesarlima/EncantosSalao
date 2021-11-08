namespace EncantosSalao.Dado.Semeando
{
    using System;
    using System.Threading.Tasks;

    public interface ISemeador
    {
        Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider);
    }
}
