namespace EncantosSalao.Servicos.Dado.Cidades
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ICidadesServico
    {
        Task<IEnumerable<T>> PegaTodosAsync<T>();

        Task AdicionaAsync(string nome);

        Task ExcluiAsync(int id);
    }
}
