namespace EncantosSalao.Dado.Semeando
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using EncantosSalao.Comum;
    using EncantosSalao.Dado.Modelos;
    using Microsoft.EntityFrameworkCore;

    public class AgendamentosSemeador : ISemeador
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Agendamentos.Any())
            {
                return;
            }

            var agendamentos = new List<Agendamentos>();

            // Pega o Id do usuario
            var idUsuario = dbContext.Users.Where(x => x.Email == ConstantesGlobais.SemeandoContas.EmailUsuario).FirstOrDefault().Id;

            // Pega os Ids dos Saloes
            var idsSaloes = await dbContext.Saloes.Select(x => x.Id).Take(ConstantesGlobais.ContadoresDadosSemeados.Saloes).ToListAsync();

            foreach (var idSalao in idsSaloes)
            {
                // Obtenha um serviço de cada salão
                var idServico = dbContext.ServicosSalao.Where(x => x.IdSalao == idSalao).FirstOrDefault().IdServico;

                // Adicionar próximos agendamentos
                agendamentos.Add(new Agendamentos
                {
                    Id = Guid.NewGuid().ToString(),
                    DataHora = DateTime.UtcNow.AddDays(5),
                    IdUsuario = idUsuario,
                    IdSalao = idSalao,
                    IdServico = idServico,
                });

                // Adicionar agendamentos anteriores
                agendamentos.Add(new Agendamentos
                {
                    Id = Guid.NewGuid().ToString(),
                    DataHora = DateTime.UtcNow.AddDays(-5),
                    IdUsuario = idUsuario,
                    IdSalao = idSalao,
                    IdServico = idServico,
                    Confirmado = true,
                });

                // Mais agendamentos anteriores para testar a opcao AvalieAgendamentoAnterior
                agendamentos.Add(new Agendamentos
                {
                    Id = Guid.NewGuid().ToString(),
                    DataHora = DateTime.UtcNow.AddDays(-10),
                    IdUsuario = idUsuario,
                    IdSalao = idSalao,
                    IdServico = idServico,
                    Confirmado = true,
                });
            }

            await dbContext.AddRangeAsync(agendamentos);
        }
    }
}
