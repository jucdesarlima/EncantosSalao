namespace EncantosSalao.Dado.Semeando
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using EncantosSalao.Comum;
    using EncantosSalao.Dado.Modelos;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.Extensions.DependencyInjection;

    public class ContasSemeador : ISemeador
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            var usuarioGerente = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            var papelGerente = serviceProvider.GetRequiredService<RoleManager<ApplicationRole>>();

            // Cria Admin
            await CreateUser(
                usuarioGerente,
                papelGerente,
                ConstantesGlobais.SemeandoContas.EmailAdmin,
                ConstantesGlobais.NomePapelAdministrador);

            // Cria Gerente do Salao
            await CreateUser(
                usuarioGerente,
                papelGerente,
                ConstantesGlobais.SemeandoContas.EmailGerenteSalao,
                ConstantesGlobais.NomePapelGerenteSalao);

            // Cria Usuario
            await CreateUser(
                usuarioGerente,
                papelGerente,
                ConstantesGlobais.SemeandoContas.EmailUsuario);
        }

        private static async Task CreateUser(
            UserManager<ApplicationUser> usuarioGerente, RoleManager<ApplicationRole> papelGerente, string email, string nomePapel = null)
        {
            var usuario = new ApplicationUser
            {
                UserName = email,
                Email = email,
            };

            var senha = ConstantesGlobais.SemeandoContas.Senha;

            if (nomePapel != null)
            {
                var papel = await papelGerente.FindByNameAsync(nomePapel);

                if (!usuarioGerente.Users.Any(x => x.Papeis.Any(x => x.RoleId == papel.Id)))
                {
                    var result = await usuarioGerente.CreateAsync(usuario, senha);

                    if (result.Succeeded)
                    {
                        await usuarioGerente.AddToRoleAsync(usuario, nomePapel);
                    }
                }
            }
            else
            {
                if (!usuarioGerente.Users.Any(x => x.Papeis.Count() == 0))
                {
                    var result = await usuarioGerente.CreateAsync(usuario, senha);
                }
            }
        }
    }
}
