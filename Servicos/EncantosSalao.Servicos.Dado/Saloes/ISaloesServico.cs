namespace EncantosSalao.Servicos.Dado.Saloes
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ISaloesServico
    {
        Task<IEnumerable<T>> PegaTodosAsync<T>();

        Task<IEnumerable<T>> PegaTodosOrdenandoFiltrandoPaginandoAsync<T>(
            string searchString,
            int? sortId,
            int pageSize,
            int pageIndex);

        Task<int> PegaContadorPorPaginacaoAsync(string searchString, int? sortId);

        Task<IEnumerable<string>> PegaTodosIdsPorCategoriaAsync(int idCategoria);

        Task<T> PegaPorIdAsync<T>(string id);

        Task<string> AdicionaAsync(string nome, int idCategoria, int idCidade, string endereco, string urlImagem);

        Task ExcluiAsync(string id);

        Task AvaliarSalaoAsync(string id, int valorAvaliado);
    }
}
