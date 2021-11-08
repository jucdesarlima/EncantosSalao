namespace EncantosSalao.Dado.Semeando
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using EncantosSalao.Dado.Modelos;

    public class ServicosSalaoSemeador : ISemeador
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.ServicosSalao.Any())
            {
                return;
            }

            var servicosSalao = new List<ServicoSalao>();

            // Para cada salão adiciona todos os serviços a partir desta Categoria
            foreach (var salao in dbContext.Saloes)
            {
                var idSalao = salao.Id;
                var idCategoria = salao.IdCategoria;

                foreach (var servico in dbContext.Servicos.Where(x => x.IdCategoria == idCategoria))
                {
                    var idServico = servico.Id;

                    servicosSalao.Add(new ServicoSalao
                    {
                        IdSalao = idSalao,
                        IdServico = idServico,
                        Disponivel = true,
                    });
                }
            }

            await dbContext.AddRangeAsync(servicosSalao);
        }
    }
}
