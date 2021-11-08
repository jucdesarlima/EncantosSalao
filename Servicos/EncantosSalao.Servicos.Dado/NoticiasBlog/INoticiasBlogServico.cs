namespace EncantosSalao.Servicos.Dado.NoticiasBlog
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface INoticiasBlogServico
    {
        Task<IEnumerable<T>> PegaTodosAsync<T>(int? count = null);

        Task<IEnumerable<T>> PegaTodosComPaginacaoAsync<T>(
            int? sortId,
            int pageSize,
            int pageIndex);

        Task<int> PegaContadorPorPaginacaoAsync();

        Task<T> PegaPorIdAsync<T>(int id);

        Task AdicionaAsync(string titulo, string conteudo, string autor, string urlImagem);

        Task ExcluiAsync(int id);
    }
}
