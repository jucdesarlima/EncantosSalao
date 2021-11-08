namespace EncantosSalao.Servicos.Dado.Agendamentos
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IAgendamentosServico
    {
        Task<T> PegaPorIdAsync<T>(string id);

        Task<IEnumerable<T>> PegaTodosAsync<T>();

        Task<IEnumerable<T>> PegaTodosPorSalaoAsync<T>(string idSalao);

        Task<IEnumerable<T>> PegaProximosPorUsuarioAsync<T>(string idUsuario);

        Task<IEnumerable<T>> PegaAnterioresPorUsuarioAsync<T>(string idUsuario);

        Task AdicionaAsync(string idUsuario, string idSalao, int idServico, DateTime dataHora);

        Task ExcluiAsync(string id);

        Task ConfirmaAsync(string id);

        Task RecusaAsync(string id);

        Task AvaliaAgendamentoAsync(string id);
    }
}
