namespace EncantosSalao.Servicos.Dado.Categorias
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ICategoriasServico
    {
        Task<IEnumerable<T>> PegaTodosAsync<T>(int? count = null);

        Task<T> PegaPorIdAsync<T>(int id);

        Task AdicionaAsync(string name, string description, string imageUrl);

        Task ExcluiAsync(int id);
    }
}
