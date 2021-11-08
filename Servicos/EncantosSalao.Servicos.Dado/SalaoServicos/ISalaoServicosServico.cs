namespace EncantosSalao.Servicos.Dado.ServicosSalaoServico
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ISalaoServicosServico
    {
        Task<T> PegaPorIdAsync<T>(string idSalao, int idServico);

        Task AdicionaAsync(string idSalao, IEnumerable<int> idsServico);

        Task AdicionaAsync(IEnumerable<string> idsSalao, int idServico);

        Task AlteraStatusDisponivelAsync(string idSalao, int idServico);
    }
}
