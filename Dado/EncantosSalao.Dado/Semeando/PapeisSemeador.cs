namespace EncantosSalao.Dado.Semeando
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using EncantosSalao.Comum;
    using EncantosSalao.Dado.Modelos;

    using Microsoft.AspNetCore.Identity;
    using Microsoft.Extensions.DependencyInjection;

    internal class PapeisSemeador : ISemeador
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            var papelGerente = serviceProvider.GetRequiredService<RoleManager<ApplicationRole>>();

            await SeedRoleAsync(papelGerente, ConstantesGlobais.NomePapelAdministrador);
            await SeedRoleAsync(papelGerente, ConstantesGlobais.NomePapelGerenteSalao);
        }

        private static async Task SeedRoleAsync(RoleManager<ApplicationRole> papelGerente, string papelNome)
        {
            var papel = await papelGerente.FindByNameAsync(papelNome);
            if (papel == null)
            {
                var result = await papelGerente.CreateAsync(new ApplicationRole(papelNome));
                if (!result.Succeeded)
                {
                    throw new Exception(string.Join(Environment.NewLine, result.Errors.Select(e => e.Description)));
                }
            }
        }
    }
}
