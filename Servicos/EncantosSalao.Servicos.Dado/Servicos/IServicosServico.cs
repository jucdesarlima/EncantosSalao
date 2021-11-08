namespace EncantosSalao.Servicos.Dado.Servicos
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IServicosServico
    {
        Task<IEnumerable<T>> PegaTodosAsync<T>();

        Task<IEnumerable<int>> PegaTodosidsPorCategoriaAsync(int idCategoria);

        Task<int> AdicionaAsync(string nome, int idCategoria, string descricao);

        Task ExcluiAsync(int id);
    }
}
