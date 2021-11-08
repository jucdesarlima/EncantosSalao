namespace EncantosSalao.Servicos.Dado.Agendamentos
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using EncantosSalao.Dado.Comum.Repositorios;
    using EncantosSalao.Dado.Modelos;
    using EncantosSalao.Servicos.Mapeamento;
    using Microsoft.EntityFrameworkCore;

    public class AgendamentosServico : IAgendamentosServico
    {
        private readonly IRepositorioEntidadeDeletavel<Agendamentos> agendamentosRepositorio;

        public AgendamentosServico(IRepositorioEntidadeDeletavel<Agendamentos> agendamentosRepositorio)
        {
            this.agendamentosRepositorio = agendamentosRepositorio;
        }

        public async Task<T> PegaPorIdAsync<T>(string id)
        {
            var agendamento =
                await this.agendamentosRepositorio
                .All()
                .Where(x => x.Id == id)
                .To<T>().FirstOrDefaultAsync();
            return agendamento;
        }

        public async Task<IEnumerable<T>> PegaTodosAsync<T>()
        {
            var agendamento =
                await this.agendamentosRepositorio
                .All()
                .OrderByDescending(x => x.DataHora)
                .To<T>().ToListAsync();
            return agendamento;
        }

        public async Task<IEnumerable<T>> PegaTodosPorSalaoAsync<T>(string idSalao)
        {
            var agendamento =
                await this.agendamentosRepositorio
                .All()
                .Where(x => x.IdSalao == idSalao)
                .OrderByDescending(x => x.DataHora)
                .To<T>().ToListAsync();
            return agendamento;
        }

        public async Task<IEnumerable<T>> PegaProximosPorUsuarioAsync<T>(string userId)
        {
            var agendamento =
                await this.agendamentosRepositorio
                .All()
                .Where(x => x.IdUsuario == userId
                        && x.DataHora.Date > DateTime.UtcNow.Date)
                .OrderBy(x => x.DataHora)
                .To<T>().ToListAsync();
            return agendamento;
        }

        public async Task<IEnumerable<T>> PegaAnterioresPorUsuarioAsync<T>(string userId)
        {
            var agendamento =
                await this.agendamentosRepositorio
                .All()
                .Where(x => x.IdUsuario == userId
                        && x.DataHora.Date < DateTime.UtcNow.Date
                        && x.Confirmado == true)
                .OrderBy(x => x.DataHora)
                .To<T>().ToListAsync();
            return agendamento;
        }

        public async Task AdicionaAsync(string idUsuario, string idSalao, int idServico, DateTime dataHora)
        {
            await this.agendamentosRepositorio.AddAsync(new Agendamentos
            {
                Id = Guid.NewGuid().ToString(),
                DataHora = dataHora,
                IdUsuario = idUsuario,
                IdSalao = idSalao,
                IdServico = idServico,
            });
            await this.agendamentosRepositorio.SaveChangesAsync();
        }

        public async Task ExcluiAsync(string id)
        {
            var agendamento =
                await this.agendamentosRepositorio
                .AllAsNoTracking()
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();
            this.agendamentosRepositorio.Delete(agendamento);
            await this.agendamentosRepositorio.SaveChangesAsync();
        }

        public async Task ConfirmaAsync(string id)
        {
            var agendamento =
                await this.agendamentosRepositorio
                .All()
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();
            agendamento.Confirmado = true;
            await this.agendamentosRepositorio.SaveChangesAsync();
        }

        public async Task RecusaAsync(string id)
        {
            var agendamento =
                await this.agendamentosRepositorio
                .All()
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();
            agendamento.Confirmado = false;
            await this.agendamentosRepositorio.SaveChangesAsync();
        }

        public async Task AvaliaAgendamentoAsync(string id)
        {
            var agendamento =
                await this.agendamentosRepositorio
                .All()
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();
            agendamento.EstaSalaoAvaliadoPeloUsuario = true;
            await this.agendamentosRepositorio.SaveChangesAsync();
        }
    }
}
